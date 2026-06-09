---
name: build-stable-list
description: "Build the list of stable types for the project. Parameters <cs_root> - the root of a checked out C# repository. <ts_root> the root of a checked out typespec repository."
---

# General information on generated types naming

The C# repository root location is provided by \<cs_root\>. C# source codes of interest are located in \<cs_root\>/sdk/ai/Azure.AI.Projects, \<cs_root\>/sdk/ai/Azure.AI.Projects.Agents and \<cs_root\>/sdk/ai/Azure.AI.Extensions.OpenAI. Each folder contains subfolder `src`, which contains all the source codes. The `src/Generated` folder contains generated code; the folder `Custom` contains the code customizations. Please review the `references/customization.md` for more information on code customization. All three projects shares the same typespec, located at \<ts_root\>/specification/ai-foundry/data-plane/Foundry. The projects are being generated from the next entry points:

- Azure.AI.Projects from \<ts_root\>/specification/ai-foundry/data-plane/Foundry/sdk-csharp-azure-ai-projects/cliet.tsp
- Azure.AI.Extensions.OpenAI \<ts_root\>/specification/ai-foundry/data-plane/Foundry/sdk-csharp-azure-ai-extensions-openai/cliet.tsp
- Azure.AI.Projects.Agents \<ts_root\>/specification/ai-foundry/data-plane/Foundry/sdk-csharp-azure-ai-projects-agents/cliet.tsp

The entry point files contain renames of types for the specific projects.
Rename happens as follows
1. The rename from cliet.tsp is bveing applies
2. The code customization in .NET code `[CodeGenmember("foo")] public class Bar {}` as outlined in `references/customization.md`.

# The task

## List rules

`#` denotes the start of a comment
`stableTypes:` denotes the start of section containing stable types. All types before this sections must be ignored (do not write any types before this section).
`- ` denotes the fully qualified type which should be stable.

Example:

```
# Some arbitrary comment
- Some.Unstable.Class

stableTypes:
- Some.Stable.Class1
- Some.Stable.Enum1
```

The stable types are `Some.Stable.Class1` and `Some.Stable.Enum1`.

## Process of stable types definition

There are two sources of stable types: stable clients - for these clients all paths are stable, and stable tools.

### Stable clients

Stable clients are defined in the next folders:

- agents
- connections
- datasets
- deployments
- evaluations
- evaluation-rules
  With the exception of `Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction` and types used by it.
- indexes

The stable types and enumerations are defined in ${folder}/models.tsp file. The folder `common` does not contain the client, but contains only stable objects.

All locations in this sections are relative to the path \<ts_root\>/specification/ai-foundry/data-plane/Foundry/src.

### Stable tools

The tool models are defined in `tools/models.tsp` file. Current stable tools from this files are:

- AzureFunctionTool
- AzureAISearchTool
- BingGroundingTool
- CaptureStructuredOutputsTool
- OpenApiTool

All these tools and dependent types needs to be present in the list. For example `OpenApiToolCall` is dependent on `OpenApiTool` and also need to be listed as stable.

Please also look at \<cs_root\>/sdk/ai/\<project\>/src/Generated to find other tools, not listed in `tools/models.tsp` these are tools, coming from OpenAI, unless they were renames as outlined in `references/customization.md`, these tools and dependent types needs to present in the stable list.
Do not look at pre existing in the repository lists; if the tool specification has a word preview in it, do not mark it as stable.


## List location

Please save the list at \<cs_root\>sdk/ai/codegen/generator/src/ and name it as stable_types_\<project_name\>.yaml where project name is one of `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`. Do not look at the pre existing files/
