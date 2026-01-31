// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.PrivateDns;

namespace Azure.Provisioning.Generator.Specifications;

public class PrivateDnsSpecification() :
    Specification("PrivateDns", typeof(PrivateDnsExtensions), ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    { }
}
