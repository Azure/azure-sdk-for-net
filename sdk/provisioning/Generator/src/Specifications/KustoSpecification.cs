// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.Kusto;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

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

        // customization for polymorphic resources
        CustomizeResource<KustoReadOnlyFollowingDatabase>(r =>
        {
            r.BaseType = GetModel<KustoDatabaseResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "ReadOnlyFollowing";
        });
        CustomizeResource<KustoReadWriteDatabase>(r =>
        {
            r.BaseType = GetModel<KustoDatabaseResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "ReadWrite";
        });
        RemoveProperty<KustoReadOnlyFollowingDatabase>("Location");
        RemoveProperty<KustoReadWriteDatabase>("Location");
    }

    private protected override Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        var result = base.FindConstructibleResources();

        result.Add(typeof(KustoReadOnlyFollowingDatabase), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoReadOnlyFollowingDatabase), BindingFlags.NonPublic | BindingFlags.Static)!);
        result.Add(typeof(KustoReadWriteDatabase), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoReadWriteDatabase), BindingFlags.NonPublic | BindingFlags.Static)!);
        return result;
    }

    // These methods are here as a workaround to generate correct properties for the above two discriminated child resources.
    private static ArmOperation<KustoDatabaseResource> CreateOrUpdateKustoReadOnlyFollowingDatabase(KustoReadOnlyFollowingDatabase content) { return null!; }
    private static ArmOperation<KustoDatabaseResource> CreateOrUpdateKustoReadWriteDatabase(KustoReadWriteDatabase content) { return null!; }
}
