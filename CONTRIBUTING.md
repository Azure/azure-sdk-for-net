# Contributing

| Component            | Build Status                                                                                                                                                                                                          |
| -------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Management Libraries | [![Build Status](https://dev.azure.com/azure-sdk/public/_apis/build/status/net/net%20-%20mgmt%20-%20ci?branchName=master)](https://dev.azure.com/azure-sdk/public/_build/latest?definitionId=529&branchName=master)   |

# Prerequisites:

- Install VS 2019 (Community or higher) and make sure you have the latest updates (https://www.visualstudio.com/).
  - Need at least .NET Framework 4.6.1 and 4.7 development tools
- Install the **.NET Core cross-platform development** workloads in VisualStudio
- Install **.NET Core 3.0.100 SDK ** or higher for your specific platform. (https://dotnet.microsoft.com/download/dotnet-core/3.0)
- Install the latest version of git (https://git-scm.com/downloads)

## GENERAL THINGS TO KNOW:

**Client Libraries** are sdks used to interact with azure resources at application run time while **Management Libraries** are those used to manage (create/modify/delete) Azure resources.

**Build Repo :** To build all Client and Management libraries together. Invoke `dotnet build build.proj` from the root of the repo.<br/>To scope to a single service supply a scope property e.g. `dotnet build build.proj /p:Scope=servicebus`. This will build both client and management projects in the specified service. If using msbuild you must run restore first. See below for how to build the [client](#client-libraries) or [management](#management-libraries) libraries independently.

**Path Length :** To account for the **260 characters Path Length Limit** encountered on windows OS, file paths within the repo is keep below 210 characters. This gives you a runway of 49 characters as clone path for your repo. Paths longer that 260 characters will cause the build to break on windows OS and on CI. Assuming you clone to the default VisualStudio location such that the root of your clone is `C:\Users\\**USERNAME**\Source\Repos\azure-sdk-for-net` your username will have to be 9 characters long to avoid build errors caused by long paths. Consider using `C:\git` as you clone path.

**Dependencies :** To ensure that the same versions of dependencies are used for all projects in the repo, package versions are managed from a central location in `eng\Packages.Data.props`. When adding package references you should first ensure that an **Update** reference of the package with the version exist in the **Packages.Data.props** then **Include** the reference without the version in your .csproj. Contact [azuresdkengsysteam@microsoft.com](mailto:azuresdkengsysteam@microsoft.com) if you need to change  versions for packages already present in **Packages.Data.props**

**Line Endings :** If working on windows OS ensure git is installed with `Checkout Windows-style, commit Unix-style` option or `core.autocrlf` set to *true* in git config. If working on Unix based Linux or MacOS ensure git is installed with `Checkout as-is, commit Unix-style` option or `core.autocrlf` set to *input* in git config
# Management Libraries

## TO BUILD:

1.  Open any solution, eg "SDKs\Compute\Microsoft.Azure.Management.Compute.sln"
2.  Build solution from Visual Studio

### Single Service from Command Line

1. Open VS 2019 command Prompt
2. From the root directory
3. Invoke `msbuild eng\mgmt.proj /p:scope=Compute`

> _Build_ without any scope will build all management SDK's.

### Create single nuget package

In order to build one package and run it's test
`msbuild eng\mgmt.proj /t:CreateNugetPackage /p:scope=Compute`
Nuget package will be created in root directory under \artifacts\packages\Debug (default configuration is Debug)

## TO TEST:

### Using Visual Studio:

1. Build project in Visual Studio.
2. **Test Explorer** window will get populated with tests. Select test and `Run` or `Debug`

### Using the command line:

Run e.g. `msbuild eng\mgmt.proj /t:"Runtests" /p:Scope=Compute`
In the above example _RunTests_ will build and run tests for Compute only or you can use command line CLI
`dotnet test Compute\Microsoft.Azure.Management.Compute\tests\Microsoft.Azure.Management.Tests.csproj`

### Non-Windows command line build

Now you can use the same command on non-windows as above for e.g. on Ubuntu you can do something like below:

- `dotnet msbuild eng\mgmt.proj /t:Build /p:scope=Compute`
- `dotnet msbuild eng\mgmt.proj /t:RunTests /p:scope=Compute`
- `dotnet msbuild eng\mgmt.proj /t:CreateNugetPackage /p:scope=Compute`
- `dotnet msbuild build.proj /t:Util /p:UtilityName=InstallPsModules`

### Update build tools

Build tools are now downloaded as part of a nuget package under `root\restoredPackages\microsoft.internal.netsdkbuild.mgmt.tools`
If for any reason there is an update to the build tools, you will then need to first delete directory `root\restoredPackages\microsoft.internal.netsdkbuild.mgmt.tools` and re-execute your build command. This will simply get the latest version of build tools.

# Client Libraries

## TO BUILD:

### Single Service from Command Line

1. Open VS 2019 Command Prompt
2. Navigate to service directory e.g. _"sdk\eventhub"_
3. Invoke `dotnet build`
4. or Build the **service.proj** in the repo root, passing the directory name of the specific service as a property. e.g. `dotnet build eng\service.proj /p:ServiceDirectory=eventhub`

### Single Service from Visual Studio

1. Open any data-plane solution e.g. _"sdk\eventhub\Microsoft.Azure.EventHubs.sln"_
2. Build solution from Visual Studio

### All Client Services from Command Line

1. Open VS 2019 Command Prompt
2. Navigate to repository root directory
3. Invoke `dotnet build eng\service.proj`

## TO TEST:

### Single Service from Command Line

1. Open VS 2019 Command Prompt
2. Navigate to service directory e.g. _"sdk\eventhub"_
3. Invoke `dotnet test --filter TestCategory!=Live` _(Skips live tests)_
4. or run test against **service.proj** in the repo root, passing the directory name of the specific service as a property. e.g. `dotnet test eng\service.proj /p:ServiceDirectory=eventhub --filter TestCategory!=Live`

### Single Service from Visual Studio

1. Build.
2. Test Explorer window will get populated with tests. Select test and `Run` or `Debug`

### All Client Services from Command Line

1. Open VS 2019 Command Propmpt
2. Navigate to repository root directory
3. Invoke `dotnet test eng\service.proj --filter TestCategory!=Live`
   <br/><br/>

### Testing Against Latest Versions of Client Libraries
In some cases, you might want to test against the latest versions of the client libraries. i.e. version not yet published to nuget. For this scenario you should make use of the `UseProjectReferenceToAzureClients` property which when set to `true` will switch all package references for client libraries present in the build to project references. This result in testing against the current version of the libraries in the repo. e.g. `dotnet test eng\service.proj /p:ServiceDirectory=eventhub --filter TestCategory!=Live /p:UseProjectReferenceToAzureClients=true`

## Public API changes

If you make a public API change `eng\Export-API.ps1` script has to be run to update public API listings.

# On-boarding New Libraries

### Project Structure

In `sdk\< Service Name >`, you will find projects for services that have already been implemented

1. Client library projects needs to use the $(RequiredTargetFrameworks) *(defined in eng/Directory.Build.Data.props)* property in its TargetFramework while management library projects should use $(SdkTargetFx) _(defined in AzSdk.reference.props)_
2. Projects of related packages are grouped together in a folder following the structure specified in [Repo Structure](https://github.com/Azure/azure-sdk/blob/master/docs/engineering-system/repo-structure.md)
   - Client library packages are in a folder name like **_Microsoft.Azure.< ServiceName >_**
   - Management library packages are in a folder named like **_Microsoft.Azure.Management.< Resource Provider Name >_**
3. Each shipping package contains a project for their **generated** and /or **Customization** code
   - The folder **'Generated'** contains the generated code
   - The folder **'Customizations'** contains additions to the generated code - this can include additions to the generated partial classes, or additional classes that augment the SDK or call the generated code
   - The file **generate.cmd**, used to generate library code for the given package, can also be found in this project

### Standard Process

1.  Create fork of [Azure REST API Specs](https://github.com/azure/azure-rest-api-specs)
2.  Create fork of [Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net)
3.  Create your Swagger specification for your HTTP API. For more information see
    [Introduction to Swagger - The World's Most Popular Framework for APIs](http://swagger.io)
4.  Install the latest version of AutoRest and use it to generate your C# client. For more info on getting started with AutoRest,
    see the [AutoRest repository](https://github.com/Azure/autorest)
5.  Create a branch in your fork of Azure SDK for .NET and add your newly generated code to your project. If you don't have a project in the SDK yet, look at some of the existing projects and build one like the others.
6.  **MANDATORY**: Add or update tests for the newly generated code.
7.  Once added to the Azure SDK for .NET, build your local package using [client](#client-libraries) or [management](#management-libraries) library instructions shown in the above sections.
8.  A Pull request of your Azure SDK for .NET changes against **master** branch of the [Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net)
9.  The pull requests will be reviewed and merged by the Azure SDK team

### New Resource Provider

1. If you have never created an SDK for your service before, you will need the following things to get your SDK in the repo
2. Follow the standard process described above.
3. Project names helps in using basic heuristics in finding projects as well it's associated test projects during CI process.
4. Create a new directory using the name of your service as specified in [azure-rest-api-specs/specification](https://github.com/Azure/azure-rest-api-specs/tree/master/specification) Repo
5. Follow the the directory structure below

```
sdk\<service name>\<package name>\README.md
sdk\<service name>\<package name>\*src*
sdk\<service name>\<package name>\*tests*
sdk\<service name>\<package name>\*samples*
```

e.g.

```
sdk\eventgrid\Microsoft.Azure.EventGrid\src\Microsoft.Azure.EventGrid.csproj
sdk\eventgrid\Microsoft.Azure.EventGrid\tests\Microsoft.Azure.EventGrid.Tests.csproj
sdk\eventgrid\Microsoft.Azure.Management.EventGrid\src\Microsoft.Azure.Management.EventGrid.csproj
sdk\eventgrid\Microsoft.Azure.Management.EventGrid\tests\Microsoft.Azure.Management.EventGrid.Tests.csproj
```

> \*Ensure that your service name is the same as it is specified in the [azure-rest-api-specs/specification](https://github.com/Azure/azure-rest-api-specs/tree/master/specification) Repo, that your csproj files starts with **Microsoft.Azure\***
> , that test files end with **.Tests** and that management plane project files contain **.Management.**

7. Copy .csproj from any other .csproj and update the following information in the new .csproj

   | Project Properties  |
   | ------------------- |
   | AssemblyTitle       |
   | Description         |
   | VersionPrefix       |
   | PackageTags         |
   | PackageReleaseNotes |
   |                     |

> PackageReleaseNotes are important because this information is displayed on www.nuget.org when your nuget package is published

8. Copy existing generate.ps1 file from another service and update the `ResourceProvider` name that is applicable to your SDK. Resource provider refers to the relative path of your REST spec directory in Azure-Rest-Api-Specs repository
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
  - MS internal folks, please reach out to us via our Teams channel or
  - Send an email to the Azure Developer Platform team [adpteam@microsoft.com](mailto:adpteam@microsoft.com) alias.
    - Include all interested parties from your team as well.
    - In the message, make sure to acknowledge that the legal signoff process is complete.

Once all of the above steps are met, the following process will be followed:

- A member of the Azure SDK team will review the pull request on GitHub.
- If the pull request meets the repository's requirements, the individual will approve the pull request, merging the code into the dev branch of the source repository.
  - The owner will then respond to the email sent as part of the pull request, informing the group of the completion of the request.
- If the request does not meet any of the requirements, the pull request will not be merged, and the necessary fixes for acceptance will be communicated back to the partner team.

### Client Library Tested OSs and .NET Versions

|                   | Linux (Ubuntu 16.04) | MacOS 10.13 | Windows Server 2016 |
| ----------------- | -------------------- | ----------- | ------------------- |
| **.NET Core 2.1** | x                    | x           | x                   |

### Issues with Generated Code

Much of the management plane SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead,

- File an issue describing the problem,
- Refer to the the [AutoRest project](https://github.com/azure/autorest) to view and modify the generator, or
- Add additional methods, properties, and overloads to the SDK by adding classes in the 'Customizations' folder of a project

## Versioning

For more information on how we version see [Versioning](doc/dev/Versioning.md)

## Breaking Changes

For information about breaking changes see [Breaking Change Rules](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/breaking-change-rules.md)