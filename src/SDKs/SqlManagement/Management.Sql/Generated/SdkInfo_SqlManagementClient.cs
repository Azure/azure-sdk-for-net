
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SqlManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Sql", "BackupLongTermRetentionPolicies", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "BackupLongTermRetentionVaults", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "Capabilities", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "DataMaskingPolicies", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "DataMaskingRules", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "DatabaseAutomaticTuning", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "DatabaseBlobAuditingPolicies", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "DatabaseOperations", "2017-03-01-preview"),
                new Tuple<string, string, string>("Sql", "DatabaseRestorePoints", "2017-03-01-preview"),
                new Tuple<string, string, string>("Sql", "DatabaseThreatDetectionPolicies", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "DatabaseUsages", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "Databases", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "Databases", "2017-03-01-preview"),
                new Tuple<string, string, string>("Sql", "ElasticPoolActivities", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ElasticPoolDatabaseActivities", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ElasticPools", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "EncryptionProtectors", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "FailoverGroups", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "FirewallRules", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "GeoBackupPolicies", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "Operations", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "RecommendedElasticPools", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "RecoverableDatabases", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ReplicationLinks", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "RestorableDroppedDatabases", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ServerAutomaticTuning", "2017-03-01-preview"),
                new Tuple<string, string, string>("Sql", "ServerAzureADAdministrators", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ServerCommunicationLinks", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ServerConnectionPolicies", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ServerDnsAliases", "2017-03-01-preview"),
                new Tuple<string, string, string>("Sql", "ServerKeys", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "ServerUsages", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "Servers", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "Servers", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "ServiceObjectives", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "ServiceTierAdvisors", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "SubscriptionUsages", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "SyncAgents", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "SyncGroups", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "SyncMembers", "2015-05-01-preview"),
                new Tuple<string, string, string>("Sql", "TransparentDataEncryptionActivities", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "TransparentDataEncryptions", "2014-04-01"),
                new Tuple<string, string, string>("Sql", "VirtualNetworkRules", "2015-05-01-preview"),
            }.AsEnumerable();
        }
    }
}
