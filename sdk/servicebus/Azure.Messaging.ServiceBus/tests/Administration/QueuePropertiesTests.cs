// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    public class QueuePropertiesTests
    {
        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardTo = $"{baseUrl}{longName}");

            StringAssert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
            Assert.AreEqual($"ForwardTo", ex.ParamName);
        }

        [Test]
        public void AutoDeleteOnIdleThrowsOutOfRangeException()
        {
            var sub = new QueueProperties("Fake Name");
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.AutoDeleteOnIdle = TimeSpan.FromMinutes(2));

            StringAssert.StartsWith($"The value supplied must be greater than or equal to {AdministrationClientConstants.MinimumAllowedAutoDeleteOnIdle}.", ex.Message);
            Assert.AreEqual($"AutoDeleteOnIdle", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardDeadLetteredMessagesToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}");

            StringAssert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
            Assert.AreEqual($"ForwardDeadLetteredMessagesTo", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void PathToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new CreateQueueOptions("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.Name = $"{baseUrl}{longName}");

            StringAssert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
            Assert.AreEqual($"Name", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void ForwardToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");
            sub.ForwardTo = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.ForwardTo);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void ForwardDeadLetteredMessagesToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");
            sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.ForwardDeadLetteredMessagesTo);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void PathAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new CreateQueueOptions("Fake SubscriptionName");
            sub.Name = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.Name);
        }

        [Test]
        public void CanCreateQueuePropertiesFromFactory()
        {
            var properties = ServiceBusModelFactory.QueueProperties(
                "queueName",
                TimeSpan.FromSeconds(30),
                100,
                true,
                true,
                TimeSpan.FromSeconds(10),
                TimeSpan.FromMinutes(5),
                true,
                TimeSpan.FromMinutes(10),
                5,
                false,
                EntityStatus.Active,
                "forward",
                "dlq",
                "metadata",
                true);
            Assert.AreEqual("queueName", properties.Name);
            Assert.AreEqual(TimeSpan.FromSeconds(30), properties.LockDuration);
            Assert.AreEqual(100, properties.MaxSizeInMegabytes);
            Assert.IsTrue(properties.RequiresDuplicateDetection);
            Assert.IsTrue(properties.RequiresSession);
            Assert.AreEqual(TimeSpan.FromSeconds(10), properties.DefaultMessageTimeToLive);
            Assert.AreEqual(TimeSpan.FromMinutes(5), properties.AutoDeleteOnIdle);
            Assert.IsTrue(properties.DeadLetteringOnMessageExpiration);
            Assert.AreEqual(TimeSpan.FromMinutes(10), properties.DuplicateDetectionHistoryTimeWindow);
            Assert.AreEqual(5, properties.MaxDeliveryCount);
            Assert.IsFalse(properties.EnableBatchedOperations);
            Assert.AreEqual(EntityStatus.Active, properties.Status);
            Assert.AreEqual("forward", properties.ForwardTo);
            Assert.AreEqual("dlq", properties.ForwardDeadLetteredMessagesTo);
            Assert.AreEqual("metadata", properties.UserMetadata);
            Assert.IsTrue(properties.EnablePartitioning);
        }

        [Test]
        public void CanCreateQueuePropertiesFromOptions()
        {
            var options = new CreateQueueOptions("queue")
            {
                LockDuration = TimeSpan.FromSeconds(60),
                MaxSizeInMegabytes = 1024,
                RequiresDuplicateDetection = true,
                RequiresSession = true,
                DefaultMessageTimeToLive = TimeSpan.FromSeconds(120),
                AutoDeleteOnIdle = TimeSpan.FromMinutes(10),
                DeadLetteringOnMessageExpiration = true,
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromSeconds(100),
                MaxDeliveryCount = 5,
                EnableBatchedOperations = true,
                AuthorizationRules = { new SharedAccessAuthorizationRule("key", new AccessRights[] { AccessRights.Listen }) },
                Status = EntityStatus.Disabled,
                ForwardDeadLetteredMessagesTo = "dlqForward",
                ForwardTo = "forward",
                EnablePartitioning = true,
                UserMetadata = "metadata"
            };
            var properties = new QueueProperties(options);

            Assert.AreEqual(options, new CreateQueueOptions(properties));
        }

        [Test]
        public async Task UnknownElementsInAtomXmlHandledCorrectly()
        {
            string queueDescriptionXml = $@"<entry xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<title xmlns=""{AdministrationClientConstants.AtomNamespace}"">testqueue1</title>" +
                $@"<content xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<QueueDescription xmlns=""{AdministrationClientConstants.ServiceBusNamespace}"">" +
                $"<LockDuration>{XmlConvert.ToString(TimeSpan.FromMinutes(1))}</LockDuration>" +
                $"<MaxSizeInMegabytes>1024</MaxSizeInMegabytes>" +
                $"<RequiresDuplicateDetection>true</RequiresDuplicateDetection>" +
                $"<RequiresSession>true</RequiresSession>" +
                $"<DefaultMessageTimeToLive>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</DefaultMessageTimeToLive>" +
                $"<DeadLetteringOnMessageExpiration>false</DeadLetteringOnMessageExpiration>" +
                $"<DuplicateDetectionHistoryTimeWindow>{XmlConvert.ToString(TimeSpan.FromMinutes(2))}</DuplicateDetectionHistoryTimeWindow>" +
                $"<MaxDeliveryCount>10</MaxDeliveryCount>" +
                $"<EnableBatchedOperations>true</EnableBatchedOperations>" +
                $"<IsAnonymousAccessible>false</IsAnonymousAccessible>" +
                $"<AuthorizationRules />" +
                $"<Status>Active</Status>" +
                $"<ForwardTo>fq1</ForwardTo>" +
                $"<UserMetadata></UserMetadata>" +
                $"<SupportOrdering>true</SupportOrdering>" +
                $"<AutoDeleteOnIdle>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</AutoDeleteOnIdle>" +
                $"<EnablePartitioning>false</EnablePartitioning>" +
                $"<EnableExpress>false</EnableExpress>" +
                $"<UnknownElement1>prop1</UnknownElement1>" +
                $"<UnknownElement2>prop2</UnknownElement2>" +
                $"<UnknownElement3>prop3</UnknownElement3>" +
                $"<UnknownElement4>prop4</UnknownElement4>" +
                $"<UnknownElement5><PropertyValue>prop5</PropertyValue></UnknownElement5>" +
                $"</QueueDescription>" +
                $"</content>" +
                $"</entry>";
            MockResponse response = new MockResponse(200);
            response.SetContent(queueDescriptionXml);
            QueueProperties queueDesc = await QueuePropertiesExtensions.ParseResponseAsync(response, new ClientDiagnostics(new ServiceBusAdministrationClientOptions()));
            Assert.NotNull(queueDesc.UnknownProperties);
            XDocument doc = QueuePropertiesExtensions.Serialize(queueDesc);

            XName queueDescriptionElementName = XName.Get("QueueDescription", AdministrationClientConstants.ServiceBusNamespace);
            XElement expectedQueueDecriptionElement = XElement.Parse(queueDescriptionXml).Descendants(queueDescriptionElementName).FirstOrDefault();
            XElement serializedQueueDescritionElement = doc.Descendants(queueDescriptionElementName).FirstOrDefault();
            XNode expectedChildNode = expectedQueueDecriptionElement.FirstNode;
            XNode actualChildNode = serializedQueueDescritionElement.FirstNode;
            while (expectedChildNode != null)
            {
                Assert.NotNull(actualChildNode);
                Assert.True(XNode.DeepEquals(expectedChildNode, actualChildNode), $"QueueDescrition parsing and serialization combo didn't work as expected. {expectedChildNode.ToString()}");
                expectedChildNode = expectedChildNode.NextNode;
                actualChildNode = actualChildNode.NextNode;
            }
        }
    }
}
