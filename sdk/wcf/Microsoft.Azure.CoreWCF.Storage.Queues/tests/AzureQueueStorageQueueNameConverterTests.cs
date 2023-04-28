// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.CoreWCF.Channels;
using NUnit;
using NUnit.Framework;

namespace CoreWCF.AzureQueueStorage.Tests
{
    [TestFixture]
    public class AzureQueueStorageQueueNameConverterTests
    {
        [Test]
        public void GetAzureQueueStorageFormatQueueNameTest()
        {
            var uri = new Uri("net.aqs://localhost/private/QueueName");
            string result = AzureQueueStorageQueueNameConverter.GetAzureQueueStorageQueueName(uri);
            Assert.Equals(".\\Private$\\QueueName", result);
        }

        [Test]
        public void GetEndpointUrlTest()
        {
            string result = AzureQueueStorageQueueNameConverter.GetEndpointUrl("StorageAccountName","QueueName");
            Assert.Equals("net.aqs://localhost/private/StorageAccountName/QueueName", result);
        }
    }
}
