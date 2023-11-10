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

            // Create an Image Analysis client.
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));

            try
            {
                // Analyze visual features from a URL. This is a synchronous call.
                ImageAnalysisResult result = client.Analyze(
                    new ImageUrl(new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg")), // imageContent: the URL of the image to analyze
                    visualFeatures: new VisualFeatures[] { VisualFeatures.Tags }, // visualFeatures: Select one or more visual features to analyze.
                    language: null, // language (optional): See https://aka.ms/cv-languages for supported languages.
                    genderNeutralCaption: null, // genderNeutralCaption (optional): Relevant only if CAPTION or DENSE_CAPTIONS were specified above.
                    smartCropsAspectRatios: null, // smartCropsAspectRatios (optional). Relevant only if SMART_CROPS was specified above.
                    modelName: null); // modelName (optional): Always set to null when using Image Analysis with standard AI model.

                PrintAnalysisResults(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
                    Console.WriteLine("   \"" + tag.Name + "\", Confidence "
                            + tag.Confidence.ToString("F4"));
                }
            }
        }
    }
}
