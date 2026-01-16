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

            Assert.That(ex.Message, Does.StartWith($"Entity path '{longName}' exceeds the '260' character limit."));
            Assert.That(ex.ParamName, Is.EqualTo($"ForwardTo"));
        }

        [Test]
        public void AutoDeleteOnIdleThrowsOutOfRangeException()
        {
            var sub = new QueueProperties("Fake Name");
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.AutoDeleteOnIdle = TimeSpan.FromMinutes(2));

            Assert.That(ex.Message, Does.StartWith($"The value supplied must be greater than or equal to {AdministrationClientConstants.MinimumAllowedAutoDeleteOnIdle}."));
            Assert.That(ex.ParamName, Is.EqualTo($"AutoDeleteOnIdle"));
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardDeadLetteredMessagesToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}");

            Assert.That(ex.Message, Does.StartWith($"Entity path '{longName}' exceeds the '260' character limit."));
            Assert.That(ex.ParamName, Is.EqualTo($"ForwardDeadLetteredMessagesTo"));
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void PathToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new CreateQueueOptions("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.Name = $"{baseUrl}{longName}");

            Assert.That(ex.Message, Does.StartWith($"Entity path '{longName}' exceeds the '260' character limit."));
            Assert.That(ex.ParamName, Is.EqualTo($"Name"));
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void ForwardToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");
            sub.ForwardTo = $"{baseUrl}{longName}";
            Assert.That(sub.ForwardTo, Is.EqualTo($"{baseUrl}{longName}"));
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void ForwardDeadLetteredMessagesToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");
            sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}";
            Assert.That(sub.ForwardDeadLetteredMessagesTo, Is.EqualTo($"{baseUrl}{longName}"));
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void PathAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new CreateQueueOptions("Fake SubscriptionName");
            sub.Name = $"{baseUrl}{longName}";
            Assert.That(sub.Name, Is.EqualTo($"{baseUrl}{longName}"));
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
                true,
                2000);
            Assert.That(properties.Name, Is.EqualTo("queueName"));
            Assert.That(properties.LockDuration, Is.EqualTo(TimeSpan.FromSeconds(30)));
            Assert.That(properties.MaxSizeInMegabytes, Is.EqualTo(100));
            Assert.That(properties.RequiresDuplicateDetection, Is.True);
            Assert.That(properties.RequiresSession, Is.True);
            Assert.That(properties.DefaultMessageTimeToLive, Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(properties.AutoDeleteOnIdle, Is.EqualTo(TimeSpan.FromMinutes(5)));
            Assert.That(properties.DeadLetteringOnMessageExpiration, Is.True);
            Assert.That(properties.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(TimeSpan.FromMinutes(10)));
            Assert.That(properties.MaxDeliveryCount, Is.EqualTo(5));
            Assert.That(properties.EnableBatchedOperations, Is.False);
            Assert.That(properties.Status, Is.EqualTo(EntityStatus.Active));
            Assert.That(properties.ForwardTo, Is.EqualTo("forward"));
            Assert.That(properties.ForwardDeadLetteredMessagesTo, Is.EqualTo("dlq"));
            Assert.That(properties.UserMetadata, Is.EqualTo("metadata"));
            Assert.That(properties.EnablePartitioning, Is.True);
            Assert.That(properties.MaxMessageSizeInKilobytes, Is.EqualTo(2000));
        }

        [Test]
        public void CanCreateQueueRuntimePropertiesFromFactory()
        {
            var today = DateTimeOffset.Now;
            var yesterday = today.Subtract(TimeSpan.FromDays(1));
            var twoDaysAgo = today.Subtract(TimeSpan.FromDays(2));
            var properties = ServiceBusModelFactory.QueueRuntimeProperties(
                "queueName",
                10,
                1,
                5,
                2,
                3,
                21,
                100,
                twoDaysAgo,
                yesterday,
                today);
            Assert.That(properties.Name, Is.EqualTo("queueName"));
            Assert.That(properties.ActiveMessageCount, Is.EqualTo(10));
            Assert.That(properties.ScheduledMessageCount, Is.EqualTo(1));
            Assert.That(properties.DeadLetterMessageCount, Is.EqualTo(5));
            Assert.That(properties.TransferDeadLetterMessageCount, Is.EqualTo(2));
            Assert.That(properties.TransferMessageCount, Is.EqualTo(3));
            Assert.That(properties.TotalMessageCount, Is.EqualTo(21));
            Assert.That(properties.SizeInBytes, Is.EqualTo(100));
            Assert.That(properties.CreatedAt, Is.EqualTo(twoDaysAgo));
            Assert.That(properties.UpdatedAt, Is.EqualTo(yesterday));
            Assert.That(properties.AccessedAt, Is.EqualTo(today));
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
                UserMetadata = "metadata",
                MaxMessageSizeInKilobytes = 2000
            };
            var properties = new QueueProperties(options);

            Assert.That(new CreateQueueOptions(properties), Is.EqualTo(options));
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
            Assert.That(queueDesc.UnknownProperties, Is.Not.Null);
            XDocument doc = QueuePropertiesExtensions.Serialize(queueDesc);

            XName queueDescriptionElementName = XName.Get("QueueDescription", AdministrationClientConstants.ServiceBusNamespace);
            XElement expectedQueueDecriptionElement = XElement.Parse(queueDescriptionXml).Descendants(queueDescriptionElementName).FirstOrDefault();
            XElement serializedQueueDescritionElement = doc.Descendants(queueDescriptionElementName).FirstOrDefault();
            XNode expectedChildNode = expectedQueueDecriptionElement.FirstNode;
            XNode actualChildNode = serializedQueueDescritionElement.FirstNode;
            while (expectedChildNode != null)
            {
                Assert.That(actualChildNode, Is.Not.Null);
                Assert.That(XNode.DeepEquals(expectedChildNode, actualChildNode), Is.True, $"QueueDescrition parsing and serialization combo didn't work as expected. {expectedChildNode.ToString()}");
                expectedChildNode = expectedChildNode.NextNode;
                actualChildNode = actualChildNode.NextNode;
            }
        }
    }
}
