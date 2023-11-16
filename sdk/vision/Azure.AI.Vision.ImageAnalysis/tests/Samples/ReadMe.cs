// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class ReadMe : SamplesBase<ImageAnalysisTestEnvironment>
    {
        public ImageAnalysisClient ImageAnalysisAuth()
        {
            #region Snippet:ImageAnalysisAuth
            string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("VISION_KEY");

#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            key = TestEnvironment.CogServicesVisionKey;
#endif
            // Create an Image Analysis client.
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));
            #endregion

            return client;
        }

        [TestCase]
        public void ImageAnalysisGenerateCaptionFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisGenerateCaptionFromFile
            // Use a file stream to pass the image data to the analyze call
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            // Get a caption for the image. This will be a synchronously (blocking) call.
            ImageAnalysisResult result = client.Analyze(
                new BinaryData(stream),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { genderNeutralCaption = true }); // Optional (default is false)

            // Print caption results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
            #endregion
        }

        [TestCase]
        public void ImageAnalysisGenerateCaptionFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisGenerateCaptionFromUrl
            // Get a caption for the image. This will be a synchronously (blocking) call.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { genderNeutralCaption = true }); // Optional (default is false)

            // Print caption results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
            #endregion
        }

        [TestCase]
        public void ImageAnalysisExtractTextFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisExtractTextFromFile
            // Load image to analyze into a stream
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            // Extract text (OCR) from an image stream. This will be a synchronously (blocking) call.
            ImageAnalysisResult result = client.Analyze(
                new BinaryData(stream),
                VisualFeatures.Read);

            // Print text (OCR) analysis results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Read:");
            Console.WriteLine($"   Model version: {result.Read.ModelVersion}");
            Console.WriteLine($"   String index type: {result.Read.StringIndexType}");
            Console.WriteLine($"   Angle: {result.Read.Pages[0].Angle}");
            Console.WriteLine($"   Content:\n{result.Read.Content}");
            // for style in result.Read.Styles:
            //    Console.WriteLine("   Style: {}".format(style)) // TODO: This was empty for me. Should be removed from JSON result?
            Console.WriteLine("   Lines:");
            foreach (DocumentLine line in result.Read.Pages[0].Lines)
            {
                string pointsString = "{" + string.Join(", ", line.BoundingBox.Select(point => point.ToString())) + "}";
                Console.WriteLine($"     Line: '{line.Content}', Bounding box {pointsString}, Span offset {line.Spans[0].Offset}, Span length {line.Spans[0].Length}");
            }
            Console.WriteLine("   Words:");
            foreach (DocumentWord word in result.Read.Pages[0].Words)
            {
                string pointsString = "{" + string.Join(", ", word.BoundingBox.Select(point => point.ToString())) + "}";
                Console.WriteLine($"     Word: '{word.Content}', Bounding box {pointsString}, Confidence {word.Confidence:F4}, Span offset {word.Span.Offset}, Span length {word.Span.Length}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisExtractTextFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisExtractTextFromUrl
            // Extract text (OCR) from an image stream. This will be a synchronously (blocking) call.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
                VisualFeatures.Read);

            // Print text (OCR) analysis results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Read:");
            Console.WriteLine($"   Model version: {result.Read.ModelVersion}");
            Console.WriteLine($"   String index type: {result.Read.StringIndexType}");
            Console.WriteLine($"   Angle: {result.Read.Pages[0].Angle}");
            Console.WriteLine($"   Content:\n{result.Read.Content}");
            // for style in result.Read.Styles:
            //    Console.WriteLine("   Style: {}".format(style)) // TODO: This was empty for me. Should be removed from JSON result?
            Console.WriteLine("   Lines:");
            foreach (DocumentLine line in result.Read.Pages[0].Lines)
            {
                string pointsString = "{" + string.Join(", ", line.BoundingBox.Select(point => point.ToString())) + "}";
                Console.WriteLine($"     Line: '{line.Content}', Bounding box {pointsString}, Span offset {line.Spans[0].Offset}, Span length {line.Spans[0].Length}");
            }
            Console.WriteLine("   Words:");
            foreach (DocumentWord word in result.Read.Pages[0].Words)
            {
                string pointsString = "{" + string.Join(", ", word.BoundingBox.Select(point => point.ToString())) + "}";
                Console.WriteLine($"     Word: '{word.Content}', Bounding box {pointsString}, Confidence {word.Confidence:F4}, Span offset {word.Span.Offset}, Span length {word.Span.Length}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisException()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisException
            var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

            try
            {
                var result = client.Analyze(imageUrl, VisualFeatures.Caption);
            }
            catch (RequestFailedException e)
            {
                if (e.Status == 400)
                {
                    Console.WriteLine("Error analyzing image.");
                    Console.WriteLine("HTTP status code 400: The request is invalid or malformed.");
                }
                else
                {
                    throw;
                }
            }
            #endregion
        }
    }
}
