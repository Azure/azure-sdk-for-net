# Analyze a document with add-on capabilities

This sample demonstrates how to analyze document with add-on capabilities, using a document as an example. For more information about add-on capabilities, see the [documentation][docint_addon].

To get started you'll need a Cognitive Services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

Add-on capabilities are available within all models except for the Business card model. This sample uses Layout model ("prebuilt-layout") to demonstrate. When analyzing a document, you can specify a list of optional [analysis features][sdk_docfeature] to enable certain add-on capabilities.

The following capabilities are free:
- Barcodes
- Languages
- KeyValuePairs

The following capabilities will incur additional charges, see [pricing][docint_pricing]:
- Formulas
- OcrHighResolution
- FontStyling

## Creating a `DocumentIntelligenceClient`

To create a new `DocumentIntelligenceClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object that, if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## High resolution extraction
To extract content from a given file at a URI with improved quality through the add-on high resolution capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.OcrHighResolution` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleHighResolutionExtraction
Uri uriSource = new Uri("<uriSource>");
var content = new AnalyzeDocumentContent()
{
    UrlSource = uriSource
};

List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>();
features.Add(DocumentAnalysisFeature.OcrHighResolution);

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
AnalyzeResult result = operation.Value;

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"Document Page {page.PageNumber} has {page.Lines.Count} line(s), {page.Words.Count} word(s)," +
        $" and {page.SelectionMarks.Count} selection mark(s).");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        DocumentLine line = page.Lines[i];

        Console.WriteLine($"  Line {i}:");
        Console.WriteLine($"    Content: '{line.Content}'");

        Console.Write("    Bounding polygon, with points ordered clockwise:");
        for (int j = 0; j < line.Polygon.Count; j += 2)
        {
            Console.Write($" ({line.Polygon[j]}, {line.Polygon[j + 1]})");
        }

        Console.WriteLine();
    }

    for (int i = 0; i < page.SelectionMarks.Count; i++)
    {
        DocumentSelectionMark selectionMark = page.SelectionMarks[i];

        Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
        Console.WriteLine($"    State: {selectionMark.State}");

        Console.Write("    Bounding polygon, with points ordered clockwise:");
        for (int j = 0; j < selectionMark.Polygon.Count; j++)
        {
            Console.Write($" ({selectionMark.Polygon[j]}, {selectionMark.Polygon[j + 1]})");
        }

        Console.WriteLine();
    }
}

for (int i = 0; i < result.Paragraphs.Count; i++)
{
    DocumentParagraph paragraph = result.Paragraphs[i];

    Console.WriteLine($"Paragraph {i}:");
    Console.WriteLine($"  Content: {paragraph.Content}");

    if (paragraph.Role != null)
    {
        Console.WriteLine($"  Role: {paragraph.Role}");
    }
}

for (int i = 0; i < result.Tables.Count; i++)
{
    DocumentTable table = result.Tables[i];

    Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

    foreach (DocumentTableCell cell in table.Cells)
    {
        Console.WriteLine($"  Cell ({cell.RowIndex}, {cell.ColumnIndex}) is a '{cell.Kind}' with content: {cell.Content}");
    }
}
```

## Formula extraction
To extract formulas from a given file at a URI with the add-on formulas capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.Formulas` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleFormulaExtraction
Uri uriSource = new Uri("<uriSource>");
var content = new AnalyzeDocumentContent()
{
    UrlSource = uriSource
};

List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>();
features.Add(DocumentAnalysisFeature.Formulas);

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
AnalyzeResult result = operation.Value;

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"----Formulas detected from page #{page.PageNumber}----");

    var inline_formulas = page.Formulas.Where(s => s.Kind == "inline").ToList();
    var display_formulas = page.Formulas.Where(s => s.Kind == "display").ToList();

    Console.WriteLine($"Detected {page.Formulas.Count()} formulas.");
    for (int i = 0; i < page.Formulas.Count(); i++)
    {
        DocumentFormula formula = page.Formulas[i];
        Console.WriteLine($"- Formula #{i}: {formula.Value}");
        Console.WriteLine($"  Kind: {formula.Kind}");
        Console.WriteLine($"  Confidence: {formula.Confidence}");
        Console.WriteLine($"  bounding polygon (points ordered clockwise):");
        for (int j = 0; j < formula.Polygon.Count; j += 2)
        {
            Console.WriteLine($"      Point {j / 2} => X: {formula.Polygon[j]}, Y: {formula.Polygon[j + 1]}");
        }
    }
}
```

## Font property extraction
To extract font information from a given file at a URI with the add-on font styling capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.FontStyling` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleFontStyling
Uri uriSource = new Uri("<uriSource>");
var content = new AnalyzeDocumentContent()
{
   UrlSource = uriSource
};

List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>();
features.Add(DocumentAnalysisFeature.StyleFont);

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
AnalyzeResult result = operation.Value;

// DocumentStyle has the following font related attributes:
var similarFontFamilies = new Dictionary<string, List<DocumentStyle>>(); // e.g., 'Arial, sans-serif
var fontStyles = new Dictionary<FontStyle, List<DocumentStyle>>(); // e.g, 'italic'
var fontWeights = new Dictionary<FontWeight, List<DocumentStyle>>(); // e.g., 'bold'
var fontColors = new Dictionary<string, List<DocumentStyle>>(); // in '#rrggbb' hexadecimal format
var fontBackgroundColors = new Dictionary<string, List<DocumentStyle>>(); // in '#rrggbb' hexadecimal format

if (result.Styles.Any(s => s.IsHandwritten != null && s.IsHandwritten.Value == true))
{
    Console.WriteLine("Document contains handwritten content");
}
else
{
    Console.WriteLine("Document does not contain handwritten content");
}

Console.WriteLine("\n----Fonts styles detected in the document----");

// Iterate over the styles and group them by their font attributes.
foreach (var style in result.Styles)
{
    if (!string.IsNullOrEmpty(style.SimilarFontFamily))
    {
        if (similarFontFamilies.ContainsKey(style.SimilarFontFamily))
        {
            similarFontFamilies[style.SimilarFontFamily].Add(style);
        }
        else
        {
            similarFontFamilies.Add(style.SimilarFontFamily, new List<DocumentStyle>() { style });
        }
    }
    if (style.FontStyle != null && style.FontStyle.HasValue)
    {
        if (fontStyles.ContainsKey(style.FontStyle.Value))
        {
            fontStyles[style.FontStyle.Value].Add(style);
        }
        else
        {
            fontStyles.Add(style.FontStyle.Value, new List<DocumentStyle>() { style });
        }
    }
    if (style.FontWeight != null && style.FontWeight.HasValue)
    {
        if (fontWeights.ContainsKey(style.FontWeight.Value))
        {
            fontWeights[style.FontWeight.Value].Add(style);
        }
        else
        {
            fontWeights.Add(style.FontWeight.Value, new List<DocumentStyle>() { style });
        }
    }
    if (!string.IsNullOrEmpty(style.Color))
    {
        if (fontColors.ContainsKey(style.Color))
        {
            fontColors[style.Color].Add(style);
        }
        else
        {
            fontColors.Add(style.Color, new List<DocumentStyle>() { style });
        }
    }
    if (!string.IsNullOrEmpty(style.BackgroundColor))
    {
        if (fontBackgroundColors.ContainsKey(style.BackgroundColor))
        {
            fontBackgroundColors[style.BackgroundColor].Add(style);
        }
        else
        {
            fontBackgroundColors.Add(style.BackgroundColor, new List<DocumentStyle>() { style });
        }
    }
}

Console.WriteLine($"Detected {similarFontFamilies.Count()} font families:");
foreach (var family in similarFontFamilies)
{
    var spans = family.Value.SelectMany(s => s.Spans).OrderBy(s => s.Offset);
    var styleContents = spans.Select(s => result.Content.Substring(s.Offset, s.Length));

    Console.WriteLine($"- Font family: '{family.Key}'");
    Console.WriteLine($"  Text: '{string.Join(",", styleContents)}'");
}

Console.WriteLine($"\nDetected {fontStyles.Count()} font styles:");
foreach (var style in fontStyles)
{
    var spans = style.Value.SelectMany(s => s.Spans).OrderBy(s => s.Offset);
    var styleContents = spans.Select(s => result.Content.Substring(s.Offset, s.Length));

    Console.WriteLine($"- Font style: '{style.Key}'");
    Console.WriteLine($"  Text: '{string.Join(",", styleContents)}'");
}

Console.WriteLine($"\nDetected {fontWeights.Count()} font weights:");
foreach (var weight in fontWeights)
{
    var spans = weight.Value.SelectMany(s => s.Spans).OrderBy(s => s.Offset);
    var styleContents = spans.Select(s => result.Content.Substring(s.Offset, s.Length));

    Console.WriteLine($"- Font weight: '{weight.Key}'");
    Console.WriteLine($"  Text: '{string.Join(",", styleContents)}'");
}

Console.WriteLine($"\nDetected {fontColors.Count()} font colors:");
foreach (var color in fontColors)
{
    var spans = color.Value.SelectMany(s => s.Spans).OrderBy(s => s.Offset);
    var styleContents = spans.Select(s => result.Content.Substring(s.Offset, s.Length));

    Console.WriteLine($"- Font color: '{color.Key}'");
    Console.WriteLine($"  Text: '{string.Join(",", styleContents)}'");
}

Console.WriteLine($"\nDetected {fontBackgroundColors.Count()} font background colors:");
foreach (var backGroundColor in fontBackgroundColors)
{
    var spans = backGroundColor.Value.SelectMany(s => s.Spans).OrderBy(s => s.Offset);
    var styleContents = spans.Select(s => result.Content.Substring(s.Offset, s.Length));

    Console.WriteLine($"- Font background color: '{backGroundColor.Key}'");
    Console.WriteLine($"  Text: '{string.Join(",", styleContents)}'");
}
```

## Barcode property extraction
To extract barcodes from a given file at a URI with the add-on barcodes capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.Barcodes` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleBarcodeExtraction
Uri uriSource = new Uri("<uriSource>");
var content = new AnalyzeDocumentContent()
{
   UrlSource = uriSource
};

List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>();
features.Add(DocumentAnalysisFeature.Barcodes);

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
AnalyzeResult result = operation.Value;

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"----Barcodes detected from page #{page.PageNumber}----");
    Console.WriteLine($"Detected {page.Barcodes.Count} barcodes:");

    for (int i = 0; i < page.Barcodes.Count; i++)
    {
        DocumentBarcode barcode = page.Barcodes[i];

        Console.WriteLine($"- Barcode #{i}: {barcode.Value}");
        Console.WriteLine($"  Kind: {barcode.Kind}");
        Console.WriteLine($"  Confidence: {barcode.Confidence}");
        Console.WriteLine($"  bounding polygon (points ordered clockwise):");

        for (int j = 0; j < barcode.Polygon.Count; j+=2)
        {
            Console.WriteLine($"      Point {j/2} => X: {barcode.Polygon[j]}, Y: {barcode.Polygon[j+1]}");
        }
    }
}
```

## Language detection
To detect languages from a given file at a URI with the add-on languages capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.Languages` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleLanguageDetection
Uri uriSource = new Uri("<uriSource>");
var content = new AnalyzeDocumentContent()
{
   UrlSource = uriSource
};

List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>();
features.Add(DocumentAnalysisFeature.Languages);

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
AnalyzeResult result = operation.Value;

Console.WriteLine("----Languages detected in the document----");
Console.WriteLine($"Detected {result.Languages.Count} languages:");

for (int i = 0; i < result.Languages.Count; i++)
{
    var lang = result.Languages[i];
    Console.WriteLine($"- Language #{i}: locale '{lang.Locale}'");
    Console.WriteLine($"  Confidence: {lang.Confidence}");

    var contents = lang.Spans.Select(s => result.Content.Substring(s.Offset, s.Length));
    Console.WriteLine($"  Text: '{string.Join(",", contents)}'");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
[docint_addon]: https://learn.microsoft.com/en-us/azure/ai-services/document-intelligence/concept-add-on-capabilities
[docint_pricing]: https://azure.microsoft.com/pricing/details/ai-document-intelligence/
[sdk_docfeature]: https://learn.microsoft.com/en-us/dotnet/api/azure.ai.documentintelligence.documentanalysisfeature
