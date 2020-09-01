// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Management;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    public class ServiceVersionTests
    {
        [Test]
        public void ServiceVersionValidated()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey" +
                ";SharedAccessKey=[not_real];EntityPath=fake";

            // default enum of 0 should throw
            // https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-versioning
            Assert.That(
                () => new ServiceBusManagementClient(fakeConnection, new ServiceBusManagementClientOptions(default)),
                Throws.InstanceOf<ArgumentException>());

            // doesn't throw
            var client = new ServiceBusManagementClient(fakeConnection, new ServiceBusManagementClientOptions());

            // doesn't throw
            client = new ServiceBusManagementClient(
                fakeConnection,
                new ServiceBusManagementClientOptions(ServiceBusManagementClientOptions.ServiceVersion.V2017_04));
        }
    }
}
