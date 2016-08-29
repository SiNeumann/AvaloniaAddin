using System;
using System.Reflection;
using MonoDevelop.Core.Assemblies;
using MonoDevelop.Projects;
using System.IO;
using System.Linq;
namespace AvaloniaAddin
{
	public class AvaloniaProjectFlavour:PortableDotNetProjectFlavor
	{
		protected override void Initialize()
		{
			base.Initialize();
			Project.UseMSBuildEngine = true;
		}
		protected override void OnGetDefaultImports(System.Collections.Generic.List<string> imports)
		{
			try
			{
				var assPath = Assembly.GetExecutingAssembly().Location;
				FileInfo info = new FileInfo(assPath);
				var adict = info.Directory.GetDirectories().First(item => item.Name == "Assemblies");
				var files = adict.GetFiles().Where(item => item.Name.Contains("Avalonia"));
				foreach (var file in files)
				{

					var refer = ProjectReference.CreateAssemblyFileReference(file.FullName);
					Project.References.Add(refer);
				}
			}
			catch 
			{
			}
			imports.Add("$(MSBuildExtensionsPath32)\\Microsoft\\Portable\\$(TargetFrameworkVersion)\\Microsoft.Portable.CSharp.targets");

		}
	}
}

