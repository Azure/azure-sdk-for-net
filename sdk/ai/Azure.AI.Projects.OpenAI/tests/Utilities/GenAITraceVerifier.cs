// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.Projects.OpenAI.Tests.Utilities
{
    public class GenAiTraceVerifier
    {
        public static void ValidateSpanAttributes(Activity span, Dictionary<string, object> expectedAttributes, bool allowUnexpected = true)
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

            if (!allowUnexpected)
            {
                var unexpectedAttributes = actualAttributes.Keys.Except(expectedAttributes.Keys).ToList();
                Assert.That(unexpectedAttributes, Is.Empty,
                    $"Found unexpected attributes in span: {string.Join(", ", unexpectedAttributes)}");
            }
        }

        public bool CheckSpanAttributes(Activity span, Dictionary<string, object> expectedAttributes)
        {
            var actualAttributes = new Dictionary<string, object>();
            foreach (var tag in span.EnumerateTagObjects())
            {
                actualAttributes[tag.Key] = tag.Value;
            }

            foreach (var expected in expectedAttributes)
            {
                if (!actualAttributes.ContainsKey(expected.Key))
                {
                    Console.WriteLine($"Attribute '{expected.Key}' not found in span.");
                    return false;
                }

                var actualValue = actualAttributes[expected.Key];
                if (!CheckAttributeValue(expected.Value, actualValue))
                {
                    Console.WriteLine($"Attribute '{expected.Key}': expected '{expected.Value}', got '{actualValue}'");
                    return false;
                }
            }

            return true;
        }

        public static void ValidateSpanEvents(Activity span, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents)
        {
            var spanEvents = span.Events.ToList();
            ValidateSpanEvents(spanEvents, expectedEvents);
        }

        public static void ValidateSpanEvents(List<ActivityEvent> spanEvents, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents, bool allowAdditionalEvents = false)
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

        public bool CheckSpanEvents(Activity span, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents)
        {
            var spanEvents = span.Events.ToList();
            return CheckSpanEvents(spanEvents, expectedEvents);
        }

        public bool CheckSpanEvents(List<ActivityEvent> spanEvents, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents, bool allowAdditionalEvents = false)
        {
            foreach (var expectedEvent in expectedEvents)
            {
                var matchingEvent = spanEvents.FirstOrDefault(e => e.Name == expectedEvent.Name);
                if (matchingEvent.Name == null)
                {
                    Console.WriteLine($"Event '{expectedEvent.Name}' not found.");
                    return false;
                }

                var actualEventAttributes = new Dictionary<string, object>();
                foreach (var tag in matchingEvent.EnumerateTagObjects())
                {
                    actualEventAttributes[tag.Key] = tag.Value;
                }

                if (!CheckEventAttributes(expectedEvent.Attributes, actualEventAttributes))
                {
                    return false;
                }
                spanEvents.Remove(matchingEvent);
            }

            if (spanEvents.Any() && !allowAdditionalEvents)
            {
                Console.WriteLine($"Unexpected additional events found in span.");
                return false;
            }
            return true;
        }

        public bool CheckEventAttributes(Dictionary<string, object> expected, Dictionary<string, object> actual)
        {
            var expectedKeys = new HashSet<string>(expected.Keys);
            var actualKeys = new HashSet<string>(actual.Keys);

            if (!expectedKeys.SetEquals(actualKeys))
            {
                return false;
            }
            foreach (var key in expectedKeys)
            {
                if (!CheckAttributeValue(expected[key], actual[key]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void ValidateAttributeValue(object expected, object actual, string key)
        {
            if (expected is string expectedStr)
            {
                if (expectedStr == "*")
                {
                    Assert.That(actual, Is.Not.Null, $"The value for {key} is expected to be {actual} but was null.");
                    Assert.That(actual, Is.Not.Empty, $"The value for {key} is expected to be {actual} but was empty.");
                }
                else if (expectedStr == "+")
                {
                    if (double.TryParse(actual?.ToString(), out double numericValue))
                    {
                        Assert.That(numericValue, Is.GreaterThanOrEqualTo(0), $"The value for {key} is expected to be more then 0, but was {numericValue}");
                        return;
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

        private bool CheckAttributeValue(object expected, object actual)
        {
            if (expected is string expectedStr)
            {
                if (expectedStr == "*")
                {
                    return actual != null && !string.IsNullOrEmpty(actual.ToString());
                }
                if (expectedStr == "+")
                {
                    if (double.TryParse(actual?.ToString(), out double numericValue))
                    {
                        return numericValue >= 0;
                    }
                    return false;
                }
                if (IsValidJson(expectedStr) && IsValidJson(actual?.ToString()))
                {
                    return CheckJsonString(expectedStr, actual.ToString());
                }
                return expectedStr == actual?.ToString();
            }
            else if (expected is Dictionary<string, object> expectedDict)
            {
                if (actual is string actualStr && IsValidJson(actualStr))
                {
                    var actualDict = JsonSerializer.Deserialize<Dictionary<string, object>>(actualStr);
                    return CheckEventAttributes(expectedDict, actualDict);
                }
                return false;
            }
            else if (expected is IEnumerable<object> expectedList)
            {
                if (actual is string actualStr && IsValidJson(actualStr))
                {
                    var actualList = JsonSerializer.Deserialize<List<object>>(actualStr);
                    return expectedList.SequenceEqual(actualList);
                }
                return false;
            }
            else
            {
                return expected.Equals(actual);
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

        private bool CheckJsonString(string expectedJson, string actualJson)
        {
            try
            {
                var expectedDoc = JsonDocument.Parse(expectedJson);
                var actualDoc = JsonDocument.Parse(actualJson);
                return JsonElementDeepEquals(expectedDoc.RootElement, actualDoc.RootElement);
            }
            catch
            {
                return false;
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
                    Assert.That(actualProps.Count, Is.EqualTo(expectedProps.Count), $"The number of properties for {key} was different. Expected: {expectedProps.Count}, but was {actualProps.Count}.\nExpected: {expectedProps}\nActual: {actualProps}.");
                    for (int i = 0; i < expectedProps.Count; i++)
                    {
                        Assert.That(actualProps[i].Name, Is.EqualTo(expectedProps[i].Name), $"The {i}-th property of {key} is named {actualProps[i].Name} but expected property is {expectedProps[i].Name}");
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

        private bool JsonElementDeepEquals(JsonElement expected, JsonElement actual)
        {
            if (expected.ValueKind != actual.ValueKind)
                return false;

            switch (expected.ValueKind)
            {
                case JsonValueKind.Object:
                    var expectedProps = expected.EnumerateObject().OrderBy(p => p.Name).ToList();
                    var actualProps = actual.EnumerateObject().OrderBy(p => p.Name).ToList();
                    if (expectedProps.Count != actualProps.Count)
                        return false;
                    for (int i = 0; i < expectedProps.Count; i++)
                    {
                        if (expectedProps[i].Name != actualProps[i].Name ||
                            !JsonElementDeepEquals(expectedProps[i].Value, actualProps[i].Value))
                            return false;
                    }
                    return true;

                case JsonValueKind.Array:
                    var expectedItems = expected.EnumerateArray().ToList();
                    var actualItems = actual.EnumerateArray().ToList();
                    if (expectedItems.Count != actualItems.Count)
                        return false;
                    for (int i = 0; i < expectedItems.Count; i++)
                    {
                        if (!JsonElementDeepEquals(expectedItems[i], actualItems[i]))
                            return false;
                    }
                    return true;
                case JsonValueKind.Number:
                    return expected.GetInt64() == actual.GetInt64();
                default:
                    return CheckAttributeValue(expected.GetString(), actual.GetString());
            }
        }
    }
}
