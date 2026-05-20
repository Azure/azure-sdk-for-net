// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI;
using Xunit;

using static Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI.MainAgentAttributeConstants;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MainAgentAttributionSpanProcessorTests
    {
        private static readonly ActivitySource s_activitySource = new("Test.MainAgentAttribution");

        [Fact]
        public void OnStart_NoParent_DoesNotAddAttributes()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var activity = new Activity("root");
            // No parent
            processor.OnStart(activity);

            Assert.Null(activity.GetTagItem(MainAgentName));
            Assert.Null(activity.GetTagItem(MainAgentId));
            Assert.Null(activity.GetTagItem(MainAgentVersion));
            Assert.Null(activity.GetTagItem(MainAgentConversationId));
        }

        [Fact]
        public void OnStart_ParentHasMainAgentAttrs_CopiedToChild()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var listener = CreateListener(processor);

            using var parent = s_activitySource.StartActivity("parent");
            Assert.NotNull(parent);
            parent!.SetTag(MainAgentName, "MainBot");
            parent.SetTag(MainAgentId, "main-123");
            parent.SetTag(MainAgentVersion, "2.0");
            parent.SetTag(MainAgentConversationId, "conv-abc");

            using var child = s_activitySource.StartActivity("child");
            Assert.NotNull(child);
            Assert.Equal("MainBot", child!.GetTagItem(MainAgentName));
            Assert.Equal("main-123", child.GetTagItem(MainAgentId));
            Assert.Equal("2.0", child.GetTagItem(MainAgentVersion));
            Assert.Equal("conv-abc", child.GetTagItem(MainAgentConversationId));
        }

        [Fact]
        public void OnStart_ParentHasFallbackAttrs_CopiedAsMainAgent()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var listener = CreateListener(processor);

            using var parent = s_activitySource.StartActivity("parent");
            Assert.NotNull(parent);
            parent!.SetTag(GenAiAgentName, "FallbackBot");
            parent.SetTag(GenAiAgentId, "fb-456");
            parent.SetTag(GenAiAgentVersion, "1.0");
            parent.SetTag(GenAiConversationId, "conv-xyz");

            using var child = s_activitySource.StartActivity("child");
            Assert.NotNull(child);
            Assert.Equal("FallbackBot", child!.GetTagItem(MainAgentName));
            Assert.Equal("fb-456", child.GetTagItem(MainAgentId));
            Assert.Equal("1.0", child.GetTagItem(MainAgentVersion));
            Assert.Equal("conv-xyz", child.GetTagItem(MainAgentConversationId));
        }

        [Fact]
        public void OnStart_ParentHasBothPrimaryAndFallback_PrimaryWins()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var listener = CreateListener(processor);

            using var parent = s_activitySource.StartActivity("parent");
            Assert.NotNull(parent);
            parent!.SetTag(MainAgentName, "PrimaryBot");
            parent.SetTag(GenAiAgentName, "FallbackBot");

            using var child = s_activitySource.StartActivity("child");
            Assert.NotNull(child);
            Assert.Equal("PrimaryBot", child!.GetTagItem(MainAgentName));
        }

        [Fact]
        public void OnEnd_InvokeAgentNoMainAttrs_CopiesFromSelf()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var activity = new Activity("invoke");
            activity.SetTag(GenAiOperationName, InvokeAgentOperationName);
            activity.SetTag(GenAiAgentName, "SelfBot");
            activity.SetTag(GenAiAgentId, "self-789");
            activity.SetTag(GenAiAgentVersion, "3.0");
            activity.SetTag(GenAiConversationId, "conv-self");

            processor.OnEnd(activity);

            Assert.Equal("SelfBot", activity.GetTagItem(MainAgentName));
            Assert.Equal("self-789", activity.GetTagItem(MainAgentId));
            Assert.Equal("3.0", activity.GetTagItem(MainAgentVersion));
            Assert.Equal("conv-self", activity.GetTagItem(MainAgentConversationId));
        }

        [Fact]
        public void OnStart_ChildAlreadyHasMainAgentAttrs_DoesNotOverwrite()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var listener = CreateListener(processor);

            using var parent = s_activitySource.StartActivity("parent");
            Assert.NotNull(parent);
            parent!.SetTag(MainAgentName, "ParentBot");
            parent.SetTag(MainAgentId, "parent-001");

            using var child = s_activitySource.StartActivity("child");
            Assert.NotNull(child);

            // Simulate child setting its own attrs before processor sees them.
            // In practice, the listener fires OnStart which runs before this,
            // so we validate that already-set attrs are preserved by the
            // per-attribute guard.
            child!.SetTag(MainAgentName, "ChildOverride");

            // Re-invoke processor manually to test the guard
            processor.OnStart(child);

            // Child's own value must be preserved
            Assert.Equal("ChildOverride", child.GetTagItem(MainAgentName));
            // Id was not set on child, so parent's value propagates
            Assert.Equal("parent-001", child.GetTagItem(MainAgentId));
        }

        [Fact]
        public void OnEnd_InvokeAgentPartialMainAttrs_FillsMissingOnly()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var activity = new Activity("invoke");
            activity.SetTag(GenAiOperationName, InvokeAgentOperationName);
            activity.SetTag(GenAiAgentName, "SelfBot");
            activity.SetTag(GenAiAgentId, "self-789");
            activity.SetTag(GenAiAgentVersion, "3.0");
            activity.SetTag(GenAiConversationId, "conv-self");

            // Pre-set only the name from parent propagation
            activity.SetTag(MainAgentName, "ParentBot");

            processor.OnEnd(activity);

            // Name should NOT be overwritten
            Assert.Equal("ParentBot", activity.GetTagItem(MainAgentName));
            // Missing attrs should be filled from gen_ai.agent.*
            Assert.Equal("self-789", activity.GetTagItem(MainAgentId));
            Assert.Equal("3.0", activity.GetTagItem(MainAgentVersion));
            Assert.Equal("conv-self", activity.GetTagItem(MainAgentConversationId));
        }

        [Fact]
        public void OnEnd_InvokeAgentAlreadyHasMainAttrs_DoesNotOverwrite()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var activity = new Activity("invoke");
            activity.SetTag(GenAiOperationName, InvokeAgentOperationName);
            activity.SetTag(GenAiAgentName, "ChildAgent");
            activity.SetTag(MainAgentName, "ParentAgent");

            processor.OnEnd(activity);

            // Should not overwrite existing main_agent attribute
            Assert.Equal("ParentAgent", activity.GetTagItem(MainAgentName));
        }

        [Fact]
        public void OnEnd_NonInvokeAgent_DoesNotCopy()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var activity = new Activity("other");
            activity.SetTag(GenAiOperationName, "chat");
            activity.SetTag(GenAiAgentName, "SomeBot");

            processor.OnEnd(activity);

            Assert.Null(activity.GetTagItem(MainAgentName));
        }

        [Fact]
        public void OnEnd_NoOperationName_DoesNotCopy()
        {
            var processor = new MainAgentAttributionSpanProcessor();

            using var activity = new Activity("other");
            activity.SetTag(GenAiAgentName, "SomeBot");

            processor.OnEnd(activity);

            Assert.Null(activity.GetTagItem(MainAgentName));
        }

        private static ActivityListener CreateListener(MainAgentAttributionSpanProcessor processor)
        {
            var listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == "Test.MainAgentAttribution",
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
                ActivityStarted = activity => processor.OnStart(activity),
                ActivityStopped = activity => processor.OnEnd(activity),
            };

            ActivitySource.AddActivityListener(listener);
            return listener;
        }
    }
}
