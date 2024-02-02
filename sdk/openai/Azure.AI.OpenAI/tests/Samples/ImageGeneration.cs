// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class ImagesSamples
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task ImageGenerations()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());
        const bool usingAzure = true;

        #region Snippet:GenerateImages
        Response<ImageGenerations> response = await client.GetImageGenerationsAsync(
            new ImageGenerationOptions()
            {
                DeploymentName = usingAzure ? "my-azure-openai-dall-e-3-deployment" : "dall-e-3",
                Prompt = "a happy monkey eating a banana, in watercolor",
                Size = ImageSize.Size1024x1024,
                Quality = ImageGenerationQuality.Standard
            });

        ImageGenerationData generatedImage = response.Value.Data[0];
        if (!string.IsNullOrEmpty(generatedImage.RevisedPrompt))
        {
            Console.WriteLine($"Input prompt automatically revised to: {generatedImage.RevisedPrompt}");
        }
        Console.WriteLine($"Generated image available at: {generatedImage.Url.AbsoluteUri}");
        #endregion
    }
}
