// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class Sample04_Objects : ImageAnalysisSampleBase
    {
        [TestCase]
        public void ImageAnalysisObjectsFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisObjectsFromFile
            // Use a file stream to pass the image data to the analyze call
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            // Detect objects in the image.
            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Objects);

            // Print object detection results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Objects:");
            foreach (DetectedObject detectedObject in result.Objects.Values)
            {
                Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box {detectedObject.BoundingBox.ToString()}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisObjectsFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisObjectsFromUrl
            // Detect objects in the image.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
                VisualFeatures.Objects);

            // Print object detection results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Objects:");
            foreach (DetectedObject detectedObject in result.Objects.Values)
            {
                Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box {detectedObject.BoundingBox.ToString()}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisObjectsException()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisObjectsException
            var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

            try
            {
                var result = client.Analyze(imageUrl, VisualFeatures.Objects);
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
