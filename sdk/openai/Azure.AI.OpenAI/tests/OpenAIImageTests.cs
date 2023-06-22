// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public async Task CanGenerateSimpleImage(OpenAIClientServiceTarget serviceTarget)
        {
            // OpenAIClient client = GetTestClient(serviceTarget);
            OpenAIClient client = GetAzureClientWithToken();

            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Completions);
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
            const string prompt = "a simplistic picture of a cyberpunk money dreaming of electric bananas";
            ImageGenerationOptions requestOptions = new ImageGenerationOptions()
            {
                Prompt = prompt,
                Size = ImageSize.Size256x256
            };
            Assert.That(requestOptions, Is.InstanceOf<ImageGenerationOptions>());

            Response<IReadOnlyList<ImageReference>> imagesResponse
                = await client.GetImagesAsync(requestOptions);

            Response rawResponse = imagesResponse.GetRawResponse();
            Assert.That(rawResponse, Is.Not.Null);
            Assert.That(rawResponse.IsError, Is.False);

            IReadOnlyList<ImageReference> images = imagesResponse.Value;
            Assert.That(images, Is.InstanceOf<IReadOnlyList<ImageReference>>());
            Assert.That(images, Is.Not.Null.Or.Empty);
            Assert.That(images.Count, Is.EqualTo(1));

            ImageReference image = images[0];
            Assert.That(image, Is.Not.Null);
            Assert.That(image.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
            Assert.That(image.DownloadUrl, Is.Not.Null.Or.Empty);

            using Stream imageStream = await image.GetStreamAsync();
            using var copyStream = new MemoryStream();
            imageStream.CopyTo(copyStream);

            Assert.That(copyStream.Length, Is.GreaterThan(0));
        }
    }
}
