// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Azure.AI.Inference.Telemetry;
using NUnit.Framework;

using static Azure.AI.Inference.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Inference.Tests.Utilities
{
    [NonParallelizable]
    internal class ValidatingActivityListener : IDisposable
    {
        private static readonly JsonSerializerOptions s_jsonOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        private readonly ActivityListener m_activityListener;
        private readonly ConcurrentQueue<Activity> m_listeners = new();

        private void ActivityStopped(Activity act)
        {
            // We have another activity, which is created when we start the http request.
            // that is why we limit the stopped activities by.
            if (act.DisplayName.StartsWith("chat"))
                m_listeners.Enqueue(act);
        }

        public ValidatingActivityListener()
        {
            m_activityListener = new ActivityListener()
            {
                ActivityStopped = ActivityStopped,
                ShouldListenTo = s => s.Name == OpenTelemetryConstants.ClientName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded
            };
            ActivitySource.AddActivityListener(m_activityListener);
        }

        public void Dispose()
        {
            m_activityListener.Dispose();
        }

        public void ValidateStartActivity(ChatCompletionsOptions requestOptions, Uri endpoint, bool traceContent)
        {
            Activity activity = m_listeners.Single();
            Assert.NotNull(activity);
            // Validate all tags
            ValidateTag(activity, GenAiSystemKey, GenAiSystemValue);
            ValidateTag(activity, GenAiRequestModelKey, requestOptions.Model);
            ValidateTag(activity, ServerAddressKey, endpoint.Host);
            if (endpoint.Port != 443)
                ValidateTag(activity, ServerPortKey, endpoint.Port);
            else
                Assert.IsNull(activity.GetTagItem(ServerPortKey));
            ValidateTag(activity, GenAiOperationNameKey, "chat");
            ValidateTag(activity, GenAiRequestMaxTokensKey, requestOptions.MaxTokens);
            ValidateTag(activity, GenAiRequestTemperatureKey, requestOptions.Temperature);
            if (requestOptions.AdditionalProperties.TryGetValue("top_p", out BinaryData topP))
            {
                ValidateTag(activity, GenAiRequestTopPKey, JsonSerializer.Deserialize<float?>(topP));
            }
            // Validate events
            ValidateChatMessageEvents(activity, requestOptions.Messages, traceContent);
        }

        public void ValidateResponse(RecordedResponse response, string errorType, string errorDescription)
        {
            Activity activity = m_listeners.Single();

            List<ActivityEvent> actualChoices = activity.Events.Where(e => e.Name == GenAiChoice).ToList();

            if (errorType != null)
            {
                ValidateError(activity, errorType, errorDescription);
            }

            if (response == null)
            {
                Assert.IsEmpty(actualChoices);
                return;
            }

            Assert.AreEqual(actualChoices.Count, actualChoices.Count);
            ValidateTag(activity, GenAiResponseIdKey, response.Id);
            ValidateTag(activity, GenAiResponseModelKey, response.Model);
            ValidateTag(activity, GenAiResponseFinishReasonsKey, response.FinishReasons);
            ValidateIntTag(activity, GenAiUsageOutputTokensKey, response.CompletionTokens);
            ValidateIntTag(activity, GenAiUsageInputTokensKey, response.PromptTokens);
            ValidateTag(activity, AzNamespaceKey, AzureRpNamespaceValue);

            HashSet<string> expectedChoices = new HashSet<string>(response.Choices.Select(c => JsonSerializer.Serialize(c, options: s_jsonOptions)));
            for (int i = 0; i < actualChoices.Count; i++)
            {
                Assert.AreEqual(2, actualChoices[i].Tags.Count());
                Assert.AreEqual(GenAiSystemValue, actualChoices[i].Tags.Single(kvp => kvp.Key == GenAiSystemKey).Value);

                var content = actualChoices[i].Tags.Where(kvp => kvp.Key == GenAiEventContent);
                Assert.AreEqual(1, content.Count());
                TelemetryUtils.AssertChoiceEventsAreEqual(response.Choices[i], content.Single().Value.ToString());
            }
        }

        private void ValidateError(Activity activity, string errorType, string errorDescription)
        {
            Assert.AreEqual(ActivityStatusCode.Error, activity.Status);
            Assert.AreEqual(errorDescription, activity.StatusDescription);
            ValidateTag(activity, ErrorTypeKey, errorType);
        }

        private static void ValidateEvent(Activity activity, string name, Dictionary<string, object> expected)
        {
            ActivityEvent actual = default;
            foreach (ActivityEvent evt in activity.Events)
            {
                if (evt.Name == name)
                {
                    actual = evt;
                    break;
                }
            }
            Assert.AreNotEqual(actual, default);
            Assert.Greater(actual.Timestamp, new DateTimeOffset(new DateTime(2024, 6, 1)));
            ValidateEventTags(actual.Tags, expected);
        }

        private static void ValidateChatMessageEvents(Activity activity, IList<ChatRequestMessage> messages, bool traceContent)
        {
            Assert.NotNull(activity);
            foreach (ChatRequestMessage message in messages)
            {
                ValidateEvent(
                    activity: activity,
                    name: $"gen_ai.{message.Role}.message",
                    expected: new() {
                        { GenAiSystemKey, GenAiSystemValue},
                        { GenAiEventContent, traceContent ? GetContent(message) : null }
                    }
                );
            }
        }

        private static void ValidateTag(Activity activity, string key, object value)
        {
            Assert.AreEqual(value, activity.GetTagItem(key));
        }

        private static void ValidateIntTag(Activity activity, string key, long? value)
        {
            if (!value.HasValue)
            {
                Assert.IsNull(activity.GetTagItem(key));
            }
            else
            {
                Assert.NotNull(activity.GetTagItem(key));
                Assert.That(int.TryParse(activity.GetTagItem(key).ToString(), out int intActual));
                Assert.AreEqual(value, intActual);
            }
        }

        private static void ValidateEventTags(IEnumerable<KeyValuePair<string, object>> actuals, Dictionary<string, object> tags)
        {
            // Though technically we can add the same named tag multiple times, we are not doing it in
            // our code.
            Assert.AreEqual(tags.Count, actuals.Count());
            foreach (KeyValuePair<string, object> actual in actuals)
            {
                Assert.That(tags.ContainsKey(actual.Key));
                Assert.AreEqual(tags[actual.Key], actual.Value);
            }
        }

        public void ValidateTelemetryIsOff()
        {
            Assert.That(m_listeners.IsEmpty);
        }

        private static string GetContent(ChatRequestMessage message)
        {
            if (message is ChatRequestAssistantMessage assistantMessage)
                return $"{{\"content\":\"{assistantMessage.Content}\"}}";
            if (message is ChatRequestSystemMessage systemMessage)
                return $"{{\"content\":\"{systemMessage.Content}\"}}";
            if (message is ChatRequestToolMessage toolMessage)
                return $"{{\"content\":\"{toolMessage.Content},\"id\":\"{toolMessage.ToolCallId}\"}}";
            if (message is ChatRequestUserMessage userMessage)
                return $"{{\"content\":\"{userMessage.Content}\"}}";
            return "";
        }
    }
}
