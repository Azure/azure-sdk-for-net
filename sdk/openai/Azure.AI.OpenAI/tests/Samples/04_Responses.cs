// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Responses;
using Azure.Identity;
using System.Collections.Generic;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;

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

    public void ResponseSummarizeText()
    {
        #region Snippet:ResponseSummarizeText
        AzureOpenAIClient azureClient = new(
                new Uri("https://your-azure-openai-resource.com"),
                new DefaultAzureCredential());

        OpenAIResponseClient client = azureClient.GetOpenAIResponseClient("my-gpt-35-turbo-deployment");

        string summaryPrompt = GetSummarizationPromt();

        OpenAIResponse response = client.CreateResponse(
            inputItems: [
                ResponseItem.CreateSystemMessageItem("You are a helpful assistant that summarizes texts"),
                    ResponseItem.CreateAssistantMessageItem("Please summarize the following text in one sentence"),
                    ResponseItem.CreateUserMessageItem(summaryPrompt)
            ]
        );
        Console.WriteLine($"Get response from id {response.Id}...: {((MessageResponseItem)response.OutputItems[0]).Content[0].Text}");
    }

    private static string GetSummarizationPromt()
    {
        String textToSummarize = "On July 20, 1969, Apollo 11 successfully landed the first humans on the Moon. "
                                + "Astronauts Neil Armstrong and Buzz Aldrin spent over two hours collecting samples and conducting experiments, "
                                + "while Michael Collins remained in orbit aboard the command module. "
                                + "The mission marked a significant achievement in space exploration, fulfilling President John F. Kennedy's goal of landing a man on the Moon and returning him safely to Earth. "
                                + "The lunar samples brought back provided invaluable insights into the Moon's composition and history.";
        return "Summarize the following text.%n" + "Text:%n" + textToSummarize + "%n Summary:%n";
        #endregion
    }

    public void ResponseStreaming()
    {
        #region Snippet:ResponseStreaming
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());

        // Replace with your deployment name
        OpenAIResponseClient client = azureClient.GetOpenAIResponseClient("my-gpt-35-turbo-deployment");

        ResponseCreationOptions options = new();
        ResponseContentPart contentPart = ResponseContentPart.CreateInputTextPart("Tell me a 20-word story about building the best SDK!");
        ResponseItem inputItem = ResponseItem.CreateUserMessageItem([contentPart]);

        foreach (StreamingResponseUpdate update
            in client.CreateResponseStreaming([inputItem], options))
        {
            Console.WriteLine(ModelReaderWriter.Write(update));
        }
        #endregion
    }
}
