# Microsoft Azure SDK for .NET

The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

### Target Frameworks:

    * .NET Framework 4.5
    * Netstandard1.5, based on the NetCore framework 
    * .NET Portable Framework(Netstandard1.1 for NetCore), using profile 111

### Prerequisites:
  Install CoreCLR RC2 using [these steps](https://www.microsoft.com/net/core).

### Known issue and workaround:
   
### To build:

Using Visual Studio:

  - Open any solution, say, "src\ResourceManagement\Compute\Compute.sln".
  - Invoke "build" command.

Using the command line:

  - Ensure "msbuild.exe" is under environment pathes, which you can run the command file pre-installed by Visual Studio.
        *C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat*
  - Under repository root, there is a "build.proj", which you can build with. For example, to build a nuget package for compute management, run:
        *msbuild build.proj /t:build;package /p:scope=ResourceManagement\Compute*
  - For other supported flags, check out the top comment section inside "build.proj".
   

### To run the tests:

Using Visual Studio:

  - Build.
  - "Test Explorer" window will get populated with tests. Go select and invoke.

Using the command line:

  - Refer to the "To build" section to get the command window set up.
  - Invoke "Test" target from "Build.proj". Likely, you need to build test project first, so put in "build" target as well. 
        *msbuild build.proj /t:build;test /p:scope=ResourceManagement\Compute*

### To on-board new libraries
Follow existing library and create a new folder under "ResourceManagement".
  - Note: To simplify test discovery, the test folder must be named with ".test" or ".tests"
  
If for platform reasons that your library won't use NetCore project system, 3 notes
  - In your library csproject file, set the msbuild property "AutoRestProjects" to "true"
  - In your test project files, set both "AutoRestProjects" and "SDKTestProject" to "true"
  - To simplify test discovery, the test folder must be named with ".tests"

### Issues with Generated Code
Much of the SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead, file an issue describing the problem, OR refer to the the [AutoRest project](AutoRest) to view and modify the generator. 

[AutoRest]:https://github.com/azure/autorest

