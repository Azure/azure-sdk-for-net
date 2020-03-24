// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ReceiptClient"/> class.
    /// </summary>
    [TestFixture]
    public class ReceiptClientTests
    {
        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheEndpoint()
        {
            var credential = new FormRecognizerApiKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(null, credential));
            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(null, credential, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheCredential()
        {
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(endpoint, null));
            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(endpoint, null, new FormRecognizerClientOptions()));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient"/> constructors.
        /// </summary>
        [Test]
        [Ignore("Argument validation not implemented yet.")]
        public void ConstructorRequiresTheOptions()
        {
            var endpoint = new Uri("http://localhost");
            var credential = new FormRecognizerApiKeyCredential("key");

            Assert.Throws<ArgumentNullException>(() => new ReceiptClient(endpoint, credential, null));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.ExtractReceipt(Stream, FormContentType, bool, CancellationToken)"/>
        /// and <see cref="ReceiptClient.ExtractReceiptAsync(Stream, FormContentType, bool, CancellationToken)"/> methods.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("Argument validation not implemented yet.")]
        public void ExtractReceiptWithStreamRequiresTheStream(bool async)
        {
            var endpoint = new Uri("http://localhost");
            var credential = new FormRecognizerApiKeyCredential("key");
            var client = new ReceiptClient(endpoint, credential);

            if (async)
            {
                Assert.ThrowsAsync<ArgumentNullException>(async () => await client.ExtractReceiptAsync(null, FormContentType.Jpeg));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => client.ExtractReceipt(null, FormContentType.Jpeg));
            }
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.ExtractReceipt(Stream, FormContentType, bool, CancellationToken)"/>
        /// and <see cref="ReceiptClient.ExtractReceiptAsync(Stream, FormContentType, bool, CancellationToken)"/> methods.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ExtractReceiptWithStreamRespectsTheCancellationToken(bool async)
        {
            var endpoint = new Uri("http://localhost");
            var credential = new FormRecognizerApiKeyCredential("key");
            var client = new ReceiptClient(endpoint, credential);

            using var stream = new MemoryStream(Array.Empty<byte>());
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            if (async)
            {
                Assert.ThrowsAsync<TaskCanceledException>(async () => await client.ExtractReceiptAsync(stream, FormContentType.Jpeg, cancellationToken: cancellationSource.Token));
            }
            else
            {
                Assert.Throws<TaskCanceledException>(() => client.ExtractReceipt(stream, FormContentType.Jpeg, cancellationToken: cancellationSource.Token));
            }
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.ExtractReceipt(Uri, bool, CancellationToken)"/>
        /// and <see cref="ReceiptClient.ExtractReceiptAsync(Uri, bool, CancellationToken)"/> methods.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("Argument validation not implemented yet.")]
        public void ExtractReceiptWithEndpointRequiresTheUri(bool async)
        {
            var endpoint = new Uri("http://localhost");
            var credential = new FormRecognizerApiKeyCredential("key");
            var client = new ReceiptClient(endpoint, credential);

            if (async)
            {
                Assert.ThrowsAsync<ArgumentNullException>(async () => await client.ExtractReceiptAsync(null));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => client.ExtractReceipt(null));
            }
        }

        /// <summary>
        /// Verifies functionality of the <see cref="ReceiptClient.ExtractReceipt(Uri, bool, CancellationToken)"/>
        /// and <see cref="ReceiptClient.ExtractReceiptAsync(Uri, bool, CancellationToken)"/> methods.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ExtractReceiptWithEndpointRespectsTheCancellationToken(bool async)
        {
            var endpoint = new Uri("http://localhost");
            var credential = new FormRecognizerApiKeyCredential("key");
            var client = new ReceiptClient(endpoint, credential);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            if (async)
            {
                Assert.ThrowsAsync<TaskCanceledException>(async () => await client.ExtractReceiptAsync(endpoint, cancellationToken: cancellationSource.Token));
            }
            else
            {
                Assert.Throws<TaskCanceledException>(() => client.ExtractReceipt(endpoint, cancellationToken: cancellationSource.Token));
            }
        }
    }
}
