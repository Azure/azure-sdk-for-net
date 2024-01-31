// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceBus.Tests.Samples
{
    public class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
        }
    }
}
