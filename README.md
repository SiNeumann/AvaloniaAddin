# AvaloniaAddin
This is an addin for Monodevelop to add support for the Avalonia Framework. Please check out https://github.com/AvaloniaUI/Avalonia
for more information.
This Addin currently only provides a Project Template and some FileTemplates, hopefully there is more to come...
There are some  issuses.

NuGet 3.x is needed but on Monodevelop 6.1 NuGetVersion is currently 2.8.1. On Ubunut 16.04 you can install Nuget from packages
"sudo apt install nuget" and then copy the newer Nuget into the  monodevelop directory.
"sudo cp /usr/lib/nuget/NuGet.Core.dll /usr/local/lib/monodevelop/AddIns/MonoDevelop.PackageManagement/NuGet.Core.dll"
This should do the trick

This addin tries to work with the NugetPackages of Avalonia, currently I couldn't figure out to get Avalonia.Gtk.dll and Avalonia.Cairo.dll through Nuget.
As workaround these are included in the addin. 

If the Addin is installed you should be able to create a new Avalonia Project.Build + Start should show an empty window.

Please note:This is work in progress and as much as I wish to add feature I'm limited in time and experience of AddinDevelopment.
Help is always welcome
Licence :MIT


 
