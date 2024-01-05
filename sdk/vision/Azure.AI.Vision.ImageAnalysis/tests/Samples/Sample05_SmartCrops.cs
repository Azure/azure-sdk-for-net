// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class Sample05_SmartCrops : ImageAnalysisSampleBase
    {
        [TestCase]
        public void ImageAnalysisGenerateSmartCropsFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisSmartCropsFromFile
            // Use a file stream to pass the image data to the analyze call
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            // Get the smart-cropped thumbnails for the image.
            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.SmartCrops);

            // Print smart-crops analysis results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" SmartCrops:");
            foreach (CropRegion cropRegion in result.SmartCrops.Values)
            {
                Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisGenerateSmartCropsFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisSmartCropsFromUrl
            // Get the smart-cropped thumbnails for the image.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
                VisualFeatures.SmartCrops);

            // Print smart-crops analysis results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" SmartCrops:");
            foreach (CropRegion cropRegion in result.SmartCrops.Values)
            {
                Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
            }
            #endregion
        }

        [TestCase]
        public void ImageAnalysisSmartCropsException()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisSmartCropsException
            var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

            try
            {
                var result = client.Analyze(imageUrl, VisualFeatures.SmartCrops);
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
