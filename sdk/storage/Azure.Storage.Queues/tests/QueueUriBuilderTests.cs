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
        public QueueUriBuilderTests(bool async, QueueClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public void QueueUriBuilder_RegularUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://account.queue.core.windows.net?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("account.queue.core.windows.net"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.Empty);
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.EqualTo("comp=list"));

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_RegularUrl_QueueTest()
        {
            // Arrange
            var uriString = "https://account.queue.core.windows.net/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("account.queue.core.windows.net"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_RegularUrl_MessagesTest()
        {
            // Arrange
            var uriString = "https://account.queue.core.windows.net/queue/messages";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("account.queue.core.windows.net"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.Messages, Is.True);
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_RegularUrl_MessageIdTest()
        {
            // Arrange
            var uriString = "https://account.queue.core.windows.net/queue/messages/messageId";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("account.queue.core.windows.net"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.True);
            Assert.That(queueUriBuilder.MessageId, Is.EqualTo("messageId"));
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_RegularUrl_PortTest()
        {
            // Arrange
            var uriString = "https://account.queue.core.windows.net:8080/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("account.queue.core.windows.net"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(8080));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_RegularUrl_SasTest()
        {
            // Arrange
            var uriString = "https://account.queue.core.windows.net/queue?sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("account.queue.core.windows.net"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);

            Assert.That(queueUriBuilder.Sas.ExpiresOn, Is.EqualTo(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero)));
            Assert.That(queueUriBuilder.Sas.Identifier, Is.Empty);
            Assert.That(queueUriBuilder.Sas.IPRange, Is.EqualTo(SasIPRange.Parse("168.1.5.60-168.1.5.70")));
            Assert.That(queueUriBuilder.Sas.Permissions, Is.EqualTo("rw"));
            Assert.That(queueUriBuilder.Sas.Protocol, Is.EqualTo(SasProtocol.Https));
            Assert.That(queueUriBuilder.Sas.Resource, Is.EqualTo("b"));
            Assert.That(queueUriBuilder.Sas.ResourceTypes, Is.Null);
            Assert.That(queueUriBuilder.Sas.Services, Is.Null);
            Assert.That(queueUriBuilder.Sas.Signature, Is.EqualTo("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk="));
            Assert.That(queueUriBuilder.Sas.StartsOn, Is.EqualTo(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero)));
            Assert.That(queueUriBuilder.Sas.Version, Is.EqualTo("2015-04-05"));

            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.Empty);
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.EqualTo("comp=list"));

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_QueueTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_MessagesTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue/messages";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.True);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_MessageIdTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue/messages/messageId";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.True);
            Assert.That(queueUriBuilder.MessageId, Is.EqualTo("messageId"));
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_PortTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1:8080/account";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(8080));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.Empty);
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_PortTestQueue()
        {
            // Arrange
            var uriString = "https://127.0.0.1:8080/account/queue";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(8080));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_AccountOnlyTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.Empty);
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);
            Assert.That(queueUriBuilder.Sas, Is.Null);
            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_IPStyleUrl_SasTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/queue?sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var queueUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(queueUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(queueUriBuilder.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(queueUriBuilder.Port, Is.EqualTo(443));
            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(queueUriBuilder.QueueName, Is.EqualTo("queue"));
            Assert.That(queueUriBuilder.Messages, Is.False);
            Assert.That(queueUriBuilder.MessageId, Is.Empty);

            Assert.That(queueUriBuilder.Sas.ExpiresOn, Is.EqualTo(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero)));
            Assert.That(queueUriBuilder.Sas.Identifier, Is.Empty);
            Assert.That(queueUriBuilder.Sas.IPRange, Is.EqualTo(SasIPRange.Parse("168.1.5.60-168.1.5.70")));
            Assert.That(queueUriBuilder.Sas.Permissions, Is.EqualTo("rw"));
            Assert.That(queueUriBuilder.Sas.Protocol, Is.EqualTo(SasProtocol.Https));
            Assert.That(queueUriBuilder.Sas.Resource, Is.EqualTo("b"));
            Assert.That(queueUriBuilder.Sas.ResourceTypes, Is.Null);
            Assert.That(queueUriBuilder.Sas.Services, Is.Null);
            Assert.That(queueUriBuilder.Sas.Signature, Is.EqualTo("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk="));
            Assert.That(queueUriBuilder.Sas.StartsOn, Is.EqualTo(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero)));
            Assert.That(queueUriBuilder.Sas.Version, Is.EqualTo("2015-04-05"));

            Assert.That(queueUriBuilder.Query, Is.Empty);

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void QueueUriBuilder_RegularUrl_CNAME()
        {
            var queueUriBUilder = new QueueUriBuilder(new Uri("http://www.contoso.com"));
            Assert.That(queueUriBUilder.AccountName, Is.Empty);
        }

        [RecordedTest]
        public void QueueUriBuilder_AccountNamePeriod()
        {
            var queueUriBuilder = new QueueUriBuilder(new Uri("https://account.z.queue.core.windows.net/share/dir"));

            Assert.That(queueUriBuilder.AccountName, Is.EqualTo("account"));
        }

        [RecordedTest]
        public void QueueUriBuilder_AccountNameError()
        {
            var queueUriBuilder = new QueueUriBuilder(new Uri("http://notaurl"));

            Assert.That(queueUriBuilder.AccountName, Is.Empty);
        }

        [RecordedTest]
        public void QueueUriBuilder_MalformedSubdomain()
        {
            // account and queue swapped
            var queueUriBuilder1 = new QueueUriBuilder(new Uri("https://queue.account.core.windows.net/queue"));

            // wrong service
            var queueUriBuilder2 = new QueueUriBuilder(new Uri("https://account.blob.core.windows.net/queue"));

            // empty service
            var queueUriBuilder3 = new QueueUriBuilder(new Uri("https://account./queue"));

            Assert.That(queueUriBuilder1.AccountName, Is.Empty);
            Assert.That(queueUriBuilder2.AccountName, Is.Empty);
            Assert.That(queueUriBuilder3.AccountName, Is.Empty);
        }

        [RecordedTest]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void QueueBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.queue.core.windows.net/queue?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");
            QueueUriBuilder queueUriBuilder = new QueueUriBuilder(initialUri);

            // Act
            Uri resultUri = queueUriBuilder.ToUri();

            // Assert
            Assert.That(resultUri, Is.EqualTo(initialUri));
            Assert.That(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"), Is.True);
            Assert.That(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"), Is.True);
        }

        [RecordedTest]
        public void QueueUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.queue.core.windows.net/queue?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");

            // Act
            try
            {
                new QueueUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.That(e.Message.Contains("was not recognized as a valid DateTime."), Is.True);
            }
        }
    }
}
