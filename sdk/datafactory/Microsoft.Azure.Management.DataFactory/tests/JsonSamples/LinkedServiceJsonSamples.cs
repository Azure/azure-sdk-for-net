// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    /// <summary>
    /// Contains LinkedService JSON samples. Samples added here will automatically be hit by the der/se unit tests.
    /// </summary>
    public class LinkedServiceJsonSamples : JsonSampleCollection<LinkedServiceJsonSamples>
    {
        [JsonSample]
        public const string AzureBlobFSLinkedService = @"
{
    name: ""Test-Windows-Azure-storage-account-linkedService"",
    properties:
    {
        type: ""AzureBlobFS"",
        typeProperties:
        {
          url: ""https://testblobfs.dfs.core.windows.net"",
          servicePrincipalId: ""9c8b1ab1-a894-4639-8fb9-75f98a36e9ab"",
          servicePrincipalKey: {
             type: ""SecureString"",
             value: ""mykey""
          },
          tenant: ""72f988bf-86f1-41af-91ab-2d7cd011db47"",
          azureCloudType: ""AzurePublic""
        }
    }
}";

        [JsonSample]
        public const string AzureStorageLinkedService = @"
{
    name: ""Test-Windows-Azure-storage-account-linkedService"",
    properties:
    {
        type: ""AzureStorage"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
        }
    }
}";

        [JsonSample]
        public const string AzureStorageLinkedServiceWithAccountKeyInAKV = @"
{
    name: ""Test-Windows-Azure-storage-account-linkedService-with-AccountKey-in-AKV"",
    properties:
    {
        type: ""AzureStorage"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            accountKey: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string AzureStorageLinkedServiceWithSasUri = @"
{
    name: ""Test-Windows-Azure-storage-linkedService-with-SasUri"",
    properties:
    {
        type: ""AzureStorage"",
        typeProperties:
        {
            sasUri: {
                value : ""fakeSasUri"",
                type : ""SecureString""
            },
        }
    }
}";

        [JsonSample]
        public const string AzureStorageLinkedServiceWithSasUriAndSasTokenInAKV = @"
{
    name: ""Test-Windows-Azure-storage-linkedService-with-SasUri-and-SasToken-in-AKV"",
    properties:
    {
        type: ""AzureStorage"",
        typeProperties:
        {
            sasUri: {
                value : ""fakeSasUri"",
                type : ""SecureString""
            },
            sasToken: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string HDISLinkedService = @"
{
    name: ""Test-HDIS-LinkedService"",
    properties:
    {
        type: ""SqlServer"",
        connectVia: {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            userName: ""WindowsAuthUserName"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string AzureSqlLinkedService = @"
{
    name: ""Test-Windows-Azure-SQL-LinkedService"",
    properties:
    {
        type: ""AzureSqlDatabase"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            azureCloudType: ""AzurePublic""
        }
}
}";

        [JsonSample]
        public const string AzureSqlMILinkedService = @"
{
    name: ""Test-Windows-Azure-SQL-MI-LinkedService"",
    properties:
    {
        type: ""AzureSqlMI"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            servicePrincipalId: ""fakeSPID"",
            servicePrincipalKey: {
                value: ""fakeSPKey"",
                type: ""SecureString""
            },
            tenant: ""fakeTenant"",
            azureCloudType: ""AzurePublic""
        }
    }
}";

        [JsonSample]
        public const string AzureSqlLinkedServiceWithPasswordInAKV = @"
{
    name: ""Test-Windows-Azure-SQL-LinkedService-with-Password-in-AKV"",
    properties:
    {
        type: ""AzureSqlDatabase"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            password: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string AzureSqlDataWarehouseLinkedService = @"
{
    name: ""Test-Windows-Azure-SQLDW-LinkedService"",
    properties:
    {
        type: ""AzureSqlDW"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            azureCloudType: ""AzurePublic""
        }
    }
}";

        [JsonSample]
        public const string AzureSqlDataWarehouseLinkedServiceWithPasswordInAKV = @"
{
    name: ""Test-Windows-Azure-SQLDW-LinkedService-with-Password-in-AKV"",
    properties:
    {
        type: ""AzureSqlDW"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            password: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string AzureMLLinkedServiceJson = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""AzureML"",
        typeProperties:
        {
            mlEndpoint:""https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs"",
            apiKey: {
                value : ""fakeKey"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string AzureMLServiceLinkedService = @"
{
    name: ""Test-AzureMLService-LinkedService"",
    properties:
    {
        type: ""AzureMLService"",
        connectVia: {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties:
        {
            subscriptionId: ""1e42591f-0000-0000-0000-a268f6105ec5"",
            resourceGroupName: ""MyResourceGroupName"",
            mlWorkspaceName: ""MyMLWorkspaceName"",
            servicePrincipalId: ""fakeSPID"",
            servicePrincipalKey: {
                value: ""fakeSPKey"",
                type: ""SecureString""
            },
            tenant: ""fakeTenant""
        }
    }
}";

        [JsonSample]
        public const string AzureMLLinkedServiceWithOptionalPropertyJson = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""AzureML"",
        typeProperties:
        {
            mlEndpoint:""https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs"",
            apiKey: {
                value : ""fakeKey"",
                type : ""SecureString""
            },
            updateResourceEndpoint:""https://management.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/endpoints/endpoint2""
        }
    }
}";

        [JsonSample]
        public const string AzureMLLinkedServiceArmWithOptionalPropertyJson = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""AzureML"",
        typeProperties:
        {
            mlEndpoint:""https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs"",
            apiKey: {
                value : ""fakeKey"",
                type : ""SecureString""
            },
            updateResourceEndpoint:""https://management.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/endpoints/endpoint2"",
            servicePrincipalId: ""fe273844-c808-40b8-ad85-94a46f737731"",
            servicePrincipalKey: {
                value : ""fakeKey"",
                type : ""SecureString""
            },
            tenant:  ""microsoft.com""
        }
    }
}";

        [JsonSample]
        public const string AzureDataLakeAnalyticsLinkedServiceJson = @"
{
    name: ""Test-ADLA-LinkedService"",
    properties:
    {
        type: ""AzureDataLakeAnalytics"",
        typeProperties:
        {
             ""accountName"": ""fake"",
             ""servicePrincipalId"": ""fe273844-c808-40b8-ad85-94a46f737731"",
             ""servicePrincipalKey"": {
                    value : ""fakeKey"",
                    type : ""SecureString""
                },
             ""tenant"": ""fake"",
             ""dataLakeAnalyticsUri"": ""fake.com"",
             ""subscriptionId"": ""fe273844-c808-40b8-ad85-94a46f737731""
        }
    }
}";

        [JsonSample]
        public const string LinkedServiceOptionalHubName = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsight"",
        typeProperties:
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            linkedServiceName: {
                referenceName : ""ls"",
                type : ""LinkedServiceReference""
            }
        }
    }
}
";

        [JsonSample]
        public const string HDInsightBYOCWithHCatalogLinkedService = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsight"",
        typeProperties:
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            linkedServiceName: {
                referenceName : ""ls"",
                type : ""LinkedServiceReference""
            },
            hcatalogLinkedServiceName : {
                referenceName : ""ls"",
                type : ""LinkedServiceReference""
            }
        }
    }
}
";

        [JsonSample]
        public const string AzureBatchLinkedService = @"
{
    name: ""Test-AzureBatch-Pool-linkedService"",
    properties:
    {
        type: ""AzureBatch"",
        typeProperties: {
            accountName: {
                value: ""@parameters('StartTime')"",
                type: ""Expression""
            },
            batchUri: ""myaccount.region.batch.windows.com"",
            accessKey: {
                value : ""fakeAccessKey"",
                type : ""SecureString""
            },
            poolName: ""MyAzureBatchPool"",
            linkedServiceName: {
                referenceName : ""ls"",
                type : ""LinkedServiceReference""
            }
        },
        description: ""Example of Azure Batch with parameter, description, and expression""
    }
}";

        [JsonSample]
        public const string SqlLinkedService = @"
{
    name: ""LinkedService-SQLDB"",
    properties:
    {
        type: ""SqlServer"",
        connectVia: {
            referenceName : ""CherryAgent-01"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            userName: ""MyUserName"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string OracleLinkedService = @"
{
    name: ""LinkedService-OracleDB"",
    properties:
    {
        type: ""Oracle"",
        connectVia: {
            referenceName : ""CherryAgent-01"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string OracleLinkedServiceWithPasswordInAKV = @"
{
    name: ""LinkedService-OracleDB-with-Password-in-AKV"",
    properties:
    {
        type: ""Oracle"",
        connectVia: {
            referenceName : ""CherryAgent-01"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            password: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            },
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string FileSystemLinkedService = @"
{
    name: ""LinkedService-FileSystem"",
    properties:
    {
        type: ""FileServer"",
        connectVia: {
            referenceName : ""CherryAgent-01"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            host: ""Myhost"",
            userId: ""MyUserId"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string CosmosDbLinkedService = @"
{
    name: ""LinkedService-CosmosDb"",
    properties:
    {
        type: ""CosmosDb"",
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string CosmosDbLinkedServiceWithoutConnectionString = @"
{
    name: ""LinkedService-CosmosDb"",
    properties:
    {
        type: ""CosmosDb"",
        typeProperties: {
            accountEndpoint: ""https://fakecosmosdb.documents.azure.com:443/"",
            database: ""testdb"",
            accountKey: {
                value : ""fakeConnString"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string CosmosDbLinkedServiceWithAccountKeyInAKV = @"
{
    name: ""LinkedService-CosmosDb-with-AccountKey-in-AKV"",
    properties:
    {
        type: ""CosmosDb"",
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            accountKey: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string TeradataLinkedService = @"
{
    name: ""Test-Teradata-linkedService"",
    properties:
    {
        type: ""Teradata"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            server: ""volvo2.teradata.ws"",
            username: ""microsoft"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            authenticationType: ""Basic""
        }
    }
}";

        [JsonSample]
        public const string TeradataOdbcLinkedService = @"
{
    name: ""Test-Teradata-linkedService"",
    properties:
    {
        type: ""Teradata"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString: ""fakedConnectionString"",
            username: ""microsoft"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string HDInsightBYOCLinkedService = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsight"",
        typeProperties:
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: {
                    value : ""fakepassword"",
                    type : ""SecureString""
                },
            linkedServiceName: {
                referenceName : ""ls"",
                type : ""LinkedServiceReference""
            }
        }
    }
}
";

        [JsonSample]
        public const string OdbcLinkedService = @"
{
    name: ""Test-ODBC-linkedService"",
    properties:
    {
        type: ""Odbc"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            credential: {
                value : ""fakeCredential"",
                type : ""SecureString""
            },
            userName: ""microsoft"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            authenticationType: ""Basic"",
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string InformixLinkedService = @"
{
    name: ""Test-Informix-linkedService"",
    properties:
    {
        type: ""Informix"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            credential: {
                value : ""fakeCredential"",
                type : ""SecureString""
            },
            userName: ""microsoft"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            authenticationType: ""Basic"",
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string MicrosoftAccessLinkedService = @"
{
    name: ""Test-MicrosoftAccess-linkedService"",
    properties:
    {
        type: ""MicrosoftAccess"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            credential: {
                value : ""fakeCredential"",
                type : ""SecureString""
            },
            userName: ""microsoft"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            authenticationType: ""Basic"",
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string HdfsLinkedService = @"
{
    name: ""Test-HDFS-linkedService"",
    properties:
    {
        type: ""Hdfs"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            url: ""http://myhost:50070/webhdfs/v1"",
            userName: ""microsoft"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            authenticationType: ""Windows"",
            encryptedCredential: ""myEncryptedCredential""
        }
    }
}";

        [JsonSample]
        public const string ODataLinkedService = @"
{
    name: ""LinkedService-OData"",
    properties:
    {
        type: ""OData"",
        description: ""test description"",
        typeProperties:
        {
            authenticationType: ""Basic"",
            url : ""http://localhost/webhdfs/v1/"",
            userName: ""admin"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            azureCloudType: ""AzurePublic""
        }
    }
}";

        [JsonSample]
        public const string WebLinkedService = @"
{
    name: ""Test-Web-linkedService"",
    properties:
    {
        type: ""Web"",
        typeProperties: {
            url: ""http://myhost.com/"",
            authenticationType: ""Basic"",
            username: ""microsoft"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string WebLinkedServiceWithClientCertificateAuthentication = @"
      {
        ""name"": ""myClientCertificateAuthentication"",
        ""properties"": {
          ""type"": ""Web"",
          ""typeProperties"": {
            ""authenticationType"": ""ClientCertificate"",
            ""url"": ""https://localhost"",
            ""pfx"": {
              ""value"": ""<certificate value>"",
              ""type"": ""SecureString""
            },
            ""password"": {
              ""value"": ""OpenSesame"",
              ""type"": ""SecureString""
            }
          }
        }
      }
";

        [JsonSample]
        public const string CassandraLinkedService = @"
{
    name: ""LinkedService-Cassandra"",
    properties:
    {
        type: ""Cassandra"",
        connectVia: {
            referenceName : ""fakeir"",
            type : ""IntegrationRuntimeReference""
        },
        description: ""test description"",
        typeProperties:
        {
            authenticationType: ""Basic"",
            host : ""http://localhost/webhdfs/v1/"",
            port : 1234,
            username: ""admin"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            encryptedCredential : ""fake credential""
        }
    }
}";

        [JsonSample]
        public const string DynamicsLinkedService_AKV = @"
{
    name: ""Test-Dynamics-LinkedService"",
    properties:
    {
        type : ""Dynamics"",
        connectVia : {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties :
        {
            deploymentType : ""Online"", 
            authenticationType : ""Office365"", 
            username : ""fakeuser@contoso.com"",
            password : { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string DynamicsLinkedService_S2S_Key = @"
{
    name: ""Test-Dynamics-LinkedService-S2S-Key"",
    properties:
    {
        type : ""Dynamics"",
        connectVia : {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties :
        {
            deploymentType : ""Online"", 
            authenticationType : ""AadServicePrincipal"", 
            servicePrincipalCredentialType: ""ServicePrincipalKey"",
            servicePrincipalId : ""9bf5d9fd-5dcd-46a5-b99b-77d69adb2567"",
            servicePrincipalCredential : { 
                  value: ""fakepassword"",
                  type: ""SecureString""
            } 
        }
    }
}";

        [JsonSample]
        public const string DynamicsLinkedService_S2S_Cert = @"
{
    name: ""Test-Dynamics-LinkedService-S2S-Cert"",
    properties:
    {
        type : ""Dynamics"",
        connectVia : {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties :
        {
            deploymentType : ""Online"", 
            authenticationType : ""AadServicePrincipal"", 
            servicePrincipalCredentialType: ""ServicePrincipalCert"",
            servicePrincipalId : ""9bf5d9fd-5dcd-46a5-b99b-77d69adb2567"",
            servicePrincipalCredential : { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeCertName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            } 
        }
    }
}";

        [JsonSample]
        public const string DynamicsLinkedService = @"
{
    name: ""LinkedService-Dynamics"",
    properties:
    {
        type: ""Dynamics"",
        typeProperties: {
            deploymentType: ""Online"",
            authenticationType: ""Office365"",
            hostName: ""hostname.com"",
            port: 12345,
            organizationName: ""contoso"",
            username: ""fakeuser@contoso.com"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            encryptedCredential : ""fake credential""
        }
    }
}";

        [JsonSample]
        public const string DynamicsCrmLinkedService = @"
{
    name: ""LinkedService-DynamicsCrm"",
    properties:
    {
        type: ""DynamicsCrm"",
        typeProperties: {
            deploymentType: ""Online"",
            authenticationType: ""Office365"",
            hostName: ""hostname.com"",
            port: 12345,
            organizationName: ""contoso"",
            username: ""fakeuser@contoso.com"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            encryptedCredential : ""fake credential""
        }
    }
}";

        [JsonSample]
        public const string DynamicsCrmLinkedService_S2S_Key = @"
{
    name: ""LinkedService-DynamicsCrm-S2S-Key"",
    properties:
    {
        type : ""DynamicsCrm"",
        connectVia : {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties :
        {
            deploymentType : ""Online"", 
            authenticationType : ""AadServicePrincipal"", 
            servicePrincipalCredentialType: ""ServicePrincipalKey"",
            servicePrincipalId : ""9bf5d9fd-5dcd-46a5-b99b-77d69adb2567"",
            servicePrincipalCredential : { 
                  value: ""fakepassword"",
                  type: ""SecureString""
            } 
        }
    }
}";

        [JsonSample]
        public const string DynamicsCrmLinkedService_S2S_Cert = @"
{
    name: ""LinkedService-DynamicsCrm-S2S-Cert"",
    properties:
    {
        type : ""DynamicsCrm"",
        connectVia : {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties :
        {
            deploymentType : ""Online"", 
            authenticationType : ""AadServicePrincipal"", 
            servicePrincipalCredentialType: ""ServicePrincipalCert"",
            servicePrincipalId : ""9bf5d9fd-5dcd-46a5-b99b-77d69adb2567"",
            servicePrincipalCredential : { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeCertName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            } 
        }
    }
}";

        [JsonSample]
        public const string CommonDataServiceForAppsLinkedService_S2S_Key = @"
{
    name: ""LinkedService-CommonDataServiceForApps-S2S-Key"",
    properties:
    {
        type : ""CommonDataServiceForApps"",
        connectVia : {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties :
        {
            deploymentType : ""Online"", 
            authenticationType : ""AadServicePrincipal"", 
            servicePrincipalCredentialType: ""ServicePrincipalKey"",
            servicePrincipalId : ""9bf5d9fd-5dcd-46a5-b99b-77d69adb2567"",
            servicePrincipalCredential : { 
                  value: ""fakepassword"",
                  type: ""SecureString""
            } 
        }
    }
}";

        [JsonSample]
        public const string CommonDataServiceForAppsLinkedService_S2S_Cert = @"
{
    name: ""LinkedService-CommonDataServiceForApps-S2S-Cert"",
    properties:
    {
        type : ""CommonDataServiceForApps"",
        connectVia : {
            referenceName : ""Connection1"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties :
        {
            deploymentType : ""Online"", 
            authenticationType : ""AadServicePrincipal"", 
            servicePrincipalCredentialType: ""ServicePrincipalCert"",
            servicePrincipalId : ""9bf5d9fd-5dcd-46a5-b99b-77d69adb2567"",
            servicePrincipalCredential : { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeCertName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            } 
        }
    }
}";

        [JsonSample]
        public const string CommonDataServiceForAppsLinkedService = @"
{
    name: ""LinkedService-CommonDataServiceForApps"",
    properties:
    {
        type: ""CommonDataServiceForApps"",
        typeProperties: {
            deploymentType: ""Online"",
            authenticationType: ""Office365"",
            hostName: ""hostname.com"",
            port: 12345,
            organizationName: ""contoso"",
            username: ""fakeuser@contoso.com"",
            password: {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            encryptedCredential : ""fake credential""
        }
    }
}";

        [JsonSample]
        public const string SalesforceLinkedService = @"
{
    name: ""SalesforceLinkedService"",
    properties:
    {
        type: ""Salesforce"",
        description: ""test description"",
        typeProperties:
        {
            environmentUrl: ""url"",
            username: ""admin"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            securityToken: {
                value : ""fakeToken"",
                type : ""SecureString""
            },
            apiVersion:""47.0""
        }
    }
}";

        [JsonSample]
        public const string SalesforceLinkedServiceWithoutSecurityToken = @"
{
    name: ""SalesforceLinkedService"",
    properties:
    {
        type: ""Salesforce"",
        description: ""test description"",
        typeProperties:
        {
            environmentUrl: ""url"",
            username: ""admin"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            apiVersion:""47.0""
        }
    }
}";

        [JsonSample]
        public const string SalesforceLinkedServiceWithAkv = @"
{
    name: ""SalesforceLinkedServiceWithAkv"",
    properties:
    {
        type: ""Salesforce"",
        description: ""test description"",
        typeProperties:
        {
            environmentUrl: ""url"",
            username: ""admin"",
            password : {
                type : ""AzureKeyVaultSecret"",
                secretName : ""fakeSecretName1"",
                store : {
                    type : ""LinkedServiceReference"",
                    referenceName : ""fakeAKVLinkedService""
                }
            },
            securityToken: {
                type : ""AzureKeyVaultSecret"",
                secretName : ""fakeSecretName2"",
                store : {
                    type : ""LinkedServiceReference"",
                    referenceName : ""fakeAKVLinkedService""
                }
            },
            apiVersion:""47.0""
        }
    }
}";

        [JsonSample]
        public const string SalesforceServiceCloudLinkedService = @"
{
    name: ""SalesforceServiceCloudLinkedService"",
    properties:
    {
        type: ""SalesforceServiceCloud"",
        description: ""test description"",
        typeProperties:
        {
            environmentUrl: ""url"",
            username: ""admin"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            securityToken: {
                value : ""fakeToken"",
                type : ""SecureString""
            },
            apiVersion:""47.0""
        }
    }
}";

        [JsonSample]
        public const string SalesforceServiceCloudLinkedServiceWithoutSecurityToken = @"
{
    name: ""SalesforceServiceCloudLinkedService"",
    properties:
    {
        type: ""SalesforceServiceCloud"",
        description: ""test description"",
        typeProperties:
        {
            environmentUrl: ""url"",
            username: ""admin"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            apiVersion:""47.0""
        }
    }
}";

        [JsonSample]
        public const string SalesforceMarketingCloudLinkedService = @"
{
    name: ""SalesforceMarketingCloudLinkedService"",
    properties:
    {
        type: ""SalesforceMarketingCloud"",
        description: ""test description"",
        typeProperties: {
            clientId: ""clientIdFake"",
            clientSecret : {
                value : ""fakepassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string SalesforceMarketingCloudConnectionPropertiesLinkedService = @"
{
	name: ""SalesforceMarketingCloudLinkedService"",
	properties: {
		type: ""SalesforceMarketingCloud"",
		description: ""test description"",
		typeProperties: {
			connectionProperties: {
				clientId: ""clientIdFake"",
				clientSecret: {
					value: ""some secret"",
					type: ""SecureString""
				}
			}
		}
	}
}";

        [JsonSample]
        public const string MongoDbLinkedService = @"
{
    name: ""MongoDbLinkedService"",
    properties:
    {
        type: ""MongoDb"",
        connectVia: {
            referenceName : ""fakegw"",
            type : ""IntegrationRuntimeReference""
        },
        description: ""test description"",
        typeProperties:
        {
            authenticationType: ""Basic"",
            server : ""fakeserver.com"",
            port : 666,
            username: ""fakeuser"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            authSource : ""fackadmindb"",
            databaseName : ""fakedb"",
            encryptedCredential : ""fakecred""
        }
    }
}";

        [JsonSample]
        public const string AmazonRedshiftLinkedService = @"
{
    name: ""AmazonRedshiftLinkedService"",
    properties:
    {
        type: ""AmazonRedshift"",
        description: ""test description"",
        typeProperties:
        {
            server : ""http://localhost/fakeredshiftserver.com"",
            port : 5439,
            username: ""rsadmin"",
            password : {
                value : ""fakepassword"",
                type : ""SecureString""
            },
            database : ""fakedatabase""
        }
    }
}";

        [JsonSample]
        public const string AmazonS3LinkedService = @"
{
    name: ""AmazonS3LinkedService"",
    properties:
    {
        type: ""AmazonS3"",
        description: ""test description"",
        typeProperties:
        {
            accessKeyId : ""fakeaccess"",
            secretAccessKey : {
                value : ""fakeKey"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string AzureDataLakeStoreLinkedService = @"
{
    name: ""AzureDataLakeStoreLinkedService"",
    properties:
    {
        type: ""AzureDataLakeStore"",
        description: ""test description"",
        typeProperties:
        {
            dataLakeStoreUri : ""fakeUri"",
            servicePrincipalId : ""fakeId"",
            servicePrincipalKey : {
                value : ""fakeKey"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string AzureSearchLinkedService = @"
{
    name: ""AzureSearchLinkedService"",
    properties:
    {
        type: ""AzureSearch"",
        description: ""test description"",
        typeProperties:
        {
            url : ""fakeUrl"",
            key : {
                value : ""fakeKey"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string HttpLinkedService = @"
{
    name: ""HttpLinkedService"",
    properties:
    {
        type: ""HttpServer"",
        description: ""test description"",
        typeProperties:
        {
            url : ""fakeUrl"",
            authenticationType : ""Basic"",
            userName : ""fakeName"",
            password : {
                value : ""fakePassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string FtpServerLinkedService = @"
{
    name: ""FtpServerLinkedService"",
    properties:
    {
        type: ""FtpServer"",
        description: ""test description"",
        typeProperties:
        {
            host : ""fakeHost"",
            authenticationType : ""Basic"",
            userName : ""fakeName"",
            password : {
                value : ""fakePassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string SftpServerLinkedService = @"
{
    name: ""SftpServerLinkedService"",
    properties:
    {
        type: ""Sftp"",
        description: ""test description"",
        typeProperties:
        {
            host : ""fakeHost"",
            authenticationType : ""Basic"",
            userName : ""fakeName"",
            password : {
                value : ""fakePassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string SapBWLinkedService = @"
{
    name: ""SapBWLinkedService"",
    properties:
    {
        type: ""SapBW"",
        description: ""test description"",
        typeProperties:
        {
            server : ""fakeServer"",
            systemNumber : ""fakeNumber"",
            clientId : ""fakeId"",
            userName : ""fakeName"",
            password : {
                value : ""fakePassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string SapHanaLinkedService = @"
{
    name: ""SapHanaLinkedService"",
    properties:
    {
        type: ""SapHana"",
        description: ""test description"",
        typeProperties:
        {
            server : ""fakeServer"",
            authenticationType : ""Basic"",
            userName : ""fakeName"",
            password : {
                value : ""fakePassword"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string HDInsightOnDemandLinkedService = @"{
    name: ""HDInsightOnDemandLinkedService"",
    properties: {
        type: ""HDInsightOnDemand"",
        typeProperties: {
            clusterSize: 4,
            timeToLive: ""01: 30: 00"",
            linkedServiceName: {
                referenceName : ""ls"",
                type : ""LinkedServiceReference""
            },
            hostSubscriptionId: ""hostSubscriptionId"",
            servicePrincipalId: ""servicePrincipalId"",
            servicePrincipalKey: {
                value : ""fakeKey"",
                type : ""SecureString""
            },
            tenant: ""72f988bf-86f1-41af-91ab-2d7cd011db47"",
            clusterNamePrefix: ""OnDemandHdiResource"",
            clusterResourceGroup: ""ADF"",
            version: ""3.5"",
            headNodeSize: ""standard_v3"",
            dataNodeSize: ""standard_D12_v2""
        }
    }
}";

        [JsonSample]
        public const string AzureMySqlLinkedService = @"
{
    name: ""LinkedService-AzureMySQLDB"",
    properties:
    {
        type: ""AzureMySql"",
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string AzureMySqlLinkedServiceWithPasswordInAKV = @"
{
    name: ""LinkedService-AzureMySQLDB-with-Password-in-AKV"",
    properties:
    {
        type: ""AzureMySql"",
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            password: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string AmazonMWSLinkedService = @"
{
    name: ""AmazonMWSLinkedService"",
    properties: {
        type: ""AmazonMWS"",
        typeProperties: {
            endpoint : ""mws.amazonservices.com"",
            marketplaceID : ""A2EUQ1WTGCTBG2"",
            sellerID : ""ACGMZIK6QTD9T"",
            mwsAuthToken : {
                type: ""SecureString"",
                value: ""amzn.mws.94acb321-6915-09bf-b628-7e94337f01b7""
            },
            accessKeyId : ""123456789123"",
            secretKey : {
                type: ""SecureString"",
                value: ""7LHODzgokrgITY17EGz2u7cBAm57QX3sopQErLpU""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";
        [JsonSample]
        public const string AzurePostgreSqlLinkedService = @"
{
    name: ""AzurePostgreSqlLinkedService"",
    properties: {
        type: ""AzurePostgreSql"",
        typeProperties: {
            connectionString: {
                type: ""AzureKeyVaultSecret"",
                secretName: ""postgreSqlConnectionString"",
                store: {
                    type: ""LinkedServiceReference"",
                    referenceName: ""AKVLinkedService""
                }
            }
        }
    }
}
";
        [JsonSample]
        public const string AzurePostgreSqlLinkedServiceWithPasswordInAKV = @"
{
    name: ""AzurePostgreSqlLinkedServiceWithPasswordInAKV"",
    properties: {
        type: ""AzurePostgreSql"",
        typeProperties: {
            connectionString: {
                type: ""AzureKeyVaultSecret"",
                secretName: ""postgreSqlConnectionString"",
                store: {
                    type: ""LinkedServiceReference"",
                    referenceName: ""AKVLinkedService""
                }
            },
            password: { 
                type: ""AzureKeyVaultSecret"", 
                secretName: ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string ConcurLinkedService = @"
{
    name: ""ConcurLinkedService"",
    properties: {
        type: ""Concur"",
        typeProperties: {
            clientId : ""f145kn9Pcyq9pr4lvumdapfl4rive"",
            username : ""jsmith"",
            password : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";
        [JsonSample]
        public const string CouchbaseLinkedService = @"
{
    name: ""CouchbaseLinkedService"",
    properties: {
        type: ""Couchbase"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            }
        }
    }
}
";
        [JsonSample]
        public const string CouchbaseLinkedServiceWithCredStringInAKV = @"
{
    name: ""CouchbaseLinkedServiceWithCredStringInAKV"",
    properties: {
        type: ""Couchbase"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            },
            credString: { 
                type: ""AzureKeyVaultSecret"", 
                secretName: ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string DrillLinkedService = @"
{
    name: ""DrillLinkedService"",
    properties: {
        type: ""Drill"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            }
        }
    }
}
";
        [JsonSample]
        public const string DrillLinkedServiceWithPwdInAKV = @"
{
    name: ""DrillLinkedServiceWithPwdInAKV"",
    properties: {
        type: ""Drill"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            },
            pwd: { 
                type: ""AzureKeyVaultSecret"", 
                secretName: ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string EloquaLinkedService = @"
{
    name: ""EloquaLinkedService"",
    properties: {
        type: ""Eloqua"",
        typeProperties: {
            endpoint : ""eloqua.example.com"",
            username : ""Eloqua/Alice"",
            password : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";
        [JsonSample]
        public const string GoogleBigQueryLinkedService = @"
{
    name: ""GoogleBigQueryLinkedService"",
    properties: {
        type: ""GoogleBigQuery"",
        typeProperties: {
            project : ""myproject"",
            requestGoogleDriveScope : true,
            authenticationType : ""ServiceAuthentication"",
            refreshToken : {
                type: ""SecureString"",
                value: ""some secret""
            },
            clientId : ""myclientId"",
            clientSecret : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useSystemTrustStore : true
        }
    }
}
";

        [JsonSample]
        public const string GoogleAdWordsLinkedService = @"
{
    name: ""GoogleAdWordsLinkedService"",
    properties: {
        type: ""GoogleAdWords"",
        typeProperties: {
            clientCustomerID : ""myclientCustomerID"",
            developerToken : {
                type: ""SecureString"",
                value: ""some secret""
            },
            authenticationType : ""ServiceAuthentication"",
            refreshToken : {
                type: ""SecureString"",
                value: ""some secret""
            },
            clientId : ""myclientId"",
            clientSecret : {
                type: ""SecureString"",
                value: ""some secret""
            },
            email : ""myemail"",
            keyFilePath : ""mykeyFilePath"",
            trustedCertPath : ""mytrustedCertPath"",
            useSystemTrustStore : true
        }
    }
}
";

        [JsonSample]
        public const string GreenplumLinkedService = @"
{
    name: ""GreenplumLinkedService"",
    properties: {
        type: ""Greenplum"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            }
        }
    }
}
";
        [JsonSample]
        public const string GreenplumLinkedServiceWithPwdInAKV = @"
{
    name: ""GreenplumLinkedServiceWithPwdInAKV"",
    properties: {
        type: ""Greenplum"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            },
            pwd: { 
                type: ""AzureKeyVaultSecret"", 
                secretName: ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string HBaseLinkedService = @"
{
    name: ""HBaseLinkedService"",
    properties: {
        type: ""HBase"",
        typeProperties: {
            host : ""192.168.222.160"",
            httpPath : ""/gateway/sandbox/hbase/version"",
            authenticationType : ""Anonymous"",
            enableSsl : true,
            allowHostNameCNMismatch : true,
            allowSelfSignedServerCert : true
        }
    }
}
";
        [JsonSample]
        public const string HiveLinkedService = @"
{
    name: ""HiveLinkedService"",
    properties: {
        type: ""Hive"",
        typeProperties: {
            host : ""my server"",
            port : 1000,
            serverType : ""HiveServer1"",
            thriftTransportProtocol : ""Binary"",
            authenticationType : ""Anonymous"",
            serviceDiscoveryMode : true,
            zooKeeperNameSpace : """",
            useNativeQuery : true,
            username : """",
            password : {
                type: ""SecureString"",
                value: ""some secret""
            },
            httpPath : """",
            enableSsl : true,
            trustedCertPath : """",
            useSystemTrustStore : true,
            allowHostNameCNMismatch : true,
            allowSelfSignedServerCert : true
        }
    }
}
";
        [JsonSample]
        public const string HubspotLinkedService = @"
{
    name: ""HubspotLinkedService"",
    properties: {
        type: ""Hubspot"",
        typeProperties: {
            clientId : ""11b5516f1322-11e6-9653-93a39db85acf"",
            clientSecret : {
                type: ""SecureString"",
                value: ""abCD+E1f2Gxhi3J4klmN/OP5QrSTuvwXYzabcdEF""
            },
            accessToken : {
                type: ""SecureString"",
                value: ""some secret""
            },
            refreshToken : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";
        [JsonSample]
        public const string ImpalaLinkedService = @"
{
    name: ""ImpalaLinkedService"",
    properties: {
        type: ""Impala"",
        typeProperties: {
            host : ""192.168.222.160"",
            authenticationType : ""Anonymous"",
            username : """",
            password : {
                type: ""SecureString"",
                value: ""some secret""
            },
            enableSsl : true,
            trustedCertPath : """",
            useSystemTrustStore : true,
            allowHostNameCNMismatch : true,
            allowSelfSignedServerCert : true
        }
    }
}
";
        [JsonSample]
        public const string JiraLinkedService = @"
{
    name: ""JiraLinkedService"",
    properties: {
        type: ""Jira"",
        typeProperties: {
            host : ""jira.example.com"",
            port : 1000,
            username : ""skroob"",
            password : {
                type: ""SecureString"",
                value: ""some secret""
            }
        }
    }
}
";
        [JsonSample]
        public const string MagentoLinkedService = @"
{
    name: ""MagentoLinkedService"",
    properties: {
        type: ""Magento"",
        typeProperties: {
            host : ""192.168.222.110/magento3"",
            accessToken : {
                type: ""SecureString"",
                value: ""some secret""
            }
        }
    }
}
";
        [JsonSample]
        public const string MariaDBLinkedService = @"
{
    name: ""MariaDBLinkedService"",
    properties: {
        type: ""MariaDB"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            }
        }
    }
}
";
        [JsonSample]
        public const string AzureMariaDBLinkedService = @"
{
    name: ""AzureMariaDBLinkedService"",
    properties: {
        type: ""AzureMariaDB"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            }
        }
    }
}
";
        [JsonSample]
        public const string MariaDBLinkedServiceWithPwdInAKV = @"
{
    name: ""MariaDBLinkedServiceWithPwdInAKV"",
    properties: {
        type: ""MariaDB"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            },
            pwd: { 
                type: ""AzureKeyVaultSecret"", 
                secretName: ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string MarketoLinkedService = @"
{
    name: ""MarketoLinkedService"",
    properties: {
        type: ""Marketo"",
        typeProperties: {
            endpoint : ""123-ABC-321.mktorest.com"",
            clientId : ""fakeClientId"",
            clientSecret : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";
        [JsonSample]
        public const string PaypalLinkedService = @"
{
    name: ""PaypalLinkedService"",
    properties: {
        type: ""Paypal"",
        typeProperties: {
            host : ""api.sandbox.paypal.com"",
            clientId : ""fakeClientId"",
            clientSecret : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true,
        }
    }
}
";
        [JsonSample]
        public const string PhoenixLinkedService = @"
{
    name: ""PhoenixLinkedService"",
    properties: {
        type: ""Phoenix"",
        typeProperties: {
            host : ""192.168.222.160"",
            port : 443,
            httpPath : ""/gateway/sandbox/phoenix/version"",
            authenticationType : ""Anonymous"",
            enableSsl : true,
            useSystemTrustStore : true,
            allowHostNameCNMismatch : true,
            allowSelfSignedServerCert : true
        }
    }
}
";
        [JsonSample]
        public const string PrestoLinkedService = @"
{
    name: ""PrestoLinkedService"",
    properties: {
        type: ""Presto"",
        typeProperties: {
            host : ""192.168.222.160"",
            serverVersion : ""0.148-t"",
            catalog : ""test"",
            authenticationType : ""Anonymous"",
            username : """",
            password : {
                type: ""SecureString"",
                value: ""some secret""
            },
            enableSsl : true,
            trustedCertPath : """",
            useSystemTrustStore : true,
            allowHostNameCNMismatch : true,
            allowSelfSignedServerCert : true
        }
    }
}
";
        [JsonSample]
        public const string QuickBooksLinkedService = @"
{
    name: ""QuickBooksLinkedService"",
    properties: {
        type: ""QuickBooks"",
        typeProperties: {
            endpoint : ""quickbooks.api.intuit.com"",
            companyId : ""fakeCompanyId"",
            consumerKey : ""fakeConsumerKey"",
            consumerSecret : {
                type : ""SecureString"",
                value : ""some secret""
            },
            accessToken : {
                type : ""SecureString"",
                value : ""some secret""
            },
            accessTokenSecret : {
                type : ""SecureString"",
                value : ""some secret""
            },
            useEncryptedEndpoints : true
        }
    }
}
";

        [JsonSample]
        public const string QuickBooksConnectionPropertiesLinkedService = @"
{
	name: ""QuickBooksLinkedService "",
	properties: {
		type: ""QuickBooks"",
		typeProperties: {
			connectionProperties: {
				endpoint: ""quickbooks.api.intuit.com"",
				companyId: ""fakeCompanyId"",
				consumerKey: ""fakeConsumerKey"",
				consumerSecret: {
					type: ""SecureString"",
					value: ""some secret""
				},
				accessToken: {
					type: ""SecureString"",
					value: ""some secret""
				},
				accessTokenSecret: {
					type: ""SecureString"",
					value: ""some secret""
				},
				useEncryptedEndpoints: true
			}
		}
	}
}
";
        [JsonSample]
        public const string ServiceNowLinkedService = @"
{
    name: ""ServiceNowLinkedService"",
    properties: {
        type: ""ServiceNow"",
        typeProperties: {
            endpoint : ""http://instance.service-now.com"",
            authenticationType : ""Basic"",
            username : ""admin"",
            password : {
                type : ""SecureString"",
                value : ""some secret""
            }
        }
    }
}
";
        [JsonSample]
        public const string ShopifyLinkedService = @"
{
    name: ""ShopifyLinkedService"",
    properties: {
        type: ""Shopify"",
        typeProperties: {
            host : ""mystore.myshopify.com"",
            accessToken : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";
        [JsonSample]
        public const string SparkLinkedService = @"
{
    name: ""SparkLinkedService"",
    properties: {
        type: ""Spark"",
        typeProperties: {
            host : ""myserver"",
            port : 443,
            serverType : ""SharkServer"",
            thriftTransportProtocol : ""Binary"",
            authenticationType : ""WindowsAzureHDInsightService"",
            username : ""admin"",
            password : {
                type: ""AzureKeyVaultSecret"",
                secretName: ""SparkPassword"",
                store: {
                    type: ""LinkedServiceReference"",
                    referenceName: ""AKVLinkedService""
                }
            },
            httpPath : ""gateway/sandbox/spark"",
            enableSsl : true,
            useSystemTrustStore : true,
            allowHostNameCNMismatch : true,
            allowSelfSignedServerCert : true
        }
    }
}
";
        [JsonSample]
        public const string SquareLinkedService = @"
{
    name: ""SquareLinkedService"",
    properties: {
        type: ""Square"",
        typeProperties: {
            host : ""mystore.mysquare.com"",
            clientId : ""clientIdFake"",
            clientSecret : {
                type: ""SecureString"",
                value: ""some secret""
            },
            redirectUri : ""http://localhost:2500"",
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";
        [JsonSample]
        public const string SquareConnectionPropertiesLinkedService = @"
{
	name: ""SquareLinkedService"",
	properties: {
		type: ""Square"",
		typeProperties: {
			connectionProperties: {
				host: ""mystore.mysquare.com"",
				clientId: ""clientIdFake"",
				clientSecret: {
					type: ""SecureString"",
					value: ""some secret""
				},
				redirectUri: ""http://localhost:2500"",
				useEncryptedEndpoints: true,
				useHostVerification: true,
				usePeerVerification: true
			}
		}
	}
}
";

        [JsonSample]
        public const string XeroLinkedService = @"
{
    name: ""XeroLinkedService"",
    properties: {
        type: ""Xero"",
        typeProperties: {
            host : ""api.xero.com"",
            consumerKey : {
                type: ""SecureString"",
                value: ""some secret""
            },
            privateKey : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";

        [JsonSample]
        public const string XeroConnectionPropertiesLinkedService = @"
{
	name: ""XeroLinkedService"",
	properties: {
		type: ""Xero"",
		typeProperties: {
			connectionProperties: {
				host: ""api.xero.com"",
				consumerKey: {
					type: ""SecureString"",
					value: ""some secret""
				},
				privateKey: {
					type: ""SecureString"",
					value: ""some secret""
				},
				useEncryptedEndpoints: true,
				useHostVerification: true,
				usePeerVerification: true
			}
		}
	}
}
";

        [JsonSample]
        public const string ZohoLinkedService = @"
{
    name: ""ZohoLinkedService"",
    properties: {
        type: ""Zoho"",
        typeProperties: {
            endpoint : ""crm.zoho.com/crm/private"",
            accessToken : {
                type: ""SecureString"",
                value: ""some secret""
            },
            useEncryptedEndpoints : true,
            useHostVerification : true,
            usePeerVerification : true
        }
    }
}
";

        [JsonSample]
        public const string ZohoConnectionPropertiesLinkedService = @"
{
	name: ""ZohoLinkedService"",
	properties: {
		type: ""Zoho"",
		typeProperties: {
			connectionProperties: {
				endpoint: ""crm.zoho.com/crm/private"",
				accessToken: {
					type: ""SecureString"",
					value: ""some secret""
				},
				useEncryptedEndpoints: true,
				useHostVerification: true,
				usePeerVerification: true
			}
		}
	}
}
";

        [JsonSample]
        public const string NetezzaLinkedService = @"
{
    name: ""NetezzaLinkedService"",
    properties: {
        type: ""Netezza"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            }
        }
    }
}
";
        [JsonSample]
        public const string NetezzaLinkedServiceWithPwdInAKV = @"
{
    name: ""NetezzaLinkedServiceWithPwdInAKV"",
    properties: {
        type: ""Netezza"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            },
            pwd: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string VerticaLinkedService = @"
{
    name: ""VerticaLinkedService"",
    properties: {
        type: ""Vertica"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            }
        }
    }
}
";
        [JsonSample]
        public const string VerticaLinkedServiceWithPwdInAKV = @"
{
    name: ""VerticaLinkedServiceWithPwdInAKV"",
    properties: {
        type: ""Vertica"",
        typeProperties: {
            connectionString: {
                type: ""SecureString"",
                value: ""some connection string""
            },
            pwd: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string DatabricksLinkedService = @"
{
    name: ""DatabricksLinkedService"",
    properties: {
        type: ""AzureDatabricks"",
        typeProperties: {
            domain: ""https://westeurope.azuredatabricks.net/"",
            accessToken:  {
                type: ""SecureString"",
                value: ""someKey""
            },
            existingClusterId: ""1215-091927-stems91""
        }
    }
}
";
        [JsonSample]
        public const string DatabricksLinkedServiceWithNewCluster = @"
{
    name: ""DatabricksLinkedService"",
    properties: {
        type: ""AzureDatabricks"",
        typeProperties: {
            domain: ""https://westeurope.azuredatabricks.net/"",
            accessToken: {
                type: ""SecureString"",
                value: ""someKey""
            },
            newClusterVersion: ""3.4.x-scala2.11"",
            newClusterNumOfWorker: ""1"",
            newClusterNodeType: ""Standard_DS3_v2"",
            newClusterDriverNodeType: ""Standard_DS3_v2"",
            newClusterLogDestination: ""dbfs:/test"",
            newClusterInitScripts: [
                ""someScript""
            ],
            newClusterEnableElasticDisk: true,
            newClusterSparkConf: {
                ""spark.speculation"": true
            }
        }
    }
}
";
        [JsonSample]
        public const string DatabricksLinkedServiceWithNewClusterPy3 = @"
{
    name: ""DatabricksLinkedService"",
    properties: {
        type: ""AzureDatabricks"",
        typeProperties: {
            domain: ""https://westeurope.azuredatabricks.net/"",
            accessToken: {
                type: ""SecureString"",
                value: ""someKey""
            },
            newClusterVersion: ""3.4.x-scala2.11"",
            newClusterNumOfWorker: ""1"",
            newClusterNodeType: ""Standard_DS3_v2"",
            newClusterSparkConf: {
                ""spark.speculation"": true
            },
            newClusterSparkEnvVars: {
                ""PYSPARK_PYTHON"": ""/databricks/python3/bin/python3""
            }
        }
    }
}
";
        [JsonSample]
        public const string MySqlLinkedService = @"
{
    name: ""MySqlLinkedService"",
    properties: {
        type: ""MySql"",
        typeProperties: {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            }
        }
    }
}
";
        [JsonSample]
        public const string MySqlLinkedServiceWithPasswordInAKV = @"
{
    name: ""MySqlLinkedServiceWithPasswordInAKV"",
    properties: {
        type: ""MySql"",
        typeProperties: {
            connectionString: {
                type : ""fakeConnString"",
                value : ""SecureString""
            },
            password: { 
                type: ""AzureKeyVaultSecret"", 
                secretName: ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string PostgreSqlLinkedService = @"
{
    name: ""PostgreSqlLinkedService"",
    properties: {
        type: ""PostgreSql"",
        typeProperties: {
            connectionString: {
                type : ""fakeConnString"",
                value : ""SecureString""
            }
        }
    }
}
";
        [JsonSample]
        public const string PostgreSqlLinkedServiceWithPasswordInAKV = @"
{
    name: ""PostgreSqlLinkedServiceWithPasswordInAKV"",
    properties: {
        type: ""PostgreSql"",
        typeProperties: {
            connectionString: {
                type : ""fakeConnString"",
                value : ""SecureString""
            },
            password: { 
                type: ""AzureKeyVaultSecret"", 
                secretName: ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}
";
        [JsonSample]
        public const string Db2LinkedService = @"
{
    name: ""Db2LinkedService"",
    properties:
    {
        type: ""Db2"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            server : ""fakeServer"",
            database : ""fakeDatabase"",
            authenticationType : ""Basic"",
            username : ""fakeUsername"",
            password : {
                type : ""SecureString"",
                value : ""some password""
            },
            packageCollection : ""fakepackageCollection"",
            certificateCommonName : ""fakecertificateCommonName""
        }
    }
}";

        [JsonSample]
        public const string Db2LinkedServiceWithConnectionString = @"
{
    name: ""Db2LinkedService"",
    properties:
    {
        type: ""Db2"",
        connectVia: {
            referenceName : ""MSourceDemoIR"",
            type : ""IntegrationRuntimeReference""
        },
        typeProperties: {
            connectionString : ""Server=<server>;Database=<database>;AuthenticationType=Basic;UserName=<username>;PackageCollection=<packageCollection>;CertificateCommonName=<certificateCommonName>""
        }
    }
}";

        [JsonSample]
        public const string SapOpenHubLinkedService = @"
{
    ""name"": ""SapBwOpenHubLinkedService"",
    ""properties"": {
        ""type"": ""SapOpenHub"",
        ""typeProperties"": {
            ""server"": ""fakeserver"",
            ""systemNumber"": ""00"",
            ""clientId"": ""800"",
            ""userName"": ""fakeusr"",
            ""password"": {
                ""type"": ""SecureString"",
                ""value"": ""fakepsw""
            }
        }
    }
}";

        [JsonSample]
        public const string SapOpenHubWithMessageServerLinkedService = @"
{
    ""name"": ""SapBwOpenHubLinkedService"",
    ""properties"": {
        ""type"": ""SapOpenHub"",
        ""typeProperties"": {
            ""messageServer"": ""fakeserver"",
            ""messageServerService"": ""00"",
            ""systemId"": ""ecc"",
            ""logonGroup"": ""fakegp"",
            ""clientId"": ""800"",
            ""userName"": ""fakeusr"",
            ""password"": {
                ""type"": ""SecureString"",
                ""value"": ""fakepsw""
            }
        }
    }
}";

        [JsonSample]
        public const string RestLinkedService = @"
{
    ""name"": ""RESTLinkedService"",
    ""properties"": {
        ""type"": ""RestService"",
        ""typeProperties"": {
            ""authenticationType"": ""Basic"",
            ""url"" : ""https://fakeurl/"",
            ""userName"": ""fakeusr"",
            ""password"": {
                ""type"": ""SecureString"",
                ""value"": ""fakepsw""
            },
            ""azureCloudType"": ""AzurePublic""
        }
    }
}";

        [JsonSample]
        public const string SapTableLinkedService = @"
{
    ""name"": ""SapTableLinkedService"",
    ""properties"": {
        ""type"": ""SapTable"",
        ""typeProperties"": {
            ""server"": ""fakeserver"",
            ""systemNumber"" : ""00"",
            ""clientId"" : ""000"",
            ""userName"": ""fakeusr"",
            ""password"": {
                ""type"": ""SecureString"",
                ""value"": ""fakepsw""
            }
        }
    }
}";

        [JsonSample]
        public const string AzureDataExplorerLinkedService = @"
{
    ""name"": ""AzureDataExplorerLinkedService"",
    ""properties"": {
        ""type"": ""AzureDataExplorer"",
        ""typeProperties"": {
            ""endpoint"": ""https://fakecluster.eastus2.kusto.windows.net"",
            ""servicePrincipalId"": ""fakeSPID"",
            ""servicePrincipalKey"": {
                ""value"": ""fakeSPKey"",
                ""type"": ""SecureString""
            },
            ""database"": ""MyDatabase"",
            ""tenant"": ""fakeTenant""
        }
    }
}";

        [JsonSample]
        public const string AzureFileStorageLinkedService = @"
{
    name: ""AzureFileStorageLinkedService"",
    properties:
    {
        type: ""AzureFileStorage"",
        description: ""test description"",
        typeProperties:
        {
            host : ""fakehost"",
            userId : ""fakeaccess"",
            password : {
                value : ""fakeKey"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string AzureFileStorageLinkedServiceWithConnectionString = @"
{
    name: ""AzureFileStorageLinkedServiceWithConnectionString"",
    properties:
    {
        type: ""AzureFileStorage"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
        }
    }
}";

        [JsonSample]
        public const string AzureFileStorageLinkedServiceWithConnectionStringWithAccountKey = @"
{
    name: ""AzureFileStorageLinkedServiceWithConnectionString"",
    properties:
    {
        type: ""AzureFileStorage"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            fileShare: ""myFileShareName"",
            snapshot: ""2020-06-18T02:35.43""
        }
}
}";

        [JsonSample]
        public const string AzureFileStorageLinkedServiceWithConnectionStringAndAccountKeyInAKV = @"
{
    name: ""AzureFileStorageLinkedServiceWithConnectionStringAndAccountKeyInAKV"",
    properties:
    {
        type: ""AzureFileStorage"",
        typeProperties:
        {
            connectionString: {
                value : ""fakeConnString"",
                type : ""SecureString""
            },
            accountKey: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string AzureFileStorageLinkedServiceWithSasUri = @"
{
    name: ""AzureFileStorageLinkedServiceWithSasUri"",
    properties:
    {
        type: ""AzureFileStorage"",
        typeProperties:
        {
            sasUri: {
                value : ""fakeSasUri"",
                type : ""SecureString""
            },
        }
    }
}";

        [JsonSample]
        public const string AzureFileStorageLinkedServiceWithSasUriAndSasTokenInAKV = @"
{
    name: ""AzureFileStorageLinkedServiceWithSasUriAndSasTokenInAKV"",
    properties:
    {
        type: ""AzureFileStorage"",
        typeProperties:
        {
            sasUri: {
                value : ""fakeSasUri"",
                type : ""SecureString""
            },
            sasToken: { 
                type : ""AzureKeyVaultSecret"", 
                secretName : ""fakeSecretName"", 
                store: { 
                    type : ""LinkedServiceReference"", 
                    referenceName : ""AKVLinkedService"" 
                } 
            }
        }
    }
}";

        [JsonSample]
        public const string GoogleCloudStorageLinkedService = @"
{
    name: ""GoogleCloudStorageLinkedService"",
    properties:
    {
        type: ""GoogleCloudStorage"",
        description: ""test description"",
        typeProperties:
        {
            accessKeyId : ""fakeaccess"",
            secretAccessKey : {
                value : ""fakeKey"",
                type : ""SecureString""
            }
        }
    }
}";

        [JsonSample]
        public const string SharePointOnlineListLinkedService = @"
{
    name: ""LinkedService-SharePointOnlineList"",
    properties:
    {
        type: ""SharePointOnlineList"",
        description: ""test description"",
        typeProperties:
        {
            siteUrl : ""http://localhost/webhdfs/v1/"",
            tenantId: ""tenantId"",
            servicePrincipalId: ""servicePrincipalId"",
            servicePrincipalKey : {
                value : ""servicePrincipalKey"",
                type : ""SecureString""
            }
        }
    }
}";
    }
}
