// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

#nullable enable

namespace Azure.MixedReality.Authentication
{
    internal static class AuthenticationEndpoint
    {
        private const string EastUS2Prefix = "eastus2.";

        /// <summary>
        /// Constructs an authentication endpoint from a service domain.
        /// </summary>
        /// <param name="accountDomain">The account domain.</param>
        /// <returns><see cref="Uri"/>.</returns>
        public static Uri ConstructFromDomain(string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            if (accountDomain.StartsWith(EastUS2Prefix, StringComparison.OrdinalIgnoreCase))
            {
                // The Mixed Reality STS instance in East US 2 prefers "sts.mixedreality.azure.com" over "sts.eastus2.mixedreality.azure.com".
                // AAD authentication will not work using "sts.eastus2.mixedreality.azure.com".
                accountDomain = accountDomain.Substring(EastUS2Prefix.Length);
            }

            if (!Uri.TryCreate($"https://sts.{accountDomain}", UriKind.Absolute, out Uri? result))
            {
                throw new ArgumentException("The value could not be used to construct a valid endpoint.", nameof(accountDomain));
            }

            return result;
        }
    }
}
