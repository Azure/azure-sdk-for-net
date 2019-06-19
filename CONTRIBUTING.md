## Contributing

| Component | Build Status |
| --------- | ------------ |
| Management Libraries | [![Build Status](https://travis-ci.org/Azure/azure-sdk-for-net.svg?branch=master)](https://travis-ci.org/Azure/azure-sdk-for-net) |
| Client Libraries | [![Build Status](https://dev.azure.com/azure-sdk/public/_apis/build/status/41?branchName=master)](https://dev.azure.com/azure-sdk/public/_build/latest?definitionId=41&branchName=master) |

### Prerequisites:
  Install VS 2017 (Professional or higher) and make sure you have the latest updates (https://www.visualstudio.com/).

### To build:
=======

#### If you are building from VS, add a nuget feed source that points to < root >\tools\LocalNugetFeed directory
 1. Open any solution, eg "Compute\Microsoft.Azure.Management.Compute.sln"
 2. Build solution from VS
 
#### Full Build from command line

 1. Open VS 2017 developer command prompt
 2. Navigate to repository root directory
 3. Invoke **msbuild** build.proj /t:Build
 will Build
 ##### *Build* without any scope will build all management SDK's.

#### Build single SDK
`msbuild build.proj /t:CreateNugetPackage /p:scope=Compute`

### To run tests:
Using Visual Studio:
  - Build project in VS
  - "Test Explorer" window will get populated with tests. Right click on a test that you wish to Run/Debug.

Using the command line:
msbuild .\build.proj /t:Runtests /p:Scope=Compute
in the above example RunTests will build and run tests for Compute only
or you can use command line CLI
dotnet test Compute\Microsoft.Azure.Management.Compute\tests\Microsoft.Azure.Management.Tests.csproj

#### Create single nuget package
In order to build one package and run it's test
`msbuild build.proj /t:CreateNugetPackage /p:scope=Compute`
Nuget package will be created in root directory under \artifacts\packages\Debug (default configuration is Debug)

### Non-Windows command line build
Now you can use the same command on non-windows as above
for e.g. on Ubuntu you can do something like below:
`dotnet msbuild build.proj /t:Build /p:scope=Compute`
`dotnet msbuild build.proj /t:RunTests /p:scope=Compute`
`dotnet msbuild build.proj /t:CreateNugetPackage /p:scope=Compute`

### Update build tools
Build tools are now downloaded as part of a nuget package under root\restoredPackages\microsoft.internal.netsdkbuild.mgmt.tools
If for any reason there is an update to the build tools, you will then need to first delete directory root\restoredPackages\microsoft.internal.netsdkbuild.mgmt.tools and reexecute your build command. This will simply get the latest version of build tools.


## To on-board new libraries

### Project Structure

In "sdk\< Service Name >", you will find projects for services that have already been implemented

  - The easiest way is to model your test/sdk project using existing test/sdk project
    - Make a copy of existing csproj and change the meta data relevant to your SDK
    - This ensures the SDK that will be generated will be consistent (including consistent target frameworks)
  - Each service contains a project for their generated/customized code
    - The folder 'Generated' contains the generated code
    - The folder 'Customizations' contains additions to the generated code - this can include additions to the generated partial classes, or additional classes that augment the SDK or 

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
 `msbuild build.proj /t:CreateNugetPackage /p:scope=Compute`
 8.  A Pull request of your Azure SDK for .NET changes against **master** branch of the [Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net)
 9. Both the pull requests will be reviewed and merged by the Azure SDK team

### New Resource Provider
1. If you have never created an SDK for your service before, you will need the following things to get your SDK in the repo
2. Follow the standard process described above.
3. Directory names helps in using basic heuristics in finding projects as well it's associated test projects during CI process.
4. Create a new directory (name of your service e.g. Compute, Storage etc)
6. For e.g. for management plane SDKs the following directory structure
 - `<RPName>\<packageName>\src\Microsoft.Azure.Management.<RPName>\Microsoft.Azure.Management.<RPName>.csproj`
 - `<RPName>\<packageName>\tests\Microsoft.Azure.Management.<RPName>.Tests.csproj`
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

### Client Library Tested OSs and .NET Versions

|                        | Linux (Ubuntu 16.04) | MacOS 10.13 | Windows Server 2016 |
|------------------------|----------------------|-------------|---------------------|
| **.NET Core 2.1**  |  x                   |      x      |          x          |


### Issues with Generated Code

Much of the SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead, 
  - File an issue describing the problem,
  - Refer to the the [AutoRest project](https://github.com/azure/autorest) to view and modify the generator, or
  - Add additional methods, properties, and overloads to the SDK by adding classes in the 'Customizations' folder of a project


![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2FREADME.png)
