# Contributing

## Prerequisites:

- Install Visual Studio 2022 (Community or higher) and make sure you have the latest updates (https://www.visualstudio.com/).
  - Install the **.NET desktop development** workload in VisualStudio
  - Need at least .NET Framework 4.6.2 and 4.7.1 development tools 
- Install **.NET 9.0.306 SDK** for your specific [platform](https://dotnet.microsoft.com/download). (or a higher version within the 9.0.*** band)  
- Install the latest version of git (https://git-scm.com/downloads)
- Install [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell), version 7 or higher, if you plan to make public API changes or are working with generated code snippets.
- Install [NodeJS](https://nodejs.org/) (22.x.x) if you plan to use [C# code generation](https://github.com/Azure/autorest.csharp).
- [Fork the repository](https://docs.github.com/get-started/quickstart/fork-a-repo); work will be done on a [topic branch](https://docs.github.com/get-started/quickstart/github-flow#create-a-branch) in your fork and a [pull request opened](https://docs.github.com/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request-from-a-fork) against the `main` branch of the Azure SDK for .NET repository when ready for review.

## GENERAL THINGS TO KNOW:

**Client Libraries** are sdks used to interact with azure resources at application run time while **Management Libraries** are those used to manage (create/modify/delete) Azure resources.

**Build Repo :** To build all Client and Management libraries together. Invoke `dotnet build build.proj` from the root of the repo.<br/>To scope to a single service supply a scope property e.g. `dotnet build build.proj /p:Scope=servicebus`. This will build both client and management projects in the specified service. If using msbuild you must run restore first. See below for how to build the [client](#client-libraries) or [management](#management-libraries) libraries independently.

**Path Length :** To account for the **260 characters Path Length Limit** encountered on windows OS, file paths within the repo is keep below 210 characters. This gives you a runway of 49 characters as clone path for your repo. Paths longer that 260 characters will cause the build to break on windows OS and on CI. Assuming you clone to the default VisualStudio location such that the root of your clone is `C:\Users\\**USERNAME**\Source\Repos\azure-sdk-for-net` your username will have to be 9 characters long to avoid build errors caused by long paths. Consider using `C:\git` as you clone path.

**Dependencies :** To ensure that the same versions of dependencies are used for all projects in the repo, package versions are managed from a central location in `eng\Packages.Data.props`. When adding package references you should first ensure that an **Update** reference of the package with the version exist in the **Packages.Data.props** then **Include** the reference without the version in your .csproj. Contact [azuresdkengsysteam@microsoft.com](mailto:azuresdkengsysteam@microsoft.com) if you need to change  versions for packages already present in **Packages.Data.props**

**Line Endings :** If working on windows OS ensure git is installed with `Checkout Windows-style, commit Unix-style` option or `core.autocrlf` set to *true* in git config. If working on Unix based Linux or MacOS ensure git is installed with `Checkout as-is, commit Unix-style` option or `core.autocrlf` set to *input* in git config

**GitHub Actions :** Forks of the repository will inherit the automations performed in the Azure SDK for .NET repository as GitHub Actions.  It is reccommended that you explicitly [disable](https://docs.github.com/repositories/managing-your-repositorys-settings-and-features/enabling-features-for-your-repository/managing-github-actions-settings-for-a-repository#managing-github-actions-permissions-for-your-repository) these Actions to prevent errors and unwanted automation.

----

# Management Libraries

## TO BUILD:

1.  Open any solution, eg "SDKs\Compute\Azure.ResourceManager.Compute.sln"
2.  Build solution from Visual Studio

### Single Service from Command Line

1. Open Developer Command Prompt
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
In the above example _RunTests_ will build and run tests for Compute only or you can use command line CLI:

```dotnetcli
dotnet test Compute\Azure.ResourceManager.Compute\tests\Azure.ResourceManager.Compute.Tests.csproj
```

### Non-Windows command line build

Now you can use the same command on non-windows as above for e.g. on Ubuntu you can do something like below:

- `dotnet msbuild eng\mgmt.proj /t:Build /p:scope=Compute`
- `dotnet msbuild eng\mgmt.proj /t:RunTests /p:scope=Compute`
- `dotnet msbuild eng\mgmt.proj /t:CreateNugetPackage /p:scope=Compute`
- `dotnet msbuild build.proj /t:Util /p:UtilityName=InstallPsModules`

### Update build tools

Build tools are now downloaded as part of a nuget package under `root\restoredPackages\microsoft.internal.netsdkbuild.mgmt.tools`
If for any reason there is an update to the build tools, you will then need to first delete directory `root\restoredPackages\microsoft.internal.netsdkbuild.mgmt.tools` and re-execute your build command. This will simply get the latest version of build tools.

## TO CREATE NEW LIBRARY USING TEMPLATE

We have created a dotnet template to make creating new management SDK library easier than ever.

See [README file](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/templates/README.md).

----

# Client Libraries

## TO BUILD:

### Single Service from Command Line

1. Open Developer Command Prompt
2. Navigate to service directory e.g. _"sdk\eventhub"_
3. Invoke `dotnet build`
4. or Build the **service.proj** in the repo root, passing the directory name of the specific service as a property. e.g. `dotnet build eng\service.proj /p:ServiceDirectory=eventhub`

### Single Service from Visual Studio

1. Open any data-plane solution e.g. _"sdk\eventhub\Microsoft.Azure.EventHubs.sln"_
2. Build solution from Visual Studio

### All Client Services from Command Line

1. Open Developer Command Prompt
2. Navigate to repository root directory
3. Invoke `dotnet build eng\service.proj`

### Support for Visual Studio Code & Dev Containers

This repository has been configured with support for Visual Studio Code's dev container extension to make it easier to get started working on code without needing to know about how to setup all the pre-requisites. Configuration for dev containers is contained within the ```.devcontainer``` folder off the root directory.

To get started:

1. Install and configure Docker for your platform.
2. Install the [Remote Development extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack) into Visual Studio Code.
3. Clone the repository to your local workstation.
4. Open Visual Studio Code at the root of the reposiory.
5. Select "Reopen in Container" when prompted.

After a few moments of initial configuration Visual Studio Code will launch the container with all dependencies (.NET SDK etc) pre-installed.

## TO TEST:

### Single Service from Command Line

1. Open Developer Command Prompt
2. Navigate to service directory e.g. _"sdk\eventhub"_
3. Invoke `dotnet test --filter TestCategory!=Live` _(Skips live tests)_
4. or run test against **service.proj** in the repo root, passing the directory name of the specific service as a property. e.g. `dotnet test eng\service.proj /p:ServiceDirectory=eventhub --filter TestCategory!=Live`

### Single Service from Visual Studio

1. Build.
2. Test Explorer window will get populated with tests. Select test and `Run` or `Debug`

### All Client Services from Command Line

1. Open VS 2019 Command Prompt
2. Navigate to repository root directory
3. Invoke `dotnet test eng\service.proj --filter TestCategory!=Live`
   <br/><br/>

### Live testing

Before running or recording live tests you need to create
[live test resources](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md).  Many of the client libraries make use of the Azure Core Test Framework to provide the basis for the live test infrastructure, including the ability to record Live tests so that they can be run without access to Azure resources.  The [Test Framework documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework/README.md) provides more context around test recordings and other features.

To run live tests after creating live resources:

1. Open Developer Command Prompt
2. Navigate to service directory e.g. _"sdk\keyvault"_
3. Invoke `dotnet test`

Some live tests may have additional steps for setting up live testing resources.
See the CONTRIBUTING.md file for the service you wish to test for additional
information or instructions.

### Testing Against Latest Versions of Client Libraries
In some cases, you might want to test against the latest versions of the client libraries. i.e. version not yet published to nuget. For this scenario you should make use of the `UseProjectReferenceToAzureClients` property which when set to `true` will switch all package references for client libraries present in the build to project references. This result in testing against the current version of the libraries in the repo. e.g. `dotnet test eng\service.proj /p:ServiceDirectory=eventhub --filter TestCategory!=Live /p:UseProjectReferenceToAzureClients=true`

### Code Coverage

If you want to enable code coverage reporting, on the command line pass `/p:CollectCoverage=true` like so:

```dotnetcli
dotnet tool restore
dotnet test /p:CollectCoverage=true
```

On developers' machines, you can open `index.html` from within the `TestResults` directory in each of your test projects.
Coverage reports can also be found in Azure Pipelines on the "Code Coverage" tab after a pull request validation build completes.

By default, all _Azure.*_ libraries are covered, and any project that sets the `IsClientLibrary=true` MSBuild property.
To exclude a project, set `ExcludeFromCodeCoverage=true` in the project's MSBuild properties before other targets are imported.

> The Azure SDK team does not mandate a threshold for code coverage nor do we aggregate those metrics in any reports. This metric can be misleading e.g., a client library with a lot of models and few operations could have complete serialization coverage of models but no coverage for operations and still have a high metric.
> We encourage teams to drill into the reports generated locally or in Azure Pipelines on the "Code Coverage" tab to analyze their code coverage as necessary e.g., any code teams have written or client library methods that call an endpoint.

## Public API additions

If you make public API changes or additions, the `eng\scripts\Export-API.ps1` script has to be run to update public API listings. This generates a file in the library's directory similar to the example found in `sdk\template\Azure.Template\api\Azure.Template.netstandard2.0.cs`.

Running the script for a project in `sdk\tables` would look like this:
```
eng\scripts\Export-API.ps1 tables
```

## Updating Sample Snippets
If the specific client library has sample snippets in markdown format, they were most likely created with help of the `eng\scripts\Update-Snippets.ps1` script.
Any changes made to the snippet markdown should be done via updating the corresponding C# snippet code and subsequently running the script.

Running the script for a project, for example in `sdk\keyvault`, would look like this:
```
eng\scripts\Update-Snippets.ps1 keyvault
```

When run, the code regions in the format below (where `<snippetName>` is the name of the snippet):
```c#
#region Snippet:<snippetName>
//some sample code
string snippet = "some snippet code";

// The snippet updater defines the SNIPPET directive while parsing. You can use #if SNIPPET to filter lines in or out of the snippet.
#if SNIPPET
snippet = "value that would never pass a test but looks good in a sample!";
#else
string ignored = "this code will not appear in the snippet markdown";
#endif

#endregion
```
 will be mapped to any markdown file with a corresponding code region in the format below where the snippet names match:

**\`\`\`C# Snippet:\<snippetName>**

**\`\`\`**

See the following example of a [snippet C# file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/tests/Samples/Sample01_HelloWorld.cs) and a [snippet markdown file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample01a_HelloWorld.md).
Note that snippet names need to be globally unique under a given service directory.

Snippets also can be integrated into XML doc comments. For example:
```c#
/// <summary>
/// Some Property.
/// </summary>
/// <example>
/// This is an example of using a snippet in XML docs.
/// <code snippet="Snippet:<snippetName>">
/// // some sample code.
/// string snippet = "some snippet code";
/// </code>
public string SomeProperty { get; set; }
```

For general information about samples, see the [Samples Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples)

## Updating Source on Build
You can run `eng\scripts\Export-API.ps1` and `eng\scripts\Update-Snippets.ps1` simultaneously as part of the build by setting as true either:
1. The property `UpdateSourceOnBuild`
2. The Environment variable `AZURE_DEV_UPDATESOURCESONBUILD=true`

e.g.
```
dotnet build eng\service.proj /p:ServiceDirectory=eventhub /p:UpdateSourceOnBuild=true
```

## API Compatibility Verification

.NET is using the [ApiCompat tool](https://github.com/dotnet/arcade/pull/14328) to enforce API compatibility between versions. Builds of GA'ed libraries will fail locally and in CI if there are breaking changes.

### How it works
Each library needs to provide a `ApiCompatVersion` property which is set to the last GA'ed version of the library that will be used to compare APIs with the current to ensure no breaks have been introduced. Projects with this property set will download the specified package and the ApiCompat (Microsoft.DotNet.ApiCompat) tools package as part of the restore step of the project. Then as a post build step of the project it will run ApiCompat to verify the current APIs are compatible with the last GA'ed version of the APIs. For libraries that wish to disable the APICompat check they can remove the `ApiCompatVersion` property from their project. Our version bump automation will automatically add or increment the `ApiCompatVersion` property to the project when it detects that the version it is changing was a GA version which usually indicates that we just shipped that GA version and so it should be the new baseline for API checks.

### Releasing a new version of a GA'ed libary
Since the [eng/Packages.Data.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/Packages.Data.props) is currently maintained manually, you will need to update the version number for your library in this file when releasing a new version.

## NuGet Package Dev Feed

The Azure SDK for .NET releases packages daily from our CI pipeline to our NuGet package dev feed to help developers use and test new libraries before they are officially released to NuGet.

**Dev Feed Package Browser**:

- https://dev.azure.com/azure-sdk/public/_packaging?_a=feed&feed=azure-sdk-for-net

**Dev Feed Package Source**:

- https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json

### 1. Add NuGet Package Dev Feed

You have multiple options for referencing the dev feed. You can either add it via the NuGet CLI or manually edit your NuGet.Config file.

#### NuGet CLI

You can add the dev feed using the [NuGet CLI](https://docs.microsoft.com/nuget/reference/nuget-exe-cli-reference), which will add it to the NuGet.Config file.

```bash
nuget sources add -Name "Azure SDK for .NET Dev Feed" -Source "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json"
```

You can then view the list of NuGet package sources with this command:

```bash
nuget sources
```

#### NuGet Config file

You can add the dev feed to your NuGet.Config file, which can be at the Solution, User, or Computer level. See [NuGet.Config file locations and uses](https://docs.microsoft.com/nuget/consume-packages/configuring-nuget-behavior#config-file-locations-and-uses) to locate your NuGet.Config file.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="Azure SDK for .NET Dev Feed" value="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json" />
  </packageSources>
  <disabledPackageSources>
    <clear />
  </disabledPackageSources>
</configuration>
```

> You can place a NuGet.Config file in the root of your solution. Projects within the solution will use the feed defined in that file.

##### Unauthorized access to the feed

If you are getting a 401 error, similar to `401 (Unauthorized - No local versions of package `xyz`; please provide authentication to access versions from upstream that have not yet been saved to your feed.)` it means you are trying 
to access a package version that is not on the feed but is on the upstream feed `nuget.org` and you don't have permissions to pull that version into the feed. There are two possible solutions to this issue:

1. If you are a member of the team with access and want to update a version of the package in the feed you will need to authenticate to the feed. For local authentication you will want to use [Azure Artifacts Credential Provider](https://github.com/microsoft/artifacts-credprovider#azure-artifacts-credential-provider).
   If you need to authenticate a pipeline in our teams DevOps org you will want login via the [NuGetAuthenticate](https://learn.microsoft.com/azure/devops/pipelines/tasks/package/nuget-authenticate?view=azure-devops#dotnet) task.
1. If you are external user and just want to consume packages in the feed you can scope the packages for the feed to just the ones you want by using [packageSourceMapping](https://learn.microsoft.com/nuget/reference/nuget-config-file#packagesource) similar to:
```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="Azure SDK for .NET Dev Feed" value="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json" />
  </packageSources>
  <disabledPackageSources>
    <clear />
  </disabledPackageSources>
  <packageSourceMapping>
    <packageSource key="Azure SDK for .NET Dev Feed">
      <package pattern="Azure.*" />
    </packageSource>
</packageSourceMapping>
</configuration>
```

### 2. Find NuGet Package

You can use the following options to find the available dev feed packages:

1. Search the Azure SDK for .NET Dev Feed: https://dev.azure.com/azure-sdk/public/_packaging?_a=feed&feed=azure-sdk-for-net
1. In Visual Studio, use the [Package Manager UI](https://docs.microsoft.com/nuget/create-packages/prerelease-packages#installing-and-updating-pre-release-packages), be sure to check "Include prerelease".
1. Use the NuGet CLI, for example `nuget list azure.identity -Prerelease -Allversions`

### 3. Reference NuGet Package

Now that you have found the package you want to use, it is time to add it to your project file.

As you can see in the example below, we want to use the `Azure.Data.Tables` version `3.0.0-alpha.*`. By using the `*` in the version number each `dotnet restore` will pull the latest version from the dev feed.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Azure.Data.Tables" Version="3.0.0-alpha.*" />
  </ItemGroup>
</Project>
```

## Preparing a new library release

To prepare a package for release you should make use of `.\eng\common\scripts\Prepare-Release.ps1` script passing it appropriate arguments for the package intended for release. This script will correctly update the package version and changelog in the repo as well as update the DevOps release work items for that release.

```
.\eng\common\scripts\Prepare-Release.ps1 <PackageName> [<ServiceDirectory>] [<ReleaseDate>] [-ReleaseTrackingOnly]
```

- `<PackageName>` - Should match the full exact package name for the given ecosystem (i.e. "Azure.Core", "azure-core", "@azure/core", etc).
- `<SerivceDirectory>` - Optional: Should be the exact directory name where the package resides in the repo. This is usually the same as the service name in most cases (i.e. "sdk<service_directory>" e.g. "core"). The parameter is optional and if provided will help speed-up the number of projects we have to parse to find the matching package project.
- `<ReleaseDate>` - Optional: provide a specific date for when you plan to release the package. If one isn't given then one will be calculated based on the normal monthly shipping schedule.
- `<ReleaseTrackingOnly>` - Optional: Switch that if passed will only update the release tracking data in DevOps and not update any versioning info or do validation in the local repo.

## On-boarding New Generated Code Library

### Project Structure

In `sdk\< Service Name >`, you will find projects for services that have already been implemented.

1. Client library projects needs to use the $(RequiredTargetFrameworks) *(defined in eng/Directory.Build.Data.props)* property in its TargetFramework while management library projects should use $(SdkTargetFx) *(defined in AzSdk.reference.props)*
2. Projects of related packages are grouped together in a folder following the structure specified in [Repo Structure](https://github.com/Azure/azure-sdk/blob/main/docs/policies/repostructure.md).
   - Client library packages are in a folder name like ***Microsoft.Azure.< ServiceName >***
   - Management library packages are in a folder named like ***Azure.ResourceManager.< Resource Provider Name >***
3. Each shipping package contains a project for their **generated** and /or **Customization** code
   - The folder **'Generated'** contains the generated code
   - The folder **'Customizations'** contains additions to the generated code - this can include additions to the generated partial classes, or additional classes that augment the SDK or call the generated code
   - The file **generate.cmd**, used to generate library code for the given package, can also be found in this project

### On-boarding (Data plane) Generated Clients

See [Data Plane Quick Start Tutorial](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKCodeGeneration_DataPlane_Quickstart.md) for details.

### On-boarding Data Plane (Gen 1) Convenience Clients And Management Plane Generated Clients

#### Standard Process

1. Fork the [Azure REST API Specs](https://github.com/azure/azure-rest-api-specs) repository
2. Create your Swagger specification for your HTTP API. For more information see [Introduction to Swagger - The World's Most Popular Framework for APIs](https://swagger.io)
3. Install the latest version of AutoRest. For more info on getting started with AutoRest, see the [AutoRest repository](https://github.com/Azure/autorest)
4. **MANDATORY**: Create a topic branch in your fork of the Azure SDK for .NET; this is where your changes will be made.
5. Generate the code. See [Generating Client Code](#generating-client-code) below.
6. **MANDATORY**: Add or update tests for the newly generated code.
7. Once added to the Azure SDK for .NET, build your local package using [client](#client-libraries) or [management](#management-libraries) library instructions shown in the above sections.
8. For management libraries run `eng\scripts\Update-Mgmt-CI.ps1` to update PR include paths in `sdk\resourcemanager\ci.mgmt.yml`
9. Opan a pull request with your changes against the `main` branch of the [Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net)
10. The pull requests will be reviewed and merged by the Azure SDK team

#### Generating Client Code

1. Install templates for both data-plane and management-plane (control-plan) SDKs:

   ```dotnetcli
   # Data-plane SDK
   dotnet new --install sdk/template
   dotnet new azuresdk --name Azure.MyService --output sdk/myservice --ServiceDirectory myservice --ProjectName Azure.MyService

   # Management-plane SDK
   dotnet new --install eng/templates/Azure.ResourceManager.Template
   dotnet new azuremgmt --help
   ```

   There are several options available for management-plane SDKs. You can see all those available with `--help` as shown above, or
   [read about them](https://github.com/heaths/azure-sdk-for-net/blob/main/eng/templates/README.md) in our documentation.

   This will perform most of the renames, namespace fix-ups, and similar, for you automatically; though, be sure to check all files - especially the README.md file(s) - for required manual changes.
   If the template is already installed, this same command will upgrade it.

2. Modify `autorest.md` to point to you Swagger file or central README.md file. E.g.

   ``` yaml
   input-file:
       - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/[COMMIT-HASH]/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/blob.json
       - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/[COMMIT-HASH]/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/file.json
       - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/[COMMIT-HASH]/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/storage.json
   ```

   ``` yaml
   require: https://github.com/Azure/azure-rest-api-specs/blob/[COMMIT-HASH]/specification/azsadmin/resource-manager/storage/readme.md
   ```

3. Run `dotnet build /t:GenerateCode` in src directory of the project (e.g. `net\sdk\storage\Azure.Management.Storage\src`). This would run AutoRest and generate the code. (NOTE: this step requires Node 14).
4. For management plan libraries add `azure-arm: true` setting to `autorest.md` client constructors and options would be auto-generated. For data-plane libraries follow the next two steps.
5. Add a `*ClientOptions` type that inherits from `ClientOptions` and has a service version enum:

   ``` C#
   namespace Azure.Management.Storage
   {
       public class StorageManagementClientOptions: ClientOptions
       {
           private const ServiceVersion Latest = ServiceVersion.V2019_06_01;
           internal static StorageManagementClientOptions Default { get; } = new StorageManagementClientOptions();

           public StorageManagementClientOptions(ServiceVersion serviceVersion = Latest)
           {
               VersionString = serviceVersion switch
               {
                   ServiceVersion.V2019_06_01 => "2019-06-01",
                   _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
               };
           }

           internal string VersionString { get; }

           public enum ServiceVersion
           {
   #pragma warning disable CA1707 // Identifiers should not contain underscores
               V2019_06_01 = 1
   #pragma warning restore CA1707
           }
       }
   }
   ```

6. Add public constructors to all the clients using a partial class.

   ``` C#
    public partial class FileSharesClient
       {
           public FileSharesClient(string subscriptionId, TokenCredential tokenCredential): this(subscriptionId, tokenCredential, StorageManagementClientOptions.Default)
           {
           }

           public FileSharesClient(string subscriptionId, TokenCredential tokenCredential, StorageManagementClientOptions options):
               this(new ClientDiagnostics(options), ManagementClientPipeline.Build(options, tokenCredential), subscriptionId, apiVersion: options.VersionString)
           {
           }
       }
   ```

### Code Review Process

Before a pull request will be considered by the Azure SDK team, the following requirements must be met:

- Prior to issuing the pull request:
  - All code must have completed any necessary legal sign-off for being publicly viewable (Patent review, JSR review, etc.)
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
    - In the message, make sure to acknowledge that the legal sign-off process is complete.

Once all of the above steps are met, the following process will be followed:

- A member of the Azure SDK team will review the pull request on GitHub.
- If the pull request meets the repository's requirements, the individual will approve the pull request, merging the code into the appropriate branch of the source repository.
  - The owner will then respond to the email sent as part of the pull request, informing the group of the completion of the request.
- If the request does not meet any of the requirements, the pull request will not be merged, and the necessary fixes for acceptance will be communicated back to the partner team.

### Pull Request Etiquette and Best Practices

#### Reviewers

- If you disagree with the overall approach of the PR, comment on the general PR rather than individual lines of code.
- Leaving [suggested changes](https://docs.github.com/pull-requests/collaborating-with-pull-requests/reviewing-changes-in-pull-requests/commenting-on-a-pull-request#adding-line-comments-to-a-pull-request) is welcomed, but please never commit them for a PR you did not create.
- When you are seeking to understand something rather than request corrections, it is suggested to use language such as "I'm curious ..." as a prefix to comments.
- For comments that are just optional suggestions or are explicitly non-blocking, prefix them with "nit: " or "non-blocking: ".
- Avoid marking a PR as "Request Changes" ![2022_01_27_08_33_07_Changes_for_discussion_to_the_PR_Template_by_christothes_Pull_Request_26631_](https://user-images.githubusercontent.com/1279263/151379844-b9babb22-b0fe-4b9c-b749-eb7488a38d84.png) unless you have serious concerns that should block the PR from merging.
- When to mark a PR as "Approved"
  - You feel confident that the code meets a high quality bar, has adequate test coverage, is ready to merge.
  - You have left comments that are uncontroversial and there is a shared understanding with the author that the comments can be addressed or resolved prior to being merged without significant discussion or significant change to the design or approach.
- When to leave comments without approval
  - You do not feel confident that your review alone is sufficient to call the PR ready to merge.
  - You have feedback that may require detailed discussion or may indicate a need to change the current design or approach in a non-trivial way.
- When to mark a PR as "Request Changes"
  - You have significant concerns that must be addressed before this PR should be merged such as unintentional breaking changes, security issues, or potential data loss.

#### Pull Request Authors

- If you add significant changes to a PR after it has been marked approved, please confirm with reviewers that they still approve before merging.
- Please ensure that you have obtained an approval from at least one of the code owners before merging.
- If a reviewer marks your PR as approved along with specific comments, it is expected that those comments will be addressed or resolved prior to merging.
  - One exception is when a comment clearly states that the feedback is optional or just a nit
  - When in doubt, reach out to the commentor to confirm that they have no concerns with you merging without addressing a comment.

### Client Library Tested Operating Systems and .NET Versions

|                          | Linux (Ubuntu 20.04) | MacOS 10.15 | Windows Server 2019 |
| ------------------------ | :------------------: | :---------: | :-----------------: |
| **.NET 7.0**             | x                    | x           | x                   |
| **.NET 6.0**             | x                    | x           | x                   |
| **.NET Framework 4.6.1** |                      |             | x                   |

### Issues with Generated Code

Much of the management plane SDK code is generated from metadata specs about the REST APIs. Do not submit PRs that modify generated code. Instead,

- File an issue describing the problem,
- Refer to the the [AutoRest project](https://github.com/azure/autorest) to view and modify the generator, or
- Add additional methods, properties, and overloads to the SDK by adding classes in the 'Customizations' folder of a project

## Versioning

For more information on how we version see [Versioning](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/Versioning.md).

## Breaking Changes

For information about breaking changes see [Breaking Change Rules](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-change-rules.md).

## Debugging

The libraries shipped out of this repo have [source link](https://docs.microsoft.com/dotnet/standard/library-guidance/sourcelink#using-source-link) enabled. Source link allows for symbols to be dynamically loaded while debugging, which allows you to step into the Azure SDK source code. This is often helpful when trying to step into Azure.Core code, as it is a package reference for most libraries. To enable using source link with the Azure SDK libraries in Visual Studio, you will need to check off Microsoft Symbol Servers as one of your Symbol file locations. Additionally, make sure that "Just My Code" is **_NOT_** enabled.

## Samples

### Third-party dependencies

Third party libraries should only be included in samples when necessary to demonstrate usage of an Azure SDK package; they should not be suggested or endorsed as alternatives to the Azure SDK.

When code samples take dependencies, readers should be able to use the material without significant license burden or research on terms. This goal requires restricting dependencies to certain types of open source or commercial licenses.

Samples may take the following categories of dependencies:

- **Open-source** : Open source offerings that use an [Open Source Initiative (OSI) approved license](https://opensource.org/licenses). Any component whose license isn't OSI-approved is considered a commercial offering. Prefer OSS projects that are members of any of the [OSS foundations that Microsoft is part of](https://opensource.microsoft.com/ecosystem/). Prefer permissive licenses for libraries, like [MIT](https://opensource.org/licenses/MIT) and [Apache 2](https://opensource.org/licenses/Apache-2.0). Copy-left licenses like [GPL](https://opensource.org/licenses/gpl-license) are acceptable for tools, and OSs. [Kubernetes](https://github.com/kubernetes/kubernetes), [Linux](https://github.com/torvalds/linux), and [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) are examples of this license type. Links to open source components should be to where the source is hosted, including any applicable license, such as a GitHub repository (or similar).

- **Commercial**: Commercial offerings that enable readers to learn from our content without unnecessary extra costs. Typically, the offering has some form of a community edition, or a free trial sufficient for its use in content. A commercial license may be a form of dual-license, or tiered license. Links to commercial components should be to the commercial site for the software, even if the source software is hosted publicly on GitHub (or similar).

- **Dual licensed**: Commercial offerings that enable readers to choose either license based on their needs. For example, if the offering has an OSS and commercial license, readers can  choose between them. [MySql](https://github.com/mysql/mysql-server) is an example of this license type.

- **Tiered licensed**: Offerings that enable readers to use the license tier that corresponds to their characteristics. For example, tiers may be available for students, hobbyists, or companies with defined revenue  thresholds. For offerings with tiered licenses, strive to limit our use in tutorials to the features available in the lowest tier. This policy enables the widest audience for the article. [Docker](https://www.docker.com/), [IdentityServer](https://duendesoftware.com/products/identityserver), [ImageSharp](https://sixlabors.com/products/imagesharp/), and [Visual Studio](https://visualstudio.com) are examples of this license type.

In general, we prefer taking dependencies on licensed components in the order of the listed categories. In cases where the category may not be well known, we'll document the category so that readers understand the choice that they're making by using that dependency.
