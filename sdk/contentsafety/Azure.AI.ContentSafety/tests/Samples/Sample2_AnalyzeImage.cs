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
            #region Snippet:CreateContentSafetyClient

            string endpoint = TestEnvironment.Endpoint;
            string key = TestEnvironment.Key;

            ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

            #endregion

            #region Snippet:ReadImageData

            string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Samples", "sample_data", "image.jpg");
            //string text = File.ReadAllText(datapath);
            BinaryData binaryData;
            using (FileStream stream = new FileStream(datapath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    binaryData = new BinaryData(reader.ReadBytes((int)stream.Length));
                }
            }

            ImageData image = new ImageData() { Content =  binaryData};

            #endregion

            #region Snippet:CreateRequest

            var request = new AnalyzeImageOptions(image);

            #endregion

            #region Snippet:AnalyzeText

            Response<AnalyzeImageResult> response;
            try
            {
                response = client.AnalyzeImage(request);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(String.Format("Analyze image failed: {0}", ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Analyze image error: {0}", ex.Message));
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
            #endregion
        }
    }
}
