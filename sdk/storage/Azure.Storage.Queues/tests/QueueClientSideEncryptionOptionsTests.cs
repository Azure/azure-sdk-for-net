// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class QueueClientSideEncryptionOptionsTests
    {
        [Test]
        public void Constructor_SetsEncryptionVersion()
        {
            var options = new QueueClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0);

            Assert.AreEqual(ClientSideEncryptionVersion.V2_0, options.EncryptionVersion);
        }

        [Test]
        public void CloneFrom_Null_ReturnsNull()
        {
            var result = QueueClientSideEncryptionOptions.CloneFrom(null);

            Assert.IsNull(result);
        }

        [Test]
        public void CloneFrom_QueueOptions_CopiesDecryptionFailed()
        {
            var original = new QueueClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0);
            bool handlerCalled = false;
            original.DecryptionFailed += (sender, args) => handlerCalled = true;

            var cloned = QueueClientSideEncryptionOptions.CloneFrom(original);

            // Trigger event on cloned to verify handler was copied
            cloned.OnDecryptionFailed(null, new Exception("test"));
            Assert.IsTrue(handlerCalled);
        }

        [Test]
        public void UsingDecryptionFailureHandler_TrueWhenSubscribed()
        {
            var options = new QueueClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0);
            options.DecryptionFailed += (sender, args) => { };

            Assert.IsTrue(options.UsingDecryptionFailureHandler);
        }

        [Test]
        public void OnDecryptionFailed_InvokesHandler()
        {
            var options = new QueueClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0);
            Exception receivedException = null;
            object receivedSender = null;
            options.DecryptionFailed += (sender, args) =>
            {
                receivedSender = sender;
                receivedException = args.Exception;
            };

            var expectedException = new InvalidOperationException("decrypt failed");
            options.OnDecryptionFailed("testMessage", expectedException);

            Assert.AreEqual("testMessage", receivedSender);
            Assert.AreSame(expectedException, receivedException);
        }

        [Test]
        public void ClientSideDecryptionFailureEventArgs_ExposesException()
        {
            var options = new QueueClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0);
            ClientSideDecryptionFailureEventArgs capturedArgs = null;
            options.DecryptionFailed += (sender, args) => capturedArgs = args;

            var exception = new InvalidOperationException("test");
            options.OnDecryptionFailed(null, exception);

            Assert.IsNotNull(capturedArgs);
            Assert.AreSame(exception, capturedArgs.Exception);
        }
    }
}
