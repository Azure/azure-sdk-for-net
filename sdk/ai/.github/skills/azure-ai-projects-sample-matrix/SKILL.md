---
name: build-sample-matrix
description: Build the matrix of all the samples throughout different frameworks.
---

# Repositary information.
The source code repositories and samples are organized in the following structure:

| Language | Repository | Samples | Notes |
| -------- | ---------- | ------- | ----- |
| Python | https://github.com/Azure/azure-sdk-for-python.git | https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/samples | All samples are organized by folders according to their topic. In most cases the sample has sync and async implementation. For example, `feature.py` and `feature_async.py` are demonstrating sync and async features. |
| C# | https://github.com/Azure/azure-sdk-for-net.git | https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects/tests/Samples, https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Extensions.OpenAI/tests/Samples, https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects.Agents/tests/Samples | C# sample consists of two parts: the source code in the folder /sdk/ai/<package_name>/tests/Samples and corresponding .md files go to /sdk/ai/<package_name>/Samples, where <package_name> is Azure.AI.Projects, Azure.AI.Extensions.OpenAI or Azure.AI.Projects.Agents |
| JavaScript | https://github.com/Azure/azure-sdk-for-js.git | https://github.com/Azure/azure-sdk-for-js/tree/main/sdk/ai/ai-projects/samples | The samples are split by two folders stable version (v2) and beta (v2-beta). Each of these folders contain samples for JavaScript and Typescript. Samples are further split by folders according to their topics. |
| Java | https://github.com/Azure/azure-sdk-for-java.git | https://github.com/Azure/azure-sdk-for-java/tree/main/sdk/ai/azure-ai-agents/src/samples/java/com/azure/ai/agents and https://github.com/Azure/azure-sdk-for-java/tree/main/sdk/ai/azure-ai-projects/src/samples | java code consists of two packagfes: azure-ai-projects and azure-ai-agents. Both of these projects contain samples, organized by folders according to their topics. |


# Instruction
Please use Server github-mcp-server, analyze samples and build the sample matrix in an Markdown format for developers to create missing samples. Here is an example. Let us say we have two samples: "Agents CRUD" and "Agents with default projects". Foo is present only in Python an C# and Bar is present only in Java and JavaScript.

| Feature | Description | Python | C# | JavaScript | Java |
| ------- | ----------- | ------ | -- | ---------- | ---- |
| Foo | Demonstrate Agents CRUD operations | [Agents basic](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/ai/azure-ai-projects/samples/agents/sample_agent_basic.py), [Agents basic async](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/ai/azure-ai-projects/samples/agents/sample_agent_basic_async.py) | [Agents basic](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects.Agents/tests/Samples/Sample_agents_CRUD.cs) | !!!Absent!!! | !!!Absent!!! |
| Bar | Demonstrate Agents with default projects | !!!Absent!!! | !!!Absent!!! | [Agents with default projects](https://github.com/Azure/azure-sdk-for-js/tree/main/sdk/ai/ai-projects/samples/v2/javascript/agents/agentBasicWithDefaultProject.js, https://github.com/Azure/azure-sdk-for-js/tree/main/sdk/ai/ai-projects/samples/v2/typescript/src/agents/agentBasicWithDefaultProject.ts) | !!!Absent!!! |

* Make sure, that all the sample files are included into the matrix, except for ones, containing only utility functions look for samples in all subdirectories.
* The tool samples for Python are located in https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/samples/agents/tools
* If python sample contains only synchronous or asynchronous sample, mark it as sync-only or async-only respectively.

Validate links in the generated file by running:
```powershell
python validate_links.py path/to/file.md
```

```bash
python3 validate_links.py path/to/file.md
```
