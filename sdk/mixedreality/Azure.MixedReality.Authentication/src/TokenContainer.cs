// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;

namespace Azure.MixedReality.Authentication
{
    internal class TokenContainer
    {
        private readonly Func<Task<AccessToken>>? autoRenewFunction;

        private readonly TokenValidationParameters tokenValidationParameters = new TokenValidationParameters();

        private AccessToken? accessToken;

        /// <summary>
        /// Gets a value indicating whether the token can be automatically renewed.
        /// </summary>
        public bool CanAutoRenew => IsTokenSet && autoRenewFunction != null;

        /// <summary>
        /// Gets a value indicating whether a token has been set.
        /// </summary>
        public bool IsTokenSet => accessToken != null;

        /// <summary>
        /// Gets a value indicating if the token is valid.
        /// </summary>
        public bool IsValid => IsTokenValid(accessToken);

        /// <summary>
        /// Gets a value indicating whether the token needs to be renewed.
        /// </summary>
        public bool NeedsRenewal => IsTokenSet && !IsValid;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenContainer"/> class.
        /// </summary>
        public TokenContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenContainer"/> class.
        /// </summary>
        /// <param name="autoRenewFunction">The automatic renewal function.</param>
        public TokenContainer(Func<Task<AccessToken>> autoRenewFunction)
        {
            Argument.AssertNotNull(autoRenewFunction, nameof(autoRenewFunction));

            this.autoRenewFunction = autoRenewFunction;
        }

        /// <summary>
        /// Gets the token asynchronously.
        /// If the token is no longer valid and an auto renew function was provided,
        /// the token will be renewed and returned.
        /// </summary>
        /// <returns>A <see cref="System.String"/> representing a valid access token.
        /// Returns null if a valid token could not be retrieved.
        /// </returns>
        public async Task<AccessToken?> GetTokenAsync()
        {
            if (CanAutoRenew && NeedsRenewal)
            {
                accessToken = await RenewTokenAsync().ConfigureAwait(false);
            }

            if (IsValid)
            {
                return accessToken;
            }

            return null;
        }

        /// <summary>
        /// Sets the token if the token is valid.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns><c>true</c> if the token was accepted, <c>false</c> otherwise.</returns>
        public bool SetToken(AccessToken accessToken)
        {
            if (IsTokenValid(accessToken))
            {
                this.accessToken = accessToken;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Forcibly sets the token for test purposes.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        internal void ForceSetToken(AccessToken accessToken)
        {
            this.accessToken = accessToken;
        }

        private bool IsTokenLifetimeValid(AccessToken token)
        {
            try
            {
                // Accounts for clock skew.
                Validators.ValidateLifetime(notBefore: null, expires: token.ExpiresOn.DateTime, securityToken: null, tokenValidationParameters);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the cached token is valid.
        /// </summary>
        /// <returns><c>true</c> if the token is valid; otherwise, <c>false</c>.</returns>
        private bool IsTokenValid(AccessToken? token)
        {
            if (token is null)
            {
                return false;
            }

            return IsTokenLifetimeValid(token.Value);
        }

        private Task<AccessToken> RenewTokenAsync()
        {
            try
            {
                return autoRenewFunction!.Invoke();
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                throw new TokenRenewalException("The token could not be renewed. See the InnerException for more details.", ex);
            }
        }
    }
}
