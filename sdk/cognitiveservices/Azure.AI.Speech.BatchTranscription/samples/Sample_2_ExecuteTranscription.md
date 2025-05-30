# Execute a Transcription

This sample shows how to execute a transcription, wait for its result and display it using the `Azure.AI.Speech.BatchTranscription` SDK.

## Create a Batchtranscription Client

To create a BatchTranscriptionClient, you will need the service endpoint and credentials of your SpeechService resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
BatchTranscriptionClientOptions options = new BatchTranscriptionClientOptions(BatchTranscriptionClientOptions.ServiceVersion.V2024_11_15);
BatchTranscriptionClient client = new BatchTranscriptionClient(endpoint, credential, options);
```

## Start Transcription, Wait for and Display Result

To start a transcription with URLs and wait for completion, create a `TranscriptionJob` request, add the URLs to the request content and call `TranscribeAsync` on the `BatchTranscriptionClient` clientlet with the `WaitUntil.Completed` parameter. This method returns the TranscriptionJob as soon as it reaches the specified status.

```C# Snippet:ExecuteTranscription
var transcriptionProperties = new TranscriptionProperties(timeToLiveHours: 48);
var request = new TranscriptionJob(transcriptionProperties, "en-US", "displayName")
request.Contents.Add(new Uri(fileUrl0));
request.Contents.Add(new Uri(fileUrl1));

var response = await client.TranscribeAsync(request, WaitUntil.Completed);

var filesResponse = client.GetTranscriptionFiles(response.Value.Id);
var transcriptionFileValue = filesResponse.First(v => v.Kind == FileKind.Transcription);

var fileResponse = await new HttpClient().GetAsync(transcriptionFileValue.Links.Content);
var transcriptionFileContent = JsonConvert.DeserializeObject<TranscriptionFileContent>(await fileResponse.Content.ReadAsStringAsync());

foreach (var phrase in transcriptionFileContent.RecognizedPhrases)
{
    Console.WriteLine($"{phrase.Offset}-{phrase.Offset + phrase.Duration}: {phrase.NBest.First().Display}");
}
```