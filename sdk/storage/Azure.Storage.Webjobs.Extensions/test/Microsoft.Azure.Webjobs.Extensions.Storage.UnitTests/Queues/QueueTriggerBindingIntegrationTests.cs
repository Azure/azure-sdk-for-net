// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Triggers;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Queue;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Queues
{
    public class QueueTriggerBindingIntegrationTests : IClassFixture<InvariantCultureFixture>
    {
        private ITriggerBinding _binding;

        public QueueTriggerBindingIntegrationTests()
        {
            IQueueTriggerArgumentBindingProvider provider = new UserTypeArgumentBindingProvider();
            ParameterInfo pi = new StubParameterInfo("parameterName", typeof(UserDataType));
            var argumentBinding = provider.TryCreate(pi);
            
            var fakeAccount = new FakeStorage.FakeAccount();
            CloudQueue queue = fakeAccount.CreateCloudQueueClient().GetQueueReference("queueName");

            IWebJobsExceptionHandler exceptionHandler = new WebJobsExceptionHandler(new Mock<IHost>().Object);
            var enqueueWatcher = new Host.Queues.Listeners.SharedQueueWatcher();
            _binding = new QueueTriggerBinding("parameterName", queue, argumentBinding,
                new QueuesOptions(), exceptionHandler,
                enqueueWatcher,
                null, null);
        }

        [Theory]
        [InlineData("RequestId", "4b957741-c22e-471d-9f0f-e1e8534b9cb6")]
        [InlineData("RequestReceivedTime", "8/16/2014 12:09:36 AM")]
        [InlineData("DeliveryCount", "8")]
        [InlineData("IsSuccess", "False")]
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
            CloudQueueMessage message = new CloudQueueMessage(messageContent);

            // Act
            ITriggerData data = _binding.BindAsync(message, null).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.ValueProvider);
            Assert.NotNull(data.BindingData);
            Assert.True(data.BindingData.ContainsKey(userPropertyName));
            Assert.Equal(userProperty.GetValue(expectedObject, null), data.BindingData[userPropertyName]);
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
