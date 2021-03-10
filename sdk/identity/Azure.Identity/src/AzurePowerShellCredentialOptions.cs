// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Runtime.InteropServices;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="AzurePowerShellCredential"/>.
    /// </summary>
    public class AzurePowerShellCredentialOptions : TokenCredentialOptions
    {
        private bool _useLegacyPowerShell;

        /// <summary>
        /// Set this to <c>true</c> if to use PowerShell (version 5 or lower) for getting the token
        /// or <c>false</c> to use PowerShell Core (version 6 or higher). The default is <c>false</c>.
        /// Note: This can be set to true only on Windows OS.
        /// </summary>
        public bool UseLegacyPowerShell
        {
            get
            {
                return _useLegacyPowerShell;
            }

            set
            {
                // Set this to true only for Windows OS
                _useLegacyPowerShell = Validations.CanUseLegacyPowerShell(value);
            }
        }
    }
}
