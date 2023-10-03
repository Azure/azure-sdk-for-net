// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageSharedKeyPipelinePolicyTests
    {
        [Test]
        public async Task OnSendingRequest_DateShouldUpdate()
        {
            // Arrange
            MockRequest mockRequest = new MockRequest();
            mockRequest.Uri.Reset(new Uri("http://dummyaccount.blob.core.windows.net"));
            mockRequest.Method = RequestMethod.Get;
            var message = new HttpMessage(mockRequest, new StorageResponseClassifier());
            var policy = new StorageSharedKeyPipelinePolicy(new StorageSharedKeyCredential("accountName", Convert.ToBase64String(Encoding.UTF8.GetBytes("accountKey"))));

            // Act
            policy.OnSendingRequest(message);
            Assert.IsTrue(message.Request.Headers.TryGetValue("x-ms-date", out string firstDate));
            await Task.Delay(1000);
            policy.OnSendingRequest(message);

            // Assert
            Assert.IsTrue(message.Request.Headers.TryGetValue("x-ms-date", out string secondDate));
            Assert.IsTrue(Convert.ToDateTime(firstDate) < Convert.ToDateTime(secondDate));
        }

        [Test]
        public void OnSendingRequest_BuildSignature()
        {
            // Arrange
            var uri = new Uri("http://dummyaccount.blob.core.windows.net");
            var mockRequest = new MockRequest();
            mockRequest.Uri.Reset(uri);
            mockRequest.Method = RequestMethod.Get;
            mockRequest.Headers.Add("x-ms-version", "2021-10-04");
            mockRequest.Headers.Add("Accept-Ranges", "bytes");
            mockRequest.Headers.Add("Accept", "application/xml");
            mockRequest.Headers.Add("ETag", "\u00220x8DAB6A893E4304F\u0022");
            mockRequest.Headers.Add("Server", "Windows-Azure-Blob/1.0,Microsoft-HTTPAPI/2.0");
            mockRequest.Headers.Add("x-ms-request-id", "a12bc899-001e-003a-3a91-e8439e000000");
            mockRequest.Headers.Add("x-ms-client-request-id", "8f978611-738a-4cd4-a318-33b2f31068d9");
            mockRequest.Headers.Add("x-ms-creation-time", "Tue, 25 Oct 2022 16:47:17 GMT");
            mockRequest.Headers.Add("x-ms-Return-Client-request-id", "true");
            mockRequest.Headers.Add("x-ms-blob-content-md5", "2OD7XGeI0jSOrsBn8ZwHTw==");
            mockRequest.Headers.Add("x-ms-lease-status", "unlocked");
            mockRequest.Headers.Add("x-ms-meta-foo", "bar");
            mockRequest.Headers.Add("x-ms-meta-meta", "data");
            mockRequest.Headers.Add("x-ms-meta-Capital", "letter");
            mockRequest.Headers.Add("x-ms-meta-UPPER", "case");
            mockRequest.Headers.Add("x-ms-enable-snapshot-virtual-directory-access", "true");
            mockRequest.Headers.Add("x-ms-enabled-protocols", "NFS");
            mockRequest.Headers.Add("User-Agent", "azsdk-net-Storage.Files.Shares/12.13.0-alpha.20221025.1,(.NET 6.0.10; Microsoft Windows 10.0.22621)");
            mockRequest.Headers.Add("x-ms-date", "Wed, 23 Feb 2022 02:39:43 GMT"); // value will be replaced by StorageSharedKeyPipelinePolicy

            var message = new HttpMessage(mockRequest, new StorageResponseClassifier());
            var credentials = new StorageSharedKeyCredential("accountName", Convert.ToBase64String(Encoding.UTF8.GetBytes("accountKey")));
            var policy = new StorageSharedKeyPipelinePolicy(credentials);

            // Act
            policy.OnSendingRequest(message);
            Assert.IsTrue(message.Request.Headers.TryGetValue("x-ms-date", out string date));

            // Assert
            Assert.IsTrue(message.Request.Headers.TryGetValue(Constants.HeaderNames.Authorization, out string authentication));
            var signature = authentication.Substring(authentication.IndexOf(credentials.AccountName, StringComparison.Ordinal) + credentials.AccountName.Length + 1);

            var expectedStringToSign = new StringBuilder()
                .Append(RequestMethod.Get.ToString().ToUpperInvariant()).Append('\n')
                .Append('\n', 11)
                .Append("x-ms-blob-content-md5:2OD7XGeI0jSOrsBn8ZwHTw==\n")
                .Append("x-ms-client-request-id:8f978611-738a-4cd4-a318-33b2f31068d9\n")
                .Append("x-ms-creation-time:Tue, 25 Oct 2022 16:47:17 GMT\n")
                .Append("x-ms-date:").Append(date).Append("\n")
                .Append("x-ms-enabled-protocols:NFS\n")
                .Append("x-ms-enable-snapshot-virtual-directory-access:true\n")
                .Append("x-ms-lease-status:unlocked\n")
                .Append("x-ms-meta-capital:letter\n")
                .Append("x-ms-meta-foo:bar\n")
                .Append("x-ms-meta-meta:data\n")
                .Append("x-ms-meta-upper:case\n")
                .Append("x-ms-request-id:a12bc899-001e-003a-3a91-e8439e000000\n")
                .Append("x-ms-return-client-request-id:true\n")
                .Append("x-ms-version:2021-10-04\n")
                .Append($"/{credentials.AccountName}/")
                .ToString();

            var expectedSignature = StorageSharedKeyCredentialInternals.ComputeSasSignature(credentials, expectedStringToSign);

            Assert.AreEqual(expectedSignature, signature);
        }
    }
}
