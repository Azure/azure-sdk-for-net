// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;

namespace Azure.Identity
{   internal class AuthenticationAccount : IAccount
    {
        private AuthenticationProfile _profile;

        internal AuthenticationAccount(AuthenticationProfile profile)
        {
            _profile = profile;
        }

        string IAccount.Username => _profile.Username;

        string IAccount.Environment => _profile.Authority;

        AccountId IAccount.HomeAccountId => _profile.AccountId;

        public static explicit operator AuthenticationAccount(AuthenticationProfile profile) => new AuthenticationAccount(profile);
        public static explicit operator AuthenticationProfile(AuthenticationAccount account) => account._profile;
    }
}
