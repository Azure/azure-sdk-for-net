// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Deidentification.Tests;
using NUnit.Framework;

namespace Azure.Health.Deidentification.Samples
{
    public partial class Samples_DeidentificationClient : SamplesBase<DeidentificationTestEnvironment>
    {
        private static void DemonstrateCredential()
        {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            #region Snippet:AzHealthDeidSample1_DemonstrateCredential
            const string serviceEndpoint = "https://example.api.cac001.deid.azure.com";
            TokenCredential credential = new DefaultAzureCredential();
            #endregion
#pragma warning restore CS0219 // Variable is assigned but its value is never used
        }

        [Test]
        public void HelloWorld()
        {
            string serviceEndpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            #region Snippet:AzHealthDeidSample1_HelloWorld
            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );
            #endregion

            #region Snippet:AzHealthDeidSample1_CreateRequest
            DeidentificationContent content = new("Hello, John!");

            Response<DeidentificationResult> result = client.DeidentifyText(content);
            string outputString = result.Value.OutputText;
            Console.WriteLine(outputString); // Hello, Tom!
            #endregion
        }
    }
}
