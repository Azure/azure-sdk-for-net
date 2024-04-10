// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET5_0_OR_GREATER

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Diagnostics
{
    public class ClientEventSourceTests
    {
        [Test]
        public void CanCreateMultipleEventSources()
        {
            EventSource GetEventSource(TestAssemblyLoadContext testAssemblyLoadContext)
            {
                var testEventSourceType = testAssemblyLoadContext.Assemblies
                    .Single()
                    .GetType("System.ClientModel.Tests.Internal.Diagnostics.ClientEventSourceTests+TestEventSource");
                return (EventSource?)Activator.CreateInstance(testEventSourceType!)!;
            }

            void LogEvent(EventSource clientModelEventSource)
            {
                var method = clientModelEventSource.GetType().GetMethod("LogSomething", BindingFlags.Public | BindingFlags.Instance);
                method?.Invoke(clientModelEventSource, Array.Empty<object>());
            }

            var alc = new TestAssemblyLoadContext("Test 1");
            var alc2 = new TestAssemblyLoadContext("Test 2");

            try
            {
                List<EventWrittenEventArgs> events = new();
                //using var listener = new ClientEventSourceListener((args, s) => events.Add(args), EventLevel.Verbose);

                alc.LoadFromAssemblyPath(typeof(TestEventSource).Assembly.Location);
                alc2.LoadFromAssemblyPath(typeof(TestEventSource).Assembly.Location);

                using var es0 = new TestEventSource();
                using var es1 = GetEventSource(alc);
                using var es2 = GetEventSource(alc2);

                LogEvent(es0);
                LogEvent(es1);
                LogEvent(es2);

                Assert.AreEqual("System-Client-Model-Test", es0.Name);
                Assert.AreEqual("System-Client-Model-Test-1", es1.Name);
                Assert.AreEqual("System-Client-Model-Test-2", es2.Name);

                Assert.AreEqual(3, events.Count);

                Assert.AreEqual("System-Client-Model-Test", events[0].EventSource.Name);
                Assert.AreEqual("System-Client-Model-Test-1", events[1].EventSource.Name);
                Assert.AreEqual("System-Client-Model-Test-2", events[2].EventSource.Name);
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
            Assert.AreEqual("true", es.GetTrait("ClientEventSource"));
        }

        public class TestAssemblyLoadContext : AssemblyLoadContext
        {
            public TestAssemblyLoadContext(string name) : base(name, true)
            {
            }
        }

        internal class TestEventSource : ClientEventSource
        {
            public TestEventSource() : base("System-Client-Model-Test")
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
