# Microsoft Azure SDK for .NET

The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

### Target Frameworks:

    * .NET Framework 4.0 and newer.
    * .NET Portable Framework, using profile 102

### Prerequisites:
    * Visual Studio 2013 RTM with update 2 at minimum

### To build:

Using Visual Studio:

  - Open any solution, say, "src\ResourceManagement\Compute\Compute.sln".
  - Invoke "build" command.
  - Most solutions support 3 solution configurations, "Net40", "Net45", and "Portable". you can use "Configruation Manager" to switch and build.

Using command line:

  - Ensure "msbuild.exe" is under environment PATH. The earliest step is to run the shortcut pre-installed by Visual Studio.
        *C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat*
  - Under repository root, there is a "build.proj", which you can build with. For example, to build a nuget package for compute management, run:
        *msbuild build.proj /t:build;package /p:scope=ResourceManagement\Compute*
  - For other supported flags, check out the top comment section inside "build.proj".
   

### To run tests

Using Visual Studio:

  - Most test projects only build for "net45". To run them, switch solution configuration to "net45".
  - Build.
  - "Test Explorer" window will get populated with tests. Go select and invoke.

Using command line:

  - Refer to the "To build" section to get the command window set up.
  - Invoke "Test" target from "Build.proj". Likely, you need to build test project first, so put in "build" target as well. 
        *msbuild build.proj /t:build;test /p:scope=ResourceManagement\Compute*
