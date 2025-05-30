# Delete a Transcription

This sample shows how to delete a transcription using the `Azure.AI.Speech.BatchTranscription` SDK.

## Create a Batchtranscription Client

To create a TranscriptionClient, you will need the service endpoint and credentials of your SpeechService resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
BatchTranscriptionClientOptions options = new BatchTranscriptionClientOptions(BatchTranscriptionClientOptions.ServiceVersion.V2024_11_15);
BatchTranscriptionClient client = new BatchTranscriptionClient(endpoint, credential, options);
```


## Delete Transcription

To delete a transcription by its id, call `DeleteTranscriptionAsync` on the `BatchTranscriptionClient` clientlet. This method returns an empty response with a status code.

```C# Snippet:DeleteTranscription
var response = await client.DeleteTranscriptionAsync(response.Id);
Console.WriteLine($"StatusCode: {response.Status}");
```