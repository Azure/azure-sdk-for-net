// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Provides a <see cref="TokenCredential"/> implementation which chains multiple <see cref="TokenCredential"/> implementations to be tried in order
    /// until one of the getToken methods returns a non-default <see cref="AccessToken"/>.
    /// </summary>
    public class ChainedTokenCredential : TokenCredential
    {
        private const string AggregateAllUnavailableErrorMessage = "The ChainedTokenCredential failed to retrieve a token from the included credentials.";

        private const string AggregateCredentialFailedErrorMessage = "The ChainedTokenCredential failed due to an unhandled exception: ";

        private readonly TokenCredential[] _sources;

        /// <summary>
        /// Creates an instance with the specified <see cref="TokenCredential"/> sources.
        /// </summary>
        /// <param name="sources">The ordered chain of <see cref="TokenCredential"/> implementations to tried when calling <see cref="GetToken"/> or <see cref="GetTokenAsync"/></param>
        public ChainedTokenCredential(params TokenCredential[] sources)
        {
            if (sources is null) throw new ArgumentNullException(nameof(sources));

            if (sources.Length == 0)
            {
                throw new ArgumentException("sources must not be empty", nameof(sources));
            }

            for (int i = 0; i < sources.Length; i++)
            {
                if (sources[i] == null)
                {
                    throw new ArgumentException("sources must not contain null", nameof(sources));
                }

            }
            _sources = sources;
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully obtained <see cref="AccessToken"/>. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            List<Exception> exceptions = new List<Exception>();

            for (int i = 0; i < _sources.Length; i++)
            {
                try
                {
                    return _sources[i].GetToken(requestContext, cancellationToken);
                }
                catch (CredentialUnavailableException e)
                {
                    exceptions.Add(e);
                }
                catch (Exception e) when (!(e is OperationCanceledException))
                {
                    exceptions.Add(e);

                    throw AuthenticationFailedException.CreateAggregateException(AggregateCredentialFailedErrorMessage + e.Message, new ReadOnlyMemory<object>(_sources, 0, i + 1), exceptions);
                }
            }

            throw AuthenticationFailedException.CreateAggregateException(AggregateAllUnavailableErrorMessage, _sources, exceptions);
        }

        /// <summary>
        /// Sequentially calls <see cref="TokenCredential.GetToken"/> on all the specified sources, returning the first successfully obtained <see cref="AccessToken"/>. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The first <see cref="AccessToken"/> returned by the specified sources. Any credential which raises a <see cref="CredentialUnavailableException"/> will be skipped.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            List<Exception> exceptions = new List<Exception>();

            for (int i = 0; i < _sources.Length; i++)
            {
                try
                {
                    return await _sources[i].GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);
                }
                catch (CredentialUnavailableException e)
                {
                    exceptions.Add(e);
                }
                catch (Exception e) when (!(e is OperationCanceledException))
                {
                    exceptions.Add(e);

                    throw AuthenticationFailedException.CreateAggregateException(AggregateCredentialFailedErrorMessage + e.Message, new ReadOnlyMemory<object>(_sources, 0, i + 1), exceptions);
                }
            }

            throw AuthenticationFailedException.CreateAggregateException(AggregateAllUnavailableErrorMessage, _sources, exceptions);
        }
    }
}
