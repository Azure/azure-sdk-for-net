﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Host.Queues;
using Newtonsoft.Json.Linq;
using Xunit;
using Azure.Storage.Queues.Models;
using Azure.WebJobs.Extensions.Storage.Common.Tests;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Queues
{
    public class QueueCausalityManagerTests
    {
        [Fact]
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

        [Fact]
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

        [Fact]
        public void SetOwner_IfUnsupportedValueType_Throws()
        {
            // Arrange
            var jobject = CreateJsonObject(123);
            Guid g = Guid.NewGuid();

            // Act & Assert
            ExceptionAssert.ThrowsArgumentNull(() => QueueCausalityManager.SetOwner(g, jobject), "token");
        }

        [Fact]
        public void GetOwner_IfMessageIsNotValidString_ReturnsNull()
        {
            QueueMessage message = CreateMessage("invalid");
            //Mock<IStorageQueueMessage> mock = new Mock<IStorageQueueMessage>(MockBehavior.Strict);
            //mock.Setup(m => m.AsString).Throws<DecoderFallbackException>();
            //IStorageQueueMessage message = mock.Object;

            TestOwnerIsNull(message);
        }

        [Fact]
        public void GetOwner_IfMessageIsNotValidJsonObject_ReturnsNull()
        {
            TestOwnerIsNull("non-json");
        }

        [Fact]
        public void GetOwner_IfMessageDoesNotHaveOwnerProperty_ReturnsNull()
        {
            TestOwnerIsNull("{'nonparent':null}");
        }

        [Fact]
        public void GetOwner_IfMessageOwnerIsNotString_ReturnsNull()
        {
            TestOwnerIsNull("{'$AzureWebJobsParentId':null}");
        }

        [Fact]
        public void GetOwner_IfMessageOwnerIsNotGuid_ReturnsNull()
        {
            TestOwnerIsNull("{'$AzureWebJobsParentId':'abc'}");
        }

        [Fact]
        public void GetOwner_IfMessageOwnerIsGuid_ReturnsThatGuid()
        {
            Guid expected = Guid.NewGuid();
            JObject json = new JObject();
            json.Add("$AzureWebJobsParentId", new JValue(expected.ToString()));

            TestOwnerEqual(expected, json.ToString());
        }

        private static void AssertOwnerEqual(Guid expectedOwner, string message)
        {
            Guid? owner = GetOwner(message);
            Assert.Equal(expectedOwner, owner);
        }

        private static void TestOwnerEqual(Guid expectedOwner, string message)
        {
            // Act
            Guid? owner = GetOwner(message);

            // Assert
            Assert.Equal(expectedOwner, owner);
        }

        private static void TestOwnerIsNull(string message)
        {
            TestOwnerIsNull(CreateMessage(message));
        }

        private static void TestOwnerIsNull(QueueMessage message)
        {
            // Act
            Guid? owner = QueueCausalityManager.GetOwner(message);

            // Assert
            Assert.Null(owner);
        }

        private static void AssertOwnerIsNull(string message)
        {
            Guid? owner = GetOwner(message);
            Assert.Null(owner);
        }

        private static Guid? GetOwner(string message)
        {
            return QueueCausalityManager.GetOwner(CreateMessage(message));
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
