# List Transcriptions

This sample shows how to list transcriptions using the `Azure.AI.Speech.BatchTranscription` SDK.

## Create a Batchtranscription Client

To create a TranscriptionClient, you will need the service endpoint and credentials of your SpeechService resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
BatchTranscriptionClientOptions options = new BatchTranscriptionClientOptions(BatchTranscriptionClientOptions.ServiceVersion.V2024_11_15);
BatchTranscriptionClient client = new BatchTranscriptionClient(endpoint, credential, options);
```

## List Transcriptions

To list transcriptions, optionally set a filter expression and call `GetTranscriptions` on the `BatchTranscriptionClient` clientlet. This method returns the files of the transcription with their kind, name, and downloadlinks.

- Supported properties: displayName, description, createdDateTime, lastActionDateTime, status, locale.

- Operators:

    - `eq`, `ne` are supported for all properties.

    - `gt`, `ge`, `lt`, `le` are supported for createdDateTime and lastActionDateTime.

    - `and`, `or`, `not` are supported.

- Example:

    filter=createdDateTime gt 2022-02-01T11:00:00Z

```C# Snippet:ListTranscriptions
foreach (var transcription in client.GetTranscriptions(maxCount: 10, skip: 5, filter: "createdDateTime gt 2024-11-15T11:00:00Z"))
{
    Console.WriteLine($"{transcription.DisplayName} {transcription.Status} {transcription.Created}");
}
```