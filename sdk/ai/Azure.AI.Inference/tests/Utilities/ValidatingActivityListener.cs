// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Azure.AI.Inference.Telemetry;
using NUnit.Framework;

using static Azure.AI.Inference.Telemetry.OpenTelemetryInternalConstants;

namespace Azure.AI.Inference.Tests.Utilities
{
    [NonParallelizable]
    internal class ValidatingActivityListener : IDisposable
    {
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

        public void ValidateStartActivity(ChatCompletionsOptions requestOptions, Uri endpoint, bool traceEvents)
        {
            Activity activity = m_listeners.Single();
            Assert.NotNull(activity);
            // Validate all tags
            ValidateTag(activity, GenAiSystemKey, GenAiSystemValue);
            ValidateTag(activity, GenAiResponseModelKey, requestOptions.Model);
            ValidateTag(activity, ServerAddressKey, endpoint.Host);
            if (endpoint.Port != 443)
                ValidateTag(activity, ServerPortKey, endpoint.Port);
            else
                Assert.IsNull(activity.GetTagItem(ServerPortKey));
            ValidateTag(activity, GenAiOperationNameKey, "chat");
            ValidateTag(activity, GenAiRequestMaxTokensKey, requestOptions.MaxTokens);
            ValidateFloatTag(activity, GenAiRequestTemperatureKey, requestOptions.Temperature);
            if (requestOptions.AdditionalProperties.TryGetValue("top_p", out BinaryData topP))
            {
                ValidateFloatTag(activity, GenAiRequestTopPKey, JsonSerializer.Deserialize<float?>(topP));
            }
            // Validate events
            if (traceEvents)
                ValidateChatMessageEvents(activity, requestOptions.Messages);
            else
                foreach (ChatRequestMessage message in requestOptions.Messages)
                {
                    ValidateNoEventsWithName($"gen_ai.{message.Role}.message");
                }
        }

        /// <summary>
        /// Remove junk added adding string as a tag.
        /// </summary>
        /// <param name="value">The string to be cleaned.</param>
        /// <returns></returns>
        private static string CleanString(string value)
        {
            return value.Replace("\\u0022", "\"").Replace("\\\\n", "\\n").Replace("\\\\u", "\\u").Trim('\"');
        }

        public void ValidateResponseEvents(AbstractRecordedResponse response, bool traceEvents)
        {
            Activity activity = m_listeners.Single();
            if (response == null)
            {
                ValidateNoEventsWithName(GenAiChoice);
                return;
            }
            ValidateTag(activity, GenAiResponseIdKey, response.Id);
            ValidateTag(activity, GenAiResponseModelKey, response.Model);
            ValidateTag(activity, GenAiResponseFinishReasonsKey, response.FinishReason);
            ValidateIntTag(activity, GenAiUsageOutputTokensKey, response.CompletionTokens);
            ValidateIntTag(activity, GenAiUsageInputTokensKey, response.PromptTokens);
            var validChoices = new HashSet<string>();
            if (traceEvents)
            {
                foreach (string v in response.GetSerializedCompletions())
                {
                    validChoices.Add(CleanString(v));
                }
                foreach (ActivityEvent evt in activity.Events)
                {
                    if (evt.Name != GenAiChoice)
                        continue;
                    Assert.AreEqual(2, evt.Tags.Count());
                    Assert.AreEqual(GenAiSystemKey, evt.Tags.ElementAt(0).Key);
                    Assert.AreEqual(GenAiSystemValue, evt.Tags.ElementAt(0).Value);
                    Assert.AreEqual(GenAiEventContent, evt.Tags.ElementAt(1).Key);
                    Assert.That(validChoices.Contains(CleanString(evt.Tags.ElementAt(1).Value.ToString())));
                }
            }
            else
            {
                ValidateNoEventsWithName(GenAiChoice);
            }
        }

        private void ValidateNoEventsWithName(string name)
        {
            Activity activity = m_listeners.Single();
            // Check that we do not have the actual completion events.
            foreach (ActivityEvent evt in activity.Events)
            {
                if (evt.Name == name)
                    Assert.That(evt.Name != name, $"The event {name} was found on activity.");
            }
        }

        public void ValidateErrorTag(
            string errorType,
            string errorDescription
            )
        {
            Activity activity = m_listeners.Single();
            Assert.AreEqual(ActivityStatusCode.Error, activity.Status);
            Assert.AreEqual(errorDescription, activity.StatusDescription);
            ValidateTag(activity, ErrorTypeKey, errorType);
        }

        private static void ValidateEvent(Activity activity, string name, Dictionary<string, object> actuals)
        {
            ActivityEvent expected = new ActivityEvent("None");
            foreach (ActivityEvent evt in activity.Events)
            {
                if (evt.Name == name)
                {
                    expected = evt;
                    break;
                }
            }
            Assert.AreNotEqual(expected.Name, "None");
            Assert.Greater(expected.Timestamp, new DateTimeOffset(new DateTime(2024, 6, 1)));
            ValidateEventTags(expected.Tags, actuals);
        }

        private static void ValidateChatMessageEvents(Activity activity, IList<ChatRequestMessage> messages)
        {
            Assert.NotNull(activity);
            foreach (ChatRequestMessage message in messages)
            {
                ValidateEvent(
                    activity: activity,
                    name: $"gen_ai.{message.Role}.message",
                    actuals: new Dictionary<string, object>()
                    {
                        { GenAiSystemKey, GenAiSystemValue},
                        { GenAiEventContent, OpenTelemetryScope.GetContent(message)}
                    }
                );
            }
        }

        private static void ValidateTag(Activity activity, string key, object value)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                Assert.IsNull(activity.GetTagItem(key));
            }
            else
            {
                Assert.NotNull(activity.GetTagItem(key));
                Assert.AreEqual(value.ToString(), activity.GetTagItem(key).ToString());
            }
        }

        private static void ValidateFloatTag(Activity activity, string key, float? value)
        {
            if (!value.HasValue)
            {
                Assert.IsNull(activity.GetTagItem(key));
            }
            else
            {
                Assert.NotNull(activity.GetTagItem(key));
                Assert.AreEqual(
                    expected: float.Parse(value.ToString()),
                    actual: float.Parse(activity.GetTagItem(key).ToString()),
                    delta: 0.001
                    );
            }
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
                Assert.AreEqual(tags[actual.Key].ToString(), actual.Value.ToString());
            }
        }

        public void VaidateTelemetryIsOff()
        {
            Assert.That(m_listeners.IsEmpty);
        }
    }
}
