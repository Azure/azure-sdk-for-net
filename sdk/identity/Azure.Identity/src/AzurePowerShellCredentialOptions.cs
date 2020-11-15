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
        /// Set this if you want to use the installer PowerShell Core for getting the token
        /// This refers to PowerShell version 6 or greater.
        /// </summary>
        public bool UsePowerShellCore
        {
            get; set;
        }

        /// <summary>
        /// Set this if you want to use the installed PowerShell for getting the token
        /// This refers to PowerShell Version 5 or lower.
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
                _usePowerShell = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && value;
            }

        }
    }
}
