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
        private bool _usePowerShell;

        /// <summary>
        /// Set this if you want to use PowerShell (version 5 or lower) for getting the token
        /// instead of PowerShell Core (version 6 or higher), which is the default used.
        /// This works only on Windows OS.
        /// </summary>
        public bool UsePowerShell
        {
            get
            {
                return _usePowerShell;
            }

            set
            {
                // Set this to true only for Windows OS
                _usePowerShell = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && value;
            }

        }
    }
}
