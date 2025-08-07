// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueTriggerBindingIntegrationTests
    {
        private ITriggerBinding _binding;
        private InvariantCultureFixture _invariantCultureFixture;

        [SetUp]
        public void SetUp()
        {
            _invariantCultureFixture = new InvariantCultureFixture();
            IQueueTriggerArgumentBindingProvider provider = new UserTypeArgumentBindingProvider(new NullLoggerFactory());
            ParameterInfo pi = new StubParameterInfo("parameterName", typeof(UserDataType));
            var argumentBinding = provider.TryCreate(pi);

            QueueServiceClient queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            QueueClient queue = queueServiceClient.GetQueueClient("queueName-queuetriggerbindingintegrationtests");

            IWebJobsExceptionHandler exceptionHandler = new WebJobsExceptionHandler(new Mock<IHost>().Object);
            var enqueueWatcher = new SharedQueueWatcher();
            var mockConcurrencyManager = new Mock<ConcurrencyManager>(MockBehavior.Strict);
            _binding = new QueueTriggerBinding(
                "parameterName",
                queueServiceClient,
                queue,
                argumentBinding,
                new QueuesOptions(),
                exceptionHandler,
                enqueueWatcher,
                new NullLoggerFactory(),
                null,
                new QueueCausalityManager(new NullLoggerFactory()),
                mockConcurrencyManager.Object,
                null);
        }

        [TearDown]
        public void TearDown()
        {
            _invariantCultureFixture.Dispose();
        }

        [TestCase("RequestId", "4b957741-c22e-471d-9f0f-e1e8534b9cb6")]
        [TestCase("RequestReceivedTime", "8/16/2014 12:09:36 AM")]
        [TestCase("DeliveryCount", "8")]
        [TestCase("IsSuccess", "False")]
        public void BindAsync_IfUserDataType_ReturnsValidBindingData(string userPropertyName, string userPropertyValue)
        {
            // Arrange
            UserDataType expectedObject = new UserDataType();
            PropertyInfo userProperty = typeof(UserDataType).GetProperty(userPropertyName);
            var parseMethod = userProperty.PropertyType.GetMethod(
                "Parse", new Type[] { typeof(string) });
            object convertedPropertyValue = parseMethod.Invoke(null, new object[] { userPropertyValue });
            userProperty.SetValue(expectedObject, convertedPropertyValue);
            string messageContent = JsonConvert.SerializeObject(expectedObject);

            // Act
            ITriggerData data = _binding.BindAsync(messageContent, null).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.ValueProvider);
            Assert.NotNull(data.BindingData);
            Assert.True(data.BindingData.ContainsKey(userPropertyName));
            Assert.AreEqual(userProperty.GetValue(expectedObject, null), data.BindingData[userPropertyName]);
        }

        private class StubParameterInfo : ParameterInfo
        {
            public StubParameterInfo(string name, Type type)
            {
                NameImpl = name;
                ClassImpl = type;
            }
        }

        public class UserDataType
        {
            public Guid RequestId { get; set; }
            public string BlobFile { get; set; }
            public DateTime RequestReceivedTime { get; set; }
            public Int32 DeliveryCount { get; set; }
            public Boolean IsSuccess { get; set; }
        }
    }
}
