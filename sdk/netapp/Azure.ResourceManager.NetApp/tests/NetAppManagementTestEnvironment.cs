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
        /// The base implementation in <see cref="TestEnvironment.CreateDeveloperCredential"/>
        /// uses <see cref="InteractiveBrowserCredential"/> with the WAM broker and
        /// <c>IntPtr.Zero</c> as the parent window handle. When tests run from
        /// <c>dotnet test</c> or Test Explorer there is no foreground window the broker
        /// can attach to, so it fails with
        /// "A window handle must be configured. See https://aka.ms/msal-net-wam#parent-window-handles".
        ///
        /// On a NetApp dev box we typically authenticate through Visual Studio and/or
        /// the Azure CLI, so prefer those silent credentials first and fall back to the
        /// broker / VS Code only if neither is available.
        /// </summary>
        protected override TokenCredential CreateDeveloperCredential()
        {
            return new ChainedTokenCredential(
                new AzureCliCredential(),
                new VisualStudioCredential(),
                new VisualStudioCodeCredential(),
                new AzurePowerShellCredential());
        }
    }
}
