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

            Assert.That(Activity.Current, Is.Null);
            Assert.That(startEvent.Key, Is.EqualTo("ActivityName.Start"));
            Assert.That(stopEvent.Key, Is.EqualTo("ActivityName.Stop"));

            Assert.That(activity.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("kind", "internal")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute1", "Value1")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute2", "2")));

            // int attributes not supported
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, object>("Attribute3", "3")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests")));
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

            Assert.That(duration > TimeSpan.Zero, Is.True);
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

            Assert.That(actualStartTimeUtc, Is.EqualTo(expectedStartTimeUtc));
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

            Assert.That(Activity.Current.ParentId, Is.EqualTo(parentId));
            Assert.That(Activity.Current.TraceStateString, Is.EqualTo(tracestate));
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

            Assert.That(Activity.Current, Is.Null);
            Assert.That(startEvent.Key, Is.EqualTo("ActivityName.Start"));
            Assert.That(stopEvent.Key, Is.EqualTo("ActivityName.Stop"));

            Assert.That(activity.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));
        }

        [Test]
        public void AddLinkCallsPassesLinksAsPartOfStartPayload()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

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

            Assert.That(activity, Is.Not.Null);
            Assert.That(Activity.Current, Is.Null);
            Assert.That(startEvent.Key, Is.EqualTo("ActivityName.Start"));
            Assert.That(stopEvent.Key, Is.EqualTo("ActivityName.Stop"));
            Assert.That(isEnabledCall.Name, Is.EqualTo("ActivityName"));
            Assert.That(activity.DisplayName, Is.EqualTo("Custom Display Name"));

            var activities = (IEnumerable<Activity>)startEvent.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(startEvent.Value);
            Activity[] activitiesArray = activities.ToArray();

            Assert.That(activitiesArray.Length, Is.EqualTo(2));

            Activity linkedActivity1 = activitiesArray[0];
            Activity linkedActivity2 = activitiesArray[1];

            Assert.That(linkedActivity1.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));
            Assert.That(linkedActivity1.ParentId, Is.EqualTo("00-6e76af18746bae4eadc3581338bbe8b1-2899ebfdbdce904b-00"));
            Assert.That(linkedActivity1.TraceStateString, Is.EqualTo("foo=bar"));

            Assert.That(linkedActivity2.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));
            Assert.That(linkedActivity2.ParentId, Is.EqualTo("00-6e76af18746bae4eadc3581338bbe8b2-2899ebfdbdce904b-00"));
            Assert.That(linkedActivity2.TraceStateString, Is.Null);

            Assert.That(testListener.Events.Count, Is.EqualTo(0));
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

            Assert.That(Activity.Current, Is.Null);
            Assert.That(startEvent.Key, Is.EqualTo("ActivityName.Start"));
            Assert.That(stopEvent.Key, Is.EqualTo("ActivityName.Stop"));

            var activities = (IEnumerable<Activity>)startEvent.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(startEvent.Value);
            Activity linkedActivity = activities.Single();

            Assert.That(linkedActivity.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));
            Assert.That(linkedActivity.ParentId, Is.EqualTo(id));

            Assert.That(linkedActivity.Tags, Is.EquivalentTo(expectedTags));
        }

        [Test]
        public void FailedStopsActivityAndWritesExceptionEvent()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

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

            Assert.That(Activity.Current, Is.Null);
            Assert.That(startEvent.Key, Is.EqualTo("ActivityName.Start"));
            Assert.That(exceptionEvent.Key, Is.EqualTo("ActivityName.Exception"));
            Assert.That(stopEvent.Key, Is.EqualTo("ActivityName.Stop"));
            Assert.That(exceptionEvent.Value, Is.EqualTo(exception));
            Assert.That(testListener.Events.Count, Is.EqualTo(0));

            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute1", "Value1")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("Attribute2", "2")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests")));
        }

        [Test]
        public void NoOpsWhenDisabled()
        {
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", false, false, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("");

            Assert.That(scope.IsEnabled, Is.False);

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.Failed(new Exception());
            scope.Dispose();
        }

        [Test]
        public void GetResourceProviderNamespaceReturnsAttributeValue()
        {
            Assert.That(ClientDiagnostics.GetResourceProviderNamespace(GetType().Assembly), Is.EqualTo("Microsoft.Azure.Core.Cool.Tests"));
        }

        [Test]
        public void CreatesASingleListenerPerNamespace()
        {
            using var testListener = new TestDiagnosticListener(l => l.Name.StartsWith("Azure.Clients."));

            _ = new DiagnosticScopeFactory("Azure.Clients.1", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            _ = new DiagnosticScopeFactory("Azure.Clients.1", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            _ = new DiagnosticScopeFactory("Azure.Clients.2", "Microsoft.Azure.Core.Cool.Tests", true, false, true);

            Assert.That(testListener.Sources.Count, Is.EqualTo(2));
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

            Assert.That(nestedScope.IsEnabled, Is.True);
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
            Assert.That(Activity.Current.DisplayName, Is.EqualTo("Nested Activity Display Name"));
            nestedScope.Dispose();
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            Assert.That(Activity.Current.DisplayName, Is.EqualTo("Activity Display Name"));
        }

        [Test]
        [NonParallelizable]
        public void NestedActivitiesNoSuppressionSameSourceServerClient()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");

            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, false, true);
            DiagnosticScope scope = clientDiagnostics.CreateScope("ClientName.ActivityName", ActivityKind.Server);
            Assert.That(scope.IsEnabled, Is.True);
            scope.Start();
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));

            DiagnosticScope nestedScope = clientDiagnostics.CreateScope("ClientName.NestedActivityName");
            Assert.That(nestedScope.IsEnabled, Is.True);
            nestedScope.Start();

            Activity nestedActivity = Activity.Current;
            Assert.That(nestedActivity.OperationName, Is.EqualTo("ClientName.NestedActivityName"));

            nestedScope.Dispose();
            Assert.That(nestedActivity.Parent, Is.EqualTo(Activity.Current));

            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
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
            Assert.That(nestedScope.IsEnabled, Is.True);
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
            nestedScope.Dispose();

            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
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
            Assert.That(nestedScope.IsEnabled, Is.True);
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.NestedActivityName"));
            nestedScope.Dispose();

            Assert.That(Activity.Current, Is.Null);
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
            Assert.That(nextScope.IsEnabled, Is.True);
            Assert.That(Activity.Current.OperationName, Is.EqualTo("ClientName.ActivityName"));
            nextScope.Dispose();

            Assert.That(Activity.Current, Is.Null);
        }
    }
}
