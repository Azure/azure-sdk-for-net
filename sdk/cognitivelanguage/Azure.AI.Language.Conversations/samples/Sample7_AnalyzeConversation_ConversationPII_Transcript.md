# Analyze a conversation

This sample demonstrates how to analyze a conversation with Conversation PII (Transcript input). To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

To analyze an utterance, you need to first create a `ConversationAnalysisClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Once you have created a client, you can prepare the input:

```C# Snippet:StartAnalyzeConversation_ConversationPII_Transcript_Input
var transciprtConversationItemOne = new TranscriptConversationItem(
   id: "1",
   participantId: "speaker",
   itn: "hi",
   maskedItn: "hi",
   text: "Hi",
   lexical: "hi");
transciprtConversationItemOne.AudioTimings.Add(new WordLevelTiming(4500000, 2800000, "hi"));

var transciprtConversationItemTwo = new TranscriptConversationItem(
   id: "2",
   participantId: "speaker",
   itn: "jane doe",
   maskedItn: "jane doe",
   text: "Jane doe",
   lexical: "jane doe");
transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(7100000, 4800000, "jane"));
transciprtConversationItemTwo.AudioTimings.Add(new WordLevelTiming(12000000, 1700000, "jane"));

var transciprtConversationItemThree = new TranscriptConversationItem(
    id: "3",
    participantId: "agent",
    itn: "hi jane what's your phone number",
    maskedItn: "hi jane what's your phone number",
    text: "Hi Jane, what's your phone number?",
    lexical: "hi jane what's your phone number");
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(7700000, 3100000, "hi"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(10900000, 5700000, "jane"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(17300000, 2600000, "what's"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(20000000, 1600000, "your"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(21700000, 1700000, "phone"));
transciprtConversationItemThree.AudioTimings.Add(new WordLevelTiming(23500000, 2300000, "number"));

var transcriptConversationItems = new List<TranscriptConversationItem>()
{
    transciprtConversationItemOne,
    transciprtConversationItemTwo,
    transciprtConversationItemThree,
};

var input = new List<TranscriptConversation>()
{
    new TranscriptConversation("1", "en", transcriptConversationItems)
};

var conversationPIITaskParameters = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, TranscriptContentType.Lexical);

var tasks = new List<AnalyzeConversationLROTask>()
{
    new AnalyzeConversationPIITask("analyze", AnalyzeConversationLROTaskKind.ConversationalPIITask, conversationPIITaskParameters),
};
```

then you can start analyzing by calling the `StartAnalyzeConversation`, and because this is a long running operation, you have to wait until it's finished by calling `WaitForCompletion` function.

## Synchronous

```C# Snippet:StartAnalyzeConversation_StartAnalayzing
var analyzeConversationOperation = client.StartAnalyzeConversation(input, tasks);
analyzeConversationOperation.WaitForCompletion();
```

## Asynchronous

```C# Snippet:StartAnalyzeConversationAsync_StartAnalayzing
var analyzeConversationOperation = await client.StartAnalyzeConversationAsync(input, tasks);
await analyzeConversationOperation.WaitForCompletionAsync();
```

You can finally print the results:

```C# Snippet:StartAnalyzeConversation_ConversationPII_Transcript_Results
var jobResults = analyzeConversationOperation.Value;
foreach (var result in jobResults.Tasks.Items)
{
    var analyzeConversationPIIResult = result as AnalyzeConversationPIIResult;

    var results = analyzeConversationPIIResult.Results;

    Console.WriteLine("Conversations:");
    foreach (var conversation in results.Conversations)
    {
        Console.WriteLine($"Conversation #:{conversation.Id}");
        Console.WriteLine("Conversation Items: ");
        foreach (var conversationItem in conversation.ConversationItems)
        {
            Console.WriteLine($"Conversation Item #:{conversationItem.Id}");

            Console.WriteLine($"Redacted Text: {conversationItem.RedactedContent.Text}");
            Console.WriteLine($"Redacted Lexical: {conversationItem.RedactedContent.Lexical}");
            Console.WriteLine($"Redacted AudioTimings: {conversationItem.RedactedContent.AudioTimings}");
            Console.WriteLine($"Redacted MaskedItn: {conversationItem.RedactedContent.MaskedItn}");

            Console.WriteLine("Entities:");
            foreach (var entity in conversationItem.Entities)
            {
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```