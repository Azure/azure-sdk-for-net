// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Azure.AI.Agents.Tests.Utilities
{
    public class GenAiTraceVerifier
    {
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
                    Console.WriteLine($"Attribute '{expected.Key}' value mismatch. Expected: {expected.Value}, Actual: {actualValue}");
                    return false;
                }
            }
            return true;
        }

        public bool CheckSpanEvents(Activity span, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents)
        {
            var spanEvents = span.Events.ToList();
            return CheckSpanEvents(spanEvents, expectedEvents);
        }

        public bool CheckSpanEvents(List<ActivityEvent> spanEvents, List<(string Name, Dictionary<string, object> Attributes)> expectedEvents, bool allowAdditionalEvents=false)
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
                    Console.WriteLine($"Event '{expectedEvent.Name}' attributes mismatch.");
                    return false;
                }

                spanEvents.Remove(matchingEvent);
            }

            if (spanEvents.Any() && !allowAdditionalEvents)
            {
                Console.WriteLine("Unexpected additional events found in span.");
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
                Console.WriteLine("Event attribute keys mismatch.");
                return false;
            }

            foreach (var key in expectedKeys)
            {
                if (!CheckAttributeValue(expected[key], actual[key]))
                {
                    Console.WriteLine($"Event attribute '{key}' value mismatch. Expected: {expected[key]}, Actual: {actual[key]}");
                    return false;
                }
            }

            return true;
        }

        private bool CheckAttributeValue(object expected, object actual)
        {
            if (expected is string expectedStr)
            {
                if (expectedStr == "*")
                {
                    return !string.IsNullOrEmpty(actual?.ToString());
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

        private bool IsValidJson(string json)
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
