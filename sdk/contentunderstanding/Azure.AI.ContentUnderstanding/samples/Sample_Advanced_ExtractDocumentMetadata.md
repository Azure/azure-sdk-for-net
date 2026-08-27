# Extract embedded document metadata

> **Supported service API version:** `2026-06-01-preview`

Content Understanding can return metadata embedded in source documents through
`AnalysisContent.Metadata`. The metadata is a string-to-string dictionary, and
only properties with extracted values are included.

The preview service enables metadata extraction for document analyzers such as
`prebuilt-layout`. Applications should enumerate the dictionary and tolerate
additional keys as support evolves.

## Extract PDF metadata

This example PDF contains an author, creation timestamp, language, title, and
one page. The service also returns its detected content type and page count.

```C# Snippet:ContentUnderstandingExtractPdfMetadata
string filePath = "<path-to-pdf-with-embedded-metadata>";
BinaryData pdfData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-layout",
    pdfData);

DocumentContent document = operation.Value.Contents
    .OfType<DocumentContent>()
    .First();

foreach (var metadata in document.Metadata.OrderBy(item => item.Key))
{
    Console.WriteLine($"{metadata.Key}: {metadata.Value}");
}

if (!document.Metadata.ContainsKey("createdAt"))
{
    Console.WriteLine("createdAt: (not returned)");
}
```

PDF metadata can include `author`, `contentType`, `createdAt`, `language`,
`pageCount`, and `title`. Each property is optional because the service only
returns values embedded in or derivable from the source document.

For the generated sample PDF, the preview service returned:

```text
author: Contoso Metadata Team
contentType: application/pdf
language: en-US
pageCount: 1
title: Contoso Metadata Extraction Sample
createdAt: (not returned)
```

## Extract DOCX metadata

DOCX files can expose additional Office document properties, including the last
person who modified the document and application-maintained content counts.

```C# Snippet:ContentUnderstandingExtractDocxMetadata
string filePath = "<path-to-docx-with-embedded-metadata>";
BinaryData docxData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-layout",
    docxData);

DocumentContent document = operation.Value.Contents
    .OfType<DocumentContent>()
    .First();

foreach (var metadata in document.Metadata.OrderBy(item => item.Key))
{
    Console.WriteLine($"{metadata.Key}: {metadata.Value}");
}
```

DOCX metadata can include `author`, `characterCount`, `contentType`, `createdAt`,
`lastModifiedAt`, `lastModifiedBy`, `pageCount`, `title`, and `wordCount`.

For the generated sample DOCX, the preview service returned all nine properties:

```text
author: Contoso Metadata Team
characterCount: 207
contentType: application/vnd.openxmlformats-officedocument.wordprocessingml.document
createdAt: 2026-07-16T19:00:00Z
lastModifiedAt: 2026-07-16T20:30:00Z
lastModifiedBy: Megan Bowen
pageCount: 1
title: Contoso Metadata Extraction Sample
wordCount: 29
```
