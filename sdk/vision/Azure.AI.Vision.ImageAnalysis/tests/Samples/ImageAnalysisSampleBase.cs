// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class ImageAnalysisSampleBase : SamplesBase<ImageAnalysisTestEnvironment>
    {
        protected ImageAnalysisClient ImageAnalysisAuth()
        {
            #region Snippet:ImageAnalysisAuth
            string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("VISION_KEY");

#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            key = TestEnvironment.CogServicesVisionKey;
#endif
            // Create an Image Analysis client.
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));
            #endregion

            return client;
        }

        protected ImageAnalysisClient ImageAnalysisEntraIDAuth()
        {
            #region Snippet:ImageAnalysisEntraIDAuth
            string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");

#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
#endif
            ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion

            return client;
        }
    }
}
