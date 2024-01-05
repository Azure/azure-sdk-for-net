// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class Sample03_Tags : ImageAnalysisSampleBase
    {
        [TestCase]
        public void ImageAnalysisTagsFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisTagsFromFile
            // Use a file stream to pass the image data to the analyze call
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            // Get the tags for the image.
            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Tags);

            // Print tags results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Tags:");
            foreach (DetectedTag tag in result.Tags.Values)
            {
                Console.WriteLine($"   '{tag.Name}', Confidence {tag.Confidence:F4}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisTagsFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisTagsFromUrl
            // Get the tags for the image.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
                VisualFeatures.Tags);

            // Print tags results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Tags:");
            foreach (DetectedTag tag in result.Tags.Values)
            {
                Console.WriteLine($"   '{tag.Name}', Confidence {tag.Confidence:F4}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisTagsException()
        {
            var client = ImageAnalysisAuth();
            #region Snippet:ImageAnalysisTagsException
            var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

            try
            {
                var result = client.Analyze(imageUrl, VisualFeatures.DenseCaptions);
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
