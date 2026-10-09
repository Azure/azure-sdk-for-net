// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

public partial class CosmosDBFailoverPolicy
{
    private BicepValue<AzureLocation> _locationName;
    private BicepValue<int> _failoverPriority;

    // CUSTOMIZATION: Restore the setter because this model is writable through the
    // failoverPriorityChange action body, which provisioning settable analysis does not traverse.
    /// <summary> Gets or sets the LocationName. </summary>
    [CodeGenMember("LocationName")]
    public BicepValue<AzureLocation> LocationName
    {
        get
        {
            Initialize();
            return _locationName;
        }
        set
        {
            Initialize();
            _locationName.Assign(value);
        }
    }

    // CUSTOMIZATION: Restore the setter because this model is writable through the
    // failoverPriorityChange action body, which provisioning settable analysis does not traverse.
    /// <summary> Gets or sets the FailoverPriority. </summary>
    [CodeGenMember("FailoverPriority")]
    public BicepValue<int> FailoverPriority
    {
        get
        {
            Initialize();
            return _failoverPriority;
        }
        set
        {
            Initialize();
            _failoverPriority.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _locationName = DefineProperty<AzureLocation>(nameof(LocationName), new string[] { "locationName" });
        _failoverPriority = DefineProperty<int>(nameof(FailoverPriority), new string[] { "failoverPriority" });
    }
}
