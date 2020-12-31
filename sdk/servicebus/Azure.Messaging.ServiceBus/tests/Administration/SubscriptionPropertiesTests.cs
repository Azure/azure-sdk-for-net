// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    public class SubscriptionPropertiesTests
    {
        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new SubscriptionProperties("sb://fakeservicebus", "Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardTo = $"{baseUrl}{longName}");

            StringAssert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
            Assert.AreEqual($"ForwardTo", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardDeadLetteredMessagesToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new SubscriptionProperties("sb://fakeservicebus", "Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}");

            StringAssert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
            Assert.AreEqual($"ForwardDeadLetteredMessagesTo", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("sb://fakepath//", 260)]
        [TestCase("", 260)]
        public void ForwardToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new SubscriptionProperties("sb://fakeservicebus", "Fake SubscriptionName");
            sub.ForwardTo = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.ForwardTo);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("sb://fakepath//", 260)]
        [TestCase("", 260)]
        public void ForwardDeadLetteredMessagesToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new SubscriptionProperties("sb://fakeservicebus", "Fake SubscriptionName");
            sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.ForwardDeadLetteredMessagesTo);
        }

        [Test]
        public void CanCreateSubscriptionPropertiesFromFactory()
        {
            var properties = ServiceBusModelFactory.SubscriptionProperties(
                "topicName",
                "subscriptionName",
                TimeSpan.FromSeconds(30),
                true,
                TimeSpan.FromSeconds(10),
                TimeSpan.FromMinutes(5),
                true,
                5,
                false,
                EntityStatus.Active,
                "forward",
                "dlq",
                "metadata");
            Assert.AreEqual("topicName", properties.TopicName);
            Assert.AreEqual("subscriptionName", properties.SubscriptionName);
            Assert.AreEqual(TimeSpan.FromSeconds(30), properties.LockDuration);
            Assert.IsTrue(properties.RequiresSession);
            Assert.AreEqual(TimeSpan.FromSeconds(10), properties.DefaultMessageTimeToLive);
            Assert.AreEqual(TimeSpan.FromMinutes(5), properties.AutoDeleteOnIdle);
            Assert.IsTrue(properties.DeadLetteringOnMessageExpiration);
            Assert.AreEqual(5, properties.MaxDeliveryCount);
            Assert.IsFalse(properties.EnableBatchedOperations);
            Assert.AreEqual(EntityStatus.Active, properties.Status);
            Assert.AreEqual("forward", properties.ForwardTo);
            Assert.AreEqual("dlq", properties.ForwardDeadLetteredMessagesTo);
            Assert.AreEqual("metadata", properties.UserMetadata);
        }

        [Test]
        public void CanCreateSubscriptionPropertiesFromOptions()
        {
            var options = new CreateSubscriptionOptions("topic", "subscription")
            {
                LockDuration = TimeSpan.FromSeconds(60),
                RequiresSession = true,
                DefaultMessageTimeToLive = TimeSpan.FromSeconds(120),
                AutoDeleteOnIdle = TimeSpan.FromMinutes(10),
                DeadLetteringOnMessageExpiration = true,
                MaxDeliveryCount = 5,
                EnableBatchedOperations = true,
                Status = EntityStatus.Disabled,
                ForwardDeadLetteredMessagesTo = "dlqForward",
                ForwardTo = "forward",
                UserMetadata = "metadata"
            };
            var properties = new SubscriptionProperties(options);

            Assert.AreEqual(options, new CreateSubscriptionOptions(properties));
        }

        [Test]
        public async Task UnknownElementsInAtomXmlHandledCorrectly()
        {
            string subscriptionDescriptionXml = $@"<entry xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<title xmlns=""{AdministrationClientConstants.AtomNamespace}"">testqueue1</title>" +
                $@"<content xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<SubscriptionDescription xmlns=""{AdministrationClientConstants.ServiceBusNamespace}"">" +
                $"<LockDuration>{XmlConvert.ToString(TimeSpan.FromMinutes(1))}</LockDuration>" +
                $"<RequiresSession>true</RequiresSession>" +
                $"<DefaultMessageTimeToLive>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</DefaultMessageTimeToLive>" +
                $"<DeadLetteringOnMessageExpiration>false</DeadLetteringOnMessageExpiration>" +
                $"<DeadLetteringOnFilterEvaluationExceptions>false</DeadLetteringOnFilterEvaluationExceptions>" +
                $"<MaxDeliveryCount>10</MaxDeliveryCount>" +
                $"<EnableBatchedOperations>true</EnableBatchedOperations>" +
                $"<Status>Active</Status>" +
                $"<ForwardTo>fq1</ForwardTo>" +
                $"<UserMetadata></UserMetadata>" +
                $"<AutoDeleteOnIdle>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</AutoDeleteOnIdle>" +
                $"<IsClientAffine>prop1</IsClientAffine>" +
                $"<ClientAffineProperties><ClientId>xyz</ClientId><IsDurable>false</IsDurable><IsShared>true</IsShared></ClientAffineProperties>" +
                $"<UnknownElement3>prop3</UnknownElement3>" +
                $"<UnknownElement4>prop4</UnknownElement4>" +
                $"</SubscriptionDescription>" +
                $"</content>" +
                $"</entry>";
            MockResponse response = new MockResponse(200);
            response.SetContent(subscriptionDescriptionXml);
            SubscriptionProperties subscriptionDesc = await SubscriptionPropertiesExtensions.ParseResponseAsync("abcd", response, new ClientDiagnostics(new ServiceBusAdministrationClientOptions()));
            Assert.NotNull(subscriptionDesc.UnknownProperties);
            XDocument doc = SubscriptionPropertiesExtensions.Serialize(subscriptionDesc);

            XName subscriptionDescriptionElementName = XName.Get("SubscriptionDescription", AdministrationClientConstants.ServiceBusNamespace);
            XElement expectedSubscriptionDecriptionElement = XElement.Parse(subscriptionDescriptionXml).Descendants(subscriptionDescriptionElementName).FirstOrDefault();
            XElement serializedSubscriptionDescritionElement = doc.Descendants(subscriptionDescriptionElementName).FirstOrDefault();
            XNode expectedChildNode = expectedSubscriptionDecriptionElement.FirstNode;
            XNode actualChildNode = serializedSubscriptionDescritionElement.FirstNode;
            while (expectedChildNode != null)
            {
                Assert.NotNull(actualChildNode);
                Assert.True(XNode.DeepEquals(expectedChildNode, actualChildNode), $"SubscriptionDescrition parsing and serialization combo didn't work as expected. {expectedChildNode.ToString()}");
                expectedChildNode = expectedChildNode.NextNode;
                actualChildNode = actualChildNode.NextNode;
            }
        }
    }
}
