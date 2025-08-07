// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

[assembly: AzureResourceProviderNamespace("Microsoft.Azure.Core.Cool.Tests")]

namespace Azure.Core.Tests
{
    public partial class ClientDiagnosticsDiagnosticSourceTests
    {
        [Test]
        public void CreatesActivityWithNameAndTags()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.AddIntegerAttribute("Attribute3", 3);

            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);

            Assert.AreEqual(ActivityIdFormat.W3C, activity.IdFormat);
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("kind", "internal"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));

            // int attributes not supported
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, object>("Attribute3", "3"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests"));
        }

        [Test]
        public void ActivityDurationIsNotZeroWhenStopping()
        {
            TimeSpan? duration = null;
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            testListener.EventCallback = _ => { duration = Activity.Current?.Duration; };

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.Start();

            Thread.Sleep(50);

            scope.Dispose();

            Assert.True(duration > TimeSpan.Zero);
        }

        [Test]
        public void ActivityStartTimeCanBeSet()
        {
            DateTime? actualStartTimeUtc = null;
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            testListener.EventCallback = _ => { actualStartTimeUtc = Activity.Current?.StartTimeUtc; };

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            DateTime expectedStartTimeUtc = DateTime.UtcNow - TimeSpan.FromSeconds(10);
            scope.SetStartTime(expectedStartTimeUtc);
            scope.Start();
            scope.Dispose();

            Assert.AreEqual(expectedStartTimeUtc, actualStartTimeUtc);
        }

        [Test]
        public void ParentIdCanBeSet()
        {
            string parentId = "parentId";
            string tracestate = "state";
            using var testListener = new TestDiagnosticListener("Azure.Clients");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false,
                false);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.SetTraceContext(parentId, tracestate);
            scope.Start();

            Assert.AreEqual(parentId, Activity.Current.ParentId);
            Assert.AreEqual(tracestate, Activity.Current.TraceStateString);
        }

        [Test]
        public void ParentIdCannotBeSetOnStartedScope()
        {
            string parentId = "parentId";
            using var testListener = new TestDiagnosticListener("Azure.Clients");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory(
                "Azure.Clients",
                "Microsoft.Azure.Core.Cool.Tests",
                true,
                false,
                false);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");
            scope.Start();
            Assert.Throws<InvalidOperationException>(() => scope.SetTraceContext(parentId));
        }

        [Test]
        public void ResourceNameIsOptional()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", null, true, false, true);

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
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.SetDisplayName("Custom Display Name");

            scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", "foo=bar");
            scope.AddLink("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", null);
            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();
            var isEnabledCall = testListener.IsEnabledCalls.Dequeue();

            Assert.NotNull(activity);
            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);
            Assert.AreEqual("ActivityName", isEnabledCall.Name);
            Assert.AreEqual("Custom Display Name", activity.DisplayName);

            var activities = (IEnumerable<Activity>)startEvent.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(startEvent.Value);
            Activity[] activitiesArray = activities.ToArray();

            Assert.AreEqual(activitiesArray.Length, 2);

            Activity linkedActivity1 = activitiesArray[0];
            Activity linkedActivity2 = activitiesArray[1];

            Assert.AreEqual(ActivityIdFormat.W3C, linkedActivity1.IdFormat);
            Assert.AreEqual("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00", linkedActivity1.ParentId);
            Assert.AreEqual("foo=bar", linkedActivity1.TraceStateString);

            Assert.AreEqual(ActivityIdFormat.W3C, linkedActivity2.IdFormat);
            Assert.AreEqual("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00", linkedActivity2.ParentId);
            Assert.Null(linkedActivity2.TraceStateString);

            Assert.AreEqual(0, testListener.Events.Count);
        }

        [Test]
        public void AddLinkCreatesLinkedActivityWithTags()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            var expectedTags = new Dictionary<string, object>()
            {
                {"key1", "value1"},
                {"key2", "value2"}
            };

            string id = "00-0123456789abcdef0123456789abcdef-0123456789abcdef-01";
            scope.AddLink(id, null, expectedTags);
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
            Assert.AreEqual(id, linkedActivity.ParentId);

            CollectionAssert.AreEquivalent(expectedTags, linkedActivity.Tags);
        }

        [Test]
        public void FailedStopsActivityAndWritesExceptionEvent()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", true, false, true);

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
        public void NoOpsWhenDisabled()
        {
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients",  "Microsoft.Azure.Core.Cool.Tests", false, false, true);
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

            _ = new DiagnosticScopeFactory("Azure.Clients.1",  "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            _ = new DiagnosticScopeFactory("Azure.Clients.1",  "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            _ = new DiagnosticScopeFactory("Azure.Clients.2",  "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            Assert.AreEqual(2, testListener.Sources.Count);
        }

        [TestCase(ActivityKind.Internal)]
        [TestCase(ActivityKind.Server)]
        [TestCase(ActivityKind.Client)]
        [TestCase(ActivityKind.Producer)]
        [TestCase(ActivityKind.Consumer)]
        [NonParallelizable]
        public void NestedClientActivitiesNotSuppressed(int kind)
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            using DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", (ActivityKind)kind);
            scope.SetDisplayName("Activity Display Name");
            scope.Start();

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName", (ActivityKind)kind);
            nestedScope.SetDisplayName("Nested Activity Display Name");
            nestedScope.Start();

            Assert.IsTrue(nestedScope.IsEnabled);
            Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
            Assert.AreEqual("Nested Activity Display Name", Activity.Current.DisplayName);
            nestedScope.Dispose();
            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            Assert.AreEqual("Activity Display Name", Activity.Current.DisplayName);
        }

        [Test]
        [NonParallelizable]
        public void NestedActivitiesNoSuppressionSameSourceServerClient()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", ActivityKind.Server);
            Assert.IsTrue(scope.IsEnabled);
            scope.Start();
            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName");
            Assert.IsTrue(nestedScope.IsEnabled);
            nestedScope.Start();

            Activity nestedActivity = Activity.Current;
            Assert.AreEqual("ClientName.NestedActivityName", nestedActivity.OperationName);

            nestedScope.Dispose();
            Assert.AreEqual(Activity.Current, nestedActivity.Parent);

            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            scope.Dispose();
        }

        [Test]
        [NonParallelizable]
        public void NestedActivitiesNoSuppressionDifferentSourcesServerClient()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            ;
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", ActivityKind.Server);
            scope.Start();

            using var activityListener2 = new TestDiagnosticListener("Azure.Clients2");
            DiagnosticScopeFactory clientDiagnostics2 = new DiagnosticScopeFactory("Azure.Clients2", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            DiagnosticScope nestedScope = clientDiagnostics2.CreateScope("ClientName.NestedActivityName");
            nestedScope.Start();
            Assert.IsTrue(nestedScope.IsEnabled);
            Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
            nestedScope.Dispose();

            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            scope.Dispose();
        }

        [Test]
        [NonParallelizable]
        public void NestedActivitiesNoSuppressionOuterDisabled()
        {
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();

            using var activityListener2 = new TestDiagnosticListener("Azure.Clients2");
            DiagnosticScopeFactory clientDiagnostics2 = new DiagnosticScopeFactory("Azure.Clients2", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            DiagnosticScope nestedScope = clientDiagnostics2.CreateScope("ClientName.NestedActivityName");
            nestedScope.Start();
            Assert.IsTrue(nestedScope.IsEnabled);
            Assert.AreEqual("ClientName.NestedActivityName", Activity.Current.OperationName);
            nestedScope.Dispose();

            Assert.IsNull(Activity.Current);
        }

        [Test]
        [NonParallelizable]
        public void SequentialActivitiesNoSuppression()
        {
            using var activityListener2 = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            scope.Start();
            scope.Dispose();

            DiagnosticScope nextScope = clientDiagnostics.CreateScope("ClientName.ActivityName");
            nextScope.Start();
            Assert.IsTrue(nextScope.IsEnabled);
            Assert.AreEqual("ClientName.ActivityName", Activity.Current.OperationName);
            nextScope.Dispose();

            Assert.IsNull(Activity.Current);
        }
    }
}
