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
        get { Initialize(); return _customStartAddress; }
        set { Initialize(); _customStartAddress.Assign(value); }
    }
    private BicepValue<string> _customStartAddress;

    /// <summary> The ending address for this route. If the start address is specified in CIDR notation, this must be omitted. </summary>
    [CodeGenMember("EndAddress")]
    public BicepValue<string> EndAddress
    {
        get { Initialize(); return _customEndAddress; }
        set { Initialize(); _customEndAddress.Assign(value); }
    }
    private BicepValue<string> _customEndAddress;

    /// <summary> The type of route this is. </summary>
    [CodeGenMember("RouteType")]
    public BicepValue<AppServiceVirtualNetworkRouteType> RouteType
    {
        get { Initialize(); return _customRouteType; }
        set { Initialize(); _customRouteType.Assign(value); }
    }
    private BicepValue<AppServiceVirtualNetworkRouteType> _customRouteType;

    partial void DefineAdditionalProperties()
    {
        _customKind = DefineProperty<string>(nameof(Kind), ["kind"]);
        _customStartAddress = DefineProperty<string>(nameof(StartAddress), ["properties", "startAddress"]);
        _customEndAddress = DefineProperty<string>(nameof(EndAddress), ["properties", "endAddress"]);
        _customRouteType = DefineProperty<AppServiceVirtualNetworkRouteType>(nameof(RouteType), ["properties", "routeType"]);
    }
}
