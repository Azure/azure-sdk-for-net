# Translating Text Within Images

Document Translation can translate text that is embedded within images in your documents. Enable this by setting `translateTextWithinImage` when you start a batch translation. When enabled, each document's `DocumentStatusResult` also reports image scan usage.

This sample demonstrates how to start a batch translation with image translation enabled. To get started you will need a Translator endpoint and credentials. See [README][README] for links and instructions.

## Batch translation with image translation enabled

Use the `translateTextWithinImage` convenience overload of `StartTranslation` to translate text embedded in images. After the operation completes, the returned `DocumentStatusResult` exposes image scan usage details.

```C# Snippet:StartTranslationWithImageTranslation
Uri sourceUri = new Uri("<source SAS URI>");
Uri targetUri = new Uri("<target SAS URI>");
var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

// Enable translation of text embedded within images for the batch.
DocumentTranslationOperation operation = client.StartTranslation(new[] { input }, translateTextWithinImage: true);

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
        Console.WriteLine($"  Characters charged: {document.CharactersCharged}");
        // Image scan usage is reported when image translation is enabled.
        Console.WriteLine($"  Total image scans succeeded: {document.TotalImageScansSucceeded}");
        Console.WriteLine($"  Total image scans failed: {document.TotalImageScansFailed}");
        Console.WriteLine($"  Images charged: {document.ImageCharged}");
        Console.WriteLine($"  Characters detected within images: {document.ImageCharacterDetected}");
    }
    else
    {
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
        Console.WriteLine($"  Error Code: {document.Error.Code}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/README.md
