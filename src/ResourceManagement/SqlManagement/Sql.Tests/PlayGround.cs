//using Microsoft.Azure.Management.Sql;
//using Microsoft.Rest;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Sql.Tests
//{
//    public class PlayGround
//    {
//        public static void Main()
//        {
//            string resourceGroup = "adamkr";

//            Microsoft.Azure.Management.Sql.SqlManagementClient client = new Microsoft.Azure.Management.Sql.SqlManagementClient(null);

//            #region server stuff - sql.core.json

//            var s = client.Servers.CreateOrUpdate(
//            resourceGroup,
//            "myserver",
//            new Microsoft.Azure.Management.Sql.Models.Server()
//            {
//                AdministratorLogin = "mylogin",
//                AdministratorLoginPassword = "mypassword",
//                Location = "West Europe",
//                Tags = new Dictionary<string, string>()
//                {
//                    { "a", "b" }
//                },
//                Version = "12.0",
//            });

//            s.AdministratorLoginPassword = "newpassword";

//            var s2 = client.Servers.CreateOrUpdate(resourceGroup, "myserver", s);

//            var sList = client.Servers.List(resourceGroup);

//            var su = client.Servers.ListUsages(resourceGroup, s.Name);

//            #endregion

//            #region firewallrules - serverFirewallRules.json

//            var f = client.Servers.CreateOrUpdateFirewallRule(
//            resourceGroup,
//            s.Name,
//            "name",
//            new Microsoft.Azure.Management.Sql.Models.FirewallRule()
//            {
//                StartIpAddress = "0.0.0.0",
//                EndIpAddress = "255.255.255.255",
//            });

//            f.StartIpAddress = "1.1.1.1";
//            f.EndIpAddress = "2.2.2.2";

//            var f2 = client.Servers.CreateOrUpdateFirewallRule(resourceGroup, s.Name, f.Name, f);

//            var fList = client.Servers.ListFirewallRules(resourceGroup, s.Name);

//            #endregion

//            #region databases - sql.core.json

//            var db = client.Databases.CreateOrUpdate(
//            resourceGroup,
//            s.Name,
//            "mydb",
//            new Microsoft.Azure.Management.Sql.Models.Database()
//            {
//                Edition = "Standard",
//                RequestedServiceObjectiveId = Guid.Empty,
//                ElasticPoolName = "mypool",
//                RequestedServiceObjectiveName = "S1",
//                Location = s.Location,
//                MaxSizeBytes = 250 * 1024L * 1024L * 1024L,
//                Tags = new Dictionary<string, string>()
//                {
//                    { "a", "b" }
//                },
//            });

//            db.Edition = "Basic";
//            db.MaxSizeBytes = 5 * 1024L * 1024L * 1024L;
//            db.RequestedServiceObjectiveName = "Basic";

//            var db2 = client.Databases.CreateOrUpdate(resourceGroup, s.Name, db.Name, db);

//            var dbList = client.Databases.List(resourceGroup, s.Name);

//            client.Databases.Delete(resourceGroup, s.Name, db.Name);

//            var dbus = client.Databases.ListUsages(resourceGroup, s.Name, db.Name);

//            #endregion

//            #region Location capabilities - sql.core.json

//            var cap = client.Capabilities.Get("West US");

//            var unit = cap.SupportedServerVersions[0].SupportedEditions[0].SupportedServiceLevelObjectives[0].SupportedMaxSizes[0].Unit;

//            #endregion

//            #region Elastic Pools - sql.core.json

//            var ep = client.ElasticPools.CreateOrUpdate(
//            resourceGroup,
//            s.Name,
//            "mypool",
//            new Microsoft.Azure.Management.Sql.Models.ElasticPool()
//            {
//                DatabaseDtuMax = 100,
//                DatabaseDtuMin = 0,
//                Dtu = 500,
//                Edition = "Standard",
//                Location = s.Location,
//                StorageMB = 500 * 1024,
//                Tags = new Dictionary<string, string>()
//                {
//                    { "a","b" }
//                }
//            });

//            ep.Edition = "Premium";

//            var ep2 = client.ElasticPools.CreateOrUpdate(resourceGroup, s.Name, ep.Name, ep);

//            var epList = client.ElasticPools.List(resourceGroup, s.Name);

//            #endregion

//            #region ImportExport - importExport.json

//            var ir = client.Servers.ImportDatabase(resourceGroup, s.Name, new Microsoft.Azure.Management.Sql.Models.ImportRequestParameters()
//            {
//                AdministratorLogin = "login",
//                AdministratorLoginPassword = "password",
//                AuthenticationType = "SQL",
//                DatabaseName = "importDb",
//                Edition = Microsoft.Azure.Management.Sql.Models.ImportExportDatabaseEditions.Standard,
//                MaxSizeBytes = (250 * 1024L * 1024L * 1024L).ToString(),
//                ServiceObjectiveName = "S2",
//                StorageKey = "aaa",
//                StorageKeyType = Microsoft.Azure.Management.Sql.Models.StorageKeyType.SharedAccessKey,
//                StorageUri = ""
//            });

//            var irStat = client.Servers.GetImportStatus(resourceGroup, s.Name, ir.RequestId.Value);

//            var er = client.Databases.Export(resourceGroup, s.Name, db.Name, new Microsoft.Azure.Management.Sql.Models.ExportRequestParameters()
//            {
//                AdministratorLogin = "",
//                AdministratorLoginPassword = "",
//                AuthenticationType = "Sql",
//                StorageKey = "",
//                StorageKeyType = "Primary",
//                StorageUri = ""
//            });

//            var erStat = client.Databases.GetImportExportStatus(resourceGroup, s.Name, db.Name, er.RequestId.Value);

//            #endregion

//            #region Server Disaster Recovery Configuration - serverDisasterRecoveryConfiguration.json

//            var sdr = client.Servers.CreateOrUpdateDisasterRecoveryConfiguration(resourceGroup, s.Name, "newDr", new Microsoft.Azure.Management.Sql.Models.ServerDisasterRecoveryConfiguration()
//            {
//                AutoFailover = "true",
//                FailoverPolicy = "allowdataloss",
//                PartnerLogicalServerName = s2.Name,
//                PartnerServerId = s2.Id,
//                Role = "Secondary",
//                Type = "",
//            });

//            var lsdr = client.Servers.ListDisasterRecoveryConfigurations(resourceGroup, s.Name);

//            sdr.FailoverPolicy = "asdf";
//            sdr.AutoFailover = "false";

//            var sdr2 = client.Servers.CreateOrUpdateDisasterRecoveryConfiguration(resourceGroup, s.Name, sdr.Name, sdr);

//            #endregion

//            #region Deleted database backup - recoverableDatabases.json

//            var gb = client.Databases.GetGeoBackup(resourceGroup, s.Name, db.Name);

//            var gbl = client.Databases.ListGeoBackups(resourceGroup, s.Name);

//            var rdbl = client.Databases.ListBackupsForDeletedDatabases(resourceGroup, s.Name);

//            var rdb = client.Databases.GetBackupForDeletedDatabase(resourceGroup, s.Name, db.Name);

//            #endregion

//            #region AuditingPolicies - auditingPolicies.json

//            var dp = client.AuditingPolicy.CreateOrUpdateDatebasePolicy(resourceGroup, s.Name, db.Name, new Microsoft.Azure.Management.Sql.Models.DatabaseAuditingPolicy()
//            {
//                AuditingState = "",
//                AuditLogsTableName = "",
//                EventTypesToAudit = "",
//                FullAuditLogsTableName = "",
//                RetentionDays = "",
//                StorageAccountKey = "",
//                StorageAccountName = "",
//                StorageAccountResourceGroupName = "",
//                StorageAccountSecondaryKey = "",
//                StorageAccountSubscriptionId = "",
//                StorageTableEndpoint = "",
//                UseServerDefault = ""
//            });

//            var sp = client.AuditingPolicy.CreateOrUpdateServerPolicy(resourceGroup, s.Name, new Microsoft.Azure.Management.Sql.Models.ServerAuditingPolicy()
//            {
//                AuditingState = "",
//                AuditLogsTableName = "",
//                EventTypesToAudit = "",
//                FullAuditLogsTableName = "",
//                RetentionDays = "",
//                StorageAccountKey = "",
//                StorageAccountName = "",
//                StorageAccountResourceGroupName = "",
//                StorageAccountSecondaryKey = "",
//                StorageAccountSubscriptionId = "",
//                StorageTableEndpoint = ""
//            });

//            var dpl = client.AuditingPolicy.GetDatabasePolicy(resourceGroup, s.Name, db.Name);

//            var spl = client.AuditingPolicy.GetServerPolicy(resourceGroup, s.Name);

//            #endregion

//            #region Data Masking - dataMasking.json

//            var dmp = client.DataMasking.CreateOrUpdatePolicy(resourceGroup, s.Name, db.Name, new Microsoft.Azure.Management.Sql.Models.DataMaskingPolicy()
//            {
//                DataMaskingState = "",
//                ExemptPrincipals = ""
//            });

//            dmp.DataMaskingState = "";
//            dmp.ExemptPrincipals = "";

//            var dmp2 = client.DataMasking.CreateOrUpdatePolicy(resourceGroup, s.Name, db.Name, dmp);

//            var dmpl = client.DataMasking.GetPolicy(resourceGroup, s.Name, db.Name);
            
//            var dmr = client.DataMasking.CreateOrUpdateRule(resourceGroup, s.Name, db.Name, "rule", new Microsoft.Azure.Management.Sql.Models.DataMaskingRule()
//            {
//                ColumnName = "",
//                DataMaskingRuleId = "",
//                MaskingFunction = "",
//                NumberFrom = "",
//                NumberTo = "",
//                PrefixSize = "",
//                ReplacementString = "",
//                RuleState = "",
//                SchemaName = "",
//                SuffixSize = "",
//                TableName = ""
//            });

//            dmr.ColumnName = "";
//            dmr.DataMaskingRuleId = "";

//            var dmr2 = client.DataMasking.CreateOrUpdateRule(resourceGroup, s.Name, db.Name, dmr.Name, dmr);

//            var dmrl = client.DataMasking.ListRules(resourceGroup, s.Name, db.Name);

//            client.DataMasking.DeleteRule(resourceGroup, s.Name, db.Name, dmr2.Name);

//            #endregion

//            #region Elastic Pool Recommendations - sql.core.json

//            var eprl = client.RecommendedElasticPools.List(resourceGroup, s.Name);

//            var eprdb = client.RecommendedElasticPools.GetDatabases(resourceGroup, s.Name, eprl.First().Name, db.Name);

//            var eprdbl = client.RecommendedElasticPools.ListDatabases(resourceGroup, s.Name, "name");

//            var epr = client.RecommendedElasticPools.Get(resourceGroup, s.Name, eprl.First().Name);

//            var metrics = client.RecommendedElasticPools.ListMetrics(resourceGroup, s.Name, "name");

//            #endregion

//            #region Database Replication Links - replicationLinks.json

//            var linklist = client.Databases.ListReplicationLinks(resourceGroup, s.Name, db.Name);

//            var dblink = client.Databases.GetReplicationLink(resourceGroup, s.Name, db.Name, linklist.First().Name);

//            client.Databases.DeleteReplicationLink(resourceGroup, s.Name, db.Name, dblink.Name);

//            client.Databases.FailoverReplicationLink(resourceGroup, s.Name, db.Name, dblink.Name);

//            client.Databases.FailoverReplicationLinkAllowDataLoss(resourceGroup, s.Name, db.Name, dblink.Name);

//            #endregion

//            #region Database Secure Connection Policy - secureConnectionPolicy.json

//            var dscp = client.Databases.CreateOrUpdateSecureConnectionPolicy(resourceGroup, s.Name, db.Name, new Microsoft.Azure.Management.Sql.Models.DatabaseSecureConnectionPolicy()
//            {
//                SecurityEnabledAccess = "",
//            });

//            dscp.SecurityEnabledAccess = "";

//            var dscp2 = client.Databases.CreateOrUpdateSecureConnectionPolicy(resourceGroup, s.Name, db.Name, dscp);

//            var dscpl = client.Databases.GetSecureConnectionPolicy(resourceGroup, s.Name, db.Name);

//            #endregion

//            #region Server AAD Administrators - serverAdministrators.json

//            var aada = client.Servers.CreateOrUpdateAzureADAdministrator(resourceGroup, s.Name, "newname", new Microsoft.Azure.Management.Sql.Models.ServerAzureADAdministrator()
//            {
//                AdministratorType = "",
//                Login = "",
//                Sid = "",
//                TenantId = ""
//            });

//            aada.Login = "";
//            aada.Sid = "";

//            var aada2 = client.Servers.CreateOrUpdateAzureADAdministrator(resourceGroup, s.Name, aada.Name, aada);

//            client.Servers.DeleteAzureADAdministrator(resourceGroup, s.Name, aada2.Name);

//            var aada3 = client.Servers.GetAzureADAdministrator(resourceGroup, s.Name, aada.Name);

//            var aadal = client.Servers.ListAzureADAdministrator(resourceGroup, s.Name);

//            #endregion

//            #region Service Tier Advisors - sql.core.json

//            var stal = client.Databases.ListServiceTierAdvisors(resourceGroup, s.Name, db.Name);

//            var sta = client.Databases.GetServiceTierAdvisor(resourceGroup, s.Name, db.Name, "");

//            #endregion

//            #region Service Objectives - sql.core.json

//            var slo = client.Servers.GetServiceObjective(resourceGroup, s.Name, "S1");

//            var slol = client.Servers.ListServiceObjectives(resourceGroup, s.Name);

//            #endregion

//            #region Transparent Data Encryption - sql.core.json

//            var tde = client.Databases.SetTransparentDataEncryption(resourceGroup, s.Name, db.Name, new Microsoft.Azure.Management.Sql.Models.TransparentDataEncryption()
//            {
//                Status = "Enabled",
//            });

//            tde.Status = "Disabled";

//            var tde2 = client.Databases.SetTransparentDataEncryption(resourceGroup, s.Name, db.Name, tde);

//            var tde1 = client.Databases.GetTransparentDataEncryption(resourceGroup, s.Name, db.Name);

//            var tdea = client.Databases.ListTransparentDataEncryptionActivity(resourceGroup, s.Name, db.Name);

//            #endregion

//            #region

//            var asdf = client.EngineAuditRecords.List(resourceGroup, s.Name, db.Name);
            

//            #endregion 

//        }
//    }
//}
