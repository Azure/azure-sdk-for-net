// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class SystemEventTests
    {
        private static readonly HashSet<string> s_casingExclusions = new()
        {
            "SignalRServiceClientConnectionConnectedEventData",
            "SignalRServiceClientConnectionDisconnectedEventData",
            "SignalRServiceClientConnectionConnected",
            "SignalRServiceClientConnectionDisconnected",
        };

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
                ValidateName(systemEvent.Name);
                Assert.IsTrue(
                    SystemEventExtensions.s_systemEventDeserializers.Values.Any(
                        f => f.Method.ReturnType == systemEvent), systemEvent.Name);
            }
        }

        [Test]
        public void SystemNamesCasedCorrectly()
        {
            foreach (FieldInfo systemName in typeof(SystemEventNames).GetFields())
            {
                ValidateName(systemName.Name);
            }
        }

        private void ValidateName(string name)
        {
            if (s_casingExclusions.Contains(name))
            {
                return;
            }

            for (int i = 1; i < name.Length; i++)
            {
                if (char.IsUpper(name[i - 1]) && char.IsUpper(name[i]))
                {
                    Assert.Fail(name);
                }
            }
        }
    }
}
