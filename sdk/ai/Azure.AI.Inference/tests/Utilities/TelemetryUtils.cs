// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.Inference.Telemetry;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static Azure.AI.Inference.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Inference.Tests.Utilities
{
    internal static class TelemetryUtils
    {
        public static IDisposable ConfigureInstrumentation(bool enableOTel, bool enableContent)
        {
            IDisposable disposable = new CompositeDisposable(
                new TestAppContextSwitch(new() {
                    { EnableOpenTelemetrySwitch, enableOTel.ToString() },
                    { TraceContentsSwitch, enableContent.ToString() }
                }));

            OpenTelemetryScope.ResetEnvironmentForTests();
            return disposable;
        }

        private class CompositeDisposable : IDisposable
        {
            private readonly List<IDisposable> _disposables = new List<IDisposable>();

            public CompositeDisposable(params IDisposable[] disposables)
            {
                for (int i = 0; i < disposables.Length; i++)
                {
                    _disposables.Add(disposables[i]);
                }
            }

            public void Dispose()
            {
                foreach (IDisposable d in _disposables)
                {
                    d?.Dispose();
                }
            }
        }

        public static void AssertChoiceEventsAreEqual(object expected, string actual)
        {
            var expectedEvent = JsonSerializer.SerializeToNode(expected);
            var actualEvent = JsonNode.Parse(actual);

            Assert.That(actualEvent["index"].GetValue<int>(), Is.EqualTo(expectedEvent["index"].GetValue<int>()));
            Assert.That(actualEvent["finish_reason"]?.GetValue<string>(), Is.EqualTo(expectedEvent["finish_reason"]?.GetValue<string>()));

            JsonNode expectedMessage = expectedEvent["message"];
            JsonNode actualMessage = actualEvent["message"];
            Assert.That(actualMessage["content"]?.GetValue<string>(), Is.EqualTo(expectedMessage["content"]?.GetValue<string>()));

            if (expectedMessage["tool_calls"] != null)
            {
                JsonArray expectedTools = expectedMessage["tool_calls"].AsArray();
                JsonArray actualTools = actualMessage["tool_calls"].AsArray();

                Assert.That(actualTools.Count, Is.EqualTo(expectedTools.Count));
                for (int i = 0; i < expectedTools.Count; i++)
                {
                    Assert.That(actualTools[i]["id"].GetValue<string>(), Is.EqualTo(expectedTools[i]["id"].GetValue<string>()));
                    Assert.That(actualTools[i]["type"].GetValue<string>(), Is.EqualTo(expectedTools[i]["type"].GetValue<string>()));

                    JsonNode expectedFunction = expectedTools[i]["function"];
                    JsonNode actualFunction = actualTools[i]["function"];

                    Assert.That(actualFunction["name"].GetValue<string>(), Is.EqualTo(expectedFunction["name"].GetValue<string>()));
                    Assert.That(actualFunction["arguments"]?.GetValue<string>(), Is.EqualTo(expectedFunction["arguments"]?.GetValue<string>()));
                }
            }
        }
    }
}
