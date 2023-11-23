# Extract the layout of a document

This sample demonstrates how to extract all identified barcodes using the
add-on 'Barcodes', 'Formulas', 'FontStyling', 'Languages', 'OcrHighResolution' capabilities.

Add-on capabilities are available within all models except for the Business card
model. This sample uses Layout model to demonstrate.
Add-on capabilities accept a list of strings containing values from the `DocumentAnalysisFeature`
enum class. For more information, see:
https://learn.microsoft.com/en-us/dotnet/api/azure.ai.formrecognizer.documentanalysis.documentanalysisfeature?view=azure-dotnet

The following capabilities are free:
- Barcodes
- Languages

The following capabilities will incur additional charges:
- Formulas
- OcrHighResolution
- FontStyling

See pricing: https://azure.microsoft.com/pricing/details/ai-document-intelligence/.

USAGE:

Set the environment variables with your own values before running the sample:
1) AZURE_FORM_RECOGNIZER_ENDPOINT - the endpoint to your Form Recognizer resource.
2) AZURE_FORM_RECOGNIZER_KEY - your Form Recognizer API key 

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentAnalysisClient`

To create a new `DocumentAnalysisClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentAnalysisClient
string endpoint =  Environment.GetEnvironmentVariable("AZURE_FORM_RECOGNIZER_ENDPOINT");
string apiKey = Environment.GetEnvironmentVariable("AZURE_FORM_RECOGNIZER_KEY");
var credential = new AzureKeyCredential(apiKey);
var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
```

## Extract the layout of a document from a URI

To extract the layout from a given file at a URI, use the `AnalyzeDocumentFromUri` method and pass `prebuilt-layout` as the model ID. The returned value is an `AnalyzeResult` object containing data about the submitted document.

usage: 
```C# 
    Uri fileUri = new Uri("<fileUri>");
    AnalyzeBarcodesWithUri(client, filePath); // Barcodes
    AnalyzeFormulasWithUri(client, filePath); //Formulas
    AnalyzeFontsWithUri(client, filePath); //FontStyling
    AnalyzeLanguagesWithUri(client, filePath); //Languages
    AnalyzeWithHighResolutionWithUri(client, filePath); // with HighResolution
```
- Analyze Barcodes
```C# 
public static async void AnalyzeBarcodesWithUri(DocumentAnalysisClient client, Uri fileUri, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.Barcodes);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-layout", fileUri, options);
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

            for (int j = 0; j < barcode.BoundingPolygon.Count; j++)
            {
                Console.WriteLine($"      Point {j} => X: {barcode.BoundingPolygon[j].X}, Y: {barcode.BoundingPolygon[j].Y}");
            }
        }
    }
}

/// <summary>
/// Help method for display content.
/// </summary>
protected static string GetStyledText(List<DocumentStyle> styles, string content)
{
    // Iterate over the styles and merge the spans from each style.
    var spans = styles.SelectMany(s => s.Spans).OrderBy(s => s.Index);
    List<string> styleContents = new List<string>();
    spans.ToList().ForEach(s => {
        styleContents.Add(content.Substring(s.Index, s.Length));
    });

    return string.Join(",", styleContents);
}

/// <summary>
/// Help method for display polygon.
/// </summary>
protected static string FormatPolygon(IReadOnlyList<PointF> polygon)
{
    if (polygon == null)
    {
        return string.Empty;
    }

    List<string> polygonStrings = new List<string>();
    foreach (var p in polygon)
    {
        polygonStrings.Add($"[{p.X}, {p.Y}]");
    }

    return string.Join(",", polygonStrings);
}

```

- Analyze Formulas
```C#
public static async void AnalyzeFormulasWithUri(DocumentAnalysisClient client, Uri fileUri, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.Formulas);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-layout", fileUri, options);
    AnalyzeResult result = operation.Value;

    foreach (DocumentPage page in result.Pages)
    {
        Console.WriteLine($"----Formulas detected from page #{page.PageNumber}----");

        var inline_formulas = page.Formulas.Where(s => s.Kind == "inline").ToList();
        var display_formulas = page.Formulas.Where(s => s.Kind == "display").ToList();

        Console.WriteLine($"Detected {inline_formulas.Count()} inline formulas.");
        for (int i = 0; i < inline_formulas.Count(); i++)
        {
            DocumentFormula formula = inline_formulas[i];
            Console.WriteLine($"- Inline #{i}: {formula.Value}");
            Console.WriteLine($"  Confidence: {formula.Confidence}");
            Console.WriteLine($"  bounding polygon (points ordered clockwise):");

            for (int j = 0; j < formula.BoundingPolygon.Count; j++)
            {
                Console.WriteLine($"      Point {j} => X: {formula.BoundingPolygon[j].X}, Y: {formula.BoundingPolygon[j].Y}");
            }
        }
    }
}
```

- Analyze FontStyling
```C#
public static async void AnalyzeFontsWithUri(DocumentAnalysisClient client, Uri fileUri, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.FontStyling);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-layout", fileUri, options);
    AnalyzeResult result = operation.Value;

    // DocumentStyle has the following font related attributes:
    var similarFontFamilies = new Dictionary<string, List<DocumentStyle>>(); // e.g., 'Arial, sans-serif
    var fontStyles = new Dictionary<DocumentFontStyle, List<DocumentStyle>>(); // e.g, 'italic'
    var fontWeights = new Dictionary<DocumentFontWeight, List<DocumentStyle>>(); // e.g., 'bold'
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
        Console.WriteLine($"- Font family: '{family.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(family.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontStyles.Count()} font styles:");
    foreach (var style in fontStyles)
    {
        Console.WriteLine($"- Font style: '{style.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(style.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontWeights.Count()} font weights:");
    foreach (var weight in fontWeights)
    {
        Console.WriteLine($"- Font weight: '{weight.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(weight.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontColors.Count()} font colors:");
    foreach (var color in fontColors)
    {
        Console.WriteLine($"- Font color: '{color.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(color.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontBackgroundColors.Count()} font background colors:");
    foreach (var backGroundColor in fontBackgroundColors)
    {
        Console.WriteLine($"- Font background color: '{backGroundColor.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(backGroundColor.Value, result.Content)}'");
    }

    Console.WriteLine("----------------------------------------");
}
```

-Analyze Languages
```C#
public static async void AnalyzeLanguagesWithUri(DocumentAnalysisClient client, Uri fileUri, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.Languages);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-layout", fileUri, options);
    AnalyzeResult result = operation.Value;

    Console.WriteLine("----Languages detected in the document----");
    Console.WriteLine($"Detected {result.Languages.Count} languages:");

    for (int i = 0; i < result.Languages.Count; i++)
    {
        var lang = result.Languages[i];
        Console.WriteLine($"- Language #{i}: locale '{lang.Locale}'");
        Console.WriteLine($"  Confidence: {lang.Confidence}");
        List<string> contents = new List<string>();
        foreach (var item in lang.Spans)
        {
            contents.Add(result.Content.Substring(item.Index, item.Length));
        }
        Console.WriteLine($"  Text: '{string.Join(",", contents)}'");
    }

    Console.WriteLine("----------------------------------------");
}
```
-Analyze with OcrHighResolution
```C#
public static async void AnalyzeWithHighResolutionWithUri(DocumentAnalysisClient client, Uri fileUri, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.OcrHighResolution);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-layout", fileUri, options);
    AnalyzeResult result = operation.Value;

    if (result.Styles.Any(s => s.IsHandwritten != null && s.IsHandwritten.Value == true))
    {
        Console.WriteLine("Document contains handwritten content");
    }
    else
    {
        Console.WriteLine("Document does not contain handwritten content");
    }

    foreach (DocumentPage page in result.Pages)
    {
        Console.WriteLine($"----Analyzing layout from page #{page.PageNumber}----");
        Console.WriteLine($"Page has width: {page.Width} and height: {page.Height}, measured with unit: {page.Unit}");

        for (int i = 0; i < page.Lines.Count; i++)
        {
            var line = page.Lines[i];
            var words = line.GetWords();
            Console.WriteLine($"...Line # {i} has word count {words.Count} and text '{line.Content}' within bounding polygon '{FormatPolygon(line.BoundingPolygon)}'");

            for (int j = 0; j < words.Count; j++)
            {
                Console.WriteLine($"......Word '{words[j].Content}' has a confidence of {words[j].Confidence}");
            }
        }

        for (int i = 0; i < page.SelectionMarks.Count; i++)
        {
            var selectionMark = page.SelectionMarks[i];
            Console.WriteLine($"Selection mark is '{selectionMark.State}' within bounding polygon '{FormatPolygon(selectionMark.BoundingPolygon)}' and has a confidence of {selectionMark.Confidence}");
        }
    }

    for (int i = 0; i < result.Tables.Count; i++)
    {
        var table = result.Tables[i];
        Console.WriteLine($"Table # {i} has {table.RowCount} rows and {table.ColumnCount} columns");

        foreach (var region in table.BoundingRegions)
        {
            Console.WriteLine($"Table # {i} location on page: {region.PageNumber} is {FormatPolygon(region.BoundingPolygon)}");
        }

        foreach (var cell in table.Cells)
        {
            Console.WriteLine($"...Cell[{cell.RowIndex}][{cell.ColumnIndex}] has text '{cell.Content}'");
            foreach (var region in cell.BoundingRegions)
            {
                Console.WriteLine($"...content on page {region.PageNumber} is within bounding polygon '{FormatPolygon(region.BoundingPolygon)}'");
            }
        }
    }

    Console.WriteLine("----------------------------------------");
}
```


## Extract the layout of a document from a file stream

To extract the layout from a given file at a file stream, use the `AnalyzeDocument` method and pass `prebuilt-layout` as the model ID. The returned value is an `AnalyzeResult` object containing data about the submitted document.

usage: 
```C# 
    string filePath = "<filePath>";
    AnalyzeBarcodes(client, filePath); // Barcodes
    AnalyzeFormulas(client, filePath); //Formulas
    AnalyzeFonts(client, filePath); //FontStyling
    AnalyzeLanguages(client, filePath); //Languages
    AnalyzeWithHighResolution(client, filePath); // with HighResolution
```

- Analyze Barcodes
```C# 
public static async void AnalyzeBarcodes(DocumentAnalysisClient client, string filePath, DocumentAnalysisFeature? feature= null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature??DocumentAnalysisFeature.Barcodes);

    var stream = new FileStream(filePath, FileMode.Open);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream, options);
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

            for (int j = 0; j < barcode.BoundingPolygon.Count; j++)
            {
                Console.WriteLine($"      Point {j} => X: {barcode.BoundingPolygon[j].X}, Y: {barcode.BoundingPolygon[j].Y}");
            }
        }
    }
}

/// <summary>
/// Help method for display content.
/// </summary>
protected static string GetStyledText(List<DocumentStyle> styles, string content)
{
    // Iterate over the styles and merge the spans from each style.
    var spans = styles.SelectMany(s => s.Spans).OrderBy(s => s.Index);
    List<string> styleContents = new List<string>();
    spans.ToList().ForEach(s => {
        styleContents.Add(content.Substring(s.Index, s.Length));
    });

    return string.Join(",", styleContents);
}

/// <summary>
/// Help method for display polygon.
/// </summary>
protected static string FormatPolygon(IReadOnlyList<PointF> polygon)
{
    if (polygon == null)
    {
        return string.Empty;
    }

    List<string> polygonStrings = new List<string>();
    foreach (var p in polygon)
    {
        polygonStrings.Add($"[{p.X}, {p.Y}]");
    }

    return string.Join(",", polygonStrings);
}
```

- Analyze Formulas
```C#
public static async void AnalyzeFormulas(DocumentAnalysisClient client, string filePath, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.Formulas);

    var stream = new FileStream(filePath, FileMode.Open);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream, options);
    AnalyzeResult result = operation.Value;

    foreach (DocumentPage page in result.Pages)
    {
        Console.WriteLine($"----Formulas detected from page #{page.PageNumber}----");

        var inline_formulas = page.Formulas.Where(s=>s.Kind== "inline").ToList();
        var display_formulas = page.Formulas.Where(s => s.Kind == "display").ToList();

        Console.WriteLine($"Detected {inline_formulas.Count()} inline formulas.");
        for (int i = 0; i < inline_formulas.Count(); i++)
        {
            DocumentFormula formula = inline_formulas[i];
            Console.WriteLine($"- Inline #{i}: {formula.Value}");
            Console.WriteLine($"  Confidence: {formula.Confidence}");
            Console.WriteLine($"  bounding polygon (points ordered clockwise):");

            for (int j = 0; j < formula.BoundingPolygon.Count; j++)
            {
                Console.WriteLine($"      Point {j} => X: {formula.BoundingPolygon[j].X}, Y: {formula.BoundingPolygon[j].Y}");
            }
        }
    }
}

```

- Analyze FontStyling
```C#
public static async void AnalyzeFonts(DocumentAnalysisClient client, string filePath, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.FontStyling);

    var stream = new FileStream(filePath, FileMode.Open);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream, options);
    AnalyzeResult result = operation.Value;

    // DocumentStyle has the following font related attributes:
    var similarFontFamilies = new Dictionary<string, List<DocumentStyle>>(); // e.g., 'Arial, sans-serif
    var fontStyles = new Dictionary<DocumentFontStyle, List<DocumentStyle>>(); // e.g, 'italic'
    var fontWeights = new Dictionary<DocumentFontWeight, List<DocumentStyle>>(); // e.g., 'bold'
    var fontColors = new Dictionary<string, List<DocumentStyle>>(); // in '#rrggbb' hexadecimal format
    var fontBackgroundColors = new Dictionary<string, List<DocumentStyle>>(); // in '#rrggbb' hexadecimal format

    if (result.Styles.Any(s=>s.IsHandwritten!=null&&s.IsHandwritten.Value==true))
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
        if(!string.IsNullOrEmpty(style.SimilarFontFamily))
        {
            if(similarFontFamilies.ContainsKey(style.SimilarFontFamily))
            {
                similarFontFamilies[style.SimilarFontFamily].Add(style);
            }
            else
            {
                similarFontFamilies.Add(style.SimilarFontFamily, new List<DocumentStyle>() { style });
            }
        }
        if (style.FontStyle!=null && style.FontStyle.HasValue)
        {
            if(fontStyles.ContainsKey(style.FontStyle.Value))
            {
                fontStyles[style.FontStyle.Value].Add(style);
            }
            else
            {
                fontStyles.Add(style.FontStyle.Value, new List<DocumentStyle>() { style });
            }
        }
        if(style.FontWeight != null && style.FontWeight.HasValue)
        {
            if(fontWeights.ContainsKey(style.FontWeight.Value))
            {
                fontWeights[style.FontWeight.Value].Add(style);
            }
            else
            {
                fontWeights.Add(style.FontWeight.Value, new List<DocumentStyle>() { style });
            }
        }
        if(!string.IsNullOrEmpty(style.Color))
        {
            if(fontColors.ContainsKey(style.Color))
            {
                fontColors[style.Color].Add(style);
            }
            else
            {
                fontColors.Add(style.Color, new List<DocumentStyle>() { style});
            }
        }
        if(!string.IsNullOrEmpty(style.BackgroundColor))
        {
            if(fontBackgroundColors.ContainsKey(style.BackgroundColor))
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
        Console.WriteLine($"- Font family: '{family.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(family.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontStyles.Count()} font styles:");
    foreach (var style in fontStyles)
    {
        Console.WriteLine($"- Font style: '{style.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(style.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontWeights.Count()} font weights:");
    foreach (var weight in fontWeights)
    {
        Console.WriteLine($"- Font weight: '{weight.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(weight.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontColors.Count()} font colors:");
    foreach (var color in fontColors)
    {
        Console.WriteLine($"- Font color: '{color.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(color.Value, result.Content)}'");
    }

    Console.WriteLine($"\nDetected {fontBackgroundColors.Count()} font background colors:");
    foreach (var backGroundColor in fontBackgroundColors)
    {
        Console.WriteLine($"- Font background color: '{backGroundColor.Key}'");
        Console.WriteLine($"  Text: '{GetStyledText(backGroundColor.Value, result.Content)}'");
    }

    Console.WriteLine("----------------------------------------");
}
```

-Analyze Languages
```C#
public static async void AnalyzeLanguages(DocumentAnalysisClient client, string filePath, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.Languages);

    var stream = new FileStream(filePath, FileMode.Open);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream, options);
    AnalyzeResult result = operation.Value;

    Console.WriteLine("----Languages detected in the document----");
    Console.WriteLine($"Detected {result.Languages.Count} languages:");

    for (int i = 0; i < result.Languages.Count; i++)
    {
        var lang = result.Languages[i];
        Console.WriteLine($"- Language #{i}: locale '{lang.Locale}'");
        Console.WriteLine($"  Confidence: {lang.Confidence}");
        List<string> contents = new List<string>();
        foreach (var item in lang.Spans)
        {
            contents.Add(result.Content.Substring(item.Index, item.Length));
        }
        Console.WriteLine($"  Text: '{string.Join(",", contents)}'");
    }

    Console.WriteLine("----------------------------------------");
}
```
-Analyze with OcrHighResolution
```C#
public static async void AnalyzeWithHighResolution(DocumentAnalysisClient client, string filePath, DocumentAnalysisFeature? feature = null)
{
    AnalyzeDocumentOptions options = new AnalyzeDocumentOptions();
    options.Features.Add(feature ?? DocumentAnalysisFeature.OcrHighResolution);

    var stream = new FileStream(filePath, FileMode.Open);

    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", stream, options);
    AnalyzeResult result = operation.Value;

    if (result.Styles.Any(s => s.IsHandwritten != null && s.IsHandwritten.Value == true))
    {
        Console.WriteLine("Document contains handwritten content");
    }
    else
    {
        Console.WriteLine("Document does not contain handwritten content");
    }

    foreach (DocumentPage page in result.Pages)
    {
        Console.WriteLine($"----Analyzing layout from page #{page.PageNumber}----");
        Console.WriteLine($"Page has width: {page.Width} and height: {page.Height}, measured with unit: {page.Unit}");

        for (int i = 0; i < page.Lines.Count; i++)
        {
            var line = page.Lines[i];
            var words = line.GetWords();
            Console.WriteLine($"...Line # {i} has word count {words.Count} and text '{line.Content}' within bounding polygon '{FormatPolygon(line.BoundingPolygon)}'");

            for (int j = 0; j < words.Count; j++)
            {
                Console.WriteLine($"......Word '{words[j].Content}' has a confidence of {words[j].Confidence}");
            }
        }

        for (int i = 0; i < page.SelectionMarks.Count; i++)
        {
            var selectionMark = page.SelectionMarks[i];
            Console.WriteLine($"Selection mark is '{selectionMark.State}' within bounding polygon '{FormatPolygon(selectionMark.BoundingPolygon)}' and has a confidence of {selectionMark.Confidence}");
        }
    }

    for (int i = 0; i < result.Tables.Count; i++)
    {
        var table = result.Tables[i];
        Console.WriteLine($"Table # {i} has {table.RowCount} rows and {table.ColumnCount} columns");

        foreach (var region in table.BoundingRegions)
        {
            Console.WriteLine($"Table # {i} location on page: {region.PageNumber} is {FormatPolygon(region.BoundingPolygon)}");
        }

        foreach (var cell in table.Cells)
        {
            Console.WriteLine($"...Cell[{cell.RowIndex}][{cell.ColumnIndex}] has text '{cell.Content}'");
            foreach (var region in cell.BoundingRegions)
            {
                Console.WriteLine($"...content on page {region.PageNumber} is within bounding polygon '{FormatPolygon(region.BoundingPolygon)}'");
            }
        }
    }

    Console.WriteLine("----------------------------------------");
}

```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[document_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzePrebuiltDocument.md
