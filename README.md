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
  - Most solutions support 3 solution configurations, "Net40", "Net45", and "Portable". you can use "Configuration Manager" to switch and build.

Using the command line:

  - Ensure "msbuild.exe" is under environment pathes, which you can run the command file pre-installed by Visual Studio.
        *C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat*
  - Under repository root, there is a "build.proj", which you can build with. For example, to build a nuget package for compute management, run:
        *msbuild build.proj /t:build;package /p:scope=ResourceManagement\Compute*
  - For other supported flags, check out the top comment section inside "build.proj".


### To run the tests:

Using Visual Studio:

  - Most test projects only build for "net45". To run them, switch solution configuration to "net45".
  - Build.
  - "Test Explorer" window will get populated with tests. Go select and invoke.

Using the command line:

  - Refer to the "To build" section to get the command window set up.
  - Invoke "Test" target from "Build.proj". Likely, you need to build test project first, so put in "build" target as well.
        *msbuild build.proj /t:build;test /p:scope=ResourceManagement\Compute*

### Issues with Generated Code
Much of the SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead, file an issue describing the problem, OR refer to the the [AutoRest project][AutoRest] to view and modify the generator.
>Note: the generated code in the master branch is from a private project. The SDK is migrating to use AutoRest with generated code described by Swagger. Not all of the generator code is public yet, but it will be over the next few weeks. (July 2015).

[AutoRest]: https://github.com/azure/autorest
