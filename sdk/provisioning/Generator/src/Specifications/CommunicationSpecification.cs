// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Communication;
using Azure.ResourceManager.Communication.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class CommunicationSpecification() :
    Specification("Communication", typeof(CommunicationExtensions))
{
    protected override void Customize()
    {
        // Patch models
        CustomizeProperty<CommunicationServiceKeys>("PrimaryKey", p => p.IsSecure = true);
        CustomizeProperty<CommunicationServiceKeys>("SecondaryKey", p => p.IsSecure = true);
        CustomizeProperty<CommunicationServiceKeys>("PrimaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<CommunicationServiceKeys>("SecondaryConnectionString", p => p.IsSecure = true);

        // Naming requirements
        AddNameRequirements<CommunicationServiceResource>(min: 1, max: 63, lower: true, upper: true, digits: true, hyphen: true);
    }
}
