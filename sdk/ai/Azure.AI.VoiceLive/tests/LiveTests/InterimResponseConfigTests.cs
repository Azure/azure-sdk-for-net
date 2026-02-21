// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Interim Response Configuration Tests
    ///
    /// These tests verify that interim response configurations can be properly set up
    /// without requiring actual session connections. Interim responses provide user
    /// feedback during latency or tool execution delays.
    /// </summary>
    public class InterimResponseConfigTests : VoiceLiveTestBase
    {
        public InterimResponseConfigTests() : base(true)
        {
        }

        public InterimResponseConfigTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        public void ShouldCreateStaticInterimResponseConfig()
        {
            // This test verifies that StaticInterimResponseConfig can be created and configured
            var config = new StaticInterimResponseConfig();

            config.Texts.Add("I'm working on that...");
            config.Texts.Add("Let me check...");
            config.Texts.Add("One moment please...");
            config.Triggers.Add(InterimResponseTrigger.Latency);
            config.Triggers.Add(InterimResponseTrigger.Tool);
            config.LatencyThresholdMs = 3000;

            Assert.AreEqual(3, config.Texts.Count);
            Assert.IsTrue(config.Texts.Contains("I'm working on that..."));
            Assert.IsTrue(config.Texts.Contains("Let me check..."));
            Assert.IsTrue(config.Texts.Contains("One moment please..."));

            Assert.AreEqual(2, config.Triggers.Count);
            Assert.IsTrue(config.Triggers.Contains(InterimResponseTrigger.Latency));
            Assert.IsTrue(config.Triggers.Contains(InterimResponseTrigger.Tool));

            Assert.AreEqual(3000, config.LatencyThresholdMs);

            TestContext.WriteLine("✓ StaticInterimResponseConfig created with static text responses");
        }

        [TestCase]
        public void ShouldCreateLlmInterimResponseConfig()
        {
            // This test verifies that LlmInterimResponseConfig can be created and configured
            var config = new LlmInterimResponseConfig
            {
                Model = "gpt-4",
                Instructions = "Generate brief, helpful interim responses that reassure the user while maintaining a professional tone.",
                MaxCompletionTokens = 50,
                LatencyThresholdMs = 2500
            };

            config.Triggers.Add(InterimResponseTrigger.Tool);
            config.Triggers.Add(InterimResponseTrigger.Latency);

            Assert.AreEqual("gpt-4", config.Model);
            Assert.AreEqual("Generate brief, helpful interim responses that reassure the user while maintaining a professional tone.", config.Instructions);
            Assert.AreEqual(50, config.MaxCompletionTokens);
            Assert.AreEqual(2500, config.LatencyThresholdMs);

            Assert.AreEqual(2, config.Triggers.Count);
            Assert.IsTrue(config.Triggers.Contains(InterimResponseTrigger.Tool));
            Assert.IsTrue(config.Triggers.Contains(InterimResponseTrigger.Latency));

            TestContext.WriteLine("✓ LlmInterimResponseConfig created with AI-generated responses");
        }

        [TestCase]
        public void ShouldCreateStaticInterimResponseConfigWithDefaultValues()
        {
            // This test verifies that StaticInterimResponseConfig has sensible defaults
            var config = new StaticInterimResponseConfig();

            Assert.IsNotNull(config.Texts);
            Assert.AreEqual(0, config.Texts.Count);
            Assert.IsNotNull(config.Triggers);
            Assert.AreEqual(0, config.Triggers.Count);
            Assert.IsNull(config.LatencyThresholdMs);

            TestContext.WriteLine("✓ StaticInterimResponseConfig has appropriate default values");
        }

        [TestCase]
        public void ShouldCreateLlmInterimResponseConfigWithDefaultValues()
        {
            // This test verifies that LlmInterimResponseConfig has sensible defaults
            var config = new LlmInterimResponseConfig();

            // Test default values
            Assert.IsNotNull(config.Triggers);
            Assert.AreEqual(0, config.Triggers.Count);
            Assert.IsNull(config.Model);
            Assert.IsNull(config.Instructions);
            Assert.IsNull(config.MaxCompletionTokens);
            Assert.IsNull(config.LatencyThresholdMs);

            TestContext.WriteLine("✓ LlmInterimResponseConfig has appropriate default values");
        }

        [TestCase]
        public void ShouldSupportInterimResponseTriggerTypes()
        {
            // This test verifies that InterimResponseTrigger enum values work correctly
            var latencyTrigger = InterimResponseTrigger.Latency;
            var toolTrigger = InterimResponseTrigger.Tool;

            Assert.AreEqual(InterimResponseTrigger.Latency, latencyTrigger);
            Assert.AreEqual(InterimResponseTrigger.Tool, toolTrigger);
            Assert.AreNotEqual(latencyTrigger, toolTrigger);

            Assert.AreEqual("latency", latencyTrigger.ToString());
            Assert.AreEqual("tool", toolTrigger.ToString());

            TestContext.WriteLine("✓ InterimResponseTrigger types work correctly");
        }

        [TestCase]
        public void ShouldConfigureInterimResponseForLatencyScenarios()
        {
            // This test verifies configuration for latency-based interim responses
            var config = new StaticInterimResponseConfig
            {
                LatencyThresholdMs = 1500
            };

            config.Triggers.Add(InterimResponseTrigger.Latency);
            config.Texts.Add("I'm thinking about your request...");
            config.Texts.Add("Processing your question...");

            Assert.AreEqual(1500, config.LatencyThresholdMs);
            Assert.AreEqual(1, config.Triggers.Count);
            Assert.AreEqual(InterimResponseTrigger.Latency, config.Triggers.First());
            Assert.AreEqual(2, config.Texts.Count);

            TestContext.WriteLine("✓ Interim response configured for latency scenarios");
        }

        [TestCase]
        public void ShouldConfigureInterimResponseForToolCallScenarios()
        {
            // This test verifies configuration for tool call interim responses
            var config = new LlmInterimResponseConfig
            {
                Model = "gpt-4-mini",
                Instructions = "Tell the user you're executing a tool to help them, be encouraging",
                MaxCompletionTokens = 30
            };

            config.Triggers.Add(InterimResponseTrigger.Tool);

            Assert.AreEqual("gpt-4-mini", config.Model);
            Assert.IsTrue(config.Instructions.Contains("executing a tool"));
            Assert.AreEqual(30, config.MaxCompletionTokens);
            Assert.AreEqual(1, config.Triggers.Count);
            Assert.AreEqual(InterimResponseTrigger.Tool, config.Triggers.First());

            TestContext.WriteLine("✓ Interim response configured for tool call scenarios");
        }

        [TestCase]
        public void ShouldSupportMultipleTriggers()
        {
            // This test verifies that configs can support multiple trigger types
            var staticConfig = new StaticInterimResponseConfig();
            staticConfig.Triggers.Add(InterimResponseTrigger.Latency);
            staticConfig.Triggers.Add(InterimResponseTrigger.Tool);
            staticConfig.Texts.Add("Working on it...");

            var llmConfig = new LlmInterimResponseConfig();
            llmConfig.Triggers.Add(InterimResponseTrigger.Latency);
            llmConfig.Triggers.Add(InterimResponseTrigger.Tool);

            Assert.AreEqual(2, staticConfig.Triggers.Count);
            Assert.AreEqual(2, llmConfig.Triggers.Count);

            foreach (var config in new InterimResponseConfigBase[] { staticConfig, llmConfig })
            {
                Assert.IsTrue(config.Triggers.Contains(InterimResponseTrigger.Latency));
                Assert.IsTrue(config.Triggers.Contains(InterimResponseTrigger.Tool));
            }

            TestContext.WriteLine("✓ Multiple triggers supported for interim responses");
        }

        [TestCase]
        public void ShouldValidateInterimResponseConfigProperties()
        {
            // This test verifies that interim response configs maintain property integrity
            var staticConfig = new StaticInterimResponseConfig();

            staticConfig.Texts.Add("Response 1");
            staticConfig.Texts.Add("Response 2");

            Assert.AreEqual(2, staticConfig.Texts.Count);
            Assert.AreEqual("Response 1", staticConfig.Texts[0]);
            Assert.AreEqual("Response 2", staticConfig.Texts[1]);

            staticConfig.LatencyThresholdMs = 5000;
            Assert.AreEqual(5000, staticConfig.LatencyThresholdMs);

            var llmConfig = new LlmInterimResponseConfig();
            llmConfig.Model = "test-model";
            llmConfig.Instructions = "test instructions";
            llmConfig.MaxCompletionTokens = 100;

            Assert.AreEqual("test-model", llmConfig.Model);
            Assert.AreEqual("test instructions", llmConfig.Instructions);
            Assert.AreEqual(100, llmConfig.MaxCompletionTokens);

            TestContext.WriteLine("✓ Interim response config properties maintain integrity");
        }
    }
}
