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

In "src\ResourceManagement", you will find projects for services that have already been implemented

  - Each service contains a project for their generated/customized code
    - The folder 'Generated' contains the generated code
    - The folder 'Customizations' contains additions to the generated code - this can include additions to the generated partial classes, or additional classes that augment the SDK or call the generated code
    - The file 'generate.cmd', used to generate library code for the given service, can also be found in this project
  - Services also contain a project for their tests

### Branches: AutoRest vs. master

The **AutoRest** branch contains the code generated from AutoRest.

The **master** branch contains the code generated from Hydra/Hyak.
  - Hydra/Hyak is Azure's legacy code generation technology.
  - This can still be used to generate client libraries, but the project is not being advanced in favor of AutoRest. Your team should move to AutoRest and Swagger as soon as possible.

### Standard Process

 1. Create fork of [Azure REST API Specs](https://github.com/azure/azure-rest-api-specs)
 2. Create fork of [Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net)
 3. Create your Swagger specification for your HTTP API. For more information see 
 [Introduction to Swagger - The World's Most Popular Framework for APIs](http://swagger.io)
 4. Install the latest version of AutoRest and use it to generate your C# client. For more info on getting started with AutoRest, 
 see the [AutoRest repository](https://github.com/Azure/autorest)
 5. Create a branch in your fork of Azure SDK for .NET and add your newly generated code to your project. If you don't have
 a project in the SDK yet, look at some of the existing projects and build one like the others. 
 6. **MANDATORY**: Add or update tests for the newly generated code.
 7. Once added to the Azure SDK for .NET, Build your local package using command "msbuild build.proj /t:build;package /p:scope=YourService" 
 (Note, 'YourService' comes from the sub folder under <sdk-repo-root>\src, for example: "ResourceManagement\Compute")
 8. If you're using **master** branch, bump up the package version in YourService.nuget.proj. If you're using **AutoRest** branch, change the package version in the project.json file, as well as in the AssemblyInfo.cs file.
 9. Use this local Package for your Powershell development
 10. Create 2 Pull Requests and send an email to [azsdkcode@microsoft.com](mailto:azsdkcode@microsoft.com)
    - A Pull Request of your spec changes against **master** branch of the [Azure REST API Specs](https://github.com/azure/azure-rest-api-specs)
    - A Pull request of your Azure SDK for .NET changes against **master** branch of the [Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net)
 11. Both the pull requests will be reviewed and merged by the Azure SDK team

### Code Review Process

Before a pull request will be considered by the Azure SDK team, the following requirements must be met:

- Prior to issuing the pull request:
  - All code must have completed any necessary legal signoff for being publically viewable (Patent review, JSR review, etc.)
  - The changes cannot break any existing functional /unit tests that are part of the central repository.
    - This includes all tests, even those not associated with the given feature area.
  - Code submitted must have basic unit test coverage, and have all the unit tests pass. Testing is the full responsibility of the service team
    - Functional tests are encouraged, and provide teams with a way to mitigate regressions caused by other code contributions.
  - Code should be commented.
  - Code should be fully code reviewed.
  - Code should be able to merge without any conflicts into the dev branch being targeted.
  - Code should pass all relevant static checks and coding guidelines set forth by the specific repository.
  - All build warnings and code analysis warnings should be fixed prior to submission.
- As part of the pull request (aka, in the text box on GitHub as part of submitting the pull request):
  - Proof of completion of the code review and test passes requirements above.
  - Identity of QA responsible for feature testing (can be conducted post-merging of the pull request).
  - Short description of the payload of pull request.
- After the pull request is submitted:
  - Send an email to the Azure SDK Code Review (azsdkcode@microsoft.com) alias.
    - Include all interested parties from your team as well.
    - In the message, make sure to acknowledge that the legal signoff process is complete.

Once all of the above steps are met, the following process will be followed:

- A member of the Azure SDK team will review the pull request on GitHub.
- If the pull request meets the respository's requirements, the individual will aproove the pull request, merging the code into the dev branch of the source repository.
  - The owner will then respond to the email sent as part of the pull request, informing the group of the completion of the request.
- If the request does not meet any of the requirements, the pull request will not be merged, and the necessary fixes for acceptance will be communicated back to the partner team.

### Adding Tests

Regarding the test project, one thing that's important is to name the test project by adding a ".Tests" suffix to the folder name for the folder containing your project. For example, the test project for "Compute\Microsoft.Azure.Management.Compute" should be named 'Compute.Tests'

  - This is for improving CI performance so to find exactly one copy of your test assembly.
  - Also, due to test dependencies, the test project should build both .NET 4.5 and NETStandard 1.5. For example, check out "src\ResourceManagement\Resource\Resource.tests"

### Issues with Generated Code

Much of the SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead, 
  - File an issue describing the problem,
  - Refer to the the [AutoRest project](https://github.com/azure/autorest) to view and modify the generator, or
  - Add additional methods, properties, and overloads to the SDK by adding classes in the 'Customizations' folder of a project
