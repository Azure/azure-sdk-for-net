// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.CoreWCF.Channels;
using Xunit;

namespace CoreWCF.AzureQueueStorage.Tests
{
    public class AzureQueueStorageQueueNameConverterTests
    {
        [Fact]
        public void GetAzureQueueStorageFormatQueueNameTest()
        {
            var uri = new Uri("net.aqs://localhost/private/QueueName");
            string result = AzureQueueStorageQueueNameConverter.GetAzureQueueStorageQueueName(uri);
            Assert.Equal(".\\Private$\\QueueName", result);
        }

        [Fact]
        public void GetEndpointUrlTest()
        {
            string result = AzureQueueStorageQueueNameConverter.GetEndpointUrl("StorageAccountName","QueueName");
            Assert.Equal("net.aqs://localhost/private/StorageAccountName/QueueName", result);
        }
    }
}
