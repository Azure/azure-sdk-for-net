// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsRestClientTest
    {
        [Test]
        public void SmsRestClient_NullClientDiagnostics_ShouldThrow()
        {
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());
            var uri = "http://localhost";

            Assert.Throws<ArgumentNullException>(() => new SmsRestClient(null, httpPipeline, uri));
        }

        [Test]
        public void SmsRestClient_NullHttpPipeline_ShouldThrow()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var endpoint = "http://localhost";

            Assert.Throws<ArgumentNullException>(() => new SmsRestClient(clientDiagnostics, null, endpoint));
        }

        [Test]
        public void SmsRestClient_NullEndpoint_ShouldThrow()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());

            Assert.Throws<ArgumentNullException>(() => new SmsRestClient(clientDiagnostics, httpPipeline, null));
        }

        [Test]
        public void SmsRestClient_NullVersion_ShouldThrow()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var uri = "http://localhost";

            Assert.Throws<ArgumentNullException>(() => new SmsRestClient(clientDiagnostics, httpPipeline, uri, null));
        }

        [Test]
        public void SmsRestClient_SendWithNullSender_ShouldThrow()
        {
            var client = CreateSmsRestClient();

            var recipients = Enumerable.Empty<SmsRecipient>();
            var message = "Message";

            try
            {
                client.Send(null, recipients, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public void SmsRestClient_SendWithNullRecipients_ShouldThrow()
        {
            var client = CreateSmsRestClient();

            var from = "+123456789";
            var message = "Message";

            try
            {
                client.Send(from, null, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("smsRecipients", ex.ParamName);
                return;
            }
        }

        [Test]
        public void SmsRestClient_SendWithNullMessage_ShouldThrow()
        {
            var client = CreateSmsRestClient();

            var from = "+123456789";
            var recipients = Enumerable.Empty<SmsRecipient>();

            try
            {
                client.Send(from, recipients, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("message", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task SmsRestClient_SendAsyncWithNullSender_ShouldThrow()
        {
            var client = CreateSmsRestClient();

            var recipients = Enumerable.Empty<SmsRecipient>();
            var message = "Message";

            try
            {
                await client.SendAsync(null, recipients, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task SmsRestClient_SendAsyncWithNullRecipients_ShouldThrow()
        {
            var client = CreateSmsRestClient();

            var from = "+123456789";
            var message = "Message";

            try
            {
                await client.SendAsync(from, null, message);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("smsRecipients", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task SmsRestClient_SendAsyncWithNullMessage_ShouldThrow()
        {
            var client = CreateSmsRestClient();

            var from = "+123456789";
            var recipients = Enumerable.Empty<SmsRecipient>();

            try
            {
                await client.SendAsync(from, recipients, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("message", ex.ParamName);
                return;
            }
        }

        private SmsRestClient CreateSmsRestClient()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = "http://localhost";

            return new SmsRestClient(clientDiagnostics, httpPipeline, endpoint);
        }
    }
}