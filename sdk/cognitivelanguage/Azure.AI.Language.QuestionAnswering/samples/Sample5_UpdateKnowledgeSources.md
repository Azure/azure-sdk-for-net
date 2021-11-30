# Update Knowledge Sources

This sample demonstrates how to update knowledge sources, question and answer pairs, synonyms, and add feedback for active learning for Question Answering projects. To get started, you'll need to create a Question Answering service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) for links and instructions.

To add knowledge sources, update question and answer pairs, or perform any other authoring actions for Question Answering projects, you need to first create a `QuestionAnsweringProjectsClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:QuestionAnsweringProjectsClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringProjectsClient client = new QuestionAnsweringProjectsClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

### Adding a knowledge base source

To add a new knowledge source to your project, you can set up a `RequestContent` instance with the appropriate parameters and call the `UpdateSources` method. In the following example, a source of type "url" is being added to our project.

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

### Adding a qna pair

Similarily, you can use the `UpdateQnas` method to add new question and answer pairs as follows:

```C# Snippet:QuestionAnsweringProjectsClient_UpdateQnas
string question = "What is the easiest way to use azure services in my .NET project?";
string answer = "Using Microsoft's Azure SDKs";
RequestContent updateQnasRequestContent = RequestContent.Create(
    new[] {
        new {
                op = "add",
                value = new
                {
                    questions = new[]
                        {
                            question
                        },
                    answer = answer
                }
            }
    });

Operation<BinaryData> updateQnasOperation = Client.UpdateQnas(testProjectName, updateQnasRequestContent);

while (true)
{
    updateQnasOperation.UpdateStatus();
    if (updateQnasOperation.HasCompleted)
    {
        Console.WriteLine($"Update Qnas operation value: \n{updateQnasOperation.Value}");
        break;
    }

    Thread.Sleep(pollingInterval);
}

Pageable<BinaryData> qnas = Client.GetQnas(testProjectName);
```

### Updating synonyms

```C# Snippet:QuestionAnsweringProjectsClient_UpdateSynonyms
RequestContent updateSynonymsRequestContent = RequestContent.Create(
    new
    {
        value = new[] {
            new  {
                    alterations = new[]
                    {
                        "qnamaker",
                        "qna maker",
                    }
                 },
            new  {
                    alterations = new[]
                    {
                        "qna",
                        "question and answer",
                    }
                 }
        }
    });

Response updateSynonymsResponse = Client.UpdateSynonyms(testProjectName, updateSynonymsRequestContent);

// Synonyms can be retrieved as follows
Pageable<BinaryData> synonyms = Client.GetSynonyms(testProjectName);

Console.WriteLine("Synonyms: ");
foreach (BinaryData synonym in synonyms)
{
    Console.WriteLine(synonym);
}
```

### Add active learning feedback

If active learning is being used, the `AddFeedback` can be used to specify a user's feedback to a specific question as follows:

```C# Snippet:QuestionAnsweringProjectsClient_AddFeedback
RequestContent addFeedbackRequestContent = RequestContent.Create(
    new
    {
        records = new[]
        {
            new
            {
                userId = "userX",
                userQuestion = "what do you mean?",
                qnaId = 1
            }
        }
    });

Response addFeedbackResponse = Client.AddFeedback(testProjectName, addFeedbackRequestContent);
```

## Asynchronous

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

### Adding a qna pair

```C# Snippet:QuestionAnsweringProjectsClient_UpdateQnasAsync
string question = "What is the easiest way to use azure services in my .NET project?";
string answer = "Using Microsoft's Azure SDKs";
RequestContent updateQnasRequestContent = RequestContent.Create(
    new[] {
        new {
                op = "add",
                value = new
                {
                    questions = new[]
                        {
                            question
                        },
                    answer = answer
                }
            }
    });

Operation<BinaryData> updateQnasOperation = await Client.UpdateQnasAsync(testProjectName, updateQnasRequestContent);
await updateQnasOperation.WaitForCompletionAsync();

AsyncPageable<BinaryData> qnas = Client.GetQnasAsync(testProjectName);
```

### Updating synonyms

```C# Snippet:QuestionAnsweringProjectsClient_UpdateSynonymsAsync
RequestContent updateSynonymsRequestContent = RequestContent.Create(
    new
    {
        value = new[] {
            new  {
                    alterations = new[]
                    {
                        "qnamaker",
                        "qna maker",
                    }
                 },
            new  {
                    alterations = new[]
                    {
                        "qna",
                        "question and answer",
                    }
                 }
        }
    });

Response updateSynonymsResponse = await Client.UpdateSynonymsAsync(testProjectName, updateSynonymsRequestContent);

// Synonyms can be retrieved as follows
AsyncPageable<BinaryData> synonyms = Client.GetSynonymsAsync(testProjectName);

Console.WriteLine("Synonyms: ");
await foreach (BinaryData synonym in synonyms)
{
    Console.WriteLine(synonym);
}
```

### Add active learning feedback

```C# Snippet:QuestionAnsweringProjectsClient_AddFeedbackAsync
RequestContent addFeedbackRequestContent = RequestContent.Create(
    new
    {
        records = new[]
        {
            new
            {
                userId = "userX",
                userQuestion = "what do you mean?",
                qnaId = 1
            }
        }
    });

Response addFeedbackResponse = await Client.AddFeedbackAsync(testProjectName, addFeedbackRequestContent);
```
