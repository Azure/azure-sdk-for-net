// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.Kusto;
using Azure.ResourceManager.Kusto.Models;
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
        RemoveProperties<KustoReadOnlyFollowingDatabase>("Id", "Name", "Location", "SystemData");
        RemoveProperties<KustoReadWriteDatabase>("Id", "Name", "Location", "SystemData");

        CustomizeResource<KustoCosmosDBDataConnection>(r =>
        {
            r.BaseType = GetModel<KustoDataConnectionResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "CosmosDb";
        });
        CustomizeResource<KustoEventGridDataConnection>(r =>
        {
            r.BaseType = GetModel<KustoDataConnectionResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "EventGrid";
        });
        CustomizeResource<KustoEventHubDataConnection>(r =>
        {
            r.BaseType = GetModel<KustoDataConnectionResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "EventHub";
        });
        CustomizeResource<KustoIotHubDataConnection>(r =>
        {
            r.BaseType = GetModel<KustoDataConnectionResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "IotHub";
        });
        RemoveProperties<KustoCosmosDBDataConnection>("Id", "Name", "Location", "SystemData");
        RemoveProperties<KustoEventGridDataConnection>("Id", "Name", "Location", "SystemData");
        RemoveProperties<KustoEventHubDataConnection>("Id", "Name", "Location", "SystemData");
        RemoveProperties<KustoIotHubDataConnection>("Id", "Name", "Location", "SystemData");

        CustomizePropertyIsoDuration<KustoReadWriteDatabase>("SoftDeletePeriod");
        CustomizePropertyIsoDuration<KustoReadWriteDatabase>("HotCachePeriod");
        CustomizePropertyIsoDuration<KustoReadOnlyFollowingDatabase>("SoftDeletePeriod");
        CustomizePropertyIsoDuration<KustoReadOnlyFollowingDatabase>("HotCachePeriod");
    }

    private protected override Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        var result = base.FindConstructibleResources();

        result.Add(typeof(KustoReadOnlyFollowingDatabase), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoReadOnlyFollowingDatabase), BindingFlags.NonPublic | BindingFlags.Static)!);
        result.Add(typeof(KustoReadWriteDatabase), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoReadWriteDatabase), BindingFlags.NonPublic | BindingFlags.Static)!);

        result.Add(typeof(KustoCosmosDBDataConnection), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoCosmosDBDataConnection), BindingFlags.NonPublic | BindingFlags.Static)!);
        result.Add(typeof(KustoEventGridDataConnection), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoEventGridDataConnection), BindingFlags.NonPublic | BindingFlags.Static)!);
        result.Add(typeof(KustoEventHubDataConnection), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoEventHubDataConnection), BindingFlags.NonPublic | BindingFlags.Static)!);
        result.Add(typeof(KustoIotHubDataConnection), typeof(KustoSpecification).GetMethod(nameof(CreateOrUpdateKustoIotHubDataConnection), BindingFlags.NonPublic | BindingFlags.Static)!);
        return result;
    }

    // These methods are here as a workaround to generate correct properties for the above two discriminated child resources.
    private static ArmOperation<KustoDatabaseResource> CreateOrUpdateKustoReadOnlyFollowingDatabase(KustoReadOnlyFollowingDatabase content) { return null!; }
    private static ArmOperation<KustoDatabaseResource> CreateOrUpdateKustoReadWriteDatabase(KustoReadWriteDatabase content) { return null!; }
    private static ArmOperation<KustoDataConnectionResource> CreateOrUpdateKustoCosmosDBDataConnection(KustoCosmosDBDataConnection content) { return null!; }
    private static ArmOperation<KustoDataConnectionResource> CreateOrUpdateKustoEventGridDataConnection(KustoEventGridDataConnection content) { return null!; }
    private static ArmOperation<KustoDataConnectionResource> CreateOrUpdateKustoEventHubDataConnection(KustoEventHubDataConnection content) { return null!; }
    private static ArmOperation<KustoDataConnectionResource> CreateOrUpdateKustoIotHubDataConnection(KustoIotHubDataConnection content) { return null!; }
}
