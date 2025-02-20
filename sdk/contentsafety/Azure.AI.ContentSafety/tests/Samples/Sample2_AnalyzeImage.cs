// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
            ContentSafetyImageData image = new ContentSafetyImageData(BinaryData.FromBytes(File.ReadAllBytes(datapath)));

            var request = new AnalyzeImageOptions(image);

            Response<AnalyzeImageResult> response;
            try
            {
                response = client.AnalyzeImage(request);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine("Analyze image failed.\nStatus code: {0}, Error code: {1}, Error message: {2}", ex.Status, ex.ErrorCode, ex.Message);
                throw;
            }

            Console.WriteLine("Hate severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Hate)?.Severity ?? 0);
            Console.WriteLine("SelfHarm severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.SelfHarm)?.Severity ?? 0);
            Console.WriteLine("Sexual severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Sexual)?.Severity ?? 0);
            Console.WriteLine("Violence severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Violence)?.Severity ?? 0);

            #endregion Snippet:Azure_AI_ContentSafety_AnalyzeImage
        }
    }
}
