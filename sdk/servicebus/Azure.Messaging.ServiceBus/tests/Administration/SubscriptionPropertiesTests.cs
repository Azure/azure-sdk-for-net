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

            Assert.That(ex.Message, Does.StartWith($"Entity path '{longName}' exceeds the '260' character limit."));
            Assert.That(ex.ParamName, Is.EqualTo($"ForwardTo"));
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardDeadLetteredMessagesToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new SubscriptionProperties("sb://fakeservicebus", "Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}");

            Assert.That(ex.Message, Does.StartWith($"Entity path '{longName}' exceeds the '260' character limit."));
            Assert.That(ex.ParamName, Is.EqualTo($"ForwardDeadLetteredMessagesTo"));
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
            Assert.That(sub.ForwardTo, Is.EqualTo($"{baseUrl}{longName}"));
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
            Assert.That(sub.ForwardDeadLetteredMessagesTo, Is.EqualTo($"{baseUrl}{longName}"));
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
            Assert.That(properties.TopicName, Is.EqualTo("topicName"));
            Assert.That(properties.SubscriptionName, Is.EqualTo("subscriptionName"));
            Assert.That(properties.LockDuration, Is.EqualTo(TimeSpan.FromSeconds(30)));
            Assert.That(properties.RequiresSession, Is.True);
            Assert.That(properties.DefaultMessageTimeToLive, Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(properties.AutoDeleteOnIdle, Is.EqualTo(TimeSpan.FromMinutes(5)));
            Assert.That(properties.DeadLetteringOnMessageExpiration, Is.True);
            Assert.That(properties.MaxDeliveryCount, Is.EqualTo(5));
            Assert.That(properties.EnableBatchedOperations, Is.False);
            Assert.That(properties.Status, Is.EqualTo(EntityStatus.Active));
            Assert.That(properties.ForwardTo, Is.EqualTo("forward"));
            Assert.That(properties.ForwardDeadLetteredMessagesTo, Is.EqualTo("dlq"));
            Assert.That(properties.UserMetadata, Is.EqualTo("metadata"));
        }

        [Test]
        public void CanCreateSubscriptionRuntimePropertiesFromFactory()
        {
            var today = DateTimeOffset.Now;
            var yesterday = today.Subtract(TimeSpan.FromDays(1));
            var twoDaysAgo = today.Subtract(TimeSpan.FromDays(2));
            var properties = ServiceBusModelFactory.SubscriptionRuntimeProperties(
                "topicName",
                "subscriptionName",
                10,
                1,
                5,
                2,
                18,
                twoDaysAgo,
                yesterday,
                today);
            Assert.That(properties.TopicName, Is.EqualTo("topicName"));
            Assert.That(properties.SubscriptionName, Is.EqualTo("subscriptionName"));
            Assert.That(properties.ActiveMessageCount, Is.EqualTo(10));
            Assert.That(properties.DeadLetterMessageCount, Is.EqualTo(1));
            Assert.That(properties.TransferDeadLetterMessageCount, Is.EqualTo(5));
            Assert.That(properties.TransferMessageCount, Is.EqualTo(2));
            Assert.That(properties.TotalMessageCount, Is.EqualTo(18));
            Assert.That(properties.CreatedAt, Is.EqualTo(twoDaysAgo));
            Assert.That(properties.UpdatedAt, Is.EqualTo(yesterday));
            Assert.That(properties.AccessedAt, Is.EqualTo(today));
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

            Assert.That(new CreateSubscriptionOptions(properties), Is.EqualTo(options));
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
            SubscriptionProperties subscriptionDesc = await SubscriptionPropertiesExtensions.ParseResponseAsync("abcd", response);
            Assert.That(subscriptionDesc.UnknownProperties, Is.Not.Null);
            XDocument doc = SubscriptionPropertiesExtensions.Serialize(subscriptionDesc);

            XName subscriptionDescriptionElementName = XName.Get("SubscriptionDescription", AdministrationClientConstants.ServiceBusNamespace);
            XElement expectedSubscriptionDecriptionElement = XElement.Parse(subscriptionDescriptionXml).Descendants(subscriptionDescriptionElementName).FirstOrDefault();
            XElement serializedSubscriptionDescritionElement = doc.Descendants(subscriptionDescriptionElementName).FirstOrDefault();
            XNode expectedChildNode = expectedSubscriptionDecriptionElement.FirstNode;
            XNode actualChildNode = serializedSubscriptionDescritionElement.FirstNode;
            while (expectedChildNode != null)
            {
                Assert.That(actualChildNode, Is.Not.Null);
                Assert.That(XNode.DeepEquals(expectedChildNode, actualChildNode), Is.True, $"SubscriptionDescrition parsing and serialization combo didn't work as expected. {expectedChildNode.ToString()}");
                expectedChildNode = expectedChildNode.NextNode;
                actualChildNode = actualChildNode.NextNode;
            }
        }
    }
}
