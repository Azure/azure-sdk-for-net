// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAIImageTests : OpenAITestBase
    {
        public OpenAIImageTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Live)
        {
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task CanGenerateImages(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetDevelopmentTestClient(serviceTarget, "AOAI_DALLE3_ENDPOINT", "AOAI_DALLE3_API_KEY");
            string deploymentName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.ImageGenerations);

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
    }
}
