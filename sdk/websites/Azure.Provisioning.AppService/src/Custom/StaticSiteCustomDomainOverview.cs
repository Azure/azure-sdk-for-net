// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class StaticSiteCustomDomainOverview
{
    // Work around https://github.com/Azure/azure-sdk-for-net/issues/61011 by restoring a create-body property omitted from the response model.

    /// <summary> Validation method for adding a custom domain. </summary>
    public BicepValue<string> ValidationMethod
    {
        get { Initialize(); return _validationMethod; }
        set { Initialize(); _validationMethod.Assign(value); }
    }
    private BicepValue<string> _validationMethod;

    partial void DefineAdditionalProperties()
    {
        _validationMethod = DefineProperty<string>(nameof(ValidationMethod), ["properties", "validationMethod"]);
    }
}
