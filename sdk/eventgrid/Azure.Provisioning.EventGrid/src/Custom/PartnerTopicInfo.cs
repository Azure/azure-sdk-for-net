// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class PartnerTopicInfo
{
    private BicepValue<Guid> _customAzureSubscriptionId;

    /// <summary> Gets or sets the Azure subscription identifier. </summary>
    [CodeGenMember("AzureSubscriptionId")]
    public BicepValue<Guid> AzureSubscriptionId
    {
        get
        {
            Initialize();
            return _customAzureSubscriptionId;
        }
        set
        {
            Initialize();
            _customAzureSubscriptionId.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customAzureSubscriptionId = DefineProperty<Guid>(nameof(AzureSubscriptionId), ["azureSubscriptionId"]);
    }
}
