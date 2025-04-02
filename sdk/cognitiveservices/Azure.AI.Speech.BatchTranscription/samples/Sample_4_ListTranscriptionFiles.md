# List Transcription Files

This sample shows how to list transcription files using the `Azure.AI.Speech.BatchTranscription` SDK.

## Create a Batchtranscription Client

To create a TranscriptionClient, you will need the service endpoint and credentials of your SpeechService resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
BatchTranscriptionClientOptions options = new BatchTranscriptionClientOptions(BatchTranscriptionClientOptions.ServiceVersion.V2024_11_15);
BatchTranscriptionClient client = new BatchTranscriptionClient(endpoint, credential, options);
```

## List Transcription Files

To get the files of a transcription by the transcription id, optionally set a filter expression and call `GetTranscriptionFiles` on the `BatchTranscriptionClient` clientlet. This method returns the files of the transcription with their kind, name, and downloadlinks.

  - Supported properties: name, createdDateTime, kind.

  - Operators:

    - `eq`, `ne` are supported for all properties.

    - `gt`, `ge`, `lt`, `le` are supported for createdDateTime.

    - `and`, `or`, `not` are supported.

  - Example:

    filter=name eq 'myaudio.wav.json' and kind eq 'Transcription'

```C# Snippet:ListTranscriptionFiles

var response = client.GetTranscriptionFiles(id, maxCount: 10, skip: 5, filter: "createdDateTime gt 2024-11-15T11:00:00Z");

foreach (var file in filesResponse)
{
    Console.WriteLine($"{file.DisplayName} {file.Kind} {file.Links.Content}");
}
```