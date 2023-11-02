using System;
using System.IO;
using System.Linq;
using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Azure.Core;

namespace AnalyzeFromStream
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

            // Create a synchronous Image Analysis client.
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));

            try
            {
                // Analyze all visual features from an image stream. This is a synchronous (blocking) call.
                using (FileStream stream = new FileStream("sample.jpg", FileMode.Open))
                {
                    ImageAnalysisResult result = client.Analyze(
                        BinaryData.FromStream(stream), // imageContent: the image file loaded into memory as BinaryData
                        new VisualFeatures[] {
                                       VisualFeatures.SmartCrops,
                                       VisualFeatures.Caption,
                                       VisualFeatures.DenseCaptions,
                                       VisualFeatures.Objects,
                                       VisualFeatures.People,
                                       VisualFeatures.Read,
                                       VisualFeatures.Tags }, // visualFeatures: Select one or more visual features to analyze.
                        language: "en", // language (optional): See https://aka.ms/cv-languages for supported languages.
                        genderNeutralCaption: true, // genderNeutralCaption (optional): Relevant only if CAPTION or DENSE_CAPTIONS were specified above.
                        smartCropsAspectRatios: new float[] { 0.9f, 1.33f }, // smartCropsAspectRatios (optional). Relevant only if SMART_CROPS was specified above.
                        modelName: null); // modelName (optional): Always set to null when using Image Analysis with a standard AI model.

                    PrintAnalysisResults(result);
                }
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

            // Rest of the result printing logic...
        }
    }
}