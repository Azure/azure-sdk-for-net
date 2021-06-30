# Ask a question

To ask a question of a knowledgebase, you need to first create a `QuestionAnsweringClient`:

```C# Snippet:QuestionAnsweringClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:QuestionAnsweringClient_QueryKnowledgebase
KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should my Surface battery last?");

Response<KnowledgebaseAnswers> response = client.QueryKnowledgebase("FAQ", options);

foreach (KnowledgebaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```

## Asynchronous

```C# Snippet:QuestionAnsweringClient_QueryKnowledgebaseAsync
KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should my Surface battery last?");

Response<KnowledgebaseAnswers> response = await client.QueryKnowledgebaseAsync("FAQ", options);

foreach (KnowledgebaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```
