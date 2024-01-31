// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;

namespace Azure
{
    public class CloudMachineTests
    {
        [Test]
        public void SerializationRoundTrip()
        {
            var cm = CloudMachine.Create(Guid.NewGuid().ToString(), "westus2");
            using var stream = new MemoryStream();
            cm.Save(stream);
            stream.Position = 0;

            var deserialized = new CloudMachine(stream);
            Assert.AreEqual(cm.Id, deserialized.Id);
            Assert.AreEqual(cm.DisplayName, deserialized.DisplayName);
            Assert.AreEqual(cm.Region, deserialized.Region);
            Assert.AreEqual(cm.SubscriptionId, deserialized.SubscriptionId);
        }

        [Test]
        public void DefaultCtor()
        {
            var path = Path.Combine(".azure", "cloudmachine.json");
            try
            {
                var cm = CloudMachine.Create(Guid.NewGuid().ToString(), "westus2");
                cm.Save(path);
                var deserialized = new CloudMachine();
                Assert.AreEqual(cm.Id, deserialized.Id);
                Assert.AreEqual(cm.DisplayName, deserialized.DisplayName);
                Assert.AreEqual(cm.Region, deserialized.Region);
                Assert.AreEqual(cm.SubscriptionId, deserialized.SubscriptionId);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
