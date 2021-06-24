// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Creates a scope which will be used by <see cref="OnBehalfOfCredential"/> to request tokens on behalf of the user's token used to initialize
    /// the <see cref="UserAssertionScope"/> instance.
    /// </summary>
    public class UserAssertionScope : IDisposable
    {
        private static AsyncLocal<UserAssertionScope> _currentAsyncLocal = new();
        internal UserAssertion UserAssertion { get; }

        /// <summary>
        /// The current value of the <see cref="AsyncLocal{UserAssertion}"/>.
        /// </summary>
        internal static UserAssertionScope Current => _currentAsyncLocal.Value;

        /// <summary>
        /// Initializes a new instance of <see cref="UserAssertionScope"/> using the supplied access token.
        /// </summary>
        /// <param name="accessToken">The access token that will be used bu <see cref="OnBehalfOfCredential"/> when requesting On-Behalf-Of tokens.</param>
        public UserAssertionScope(string accessToken)
        {
            UserAssertion = new UserAssertion(accessToken);
            _currentAsyncLocal.Value = this;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="UserAssertionScope"/> using the supplied <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The <see cref="AccessToken"/> that will be used bu <see cref="OnBehalfOfCredential"/> when requesting On-Behalf-Of tokens.</param>
        public UserAssertionScope(AccessToken accessToken)
        {
            UserAssertion = new UserAssertion(accessToken.Token);
            _currentAsyncLocal.Value = this;
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _currentAsyncLocal.Value = default;
        }
    }
}
