// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Kusto;

namespace Azure.Provisioning.Generator.Specifications;

public class KustoSpecification() :
    Specification("Kusto", typeof(KustoExtensions), ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<KustoClusterResource>("IfMatch");
        RemoveProperty<KustoClusterResource>("IfNoneMatch");
        RemoveProperty<KustoDatabaseResource>("CallerRole");
    }
}
