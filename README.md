# Microsoft Azure SDK for .NET

The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

### Target Frameworks:

* .NET Framework 4.5
* Netstandard1.5, based on the NetCore framework 
* .NET Portable Framework(Netstandard1.1 for NetCore), using profile 111

### Prerequisites:
  Install .Net CoreCLR using [these steps](https://www.microsoft.com/net/core).

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

## To on-board new libraries

### Project Structure

In "src\ResourceManagement", you will find packages for services that have already been implemented

  - Each service contains a package for their generated code, as well as a package for tests
  - The file 'generate.cmd', used to generate library code for the given service, can also be found in these packages

### Branches: AutoRest vs. master

The **AutoRest** branch contains the code generated from AutoRest.

The **master** branch contains the code generated from Hydra/Hyak.
  - Hydra/Hyak is Azure's legacy code generation technology.
  - This can still be used to generate client libraries, but the project is not being advanced in favor of AutoRest. Your team should move to AutoRest and Swagger as soon as possible.

### Standard Process

For a step-by-step process on how to generate C# code for your service and get it published, click [here](https://github.com/Azure/adx-documentation-pr/blob/master/engineering/autorest-to-powershell.md#phase-1---swagger-specs-to-net-sdk-using-autorest).

**Note**: if you receive a 404 error trying to access this page, click [here](https://aka.ms/azuregithub) and sign in with your Microsoft corporate account to gain access.

### Code Review Process

To see the requirements and process for checking code into the working branch, click [here](https://github.com/Azure/adx-documentation-pr/blob/master/engineering/adx_sdk_gitflow.md#checking-code-into-the-dev-working-branch)

**Note**: if you receive a 404 error trying to access this page, click [here](https://aka.ms/azuregithub) and sign in with your Microsoft corporate account to gain access.

### Adding Tests

Regarding the test project, one thing that's important is to name the test project folder and related project assembly to be ".tests".

  - This is for improving CI performance so to find exactly one copy of your test assembly.
  - Also, due to test dependencies, the test project should build .NET 4.5. For example, check out "src\ResourceManagement\Resource\Resource.tests"

### Issues with Generated Code

Much of the SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead, file an issue describing the problem, OR refer to the the [AutoRest project](https://github.com/azure/autorest) to view and modify the generator. 

### Other

If for platform reasons that your library won't use NetCore project system, 3 notes
  - In your library csproject file, set the msbuild property "AutoRestProjects" to "true"
  - In your test project files, set both "AutoRestProjects" and "SDKTestProject" to "true"
  - To simplify test discovery, the test folder must be named with ".tests"