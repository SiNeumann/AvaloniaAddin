using System;
using System.Reflection;
using MonoDevelop.Core.Assemblies;
using MonoDevelop.Projects;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AvaloniaAddin
{
	public class AvaloniaProjectFlavour:PortableDotNetProjectFlavor
	{
		protected override void Initialize()
		{
			base.Initialize();
			Project.UseMSBuildEngine = true;
		}
		protected override TargetFrameworkMoniker OnGetDefaultTargetFrameworkId()
		{
			Debug.Print(Project.Name);
			// Profile78 includes .NET 4.5+, Windows Phone 8, and Xamarin.iOS/Android, so make that our default.
			// Note: see also: PortableLibrary.xpt.xml
			if (!Project.Name.EndsWith(".Desktop"))
			{
				return new TargetFrameworkMoniker(".NETPortable", "4.5", "Profile78");

			}
			else 
			{
				return TargetFrameworkMoniker.NET_4_5;

			}
		}

		 protected override bool OnGetSupportsFramework(TargetFramework framework)
		{
			// Note: see also: PortableLibrary.xpt.xml
			if (!Project.Name.EndsWith(".Desktop"))
			{
				return framework.Id.Identifier == TargetFrameworkMoniker.ID_PORTABLE;
			}
			else 
			{
				return true;
			}
		}
		protected override void OnGetDefaultImports(System.Collections.Generic.List<string> imports)
		{


			if (!Project.Name.EndsWith(".Desktop"))
			{
				imports.Add("$(MSBuildExtensionsPath32)\\Microsoft\\Portable\\$(TargetFrameworkVersion)\\Microsoft.Portable.CSharp.targets");
			}
			else 
			{
				imports.Add("$(MSBuildToolsPath)\\Microsoft.CSharp.targets");
				var project= Project.ParentSolution.GetAllProjects().First(item => item.Name == Project.Name.Replace(".Desktop",""));
				var pRef=ProjectReference.CreateProjectReference(project);
				Project.References.Add(pRef);
				foreach (var f in Project.Files) 
				{
					Debug.Print(f.Name);
				}
				var file = Project.Files.First(item => item.Name.EndsWith("Program.cs"));
				var lines= File.ReadAllLines(file.FilePath);
				List<string> newLines = new List<string>();
				foreach (var line in lines) 
				{
					if (!line.Contains("namespace"))
					{
						newLines.Add(line);
					}
					else 
					{
						newLines.Add("namespace " + project.Name );
					}   
				}
				File.WriteAllLines(file.FilePath, newLines);
			}

		}

		 protected override async Task<List<AssemblyReference>> OnGetReferencedAssemblies(ConfigurationSelector configuration)
		{
			var res = await base.OnGetReferencedAssemblies(configuration);
			var asms = Project.TargetRuntime.AssemblyContext.GetAssemblies(Project.TargetFramework).Where(a => a.Package.IsFrameworkPackage).Select(a => new AssemblyReference(a.Location));
			res.AddRange(asms);
			return res;
		}
	}
}

