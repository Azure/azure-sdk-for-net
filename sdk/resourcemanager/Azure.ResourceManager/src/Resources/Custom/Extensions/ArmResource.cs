// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager
{
    public partial class ArmResource
    {
        /// <summary> Gets an object representing a TagResource along with the instance operations that can be performed on it in the ArmResource. </summary>
        /// <returns> Returns a <see cref="TagResource" /> object. </returns>
        public virtual TagResource GetTagResource()
        {
            return GetCachedClient(client => new TagResource(client, new ResourceIdentifier(Id.ToString() + "/providers/Microsoft.Resources/tags/default")));
        }
    }
}
