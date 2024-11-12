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
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
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
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.Objects);

            // Print object detection results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" Objects:");
            foreach (DetectedObject detectedObject in result.Objects.Values)
            {
                Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box {detectedObject.BoundingBox.ToString()}");
            }
            #endregion
        }
    }
}
