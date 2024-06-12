# Enable AOT compatibility regression testing in CI pipelines

An increasing number of .NET Azure SDK libraries are committed to being compatible with native AOT. For more information about native AOT deployment see [this article](https://learn.microsoft.com/dotnet/core/deploying/native-aot/). To support this work, there is now an opt-in pipeline step called "Check for AOT compatibility regressions in \[Package Name\]". This pipeline creates a small sample app that uses a project reference to collect the set of trimming warnings reported for the specified library. This approach for collecting warnings is described in [this article](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming?pivots=dotnet-8-0#show-all-warnings-with-test-app).

## How to enable the pipeline for your package

### Collect any expected trimming warnings

You can use any of the approaches described in the articles linked at the bottom of this document to find the warnings reported from your library. In an ideal scenario, this would be zero. However, there are cases where a library needs to baseline an expected set of warnings. Sometimes warnings are not straightforward \(or are even impossible\) to resolve, but are not expected to impact the majority of customer use cases. In other cases, warnings may be dependent on other work finishing first (for example, adding a net6.0 target, or upgrading a package dependency version).

The text file should be formatted with each warning on its own line. The pipeline uses pattern matching to validate warnings. This means that warnings will need to be edited to avoid using special characters incorrectly. Even though it seems easier to just do simple string matching, the errors are formatted differently depending on the environment, so using correctly formatted pattern matching makes it easier.

**Example**:

Actual warning:
> C:\Users\mredding\source\repos\azure-sdk-for-net\sdk\core\Azure.Core\src\JsonPatchDocument.cs(44): Trim analysis warning IL2026: Azure.JsonPatchDocument.JsonPatchDocument(ReadOnlyMemory`1<Byte>): Using member 'Azure.Core.Serialization.JsonObjectSerializer.JsonObjectSerializer()' which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code. This class uses reflection-based JSON serialization and deserialization that is not compatible with trimming. [C:\Users\mredding\source\repos\ResolveAOT\ResolveAOT\ResolveAOT.csproj]

Line in the text file:
> Azure\\.Core.src.JsonPatchDocument\\.cs\\(\\d*\\): Trim analysis warning IL2026: Azure\\.JsonPatchDocument\\.JsonPatchDocument\\(ReadOnlyMemory`1<Byte>\\): Using member 'Azure\\.Core\\.Serialization\\.JsonObjectSerializer\\.JsonObjectSerializer\\(\\)' which has 'RequiresUnreferencedCodeAttribute'

**Note**: In my case, my local environment uses forward slashes in filepaths, while the pipeline uses back slashes, so using a wildcard was the easiest way to reconcile this.

### Update ci.yml file

The ci.yml file needs to be updated to include the following information:
```yml
extends:
  template: /eng/pipelines/templates/stages/archetype-sdk-client.yml
  parameters:
    ServiceDirectory: [service directory]
    # [... other inputs]
    CheckAOTCompat: true
    AOTTestInputs:
    - ArtifactName: [Name of package]
      ExpectedWarningsFilePath: None [or filepath of errors relative to the service directory]
```

**Example**:
```yml
extends:
  template: /eng/pipelines/templates/stages/archetype-sdk-client.yml
  parameters:
    ServiceDirectory: core
    # [... other inputs]
    CheckAOTCompat: true
    AOTTestInputs:
    - ArtifactName: Azure.Core
      ExpectedWarningsFilepath: /Azure.Core/tests/aotcompatibility/ExpectedAotWarnings.txt
```
**Example 2**:
```yml
extends:
  template: /eng/pipelines/templates/stages/archetype-sdk-client.yml
  parameters:
    ServiceDirectory: core
    # [... other inputs]
    CheckAOTCompat: true
    AOTTestInputs:
    - ArtifactName: Azure.Core
      ExpectedWarningsFilepath: /Azure.Core/tests/aotcompatibility/ExpectedAotWarnings.txt
    - ArtifactName: Azure.Core.Experimental # For illustration only
      ExpectedWarningsFilepath: None
```

## How to resolve trimming warnings

The following three articles provide comprehensive guidance for how to resolve trimming warnings and make libraries compatible with AOT:
- ["How to make libraries compatible with native AOT"](https://devblogs.microsoft.com/dotnet/creating-aot-compatible-libraries/) by Eric Erhardt on November 30th, 2023
- ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming)
- ["Introduction to trim warnings"](https://learn.microsoft.com/dotnet/core/deploying/trimming/fixing-warnings)

Learning how to use source generation for serialization/deserialization:
- [Introduction of C# source generation in .NET 6](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/)
- [How to use source generation](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation)
