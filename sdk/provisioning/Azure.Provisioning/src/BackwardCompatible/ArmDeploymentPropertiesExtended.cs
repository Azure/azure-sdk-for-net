// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Resources;

public partial class ArmDeploymentPropertiesExtended : ProvisionableConstruct
{
    /// <summary>
    /// Array of provisioned resources.
    /// </summary>
    public BicepList<SubResource> OutputResources
    {
        get { Initialize(); return _outputResources!; }
    }
    private BicepList<SubResource>? _outputResources;

    /// <summary>
    /// Array of validated resources.
    /// </summary>
    public BicepList<SubResource> ValidatedResources
    {
        get { Initialize(); return _validatedResources!; }
    }
    private BicepList<SubResource>? _validatedResources;
}
