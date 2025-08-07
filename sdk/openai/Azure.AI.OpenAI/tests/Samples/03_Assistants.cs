// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Identity;
using OpenAI.Assistants;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public async Task StreamingAssistantRunAsync()
    {
        #region Snippet:Assistants:CreateClient
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());

        // The Assistants feature area is in beta, with API specifics subject to change.
        // Suppress the [Experimental] warning via .csproj or, as here, in the code to acknowledge.
        #pragma warning disable OPENAI001
        AssistantClient assistantClient = azureClient.GetAssistantClient();
        #endregion

        #region Snippet:Assistants:PrepareToRun
        Assistant assistant = await assistantClient.CreateAssistantAsync(
            model: "my-gpt-4o-deployment",
            new AssistantCreationOptions()
            {
                Name = "My Friendly Test Assistant",
                Instructions = "You politely help with math questions. Use the code interpreter tool when asked to "
                    + "visualize numbers.",
                Tools = { ToolDefinition.CreateCodeInterpreter() },
            });
        ThreadInitializationMessage initialMessage = new(
            MessageRole.User,
            [
                "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9."
            ]);
        AssistantThread thread = await assistantClient.CreateThreadAsync(new ThreadCreationOptions()
        {
            InitialMessages = { initialMessage },
        });
        #endregion

        #region Snippet:Assistants:StreamRun
        RunCreationOptions runOptions = new()
        {
            AdditionalInstructions = "When possible, talk like a pirate."
        };
        await foreach (StreamingUpdate streamingUpdate
            in assistantClient.CreateRunStreamingAsync(thread.Id, assistant.Id, runOptions))
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine($"--- Run started! ---");
            }
            else if (streamingUpdate is MessageContentUpdate contentUpdate)
            {
                Console.Write(contentUpdate.Text);
                if (contentUpdate.ImageFileId is not null)
                {
                    Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
                }
            }
        }
        #endregion

        #region Snippet:Assistants:Cleanup
        // Optionally, delete persistent resources that are no longer needed.
        _ = await assistantClient.DeleteAssistantAsync(assistant.Id);
        _ = await assistantClient.DeleteThreadAsync(thread.Id);
        #endregion
    }
}
