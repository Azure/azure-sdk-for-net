// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    /// <summary>
    /// Tests for MessagingConnect partner parameter functionality using the generic approach.
    /// </summary>
    public class MessagingConnectPartnerParametersTests
    {
        [Test]
        public void PartnerParameters_CreateWithTuples_ShouldSerializeCorrectly()
        {
            // Arrange & Act
            var partnerParams = MessagingConnectPartnerParameters.Create(
                ("ApiKey", "test-api-key"),
                ("ServicePlanId", "test-service-plan"));

            // Assert
            var keyValuePairs = partnerParams.ToList();
            Assert.AreEqual(2, keyValuePairs.Count);
            Assert.IsTrue(keyValuePairs.Any(kvp => kvp.Key == "ApiKey" && kvp.Value.Equals("test-api-key")));
            Assert.IsTrue(keyValuePairs.Any(kvp => kvp.Key == "ServicePlanId" && kvp.Value.Equals("test-service-plan")));
        }

        [Test]
        public void PartnerParameters_FromObject_ShouldSerializeCorrectly()
        {
            // Arrange & Act
            var partnerParams = MessagingConnectPartnerParameters.FromObject(new
            {
                ApiKey = "test-api-key",
                ServicePlanId = "test-service-plan",
                Timeout = 30
            });

            // Assert
            var keyValuePairs = partnerParams.ToList();
            Assert.AreEqual(3, keyValuePairs.Count);
            Assert.IsTrue(keyValuePairs.Any(kvp => kvp.Key == "ApiKey" && kvp.Value.Equals("test-api-key")));
            Assert.IsTrue(keyValuePairs.Any(kvp => kvp.Key == "ServicePlanId" && kvp.Value.Equals("test-service-plan")));
            Assert.IsTrue(keyValuePairs.Any(kvp => kvp.Key == "Timeout" && kvp.Value.Equals(30)));
        }

        [Test]
        public void PartnerParameters_FromDictionary_ShouldSerializeCorrectly()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>
            {
                ["ApiKey"] = "test-api-key",
                ["ServicePlanId"] = "test-service-plan"
            };

            // Act
            var partnerParams = MessagingConnectPartnerParameters.FromDictionary(dictionary);

            // Assert
            var keyValuePairs = partnerParams.ToList();
            Assert.AreEqual(2, keyValuePairs.Count);
            Assert.IsTrue(keyValuePairs.Any(kvp => kvp.Key == "ApiKey" && kvp.Value.Equals("test-api-key")));
            Assert.IsTrue(keyValuePairs.Any(kvp => kvp.Key == "ServicePlanId" && kvp.Value.Equals("test-service-plan")));
        }

        [Test]
        public void PartnerParameters_GetValue_ShouldReturnCorrectValues()
        {
            // Arrange
            var partnerParams = MessagingConnectPartnerParameters.Create(
                ("ApiKey", "test-api-key"),
                ("Timeout", 30),
                ("Enabled", true));

            // Act & Assert
            Assert.AreEqual("test-api-key", partnerParams.GetValue("ApiKey"));
            Assert.AreEqual(30, partnerParams.GetValue<int>("Timeout"));
            Assert.AreEqual(true, partnerParams.GetValue<bool>("Enabled"));
            Assert.IsNull(partnerParams.GetValue("NonExistent"));
            Assert.AreEqual(0, partnerParams.GetValue<int>("NonExistent"));
        }

        [Test]
        public void PartnerParameters_ContainsKey_ShouldWorkCorrectly()
        {
            // Arrange
            var partnerParams = MessagingConnectPartnerParameters.Create(
                ("ApiKey", "test-api-key"),
                ("ServicePlanId", "test-service-plan"));

            // Act & Assert
            Assert.IsTrue(partnerParams.ContainsKey("ApiKey"));
            Assert.IsTrue(partnerParams.ContainsKey("ServicePlanId"));
            Assert.IsFalse(partnerParams.ContainsKey("NonExistent"));
        }

        [Test]
        public void PartnerParameters_Count_ShouldReturnCorrectValue()
        {
            // Arrange
            var partnerParams = MessagingConnectPartnerParameters.Create(
                ("ApiKey", "test-api-key"),
                ("ServicePlanId", "test-service-plan"),
                ("Timeout", 30));

            // Act & Assert
            Assert.AreEqual(3, partnerParams.Count);
        }

        [Test]
        public void MessagingConnectOptions_WithPartnerParameters_ShouldWork()
        {
            // Arrange
            var partner = "any-partner";
            var partnerParams = MessagingConnectPartnerParameters.Create(
                ("ApiKey", "test-api-key"),
                ("CustomParam", "custom-value"));

            // Act
            var messagingConnectOptions = new MessagingConnectOptions(partner, partnerParams);

            // Assert
            Assert.AreEqual(partner, messagingConnectOptions.Partner);
            Assert.AreEqual(partnerParams, messagingConnectOptions.PartnerParams);
        }

        [Test]
        public void PartnerParameters_SupportsAnyPartner_ShouldWork()
        {
            // Test that this approach works for any partner without SDK changes
            var partners = new[] { "infobip", "twilio", "nexmo", "custom-partner", "future-partner" };

            foreach (var partner in partners)
            {
                // Arrange
                var partnerParams = MessagingConnectPartnerParameters.Create(
                    ("ApiKey", $"{partner}-api-key"),
                    ("PartnerSpecificParam", $"{partner}-specific-value"));

                // Act
                var messagingConnectOptions = new MessagingConnectOptions(partner, partnerParams);

                // Assert
                Assert.AreEqual(partner, messagingConnectOptions.Partner);
                Assert.IsInstanceOf<MessagingConnectPartnerParameters>(messagingConnectOptions.PartnerParams);

                var retrievedParams = (MessagingConnectPartnerParameters)messagingConnectOptions.PartnerParams;
                Assert.AreEqual($"{partner}-api-key", retrievedParams.GetValue("ApiKey"));
                Assert.AreEqual($"{partner}-specific-value", retrievedParams.GetValue("PartnerSpecificParam"));
            }
        }
    }
}
