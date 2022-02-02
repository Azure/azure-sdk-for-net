// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;

namespace Azure.Identity
{   internal class AuthenticationAccount : IAccount
    {
        private AuthenticationRecord _profile;
#if !IDENTITYCORE
        private AccountId _accountId;
#endif
        internal AuthenticationAccount(AuthenticationRecord profile)
        {
            _profile = profile;

#if !IDENTITYCORE
            _accountId = BuildAccountIdFromString(profile.HomeAccountId);
#endif
        }

        public static explicit operator AuthenticationAccount(AuthenticationRecord profile) => new AuthenticationAccount(profile);
        public static explicit operator AuthenticationRecord(AuthenticationAccount account) => account._profile;

        string IAccount.Username => _profile.Username;

        string IAccount.Environment => _profile.Authority;
#if IDENTITYCORE
        AccountId IAccount.HomeAccountId => _profile.AccountId;
#else
        AccountId IAccount.HomeAccountId => _accountId;

        private static AccountId BuildAccountIdFromString(string homeAccountId)
        {
            //For the Microsoft identity platform (formerly named Azure AD v2.0), the identifier is the concatenation of
            // Microsoft.Identity.Client.AccountId.ObjectId and Microsoft.Identity.Client.AccountId.TenantId separated by a dot.
            var homeAccountSegments = homeAccountId.Split('.');
            AccountId accountId;
            if (homeAccountSegments.Length == 2)
            {
                accountId = new AccountId(homeAccountId, homeAccountSegments[0], homeAccountSegments[1]);
            }
            else
            {
                accountId = new AccountId(homeAccountId);
            }
            return accountId;
        }
#endif

    }
}
