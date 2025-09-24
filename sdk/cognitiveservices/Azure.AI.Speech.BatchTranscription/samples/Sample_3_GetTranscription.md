# Get a Transcription

This sample shows how to get a transcription using the `Azure.AI.Speech.BatchTranscription` SDK.

## Create a Batchtranscription Client

To create a TranscriptionClient, you will need the service endpoint and credentials of your SpeechService resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
BatchTranscriptionClientOptions options = new BatchTranscriptionClientOptions(BatchTranscriptionClientOptions.ServiceVersion.V2024_11_15);
BatchTranscriptionClient client = new BatchTranscriptionClient(endpoint, credential, options);
```

## Get Transcription

To get a transcription by its id, call `GetTranscriptionAsync` on the `BatchTranscriptionClient` clientlet. This method returns the transcription with its current status and its contents.

```C# Snippet:GetTranscription
var response = await client.GetTranscriptionAsync(id);

if(response.Value.Status != TranscriptionStatus.Succeeded)
{
    return;
}

var filesResponse = client.GetTranscriptionFiles(response.Value.Id);
var transcriptionFileValue = filesResponse.First(v => v.Kind == FileKind.Transcription);

var fileResponse = await new HttpClient().GetAsync(transcriptionFileValue.Links.Content);
var transcriptionFileContent = JsonConvert.DeserializeObject<TranscriptionFileContent>(await fileResponse.Content.ReadAsStringAsync());

foreach (var phrase in transcriptionFileContent.RecognizedPhrases)
{
    Console.WriteLine($"{phrase.Offset}-{phrase.Offset + phrase.Duration}: {phrase.NBest.First().Display}");
}
```