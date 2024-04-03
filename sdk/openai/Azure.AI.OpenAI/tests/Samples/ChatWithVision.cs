// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class ChatWithVision
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task ChatWithVisionPreview()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

        #region Snippet:AddImageToChat
        const string rawImageUri = "<URI to your image>";
        ChatCompletionsOptions chatCompletionsOptions = new()
        {
            DeploymentName = "gpt-4-vision-preview",
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant that describes images."),
                new ChatRequestUserMessage(
                    new ChatMessageTextContentItem("Hi! Please describe this image"),
                    new ChatMessageImageContentItem(new Uri(rawImageUri))),
            },
        };
        #endregion

        #region Snippet:GetResponseFromImages
        Response<ChatCompletions> chatResponse = await client.GetChatCompletionsAsync(chatCompletionsOptions);
        ChatChoice choice = chatResponse.Value.Choices[0];
        if (choice.FinishDetails is StopFinishDetails stopDetails || choice.FinishReason == CompletionsFinishReason.Stopped)
        {
            Console.WriteLine($"{choice.Message.Role}: {choice.Message.Content}");
        }
        #endregion
    }
}
