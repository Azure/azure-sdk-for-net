// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ResourceGraph;

namespace Azure.Provisioning.Generator.Specifications;

public class ResourceGraphSpecification() :
    Specification("ResourceGraph", typeof(ResourceGraphExtensions), serviceDirectory: "resourcegraph")
{
    protected override void Customize()
    { }
}
