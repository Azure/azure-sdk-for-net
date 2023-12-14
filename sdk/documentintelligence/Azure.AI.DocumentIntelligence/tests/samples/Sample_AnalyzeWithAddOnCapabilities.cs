// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.DocumentIntelligence.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task AnalyzeWithFormulaExtraction()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceSampleFormulaExtraction
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>
            {
                DocumentAnalysisFeature.Formulas
            };

            var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
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

            #endregion
        }

        [RecordedTest]
        public async Task AnalyzeWithFontStyling()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceSampleFontStyling
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>
            {
                DocumentAnalysisFeature.StyleFont
            };

            var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
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
            var fontStyles = new Dictionary<FontStyle, List<DocumentStyle>>(); // e.g, 'italic'
            var fontWeights = new Dictionary<FontWeight, List<DocumentStyle>>(); // e.g., 'bold'
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

            #endregion
        }

        [RecordedTest]
        public async Task AnalyzeWithBarcodeExtraction()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceSampleBarcodeExtraction
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>
            {
                DocumentAnalysisFeature.Barcodes
            };

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

                    for (int j = 0; j < barcode.Polygon.Count; j += 2)
                    {
                        Console.WriteLine($"      Point {j / 2} => X: {barcode.Polygon[j]}, Y: {barcode.Polygon[j + 1]}");
                    }
                }
            }

            #endregion
        }

        [RecordedTest]
        public async Task AnalyzeWithLanguageDetection()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceSampleLanguageDetection
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>
            {
                DocumentAnalysisFeature.Languages
            };

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

            #endregion
        }

        [RecordedTest]
        public async Task AnalyzeWithKeyValuePairs()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceSampleKeyValuePairsExtraction
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            List<DocumentAnalysisFeature> features = new List<DocumentAnalysisFeature>
            {
                DocumentAnalysisFeature.KeyValuePairs
            };

            var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content, features: features);
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

            #endregion
        }
    }
}
