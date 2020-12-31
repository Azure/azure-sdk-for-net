// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
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

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), queueUriBuilder.Sas.ExpiresOn);
            Assert.AreEqual("", queueUriBuilder.Sas.Identifier);
            Assert.AreEqual(SasIPRange.Parse("168.1.5.60-168.1.5.70"), queueUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", queueUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, queueUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", queueUriBuilder.Sas.Resource);
            Assert.IsNull(queueUriBuilder.Sas.ResourceTypes);
            Assert.IsNull(queueUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", queueUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), queueUriBuilder.Sas.StartsOn);
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

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), queueUriBuilder.Sas.ExpiresOn);
            Assert.AreEqual("", queueUriBuilder.Sas.Identifier);
            Assert.AreEqual(SasIPRange.Parse("168.1.5.60-168.1.5.70"), queueUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", queueUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, queueUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", queueUriBuilder.Sas.Resource);
            Assert.IsNull(queueUriBuilder.Sas.ResourceTypes);
            Assert.IsNull(queueUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", queueUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), queueUriBuilder.Sas.StartsOn);
            Assert.AreEqual("2015-04-05", queueUriBuilder.Sas.Version);

            Assert.AreEqual("", queueUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void QueueUriBuilder_RegularUrl_CNAME()
        {
            var queueUriBUilder = new QueueUriBuilder(new Uri("http://www.contoso.com"));
            Assert.AreEqual(string.Empty, queueUriBUilder.AccountName);
        }

        [Test]
        public void QueueUriBuilder_MalformedSubdomain()
        {
            // core and queue swapped
            var queueUriBuilder1 = new QueueUriBuilder(new Uri("https://account.core.queue.windows.net/queue"));

            // account and queue swapped
            var queueUriBuilder2 = new QueueUriBuilder(new Uri("https://queue.account.core.windows.net/queue"));

            // wrong service
            var queueUriBuilder3 = new QueueUriBuilder(new Uri("https://account.blob.core.windows.net/queue"));

            // empty service
            var queueUriBuilder4 = new QueueUriBuilder(new Uri("https://account./queue"));

            Assert.AreEqual(string.Empty, queueUriBuilder1.AccountName);
            Assert.AreEqual(string.Empty, queueUriBuilder2.AccountName);
            Assert.AreEqual(string.Empty, queueUriBuilder3.AccountName);
            Assert.AreEqual(string.Empty, queueUriBuilder4.AccountName);
        }

        [Test]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void QueueBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.queue.core.windows.net/queue?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");
            QueueUriBuilder queueUriBuilder = new QueueUriBuilder(initialUri);

            // Act
            Uri resultUri = queueUriBuilder.ToUri();

            // Assert
            Assert.AreEqual(initialUri, resultUri);
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"));
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"));
        }

        [Test]
        public void QueueUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.queue.core.windows.net/queue?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");

            // Act
            try
            {
                new QueueUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.IsTrue(e.Message.Contains("was not recognized as a valid DateTime."));
            }
        }
    }
}
