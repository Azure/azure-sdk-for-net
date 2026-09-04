// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample11_AdaptiveCards.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample11Snippets
    {
        public void CardAgent(string[] args)
        {
            #region Snippet:Activity_Sample11_AdaptiveCards

            const string AdaptiveCardContentType = "application/vnd.microsoft.card.adaptive";

            ActivityServer.Run(
                (AgentApplication app) =>
            // On a text message, reply with an Adaptive Card that has a submit action.
            app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                // A card submit action arrives as a message with a `value` payload and no text.
                if (turnContext.Activity.Value is not null)
                {
                    var choice = JsonSerializer.Serialize(turnContext.Activity.Value);
                    await turnContext.SendActivityAsync($"You chose: {choice}", cancellationToken: cancellationToken);
                    return;
                }

                var cardJson = """
                {
                  "type": "AdaptiveCard",
                  "version": "1.5",
                  "body": [ { "type": "TextBlock", "text": "Pick one:", "weight": "Bolder" } ],
                  "actions": [
                    { "type": "Action.Submit", "title": "Yes", "data": { "answer": "yes" } },
                    { "type": "Action.Submit", "title": "No",  "data": { "answer": "no" } }
                  ]
                }
                """;

                var reply = new Microsoft.Agents.Core.Models.Activity
                {
                    Type = ActivityTypes.Message,
                    Attachments =
                    [
                        new Attachment
                        {
                            ContentType = AdaptiveCardContentType,
                            Content = JsonSerializer.Deserialize<JsonElement>(cardJson),
                        }
                    ],
                };

                await turnContext.SendActivityAsync(reply, cancellationToken: cancellationToken);
            }),
                args);

            #endregion
        }
    }
}
