// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.IO;
using System.Buffers;

namespace CadlRanchProjects.Tests
{
    public class OAuth2TestHelper
    {
        public class MockCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken(string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }

        // Only for bypassing HTTPS check purpose
        public class MockBearerTokenAuthenticationPolicy : BearerTokenAuthenticationPolicy
        {
            private readonly HttpPipelineTransport _transport;

            public MockBearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, HttpPipelineTransport transport) : base(credential, scopes)
            {
                _transport = transport;
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                return ProcessAsync(message, pipeline, true);
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                ProcessAsync(message, pipeline, false).GetAwaiter().GetResult();
            }

            protected new async ValueTask ProcessNextAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                await _transport.ProcessAsync(message).ConfigureAwait(false);
                await ProcessResponseBodyPolicyAsync(message, pipeline).ConfigureAwait(false);

                var response = message.Response;
                Type responseType = response.GetType();
                PropertyInfo propInfo = responseType.GetProperty("IsError", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)!;
                propInfo.SetValue(response, message.ResponseClassifier.IsErrorResponse(message));
            }

            // To bypass the HTTPS check in real BearerTokenAuthenticationPolicy, we have to short circuit to _transport inside MockBearerTokenAuthenticationPolicy, which also bypass the ResponseBodyPolicy. This policy is crucial to read response to memory so that when we disposing response the data won't lose. However, ResponseBodyPolicy is internal, so copy the logic directly here.
            // Reference: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/Pipeline/Internal/ResponseBodyPolicy.cs
            private async ValueTask ProcessResponseBodyPolicyAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                CancellationToken oldToken = message.CancellationToken;
                using CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(oldToken);

                Stream? responseContentStream = message.Response.ContentStream;
                if (responseContentStream == null || responseContentStream.CanSeek)
                {
                    return;
                }

                if (message.BufferResponse)
                {
                    try
                    {
                        var bufferedStream = new MemoryStream();
                        await CopyToAsync(responseContentStream, bufferedStream, cts).ConfigureAwait(false);

                        responseContentStream.Dispose();
                        bufferedStream.Position = 0;
                        message.Response.ContentStream = bufferedStream;
                    }
                    // We dispose stream on timeout or user cancellation so catch and check if cancellation token was cancelled
                    catch (Exception ex)
                        when (ex is ObjectDisposedException
                                  or IOException
                                  or OperationCanceledException
                                  or NotSupportedException)
                    {
                        throw;
                    }
                }

                async Task CopyToAsync(Stream source, Stream destination, CancellationTokenSource cancellationTokenSource)
                {
                    // Same value as Stream.CopyTo uses by default
                    int defaultCopyBufferSize = 81920;

                    var networkTimeout = TimeSpan.FromSeconds(100);
                    if (message.NetworkTimeout is TimeSpan networkTimeoutOverride)
                    {
                        networkTimeout = networkTimeoutOverride;
                    }

                    byte[] buffer = ArrayPool<byte>.Shared.Rent(defaultCopyBufferSize);
                    try
                    {
                        while (true)
                        {
                            cancellationTokenSource.CancelAfter(networkTimeout);
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in all targets
                            int bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in all targets
                            if (bytesRead == 0)
                                break;
                            await destination.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, bytesRead), cancellationTokenSource.Token).ConfigureAwait(false);
                        }
                    }
                    finally
                    {
                        cancellationTokenSource.CancelAfter(Timeout.InfiniteTimeSpan);
                        ArrayPool<byte>.Shared.Return(buffer);
                    }
                }
            }

            protected new void ProcessNext(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                _transport.Process(message);
            }

            private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
            {
                if (async)
                {
                    await AuthorizeRequestAsync(message).ConfigureAwait(false);
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    AuthorizeRequest(message);
                    ProcessNext(message, pipeline);
                }

                // Check if we have received a challenge or we have not yet issued the first request.
                if (message.Response.Status == (int)HttpStatusCode.Unauthorized && message.Response.Headers.Contains(HttpHeader.Names.WwwAuthenticate))
                {
                    // Attempt to get the TokenRequestContext based on the challenge.
                    // If we fail to get the context, the challenge was not present or invalid.
                    // If we succeed in getting the context, authenticate the request and pass it up the policy chain.
                    if (async)
                    {
                        if (await AuthorizeRequestOnChallengeAsync(message).ConfigureAwait(false))
                        {
                            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        if (AuthorizeRequestOnChallenge(message))
                        {
                            await ProcessNextAsync(message, pipeline);
                        }
                    }
                }
            }
        }
    }
}