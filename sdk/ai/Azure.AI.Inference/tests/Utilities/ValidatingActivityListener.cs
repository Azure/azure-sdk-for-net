// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Azure.AI.Inference.Telemetry;
using Castle.Core;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

using static Azure.AI.Inference.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Inference.Tests.Utilities
{
    internal class ValidatingActivityListener : IDisposable
    {
        private readonly ActivityListener m_activityListener;
        private readonly ConcurrentQueue<Activity> m_listeners = new();

        public ValidatingActivityListener()
        {
            m_activityListener = new ActivityListener()
            {
                ActivityStopped = m_listeners.Enqueue,
                ShouldListenTo = s => s.Name == OpenTelemetryScope.ACTIVITY_NAME,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded
            };
            ActivitySource.AddActivityListener(m_activityListener);
        }

        public void Dispose()
        {
            m_activityListener.Dispose();
        }

        public void validateStartActivity(ChatCompletionsOptions requestOptions, Uri endpoint)
        {
            Activity activity = m_listeners.Single();
            Assert.NotNull(activity);
            // Validate all tags
            validateTag(activity, GenAiSystemKey, GenAiSystemValue);
            validateTag(activity, GenAiResponseModelKey, requestOptions.Model);
            validateTag(activity, ServerAddressKey, endpoint.Host);
            validateTag(activity, ServerPortKey, endpoint.Port);
            validateTag(activity, GenAiOperationNameKey, "Complete");
            validateTag(activity, GenAiRequestMaxTokensKey, requestOptions.MaxTokens);
            validateTag(activity, GenAiRequestTemperatureKey, requestOptions.Temperature);
            validateTag(activity, GenAiRequestTopPKey, JsonSerializer.Deserialize<double?>(requestOptions.AdditionalProperties["top_p"]));
            // Validate events
            validateChatMessageEvents(activity, requestOptions.Messages);
        }

        public void validateResponseEvents(AbstractRecordedResponse response)
        {
            Activity activity = m_listeners.Single();
            validateTag(activity, GenAiResponseIdKey, response.Id);
            validateTag(activity, GenAiResponseModelKey, response.Model);
            validateTag(activity, GenAiResponseFinishReasonKey, response.FinishReason);
            validateIntTag(activity, GenAiUsageOutputTokensKey, response.CompletionTokens);
            validateIntTag(activity, GenAiUsageInputTokensKey, response.PromptTokens);
            var validChoices = new HashSet<string>(response.getSerializedCompletions());
            foreach (var evt in activity.Events)
            {
                if (evt.Name != GenAiChoice)
                    continue;
                Assert.AreEqual(2, evt.Tags.Count());
                Assert.AreEqual(GenAiSystemKey, evt.Tags.ElementAt(0).Key);
                Assert.AreEqual(GenAiSystemValue, evt.Tags.ElementAt(0).Value);
                Assert.AreEqual(GenAiEventContent, evt.Tags.ElementAt(1).Key);
                Assert.That(validChoices.Contains(evt.Tags.ElementAt(1).Value.ToString().Replace("\\u0022", "\"").Trim('\"')));
            }
            Assert.AreEqual(ActivityStatusCode.Ok, activity.Status);
        }

        public void validateErrorTag(
            string errorType,
            string errorDescription
            )
        {
            Activity activity = m_listeners.Single();
            Assert.AreEqual(ActivityStatusCode.Error, activity.Status);
            Assert.AreEqual(errorDescription, activity.StatusDescription);
            validateTag(activity, ErrorTypeKey, errorType);
        }

        private static void validateEvent(Activity activity, string name, Dictionary<string, object> actuals)
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
            validateEventTags(expected.Tags, actuals);
        }

        private static void validateChatMessageEvents(Activity activity, IList<ChatRequestMessage> messages)
        {
            Assert.NotNull(activity);
            foreach (ChatRequestMessage message in messages)
            {
                validateEvent(
                    activity: activity,
                    name: $"gen_ai.{message.Role}.message",
                    actuals: new Dictionary<string, object>()
                    {
                        { GenAiSystemKey, GenAiSystemValue},
                        { GenAiEventContent, OpenTelemetryScope.getContent(message)}
                    }
                );
            }
        }

        private static void validateTag(Activity activity, string key, object value)
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

        private static void validateIntTag(Activity activity, string key, int value)
        {
            if (value == AbstractRecordedResponse.NOT_SET)
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

        private static void validateEventTags(IEnumerable<KeyValuePair<string, object>> actuals, Dictionary<string, object> tags)
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
    }
}
