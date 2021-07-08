# Ask a follow-up question (chit-chat)

This sample demonstrates how to query an existing knowledge base. To get started, you'll need to create a Question Answering service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) for links and instructions.

To ask a follow-up question of an existing knowledge base configured for [chit-chat][questionanswering_docs_chat], you need to first create a `QuestionAnsweringClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:QuestionAnsweringClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

Once you have created a client and have a previous question-answer result, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:QuestionAnsweringClient_Chat
// Answers are ordered by their ConfidenceScore so assume the user choose the first answer below:
KnowledgebaseAnswer previousAnswer = answers.Answers.First();
KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should charging take?")
{
    Context = new KnowledgebaseAnswerRequestContext(previousAnswer.Id.Value)
};

Response<KnowledgebaseAnswers> response = client.QueryKnowledgebase("FAQ", options);

foreach (KnowledgebaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```

## Asynchronous

```C# Snippet:QuestionAnsweringClient_ChatAsync
// Answers are ordered by their ConfidenceScore so assume the user choose the first answer below:
KnowledgebaseAnswer previousAnswer = answers.Answers.First();
KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should charging take?")
{
    Context = new KnowledgebaseAnswerRequestContext(previousAnswer.Id.Value)
};

Response<KnowledgebaseAnswers> response = await client.QueryKnowledgebaseAsync("FAQ", options);

foreach (KnowledgebaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```

[questionanswering_docs_chat]: https://docs.microsoft.com/azure/cognitive-services/qnamaker/how-to/chit-chat-knowledge-base
