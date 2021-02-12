// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

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
        public Guid AccountId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingAccount"/> class.
        /// </summary>
        /// <param name="accountId">The Azure Remote Rendering account identifier.</param>
        /// <param name="accountDomain">
        /// The Azure Remote Rendering account domain. For example, for an account created in the eastus region, this will have the form "eastus.mixedreality.azure.com".
        /// </param>
        /// <exception cref="ArgumentException"> <paramref name="accountId"/> cannot be parsed as a Guid. </exception>
        public RemoteRenderingAccount(Guid accountId, string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));
            AccountId = accountId;
            AccountDomain = accountDomain;
        }
    }
}
