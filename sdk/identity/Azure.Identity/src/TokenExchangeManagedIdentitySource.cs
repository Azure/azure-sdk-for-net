// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class TokenExchangeManagedIdentitySource : ManagedIdentitySource
    {
        private TokenFileCache _tokenFileCache;
        private ClientAssertionCredential _clientAssertionCredential;
        private static readonly int DefaultBufferSize = 4096;

        private TokenExchangeManagedIdentitySource(CredentialPipeline pipeline, string tenantId, string clientId, string tokenFilePath)
            : base(pipeline)
        {
            _tokenFileCache = new TokenFileCache(tokenFilePath);
            _clientAssertionCredential = new ClientAssertionCredential(tenantId, clientId, _tokenFileCache.GetTokenFileContentsAsync, new ClientAssertionCredentialOptions { Pipeline = pipeline });
        }

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            string tokenFilePath = EnvironmentVariables.AzureFederatedTokenFile;
            string tenantId = EnvironmentVariables.TenantId;
            string clientId = options.ManagedIdentityId?._userAssignedId ?? EnvironmentVariables.ClientId;

            if (options.ExcludeTokenExchangeManagedIdentitySource || string.IsNullOrEmpty(tokenFilePath) || string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId))
            {
                AzureIdentityEventSource.Singleton.ManagedIdentitySourceAttempted("TokenExchangeManagedIdentitySource", false);
                return default;
            }

            AzureIdentityEventSource.Singleton.ManagedIdentitySourceAttempted("TokenExchangeManagedIdentitySource", true);
            return new TokenExchangeManagedIdentitySource(options.Pipeline, tenantId, clientId, tokenFilePath);
        }

        public async override ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            return async ? await _clientAssertionCredential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false) : _clientAssertionCredential.GetToken(context, cancellationToken);
        }

        protected override Request CreateRequest(string[] scopes)
        {
            throw new NotImplementedException();
        }

        private class TokenFileCache
        {
            private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
            private readonly string _tokenFilePath;
            private string _tokenFileContents;
            private DateTimeOffset _refreshOn = DateTimeOffset.MinValue;

            public TokenFileCache(string tokenFilePath)
            {
                _tokenFilePath = tokenFilePath;
            }

            public async Task<string> GetTokenFileContentsAsync(CancellationToken cancellationToken)
            {
                if (_refreshOn <= DateTimeOffset.UtcNow)
                {
                    try
                    {
                        await semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                        {
                            if (_refreshOn <= DateTimeOffset.UtcNow)
                            {
                                _tokenFileContents = await ReadAllTextAsync(_tokenFilePath).ConfigureAwait(false);

                                _refreshOn = DateTimeOffset.UtcNow.AddMinutes(5);
                            }
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
                return _tokenFileContents;
            }
        }

        // Since File.ReadAllTextAsync is not available in netstandard2.0, the below implementation is borrowed with some modifications from
        // https://github.com/dotnet/runtime/blob/8bcd03c650a85d523d542715e4e2543251f1dfa5/src/libraries/System.Private.CoreLib/src/System/IO/File.cs#L863-L906
        internal static Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default)
            => ReadAllTextAsync(path, Encoding.UTF8, cancellationToken);

        internal static Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
        {
            Argument.AssertNotNullOrEmpty(path, nameof(path));
            Argument.AssertNotNull(encoding, nameof(encoding));

            return cancellationToken.IsCancellationRequested
                ? Task.FromCanceled<string>(cancellationToken)
                : InternalReadAllTextAsync(path, encoding, cancellationToken);
        }

        private static async Task<string> InternalReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken)
        {
            char[] buffer = null;
            StreamReader sr = AsyncStreamReader(path, encoding);
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                buffer = ArrayPool<char>.Shared.Rent(sr.CurrentEncoding.GetMaxCharCount(DefaultBufferSize));
                StringBuilder sb = new StringBuilder();
                int totalRead = 0;
                while (true)
                {
                    int read = await sr.ReadAsync(buffer, totalRead, DefaultBufferSize - totalRead).ConfigureAwait(false);
                    if (read == 0)
                    {
                        return sb.ToString();
                    }

                    sb.Append(buffer, 0, read);
                    totalRead += read;
                }
            }
            finally
            {
                sr.Dispose();
                if (buffer != null)
                {
                    ArrayPool<char>.Shared.Return(buffer);
                }
            }
        }

        // If we use the path-taking constructors, we won't have FileOptions.Asynchronous set and
        // we will have asynchronous file access faked by the thread pool. We want the real thing.
        private static StreamReader AsyncStreamReader(string path, Encoding encoding)
            => new StreamReader(
                new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, DefaultBufferSize, FileOptions.Asynchronous | FileOptions.SequentialScan),
                encoding, detectEncodingFromByteOrderMarks: true);
    }
}
