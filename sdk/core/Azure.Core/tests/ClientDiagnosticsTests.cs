// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ClientDiagnosticsTests
    {
        [Test]
        public void CreatesActivityWithNameAndTags()
        {

            using var testListener = new TestDiagnosticListener("Azure.Clients");
            ClientDiagnostics clientDiagnostics = new ClientDiagnostics("Azure.Clients", true);

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
        }

        [Test]
        public void AddLinkCallsPassesLinksAsPartOfStartPayload()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            ClientDiagnostics clientDiagnostics = new ClientDiagnostics("Azure.Clients", true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddLink("id");
            scope.AddLink("id2");
            scope.Start();

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            scope.Dispose();

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);

            var activities = (IEnumerable<Activity>)startEvent.Value.GetType().GetProperty("Links").GetValue(startEvent.Value);
            Activity[] activitiesArray = activities.ToArray();

            Assert.AreEqual(activitiesArray.Length, 2);

            Activity linkedActivity1 = activitiesArray[0];
            Activity linkedActivity2 = activitiesArray[1];

            Assert.AreEqual(ActivityIdFormat.W3C, linkedActivity1.IdFormat);
            Assert.AreEqual("id", linkedActivity1.ParentId);

            Assert.AreEqual(ActivityIdFormat.W3C, linkedActivity2.IdFormat);
            Assert.AreEqual("id2", linkedActivity2.ParentId);

            Assert.AreEqual(0, testListener.Events.Count);
        }

        [Test]
        public void FailedStopsActivityAndWritesExceptionEvent()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            ClientDiagnostics clientDiagnostics = new ClientDiagnostics("Azure.Clients", true);

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
        }

        [Test]
        public void NoopsWhenDisabled()
        {
            ClientDiagnostics clientDiagnostics = new ClientDiagnostics("Azure.Clients", false);
            DiagnosticScope scope = clientDiagnostics.CreateScope("");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.Failed(new Exception());
            scope.Dispose();
        }
    }
}
