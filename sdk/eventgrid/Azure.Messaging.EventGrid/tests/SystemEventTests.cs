// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private static readonly HashSet<string> s_etagCasingExlusions = new()
        {
            "AppConfigurationKeyValueDeletedEventData",
            "AppConfigurationKeyValueModifiedEventData"
        };

        [Test]
        public void MappingContainsAllSystemEvents()
        {
            foreach (var systemEvent in Assembly.GetAssembly(typeof(EventGridEvent)).GetTypes().Where(t => t.Name.EndsWith("EventData")))
            {
                // skip types that have no public constructors, e.g. base types
                if (systemEvent.GetConstructors().Length == 0)
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

        [Test]
        public void EventPropertiesCasedCorrectly()
        {
            foreach (Type systemEvent in Assembly.GetAssembly(typeof(EventGridEvent)).GetTypes().Where(t => t.Name.EndsWith("EventData")))
            {
                if (s_etagCasingExlusions.Contains(systemEvent.Name))
                {
                    continue;
                }

                foreach (PropertyInfo propertyInfo in systemEvent.GetProperties())
                {
                    string name = propertyInfo.Name;
                    if (name.ToLower() == "etag")
                    {
                        if (name != "ETag")
                        {
                            Assert.Fail($"{systemEvent}.{name} is not cased correctly. It should be cased as 'ETag'.");
                        }
                    }
                }
            }
        }

        [Test]
        public void ModelsAreInCorrectNamespace()
        {
            foreach (Type model in Assembly.GetAssembly(typeof(EventGridEvent)).GetTypes())
            {
                if (model.IsPublic && model.Namespace == "Azure.Messaging.EventGrid.Models"
                    && model.GetCustomAttribute<EditorBrowsableAttribute>() == null)
                {
                    Assert.Fail($"{model} is not in the correct namespace. It should be in Azure.Messaging.EventGrid.SystemEvents.");
                }
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
