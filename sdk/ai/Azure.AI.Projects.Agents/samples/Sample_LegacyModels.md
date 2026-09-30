# Using legacy and shared agent tool models together

The 3.x compatibility prototype retains the public tool models from `Azure.AI.Projects.Agents` 2.0.
They keep their original namespace, constructors, members, and serialization contracts, and are marked
`EditorBrowsable(EditorBrowsableState.Never)` to discourage new source code from selecting them.
The replacement tool models are in `Azure.AI.Extensions.OpenAI`.

## Fully qualified names are required when imports overlap

An application may need both namespaces: one for `AgentAdministrationClient` and one for the shared tools.

```C# Snippet:Sample_LegacyAgentModels_Imports
using Azure.AI.Projects.Agents;
using Azure.AI.Extensions.OpenAI;
```

With both imports, an unqualified reference such as `AzureAISearchTool` or `AzureAISearchToolOptions`
is ambiguous (`CS0104`). **`EditorBrowsable(Never)` affects IntelliSense, not compiler name resolution.**
Use fully qualified names, as below, or explicit C# aliases to select the intended model.
The same applies to other names present in both namespaces. Existing binaries do not encounter
source-name ambiguity, and source using only one namespace does not need qualification for this reason.

The following example creates both model versions without contacting the service.
The shared model is experimental and requires acknowledging its `AAIP002` diagnostic.

```csharp
#pragma warning disable AAIP002
```

```C# Snippet:Sample_LegacyAgentModels_QualifiedNames
// Both namespaces contain AzureAISearchTool and AzureAISearchToolOptions.
// EditorBrowsable(Never) does not remove the legacy names from compilation.
var legacyTool = new Azure.AI.Projects.Agents.AzureAISearchTool(
    new Azure.AI.Projects.Agents.AzureAISearchToolOptions(
    [
        new Azure.AI.Projects.Agents.AzureAISearchToolIndex
        {
            ProjectConnectionId = "search-connection",
            IndexName = "documents"
        }
    ]));

var sharedTool = new Azure.AI.Extensions.OpenAI.AzureAISearchTool(
    new Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions(
    [
        new Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex
        {
            ProjectConnectionId = "search-connection",
            IndexName = "documents"
        }
    ]));

// Existing code can keep using the legacy model and its implicit conversion.
var legacyDefinition = new DeclarativeAgentDefinition("model-deployment")
{
    Tools = { legacyTool }
};

// New code can use the shared model directly.
var sharedDefinition = new DeclarativeAgentDefinition("model-deployment")
{
    Tools = { sharedTool }
};
```

## Compatibility boundaries

- The legacy `ProjectsAgentTool` conversion creates a shared `OpenAI.Responses.ResponseTool` from the
  current legacy model's JSON. `ResponseToolExtensions.AsAgentTool` provides the reverse conversion.
  Conversion creates a snapshot; subsequent mutations to one representation do not update the other.
- Hiding a legacy type does not make it the same CLR type as its replacement. Methods and collections
  expecting one model do not automatically accept the other except where an explicit conversion exists.
- `WebSearchTool.CustomSearchConfiguration` retains its legacy model type. Use `SearchConfiguration`
  to access the same configuration with the shared `WebSearchConfiguration` model.
- The legacy hosted-agent `Tools` property and model-factory signature are retained for binary
  compatibility. The current hosted-agent service contract does not use that property, so retaining
  it does not restore the old hosted-agent behavior.
- This prototype targets compatibility with the released 2.0 API. It does not guarantee every source
  program, earlier 3.x preview contract, or service behavior remains unchanged. Preview consumers that
  used the shared type through `CustomSearchConfiguration` should use `SearchConfiguration` instead.
