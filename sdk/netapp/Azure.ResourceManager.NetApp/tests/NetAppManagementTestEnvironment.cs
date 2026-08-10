// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class NetAppManagementTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Local-developer credential chain used when recording tests.
        ///
        /// Why this override exists:
        /// the base implementation in <see cref="TestEnvironment.CreateDeveloperCredential"/>
        /// uses <see cref="InteractiveBrowserCredential"/> configured with the WAM broker and
        /// <c>IntPtr.Zero</c> as the parent window handle. When tests run from
        /// <c>dotnet test</c> or Test Explorer there is no foreground window the broker can
        /// attach to, so it fails with:
        /// "A window handle must be configured. See https://aka.ms/msal-net-wam#parent-window-handles".
        ///
        /// On a NetApp dev box we typically authenticate through Visual Studio and/or the
        /// Azure CLI, so the chain prefers those silent credentials first. If none of the
        /// silent options are available the chain falls back to a browser-based
        /// <see cref="InteractiveBrowserCredential"/> configured WITHOUT the WAM broker, i.e.
        /// the standard system-browser + localhost-redirect flow. That flow does not need a
        /// parent window handle, so it works in both <c>dotnet test</c> and Test Explorer.
        ///
        /// Order (first that succeeds wins):
        /// 1. <see cref="AzureCliCredential"/>          - silent, uses an existing <c>az login</c>.
        /// 2. <see cref="VisualStudioCredential"/>      - silent, uses the signed-in VS account.
        /// 3. <see cref="VisualStudioCodeCredential"/>  - silent, uses the VS Code Azure account.
        /// 4. <see cref="AzurePowerShellCredential"/>   - silent, uses <c>Connect-AzAccount</c>.
        /// 5. <see cref="InteractiveBrowserCredential"/> (system browser, no WAM broker) -
        ///    interactive fallback so a developer without any of the above can still record.
        /// </summary>
        protected override TokenCredential CreateDeveloperCredential()
        {
            // Explicitly construct InteractiveBrowserCredentialOptions WITHOUT enabling the
            // WAM broker; this routes the sign-in through the default system browser using a
            // localhost redirect, which works in headless test hosts (dotnet test / Test
            // Explorer) where no parent window handle is available.
            InteractiveBrowserCredentialOptions browserOptions = new();

            return new ChainedTokenCredential(
                new AzureCliCredential(),
                new VisualStudioCredential(),
                new VisualStudioCodeCredential(),
                new AzurePowerShellCredential(),
                new InteractiveBrowserCredential(browserOptions));
        }
    }
}
