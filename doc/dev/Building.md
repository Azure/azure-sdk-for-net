# Azure SDK for .NET - Building

Building [management plane](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#management-libraries) and [data plane](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#client-libraries) libraries is already covered in our root [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md). This document is focused on understanding how projects are automatically assigned derived properties and how pipelines within this repository interact with [common engineering pipelines](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md) prevalent across all Azure SDK language repos.

## Projects

All our SDKs for .NET use [SDK-style project](https://learn.microsoft.com/dotnet/core/project-sdk/overview) files - typically _.csproj_ files. There's typically little to author in these projects because many properties like the assembly name and package name are derived automatically by the C# project system targets. These same targets also find the first _Directory.Build.props_ (processed before the contents of the _.csproj_ file) and _Directory.Build.targets_ (processed after the content of the _.csproj_ file) in ancestor directories. In most cases, that will find those files in the repo root. If you add either of these files in any directory below the root, be sure to add something like the following in an order that makes sense for your use case:

```xml
<Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory).., Directory.Build.props))\Directory.Build.props" />
```

The root _Directory.Build.props_ and _Directory.Build.targets_ files do little more than include _eng/Directory.Common.Build.props_ and _eng/Directory.Common.Build.props_, respectively. Within those files is where most of the repo-specific automatic customization happens. Because this repo contains both track 1 (typically _Microsoft.Azure.*_ packages) and track 2 (typically _Azure.*_ packages), most track 2 customizations depend on the property `IsClientLibrary`, which that and related properties you can find set near the top of _eng/Directory.Common.Build.props_.

This is also where, for example, the `$(RequiredTargetFrameworks)` property is set and maintained for both production and test projects, and why that's one of the few properties you have to set in each package project e.g.,

```xml
<PropertyGroup>
    <TargetFrameworks>$(RequiredTargetFrameworks)</TargetFrameworks>
</PropertyGroup>
```

Always set the plural `<TargetFrameworks>` standard property for the correct behavior when building any project whether you are multi-targeting or not.

### Project discovery

Detailed more in our root [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md), it's notable that contributors will typically run `dotnet build` or `dotnet test` in a service directory of package directory, but the pipelines described below typically build using _eng/service.proj_ or _eng/mgmt.proj_ which uses traversal SDK to enumerate all packages within a specified service directory. This means that any solution files are ignored, so you can use them or put them wherever make sense for your SDK.

If you need to customize the collection of projects discovered by either of those traversal projects, you can put a _service.projects_ file in your service direectory with contents like this:

```xml
<Project>
  <ItemGroup>
    <!-- Make sure backup/restore tests in the Administration package do not run parallel with other tests. -->
    <ProjectReference Update="$(MSBuildThisFileDirectory)Azure.Security.KeyVault.Administration\tests\Azure.Security.KeyVault.Administration.Tests.csproj">
      <TestInParallel>false</TestInParallel>
    </ProjectReference>
  </ItemGroup>
</Project>
```

## Pipelines

Similar to how all projects require minimal authoring, various [Azure Pipelines](https://learn.microsoft.com/azure/devops/pipelines/) for each package also require very little authoring and all start from the following files in a service directory:

* _ci.yml_ for data plane PR and release pipelines.
* _ci.mgmt.yml_ for management plane PR and release pipelines.
* _test.yml_ for live test pipelines.

These pipeline definitions typically contain the necessary triggers, paths to watch, and package information. See existing SDKs' files for examples to avoid duplicating information that may change here. _tests.yml_ might also contain additional [matrix generation](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/matrix_generator.md) options to change or add testing environments particular to a service directory.

If you're working on engineering system changes for the .NET repo within one of the files above, you can follow the `template` directives. Currently, for example, a _ci.yml_ would include a chain of templates like so:

* _sdk/keyvault/ci.yml_
  * _eng/pipelines/templates/stages/archetype-sdk-client.yml_
    * _eng/pipelines/variables/globals.yml_
    * _eng/pipelines/templates/jobs/ci.yml_

      This is where a lot of common pipelines under _eng/common_ get included and passed various objects that those pipelines use, including calling back into repo-specific pipelines including jobs, steps, etc.

    * _eng/pipelines/templates/stages/archetype-net-release.yml_

      Same as above: common pipelines get included and passed various objects here too.

Any changes to the _eng_ directory outside of the _common_ subdirectory are owned by the Azure SDK for .NET team, but you should still coordinate with the central Engineering Systems team to discuss how your changes will work, go over any problems they might think of, and determine whether the changes should actually be common. Any changes within the _eng/common_ subdirectory should be discussed with the central EngSys team and should be made in the <https://github.com/Azure/azure-sdk-tools/tree/main/eng/common> directory. See [here](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md) for more information.
