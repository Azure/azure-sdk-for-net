using System;
using System.IO;
using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Azure.Core;

namespace AnalyzeFromStreamUsingCustomModel
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = Environment.GetEnvironmentVariable("CUSTOM_VISION_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("CUSTOM_VISION_KEY");
            string modelName = Environment.GetEnvironmentVariable("CUSTOM_MODEL_NAME");

            if (endpoint == null || key == null || modelName == null)
            {
                Console.WriteLine("Missing environment variable 'CUSTOM_VISION_ENDPOINT', 'CUSTOM_VISION_KEY', or 'CUSTOM_MODEL_NAME'. Set them before running this sample.");
                Environment.Exit(1);
            }

            // Create a synchronous Image Analysis client.
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));

            try
            {
                // Analyze all visual features from an image stream. This is a synchronous (blocking) call.
                using FileStream stream = File.OpenRead("sample.jpg");
                ImageAnalysisResult result = client.AnalyzeAsync(
                    BinaryData.FromStream(stream), // imageContent: the image file loaded into memory as BinaryData
                    null, // visualFeatures
                    null, // language
                    null, // genderNeutralCaption
                    null, // smartCropsAspectRatios
                    modelName) // Always set to null when using Image Analysis with standard AI model.
                    .Result;

                PrintAnalysisResults(result, modelName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // Print all analysis results to the console
        public static void PrintAnalysisResults(ImageAnalysisResult result, string modelName)
        {
            Console.WriteLine($"Image analysis results, using custom model {modelName}");
            Console.WriteLine($" Image height = {result.Metadata.Height}");
            Console.WriteLine($" Image width = {result.Metadata.Width}");
            Console.WriteLine($" Model version = {result.ModelVersion}");

            if (result.CustomModelResult.ObjectsResult != null)
            {
                Console.WriteLine(" Custom objects:");
                foreach (DetectedObject detectedObject in result.CustomModelResult.ObjectsResult.Values)
                {
                    Console.WriteLine($"   \"{detectedObject.Tags[0].Name}\", Bounding box {detectedObject.BoundingBox}, Confidence {detectedObject.Tags[0].Confidence:F4}");
                }
            }

            if (result.CustomModelResult.TagsResult != null)
            {
                Console.WriteLine(" Custom tags:");
                foreach (DetectedTag tag in result.CustomModelResult.TagsResult.Values)
                {
                    Console.WriteLine($"   \"{tag.Name}\", Confidence {tag.Confidence:F4}");
                }
            }
        }
    }
}