// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat: generated constructor sets Properties but no generated property declaration.
// We provide the Properties property here. Also provides a public parameterless ctor for ApiCompat.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupFileShare
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupFileShare"/> for mocking. </summary>
        public ContainerGroupFileShare()
        {
        }

        /// <summary> The file share properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupFileShareProperties Properties { get; set; }
    }
}
