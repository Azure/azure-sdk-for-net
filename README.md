

# Microsoft Azure SDK for .NET
 ----------
The Microsoft Azure SDK for .NET allows you to build applications
that take advantage of scalable cloud computing resources.

### Download Packages

For a full list of packages available for download in this repository, please see our [list of .NET SDK packages](https://github.com/Azure/azure-sdk-for-net/tree/psSdkJson6/Documentation/sdk-for-net-packages.md).

### Target Frameworks:

* .NET Framework 4.5.2
* Netstandard 1.4, based on the NetCore framework

### Prerequisites:
  Install VS 2017 (Professional or higher) + VS2017 Update 1
  (https://www.visualstudio.com/).
  To know more about VS 2017 and its project system (https://docs.microsoft.com/en-us/visualstudio/#pivot=workloads&panel=windows)

### Directory Restructure
Directory structure has been simplified and consolidated in fewer directories
All Management and Data plane SDKs are now under
src\SDKs
e.g.
src\SDKs\AnalysisService
src\SDKs\Compute

### To build:
=======
#### If you have recently cloned the repo or did a pull from upstream or did git clean -xdf you need to the following before you do anything else in order to build your projects

 1. Open **elevated** VS 2017 command prompt
 2. Navigate to repository root directory
 3. Skip verification for the following dlls
    - Sn -Vr tools\bootstrapTools\taskBinaries\Microsoft.Azure.Build.BootstrapTasks.dll
    - Sn -Vr tools\SdkBuildTools\tasks\net46\Microsoft.Azure.Sdk.Build.Tasks.dll
 4. Execute MsBuild.exe build.proj (this will pull all the build related tools needed to build the repo)
 5. Follow below steps to start building your repo/project

#### If you are building from VS, add a nuget feed source that points to < root >\tools\LocalNugetFeed directory
 1. Open any solution, eg "SDKs\Compute\Compute.sln"
 2. Build solution from VS
 
#### Full Build from command line

 1. Open VS 2017 command prompt
 2. Navigate to repository root directory
 3. Invoke **msbuild** build.proj /t:Build
 will Build
 ##### *Build* without any scope will build all SDK's and create nuget packages.

#### Create single nuget package
In order to build one package and run it's test
`msbuild build.proj /t:CreateNugetPackage /p:scope=SDKs\Compute`
Nuget package will be created in root directory under \binaries\packages
 
### To run the tests:
Using Visual Studio:
  - Build.
  - "Test Explorer" window will get populated with tests. Select test and Run/Debug.

Using the command line:
msbuild .\build.proj /t:"Runtests" /p:Scope=SDKs\Compute
in the above example RunTests will build and run tests for Compute only
or
dotnet test SDKs\Compute\Compute.Tests\Compute.Tests.csproj

  - Refer to the "To build" section to get the command window set up.
  - Invoke "RunTests" target from "Build.proj". RunTests will build and run tests 
        *msbuild build.proj /t:RunTests /p:scope=SDKs\Compute*

## To on-board new libraries

### Project Structure

In "SDKs\< RPName >", you will find projects for services that have already been implemented

  - Each SDK project needs to target .NET 4.5.2 and .NET Standard 1.4
	  - Test project needs to target NetCoreApp 1.1
  - Each service contains a project for their generated/customized code
    - The folder 'Generated' contains the generated code
    - The folder 'Customizations' contains additions to the generated code - this can include additions to the generated partial classes, or additional classes that augment the SDK or call the generated code
    - The file 'generate.cmd', used to generate library code for the given service, can also be found in this project
  - Services also contain a project for their tests

### Branches: psSdkJson6 vs. master

The **psSdkJson6** branch contains the code generated from AutoRest tool.

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
 5. Create a branch in your fork of Azure SDK for .NET and add your newly generated code to your project. If you don't have a project in the SDK yet, look at some of the existing projects and build one like the others. 
 6. **MANDATORY**: Add or update tests for the newly generated code.
 7. Once added to the Azure SDK for .NET, build your local package using command
 e.g.
 `msbuild build.proj /t:CreateNugetPackage /p:scope=SDKs\Compute`
 8. If you're using **master** branch, bump up the package version in YourService.nuget.proj. If you're using **psSdkJson6** branch, change the package version in the .csproj file, as well as in the AssemblyInfo.cs file.
 9.  A Pull request of your Azure SDK for .NET changes against **psSdkJson6** branch of the [Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net)
 11. Both the pull requests will be reviewed and merged by the Azure SDK team

### New Resource Provider
1. If you have never created an SDK for your service before, you will need the following things to get your SDK in the repo
2. Follow the standard process described above.
3. Directory names helps in using basic heuristics in finding projects as well it's associated test projects during CI process.
4. Create a new directory (name of your service e.g. Compute, Storage etc)
5. If you have a data plane as well as management plane follow the following directory structure.
 - `SDKs\<RPName>\management\Management.<RPName>\Microsoft.Azure.Management.<RPName>.csproj`
 - `SDKs\<RPName\management\<RPName>.Tests\Management.<RPName>.Tests.csproj`
 - `SDKs\<RPName>\dataplane\Microsoft.Azure.<RPName>\Microsoft.Azure.<RPName>.csproj`
 - `SDKs\<RPName\dataplane\Microsoft.Azure.<RPName>.Tests\Microsoft.Azure.<RPName>.Tests.csproj`
6. If you only have management plane SDK then have the following directory structure
 - `SDKs\<RPName>\Management.<RPName>\Microsoft.Azure.Management.<RPName>.csproj`
 - `SDKs\<RPName\<RPName>.Tests\Management.<RPName>.Tests.csproj`
7. Copy .csproj from any other .csproj and update the following information in the new .csproj
 - PackageId
 - Description
 - AssemblyTitle
 - AssemblyName
 - Version
 - PackageTags
 - PackageReleaseNotes (this is important because this information is displayed on www.nuget.org when your nuget package is published
8. Copy existing generate.ps1 file from another dirctory and update the `ResourceProvider` name that is applicable to your SDK. Resource provider refers to the relative path of your REST spec directory in Azure-Rest-Api-Specs repository
During SDK generation, this path helps to locate the REST API spec from the `https://github.com/Azure/azure-rest-api-specs`

### Code Review Process

Before a pull request will be considered by the Azure SDK team, the following requirements must be met:

- Prior to issuing the pull request:
  - All code must have completed any necessary legal signoff for being publicly viewable (Patent review, JSR review, etc.)
  - The changes cannot break any existing functional/unit tests that are part of the central repository.
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
  - Our SLA is 48 hours. When your PR is submitted someone on our team will be auto assigned the PR for review. No need to email us
  - MS internal folks, please reach out to us via our slack channel or
  - Send an email to the Azure DevEx .Net team (azdevxdotnet@microsoft.com) alias.
    - Include all interested parties from your team as well.
    - In the message, make sure to acknowledge that the legal signoff process is complete.

Once all of the above steps are met, the following process will be followed:

- A member of the Azure SDK team will review the pull request on GitHub.
- If the pull request meets the repository's requirements, the individual will approve the pull request, merging the code into the dev branch of the source repository.
  - The owner will then respond to the email sent as part of the pull request, informing the group of the completion of the request.
- If the request does not meet any of the requirements, the pull request will not be merged, and the necessary fixes for acceptance will be communicated back to the partner team.

### Adding Tests

Regarding the test project, one thing that's important is to name the test project by adding a ".Tests" suffix to the folder name for the folder containing your project. For example, the test project for "Compute\Management.Compute" should be named 'Compute.Tests'

  - This is for improving CI performance so to find exactly one copy of your test assembly.
  - Also, due to test dependencies, the test project should build both .NET 4.5.2 and NETStandard 1.4. For example, check out "src\SDKs\Resource\Resource.tests"

### Issues with Generated Code

Much of the SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead, 
  - File an issue describing the problem,
  - Refer to the the [AutoRest project](https://github.com/azure/autorest) to view and modify the generator, or
  - Add additional methods, properties, and overloads to the SDK by adding classes in the 'Customizations' folder of a project
