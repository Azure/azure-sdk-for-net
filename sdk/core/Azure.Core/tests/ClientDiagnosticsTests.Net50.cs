﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Core.Tests
{
#if NET5_0_OR_GREATER
    public partial class ClientDiagnosticsTests
    {
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            Pipeline.ActivityExtensions.ResetFeatureSwitch();
        }

        private static TestAppContextSwitch SetAppConfigSwitch()
        {
            var s = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", "true");
            Pipeline.ActivityExtensions.ResetFeatureSwitch();
            return s;
        }

        [Test]
        [NonParallelizable]
        public void StartActivityNoOpsWithoutSwitch()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            scope.Start();
            scope.Dispose();

            Assert.AreEqual(0, activityListener.Activities.Count);
        }

        [Test]
        [NonParallelizable]
        public void StartsActivitySourceActivity()
        {
            using var _ = SetAppConfigSwitch();

            // Bug: there is no way to set activity type to W3C
            // https://github.com/dotnet/runtime/issues/43853
            var oldDefault = Activity.DefaultIdFormat;

            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            try
            {
                using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

                DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false);

                DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

                scope.SetDisplayName("custom display name");

                scope.AddAttribute("Attribute1", "Value1");
                scope.AddAttribute("Attribute2", 2, i => i.ToString());
                scope.AddAttribute("Attribute3", 3);

                scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", "foo=bar");
                scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", null, new Dictionary<string, string>()
                {
                    {"linkAttribute", "linkAttributeValue"}
                });

                Assert.IsTrue(scope.IsEnabled);

                scope.Start();

                // Validate that the default activity kind is used
                Assert.AreEqual(ActivityKind.Internal, Activity.Current.Kind);
                Assert.AreEqual("custom display name", Activity.Current.DisplayName);

                scope.Dispose();

                Assert.AreEqual(1, activityListener.Activities.Count);
                var activity = activityListener.Activities.Dequeue();

                Assert.AreEqual("Value1", activity.TagObjects.Single(o => o.Key == "Attribute1").Value);
                Assert.AreEqual("2", activity.TagObjects.Single(o => o.Key == "Attribute2").Value);
                Assert.AreEqual("3", activity.TagObjects.Single(o => o.Key == "Attribute3").Value);

                var links = activity.Links.ToArray();
                Assert.AreEqual(2, links.Length);
                Assert.AreEqual(ActivityContext.Parse("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", "foo=bar"), links[0].Context);
                Assert.AreEqual(ActivityContext.Parse("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", null), links[1].Context);

                Assert.AreEqual(ActivityIdFormat.W3C, activity.IdFormat);

                CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));
            }
            finally
            {
                Activity.DefaultIdFormat = oldDefault;
            }
        }

        [Test]
        [NonParallelizable]
        public void StartsActivityShortNameSourceActivity()
        {
            using var _ = SetAppConfigSwitch();

            // Bug: there is no way to set activity type to W3C
            // https://github.com/dotnet/runtime/issues/43853
            var oldDefault = Activity.DefaultIdFormat;

            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            try
            {
                using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

                DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients.ClientName", "Microsoft.Azure.Core.Cool.Tests", true, false);

                DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
                Assert.IsTrue(scope.IsEnabled);

                scope.Start();
                scope.Dispose();

                Assert.AreEqual(1, activityListener.Activities.Count);
                var activity = activityListener.Activities.Dequeue();

                Assert.AreEqual("ActivityName", activity.DisplayName);
                CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));
            }
            finally
            {
                Activity.DefaultIdFormat = oldDefault;
            }
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [NonParallelizable]
        public void NestedClientActivitiesConfigurationClientOptions(bool? suppressNestedScopes)
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticsOptions testOptions = new DiagnosticsOptions();

            ClientDiagnostics clientDiagnostics = new ClientDiagnostics("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", testOptions, suppressNestedScopes);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.SetDisplayName("Activity Display Name");
            scope.Start();

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName");
            nestedScope.SetDisplayName("Nested Activity Display Name");
            nestedScope.Start();

            if (suppressNestedScopes.GetValueOrDefault(false))
            {
                Assert.IsFalse(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
                Assert.AreEqual("Activity Display Name", Activity.Current.DisplayName);
            }
            else
            {
                Assert.IsTrue(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
                Assert.AreEqual("Nested Activity Display Name", Activity.Current.DisplayName);
            }

            nestedScope.Dispose();
            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            CollectionAssert.DoesNotContain(Activity.Current.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));
        }

        [TestCase(DiagnosticScope.ActivityKind.Internal, true)]
        [TestCase(DiagnosticScope.ActivityKind.Server, false)]
        [TestCase(DiagnosticScope.ActivityKind.Client, true)]
        [TestCase(DiagnosticScope.ActivityKind.Producer, false)]
        [TestCase(DiagnosticScope.ActivityKind.Consumer, false)]
        [NonParallelizable]
        public void NestedClientActivitiesSuppressed(int kind, bool expectSuppression)
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", (DiagnosticScope.ActivityKind)kind);
            scope.Start();

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName", (DiagnosticScope.ActivityKind)kind);
            nestedScope.Start();
            if (expectSuppression)
            {
                Assert.IsFalse(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            }
            else
            {
                Assert.IsTrue(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
            }
            nestedScope.Dispose();
            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            CollectionAssert.DoesNotContain(Activity.Current.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));
        }

        [TestCase(DiagnosticScope.ActivityKind.Internal, true)]
        [TestCase(DiagnosticScope.ActivityKind.Server, false)]
        [TestCase(DiagnosticScope.ActivityKind.Client, true)]
        [TestCase(DiagnosticScope.ActivityKind.Producer, false)]
        [TestCase(DiagnosticScope.ActivityKind.Consumer, false)]
        [NonParallelizable]
        public void NestedClientActivitiesSuppressionActivitySource(int kind, bool expectSuppression)
        {
            using var _ = SetAppConfigSwitch();
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", (DiagnosticScope.ActivityKind)kind);
            scope.Start();

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName", (DiagnosticScope.ActivityKind)kind);
            nestedScope.Start();
            if (expectSuppression)
            {
                Assert.IsFalse(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            }
            else
            {
                Assert.IsTrue(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
            }
            nestedScope.Dispose();
            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
        }

        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, true)]
        [TestCase(false, false, false)]
        [NonParallelizable]
        public void NestedActivitiesSuppressionConfiguration(bool suppressOuter, bool suppressNested, bool expectSuppression)
        {
            using var _ = SetAppConfigSwitch();
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, suppressOuter);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();

            using var activityListener2 = new TestActivitySourceListener("Azure.Clients2.ClientName");
            DiagnosticScopeFactory clientDiagnostics2 = new DiagnosticScopeFactory("Azure.Clients2", "Microsoft.Azure.Core.Cool.Tests", true, suppressNested);
            DiagnosticScope nestedScope = clientDiagnostics2.CreateScope("ClientName.NestedActivityName");
            nestedScope.Start();

            if (expectSuppression)
            {
                Assert.IsFalse(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            }
            else
            {
                Assert.IsTrue(nestedScope.IsEnabled);
                Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
            }
            nestedScope.Dispose();

            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            CollectionAssert.Contains(Activity.Current.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));
            CollectionAssert.DoesNotContain(Activity.Current.Tags, new KeyValuePair<string, string>("kind", "internal"));
            scope.Dispose();
        }

        [Test]
        [NonParallelizable]
        public void NestedActivitiesOuterSampledOut()
        {
            using var _ = SetAppConfigSwitch();
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.AddAttribute("sampled-out", true);
            scope.Start();
            Assert.IsNull(Activity.Current);

            using var activityListener2 = new TestActivitySourceListener("Azure.Clients2.ClientName");
            DiagnosticScopeFactory clientDiagnostics2 = new DiagnosticScopeFactory("Azure.Clients2", "Microsoft.Azure.Core.Cool.Tests", true, true);
            DiagnosticScope nestedScope = clientDiagnostics2.CreateScope("ClientName.NestedActivityName");
            nestedScope.Start();
            Assert.IsTrue(nestedScope.IsEnabled);
            Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
            CollectionAssert.Contains(Activity.Current.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));
            CollectionAssert.DoesNotContain(Activity.Current.Tags, new KeyValuePair<string, string>("kind", "internal"));
            nestedScope.Dispose();

            Assert.IsNull(Activity.Current);
        }

        [Test]
        public void CanSetActivitySourceAndDiagnosticSourceActivitiesTogether()
        {
            using var _ = SetAppConfigSwitch();

            using var testListener = new TestDiagnosticListener("Azure.Clients");
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activityAfterStart = Activity.Current;

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.AddAttribute("Attribute3", 3);
            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.AreEqual(1, activityListener.Activities.Count);

            var activitySourceActivity = activityListener.Activities.Dequeue();
            Assert.AreEqual("Value1", activitySourceActivity.TagObjects.Single(o => o.Key == "Attribute1").Value);
            Assert.AreEqual("2", activitySourceActivity.TagObjects.Single(o => o.Key == "Attribute2").Value);
            Assert.AreEqual("3", activitySourceActivity.TagObjects.Single(o => o.Key == "Attribute3").Value);
            CollectionAssert.Contains(activitySourceActivity.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));

            Assert.Null(Activity.Current);
            Assert.AreEqual("ClientName.ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ClientName.ActivityName.Stop", stopEvent.Key);

            var diagnosticSourceActivity = (Activity) startEvent.Value;
            Assert.AreEqual(ActivityIdFormat.W3C, diagnosticSourceActivity.IdFormat);
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute3", "3"));

            // Since both ActivitySource and DiagnosticSource listeners are used, we should see the az.schema_url tag set even in diagnostic source because they use the same
            // underlying activity.
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion));

            Assert.AreEqual(activityAfterStart, diagnosticSourceActivity);
        }

        [Test]
        public void CanSetActivitySourceAttributesAfterStarting()
        {
            using var _ = SetAppConfigSwitch();

            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();
            scope.AddAttribute("name", "value");
            scope.Dispose();

            Assert.AreEqual(1, activityListener.Activities.Count);
            var activity = activityListener.Activities.Dequeue();
            Assert.AreEqual("value", activity.TagObjects.Single(o => o.Key == "name").Value);
        }

        [Test]
        [NonParallelizable]
        public void StartActivitySourceActivityIgnoresInvalidLinkParent()
        {
            using var _ = SetAppConfigSwitch();

            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            scope.AddLink("test", "ignored");

            scope.Start();
            scope.Dispose();

            Assert.AreEqual(0, activityListener.Activities.Single().Links.Count());
        }

        [Test]
        [NonParallelizable]
        public void ParentIdCanBeSetActivitySource()
        {
            using var _ = SetAppConfigSwitch();
            string parentId = "00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00";
            string traceState = "state";
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients.ClientName",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.SetTraceContext(parentId, traceState);
            scope.Start();
            scope.Dispose();

            Assert.AreEqual(1, activityListener.Activities.Count);
            var activity = activityListener.Activities.Dequeue();
            Assert.AreEqual(parentId, activity.ParentId);
            Assert.AreEqual(traceState, activity.TraceStateString);
        }

        [Test]
        [NonParallelizable]
        public void ParentIdCannotBeSetOnStartedScopeActivitySource()
        {
            using var _ = SetAppConfigSwitch();
            string parentId = "00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00";
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients.ClientName",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.Start();
            Assert.Throws<InvalidOperationException>(() => scope.SetTraceContext(parentId));
        }

        [Test]
        [NonParallelizable]
        public void FailedStopsActivityAndWritesExceptionEventActivitySource()
        {
            using var _ = SetAppConfigSwitch();
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients.ClientName",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());

            scope.Start();

            var activity = activityListener.AssertAndRemoveActivity("ActivityName");
            Assert.IsEmpty(activityListener.Activities);

            Assert.AreEqual(ActivityStatusCode.Unset, activity.Status);
            Assert.IsNull(activity.StatusDescription);

            var exception = new Exception();
            scope.Failed(exception);
            scope.Dispose();

            Assert.Null(Activity.Current);

            Assert.AreEqual(exception.ToString(), activity.StatusDescription);
            Assert.AreEqual(ActivityStatusCode.Error, activity.Status);

            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests"));
        }

        [Test]
        [NonParallelizable]
        public void OpenTelemetryCompatibilityWithAlwaysOffSampler()
        {
            using var _ = SetAppConfigSwitch();

            // Open Telemetry Listener
            using TracerProvider OTelTracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource($"Azure.*")
                .SetSampler(new AlwaysOffSampler())
                .Build();

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true);

            int activeActivityCounts = 0;
            for (int i = 0; i < 100; i++)
            {
                DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
                scope.Start();
                if (Activity.Current.IsAllDataRequested)
                {
                    activeActivityCounts++;
                }
                scope.Dispose();
                Assert.IsNull(Activity.Current);
            }

            Assert.AreEqual(0, activeActivityCounts);
        }

        [Test]
        [NonParallelizable]
        public void OpenTelemetryCompatibilityWithCustomSampler()
        {
            using var _ = SetAppConfigSwitch();

            // Open Telemetry Listener
            using TracerProvider OTelTracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource($"Azure.*")
                .SetSampler(new ParentBasedSampler(new CustomSampler()))
                .Build();

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true);

            int activeActivityCounts = 0;
            for (int i = 0; i < 5; i++)
            {
                DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
                scope.AddLink($"00-6e76af18746bae4eadc3581338bbe8b{i}-2899ebfdbdce904b-00", "foo=bar");

                scope.Start();
                if (Activity.Current.IsAllDataRequested)
                {
                    activeActivityCounts++;
                }
                scope.Dispose();
                Assert.IsNull(Activity.Current);
            }

            Assert.AreEqual(4, activeActivityCounts); // 1 activity will be dropped due to sampler logic
        }

        private class CustomSampler : Sampler
        {
            public override SamplingResult ShouldSample(in SamplingParameters samplingParameters)
            {
                if (samplingParameters.Links.First().Context.TraceId.ToString() == "6e76af18746bae4eadc3581338bbe8b1")
                {
                    return new SamplingResult(SamplingDecision.Drop);
                }

                return new SamplingResult(SamplingDecision.RecordAndSample);
            }
        }
    }
#endif
}
