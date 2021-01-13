// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// Represents Azure Remote Rendering account details.
    /// </summary>
    public class RemoteRenderingAccount
    {
        /// <summary>
        /// Gets the Azure Remote Rendering account domain.
        /// </summary>
        public string AccountDomain { get; }

        /// <summary>
        /// Gets the Azure Remote Rendering account identifier.
        /// </summary>
        public string AccountId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingAccount"/> class.
        /// </summary>
        /// <param name="accountId">The Azure Remote Rendering account identifier.</param>
        /// <param name="accountDomain">The Azure Remote Rendering account domain.</param>
        public RemoteRenderingAccount(string accountId, string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountId, nameof(accountId));
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            AccountId = accountId;
            AccountDomain = accountDomain;
        }
    }
}
