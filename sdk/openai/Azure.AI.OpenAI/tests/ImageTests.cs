// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using OpenAI.Images;

namespace Azure.AI.OpenAI.Tests;

public class ImageTests : AoaiTestBase<ImageClient>
{
    public ImageTests(bool isAsync) : base(isAsync)
    { }

    [RecordedTest]
    [Category("Smoke")]
    public void CanCreateClient()
    {
        ImageClient client = GetTestClient(tokenCredential: new DefaultAzureCredential());
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
            User = "test_user",
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
            User = "test_user",
            ResponseFormat = GeneratedImageFormat.Uri,
        });
        GeneratedImage image = imageResult.Value;
        Assert.That(image, Is.Not.Null);
        Assert.That(image.ImageUri, Is.Not.Null);
        Console.WriteLine($"RESPONSE--\n{imageResult.GetRawResponse().Content}");
        ImageContentFilterResultForPrompt promptResults = image.GetContentFilterResultForPrompt();
        ImageContentFilterResultForResponse responseResults = image.GetContentFilterResultForResponse();
        Assert.That(promptResults?.Sexual?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
        Assert.That(responseResults?.Sexual?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
    }
}
