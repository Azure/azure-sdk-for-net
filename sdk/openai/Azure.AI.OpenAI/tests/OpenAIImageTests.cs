// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public async Task CanGenerateBatchImages(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            Assert.That(client, Is.InstanceOf<OpenAIClient>());

            const string prompt = "a simplistic picture of a cyberpunk money dreaming of electric bananas";
            var requestOptions = new ImageGenerationOptions()
            {
                Prompt = prompt,
                Size = ImageSize.Size256x256,
                N = 2,
                User = "placeholder",
            };
            Assert.That(requestOptions, Is.InstanceOf<ImageGenerationOptions>());

            if (serviceTarget == OpenAIClientServiceTarget.NonAzure)
            {
                Assert.ThrowsAsync<InvalidOperationException>(async () => await client.BeginBatchImageGenerationAsync(
                    WaitUntil.Started,
                    requestOptions));
                return;
            }

            Operation<BatchImageGenerationOperationResponse> operation
                = await client.BeginBatchImageGenerationAsync(WaitUntil.Started, requestOptions);
            Assert.IsFalse(operation.HasCompleted);

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            Response rawResponse = operation.GetRawResponse();
            Assert.That(rawResponse, Is.Not.Null);
            Assert.That(rawResponse.IsError, Is.False);

            BatchImageGenerationOperationResponse operationResponse = operation.Value;
            Assert.IsNotNull(operationResponse);
            Assert.That(operationResponse.Status, Is.EqualTo(AzureOpenAIOperationState.Succeeded));
            Assert.That(operationResponse.Id, Is.Not.Null.Or.Empty);
            Assert.That(operationResponse.Created, Is.GreaterThan(0));
            Assert.That(operationResponse.Expires, Is.GreaterThan(0));
            Assert.That(operationResponse.Expires, Is.GreaterThan(operationResponse.Created));

            ImageLocationResult imageLocationResult = operationResponse.Result;
            Assert.IsNotNull(imageLocationResult);
            Assert.That(imageLocationResult.Created, Is.GreaterThan(0));
            Assert.That(imageLocationResult.Data, Is.Not.Null.Or.Empty);
            Assert.That(imageLocationResult.Data.Count, Is.EqualTo(requestOptions.N));

            ImageLocation firstImage = imageLocationResult.Data[0];
            Assert.That(firstImage, Is.Not.Null);
            Assert.That(firstImage.Error, Is.Null);
            Assert.That(firstImage.Url, Is.Not.Null.Or.Empty);
        }
    }
}
