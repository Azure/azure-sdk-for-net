// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class ImagesSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ImageGenerations()
        {
            string endpoint = "https://myaccount.openai.azure.com/";
            var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

            #region Snippet:GenerateImages
            Response<ImageGenerations> imageGenerations = await client.GetImageGenerationsAsync(
                new ImageGenerationOptions()
                {
                    Prompt = "a happy monkey eating a banana, in watercolor",
                    Size = ImageSize.Size256x256,
                });

            // Image Generations responses provide URLs you can use to retrieve requested images
            Uri imageUri = imageGenerations.Value.Data[0].Url;
            #endregion
        }
    }
}
