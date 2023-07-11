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
            OpenAIClient client = GetTestClient(serviceTarget);
            Assert.That(client, Is.InstanceOf<OpenAIClient>());

            const string prompt = "a simplistic picture of a cyberpunk money dreaming of electric bananas";
            var requestOptions = new ImageGenerationOptions()
            {
                Prompt = prompt,
                Size = ImageSize.Size256x256,
                ImageCount = 2,
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

            ImageLocation firstImageLocation = imageGenerations.Data[0];
            Assert.That(firstImageLocation, Is.Not.Null);
            Assert.That(firstImageLocation.Url, Is.Not.Null.Or.Empty);

            using Stream imageStream = await firstImageLocation.GetStreamAsync();
            using var copyStream = new MemoryStream();
            imageStream.CopyTo(copyStream);

            Assert.That(copyStream.Length, Is.GreaterThan(0));

            ImageLocation secondImageLocation = imageGenerations.Data[1] as ImageLocation;
            Assert.That(secondImageLocation, Is.Not.Null);
            Assert.That(secondImageLocation.Url, Is.Not.Null.Or.Empty);
            Assert.That(
                secondImageLocation.Url.ToString(),
                Is.Not.EquivalentTo(firstImageLocation.Url.ToString()));
        }

        /*
         * Restore this test when base64 methods are available
         *

        [RecordedTest]
        // [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        [Ignore("Test recording currently fails with b64 data payload")]
        public async Task Base64EncodedResponsesWork(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            Assert.That(client, Is.InstanceOf<OpenAIClient>());

            const string prompt = "a simplistic picture of a cyberpunk money dreaming of electric bananas";
            var requestOptions = new ImageGenerationOptions()
            {
                Prompt = prompt,
                Size = ImageSize.Size256x256,
                User = "placeholder",
            };
            Assert.That(requestOptions, Is.InstanceOf<ImageGenerationOptions>());

            Response<ImageGenerations> imagesResponse = await client.GetImageGenerationsEncodedAsync(requestOptions);

            Response rawResponse = imagesResponse.GetRawResponse();
            Assert.That(rawResponse, Is.Not.Null);
            Assert.That(rawResponse.IsError, Is.False);

            ImageGenerations imageGenerations = imagesResponse.Value;
            Assert.That(imageGenerations, Is.InstanceOf<ImageGenerations>());
            Assert.That(imageGenerations, Is.Not.Null);
            Assert.That(imageGenerations.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));

            Assert.That(imageGenerations.Data, Is.Not.Null.Or.Empty);
            Assert.That(imageGenerations.Data.Count, Is.EqualTo(1));

            ImagePayload imagePayload = imageGenerations.Data[0] as ImagePayload;
            Assert.That(imagePayload, Is.Not.Null);
            Assert.That(imagePayload.Base64Data, Is.Not.Null.Or.Empty);

            using Stream helperDataStream = await imageGenerations.Data[0].GetStreamAsync();
            using var streamReader = new StreamReader(helperDataStream);
            string helperStreamDump = await streamReader.ReadToEndAsync();

            Assert.That(helperStreamDump.Length, Is.EqualTo(imagePayload.Base64Data.Length));
        }

        */
    }
}
