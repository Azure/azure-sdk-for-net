// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedApplications
{
    [CodeGenSuppress("ManagedApplicationResource", typeof(ArmClient), typeof(ManagedApplicationData))]
    public partial class ManagedApplicationResource
    {
        internal ManagedApplicationResource(ArmClient client, ManagedApplicationData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }
    }
}
