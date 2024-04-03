// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class Sample08_AllFeatures : ImageAnalysisSampleBase
    {
        [TestCase]
        public void ImageAnalysisAllFeaturesFromFile()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisAllFromFile

            // Use a file stream to pass the image data to the analyze call
            using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

            // Analyze the image with all visual features.
            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Caption |
                VisualFeatures.DenseCaptions |
                VisualFeatures.Tags |
                VisualFeatures.Objects |
                VisualFeatures.SmartCrops |
                VisualFeatures.People |
                VisualFeatures.Read
                );

            // Print the results for each visual feature
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" Caption: {result.Caption.Text}, Confidence: {result.Caption.Confidence:F4}");
            Console.WriteLine($" Dense Captions:");
            foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
            {
                Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence: {denseCaption.Confidence:F4}, Bounding box: {denseCaption.BoundingBox}");
            }
            Console.WriteLine($" Tags:");
            foreach (DetectedTag tag in result.Tags.Values)
            {
                Console.WriteLine($"   '{tag.Name}', Confidence: {tag.Confidence:F4}");
            }
            Console.WriteLine($" Objects:");
            foreach (DetectedObject detectedObject in result.Objects.Values)
            {
                Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box: {detectedObject.BoundingBox.ToString()}");
            }
            Console.WriteLine($" SmartCrops:");
            foreach (CropRegion cropRegion in result.SmartCrops.Values)
            {
                Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
            }
            Console.WriteLine($" People:");
            foreach (DetectedPerson person in result.People.Values)
            {
                Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence: {person.Confidence:F4}");
            }
            Console.WriteLine($" Read:");
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
        public void ImageAnalysisAllFeaturesFromUrl()
        {
            var client = ImageAnalysisAuth();

            #region Snippet:ImageAnalysisAllFromUrl

            // Analyze the image with all visual features.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.Caption |
                VisualFeatures.DenseCaptions |
                VisualFeatures.Tags |
                VisualFeatures.Objects |
                VisualFeatures.SmartCrops |
                VisualFeatures.People |
                VisualFeatures.Read
                );

            // Print the results for each visual feature
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
            Console.WriteLine($" Caption: {result.Caption.Text}, Confidence: {result.Caption.Confidence:F4}");
            Console.WriteLine($" Dense Captions:");
            foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
            {
                Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence: {denseCaption.Confidence:F4}, Bounding box: {denseCaption.BoundingBox}");
            }
            Console.WriteLine($" Tags:");
            foreach (DetectedTag tag in result.Tags.Values)
            {
                Console.WriteLine($"   '{tag.Name}', Confidence: {tag.Confidence:F4}");
            }
            Console.WriteLine($" Objects:");
            foreach (DetectedObject detectedObject in result.Objects.Values)
            {
                Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box: {detectedObject.BoundingBox.ToString()}");
            }
            Console.WriteLine($" SmartCrops:");
            foreach (CropRegion cropRegion in result.SmartCrops.Values)
            {
                Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
            }
            Console.WriteLine($" People:");
            foreach (DetectedPerson person in result.People.Values)
            {
                Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence: {person.Confidence:F4}");
            }
            Console.WriteLine($" Read:");
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
