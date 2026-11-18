// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

// Restore the create-body validation method omitted from the response model (https://github.com/Azure/azure-sdk-for-net/issues/61011) within the generated properties object.
internal partial class StaticSiteCustomDomainOverviewARMResourceProperties
{
    internal BicepValue<string> ValidationMethod
    {
        get { Initialize(); return _validationMethod; }
        set { Initialize(); _validationMethod.Assign(value); }
    }
    private BicepValue<string> _validationMethod;

    partial void DefineAdditionalProperties()
    {
        _validationMethod = DefineProperty<string>(nameof(ValidationMethod), ["validationMethod"]);
    }
}
