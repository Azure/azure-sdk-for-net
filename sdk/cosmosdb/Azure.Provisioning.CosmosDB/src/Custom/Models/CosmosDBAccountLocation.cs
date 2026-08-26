// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

public partial class CosmosDBAccountLocation
{
    private BicepValue<AzureLocation> _locationName;
    private BicepValue<int> _failoverPriority;
    private BicepValue<bool> _isZoneRedundant;

    // CUSTOMIZATION: Restore the setter lost because the provisioning generator does not yet
    // recursively combine the resource response and create body model graphs.
    // https://github.com/Azure/azure-sdk-for-net/issues/61011
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

    // CUSTOMIZATION: Restore the setter lost because the provisioning generator does not yet
    // recursively combine the resource response and create body model graphs.
    // https://github.com/Azure/azure-sdk-for-net/issues/61011
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

    // CUSTOMIZATION: Restore the setter lost because the provisioning generator does not yet
    // recursively combine the resource response and create body model graphs.
    // https://github.com/Azure/azure-sdk-for-net/issues/61011
    /// <summary> Gets or sets the IsZoneRedundant. </summary>
    [CodeGenMember("IsZoneRedundant")]
    public BicepValue<bool> IsZoneRedundant
    {
        get
        {
            Initialize();
            return _isZoneRedundant;
        }
        set
        {
            Initialize();
            _isZoneRedundant.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _locationName = DefineProperty<AzureLocation>(nameof(LocationName), new string[] { "locationName" });
        _failoverPriority = DefineProperty<int>(nameof(FailoverPriority), new string[] { "failoverPriority" });
        _isZoneRedundant = DefineProperty<bool>(nameof(IsZoneRedundant), new string[] { "isZoneRedundant" });
    }
}
