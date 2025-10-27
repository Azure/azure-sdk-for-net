# Transcribe a Remote File

This sample shows how to transcribe a remote file using the `Azure.AI.Speech.Transcription` SDK.

## Create a Transcription Client

To create a Transcription Client, you will need the service endpoint and credentials of your AI Foundry resource or Speech Service resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V2025_10_15);
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
```

## Transcribe Remote File (Synchronous)

To transcribe a remote file synchronously, create a stream from url of the file and call `Transcribe` on the `TranscriptionClient` clientlet, which returns the transcribed phrases and total duration of the file

```C# Snippet:TranscribeRemoteFileSync
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
using HttpClient httpClient = new HttpClient();
using HttpResponseMessage httpResponse = httpClient.GetAsync("https://your-domain.com/your-file.mp3").Result;
using Stream stream = httpResponse.Content.ReadAsStreamAsync().Result;

var request = new TranscribeRequestContent { Audio = stream };
var response = client.Transcribe(request);

Console.WriteLine($"File Duration: {response.Value.Duration}");
foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
{
    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
}
```

## Transcribe Remote File (Asynchronous)

To transcribe a remote file ssynchronously, create a stream from url of the file and call `TranscribeAsync` on the `TranscriptionClient` clientlet, which returns the transcribed phrases and total duration of the file

```C# Snippet:TranscribeRemoteFileAsync
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
using HttpClient httpClient = new HttpClient();
using HttpResponseMessage httpResponse = await httpClient.GetAsync("https://your-domain.com/your-file.mp3");
using Stream stream = await httpResponse.Content.ReadAsStreamAsync();

var request = new TranscribeRequestContent { Audio = stream };
var response = await client.TranscribeAsync(request);

Console.WriteLine($"File Duration: {response.Value.Duration}");
foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
{
    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
}
```