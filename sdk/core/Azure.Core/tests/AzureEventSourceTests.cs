// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET5_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Azure.Core.Diagnostics;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AzureEventSourceTests
    {
        [Test]
        public void CanCreateMultipleEventSources()
        {
            EventSource GetEventSource(TestAssemblyLoadContext testAssemblyLoadContext)
            {
                return (EventSource)Activator.CreateInstance(testAssemblyLoadContext.Assemblies
                    .Single()
                    .GetType("Azure.Core.Tests.AzureEventSourceTests+TestEventSource"));
            }

            void LogEvent(EventSource azureCoreEventSource)
            {
                azureCoreEventSource.GetType()
                    .GetMethod("LogSomething", BindingFlags.Public | BindingFlags.Instance)
                    .Invoke(azureCoreEventSource, Array.Empty<object>());
            }

            var alc = new TestAssemblyLoadContext("Test 1");
            var alc2 = new TestAssemblyLoadContext("Test 2");

            try
            {
                List<EventWrittenEventArgs> events = new();
                using var listener = new AzureEventSourceListener(events.Add, EventLevel.Verbose);

                alc.LoadFromAssemblyPath(typeof(TestEventSource).Assembly.Location);
                alc2.LoadFromAssemblyPath(typeof(TestEventSource).Assembly.Location);

                using var es0 = new TestEventSource();
                using var es1 = GetEventSource(alc);
                using var es2 = GetEventSource(alc2);

                LogEvent(es0);
                LogEvent(es1);
                LogEvent(es2);

                Assert.AreEqual("Azure-Corez", es0.Name);
                Assert.AreEqual("Azure-Corez-1", es1.Name);
                Assert.AreEqual("Azure-Corez-2", es2.Name);

                Assert.AreEqual(3, events.Count);

                Assert.AreEqual("Azure-Corez", events[0].EventSource.Name);
                Assert.AreEqual("Azure-Corez-1", events[1].EventSource.Name);
                Assert.AreEqual("Azure-Corez-2", events[2].EventSource.Name);
            }
            finally
            {
                alc.Unload();
                alc2.Unload();
            }
        }

        [Test]
        public void SetsTraits()
        {
            using var es = new TestEventSource();
            Assert.AreEqual("true", es.GetTrait("AzureEventSource"));
        }

        public class TestAssemblyLoadContext : AssemblyLoadContext
        {
            public TestAssemblyLoadContext(string name) : base(name, true)
            {
            }
        }

        internal class TestEventSource: AzureEventSource
        {
            public TestEventSource() : base("Azure-Corez")
            {
            }

            [Event(1)]
            public void LogSomething()
            {
                WriteEvent(1);
            }
        }
    }
}
#endif
