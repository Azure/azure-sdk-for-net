// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.ChatProtocol.Tests.Samples
{
    public partial class StreamingCompletion
    {
        private void PrintIfNotNull<T>(string prefix, T value)
        {
            if (value != null)
            {
                Console.WriteLine($"{prefix}: {value}");
            }
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateStreamingCompletionAsync()
        {
            #region Snippet:CreateStreamingCompletion
            #region Snippet:CreateChatClient
            var client = new ChatProtocolClient(new Uri("<my-endpoint>"), new AzureKeyCredential("<my-key>"));
            #endregion

            var response = await client.CreateStreamingAsync(new StreamingChatCompletionOptions(
                messages: new[]
                {
                    new ChatMessage("Hello", ChatRole.Assistant),
                },
                sessionState: BinaryData.FromString("Hello"),
                context: new Dictionary<string, BinaryData>
                {
                    ["key"] = BinaryData.FromString("value")
                }
            ));

            await foreach (var completionChunk in response.Value)
            {
                foreach (var choiceDelta in completionChunk.Choices)
                {
                    Console.WriteLine("Index: " + choiceDelta.Index);
                    PrintIfNotNull("Content: ", choiceDelta.Delta?.Content);
                    PrintIfNotNull("Role: ", choiceDelta.Delta?.Role);
                    PrintIfNotNull("SessionState: ", choiceDelta.SessionState);
                    PrintIfNotNull("Context: ", choiceDelta.Context);
                }
            }
            #endregion
        }
    }
}
