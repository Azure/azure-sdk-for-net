// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

[assembly:AzureResourceProviderNamespace("Microsoft.Azure.Core.Cool.Tests")]

namespace Azure.Core.Tests
{
    public class ClientDiagnosticsTests
    {
        [Test]
        public void CreatesActivityWithNameAndTags()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.AddAttribute("Attribute3", 3);

            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);

            Assert.AreEqual(ActivityIdFormat.W3C, activity.IdFormat);
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute3", "3"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests"));
        }

        [Test]
        public void ResourceNameIsOptional()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", null, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);

            Assert.AreEqual(ActivityIdFormat.W3C, activity.IdFormat);
        }

        [Test]
        public void AddLinkCallsPassesLinksAsPartOfStartPayload()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests",true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00");
            scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00");
            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);

            var activities = (IEnumerable<Activity>)startEvent.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(startEvent.Value);
            Activity[] activitiesArray = activities.ToArray();

            Assert.AreEqual(activitiesArray.Length, 2);

            Activity linkedActivity1 = activitiesArray[0];
            Activity linkedActivity2 = activitiesArray[1];

            Assert.AreEqual(ActivityIdFormat.W3C, linkedActivity1.IdFormat);
            Assert.AreEqual("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", linkedActivity1.ParentId);

            Assert.AreEqual(ActivityIdFormat.W3C, linkedActivity2.IdFormat);
            Assert.AreEqual("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", linkedActivity2.ParentId);

            Assert.AreEqual(0, testListener.Events.Count);
        }

        [Test]
        public void AddLinkCreatesLinkedActivityWithTags()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            var expectedTags = new Dictionary<string, string>()
            {
                {"key1", "value1"},
                {"key2", "value2"}
            };

            scope.AddLink("id", expectedTags);
            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);

            var activities = (IEnumerable<Activity>)startEvent.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(startEvent.Value);
            Activity linkedActivity = activities.Single();

            Assert.AreEqual(ActivityIdFormat.W3C, linkedActivity.IdFormat);
            Assert.AreEqual("id", linkedActivity.ParentId);

            CollectionAssert.AreEquivalent(expectedTags, linkedActivity.Tags);
        }

        [Test]
        public void FailedStopsActivityAndWritesExceptionEvent()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());

            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            var exception = new Exception();
            scope.Failed(exception);
            scope.Dispose();

            (string Key, object Value, DiagnosticListener) exceptionEvent = testListener.Events.Dequeue();
            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Exception", exceptionEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);
            Assert.AreEqual(exception, exceptionEvent.Value);
            Assert.AreEqual(0, testListener.Events.Count);

            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests"));
        }

        [Test]
        [NonParallelizable]
        public void StartsActivitySourceActivity()
        {
            // Bug: there is no way to set activity type to W3C
            // https://github.com/dotnet/runtime/issues/43853
            var oldDefault = Activity.DefaultIdFormat;

            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            try
            {
                using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

                DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", true);

                DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
                scope.AddAttribute("Attribute1", "Value1");
                scope.AddAttribute("Attribute2", 2, i => i.ToString());
                scope.AddAttribute("Attribute3", 3);

                scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00");
                scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", new Dictionary<string, string>()
                {
                    { "linkAttribute", "linkAttributeValue" }
                });

                Assert.IsTrue(scope.IsEnabled);

                scope.Start();
                scope.Dispose();

                Assert.AreEqual(1, activityListener.Activities.Count);
                var activity = activityListener.Activities.Dequeue();

                Assert.AreEqual("ActivityName", activity.DisplayName);
                Assert.AreEqual("Value1", activity.TagObjects.Single(o=> o.Key == "Attribute1").Value);
                Assert.AreEqual(2, activity.TagObjects.Single(o=> o.Key == "Attribute2").Value);
                Assert.AreEqual(3, activity.TagObjects.Single(o=> o.Key == "Attribute3").Value);
                Assert.AreEqual(0, activity.TagObjects.Count(o=> o.Key == "otel.status_code"));

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
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", true);

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
            Assert.AreEqual("Value1", activitySourceActivity.TagObjects.Single(o=> o.Key == "Attribute1").Value);
            Assert.AreEqual(2, activitySourceActivity.TagObjects.Single(o=> o.Key == "Attribute2").Value);
            Assert.AreEqual(3, activitySourceActivity.TagObjects.Single(o=> o.Key == "Attribute3").Value);

            Assert.Null(Activity.Current);
            Assert.AreEqual("ClientName.ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ClientName.ActivityName.Stop", stopEvent.Key);

            var diagnosticSourceActivity = (Activity) startEvent.Value;
            Assert.AreEqual(ActivityIdFormat.W3C, diagnosticSourceActivity.IdFormat);
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));
            CollectionAssert.Contains(diagnosticSourceActivity.Tags, new KeyValuePair<string, string>("Attribute3", "3"));

            Assert.AreEqual(activityAfterStart, activitySourceActivity);
        }

        [Test]
        public void CanSetActivitySourceAttributesAfterStarting()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();
            scope.AddAttribute("name", "value");
            scope.Dispose();

            Assert.AreEqual(1, activityListener.Activities.Count);
            var activity = activityListener.Activities.Dequeue();
            Assert.AreEqual("value", activity.TagObjects.Single(o=> o.Key == "name").Value);
        }

        [Test]
        public void StartsActivitySourceActivityAndMarksFailed()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();
            scope.Failed(new Exception());
            scope.Dispose();

            Assert.AreEqual(1, activityListener.Activities.Count);
            var activity = activityListener.Activities.Dequeue();
            Assert.AreEqual(1, activity.TagObjects.Single(o=> o.Key == "otel.status_code").Value);
            Assert.AreEqual("Exception of type 'System.Exception' was thrown.", activity.TagObjects.Single(o=> o.Key == "otel.status_description").Value);
        }

        [Test]
        [NonParallelizable]
        public void StartActivitySourceActivityIgnoresInvalidLinkParent()
        {
            using var activityListener = new TestActivitySourceListener("Azure.Clients.ClientName");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");

            scope.AddLink("LALALA");

            scope.Start();
            scope.Dispose();

            Assert.AreEqual(0, activityListener.Activities.Single().Links.Count());
        }

        [Test]
        public void NoopsWhenDisabled()
        {
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", false);
            DiagnosticScope scope = clientDiagnostics.CreateScope("");

            Assert.IsFalse(scope.IsEnabled);

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.Failed(new Exception());
            scope.Dispose();
        }

        [Test]
        public void GetResourceProviderNamespaceReturnsAttributeValue()
        {
            Assert.AreEqual("Microsoft.Azure.Core.Cool.Tests", ClientDiagnostics.GetResourceProviderNamespace(GetType().Assembly));
        }

        [Test]
        public void CreatesASingleListenerPerNamespace()
        {
            using var testListener = new TestDiagnosticListener(l => l.Name.StartsWith("Azure.Clients."));

            _ = new DiagnosticScopeFactory("Azure.Clients.1",  "Microsoft.Azure.Core.Cool.Tests", true);
            _ = new DiagnosticScopeFactory("Azure.Clients.1",  "Microsoft.Azure.Core.Cool.Tests", true);
            _ = new DiagnosticScopeFactory("Azure.Clients.2",  "Microsoft.Azure.Core.Cool.Tests", true);

            Assert.AreEqual(2, testListener.Sources.Count);
        }
    }
}
