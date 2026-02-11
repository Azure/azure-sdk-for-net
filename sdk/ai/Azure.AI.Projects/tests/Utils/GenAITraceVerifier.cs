// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Utils
{
    public class GenAiTraceVerifier
    {
        public static void ValidateSpanAttributes(Activity span, Dictionary<string, object> expectedAttributes)
        {
            var actualAttributes = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> tag in span.EnumerateTagObjects())
            {
                actualAttributes[tag.Key] = tag.Value;
            }

            foreach (KeyValuePair<string, object> expected in expectedAttributes)
            {
                Assert.That(actualAttributes, Contains.Key(expected.Key), $"Attribute '{expected.Key}' not found in span.");
                var actualValue = actualAttributes[expected.Key];
                ValidateAttributeValue(expected.Value, actualValue, expected.Key);
            }
        }

        public static void ValidateSpanEvents(Activity span, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents)
        {
            var spanEvents = span.Events.ToList();
            ValidateSpanEvents(spanEvents, expectedEvents);
        }

        public static void ValidateSpanEvents(List<ActivityEvent> spanEvents, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents, bool allowAdditionalEvents=false)
        {
            foreach (var expectedEvent in expectedEvents)
            {
                var matchingEvent = spanEvents.FirstOrDefault(e => e.Name == expectedEvent.Name);
                Assert.That(matchingEvent.Name, Is.Not.Null, $"Event '{expectedEvent.Name}' not found.");

                var actualEventAttributes = new Dictionary<string, object>();
                foreach (var tag in matchingEvent.EnumerateTagObjects())
                {
                    actualEventAttributes[tag.Key] = tag.Value;
                }

                ValidateEventAttributes(expectedEvent.Attributes, actualEventAttributes, expectedEvent.Name);
                spanEvents.Remove(matchingEvent);
            }

            Assert.That(spanEvents.Any() && !allowAdditionalEvents, Is.False, $"Unexpected additional events {spanEvents} found in span.");
        }

        public static void ValidateEventAttributes(Dictionary<string, object> expected, Dictionary<string, object> actual, string eventName)
        {
            var expectedKeys = new HashSet<string>(expected.Keys);
            var actualKeys = new HashSet<string>(actual.Keys);

            Assert.That(expectedKeys.SetEquals(actualKeys), Is.True, $"The {eventName} event attribute keys mismatch.\nExpected: {expectedKeys}\nActual: {actualKeys}");
            foreach (var key in expectedKeys)
            {
                ValidateAttributeValue(expected[key], actual[key], key);
            }
        }

        private static void ValidateAttributeValue(object expected, object actual, string key)
        {
            if (expected is string expectedStr)
            {
                if (expectedStr == "*")
                {
                    Assert.That(actual, Is.Not.Null, $"The value for {key} i expected to be {actual} but was null.");
                    Assert.That(actual, Is.Not.Empty, $"The value for {key} i expected to be {actual} but was empty.");
                }
                else if (expectedStr == "+")
                {
                    if (double.TryParse(actual?.ToString(), out double numericValue))
                    {
                        Assert.That(numericValue, Is.GreaterThanOrEqualTo(0), $"The value for {key} is expected to be more then 0, but was {numericValue}");
                    }
                    Assert.Fail($"The value for {key} was not set.");
                }
                else if (IsValidJson(expectedStr) && IsValidJson(actual?.ToString()))
                {
                    ValidateJsonString(expectedStr, actual.ToString(), key);
                }
                else
                {
                    Assert.That(actual?.ToString(), Is.EqualTo(expectedStr), $"Expected value for {key} is {expectedStr}, but was {actual?.ToString()}");
                }
            }
            else if (expected is Dictionary<string, object> expectedDict)
            {
                if (actual is string actualStr && IsValidJson(actualStr))
                {
                    Dictionary<string, object> actualDict = JsonSerializer.Deserialize<Dictionary<string, object>>(actualStr);
                    ValidateAttributeValue(expectedDict, actualDict, key);
                }
                Assert.Fail($"The value for {key} is not a valid JSON: {actual}");
            }
            else if (expected is IEnumerable<object> expectedList)
            {
                if (actual is string actualStr && IsValidJson(actualStr))
                {
                    List<object> actualList = JsonSerializer.Deserialize<List<object>>(actualStr);
                    Assert.That(expectedList.SequenceEqual(actualList), Is.True, $"The lists for {key} are different:\nActual {actualList}\n{expectedList}");
                }
                Assert.Fail($"The value for {key} is not a valid JSON: {actual}");
            }
            else
            {
                Assert.That(actual, Is.EqualTo(expected), $"Expected value for {key} is {expected}, but was {actual}");
            }
        }

        private static bool IsValidJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return false;
            try
            {
                JsonDocument.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ValidateJsonString(string expectedJson, string actualJson, string key)
        {
            try
            {
                var expectedDoc = JsonDocument.Parse(expectedJson);
                var actualDoc = JsonDocument.Parse(actualJson);
                AssertJsonElementDeepEquals(expectedDoc.RootElement, actualDoc.RootElement, key);
            }
            catch
            {
                Assert.Fail($"Unable to parse expected or actual for {key}. Expected: {expectedJson}; Actual: {actualJson}");
            }
        }

        private static void AssertJsonElementDeepEquals(JsonElement expected, JsonElement actual, string key)
        {
            Assert.That(actual.ValueKind, Is.EqualTo(expected.ValueKind), $"The value kind for key {key} differs. Expected: {expected.ValueKind}, Actual: {actual.ValueKind}");

            switch (expected.ValueKind)
            {
                case JsonValueKind.Object:
                    var expectedProps = expected.EnumerateObject().OrderBy(p => p.Name).ToList();
                    var actualProps = actual.EnumerateObject().OrderBy(p => p.Name).ToList();
                    Assert.That(actualProps.Count, Is.EqualTo(expectedProps.Count), $"The number of propertie for {key} was different. Expected: {expectedProps.Count}, but was {actualProps.Count}.\nExpected: {expectedProps}\nActual: {actualProps}.");
                    for (int i = 0; i < expectedProps.Count; i++)
                    {
                        Assert.That(actualProps[i].Name, Is.EqualTo(expectedProps[i].Name), $"The {i}-th property of {key} is named {actualProps[i].Name} bit expected property is {expectedProps[i].Name}");
                        AssertJsonElementDeepEquals(expectedProps[i].Value, actualProps[i].Value, $"{key}/{actualProps[i].Name}");
                    }
                    break;
                case JsonValueKind.Array:
                    var expectedItems = expected.EnumerateArray().ToList();
                    var actualItems = actual.EnumerateArray().ToList();
                    Assert.That(actualItems.Count, Is.EqualTo(expectedItems.Count), $"The number of elements in {key} is different.  Expected: {expectedItems.Count}, but was {actualItems.Count}.\nExpected: {expectedItems}\nActual: {actualItems}.");
                    for (int i = 0; i < expectedItems.Count; i++)
                    {
                        AssertJsonElementDeepEquals(expectedItems[i], actualItems[i], $"{key}/[{i}]");
                    }
                    break;
                case JsonValueKind.Number:
                    Assert.That(actual.GetInt64(), Is.EqualTo(expected.GetInt64()), $"Expected value for {key} is {expected}, but was {actual}.");
                    break;
                default:
                    ValidateAttributeValue(expected.GetString(), actual.GetString(), key);
                    break;
            }
        }
    }
}
