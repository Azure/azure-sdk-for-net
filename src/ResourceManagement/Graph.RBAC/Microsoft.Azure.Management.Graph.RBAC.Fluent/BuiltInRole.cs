// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    /// <summary>
    /// Defines values for known roles in Azure to the SDK.
    /// </summary>
    public class BuiltInRole : ExpandableStringEnum<BuiltInRole>
    {
        public static readonly BuiltInRole ApiManagementServiceOperatorRole = Parse("API Management Service Operator Role");
        public static readonly BuiltInRole ApiManagementServiceReaderRole = Parse("API Management Service Reader Role");
        public static readonly BuiltInRole ApplicationInsightsComponentContributor = Parse("Application Insights Component Contributor");
        public static readonly BuiltInRole AutomationOperator = Parse("Automation Operator");
        public static readonly BuiltInRole BackupContributor = Parse("Backup Contributor");
        public static readonly BuiltInRole BackupOperator = Parse("Backup Operator");
        public static readonly BuiltInRole BackupReader = Parse("Backup Reader");
        public static readonly BuiltInRole BillingReader = Parse("Billing Reader");
        public static readonly BuiltInRole BiztalkContributor = Parse("BizTalk Contributor");
        public static readonly BuiltInRole CleardbMysqlDbContributor = Parse("ClearDB MySQL DB Contributor");
        public static readonly BuiltInRole Contributor = Parse("Contributor");
        public static readonly BuiltInRole DataFactoryContributor = Parse("Data Factory Contributor");
        public static readonly BuiltInRole DevtestLabsUser = Parse("DevTest Labs User");
        public static readonly BuiltInRole DnsZoneContributor = Parse("DNS Zone Contributor");
        public static readonly BuiltInRole AzureCosmosDbAccountContributor = Parse("Azure Cosmos DB Account Contributor");
        public static readonly BuiltInRole IntelligentSystemsAccountContributor = Parse("Intelligent Systems Account Contributor");
        public static readonly BuiltInRole MonitoringReader = Parse("Monitoring Reader");
        public static readonly BuiltInRole MonitoringContributor = Parse("Monitoring Contributor");
        public static readonly BuiltInRole NetworkContributor = Parse("Network Contributor");
        public static readonly BuiltInRole NewRelicApmAccountContributor = Parse("New Relic APM Account Contributor");
        public static readonly BuiltInRole Owner = Parse("Owner");
        public static readonly BuiltInRole Reader = Parse("Reader");
        public static readonly BuiltInRole RedisCacheContributor = Parse("Redis Cache Contributor");
        public static readonly BuiltInRole SchedulerJobCollectionsContributor = Parse("Scheduler Job Collections Contributor");
        public static readonly BuiltInRole SearchServiceContributor = Parse("Search Service Contributor");
        public static readonly BuiltInRole SecurityManager = Parse("Security Manager");
        public static readonly BuiltInRole SqlDbContributor = Parse("SQL DB Contributor");
        public static readonly BuiltInRole SqlSecurityManager = Parse("SQL Security Manager");
        public static readonly BuiltInRole SqlServerContributor = Parse("SQL Server Contributor");
        public static readonly BuiltInRole ClassicStorageAccountContributor = Parse("Classic Storage Account Contributor");
        public static readonly BuiltInRole StorageAccountContributor = Parse("Storage Account Contributor");
        public static readonly BuiltInRole UserAccessAdministrator = Parse("User Access Administrator");
        public static readonly BuiltInRole ClassicVirtualMachineContributor = Parse("Classic Virtual Machine Contributor");
        public static readonly BuiltInRole VirtualMachineContributor = Parse("Virtual Machine Contributor");
        public static readonly BuiltInRole ClassicNetworkContributor = Parse("Classic Network Contributor");
        public static readonly BuiltInRole WebPlanContributor = Parse("Web Plan Contributor");
        public static readonly BuiltInRole WebsiteContributor = Parse("Website Contributor");
    }
}
