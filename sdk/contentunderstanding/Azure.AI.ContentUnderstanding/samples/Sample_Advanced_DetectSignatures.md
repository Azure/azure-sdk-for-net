# Detect signatures in a document

> **Supported service API version:** `2026-06-01-preview`

Signature detection is available when layout extraction is enabled
(`EnableLayout = true`), including with `prebuilt-layout`. Detected regions are
returned as `DocumentSignature` values in `DocumentContent.Signatures`.

This sample uses the following synthetic training acknowledgment, which contains
participant and approver signatures. The names and other details are fake data.

![Synthetic training acknowledgment with two signatures](../tests/samples/SampleFiles/sample_signature.png)

## Analyze the image and inspect signatures

Load the image into `imageData`, then submit it to `prebuilt-layout`:

```C# Snippet:ContentUnderstandingDetectSignatures
string filePath = "<path-to-image-that-contains-signatures>";
BinaryData imageData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-layout",
    imageData);

DocumentContent document = operation.Value.Contents
    .OfType<DocumentContent>()
    .First();

Console.WriteLine($"Found {document.Signatures.Count} signature(s).");
foreach (DocumentSignature signature in document.Signatures)
{
    Console.WriteLine($"Signature ID: {signature.Id}");
    Console.WriteLine($"  Role: {signature.Role?.ToString() ?? "(not available)"}");
    Console.WriteLine($"  Source: {signature.Source}");

    if (signature.Span is not null)
    {
        Console.WriteLine($"  Span: offset={signature.Span.Offset}, length={signature.Span.Length}");
        string markdownFragment = document.Markdown.Substring(
            signature.Span.Offset,
            signature.Span.Length);
        Console.WriteLine($"  Markdown: {markdownFragment}");
    }
}
```

Each `DocumentSignature` includes an identifier and a source that locates the
signature in the analyzed content. A semantic role and markdown span are also
available when the service can determine them.

## How signatures appear in markdown

In `DocumentContent.Markdown`, each detected signature appears as a Markdown
image reference:

```markdown
![John Smith](signatures/1.1)
![MB-](signatures/1.2)
```

The image alt text contains text recognized from the signature region. The link
target uses `signatures/{id}`, where `{id}` matches the corresponding
`DocumentSignature.Id`. The signature's `Span` identifies the exact offset and
length of this image reference in `DocumentContent.Markdown`, as shown in the
sample code.
