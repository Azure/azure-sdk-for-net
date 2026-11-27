// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppService;

public partial class AppServiceVirtualNetworkRoute
{
    // Work around https://github.com/Azure/azure-sdk-for-net/issues/61011 by preserving setters omitted from the response model.

    /// <summary> Kind of resource. </summary>
    [CodeGenMember("Kind")]
    public BicepValue<string> Kind
    {
        get { Initialize(); return _customKind; }
        set { Initialize(); _customKind.Assign(value); }
    }
    private BicepValue<string> _customKind;

    /// <summary> The starting address for this route. This may also include a CIDR notation, in which case the end address must not be specified. </summary>
    [CodeGenMember("StartAddress")]
    public BicepValue<string> StartAddress
    {
        get { return Properties is null ? default : Properties.StartAddress; }
        set { EnsureProperties(); Properties.StartAddress.Assign(value); }
    }

    /// <summary> The ending address for this route. If the start address is specified in CIDR notation, this must be omitted. </summary>
    [CodeGenMember("EndAddress")]
    public BicepValue<string> EndAddress
    {
        get { return Properties is null ? default : Properties.EndAddress; }
        set { EnsureProperties(); Properties.EndAddress.Assign(value); }
    }

    /// <summary> The type of route this is. </summary>
    [CodeGenMember("RouteType")]
    public BicepValue<AppServiceVirtualNetworkRouteType> RouteType
    {
        get { return Properties is null ? default : Properties.RouteType; }
        set { EnsureProperties(); Properties.RouteType.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _customKind = DefineProperty<string>(nameof(Kind), ["kind"]);
    }

    private void EnsureProperties()
    {
        if (Properties is null)
        {
            AssignOrReplace(ref _properties, new VnetRouteProperties());
        }
    }
}
