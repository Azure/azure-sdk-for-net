# Translating with a Custom Translation Model

Document Translation lets you tailor translations by using a custom translation model. You provide the model's deployment name when submitting a translation request, and the service reports the deployment name that was used on each document's status.

This sample demonstrates how to use a custom translation model deployment name for both batch and single document translation. To get started you will need a Translator endpoint and credentials. See [README][README] for links and instructions.

## Batch translation with a custom model deployment name

Set the `DeploymentName` on the `TranslationTarget` to route the translation through your custom model. After the operation completes, the returned `DocumentStatusResult` exposes the deployment name that was used.

```C# Snippet:StartTranslationWithCustomModel
Uri sourceUri = new Uri("<source SAS URI>");
Uri targetUri = new Uri("<target SAS URI>");
// Set the deployment name of your custom translation model on the target.
var input = new DocumentTranslationInput(sourceUri, targetUri, "es");
input.Targets[0].DeploymentName = "<custom translation model deployment name>";

DocumentTranslationOperation operation = client.StartTranslation(input);

TimeSpan pollingInterval = new(1000);
while (true)
{
    operation.UpdateStatus();
    if (operation.HasCompleted)
    {
        break;
    }

    if (operation.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
    {
        pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
    }
    Thread.Sleep(pollingInterval);
}

foreach (DocumentStatusResult document in operation.GetValues())
{
    Console.WriteLine($"Document with Id: {document.Id}");
    Console.WriteLine($"  Status: {document.Status}");
    if (document.Status == DocumentTranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Deployment name used: {document.DeploymentName}");
        Console.WriteLine($"  Characters charged: {document.CharactersCharged}");
    }
    else
    {
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
        Console.WriteLine($"  Error Code: {document.Error.Code}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

## Single document translation with a custom model

For synchronous single document translation, pass the custom model `deploymentName` to route the request through your custom model.

```C# Snippet:SingleDocumentTranslationWithCustomModel
try
{
    string filePath = Path.Combine("TestData", "test-input.txt");
    using Stream fileStream = File.OpenRead(filePath);
    var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");
    DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument);

    // Provide the custom model deployment name for the translation.
    Response<BinaryData> response = await client.TranslateAsync(
        "hi",
        content,
        deploymentName: "<custom translation model deployment name>").ConfigureAwait(false);

    string responseString = Encoding.UTF8.GetString(response.Value.ToArray());
    Console.WriteLine($"Response string after translation: {responseString}");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/README.md
