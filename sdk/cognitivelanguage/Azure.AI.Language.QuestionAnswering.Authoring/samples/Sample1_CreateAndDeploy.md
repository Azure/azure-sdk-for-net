# Create and Deploy Question Answering Projects

This sample demonstrates how to create and deploy Question Answering projects. To get started, you'll need to create a Question Answering service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) for links and instructions.

To create, deploy, or perform any other authoring actions for Question Answering projects, you need to first create a `QuestionAnsweringAuthoringClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:QuestionAnsweringAuthoringClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

### Creating a Project

To create a new Question Answering project, you will need to set your project name as well as the request content and call `CreateProject()` as shown below:

```C# Snippet:QuestionAnsweringAuthoringClient_CreateProject
// Set project name and request content parameters
string newProjectName = "{ProjectName}";
RequestContent creationRequestContent = RequestContent.Create(
    new {
        description = "This is the description for a test project",
        language = "en",
        multilingualResource = false,
        settings = new {
            defaultAnswer = "No answer found for your question."
            }
        }
    );

Response creationResponse = client.CreateProject(newProjectName, creationRequestContent);

// Projects can be retrieved as follows
Pageable<QuestionAnsweringProject> projects = client.GetProjects();

Console.WriteLine("Projects: ");
foreach (QuestionAnsweringProject project in projects)
{
    Console.WriteLine(project);
}
```

### Adding a knowledge base source

You might want to add a knowledge base source to your project before deployment. Alternatively, you might wish to manually input question and answer pairs using the `UpdateQnas()` method. Please note that the service will not allow you to deploy an empty project.

The following snippet shows how to add a new knowledge base source to your project using the `UpdateSources()` method.

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSources
// Set request content parameters for updating our new project's sources
string sourceUri = "{KnowledgeSourceUri}";
RequestContent updateSourcesRequestContent = RequestContent.Create(
    new[] {
        new {
                op = "add",
                value = new
                {
                    displayName = "MicrosoftFAQ",
                    source = sourceUri,
                    sourceUri = sourceUri,
                    sourceKind = "url",
                    contentStructureKind = "unstructured",
                    refresh = false
                }
            }
    });

Operation updateSourcesOperation = client.UpdateSources(WaitUntil.Completed, newProjectName, updateSourcesRequestContent);

// Knowledge Sources can be retrieved as follows
BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

Console.WriteLine($"Sources: {sources}");
```

### Deploy your Project

```C# Snippet:QuestionAnsweringAuthoringClient_DeployProject
// Set deployment name and start operation
string newDeploymentName = "{DeploymentName}";

Operation deploymentOperation = client.DeployProject(WaitUntil.Completed, newProjectName, newDeploymentName);

// Deployments can be retrieved as follows
Pageable<ProjectDeployment> deployments = client.GetDeployments(newProjectName);
Console.WriteLine("Deployments: ");
foreach (ProjectDeployment deployment in deployments)
{
    Console.WriteLine(deployment);
}
```

## Asynchronous

### Creating a Project

```C# Snippet:QuestionAnsweringAuthoringClient_CreateProjectAsync
// Set project name and request content parameters
string newProjectName = "{ProjectName}";
RequestContent creationRequestContent = RequestContent.Create(
    new
    {
        description = "This is the description for a test project",
        language = "en",
        multilingualResource = false,
        settings = new
        {
            defaultAnswer = "No answer found for your question."
        }
    }
    );

Response creationResponse = await client.CreateProjectAsync(newProjectName, creationRequestContent);

// Projects can be retrieved as follows
AsyncPageable<QuestionAnsweringProject> projects = client.GetProjectsAsync();

Console.WriteLine("Projects: ");
await foreach (QuestionAnsweringProject project in projects)
{
    Console.WriteLine(project);
}
```

### Adding a knowledge base source

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSourcesAsync
// Set request content parameters for updating our new project's sources
string sourceUri = "{KnowledgeSourceUri}";
RequestContent updateSourcesRequestContent = RequestContent.Create(
    new[] {
        new {
                op = "add",
                value = new
                {
                    displayName = "MicrosoftFAQ",
                    source = sourceUri,
                    sourceUri = sourceUri,
                    sourceKind = "url",
                    contentStructureKind = "unstructured",
                    refresh = false
                }
            }
    });

Operation updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, newProjectName, updateSourcesRequestContent);

// Knowledge Sources can be retrieved as follows
BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

Console.WriteLine($"Sources: {sources}");
```

### Deploy your Project

```C# Snippet:QuestionAnsweringAuthoringClient_DeployProjectAsync
// Set deployment name and start operation
string newDeploymentName = "{DeploymentName}";

Operation deploymentOperation = await client.DeployProjectAsync(WaitUntil.Completed, newProjectName, newDeploymentName);

// Deployments can be retrieved as follows
AsyncPageable<ProjectDeployment> deployments = client.GetDeploymentsAsync(newProjectName);
Console.WriteLine("Deployments: ");
await foreach (ProjectDeployment deployment in deployments)
{
    Console.WriteLine(deployment);
}
```
