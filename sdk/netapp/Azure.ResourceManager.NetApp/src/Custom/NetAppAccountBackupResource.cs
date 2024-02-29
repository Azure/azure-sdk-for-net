// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A Class representing a NetAppAccountBackup along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="NetAppAccountBackupResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetNetAppAccountBackupResource method.
    /// Otherwise you can get one from its parent resource <see cref="NetAppAccountResource" /> using the GetNetAppAccountBackup method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppAccountBackupResource : ArmResource
    {
    }
}
