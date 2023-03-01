// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Identity.Tests.Infrastructure;

namespace Azure.Communication.Identity.Tests
{
    public class CommunicationIdentityClientTestEnvironment : CommunicationTestEnvironment
    {
        public const string CommunicationMsalUsernameEnvironmentVariableName = "COMMUNICATION_MSAL_USERNAME";
        public const string CommunicationMsalPasswordEnvironmentVariableName  = "COMMUNICATION_MSAL_PASSWORD";
        public const string CommunicationM365AppIdEnvironmentVariableName  = "COMMUNICATION_M365_APP_ID";
        public const string CommunicationM365AadAuthorityEnvironmentVariableName  = "COMMUNICATION_M365_AAD_AUTHORITY";
        public const string CommunicationM365AadTenantEnvironmentVariableName  = "COMMUNICATION_M365_AAD_TENANT";
        public const string CommunicationM365RedirectUriEnvironmentVariableName  = "COMMUNICATION_M365_REDIRECT_URI";
        public const string CommunicationExpiredTeamsTokenEnvironmentVariableName  = "COMMUNICATION_EXPIRED_TEAMS_TOKEN";
        private const string SkipIntIdentityExchangeTokenTestEnvironmentVariableName = "SKIP_INT_IDENTITY_EXCHANGE_TOKEN_TEST";

        public string CommunicationMsalUsername => GetOptionalVariable(CommunicationMsalUsernameEnvironmentVariableName) ?? "Sanitized";

        public string CommunicationMsalPassword => GetOptionalVariable(CommunicationMsalPasswordEnvironmentVariableName) ?? "Sanitized";

        public string CommunicationM365AppId => GetOptionalVariable(CommunicationM365AppIdEnvironmentVariableName) ?? "Sanitized";

        public string CommunicationM365AadAuthority => GetOptionalVariable(CommunicationM365AadAuthorityEnvironmentVariableName) ?? "Sanitized";

        public string CommunicationM365AadTenant => GetOptionalVariable(CommunicationM365AadTenantEnvironmentVariableName) ?? "Sanitized";

        public string CommunicationM365RedirectUri => GetOptionalVariable(CommunicationM365RedirectUriEnvironmentVariableName) ?? "Sanitized";

        public string CommunicationExpiredTeamsToken => GetOptionalVariable(CommunicationExpiredTeamsTokenEnvironmentVariableName) ?? "Sanitized";

        public string SkipIntIdentityExchangeTokenTest => GetOptionalVariable(SkipIntIdentityExchangeTokenTestEnvironmentVariableName) ?? "False";
        public bool ShouldIgnoreIdentityExchangeTokenTest => bool.Parse(SkipIntIdentityExchangeTokenTest);
    }
}
