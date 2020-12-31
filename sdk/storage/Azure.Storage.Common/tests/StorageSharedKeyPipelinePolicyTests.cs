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
    }
}
