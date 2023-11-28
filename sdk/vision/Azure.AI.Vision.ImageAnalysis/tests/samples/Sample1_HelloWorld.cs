// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests.Samples
{
    public partial class ImageAnalysisSamples : SamplesBase<ImageAnalysisTestEnvironment>
    {
        [Test]
        public void HelloWorld()
        {
            #region Snippet:CreateImageAnalysisClient
            // Replace the endpoint and API key with your own
            string endpointString = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
            string keyString = Environment.GetEnvironmentVariable("VISION_KEY");

#if !SNIPPET
            endpointString = TestEnvironment.Endpoint;
            keyString = TestEnvironment.CogServicesVisionKey;
#endif
            Uri endpoint = new Uri(endpointString);
            AzureKeyCredential credential = new AzureKeyCredential(keyString);

            // Create ImageAnalysisClient
            ImageAnalysisClient client = new ImageAnalysisClient(endpoint, credential);
            #endregion

            #region Snippet:GetCaptionForImage
            // Read image file content
            Uri imagePath = new Uri("https://url/to/your/image.jpg");
#if !SNIPPET
            imagePath = TestEnvironment.TestImageInputUrl;
#endif
            // Analyze the image and get caption
            var result = client.Analyze(imagePath, VisualFeatures.Caption);

            // Print the caption
            Console.WriteLine("Caption: " + result.Value.Caption.Text);
            #endregion
        }
    }
}
