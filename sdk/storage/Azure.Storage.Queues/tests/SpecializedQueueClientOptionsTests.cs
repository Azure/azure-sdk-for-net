// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class SpecializedQueueClientOptionsTests
    {
        [Test]
        public void SpecializedQueueClientOptions_DefaultConstructor()
        {
            var options = new SpecializedQueueClientOptions();

            Assert.IsNull(options.ClientSideEncryption);
        }

        [Test]
        public void SpecializedQueueClientOptions_WithVersion()
        {
            var options = new SpecializedQueueClientOptions(QueueClientOptions.ServiceVersion.V2024_11_04);

            Assert.IsNull(options.ClientSideEncryption);
        }

        [Test]
        public void SpecializedQueueClientOptions_SetClientSideEncryption()
        {
            var options = new SpecializedQueueClientOptions();
            var encryptionOptions = new QueueClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0);

            options.ClientSideEncryption = encryptionOptions;

            Assert.AreSame(encryptionOptions, options.ClientSideEncryption);
        }

        [Test]
        public void SpecializedQueueClientOptions_SetClientSideEncryption_Null()
        {
            var options = new SpecializedQueueClientOptions();
            options.ClientSideEncryption = null;

            Assert.IsNull(options.ClientSideEncryption);
        }
    }
}
