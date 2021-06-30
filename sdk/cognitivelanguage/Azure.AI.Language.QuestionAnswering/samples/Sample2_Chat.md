# Ask a follow-up question (chit-chat)

To ask a follow-up question of a knowledgebase configured for [chit-chat][questionanswering_docs_chat], you need to first create a `QuestionAnsweringClient`:

```C# Snippet:QuestionAnsweringClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

Once you have created a client and have a previous question-answer result, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:QuestionAnsweringClient_Chat
KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should charging take?")
{
    Context = new KnowledgebaseAnswerRequestContext(previousAnswer.Id.Value)
    {
        PreviousUserQuery = "How long should my Surface battery last?"
    }
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
KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should charging take?")
{
    Context = new KnowledgebaseAnswerRequestContext(previousAnswer.Id.Value)
    {
        PreviousUserQuery = "How long should my Surface battery last?"
    }
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
