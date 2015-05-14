# Microsoft Azure SDK for .NET

The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

## Target Frameworks

- .NET Framework 4.0 and newer
- .Net Portable Framework, using profile 102
- Storage Libraries are available for Windows 8 for Windows Store development as well as Windows Phone 8

### To Build

#### Using Visual Studio

- Have Visual Studio 2013 RTM with update 2 at minimum
- Open any solution, and invoke "Build"
- Most solution support 3 solution configurations, Net40, Net45, Portable. you can use "Configruation Manager"to switch and build. Most test projects only build for "net45", so to run them, switch to "net45"

#### Using command line
- Make "msbuild.exe" is at default path. The earliest step is to run the shortcut preinstalled by Visual Studio, such as "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat".
- Switch to repository root, you should see a build file "build.proj"
- Invoke related target for different activities
  To build package: "msbuild build.proj /t:build;package /p:scope=ResourceManagement\Compute"
  For all other flags, check out the top comment section inside "build.proj" 

### To Run Tests

#### Using Visual Studio

- Most test projects only build for "net45", so to run them, switch to "net45"
- Build 
- See the "Test Explorer" gets populated with tests. Go select and invoke 

#### Using command line
- Refer to "To Build" section to get envionment set up
- Use "Test" target, such as "msbuild build.proj /t:test /p:scope=ResourceManagement\Compute". Likely, you need to build test proejct first, so invoke both "build;test" 

