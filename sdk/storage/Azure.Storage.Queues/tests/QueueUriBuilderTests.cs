﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    public class QueueUriBuilderTests : QueueTestBase
    {
        public QueueUriBuilderTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void QueueUriBuilder_RegularUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://account.core.queue.windows.net?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("account.core.queue.windows.net", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("", queueUriBuilder.AccountName);
            Assert.AreEqual("", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("comp=list", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_RegularUrl_QueueTest()
        {
            // Arrange
            var uriString = "https://account.core.queue.windows.net/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("account.core.queue.windows.net", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_RegularUrl_MessagesTest()
        {
            // Arrange
            var uriString = "https://account.core.queue.windows.net/queue/messages";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("account.core.queue.windows.net", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("", queueUriBuilder.AccountName);
            Assert.IsTrue(queueUriBuilder.Messages);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_RegularUrl_MessageIdTest()
        {
            // Arrange
            var uriString = "https://account.core.queue.windows.net/queue/messages/messageId";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("account.core.queue.windows.net", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsTrue(queueUriBuilder.Messages);
            Assert.AreEqual("messageId", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_RegularUrl_PortTest()
        {
            // Arrange
            var uriString = "https://account.core.queue.windows.net:8080/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("account.core.queue.windows.net", queueUriBuilder.Host);
            Assert.AreEqual(8080, queueUriBuilder.Port);
            Assert.AreEqual("", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_RegularUrl_SasTest()
        {
            // Arrange
            var uriString = "https://account.core.queue.windows.net/queue?sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("account.core.queue.windows.net", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), queueUriBuilder.Sas.ExpiryTime);
            Assert.AreEqual("", queueUriBuilder.Sas.Identifier);
            Assert.AreEqual(IPRange.Parse("168.1.5.60-168.1.5.70"), queueUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", queueUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, queueUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", queueUriBuilder.Sas.Resource);
            Assert.AreEqual("", queueUriBuilder.Sas.ResourceTypes);
            Assert.AreEqual("", queueUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", queueUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), queueUriBuilder.Sas.StartTime);
            Assert.AreEqual("2015-04-05", queueUriBuilder.Sas.Version);

            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_IPStyleUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("account", queueUriBuilder.AccountName);
            Assert.AreEqual("", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("comp=list", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_IPStyleUrl_QueueTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("account", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_IPStyleUrl_MessagesTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue/messages";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("account", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsTrue(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_IPStyleUrl_MessageIdTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue/messages/messageId";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("account", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsTrue(queueUriBuilder.Messages);
            Assert.AreEqual("messageId", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_IPStyleUrl_PortTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1:8080/account/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", queueUriBuilder.Host);
            Assert.AreEqual(8080, queueUriBuilder.Port);
            Assert.AreEqual("account", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_IPStyleUrl_AccountOnlyTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("account", queueUriBuilder.AccountName);
            Assert.AreEqual("", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);
            Assert.IsNull(queueUriBuilder.Sas);
            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_IPStyleUrl_SasTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue?sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", queueUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", queueUriBuilder.Host);
            Assert.AreEqual(443, queueUriBuilder.Port);
            Assert.AreEqual("account", queueUriBuilder.AccountName);
            Assert.AreEqual("queue", queueUriBuilder.QueueName);
            Assert.IsFalse(queueUriBuilder.Messages);
            Assert.AreEqual("", queueUriBuilder.MessageId);

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), queueUriBuilder.Sas.ExpiryTime);
            Assert.AreEqual("", queueUriBuilder.Sas.Identifier);
            Assert.AreEqual(IPRange.Parse("168.1.5.60-168.1.5.70"), queueUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", queueUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, queueUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", queueUriBuilder.Sas.Resource);
            Assert.AreEqual("", queueUriBuilder.Sas.ResourceTypes);
            Assert.AreEqual("", queueUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", queueUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), queueUriBuilder.Sas.StartTime);
            Assert.AreEqual("2015-04-05", queueUriBuilder.Sas.Version);

            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }
    }
}
