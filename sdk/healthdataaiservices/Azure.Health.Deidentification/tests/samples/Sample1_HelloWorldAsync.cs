// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Deidentification.Tests;
using NUnit.Framework;

namespace Azure.Health.Deidentification.Samples
{
    public partial class Samples_DeidentificationClient : SamplesBase<DeidentificationTestEnvironment>
    {
        [Test]
        public async Task HelloWorldAsync()
        {
            string serviceEndpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            #region Snippet:AzHealthDeidSample1Async_HelloWorld
            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );
            #endregion

            #region Snippet:AzHealthDeidSample1Async_CreateRequest
            DeidentificationContent content = new("Hello, John!");

            Response<DeidentificationResult> result = await client.DeidentifyTextAsync(content);
            string outputString = result.Value.OutputText;
            Console.WriteLine(outputString); // Hello, Tom!
            #endregion
        }
    }
}
