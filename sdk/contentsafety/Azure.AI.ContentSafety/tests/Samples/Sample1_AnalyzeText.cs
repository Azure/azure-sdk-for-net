// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.ContentSafety.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests.Samples
{
    public partial class ContentSafetySamples: SamplesBase<ContentSafetyClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AnalyzeText()
        {
            #region Snippet:CreateContentSafetyClient

            string endpoint = TestEnvironment.Endpoint;
            string key = TestEnvironment.Key;

            ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

            #endregion

            #region Snippet:ReadTextData

            string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Samples", "sample_data", "text.txt");
            string text = File.ReadAllText(datapath);

            #endregion

            #region Snippet:CreateRequest

            var request = new AnalyzeTextOptions(text);

            #endregion

            #region Snippet:AnalyzeText

            Response<AnalyzeTextResult> response;
            try
            {
                response = client.AnalyzeText(request);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(String.Format("Analyze text failed: {0}", ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Analyze text error: {0}", ex.Message));
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
