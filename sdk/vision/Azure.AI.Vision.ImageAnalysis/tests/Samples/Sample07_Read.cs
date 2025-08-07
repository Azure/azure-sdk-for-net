// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class Sample07_Read : ImageAnalysisSampleBase
    {
        [TestCase]
        public void ImageAnalysisReadFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisReadFromFile
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Read);

            Console.WriteLine($"Image read results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" Text:");
            foreach (var line in result.Read.Blocks.SelectMany(block => block.Lines))
            {
                Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
                foreach (DetectedTextWord word in line.Words)
                {
                    Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
                }
            }

            #endregion
        }

        [TestCase]
        public void ImageAnalysisReadFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisReadFromUrl
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.Read);

            Console.WriteLine($"Image read results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" Text:");
            foreach (var line in result.Read.Blocks.SelectMany(block => block.Lines))
            {
                Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
                foreach (DetectedTextWord word in line.Words)
                {
                    Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
                }
            }
            #endregion
        }
    }
}
