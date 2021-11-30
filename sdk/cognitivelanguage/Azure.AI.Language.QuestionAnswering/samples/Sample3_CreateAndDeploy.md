# Create and Deploy Question Answering Projects

This sample demonstrates how to create and deploy Question Answering projects. To get started, you'll need to create a Question Answering service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) for links and instructions.

To create, deploy, or perform any other authoring actions for Question Answering projects, you need to first create a `QuestionAnsweringProjectsClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:QuestionAnsweringProjectsClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringProjectsClient client = new QuestionAnsweringProjectsClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

### Creating a Project

To create a new Question Answering project, you will need to set your project name as well as the request content and call `CreateProject()` as shown below:

```C# Snippet:QuestionAnsweringProjectsClient_CreateProject
// Set project name and request content parameters
string newProjectName = "NewFAQ";
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
Pageable<BinaryData> projects = client.GetProjects();

Console.WriteLine("Projects: ");
foreach (BinaryData project in projects)
{
    Console.WriteLine(project);
}
```

### Adding a knowledge base source

You might want to add a knowledge base source to your project before deployment. Alternatively, you might wish to manually input question and answer pairs using the `UpdateQnas()` method. Please note that the service will not allow you to deploy an empty project.

The following snippet shows how to add a new knowledge base source to your project using the `UpdateSources()` method.

```C# Snippet:QuestionAnsweringProjectsClient_UpdateSources
// Set request content parameters for updating our new project's sources
string sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
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

Operation<BinaryData> updateSourcesOperation = client.UpdateSources(newProjectName, updateSourcesRequestContent);

// Wait for operation completion
TimeSpan pollingInterval = new TimeSpan(1000);

while (true)
{
    updateSourcesOperation.UpdateStatus();
    if (updateSourcesOperation.HasCompleted)
    {
        Console.WriteLine($"Update Sources operation value: \n{updateSourcesOperation.Value}");
        break;
    }

    Thread.Sleep(pollingInterval);
}

// Knowledge Sources can be retrieved as follows
Pageable<BinaryData> sources = client.GetSources(newProjectName);
Console.WriteLine("Sources: ");
foreach (BinaryData source in sources)
{
    Console.WriteLine(source);
}
```

### Deploy your Project

```C# Snippet:QuestionAnsweringProjectsClient_DeployProject
// Set deployment name and start operation
string newDeploymentName = "production";
Operation<BinaryData> deploymentOperation = client.DeployProject(newProjectName, newDeploymentName);

// Wait for completion with manual polling.
while (true)
{
    deploymentOperation.UpdateStatus();
    if (deploymentOperation.HasCompleted)
    {
        Console.WriteLine($"Deployment operation value: \n{deploymentOperation.Value}");
        break;
    }

    Thread.Sleep(pollingInterval);
}

// Deployments can be retrieved as follows
Pageable<BinaryData> deployments = client.GetDeployments(newProjectName);
Console.WriteLine("Deployments: ");
foreach (BinaryData deployment in deployments)
{
    Console.WriteLine(deployment);
}
```

## Asynchronous

### Creating a Project

```C# Snippet:QuestionAnsweringProjectsClient_CreateProjectAsync
// Set project name and request content parameters
string newProjectName = "NewFAQ";
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
AsyncPageable<BinaryData> projects = client.GetProjectsAsync();

Console.WriteLine("Projects: ");
await foreach (BinaryData project in projects)
{
    Console.WriteLine(project);
}
```

### Adding a knowledge base source

```C# Snippet:QuestionAnsweringProjectsClient_UpdateSourcesAsync
// Set request content parameters for updating our new project's sources
string sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
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

Operation<BinaryData> updateSourcesOperation = await client.UpdateSourcesAsync(newProjectName, updateSourcesRequestContent);

// Wait for operation completion
Response<BinaryData> updateSourcesOperationResult = await updateSourcesOperation.WaitForCompletionAsync();

Console.WriteLine($"Update Sources operation result: \n{updateSourcesOperationResult}");

// Knowledge Sources can be retrieved as follows
AsyncPageable<BinaryData> sources = client.GetSourcesAsync(newProjectName);
Console.WriteLine("Sources: ");
await foreach (BinaryData source in sources)
{
    Console.WriteLine(source);
}
```

### Deploy your Project

```C# Snippet:QuestionAnsweringProjectsClient_DeployProjectAsync
// Set deployment name and start operation
string newDeploymentName = "production";
Operation<BinaryData> deploymentOperation = await client.DeployProjectAsync(newProjectName, newDeploymentName);

// Wait for operation completion
Response<BinaryData> deploymentOperationResult = await deploymentOperation.WaitForCompletionAsync();

Console.WriteLine($"Update Sources operation result: \n{deploymentOperationResult}");

// Deployments can be retrieved as follows
AsyncPageable<BinaryData> deployments = client.GetDeploymentsAsync(newProjectName);
Console.WriteLine("Deployments: ");
await foreach (BinaryData deployment in deployments)
{
    Console.WriteLine(deployment);
}
```