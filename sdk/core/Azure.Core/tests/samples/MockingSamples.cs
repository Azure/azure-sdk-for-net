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
            mock.Setup(c => c.GetSecret("Name", null, default))
                .Returns(Response.FromValue(mockValue, mockResponse.Object));

            // Use the client mock
            SecretClient client = mock.Object;
            KeyVaultSecret secret = client.GetSecret("Name");

            #endregion

            Assert.NotNull(secret);
        }

        [Test]
        public void ClientMockWithPageable()
        {
            #region Snippet:ClientMockWithPageable
            // Create a client mock
            var mock = new Mock<SecretClient>();

            // Create a Page
            var deletedValue = SecretModelFactory.DeletedSecret(
                SecretModelFactory.SecretProperties(new Uri("http://example.com"))
            );
            var pageValues = new[] { deletedValue };
            var page = Page<DeletedSecret>.FromValues(pageValues, default, new Mock<Response>().Object);

            // Create a mock for the Pageable
            var pageableMock = new Mock<Pageable<DeletedSecret>> { CallBase = true };

            // Setup AsPages method in the Pageable mock
            pageableMock.Setup(c => c.AsPages(It.IsAny<string>(), default))
                .Returns(new[] { page });

            // Setup client method that returns Pageable
            mock.Setup(c => c.GetDeletedSecrets(default))
                .Returns(pageableMock.Object);

            // Use the client mock
            SecretClient client = mock.Object;
            DeletedSecret deletedSecret = client.GetDeletedSecrets().First();
            #endregion

            Assert.AreEqual(deletedSecret, deletedValue);
        }
    }
}
