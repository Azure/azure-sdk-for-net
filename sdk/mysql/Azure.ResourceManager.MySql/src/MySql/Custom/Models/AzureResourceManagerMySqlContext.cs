// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.MySql.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MySql
{
    /// <summary>
    /// Context class which will be filled in by the System.ClientModel.SourceGeneration.
    /// For more information see 'https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md'
    /// </summary>
    [ModelReaderWriterBuildable(typeof(ManagedServiceIdentity))]
    [ModelReaderWriterBuildable(typeof(MySqlAdvisorData))]
    [ModelReaderWriterBuildable(typeof(MySqlAdvisorListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlAdvisorResource))]
    [ModelReaderWriterBuildable(typeof(MySqlConfigurationData))]
    [ModelReaderWriterBuildable(typeof(MySqlConfigurationResource))]
    [ModelReaderWriterBuildable(typeof(MySqlConfigurations))]
    [ModelReaderWriterBuildable(typeof(MySqlDatabaseData))]
    [ModelReaderWriterBuildable(typeof(MySqlDatabaseListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlDatabaseResource))]
    [ModelReaderWriterBuildable(typeof(MySqlFirewallRuleData))]
    [ModelReaderWriterBuildable(typeof(MySqlFirewallRuleListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlFirewallRuleResource))]
    [ModelReaderWriterBuildable(typeof(MySqlLogFile))]
    [ModelReaderWriterBuildable(typeof(MySqlLogFileListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlNameAvailabilityContent))]
    [ModelReaderWriterBuildable(typeof(MySqlNameAvailabilityResult))]
    [ModelReaderWriterBuildable(typeof(MySqlPerformanceTier))]
    [ModelReaderWriterBuildable(typeof(MySqlPerformanceTierListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlPerformanceTierServiceLevelObjectives))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateEndpointConnectionData))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateEndpointConnectionListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateEndpointConnectionPatch))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateEndpointConnectionResource))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateLinkResource))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateLinkResourceData))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateLinkResourceListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateLinkResourceProperties))]
    [ModelReaderWriterBuildable(typeof(MySqlPrivateLinkServiceConnectionStateProperty))]
    [ModelReaderWriterBuildable(typeof(MySqlQueryPerformanceInsightResetDataResult))]
    [ModelReaderWriterBuildable(typeof(MySqlQueryStatisticData))]
    [ModelReaderWriterBuildable(typeof(MySqlQueryStatisticResource))]
    [ModelReaderWriterBuildable(typeof(MySqlQueryTextData))]
    [ModelReaderWriterBuildable(typeof(MySqlQueryTextListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlQueryTextResource))]
    [ModelReaderWriterBuildable(typeof(MySqlRecommendationActionData))]
    [ModelReaderWriterBuildable(typeof(MySqlRecommendationActionListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlRecommendationActionResource))]
    [ModelReaderWriterBuildable(typeof(MySqlRecoverableServerResourceData))]
    [ModelReaderWriterBuildable(typeof(MySqlServerAdministratorData))]
    [ModelReaderWriterBuildable(typeof(MySqlServerAdministratorListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlServerAdministratorResource))]
    [ModelReaderWriterBuildable(typeof(MySqlServerCreateOrUpdateContent))]
    [ModelReaderWriterBuildable(typeof(MySqlServerData))]
    [ModelReaderWriterBuildable(typeof(MySqlServerKeyData))]
    [ModelReaderWriterBuildable(typeof(MySqlServerKeyListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlServerKeyResource))]
    [ModelReaderWriterBuildable(typeof(MySqlServerListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPatch))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPrivateEndpointConnection))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPrivateEndpointConnectionProperties))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPrivateLinkServiceConnectionStateProperty))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPropertiesForCreate))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPropertiesForDefaultCreate))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPropertiesForGeoRestore))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPropertiesForReplica))]
    [ModelReaderWriterBuildable(typeof(MySqlServerPropertiesForRestore))]
    [ModelReaderWriterBuildable(typeof(MySqlServerResource))]
    [ModelReaderWriterBuildable(typeof(MySqlServerSecurityAlertPolicyData))]
    [ModelReaderWriterBuildable(typeof(MySqlServerSecurityAlertPolicyListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlServerSecurityAlertPolicyResource))]
    [ModelReaderWriterBuildable(typeof(MySqlServerUpgradeContent))]
    [ModelReaderWriterBuildable(typeof(MySqlSku))]
    [ModelReaderWriterBuildable(typeof(MySqlStorageProfile))]
    [ModelReaderWriterBuildable(typeof(MySqlTopQueryStatisticsInput))]
    [ModelReaderWriterBuildable(typeof(MySqlTopQueryStatisticsListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlVirtualNetworkRuleData))]
    [ModelReaderWriterBuildable(typeof(MySqlVirtualNetworkRuleListResult))]
    [ModelReaderWriterBuildable(typeof(MySqlVirtualNetworkRuleResource))]
    [ModelReaderWriterBuildable(typeof(MySqlWaitStatisticData))]
    [ModelReaderWriterBuildable(typeof(MySqlWaitStatisticResource))]
    [ModelReaderWriterBuildable(typeof(MySqlWaitStatisticsInput))]
    [ModelReaderWriterBuildable(typeof(MySqlWaitStatisticsListResult))]
    [ModelReaderWriterBuildable(typeof(ResponseError))]
    [ModelReaderWriterBuildable(typeof(SystemData))]
    [ModelReaderWriterBuildable(typeof(UnknownServerPropertiesForCreate))]
    [ModelReaderWriterBuildable(typeof(WritableSubResource))]
    public partial class AzureResourceManagerMySqlContext : ModelReaderWriterContext
    {
    }
}