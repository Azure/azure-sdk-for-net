// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Dns;

namespace Azure.Provisioning.Generator.Specifications;

public class DnsSpecification() :
    Specification("Dns", typeof(DnsExtensions), ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    { }
}
