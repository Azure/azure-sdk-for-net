// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

// Backward-compat constructor and property shims for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance
{
    public partial class NGroupData
    {
        /// <summary> Initializes a new instance of <see cref="NGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NGroupData(AzureLocation location) : this()
        {
        }

        /// <summary> The identity of the NGroup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity
        {
            get => null;
            set { }
        }
    }
}