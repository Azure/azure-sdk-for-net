using System;
using System.Linq;
using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Azure.Core;

namespace AnalyzeAsyncFromUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("VISION_KEY");

            if (endpoint == null || key == null)
            {
                Console.WriteLine("Missing environment variable 'VISION_ENDPOINT' or 'VISION_KEY'. Set them before running this sample.");
                Environment.Exit(1);
            }

            // Create an asynchronous Image Analysis client.
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));

            try
            {
                // Analyze all visual features from an image stream. This is an asynchronous call. Here we block until the result is ready.
                ImageAnalysisResult result = client.AnalyzeAsync(
                    new ImageUrl(new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg")), // imageContent: the URL of the image to analyze
                    new VisualFeatures[] { VisualFeatures.Tags }, // visualFeatures: Select one or more visual features to analyze.
                    null, // language (optional): See https://aka.ms/cv-languages for supported languages.
                    null, // genderNeutralCaption (optional): Relevant only if CAPTION or DENSE_CAPTIONS were specified above.
                    null, // smartCropsAspectRatios (optional). Relevant only if SMART_CROPS was specified above.
                    null  // modelName (optional): Always set to null when using Image Analysis with standard AI model.
                ).Result;

                PrintAnalysisResults(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // Print all analysis results to the console
        public static void PrintAnalysisResults(ImageAnalysisResult result)
        {
            Console.WriteLine("Image analysis results:");
            Console.WriteLine(" Image height = " + result.Metadata.Height);
            Console.WriteLine(" Image width = " + result.Metadata.Width);
            Console.WriteLine(" Model version = " + result.ModelVersion);

            if (result.TagsResult != null)
            {
                Console.WriteLine(" Tags:");
                foreach (DetectedTag tag in result.TagsResult.Values)
                {
                    Console.WriteLine($"   \"{tag.Name}\", Confidence {tag.Confidence:F4}");
                }
            }
        }
    }
}