// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterPublisherData. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterPublisherData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PublisherData : HciClusterPublisherData
    {
    }
}
