// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    /// <summary>
    /// Defines values for known roles in Azure to the SDK.
    /// </summary>
    public class BuiltInRole : ExpandableStringEnum<BuiltInRole>
    {
        public static readonly BuiltInRole ApiManagementServiceOperatorRole = BuiltInRole.fromString("API Management Service Operator Role");
        public static readonly BuiltInRole ApiManagementServiceReaderRole = BuiltInRole.fromString("API Management Service Reader Role");
        public static readonly BuiltInRole ApplicationInsightsComponentContributor = BuiltInRole.fromString("Application Insights Component Contributor");
        public static readonly BuiltInRole AutomationOperator = BuiltInRole.fromString("Automation Operator");
        public static readonly BuiltInRole BackupContributor = BuiltInRole.fromString("Backup Contributor");
        public static readonly BuiltInRole BackupOperator = BuiltInRole.fromString("Backup Operator");
        public static readonly BuiltInRole BackupReader = BuiltInRole.fromString("Backup Reader");
        public static readonly BuiltInRole BillingReader = BuiltInRole.fromString("Billing Reader");
        public static readonly BuiltInRole BiztalkContributor = BuiltInRole.fromString("BizTalk Contributor");
        public static readonly BuiltInRole CleardbMysqlDbContributor = BuiltInRole.fromString("ClearDB MySQL DB Contributor");
        public static readonly BuiltInRole Contributor = BuiltInRole.fromString("Contributor");
        public static readonly BuiltInRole DataFactoryContributor = BuiltInRole.fromString("Data Factory Contributor");
        public static readonly BuiltInRole DevtestLabsUser = BuiltInRole.fromString("DevTest Labs User");
        public static readonly BuiltInRole DnsZoneContributor = BuiltInRole.fromString("DNS Zone Contributor");
        public static readonly BuiltInRole AzureCosmosDbAccountContributor = BuiltInRole.fromString("Azure Cosmos DB Account Contributor");
        public static readonly BuiltInRole IntelligentSystemsAccountContributor = BuiltInRole.fromString("Intelligent Systems Account Contributor");
        public static readonly BuiltInRole MonitoringReader = BuiltInRole.fromString("Monitoring Reader");
        public static readonly BuiltInRole MonitoringContributor = BuiltInRole.fromString("Monitoring Contributor");
        public static readonly BuiltInRole NetworkContributor = BuiltInRole.fromString("Network Contributor");
        public static readonly BuiltInRole NewRelicApmAccountContributor = BuiltInRole.fromString("New Relic APM Account Contributor");
        public static readonly BuiltInRole Owner = BuiltInRole.fromString("Owner");
        public static readonly BuiltInRole Reader = BuiltInRole.fromString("Reader");
        public static readonly BuiltInRole RedisCacheContributor = BuiltInRole.fromString("Redis Cache Contributor");
        public static readonly BuiltInRole SchedulerJobCollectionsContributor = BuiltInRole.fromString("Scheduler Job Collections Contributor");
        public static readonly BuiltInRole SearchServiceContributor = BuiltInRole.fromString("Search Service Contributor");
        public static readonly BuiltInRole SecurityManager = BuiltInRole.fromString("Security Manager");
        public static readonly BuiltInRole SqlDbContributor = BuiltInRole.fromString("SQL DB Contributor");
        public static readonly BuiltInRole SqlSecurityManager = BuiltInRole.fromString("SQL Security Manager");
        public static readonly BuiltInRole SqlServerContributor = BuiltInRole.fromString("SQL Server Contributor");
        public static readonly BuiltInRole ClassicStorageAccountContributor = BuiltInRole.fromString("Classic Storage Account Contributor");
        public static readonly BuiltInRole StorageAccountContributor = BuiltInRole.fromString("Storage Account Contributor");
        public static readonly BuiltInRole UserAccessAdministrator = BuiltInRole.fromString("User Access Administrator");
        public static readonly BuiltInRole ClassicVirtualMachineContributor = BuiltInRole.fromString("Classic Virtual Machine Contributor");
        public static readonly BuiltInRole VirtualMachineContributor = BuiltInRole.fromString("Virtual Machine Contributor");
        public static readonly BuiltInRole ClassicNetworkContributor = BuiltInRole.fromString("Classic Network Contributor");
        public static readonly BuiltInRole WebPlanContributor = BuiltInRole.fromString("Web Plan Contributor");
        public static readonly BuiltInRole WebsiteContributor = BuiltInRole.fromString("Website Contributor");
    }
}
