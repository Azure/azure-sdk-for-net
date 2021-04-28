// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    ///
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
        ///
        /// </summary>
        /// <param name="accessToken"></param>
        public UserAssertionScope(string accessToken)
        {
            UserAssertion = new UserAssertion(accessToken);
            _currentAsyncLocal.Value = this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accessToken"></param>
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
