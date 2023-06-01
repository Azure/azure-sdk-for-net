// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests.Samples
{
    public partial class ContentSafetySamples : SamplesBase<ContentSafetyClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AnalyzeImage()
        {
            string endpoint = TestEnvironment.Endpoint;
            string key = TestEnvironment.Key;

            ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

            #region Snippet:Azure_AI_ContentSafety_AnalyzeImage

            string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Samples", "sample_data", "image.jpg");
            ImageData image = new ImageData() { Content = BinaryData.FromBytes(File.ReadAllBytes(datapath)) };

            var request = new AnalyzeImageOptions(image);

            Response<AnalyzeImageResult> response;
            try
            {
                response = client.AnalyzeImage(request);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(String.Format("Analyze image failed.\nError code: {0}, Error message: {1}", ex.ErrorCode, ex.Message));
                throw;
            }

            if (response.Value.HateResult != null)
            {
                Console.WriteLine(String.Format("Hate severity: {0}", response.Value.HateResult.Severity));
            }
            if (response.Value.SelfHarmResult != null)
            {
                Console.WriteLine(String.Format("SelfHarm severity: {0}", response.Value.SelfHarmResult.Severity));
            }
            if (response.Value.SexualResult != null)
            {
                Console.WriteLine(String.Format("Sexual severity: {0}", response.Value.SexualResult.Severity));
            }
            if (response.Value.ViolenceResult != null)
            {
                Console.WriteLine(String.Format("Violence severity: {0}", response.Value.ViolenceResult.Severity));
            }

            #endregion Snippet:Azure_AI_ContentSafety_AnalyzeImage
        }
    }
}
