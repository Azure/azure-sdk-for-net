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
        public void ImageAnalysisGenerateCaptionFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisGenerateCaptionFromFile
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { genderNeutralCaption = true });

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
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { genderNeutralCaption = true });

            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
            #endregion
        }

        [TestCase]
        public void ImageAnalysisException()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisCaptionException
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
