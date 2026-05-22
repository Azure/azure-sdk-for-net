// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class AccessControlListAction
    {
        /// <summary> Type of actions that can be performed. </summary>
        public AclActionType? AclActionType
        {
            get => Type;
            set => Type = value;
        }
    }
}
