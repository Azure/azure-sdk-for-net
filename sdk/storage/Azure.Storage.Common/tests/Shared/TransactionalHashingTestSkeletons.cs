// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// We're going to make our tests retry a few additional error types that
    /// may be more wasteful, but are less likely to cause test failures.
    /// </summary>
    public static class TransactionalHashingTestSkeletons
    {
        internal static Action<Request> GetRequestHashAssertion(TransactionalHashAlgorithm algorithm, Func<Request, bool> isHashExpected = default, byte[] expectedHash = default)
        {
            Action<RequestHeaders, string> assertHash = (headers, headerName) =>
            {
                if (headers.TryGetValue(headerName, out string hash))
                {
                    if (expectedHash != default)
                    {
                        Assert.AreEqual(Convert.ToBase64String(expectedHash), hash);
                    }
                }
                else
                {
                    Assert.Fail($"{headerName} expected on request but was not found.");
                }
            };

            return request =>
            {
                if (isHashExpected != default && !isHashExpected(request))
                {
                    return;
                }

                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        assertHash(request.Headers, "Content-MD5");
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        assertHash(request.Headers, "x-ms-content-crc64");
                        break;
                    default:
                        throw new Exception("Bad TransactionalHashAlgorithm provided to Request hash assertion.");
                }
            };
        }

        /// <summary>
        /// Checks if service returns an error that content and transactional hash did not match.
        /// </summary>
        /// <param name="writeAction"></param>
        /// <param name="algorithm"></param>
        internal static void AssertWriteHashMismatch(AsyncTestDelegate writeAction, TransactionalHashAlgorithm algorithm)
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(writeAction);
            switch (algorithm)
            {
                case TransactionalHashAlgorithm.MD5:
                    Assert.AreEqual("Md5Mismatch", exception.ErrorCode);
                    break;
                case TransactionalHashAlgorithm.StorageCrc64:
                    Assert.AreEqual("Crc64Mismatch", exception.ErrorCode);
                    break;
                default:
                    throw new ArgumentException("Test arguments contain bad algorithm specifier.");
            }
        }

        // TODO make sync and async
        public static async Task TestOpenWriteSuccessfulHashComputationAsync<TClient, TParentClient, TClientOptions>(
            byte[] writeBuffer,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, UploadTransactionalHashingOptions, Task<Stream>> openWriteAsync) where TClientOptions : ClientOptions
        {
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);
            var writeStream = await openWriteAsync(client, hashingOptions);

            hashPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, 10))
            {
                await writeStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
            }
        }

        public static async Task TestOpenWriteMismatchedHashThrowsAsync<TClient, TParentClient, TClientOptions>(
            byte[] writeBuffer,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, UploadTransactionalHashingOptions, Task<Stream>> openWriteAsync) where TClientOptions : ClientOptions
        {
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            var clientOptions = getOptions();
            var tamperPolicy = new TamperStreamContentsPolicy();
            clientOptions.AddPolicy(tamperPolicy, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);
            var writeStream = await openWriteAsync(client, hashingOptions);

            AssertWriteHashMismatch(async () =>
            {
                tamperPolicy.TransformRequestBody = true;
                foreach (var _ in Enumerable.Range(0, 10))
                {
                    await writeStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
                }
            }, algorithm);
        }
    }
}
