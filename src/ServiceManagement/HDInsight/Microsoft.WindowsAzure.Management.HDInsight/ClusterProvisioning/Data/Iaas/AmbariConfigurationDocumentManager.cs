using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    internal class AmbariConfigurationDocumentManager
    {
        private JObject ambariConfiguration;

        private const string DefaultPasswordKeyName = "default_password";
        private const string ConfigurationsKeyName = "configurations";
        private const string DefaultFileSystemPropertyKeyName = "fs.defaultFS";
        private const string StorageAccountKeyPropertyKeyNamePrefix = "fs.azure.account.key.";
        private const string DefaultStorageAccountSuffix = "blob.core.windows.net";

        public const string CoreConfigurationKeyName = "core-site";
        public const string HdfsConfigurationKeyName = "hdfs-site";
        public const string MapredConfigurationKeyName = "mapred-site";
        public const string YarnConfigurationKeyName = "yarn-site";
        public const string HiveConfigurationKeyName = "hive-site";
        public const string OozieConfigurationKeyName = "oozie-site";

        public const string HiveEnvironmentKeyName = "hive-env";
        public const string OozieEnvironmentKeyName = "oozie-env";

        public const string MsSqlDatabaseType = "mssql";
        public const string MsSqlDriverName = "com.microsoft.sqlserver.jdbc.SQLServerDriver";

        public AmbariConfigurationDocumentManager(string ambariConfigurationDocument)
        {
            if (String.IsNullOrEmpty(ambariConfigurationDocument))
            {
                throw new ArgumentException("ambariConfigurationDocument");
            }

            this.ambariConfiguration = JObject.Parse(ambariConfigurationDocument);
        }

        public string Document
        {
            get { return this.ambariConfiguration.ToString(); }
        }

        public void SetPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentException("password");
            }

            ambariConfiguration[DefaultPasswordKeyName] = password;
        }

        public void RemoveStorageAccountEntries()
        {
            JObject coreSite = GetOrCreateConfigurationObject(CoreConfigurationKeyName);

            coreSite.RemoveAll();
        }

        public void SetDefaultStorageAccount(string containerName, string storageAccountName, string storageAccountKey)
        {
            if (String.IsNullOrEmpty(containerName))
            {
                throw new ArgumentException("containerName");
            }
            
            if (String.IsNullOrEmpty(storageAccountName))
            {
                throw new ArgumentException("storageAccountName");
            }

            if (String.IsNullOrEmpty(storageAccountKey))
            {
                throw new ArgumentException("storageAccountKey");
            }

            if (!storageAccountName.Contains("."))
            {
                storageAccountName = string.Format("{0}.{1}", storageAccountName, DefaultStorageAccountSuffix);
            }

            JObject coreSite = GetOrCreateConfigurationObject(CoreConfigurationKeyName);

            coreSite.Add(new JProperty(DefaultFileSystemPropertyKeyName, String.Format("wasb://{0}@{1}", containerName, storageAccountName)));
            coreSite.Add(new JProperty(String.Format("{0}{1}", StorageAccountKeyPropertyKeyNamePrefix, storageAccountName), storageAccountKey));
        }

        public void SetAdditionalStorageAccount(string storageAccountName, string storageAccountKey)
        {
            if (String.IsNullOrEmpty(storageAccountName))
            {
                throw new ArgumentException("storageAccountName");
            }

            if (String.IsNullOrEmpty(storageAccountKey))
            {
                throw new ArgumentException("storageAccountKey");
            }

            if (!storageAccountName.Contains("."))
            {
                storageAccountName = string.Format("{0}.{1}", storageAccountName, DefaultStorageAccountSuffix);
            }

            JObject coreSite = GetOrCreateConfigurationObject(CoreConfigurationKeyName);

            coreSite.Add(new JProperty(String.Format("{0}{1}", StorageAccountKeyPropertyKeyNamePrefix, storageAccountName), storageAccountKey));
        }

        public void SetCustomConfigurations(string configurationKeyName, ConfigValuesCollection configValues)
        {
            if (configValues == null || !configValues.Any())
            {
                return;
            }

            JObject configuration = GetOrCreateConfigurationObject(configurationKeyName);

            foreach (var configValue in configValues)
            {
                configuration.Add(new JProperty(configValue.Key, configValue.Value));
            }
        }

        public void SetCustomHiveMetastore(Metastore metastore)
        {
            if (metastore == null)
            {
                return;
            }

            JObject hiveConfiguration = GetOrCreateConfigurationObject(HiveConfigurationKeyName);
            hiveConfiguration.Add(new JProperty("javax.jdo.option.ConnectionUserName", String.Format("{0}@{1}", metastore.User, metastore.Server)));
            hiveConfiguration.Add(new JProperty("javax.jdo.option.ConnectionPassword", metastore.Password));
            hiveConfiguration.Add(new JProperty("javax.jdo.option.ConnectionDriverName", MsSqlDriverName));
            hiveConfiguration.Add(new JProperty("javax.jdo.option.ConnectionURL", String.Format("jdbc:sqlserver://{0};databaseName={1}", metastore.Server, metastore.Database)));

            JObject hiveEnvironment = GetOrCreateConfigurationObject(HiveEnvironmentKeyName);
            hiveEnvironment.Add(new JProperty("hive_database", "Existing MSSQL Server database with SQL authentication"));
            hiveEnvironment.Add(new JProperty("hive_database_name", metastore.Database));
            hiveEnvironment.Add(new JProperty("hive_database_type", MsSqlDatabaseType));
            hiveEnvironment.Add(new JProperty("hive_existing_mssql_server_database", metastore.Database));
            hiveEnvironment.Add(new JProperty("hive_existing_mssql_server_host", metastore.Server));
            hiveEnvironment.Add(new JProperty("hive_hostname", metastore.Server));
        }

        public void SetCustomOozieMetastore(Metastore metastore)
        {
            if (metastore == null)
            {
                return;
            }

            JObject oozieConfiguration = GetOrCreateConfigurationObject(OozieConfigurationKeyName);
            oozieConfiguration.Add(new JProperty("oozie.db.schema.name", metastore.Database));
            oozieConfiguration.Add(new JProperty("oozie.service.JPAService.jdbc.username", String.Format("{0}@{1}", metastore.User, metastore.Server)));
            oozieConfiguration.Add(new JProperty("oozie.service.JPAService.jdbc.password", metastore.Password));
            oozieConfiguration.Add(new JProperty("oozie.service.JPAService.jdbc.driver", MsSqlDriverName));
            oozieConfiguration.Add(new JProperty("oozie.service.JPAService.jdbc.url", String.Format("jdbc:sqlserver://{0};databaseName={1}", metastore.Server, metastore.Database)));

            JObject oozieEnvironment = GetOrCreateConfigurationObject(OozieEnvironmentKeyName);
            oozieEnvironment.Add(new JProperty("oozie_database", "Existing MSSQL Server database with SQL authentication"));
            oozieEnvironment.Add(new JProperty("oozie_database_type", MsSqlDatabaseType));
            oozieEnvironment.Add(new JProperty("oozie_existing_mssql_server_database", metastore.Database));
            oozieEnvironment.Add(new JProperty("oozie_existing_mssql_server_host", metastore.Server));
            oozieEnvironment.Add(new JProperty("oozie_hostname", metastore.Server));
        }

        public string GetPassword()
        {
            return (string)ambariConfiguration[DefaultPasswordKeyName];
        }

        public WabStorageAccountConfiguration GetDefaultStorageAccount()
        {
            JObject coreSite = GetConfigurationObject(CoreConfigurationKeyName);

            string defaultFileSystem = (string)coreSite[DefaultFileSystemPropertyKeyName];

            // Note: the defaultFileSystem will be of the form wasb://containerName@storageAccountName
            string defaultContainer = defaultFileSystem.Split('@')[0].Substring("wasb://".Length);
            string defaultStorageAccountName = defaultFileSystem.Split('@')[1];
            string defaultKeyName = String.Format("{0}{1}", StorageAccountKeyPropertyKeyNamePrefix, defaultStorageAccountName);
            string defaultStorageAccountKey = (string)coreSite[defaultKeyName];

            return new WabStorageAccountConfiguration(defaultStorageAccountName, defaultStorageAccountKey, defaultContainer);
        }

        public IEnumerable<WabStorageAccountConfiguration> GetAdditionalStorageAccounts()
        {
            List<WabStorageAccountConfiguration> additionalStorageAccounts = new List<WabStorageAccountConfiguration>();

            JObject coreSite = GetConfigurationObject(CoreConfigurationKeyName);
            
            string defaultFileSystem = (string)coreSite[DefaultFileSystemPropertyKeyName];
            string defaultStorageAccountName = defaultFileSystem.Split('@')[1];
            string defaultKeyName = String.Format("{0}{1}", StorageAccountKeyPropertyKeyNamePrefix, defaultStorageAccountName);

            foreach (JProperty property in coreSite.Properties())
            {
                if (property.Name == DefaultFileSystemPropertyKeyName || property.Name == defaultKeyName)
                {
                    continue;
                }

                string keyName = property.Name;
                string accountName = keyName.Substring(StorageAccountKeyPropertyKeyNamePrefix.Length);
                string accountKey = (string)property.Value;

                additionalStorageAccounts.Add(new WabStorageAccountConfiguration(accountName, accountKey));
            }

            return additionalStorageAccounts;
        }

        private JObject GetConfigurationObject(string configurationKeyName)
        {
            JArray configurations = ambariConfiguration[ConfigurationsKeyName] as JArray;

            foreach (var item in configurations.Children())
            {
                JProperty configurationProperty = item.Children<JProperty>().First();

                if (configurationProperty.Name == configurationKeyName)
                {
                    return configurationProperty.Value as JObject;
                }
            }

            return null;
        }

        private JObject GetOrCreateConfigurationObject(string configurationKeyName)
        {
            JObject configurationObject = GetConfigurationObject(configurationKeyName);

            if (configurationObject != null)
            {
                return configurationObject;
            }
            else
            {
                JObject newConfiguration = new JObject();
                newConfiguration.Add(configurationKeyName, new JObject());

                JArray configurations = ambariConfiguration[ConfigurationsKeyName] as JArray;
                configurations.Add(newConfiguration);

                return newConfiguration[configurationKeyName] as JObject;
            }
        }
    }
}
