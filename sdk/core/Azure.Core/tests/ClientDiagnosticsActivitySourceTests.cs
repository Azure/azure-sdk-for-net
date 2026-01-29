// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Core.Tests
{
    public class ClientDiagnosticsActivitySourceTests
    {
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            Pipeline.ActivityExtensions.ResetFeatureSwitch();
        }

        [Test]
        [NonParallelizable]
        public void ExperimentalStartsActivityNoOpsWithoutSwitchWithListener()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, false);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            Assert.That(scope.IsEnabled, Is.False);

            scope.Start();
            scope.Dispose();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(0));
        }

        [Test]
        [NonParallelizable]
        public void ExperimentalStartActivityNoOpsWithoutSwitch()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, false);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            scope.Start();
            scope.Dispose();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(0));
        }

        [Test]
        [NonParallelizable]
        public void StableStartsActivitySourceActivity()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            scope.SetDisplayName("custom display name");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.AddIntegerAttribute("Attribute3", 3);

            scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", "foo=bar");
            scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", null, new Dictionary<string, object>()
            {
                {"linkAttribute", "linkAttributeValue"}
            });

            Assert.That(scope.IsEnabled, Is.True);

            scope.Start();

            // Validate that the default activity kind is used
            Assert.That(Activity.Current.Kind, Is.EqualTo(ActivityKind.Internal));
            Assert.That(Activity.Current.DisplayName, Is.EqualTo("custom display name"));

            scope.Dispose();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(1));
            var activity = activityListener.Activities.Dequeue();

            Assert.That(activity.TagObjects.Single(o => o.Key == "Attribute1").Value, Is.EqualTo("Value1"));
            Assert.That(activity.TagObjects.Single(o => o.Key == "Attribute2").Value, Is.EqualTo("2"));
            Assert.That(activity.TagObjects.Single(o => o.Key == "Attribute3").Value, Is.EqualTo(3));

            var links = activity.Links.ToArray();
            Assert.That(links.Length, Is.EqualTo(2));
            Assert.That(links[0].Context, Is.EqualTo(ActivityContext.Parse("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", "foo=bar")));
            Assert.That(links[1].Context, Is.EqualTo(ActivityContext.Parse("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", null)));

            Assert.That(activity.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));

            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));
        }

        [Test]
        [NonParallelizable]
        public void StableStartsActivityShortNameSourceActivity()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ActivityName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            Assert.That(scope.IsEnabled, Is.True);

            scope.Start();
            scope.Dispose();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(1));
            var activity = activityListener.Activities.Dequeue();

            Assert.That(activity.DisplayName, Is.EqualTo("ActivityName"));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));
        }

        [Test]
        [NonParallelizable]
        public void DuplicateTagsAreUpdatedActivitySource()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ActivityName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.AddAttribute("key1", "value1");
            scope.AddAttribute("key1", "value2");

            scope.Start();
            scope.AddAttribute("key2", "value1");
            scope.AddAttribute("key2", "value2");

            scope.Dispose();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(1));
            var activity = activityListener.Activities.Dequeue();

            var key1 = activity.TagObjects.Where(kvp => kvp.Key == "key1").ToList();
            var key2 = activity.TagObjects.Where(kvp => kvp.Key == "key2").ToList();
            Assert.That(key1.Count, Is.EqualTo(1));
            Assert.That(key2.Count, Is.EqualTo(1));
            Assert.That(key1.Single().Value, Is.EqualTo("value2"));
            Assert.That(key2.Single().Value, Is.EqualTo("value2"));
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

            if (suppressNestedScopes.GetValueOrDefault(true))
            {
                Assert.That(nestedScope.IsEnabled, Is.False);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
                Assert.That(Activity.Current.DisplayName, Is.EqualTo("Activity Display Name"));
            }
            else
            {
                Assert.That(nestedScope.IsEnabled, Is.True);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
                Assert.That(Activity.Current.DisplayName, Is.EqualTo("Nested Activity Display Name"));
            }

            nestedScope.Dispose();
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            Assert.That(Activity.Current.Tags, Has.No.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));
        }

        [TestCase(ActivityKind.Internal, true)]
        [TestCase(ActivityKind.Server, false)]
        [TestCase(ActivityKind.Client, true)]
        [TestCase(ActivityKind.Producer, false)]
        [TestCase(ActivityKind.Consumer, false)]
        [NonParallelizable]
        public void NestedClientActivitiesSuppressed(int kind, bool expectSuppression)
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", (ActivityKind)kind);
            scope.Start();

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName", ActivityKind.Client);
            nestedScope.Start();
            if (expectSuppression)
            {
                Assert.That(nestedScope.IsEnabled, Is.False);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            }
            else
            {
                Assert.That(nestedScope.IsEnabled, Is.True);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
            }
            nestedScope.Dispose();
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            Assert.That(Activity.Current.Tags, Has.No.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));
        }

        [TestCase(ActivityKind.Internal, true)]
        [TestCase(ActivityKind.Server, false)]
        [TestCase(ActivityKind.Client, true)]
        [TestCase(ActivityKind.Producer, false)]
        [TestCase(ActivityKind.Consumer, false)]
        [NonParallelizable]
        public void NestedInternalActivitiesSuppressionActivitySource(int kind, bool expectSuppression)
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", (ActivityKind)kind);
            scope.Start();

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName", ActivityKind.Internal);
            nestedScope.Start();
            if (expectSuppression)
            {
                Assert.That(nestedScope.IsEnabled, Is.False);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            }
            else
            {
                Assert.That(nestedScope.IsEnabled, Is.True);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
            }
            nestedScope.Dispose();
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        [NonParallelizable]
        public void NestedActivitiesSuppressionConfiguration(bool suppressOuter, bool suppressNested)
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, suppressOuter, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();

            using var activityListener2 = new TestActivitySourceListener("Azure.Clients2.ClientName");
            DiagnosticScopeFactory clientDiagnostics2 = new DiagnosticScopeFactory("Azure.Clients2", "Microsoft.Azure.Core.Cool.Tests", true, suppressNested, true);
            DiagnosticScope nestedScope = clientDiagnostics2.CreateScope("ClientName.NestedActivityName");
            nestedScope.Start();

            if (suppressOuter && suppressNested)
            {
                Assert.That(nestedScope.IsEnabled, Is.False);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            }
            else
            {
                Assert.That(nestedScope.IsEnabled, Is.True);
                Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
            }
            nestedScope.Dispose();

            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            Assert.That(Activity.Current.Tags, Has.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));
            Assert.That(Activity.Current.Tags, Has.No.Member(new KeyValuePair<string, string>("kind", "internal")));
            scope.Dispose();
        }

        [Test]
        [NonParallelizable]
        public void NestedActivitiesOuterSampledOut()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.AddAttribute("sampled-out", "True");
            scope.Start();
            Assert.That(Activity.Current, Is.Null);

            using var activityListener2 = new TestActivitySourceListener("Azure.Clients2.ClientName");
            DiagnosticScopeFactory clientDiagnostics2 = new DiagnosticScopeFactory("Azure.Clients2", "Microsoft.Azure.Core.Cool.Tests", true, true, true);
            DiagnosticScope nestedScope = clientDiagnostics2.CreateScope("ClientName.NestedActivityName");
            nestedScope.Start();
            Assert.That(nestedScope.IsEnabled, Is.True);
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
            Assert.That(Activity.Current.Tags, Has.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));
            Assert.That(Activity.Current.Tags, Has.No.Member(new KeyValuePair<string, string>("kind", "internal")));
            nestedScope.Dispose();

            Assert.That(Activity.Current, Is.Null);
        }

        [Test]
        public void CanSetActivitySourceAndDiagnosticSourceActivitiesTogether()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activityAfterStart = Activity.Current;

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.AddIntegerAttribute("Attribute3", 3);
            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(1));

            var activitySourceActivity = activityListener.Activities.Dequeue();
            Assert.That(activitySourceActivity.TagObjects.Single(o => o.Key == "Attribute1").Value, Is.EqualTo("Value1"));
            Assert.That(activitySourceActivity.TagObjects.Single(o => o.Key == "Attribute2").Value, Is.EqualTo("2"));
            Assert.That(activitySourceActivity.TagObjects.Single(o => o.Key == "Attribute3").Value, Is.EqualTo(3));
            Assert.That(activitySourceActivity.Tags, Has.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));

            Assert.That(Activity.Current, Is.Null);
            Assert.That(startEvent.Key, Is.EqualTo("ClientName.ActivityName.Start"));
            Assert.That(stopEvent.Key, Is.EqualTo("ClientName.ActivityName.Stop"));

            var diagnosticSourceActivity = (Activity)startEvent.Value;
            Assert.That(diagnosticSourceActivity.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));
            Assert.That(diagnosticSourceActivity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute1", "Value1")));
            Assert.That(diagnosticSourceActivity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute2", "2")));

            // int attributes are returned by TagObjects, not Tags
            Assert.That(diagnosticSourceActivity.Tags.Where(kvp => kvp.Value == "Attribute3"), Is.Empty);

            // Since both ActivitySource and DiagnosticSource listeners are used, we should see the az.schema_url tag set even in diagnostic source because they use the same
            // underlying activity.
            Assert.That(diagnosticSourceActivity.Tags, Has.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));

            Assert.That(diagnosticSourceActivity, Is.EqualTo(activityAfterStart));
        }

        [Test]
        public void CanSetActivitySourceAttributesAfterStarting()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();
            scope.AddAttribute("name", "value");
            scope.Dispose();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(1));
            var activity = activityListener.Activities.Dequeue();
            Assert.That(activity.TagObjects.Single(o => o.Key == "name").Value, Is.EqualTo("value"));
        }

        [Test]
        [NonParallelizable]
        public void StartActivitySourceActivityDoesNotIgnoreInvalidLinkParent()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            var linkAttributes = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            scope.AddLink("test", "ignored", linkAttributes);

            scope.Start();
            scope.Dispose();

            var links = activityListener.Activities.Single().Links;
            Assert.That(links.Count(), Is.EqualTo(1));
            Assert.That(links.Single().Tags.Single(o => o.Key == "key").Value, Is.EqualTo("value"));
        }

        [Test]
        [NonParallelizable]
        public void TraceContextCanBeSetActivitySource()
        {
            string traceId = "6e76af18746bae4eadc3581338bbe8b1";
            string spanId = "2899ebfdbdce904b";
            string traceparent = $"00-{traceId}-{spanId}-01";
            string traceState = "state";
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false,
                true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.SetTraceContext(traceparent, traceState);
            scope.Start();
            scope.Dispose();

            Assert.That(activityListener.Activities.Count, Is.EqualTo(1));
            var activity = activityListener.Activities.Dequeue();
            Assert.That(activity.ParentId, Is.EqualTo(traceparent));
            Assert.That(activity.TraceId.ToString(), Is.EqualTo(traceId));
            Assert.That(activity.ParentSpanId.ToString(), Is.EqualTo(spanId));
            Assert.That(activity.TraceStateString, Is.EqualTo(traceState));
        }

        [Test]
        [NonParallelizable]
        public void TraceparentCannotBeSetOnStartedScopeActivitySource()
        {
            string traceparent = "00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00";
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false,
                true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();
            Assert.Throws<InvalidOperationException>(() => scope.SetTraceContext(traceparent));
        }

        [TestCase("foobar")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("00-00-00-00")]
        [TestCase("00-00000000000000000000000000000000-0000000000000000-00")]
        [NonParallelizable]
        public void InvalidContextDoesNotThrow(string traceparent)
        {
            using var testListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false,
                true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.SetTraceContext(traceparent, null);
            scope.Start();

            Assert.That(Activity.Current.ParentId, Is.Null);
            Assert.That(Activity.Current.TraceStateString, Is.Null);
        }

        [Test]
        [NonParallelizable]
        public void FailedStopsActivityAndWritesExceptionEventActivitySource()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false,
                true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());

            scope.Start();

            var activity = activityListener.AssertAndRemoveActivity("ClientName.ActivityName");
            Assert.That(activityListener.Activities, Is.Empty);

            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Unset));
            Assert.That(activity.StatusDescription, Is.Null);

            var exception = new Exception();
            scope.Failed(exception);
            scope.Dispose();

            Assert.That(Activity.Current, Is.Null);

            Assert.That(activity.StatusDescription, Is.EqualTo(exception.ToString()));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));

            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute1", "Value1")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute2", "2")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests")));
        }

        [Test]
        [NonParallelizable]
        public void OpenTelemetryCompatibilityWithAlwaysOffSampler()
        {
            // Open Telemetry Listener
            using TracerProvider OTelTracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource($"Azure.*")
                .SetSampler(new AlwaysOffSampler())
                .Build();

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, true);

            int activeActivityCounts = 0;
            for (int i = 0; i < 100; i++)
            {
                DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
                scope.AddAttribute("AttributeBeforeStart", "value");
                scope.Start();
                scope.AddAttribute("AttributeAfterStart", "value");

                Type type = scope.GetType();
                FieldInfo field = type.GetField("_activityAdapter", BindingFlags.NonPublic | BindingFlags.Instance);
                object activityadaptor = (object)field.GetValue(scope);

                Type type1 = activityadaptor.GetType();
                FieldInfo field1 = type1.GetField("_sampleOutActivity", BindingFlags.NonPublic | BindingFlags.Instance);
                Activity activity = (Activity)field1.GetValue(activityadaptor);

                Assert.That(activity.GetTagItem("AttributeAfterStart"), Is.Null);
                Assert.That(activity.GetTagItem("AttributeBeforeStart"), Is.Not.Null);

                if (Activity.Current.IsAllDataRequested)
                {
                    activeActivityCounts++;
                }
                scope.Dispose();
                Assert.That(Activity.Current, Is.Null);
            }

            Assert.That(activeActivityCounts, Is.EqualTo(0));
        }

        [Test]
        [NonParallelizable]
        public void OpenTelemetryCompatibilityWithCustomSampler()
        {
            // Open Telemetry Listener
            using TracerProvider OTelTracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource($"Azure.*")
                .SetSampler(new ParentBasedSampler(new CustomSampler()))
                .Build();

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, true);

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
                Assert.That(Activity.Current, Is.Null);
            }

            Assert.That(activeActivityCounts, Is.EqualTo(4)); // 1 activity will be dropped due to sampler logic
        }

        [Test]
        [NonParallelizable]
        public void FailedStopsActivityAndWritesErrorTypeException()
        {
            using var testListener = new TestActivitySourceListener("Azure.Clients.ActivityName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.Start();
            scope.Failed(new ArgumentException());

            Activity activity = testListener.AssertAndRemoveActivity("ActivityName");
            Assert.That(activity.Events, Is.Empty);
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("error.type", typeof(ArgumentException).FullName)));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
        }

        [Test]
        [NonParallelizable]
        public void FailedStopsActivityAndWritesErrorTypeRequestException()
        {
            using var testListener = new TestActivitySourceListener("Azure.Clients.ActivityName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.Start();
            scope.Failed(new RequestFailedException(400, "error", "errorCode", new HttpRequestException()));

            Activity activity = testListener.AssertAndRemoveActivity("ActivityName");
            Assert.That(activity.Events, Is.Empty);
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("error.type", "errorCode")));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
        }

        [Test]
        [NonParallelizable]
        public void FailedStopsActivityAndWritesErrorTypeString()
        {
            using var testListener = new TestActivitySourceListener("Azure.Clients.ActivityName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.Start();
            scope.Failed("errorCode");

            Activity activity = testListener.AssertAndRemoveActivity("ActivityName");
            Assert.That(activity.Events, Is.Empty);
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("error.type", "errorCode")));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
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
}
