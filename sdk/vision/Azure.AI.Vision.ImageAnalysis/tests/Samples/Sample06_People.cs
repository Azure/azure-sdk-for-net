// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class Sample06_People : ImageAnalysisSampleBase
    {
        [TestCase]
        public void ImageAnalysisPeopleFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisPeopleFromFile
            // Use a file stream to pass the image data to the analyze call
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            // Detect people in the image.
            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.People);

            // Print people detection results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" People:");
            foreach (DetectedPerson person in result.People.Values)
            {
                Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence {person.Confidence:F4}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisPeopleFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisPeopleFromUrl
            // Detect people in the image.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.People);

            // Print people detection results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" People:");
            foreach (DetectedPerson person in result.People.Values)
            {
                Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence {person.Confidence:F4}");
            }
            #endregion
        }
    }
}
