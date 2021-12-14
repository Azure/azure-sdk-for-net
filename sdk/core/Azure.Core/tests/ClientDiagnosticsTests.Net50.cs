// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
#if NET5_0_OR_GREATER
    public partial class ClientDiagnosticsTests
    {
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            ActivityExtensions.ResetFeatureSwitch();
        }

        private static TestAppContextSwitch SetAppConfigSwitch()
        {
            var s = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", "true");
            ActivityExtensions.ResetFeatureSwitch();
            return s;
        }

        [Test]
        [NonParallelizable]
        public void StartActivityNoOpsWithoutSwitch()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

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

                DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

                DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
                scope.AddAttribute("Attribute1", "Value1");
                scope.AddAttribute("Attribute2", 2, i => i.ToString());
                scope.AddAttribute("Attribute3", 3);

                scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00");
                scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", new Dictionary<string, string>()
                {
                    {"linkAttribute", "linkAttributeValue"}
                });

                Assert.IsTrue(scope.IsEnabled);

                scope.Start();
                scope.Dispose();

                Assert.AreEqual(1, activityListener.Activities.Count);
                var activity = activityListener.Activities.Dequeue();

                Assert.AreEqual("ClientName.ActivityName", activity.DisplayName);
                Assert.AreEqual("Value1", activity.TagObjects.Single(o => o.Key == "Attribute1").Value);
                Assert.AreEqual("2", activity.TagObjects.Single(o => o.Key == "Attribute2").Value);
                Assert.AreEqual("3", activity.TagObjects.Single(o => o.Key == "Attribute3").Value);

                var links = activity.Links.ToArray();
                Assert.AreEqual(2, links.Length);
                Assert.AreEqual(ActivityContext.Parse("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", null), links[0].Context);
                Assert.AreEqual(ActivityContext.Parse("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", null), links[1].Context);

                Assert.AreEqual(ActivityIdFormat.W3C, activity.IdFormat);
            }
            finally
            {
                Activity.DefaultIdFormat = oldDefault;
            }
        }

        [Test]
        public void CanSetActivitySourceAndDiagnosticSourceActivitiesTogether()
        {
            using var _ = SetAppConfigSwitch();

            using var testListener = new TestDiagnosticListener("Azure.Clients");
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

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

            Assert.Null(Activity.Current);
            Assert.AreEqual("ClientName.ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ClientName.ActivityName.Stop", stopEvent.Key);

            var diagnosticSourceActivity = (Activity) startEvent.Value;
            Assert.AreEqual(ActivityIdFormat.W3C, diagnosticSourceActivity.IdFormat);
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute3", "3"));

            Assert.AreEqual(activityAfterStart, diagnosticSourceActivity);
        }

        [Test]
        public void CanSetActivitySourceAttributesAfterStarting()
        {
            using var _ = SetAppConfigSwitch();

            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

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

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            scope.AddLink("test");

            scope.Start();
            scope.Dispose();

            Assert.AreEqual(0, activityListener.Activities.Single().Links.Count());
        }
    }
#endif
}
