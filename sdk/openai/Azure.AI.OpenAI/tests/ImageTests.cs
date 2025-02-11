// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Images;
using OpenAI.Images;
using OpenAI.TestFramework;

namespace Azure.AI.OpenAI.Tests;

public class ImageTests(bool isAsync) : AoaiTestBase<ImageClient>(isAsync)
{
    [RecordedTest]
    [Category("Smoke")]
    public void CanCreateClient()
    {
        ImageClient client = GetTestClient(tokenCredential: TestEnvironment.Credential);
        Assert.That(client, Is.InstanceOf<ImageClient>());
    }

    [RecordedTest]
    public async Task BadKeyGivesHelpfulError()
    {
        string mockKey = "not-a-valid-key-and-should-still-be-sanitized";

        try
        {
            ImageClient client = GetTestClient(keyCredential: new ApiKeyCredential(mockKey));
            _ = await client.GenerateImageAsync("a delightful exception message, in contemporary watercolor");
            Assert.Fail("No exception was thrown");
        }
        catch (Exception thrownException)
        {
            Assert.That(thrownException, Is.InstanceOf<ClientResultException>());
            Assert.That(thrownException.Message, Does.Contain("invalid subscription key"));
            Assert.That(thrownException.Message, Does.Not.Contain(mockKey));
        }
    }

    [RecordedTest]
    public async Task CanCreateSimpleImage()
    {
        ImageClient client = GetTestClient();
        GeneratedImage image = await client.GenerateImageAsync("a tabby cat", new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            EndUserId = "test_user",
            ResponseFormat = GeneratedImageFormat.Bytes,
        });
        Assert.That(image, Is.Not.Null);
        Assert.That(image.ImageBytes, Is.Not.Null);
    }

    [RecordedTest]
    public async Task CanGetContentFilterResults()
    {
        ImageClient client = GetTestClient();
        ClientResult<GeneratedImage> imageResult = await client.GenerateImageAsync("a tabby cat", new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            EndUserId = "test_user",
            ResponseFormat = GeneratedImageFormat.Uri,
        });
        GeneratedImage image = imageResult.Value;
        Assert.That(image, Is.Not.Null);
        Assert.That(image.ImageUri, Is.Not.Null);
        RequestImageContentFilterResult promptResults = image.GetRequestContentFilterResult();
        ResponseImageContentFilterResult responseResults = image.GetResponseContentFilterResult();
        Assert.That(promptResults?.Sexual?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
        Assert.That(responseResults?.Sexual?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
    }
}
