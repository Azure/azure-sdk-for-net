// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageTaskAssignmentResource
    {
        // Constructor overload to fix generator bug: StorageTaskAssignmentData extends
        // a local Resource type with string Id, but the base constructor expects ResourceIdentifier.
        internal StorageTaskAssignmentResource(ArmClient client, string id) : this(client, new ResourceIdentifier(id))
        {
        }
    }
}
