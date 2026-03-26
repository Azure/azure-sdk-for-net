// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.Provisioning.Generator.Specifications;

// NOTE: To correctly regenerate Azure.Provisioning.ContainerInstance, the mgmt
// library (Azure.ResourceManager.ContainerInstance) must first be regenerated
// with `enable-bicep-serialization: true` in its autorest.md to produce
// WirePath attributes. Then switch the PackageReference in Generator.csproj to
// a ProjectReference pointing to the local mgmt project before running this
// generator. After generation, restore the PackageReference and revert the
// mgmt changes.
public class ContainerInstanceSpecification() :
    Specification("ContainerInstance", typeof(ContainerInstanceExtensions), ignorePropertiesWithoutPath: true, serviceDirectory: "containerinstance")
{
    protected override void Customize()
    { }
}
