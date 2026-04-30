// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Security.KeyVault.Secrets;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class MockingSamples
    {
        [Test]
        public void ClientMock()
        {
            #region Snippet:ClientMock
            // Create a mock response
            var mockResponse = new Mock<Response>();

            // Create a mock value
            var mockValue = SecretModelFactory.KeyVaultSecret(
                SecretModelFactory.SecretProperties(new Uri("http://example.com"))
            );

            // Create a client mock
            var mock = new Mock<SecretClient>();

            // Setup client method
            mock.Setup(c => c.GetSecret("Name", null, null, default))
                .Returns(Response.FromValue(mockValue, mockResponse.Object));

            // Use the client mock
            SecretClient client = mock.Object;
            KeyVaultSecret secret = client.GetSecret("Name");
            #endregion

            Assert.NotNull(secret);
        }
    }
}
