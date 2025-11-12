# Update Knowledge Sources

This sample demonstrates how to update knowledge sources, question and answer pairs, synonyms, and add feedback for active learning for Question Answering projects. To get started, you'll need to create a Question Answering service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) for links and instructions.

To add knowledge sources, update question and answer pairs, or perform any other authoring actions for Question Answering projects, you need to first create a `QuestionAnsweringAuthoringClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:QuestionAnsweringAuthoringClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

### Adding a knowledge base source

To add a new knowledge source to your project, you can set up a `RequestContent` instance with the appropriate parameters and call the `UpdateSources` method. In the following example, a source of type "url" is being added to our project.

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSources_UpdateSample
// Set request content parameters for updating our new project's sources
string sourceUri = "{KnowledgeSourceUri}";
string testProjectName = "{ProjectName}";
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

Operation updateSourcesOperation = client.UpdateSources(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);

// Updated Knowledge Sources can be retrieved as follows
BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

Console.WriteLine($"Sources: {sources}");
```

### Adding a qna pair

Similarily, you can use the `UpdateQnas` method to add new question and answer pairs as follows:

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateQnas
string question = "{NewQuestion}";
string answer = "{NewAnswer}";
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

Operation updateQnasOperation = Client.UpdateQnas(WaitUntil.Completed, testProjectName, updateQnasRequestContent);

// QnAs can be retrieved as follows
BinaryData qnas = updateQnasOperation.GetRawResponse().Content;

Console.WriteLine($"Qnas: {qnas}");
```

### Updating synonyms

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSynonyms
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
Pageable<WordAlterations> synonyms = Client.GetSynonyms(testProjectName);

Console.WriteLine("Synonyms: ");
foreach (WordAlterations synonym in synonyms)
{
    Console.WriteLine(synonym);
}
```

### Add active learning feedback

If active learning is being used, the `AddFeedback` can be used to specify a user's feedback to a specific question as follows:

```C# Snippet:QuestionAnsweringAuthoringClient_AddFeedback
RequestContent addFeedbackRequestContent = RequestContent.Create(
    new
    {
        records = new[]
        {
            new
            {
                userId = "userX",
                userQuestion = "{Follow-up Question}",
                qnaId = 1
            }
        }
    });

Response addFeedbackResponse = Client.AddFeedback(testProjectName, addFeedbackRequestContent);
```

## Asynchronous

### Adding a knowledge base source

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSourcesAsync_UpdateSample
// Set request content parameters for updating our new project's sources
string sourceUri = "{KnowledgeSourceUri}";
string testProjectName = "{ProjectName}";
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

Operation updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);

// Updated Knowledge Sources can be retrieved as follows
BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

Console.WriteLine($"Sources: {sources}");
```

### Adding a qna pair

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateQnasAsync
string question = "{NewQuestion}";
string answer = "{NewAnswer}";
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

Operation updateQnasOperation = await Client.UpdateQnasAsync(WaitUntil.Completed, testProjectName, updateQnasRequestContent);

// QnAs can be retrieved as follows
BinaryData qnas = updateQnasOperation.GetRawResponse().Content;

Console.WriteLine($"Qnas: {qnas}");
```

### Updating synonyms

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSynonymsAsync
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
AsyncPageable<WordAlterations> synonyms = Client.GetSynonymsAsync(testProjectName);

Console.WriteLine("Synonyms: ");
await foreach (WordAlterations synonym in synonyms)
{
    Console.WriteLine(synonym);
}
```

### Add active learning feedback

```C# Snippet:QuestionAnsweringAuthoringClient_AddFeedbackAsync
RequestContent addFeedbackRequestContent = RequestContent.Create(
    new
    {
        records = new[]
        {
            new
            {
                userId = "userX",
                userQuestion = "{Follow-up question}",
                qnaId = 1
            }
        }
    });

Response addFeedbackResponse = await Client.AddFeedbackAsync(testProjectName, addFeedbackRequestContent);
```
