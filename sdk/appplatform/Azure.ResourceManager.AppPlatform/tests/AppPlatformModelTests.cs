// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.AppPlatform.Models;
using NUnit.Framework;
using System;
using System.Text.Json;

namespace Azure.ResourceManager.AppPlatform.Tests
{
    public class AppPlatformModelTests
    {
        [TestCase("79d502c7359c4afc99095965f28ca37f", "79d502c7-359c-4afc-9909-5965f28ca37f")]
        [TestCase("77af734a-f643-467d-a31f-f873b15cc869", "77af734a-f643-467d-a31f-f873b15cc869")]
        [Obsolete]
        public void AppPlatformServicePropertiesServiceId(string rawId, string guid)
        {
            var jsonElement = JsonDocument.Parse($"{{\"serviceId\":\"{rawId}\"}}").RootElement;
            var properties = AppPlatformServiceProperties.DeserializeAppPlatformServiceProperties(jsonElement);

            Assert.AreEqual(new Guid(guid), properties.ServiceId);
            Assert.AreEqual(rawId, properties.ServiceInstanceId);
        }

        [Test]
        [Obsolete]
        public void AppPlatformServicePropertiesUndefinedServiceId()
        {
            var jsonElement = JsonDocument.Parse("{}").RootElement;
            var properties = AppPlatformServiceProperties.DeserializeAppPlatformServiceProperties(jsonElement);

            Assert.IsNull(properties.ServiceId);
            Assert.IsNull(properties.ServiceInstanceId);
        }

        [Test]
        [Obsolete]
        public void AppPlatformServicePropertiesNullServiceId()
        {
            var jsonElement = JsonDocument.Parse("{\"serviceId\":null}").RootElement;
            var properties = AppPlatformServiceProperties.DeserializeAppPlatformServiceProperties(jsonElement);

            Assert.IsNull(properties.ServiceId);
            Assert.IsNull(properties.ServiceInstanceId);
        }

        [Test]
        [Obsolete]
        public void AppPlatformServicePropertiesUnknownServiceId()
        {
            var jsonElement = JsonDocument.Parse("{\"serviceId\":\"1232dcf\"}").RootElement;
            var properties = AppPlatformServiceProperties.DeserializeAppPlatformServiceProperties(jsonElement);

            try
            {
                var serviceId = properties.ServiceId;
                Assert.Fail("Should throw exception");
            }
            catch (FormatException) { }
            Assert.AreEqual("1232dcf", properties.ServiceInstanceId);
        }
    }
}
