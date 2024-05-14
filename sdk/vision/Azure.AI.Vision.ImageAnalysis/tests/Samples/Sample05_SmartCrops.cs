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
                VisualFeatures.SmartCrops,
                new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

            // Print smart-crops analysis results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
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
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.SmartCrops,
                new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

            // Print smart-crops analysis results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" SmartCrops:");
            foreach (CropRegion cropRegion in result.SmartCrops.Values)
            {
                Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
            }
            #endregion
        }
    }
}
