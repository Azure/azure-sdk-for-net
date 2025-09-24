# Start a Transcription

This sample shows how to start a transcription using the `Azure.AI.Speech.BatchTranscription` SDK.

## Create a Batchtranscription Client

To create a BatchTranscriptionClient, you will need the service endpoint and credentials of your SpeechService resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
BatchTranscriptionClientOptions options = new BatchTranscriptionClientOptions(BatchTranscriptionClientOptions.ServiceVersion.V2024_11_15);
BatchTranscriptionClient client = new BatchTranscriptionClient(endpoint, credential, options);
```

## Start Transcription with URLs (Synchronous)

To start a transcription with URLs synchonously, create a `TranscriptionJob` request, add the URLs to the request content and call `StartTranscription` on the `BatchTranscriptionClient` clientlet. This method return the scheduled TranscriptionJob with its id and current status.

```C# Snippet:StartTranscriptionWithUrls
var transcriptionProperties = new TranscriptionProperties(timeToLiveHours: 48);
var request = new TranscriptionJob(transcriptionProperties, "en-US", "displayName")
request.Contents.Add(new Uri(fileUrl0));
request.Contents.Add(new Uri(fileUrl1));

var response = client.StartTranscription(request);

Console.Log($"TranscriptionJobId: {response.Value.Id} Status: {response.Value.Status}")
```

## Start Transcription with URLs (Asynchronous)

To start a transcription with URLs asynchonously, create a `TranscriptionJob` request, add the URLs to the request content and call `StartTranscriptionAsync` on the `BatchTranscriptionClient` clientlet. This method return the scheduled TranscriptionJob with its id and current status.

```C# Snippet:StartTranscriptionWithUrlsAsync
var transcriptionProperties = new TranscriptionProperties(timeToLiveHours: 48);
var request = new TranscriptionJob(transcriptionProperties, "en-US", "displayName")
request.Contents.Add(new Uri(fileUrl0));
request.Contents.Add(new Uri(fileUrl1));

var response = await client.StartTranscriptionAsync(request);

Console.Log($"TranscriptionJobId: {response.Value.Id} Status: {response.Value.Status}")
```

## Start Transcription with Blob Container (Synchronous)

To start a transcription with URLs synchonously, create a `TranscriptionJob` request, specify the SourceContainer and call `StartTranscription` on the `BatchTranscriptionClient` clientlet. This method return the scheduled TranscriptionJob with its id and current status.

```C# Snippet:StartTranscriptionWithBlob
var transcriptionProperties = new TranscriptionProperties(timeToLiveHours: 48);
var request = new TranscriptionJob(transcriptionProperties, "en-US", "displayName")
request.SourceContainer = new Uri("https://youraccount.blob.core.windows.net");

var response = client.StartTranscription(request);

Console.Log($"TranscriptionJobId: {response.Value.Id} Status: {response.Value.Status}")
```

## Start Transcription with Blob Container (Asynchronous)

To start a transcription with URLs asynchonously, create a `TranscriptionJob` request, specify the SourceContainer and call `StartTranscriptionAsync` on the `BatchTranscriptionClient` clientlet. This method return the scheduled TranscriptionJob with its id and current status.

```C# Snippet:StartTranscriptionWithBlobAsync
var transcriptionProperties = new TranscriptionProperties(timeToLiveHours: 48);
var request = new TranscriptionJob(transcriptionProperties, "en-US", "displayName")
request.SourceContainer = new Uri("https://youraccount.blob.core.windows.net");

var response = await client.StartTranscriptionAsync(request);

Console.Log($"TranscriptionJobId: {response.Value.Id} Status: {response.Value.Status}")
```