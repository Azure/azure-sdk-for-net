using System;
using System.IO;
using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Azure.Core;

namespace SegmentFromUrl
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
                Response<BinaryData> result = client.Segment(
                    SegmentationMode.BackgroundRemoval, // mode: the segmentation mode to use (that or SegmentationMode.ForegroundMatting)
                    new ImageUrl(new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"))); // imageContent: the URL of the image to analyze

                // Write output PNG image to file
                string outputImageFile = "output.png";
                try
                {
                    File.WriteAllBytes(outputImageFile, result.Value.ToArray());
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Error writing to file " + outputImageFile + ": " + e.Message);
                }

                Console.WriteLine("Image segmentation result:");
                Console.WriteLine(" Size of resulting image = " + result.Value.ToMemory().Length + " bytes.");
                Console.WriteLine(" File " + outputImageFile + " written to disk.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}