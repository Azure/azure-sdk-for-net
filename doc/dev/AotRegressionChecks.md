# AOT compatibility regression test in CI pipelines

An increasing number of .NET Azure SDK libraries are committed to being fully compatible with native AOT. For more information about native AOT deployment see [this article](https://learn.microsoft.com/dotnet/core/deploying/native-aot/).

In order to align with this priority, a pipeline step called "Check for AOT compatibility regressions in \[Package Name\]" was added in all CI pipelines to prevent AOT regressions in all SDK libraries. This is true even if the package is not yet fully compatible with native AOT. This pipeline creates a small sample app that uses a project reference to collect the set of trimming warnings reported for the specified library. This approach for collecting warnings is described in [this article](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming?pivots=dotnet-8-0#show-all-warnings-with-test-app).

## See AOT warnings locally

Run the [Check AOT Compatibility script](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/scripts/compatibility/Check-AOT-Compatibility.ps1).

To see all warnings:
```
PS C:\...\azure-sdk-for-net\eng\scripts\compatibility> .\Check-AOT-Compatibility.ps1 core Azure.Core
```

To see only the warnings that are not baselined:
```
PS C:\...\azure-sdk-for-net\eng\scripts\compatibility> .\Check-AOT-Compatibility.ps1 core Azure.Core "Azure.Core/tests/compatibility/ExpectedWarnings.txt"
```

## Resolve AOT warnings

The following three articles provide comprehensive guidance for how to resolve trimming warnings and make libraries compatible with AOT:
- ["How to make libraries compatible with native AOT"](https://devblogs.microsoft.com/dotnet/creating-aot-compatible-libraries/) by Eric Erhardt on November 30th, 2023
- ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming)
- ["Introduction to trim warnings"](https://learn.microsoft.com/dotnet/core/deploying/trimming/fixing-warnings)

Learning how to use source generation for serialization/deserialization:
- [Introduction of C# source generation in .NET 6](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/)
- [How to use source generation](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation)


## Baseline expected warnings

In an ideal scenario, this pipeline will pass with no baselined warnings. However, there are cases where a library needs to define an expected set of warnings to ignore when running this check. Sometimes warnings are not straightforward \(or are even impossible\) to resolve, but are not expected to impact the majority of customer use cases. In other cases, warnings may be dependent on other work finishing first (for example, adding a net6.0 target, or upgrading a package dependency version).

The text file should be formatted with each warning on its own line. The pipeline uses pattern matching to validate warnings. You can use BaselineExistingWarnings.ps1 in eng/scripts/compatibility to create the expected warnings file from the AOT regressions output from Check-AOT-Compatibility.

```
```


### Update ci.yml file

To baseline warnings, pass the filepath to the CI in ci.yml using the following structure:
```yml
extends:
  template: /eng/pipelines/templates/stages/archetype-sdk-client.yml
  parameters:
    ServiceDirectory: [service directory]
    # [... other inputs]
    ExpectedAOTWarnings:
    - ArtifactName: [Name of package]
      ExpectedWarningsFilePath: [Filepath of errors relative to the service directory]
```