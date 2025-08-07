// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class OptOutsRestClientTests
    {
        [Test]
        public void OptOutsRestClient_NullClientDiagnostics_ShouldThrow()
        {
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new OptOutsRestClient(null, httpPipeline, uri));
        }

        [Test]
        public void OptOutsRestClient_NullHttpPipeline_ShouldThrow()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new OptOutsRestClient(clientDiagnostics, null, endpoint));
        }

        [Test]
        public void OptOutsRestClient_NullEndpoint_ShouldThrow()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());

            Assert.Throws<ArgumentNullException>(() => new OptOutsRestClient(clientDiagnostics, httpPipeline, null));
        }

        [Test]
        public void OptOutsRestClient_NullVersion_ShouldThrow()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new OptOutsRestClient(clientDiagnostics, httpPipeline, uri, null));
        }

        [Test]
        public void OptOutsRestClient_CheckWithNullSender_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var recipients = Enumerable.Empty<OptOutRecipient>();

            try
            {
                client.Check(null, recipients);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public void OptOutsRestClient_CheckWithNullRecipients_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var from = "+123456789";

            try
            {
                client.Check(from, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("recipients", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task OptOutsRestClient_CheckAsyncWithNullSender_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var recipients = Enumerable.Empty<OptOutRecipient>();

            try
            {
                await client.CheckAsync(null, recipients);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task OptOutsRestClient_CheckAsyncWithNullRecipients_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var from = "+123456789";

            try
            {
                await client.CheckAsync(from, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("recipients", ex.ParamName);
                return;
            }
        }

        [Test]
        public void OptOutsRestClient_AddWithNullSender_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var recipients = Enumerable.Empty<OptOutRecipient>();

            try
            {
                client.Add(null, recipients);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public void OptOutsRestClient_AddWithNullRecipients_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var from = "+123456789";

            try
            {
                client.Add(from, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("recipients", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task OptOutsRestClient_AddAsyncWithNullSender_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var recipients = Enumerable.Empty<OptOutRecipient>();

            try
            {
                await client.AddAsync(null, recipients);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task OptOutsRestClient_AddAsyncWithNullRecipients_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var from = "+123456789";

            try
            {
                await client.AddAsync(from, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("recipients", ex.ParamName);
                return;
            }
        }

        [Test]
        public void OptOutsRestClient_RemoveWithNullSender_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var recipients = Enumerable.Empty<OptOutRecipient>();

            try
            {
                client.Remove(null, recipients);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public void OptOutsRestClient_RemoveWithNullRecipients_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var from = "+123456789";

            try
            {
                client.Remove(from, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("recipients", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task OptOutsRestClient_RemoveAsyncWithNullSender_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var recipients = Enumerable.Empty<OptOutRecipient>();

            try
            {
                await client.RemoveAsync(null, recipients);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
        }

        [Test]
        public async Task OptOutsRestClient_RemoveAsyncWithNullRecipients_ShouldThrow()
        {
            var client = CreateOptOutsRestClient();

            var from = "+123456789";

            try
            {
                await client.RemoveAsync(from, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("recipients", ex.ParamName);
                return;
            }
        }

        private OptOutsRestClient CreateOptOutsRestClient()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = new Uri("http://localhost");

            return new OptOutsRestClient(clientDiagnostics, httpPipeline, endpoint);
        }
    }
}