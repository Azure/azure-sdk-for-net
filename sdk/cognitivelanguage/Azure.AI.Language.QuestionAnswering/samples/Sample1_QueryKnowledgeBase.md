# Ask a question

This sample demonstrates how to query an existing knowledge base. To get started, you'll need to create a Question Answering service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) for links and instructions.

To ask a question of an existing knowledge base, you need to first create a `QuestionAnsweringClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:QuestionAnsweringClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:QuestionAnsweringClient_QueryKnowledgeBase
QueryKnowledgeBaseOptions options = new QueryKnowledgeBaseOptions("How long should my Surface battery last?");

Response<KnowledgeBaseAnswers> response = client.QueryKnowledgeBase("FAQ", options);

foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```

## Asynchronous

```C# Snippet:QuestionAnsweringClient_QueryKnowledgeBaseAsync
string projectName = "FAQ";
QueryKnowledgeBaseOptions options = new QueryKnowledgeBaseOptions("How long should my Surface battery last?");

Response<KnowledgeBaseAnswers> response = await client.QueryKnowledgeBaseAsync(projectName, options);

foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```
