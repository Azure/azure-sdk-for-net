﻿// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace DataFactory.Tests.Framework.JsonSamples
{
    /// <summary>
    /// Contains InternalLinkedService JSON samples. Samples added here will automatically be hit by the serialization unit tests. 
    /// </summary>
    public class LinkedServiceJsonSamples : JsonSampleCollection<LinkedServiceJsonSamples>
    {
        [JsonSample]
        public const string HDInsightBYOCLinkedService = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsight"",
        hubName: ""testHub"",
        typeProperties:
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName""
        }
    }
}
";

        [JsonSample]
        public const string HDInsightOnDemandLinkedService = @"
{
    name: ""Test-on-demand-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsightOnDemand"",
        hubName: ""hubName"",
        typeProperties:
        {
            version: ""1.1"",
            clusterSize: 10,
            timeToLive: ""05:00:00"",
            linkedServiceName: ""MyStorageAssetName"",
            hiveCustomLibrariesContainer: ""myhivelibs""
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
        hubName: ""testHub"",
        typeProperties:
        {
            connectionString: ""MyConnectionString""
        }
    }
}";

        [JsonSample]
        public const string AzureStorageSasLinkedService = @"
{
    name: ""Test-Windows-Azure-storage-Sas-linkedService"",
    properties:
    {
        type: ""AzureStorageSas"",
        hubName: ""testHub"",
        typeProperties:
        {
            sasUri: ""SasUri""
        }
    }
}";

        [JsonSample]
        public const string HDISLinkedService = @"
{
    name: ""Test-HDIS-LinkedService"",
    properties:
    {
        type: ""OnPremisesSqlServer"",
        hubName: ""testHub"",
        typeProperties:
        {
            connectionString: ""MyConnectionString"",
            gatewayName: ""Connection1"",
            userName: ""WindowsAuthUserName"",
            password: ""WindowsAuthPassword""
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
        hubName: ""testHub"",
        typeProperties:
        {
            connectionString: ""MyConnectionString"",
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
        hubName: ""testHub"",
        typeProperties:
        {
            connectionString: ""MyConnectionString"",
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
        hubName: ""testHub"",
        typeProperties:
        {
            mlEndpoint:""https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs"",
            apiKey:""jOeOfV4/ujgUvU5DB5cC+poDvHmHE/g==""
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
        hubName: ""testHub"",
        typeProperties:
        {
            mlEndpoint:""https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs"",
            apiKey:""jOeOfV4/ujgUvU5DB5cC+poDvHmHE/g=="",
            updateResourceEndpoint:""https://management.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/endpoints/endpoint2""
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
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName""
        }
    }
}
";

//        [JsonSample("ExtraProperties")]
//        public const string ExtraPropertiesLinkedService = @"
//{
//    name: ""Test-ML-LinkedService"",
//    properties:
//    {
//        type: ""AzureMLLinkedService"",
//        typeProperties:
//        {
//            mlEndpoint:""https://service.azureml.net/"",
//            apiKey:""testApiKey"", 
//            extraProperty1: ""value1"",
//            extraProperty2: {
//                subProp1: 5, 
//                subProp2: ""subValue2""
//            }
//        }
//    }
//}";

        [JsonSample]
        public const string HDInsightBYOCWithHCatalogLinkedService = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsight"",
        hubName: ""testHub"",
        typeProperties: 
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName"",
		    hcatalogLinkedServiceName : ""Asset-HcatDb"",
		    schemaGeneration:
		    {
			    type : ""Output"",
			    inputPartition : ""None"",
			    alterSchema : false
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
        hubName: ""hubName"",
        typeProperties: {
            accountName: ""myaccount"",
            batchUri: ""myaccount.region.batch.windows.com"",
            accessKey: ""accessKey"",
            poolName: ""MyAzureBatchPool"",
            linkedServiceName: ""MyStorageAssetName""
        }
    }
}";

                [JsonSample] 
        public const string OnPremisesSqlLinkedService = @"
{
    name: ""LinkedService-OnPremisesSQLDB"",
    properties:
    {
        type: ""OnPremisesSqlServer"",
        typeProperties: {
            connectionString: ""MyConnectionString"",
            gatewayName: ""CherryAgent-01"",
            userName: ""MyUserName"",
            password: ""MyPassword""
        }
    }
}";

        [JsonSample]
        public const string OnPremisesOracleLinkedService = @"
{
    name: ""LinkedService-OnPremisesOracleDB"",
    properties:
    {
        type: ""OnPremisesOracle"",
        typeProperties: {
            connectionString: ""MyConnectionString"",
            gatewayName: ""CherryAgent-01"",
            userName: ""MyUserName"",
            password: ""MyPassword""
        }
    }
}";

        [JsonSample]
        public const string OnPremisesFileSystemLinkedService = @"
{
    name: ""LinkedService-OnPremisesFileSystem"",
    properties:
    {
        type: ""OnPremisesFileServer"",
        typeProperties: {
            host: ""Myhost"",
            gatewayName: ""CherryAgent-01"",
            userId: ""MyUserId"",
            password: ""MyPassword"",
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

        [JsonSample]
        public const string DocDbLinkedService = @"
{
    name: ""LinkedService-DocDb"",
    properties:
    {
        type: ""DocumentDb"",
        typeProperties: {
            connectionString: ""MyConnectionString""
        }
    }
}";

        [JsonSample]
        public const string TeradataLinkedService = @"
{
    name: ""Test-Teradata-linkedService"",
    properties:
    {
        type: ""OnPremisesTeradata"",
        typeProperties: {
            server: ""volvo2.teradata.ws"",
            username: ""microsoft"",
            password: ""fakepassword"",
            gatewayName: ""MSourceDemoGateway"",
            authenticationType: ""Basic""
        }
    }
}";

        [JsonSample]
        public const string AzureDataLakeStoreLinkedService = @"
{
    name: ""LinkedService-AzureDataLakeStore"",
    properties:
    {
        type: ""AzureDataLakeStore"",
        typeProperties:
        {
            authorization: ""authCode"",
            sessionId: ""sessionId"",
            dataLakeStoreUri: ""https://account.azuredatalake.net/webhdfs/v1"",
            accountName: ""account"",
            subscriptionId: ""subId"",
            resourceGroupName:  ""resourceGroup""
        },
        description: ""test description""
    }
}";

        [JsonSample]
        public const string AzureDataLakeAnalyticsLinkedService = @"
{
    name: ""LinkedService-AzureDataLakeAnalytics"",
    properties:
    {
        type: ""AzureDataLakeAnalytics"",
        description: ""test description"",
        typeProperties:
        {
            authorization: ""authCode"",
            sessionId: ""sessionId"",
            accountName: ""account"",
            dataLakeAnalyticsUri: ""microsoftkonacompute.net"",
            subscriptionId: ""subId"",
            resourceGroupName:  ""resourceGroup""
        }
    }
}";

        [JsonSample]
        public const string OdbcLinkedService = @"
{
    name: ""Test-ODBC-linkedService"",
    properties:
    {
        type: ""OnPremisesOdbc"",
        typeProperties: {
            connectionString: ""driver={SQL Server};server=myserver;database=mydb;"",

            credential: ""uid=myuid;pwd=PLACEHOLDER"",
            username: ""microsoft"",
            password: ""fakepassword"",
            gatewayName: ""MSourceDemoGateway"",
            authenticationType: ""Basic""
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
        typeProperties: {
            url: ""http://myhost:50070/webhdfs/v1"",
            username: ""microsoft"",
            password: ""fakepassword"",
            gatewayName: ""MSourceDemoGateway"",
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
            password : ""fakepassword""
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
            password: ""fakepassword""   
        }
    }
}";
        [JsonSample]
        public const string OnPremisesCassandraLinkedService = @"
{
    name: ""LinkedService-OnPremisesCassandra"",
    properties:
    {
        type: ""OnPremisesCassandra"",
        description: ""test description"",
        typeProperties:
        {
            authenticationType: ""Basic"",
            host : ""http://localhost/webhdfs/v1/"", 
            port : 1234,
            username: ""admin"",
            password : ""fakepassword"",
            gatewayName : ""fakegateway"",
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
            userName: ""admin"",
            password : ""fakepassword"",
            securityToken: ""fakeToken""
        }
    }
}";

        [JsonSample]
        public const string MongoDbLinkedService = @"
{
    name: ""OnPremisesMongoDbLinkedService"",
    properties:
    {
        type: ""OnPremisesMongoDb"",
        description: ""test description"",
        typeProperties:
        {
            authenticationType: ""Basic"",
            server : ""fakeserver.com"", 
            port : 666,
            username: ""fakeuser"",
            password : ""fakepwd"",
            authSource : ""fackadmindb"",
            databaseName : ""fakedb"",
            gatewayName : ""fakegw"",
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
            password : ""fakepassword"",
            database : ""fakedatabase""
        }
    }
}";

        [JsonSample]
        public const string AwsAccessKeyLinkedService = @"
{
    name: ""AwsAccessKeyLinkedService"",
    properties:
    {
        type: ""AwsAccessKey"",
        description: ""test description"",
        typeProperties:
        {
            accessKeyId : ""fakeaccess"",
            secretAccessKey : ""fakesecret""
        }
    }
}";
    }
}
