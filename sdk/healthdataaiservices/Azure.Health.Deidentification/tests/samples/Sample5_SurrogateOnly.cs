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
        [Test]
        public void SurrogateOnly()
        {
            string serviceEndpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );

            #region Snippet:AzHealthDeidSample5_SurrogateOnly
            DeidentificationContent content = new("Hello, John!");
            content.OperationType = DeidentificationOperationType.SurrogateOnly;
            content.TaggedEntities = new TaggedPhiEntities(
                new SimplePhiEntity[]
                {
                    new SimplePhiEntity(PhiCategory.Patient, 7, 4)
                });

            Response<DeidentificationResult> result = client.DeidentifyText(content);
            string outputString = result.Value.OutputText;
            Console.WriteLine(outputString); // Hello, Tom!
            #endregion
        }
    }
}
