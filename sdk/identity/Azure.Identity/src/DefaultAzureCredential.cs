// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a default <see cref="TokenCredential"/> authentication flow for applications that will be deployed to Azure.  The following credential
    /// types if enabled will be tried, in order:
    /// - <see cref="EnvironmentCredential"/>
    /// - <see cref="ManagedIdentityCredential"/>
    /// - <see cref="SharedTokenCacheCredential"/>
    /// - <see cref="InteractiveBrowserCredential"/>
    /// Consult the documentation of these credential types for more information on how they attempt authentication.
    /// </summary>
    public class DefaultAzureCredential : TokenCredential
    {
        private const string DefaultExceptionMessage = "The DefaultAzureCredential failed to retrieve from the included credentials.";
        private const string UnhandledExceptionMessage = "The DefaultAzureCredential failed due to an unhandled exception: ";
        private static readonly IExtendedTokenCredential[] s_defaultCredentialChain = GetDefaultAzureCredentialChain(new DefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null)), new DefaultAzureCredentialOptions());

        private readonly Exception[] _unavailableExceptions;
        private readonly IExtendedTokenCredential[] _sources;
        private readonly CredentialPipeline _pipeline;

        /// <summary>
        /// Creates an instance of the DefaultAzureCredential class.
        /// </summary>
        /// <param name="includeInteractiveCredentials">Specifies whether credentials requiring user interaction will be included in the default authentication flow.</param>
        public DefaultAzureCredential(bool includeInteractiveCredentials = false)
            : this((includeInteractiveCredentials) ? new DefaultAzureCredentialOptions { ExcludeInteractiveBrowserCredential = !includeInteractiveCredentials } : null)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="DefaultAzureCredential"/> class.
        /// </summary>
        /// <param name="options"></param>
        public DefaultAzureCredential(DefaultAzureCredentialOptions options)
            : this(new DefaultAzureCredentialFactory(CredentialPipeline.GetInstance(options)), options)
        {
        }

        internal DefaultAzureCredential(DefaultAzureCredentialFactory factory, DefaultAzureCredentialOptions options)
        {
            _pipeline = factory.Pipeline;

            _sources = GetDefaultAzureCredentialChain(factory, options);

            _unavailableExceptions = new Exception[_sources.Length];
        }

        /// <summary>
        /// Sequencially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully retured <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(false, requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sequencially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully retured <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async Task<AccessToken> GetTokenAsync(bool isAsync, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.DefaultAcureCredential.GetToken", requestContext);

            int i;

            for (i = 0; i < _sources.Length && _sources[i] != null; i++)
            {
                if (_unavailableExceptions[i] == null)
                {
                    ExtendedAccessToken exToken = isAsync ? await _sources[i].GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false) : _sources[i].GetToken(requestContext, cancellationToken);

                    if (exToken.Exception is null)
                    {
                        return scope.Succeeded(exToken.AccessToken);
                    }

                    if (exToken.Exception is CredentialUnavailableException)
                    {
                        _unavailableExceptions[i] = exToken.Exception;
                    }
                    else
                    {
                        Exception[] aggEx = new Exception[i + 1];

                        Array.Copy(_unavailableExceptions, 0, aggEx, 0, i);

                        aggEx[i] = exToken.Exception;

                        throw scope.Failed(AuthenticationFailedException.CreateAggregateException(UnhandledExceptionMessage + exToken.Exception.ToString(), new ReadOnlyMemory<object>(_sources, 0, i + 1), aggEx));
                    }
                }
            }

            throw scope.Failed(AuthenticationFailedException.CreateAggregateException(DefaultExceptionMessage, new ReadOnlyMemory<object>(_sources, 0, i), new ReadOnlyMemory<Exception>(_unavailableExceptions, 0, i)));
        }


        private static IExtendedTokenCredential[] GetDefaultAzureCredentialChain(DefaultAzureCredentialFactory factory, DefaultAzureCredentialOptions options)
        {
            if (options is null)
            {
                return s_defaultCredentialChain;
            }

            int i = 0;
            IExtendedTokenCredential[] chain = new IExtendedTokenCredential[4];

            if (!options.ExcludeEnvironmentCredential)
            {
                chain[i++] = factory.CreateEnvironmentCredential();
            }

            if (!options.ExcludeManagedIdentityCredential)
            {
                chain[i++] = factory.CreateManagedIdentityCredential(options.ManagedIdentityClientId);
            }

            if (!options.ExcludeSharedTokenCacheCredential)
            {
                chain[i++] = factory.CreateSharedTokenCacheCredential(options.SharedTokenCacheUsername ?? EnvironmentVariables.Username);
            }

            if (!options.ExcludeInteractiveBrowserCredential)
            {
                chain[i++] = factory.CreateInteractiveBrowserCredential();
            }

            if (i == 0)
            {
                throw new ArgumentException("At least one credential type must be included in the authentication flow.", nameof(options));
            }

            return chain;
        }
    }
}
