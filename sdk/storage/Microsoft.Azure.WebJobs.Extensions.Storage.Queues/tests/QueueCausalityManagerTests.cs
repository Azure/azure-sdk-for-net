// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueCausalityManagerTests
    {
        private QueueCausalityManager queueCausalityManager;

        [SetUp]
        public void Setup()
        {
            queueCausalityManager = new QueueCausalityManager(new NullLoggerFactory());
        }

        [Test]
        public void SetOwner_IfEmptyOwner_DoesNotAddOwner()
        {
            // Arrange
            var jobject = CreateJsonObject(new Payload { Val = 123 });
            Guid g = Guid.Empty;

            // Act
            QueueCausalityManager.SetOwner(g, jobject);

            // Assert
            AssertOwnerIsNull(jobject.ToString());
        }

        [Test]
        public void SetOwner_IfValidOwner_AddsOwner()
        {
            // Arrange
            var jobject = CreateJsonObject(new Payload { Val = 123 });
            Guid g = Guid.NewGuid();

            // Act
            QueueCausalityManager.SetOwner(g, jobject);

            // Assert
            AssertOwnerEqual(g, jobject.ToString());
        }

        [Test]
        public void SetOwner_IfUnsupportedValueType_Throws()
        {
            // Arrange
            var jobject = CreateJsonObject(123);
            Guid g = Guid.NewGuid();

            // Act & Assert
            ExceptionAssert.ThrowsArgumentNull(() => QueueCausalityManager.SetOwner(g, jobject), "token");
        }

        [Test]
        public void GetOwner_IfMessageIsNotValidString_ReturnsNull()
        {
            QueueMessage message = CreateMessage("invalid");
            //Mock<IStorageQueueMessage> mock = new Mock<IStorageQueueMessage>(MockBehavior.Strict);
            //mock.Setup(m => m.AsString).Throws<DecoderFallbackException>();
            //IStorageQueueMessage message = mock.Object;

            TestOwnerIsNull(message);
        }

        [Test]
        public void GetOwner_IfMessageIsNotValidJsonObject_ReturnsNull()
        {
            TestOwnerIsNull("non-json");
        }

        [Test]
        public void GetOwner_IfMessageDoesNotHaveOwnerProperty_ReturnsNull()
        {
            TestOwnerIsNull("{'nonparent':null}");
        }

        [Test]
        public void GetOwner_IfMessageOwnerIsNotString_ReturnsNull()
        {
            TestOwnerIsNull("{'$AzureWebJobsParentId':null}");
        }

        [Test]
        public void GetOwner_IfMessageOwnerIsNotGuid_ReturnsNull()
        {
            TestOwnerIsNull("{'$AzureWebJobsParentId':'abc'}");
        }

        [Test]
        public void GetOwner_IfMessageOwnerIsGuid_ReturnsThatGuid()
        {
            Guid expected = Guid.NewGuid();
            JObject json = new JObject();
            json.Add("$AzureWebJobsParentId", new JValue(expected.ToString()));

            TestOwnerEqual(expected, json.ToString());
        }

        private void AssertOwnerEqual(Guid expectedOwner, string message)
        {
            Guid? owner = GetOwner(message);
            Assert.AreEqual(expectedOwner, owner);
        }

        private void TestOwnerEqual(Guid expectedOwner, string message)
        {
            // Act
            Guid? owner = GetOwner(message);

            // Assert
            Assert.AreEqual(expectedOwner, owner);
        }

        private void TestOwnerIsNull(string message)
        {
            TestOwnerIsNull(CreateMessage(message));
        }

        private void TestOwnerIsNull(QueueMessage message)
        {
            // Act
            Guid? owner = queueCausalityManager.GetOwner(message);

            // Assert
            Assert.Null(owner);
        }

        private void AssertOwnerIsNull(string message)
        {
            Guid? owner = GetOwner(message);
            Assert.Null(owner);
        }

        private Guid? GetOwner(string message)
        {
            return queueCausalityManager.GetOwner(CreateMessage(message));
        }

        private static JObject CreateJsonObject(object value)
        {
            return JToken.FromObject(value) as JObject;
        }

        private static QueueMessage CreateMessage(string content)
        {
            return QueuesModelFactory.QueueMessage("testId", "testReceipt", content, 0);
        }

        public class Payload
        {
            public int Val { get; set; }
        }
    }
}
