// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Responses;
using Azure.Identity;
using System.Collections.Generic;
using System;
using System.ClientModel;

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
        OpenAIResponseClient client = azureClient.GetOpenAIResponseClient("my-gpt-35-turbo-deployment");

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

    public void ResponseChatbot()
    {
        #region Snippet:ResponseBasicChatbot

        AzureOpenAIClient azureClient = new(
                new Uri("https://your-azure-openai-resource.com"),
                new DefaultAzureCredential());

        // Replace with your deployment name
        OpenAIResponseClient client = azureClient.GetOpenAIResponseClient("my-gpt-35-turbo-deployment");

        OpenAIResponse response = client.CreateResponse(
            inputItems: [
                ResponseItem.CreateSystemMessageItem("You are a humorous assistant who tells jokes"),
                    ResponseItem.CreateUserMessageItem("Please tell me 3 jokes about trains")
                ]);

        Console.WriteLine($"{response.Id}: {((MessageResponseItem)response.OutputItems[0]).Content[0].Text}");

        OpenAIResponse getResponse = client.GetResponse(response.Id);
        Console.WriteLine($"Get response from id {response.Id}...: {((MessageResponseItem)response.OutputItems[0]).Content[0].Text}");

        ResponseDeletionResult deleteResponse = client.DeleteResponse(response.Id);
        Console.WriteLine($"Deleting response from id... \nResponse deleted: {deleteResponse.Deleted}");

        try
        {
            OpenAIResponse getDeletedResponse = client.GetResponse(response.Id);
            Console.WriteLine($"Response not deleted properly: {((MessageResponseItem)getDeletedResponse.OutputItems[0]).Content[0].Text}");
        }
        catch (ClientResultException ex)
        {
            if (!ex.Message.Contains("404"))
            {
                throw;
            }
            Console.WriteLine($"Response was not found as expected: {ex.Message}");
        }

        #endregion
    }
}
