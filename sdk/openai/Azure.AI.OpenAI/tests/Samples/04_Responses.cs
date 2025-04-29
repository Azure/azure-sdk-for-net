// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Responses;
using Azure.Identity;
using System.Collections.Generic;
using System;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void ResponseImage()
    {
        #region Snippet:ResponseInputImage

        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());

        // Replace with your deployment name
        OpenAIResponseClient client = azureClient.GetOpenAIResponseClient("gpt-4o-mini");

        Uri imageUri = new("https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Microsoft_logo.svg/512px-Microsoft_logo.svg.png");
        ResponseContentPart imagePart = ResponseContentPart.CreateInputImagePart(imageUri);
        ResponseContentPart textPart = ResponseContentPart.CreateInputTextPart("Describe this image");

        List<ResponseContentPart> contentParts = [imagePart, textPart];

        OpenAIResponse response = client.CreateResponse(
                    inputItems:
                    [
                        ResponseItem.CreateSystemMessageItem("You are a helpful assistant that describes images"),
                        ResponseItem.CreateUserMessageItem(contentParts)
                    ]);

        Console.WriteLine($"{response.Id}: {((MessageResponseItem)response.OutputItems[0]).Content[0].Text}");

        #endregion

    }
}
