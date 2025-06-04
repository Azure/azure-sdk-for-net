// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Messaging.ServiceBus.Administration;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    public class ServiceVersionTests
    {
        [Test]
        public void ServiceVersionValidated()
        {
            var fakeNamespace = "not-real.servicebus.windows.net";
            var fakeCredential = Mock.Of<TokenCredential>();

            // default enum of 0 should throw
            // https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-versioning
            Assert.That(
                () => new ServiceBusAdministrationClient(fakeNamespace, fakeCredential, new ServiceBusAdministrationClientOptions(default)),
                Throws.InstanceOf<ArgumentException>());

            // doesn't throw
            var client = new ServiceBusAdministrationClient(fakeNamespace, fakeCredential, new ServiceBusAdministrationClientOptions());

            // doesn't throw
            client = new ServiceBusAdministrationClient(
                fakeNamespace,
                fakeCredential,
                new ServiceBusAdministrationClientOptions(ServiceBusAdministrationClientOptions.ServiceVersion.V2017_04));
        }
    }
}
