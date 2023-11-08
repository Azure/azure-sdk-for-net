// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Azure.AI.ChatProtocol.Tests.Samples
{
    public partial class Completion
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async void CreateCompletion()
        {
            #region Snippet:CreateCompletion
            #region Snippet:CreateChatClient
            var client = new ChatProtocolClient(new Uri("<my-endpoint>"), new AzureKeyCredential("<my-key>"));
            #endregion

            ChatCompletion completion = await client.CreateAsync(new ChatCompletionOptions(
                messages: new[]
                {
                    new TextChatMessage(ChatRole.Assistant, "Hello"),
                },
                sessionState: BinaryData.FromString("Hello"),
                context: new Dictionary<string, BinaryData>
                {
                    ["key"] = BinaryData.FromString("value")
                }
            ));

            foreach (var choice in completion.Choices)
            {
                Console.WriteLine("Index: " + choice.Index);
                if (choice.Message is TextChatMessage textMessage)
                {
                    Console.WriteLine("Content: ", textMessage.Content);
                }
                Console.WriteLine("Role: ", choice.Message.Role);
                Console.WriteLine("SessionState: ", choice.SessionState);
                Console.WriteLine("Context: ", choice.Context);
            }
            #endregion
        }
    }
}
