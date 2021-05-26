// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Tests;

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
        public const string CommunicationM365ScopeEnvironmentVariableName  = "COMMUNICATION_M365_SCOPE";
        public string CommunicationMsalUsername => GetVariable(CommunicationMsalUsernameEnvironmentVariableName);

        public string CommunicationMsalPassword => GetVariable(CommunicationMsalPasswordEnvironmentVariableName);

        public string CommunicationM365AppId => GetVariable(CommunicationM365AppIdEnvironmentVariableName);

        public string CommunicationM365AadAuthority => GetVariable(CommunicationM365AadAuthorityEnvironmentVariableName);

        public string CommunicationM365AadTenant => GetVariable(CommunicationM365AadTenantEnvironmentVariableName);

        public string CommunicationM365RedirectUri => GetVariable(CommunicationM365RedirectUriEnvironmentVariableName);

        public string CommunicationM365Scope => GetVariable(CommunicationM365ScopeEnvironmentVariableName);
    }
}
