// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class Sample01_HelloWorld : ImageAnalysisSampleBase
    {
        [TestCase]
        public void ImageAnalysisCaptionFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisCaptionFromFile
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { GenderNeutralCaption = true });

            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
            #endregion
        }

        [TestCase]
        public void ImageAnalysisCaptionFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisCaptionFromUrl
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { GenderNeutralCaption = true });

            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
            #endregion
        }
    }
}
