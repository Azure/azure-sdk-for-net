// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Deidentification.Tests;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Health.Deidentification.Samples
{
    public partial class Samples_DeidentificationClient : SamplesBase<DeidentificationTestEnvironment>
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void HelloWorld()
        {
            string serviceEndpoint = "https://example.api.cac001.deid.azure.com";
            TokenCredential credential = new DefaultAzureCredential();

            DeidentificationClient client = new DeidentificationClient(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );
        }
    }
}
