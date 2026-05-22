// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    [CodeGenType("TerminalServerPatchConfiguration")]
    public partial class TerminalServerPatchableProperties
    {
        /// <summary> Initializes a new instance of <see cref="TerminalServerPatchableProperties"/>. </summary>
        public TerminalServerPatchableProperties()
        {
        }

        internal TerminalServerPatchableProperties(string username, string password, string serialNumber)
        {
            Username = username;
            Password = password;
            SerialNumber = serialNumber;
        }

        /// <summary> Username for the terminal server connection. </summary>
        public string Username { get; set; }
        /// <summary> Password for the terminal server connection. </summary>
        public string Password { get; set; }
        /// <summary> Serial number of the terminal server. </summary>
        public string SerialNumber { get; set; }
    }
}
