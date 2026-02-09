# Analyze a document with add-on capabilities

This sample demonstrates how to analyze a document with add-on capabilities. For more information about the supported features, see the [service documentation][docint_addon].

To get started you'll need an Azure AI services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

When analyzing a document, you can specify a list of optional [analysis features][sdk_docfeature] to enable certain add-on capabilities. Some of the capabilities are free, while others incur additional charges, see [pricing][docint_pricing] for more information.

## Creating a `DocumentIntelligenceClient`

To create a new `DocumentIntelligenceClient` you need the endpoint and credentials from your resource. In the sample below you'll make use of identity-based authentication by creating a `DefaultAzureCredential` object.

You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new DocumentIntelligenceClient(new Uri(endpoint), credential);
```

## High resolution extraction
To extract content from a given file at a URI with improved quality through the add-on high resolution capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.OcrHighResolution` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

## Formula extraction
To extract formulas from a given file at a URI with the add-on formulas capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.Formulas` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleFormulaExtraction
Uri uriSource = new Uri("<uriSource>");

var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource)
{
    Features = { DocumentAnalysisFeature.Formulas }
};

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
AnalyzeResult result = operation.Value;

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"----Formulas detected from page #{page.PageNumber}----");

    Console.WriteLine($"Detected {page.Formulas.Count} formulas.");
    for (int i = 0; i < page.Formulas.Count; i++)
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

var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource)
{
    Features = { DocumentAnalysisFeature.FontStyling }
};

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
AnalyzeResult result = operation.Value;

// Handwritten styles
var handwrittenSpans = result.Styles
    .Where(s => s.IsHandwritten != null && s.IsHandwritten.Value)
    .SelectMany(s => s.Spans).OrderBy(s => s.Offset);
if (handwrittenSpans.Any())
{
    Console.WriteLine("----Handwritten content----");
    var handwrittenContents = handwrittenSpans.Select(s => result.Content.Substring(s.Offset, s.Length));
    Console.WriteLine(string.Join(",", handwrittenContents));
}
else
{
    Console.WriteLine("No handwritten content was detected.");
}

// DocumentStyle has the following font related attributes:
var similarFontFamilies = new Dictionary<string, List<DocumentStyle>>(); // e.g., 'Arial, sans-serif
var fontStyles = new Dictionary<DocumentFontStyle, List<DocumentStyle>>(); // e.g, 'italic'
var fontWeights = new Dictionary<DocumentFontWeight, List<DocumentStyle>>(); // e.g., 'bold'
var fontColors = new Dictionary<string, List<DocumentStyle>>(); // in '#rrggbb' hexadecimal format
var fontBackgroundColors = new Dictionary<string, List<DocumentStyle>>(); // in '#rrggbb' hexadecimal format

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
    if (style.FontStyle != null)
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
    if (style.FontWeight != null)
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

var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource)
{
    Features = { DocumentAnalysisFeature.Barcodes }
};

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
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

        for (int j = 0; j < barcode.Polygon.Count; j += 2)
        {
            Console.WriteLine($"      Point {j / 2} => X: {barcode.Polygon[j]}, Y: {barcode.Polygon[j + 1]}");
        }
    }
}
```

## Language detection
To detect languages from a given file at a URI with the add-on languages capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.Languages` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleLanguageDetection
Uri uriSource = new Uri("<uriSource>");

var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource)
{
    Features = { DocumentAnalysisFeature.Languages }
};

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
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

## Key-value pairs extraction
To extract key-value pairs from a given file at a URI with the add-on keyValuePairs capability, use the `AnalyzeDocumentAsync` method and specify `DocumentAnalysisFeature.KeyValuePairs` as the analysis features. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceSampleKeyValuePairsExtraction
Uri uriSource = new Uri("<uriSource>");

var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource)
{
    Features = { DocumentAnalysisFeature.KeyValuePairs }
};

var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
AnalyzeResult result = operation.Value;

Console.WriteLine("----Key Value Pair Options detected in the document----");
Console.WriteLine($"Detected {result.KeyValuePairs.Count} Key Value Pairs:");

for (int i = 0; i < result.KeyValuePairs.Count; i++)
{
    var kvp = result.KeyValuePairs[i];

    Console.WriteLine($"- Key Value Pair #{i}: Key '{kvp.Key}'");
    Console.WriteLine($"  Value: {kvp.Value}");
    Console.WriteLine($"  Confidence: {kvp.Confidence}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
[docint_addon]: https://learn.microsoft.com/azure/ai-services/document-intelligence/concept-add-on-capabilities
[docint_pricing]: https://azure.microsoft.com/pricing/details/ai-document-intelligence/
[sdk_docfeature]: https://learn.microsoft.com/dotnet/api/azure.ai.documentintelligence.documentanalysisfeature
