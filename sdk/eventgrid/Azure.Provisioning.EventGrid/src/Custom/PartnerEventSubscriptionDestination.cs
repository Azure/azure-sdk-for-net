// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class PartnerEventSubscriptionDestination
{
    private BicepValue<string> _resourceId;

    /// <summary> The Azure Resource ID of the partner destination. </summary>
    // The generated property uses ResourceIdentifier. Preserve the released string property and
    // the nested properties.resourceId wire path used by the generated payload.
    [CodeGenMember("ResourceId")]
    public BicepValue<string> ResourceId
    {
        get
        {
            Initialize();
            return _resourceId;
        }
        set
        {
            Initialize();
            _resourceId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _resourceId = DefineProperty<string>(nameof(ResourceId), ["properties", "resourceId"], isRequired: true);
    }
}
