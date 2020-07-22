// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;

namespace Azure.Identity
{   internal class AuthenticationAccount : IAccount
    {
        private AuthenticationRecord _profile;

        internal AuthenticationAccount(AuthenticationRecord profile)
        {
            _profile = profile;
        }

        string IAccount.Username => _profile.Username;

        string IAccount.Environment => _profile.Authority;

        AccountId IAccount.HomeAccountId => _profile.AccountId;

        public static explicit operator AuthenticationAccount(AuthenticationRecord profile) => new AuthenticationAccount(profile);
        public static explicit operator AuthenticationRecord(AuthenticationAccount account) => account._profile;
    }
}
