// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.IotFirmwareDefense.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class CveResultCompatibilityTests
    {
        [Test]
        public void ComponentGetterUsesFlattenedProperties()
        {
            var result = new CveResult
            {
                ComponentId = "component-id",
                ComponentName = "component-name",
                ComponentVersion = "1.2.3"
            };

            CveComponent component = result.Component;

            Assert.That(component.ComponentId, Is.EqualTo("component-id"));
            Assert.That(component.Name, Is.EqualTo("component-name"));
            Assert.That(component.Version, Is.EqualTo("1.2.3"));
        }

        [Test]
        public void ComponentSetterUpdatesFlattenedProperties()
        {
            var result = new CveResult
            {
                Component = new CveComponent
                {
                    ComponentId = "component-id",
                    Name = "component-name",
                    Version = "1.2.3"
                }
            };

            Assert.That(result.ComponentId, Is.EqualTo("component-id"));
            Assert.That(result.ComponentName, Is.EqualTo("component-name"));
            Assert.That(result.ComponentVersion, Is.EqualTo("1.2.3"));
        }
    }
}
