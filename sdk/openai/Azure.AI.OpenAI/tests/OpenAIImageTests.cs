// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAIImageTests : OpenAITestBase
    {
        public OpenAIImageTests(bool isAsync)
            : base(Scenario.ImageGenerations, isAsync)//, RecordedTestMode.Live)
        {
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task CanGenerateImages(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentName = GetDeploymentOrModelName(serviceTarget);

            const string prompt = "a simplistic picture of a cyberpunk money dreaming of electric bananas";
            var requestOptions = new ImageGenerationOptions()
            {
                DeploymentName = deploymentName,
                Prompt = prompt,
                ImageCount = 1,
                User = "placeholder",
            };
            Assert.That(requestOptions, Is.InstanceOf<ImageGenerationOptions>());

            Response<ImageGenerations> imagesResponse = await client.GetImageGenerationsAsync(requestOptions);

            Response rawResponse = imagesResponse.GetRawResponse();
            Assert.That(rawResponse, Is.Not.Null);
            Assert.That(rawResponse.IsError, Is.False);

            ImageGenerations imageGenerations = imagesResponse.Value;
            Assert.That(imageGenerations, Is.InstanceOf<ImageGenerations>());
            Assert.That(imageGenerations, Is.Not.Null);
            Assert.That(imageGenerations.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));

            Assert.That(imageGenerations.Data, Is.Not.Null.Or.Empty);
            Assert.That(imageGenerations.Data.Count, Is.EqualTo(requestOptions.ImageCount));

            ImageGenerationData firstImageLocation = imageGenerations.Data[0];
            Assert.That(firstImageLocation, Is.Not.Null);
            Assert.That(firstImageLocation.Url, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(Service.Azure, OpenAIClientOptions.ServiceVersion.V2023_09_01_Preview, false)]
        [TestCase(Service.Azure, OpenAIClientOptions.ServiceVersion.V2023_12_01_Preview, false)]
        [TestCase(Service.NonAzure)]
        public async Task DallE2LegacySupport(
            Service serviceTarget,
            OpenAIClientOptions.ServiceVersion azureServiceVersion = default,
            bool shouldWork = true)
        {
            OpenAIClient client = GetTestClient(
                serviceTarget,
                Scenario.LegacyImageGenerations,
                azureServiceVersionOverride: azureServiceVersion);

            var requestOptions = new ImageGenerationOptions()
            {
                Prompt = "an old dall-e-2 image generator still creating images",
            };

            if (shouldWork)
            {
                Response<ImageGenerations> response = await client.GetImageGenerationsAsync(requestOptions);
                Assert.That(response.Value, Is.InstanceOf<ImageGenerations>());

                Assert.That(response.Value.Data, Is.Not.Null.Or.Empty);
                Assert.That(response.Value.Data[0].Url, Is.Not.Null.Or.Empty);
            }
            else
            {
                ArgumentNullException exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
                {
                    await client.GetImageGenerationsAsync(requestOptions);
                });
            }
        }
    }
}
