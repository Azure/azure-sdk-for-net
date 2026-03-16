// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudBareMetalMachineKeySetData
    {
        /// <summary> The name of the group that users will be assigned to on the operating system of the machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSGroupName
        {
            get => OsGroupName;
            set => OsGroupName = value;
        }
    }
}
