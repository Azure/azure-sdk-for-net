// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Hci
{
    public partial class HciClusterPublisherData
    {
        /// <summary> Initializes a new instance of <see cref="HciClusterPublisherData"/> for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HciClusterPublisherData(ResourceIdentifier id) : this()
        {
        }
    }
}
