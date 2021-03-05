// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class SystemEventTests
    {
        [Test]
        public void MappingContainsAllSystemEvents()
        {
            foreach (var systemEvent in Assembly.GetAssembly(typeof(EventGridEvent)).GetTypes().Where(t => t.Name.EndsWith("EventData")))
            {
                // skip base types
                if (systemEvent == typeof(ContainerRegistryArtifactEventData) ||
                    systemEvent == typeof(ContainerRegistryEventData))
                {
                    continue;
                }
                Assert.IsTrue(
                    SystemEventExtensions.s_systemEventDeserializers.Values.Any(
                        f => f.Method.ReturnType == systemEvent), systemEvent.Name);
            }
        }
    }
}
