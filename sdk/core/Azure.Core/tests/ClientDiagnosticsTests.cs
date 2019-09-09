// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ClientDiagnostics clientDiagnostics = new ClientDiagnostics(true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.AddAttribute("Attribute3", 3);

            scope.Start();

            KeyValuePair<string, object> startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            scope.Dispose();

            KeyValuePair<string, object> stopEvent = testListener.Events.Dequeue();

            Assert.Null(Activity.Current);
            Assert.AreEqual("ActivityName.Start", startEvent.Key);
            Assert.AreEqual("ActivityName.Stop", stopEvent.Key);

            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute1", "Value1"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute2", "2"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("Attribute3", "3"));
        }

        [Test]
        public void FailedStopsActivityAndWritesExceptionEvent()
        {
            using var testListener = new TestDiagnosticListener("Azure.Clients");
            ClientDiagnostics clientDiagnostics = new ClientDiagnostics(true);

            DiagnosticScope scope = clientDiagnostics.CreateScope("ActivityName");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());

            scope.Start();

            KeyValuePair<string, object> startEvent = testListener.Events.Dequeue();

            Activity activity = Activity.Current;

            var exception = new Exception();
            scope.Failed(exception);
            scope.Dispose();
            
            KeyValuePair<string, object> exceptionEvent = testListener.Events.Dequeue();
            KeyValuePair<string, object> stopEvent = testListener.Events.Dequeue();

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
            ClientDiagnostics clientDiagnostics = new ClientDiagnostics(false);
            DiagnosticScope scope = clientDiagnostics.CreateScope("");

            scope.AddAttribute("Attribute1", "Value1");
            scope.AddAttribute("Attribute2", 2, i => i.ToString());
            scope.Failed(new Exception());
            scope.Dispose();
        }
    }
}
