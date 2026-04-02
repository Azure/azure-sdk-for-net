// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat property shims for TypeSpec migration (ApiCompat MembersMustExist).

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
        public ContainerGroupFileShareProperties Properties
        {
            get => FileSharePropertiesValue as ContainerGroupFileShareProperties;
            set => FileSharePropertiesValue = value;
        }
    }
}