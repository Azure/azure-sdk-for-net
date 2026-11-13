// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Compute.Batch.Custom;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class BatchSharedKeySigningTests
    {
        [Test]
        public async Task SignsContentLength(
            [Values("POST", "PUT", "GET", "DELETE")] string method,
            [Values(null, "", "{}")] string body,
            [Values(false, true)] bool isAsync)
        {
            byte[] key = Encoding.UTF8.GetBytes("unit-test-signing-key");
            var credential = new AzureNamedKeyCredential("account", Convert.ToBase64String(key));
            var options = new BatchClientOptions { Transport = new MockTransport(new MockResponse(200)) };
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new BatchNamedKeyCredentialPolicy(credential));
            using HttpMessage message = pipeline.CreateMessage();
            message.Request.Method = new RequestMethod(method);
            message.Request.Uri.Reset(new Uri("https://account.region.batch.azure.com/pools/pool/enable"));
            const string contentType = "application/json;odata=minimalmetadata";
            message.Request.Headers.SetValue("Content-Type", contentType);
            if (body != null)
            {
                message.Request.Content = RequestContent.Create(Encoding.UTF8.GetBytes(body));
            }

            if (isAsync)
            {
                await pipeline.SendAsync(message, CancellationToken.None);
            }
            else
            {
                pipeline.Send(message, CancellationToken.None);
            }

            Assert.IsTrue(message.Request.Headers.TryGetValue("ocp-date", out string date));
            Assert.IsTrue(message.Request.Headers.TryGetValue("Authorization", out string actual));
            string contentLength = body == null
                ? (method == "POST" ? "0" : "")
                : Encoding.UTF8.GetByteCount(body).ToString(System.Globalization.CultureInfo.InvariantCulture);
            string canonicalRequest = string.Join("\n", new[]
            {
                method, "", "", contentLength, "", contentType, "", "", "", "", "", ""
            }) + "\nocp-date:" + date + "\n/account/pools/pool/enable";
            using var hmac = new HMACSHA256(key);
            string expected = "SharedKey account:" + Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(canonicalRequest)));

            Assert.AreEqual(expected, actual);
        }
    }
}
