# Microsoft Azure SDK for .NET

The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

### Target Frameworks:

    * .NET Framework 4.0 and newer.
    * .NET Portable Framework, using profile 102

### Prerequisites:
    * Visual Studio 2013 RTM with update 2 at minimum

### To build:

Using Visual Studio

    * Open any solution, say, "src\ResourceManagement\Compute\Compute.sln".
    * Invoke "build" command.
    * Most solutions support 3 solution configurations, "Net40", "Net45", and "Portable". you can use "Configruation Manager" to switch and build.

Using command line
    * Ensure "msbuild.exe" is under environment PATH. The earliest step is to run the shortcut pre-installed by Visual Studio, such as "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat".
    * Switch to repository root, where the build file of "build.proj" stays.
    * Invoke related target for different activities, such as build a nuget package for compute management.
          msbuild build.proj /t:build;package /p:scope=ResourceManagement\Compute
    * For all other supported flags, check out the top comment section inside "build.proj".

### To run tests

Using Visual Studio

    * Most test projects only build for "net45", so to run them, switch to solution configruation of "net45".
    * Build.
    * See the "Test Explorer" window gets populated with tests. Go select and invoke.

Using command line
    * Refer to "To build" section to get command windows set up.
    * Use "Test" target. Likely, you need to build test project first, so put "build" target as well.
        msbuild build.proj /t:build;test /p:scope=ResourceManagement\Compute".

