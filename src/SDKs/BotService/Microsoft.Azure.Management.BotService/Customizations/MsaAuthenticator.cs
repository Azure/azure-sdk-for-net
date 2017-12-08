// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Management.BotService
{
    /// <summary>
    /// Obtains user level tokesn with the bot service first party app audience in order
    /// to provision Msa Apps, which are crucial for bots to work
    /// </summary>
    internal class MsaAuthenticator
    {
        private const string BotFirstPartyAppId = "f3723d34-6ff5-4ceb-a148-d99dcd2511fc";
        private const string AadClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
        private const string AadRedirectUri = "urn:ietf:wg:oauth:2.0:oob";

        private readonly string tenantId;

        /// <summary>
        /// Creates an instance of MsaAuthenticator
        /// </summary>
        public MsaAuthenticator(string tenantId)
        {
            this.tenantId = tenantId;
        }

        /// <summary>
        /// Acquires a user token with the bot service first party app as audience
        /// </summary>
        /// <returns></returns>
        public async Task<AuthenticationResult> AcquireTokenAsync()
        {
            var authority = $"https://login.windows.net/{tenantId}";
            var context = new AuthenticationContext(
                authority: authority,
                validateAuthority: true);
            
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            
#if NET452
            return context.AcquireToken(
                resource: BotFirstPartyAppId,
                clientId: AadClientId,
                redirectUri: new Uri(AadRedirectUri),
                promptBehavior: PromptBehavior.Always);
#endif
#if NETSTANDARD1_4

            var deviceCodeResult = await context.AcquireDeviceCodeAsync(BotFirstPartyAppId, AadClientId);
            return await context.AcquireTokenByDeviceCodeAsync(deviceCodeResult); 
#endif
        }
    }
}