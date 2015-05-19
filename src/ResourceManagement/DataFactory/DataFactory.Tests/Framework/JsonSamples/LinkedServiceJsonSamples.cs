// 
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
    public class LinkedServiceJsonSamples
    {
        [JsonSample]
        public const string HDInsightBYOCLinkedService = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsightBYOCLinkedService"",
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

#if ADF_INTERNAL
        [JsonSample(propertyBagKeys: new string[] 
            { 
                // Identify user-provided property names. These should always be cased exactly as the user 
                // specified, rather than converted to camel/Pascal-cased.
                "properties.extendedProperties.PropertyBagPropertyName1",
                "properties.extendedProperties.propertyBagPropertyName2"
            })]
        public const string AzureServiceBusLinkedService = @"
{
    name: ""LinkedService-AzureServiceBus"",
    properties:
    {
        type: ""AzureServiceBusLinkedService"",
        typeProperties:
        {
            endpoint: ""sb://azuredatafactory.servicebus.windows.net/"",
            sharedAccessKeyName : ""RootManageSharedAccessKey"",
            sharedAccessKey : ""FTTa0PM8="",
            activityQueueName: ""test1"",
            statusQueueName:  ""status1"",
            transportProtocolVersion: ""1.0-preview"",
            extendedProperties:
            {
                PropertyBagPropertyName1: ""PropertyBagPropertyValue1"",
                propertyBagPropertyName2: ""PropertyBagPropertyValue2""
            }
        }
    }
}";
#endif

        [JsonSample]
        public const string HDInsightOnDemandLinkedService = @"
{
    name: ""Test-on-demand-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsightOnDemandLinkedService"",
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
        type: ""AzureStorageLinkedService"",
        hubName: ""testHub"",
        typeProperties:
        {
            connectionString: ""MyConnectionString""
        }
    }
}";

        [JsonSample]
        public const string HDISLinkedService = @"
{
    name: ""Test-HDIS-LinkedService"",
    properties:
    {
        type: ""OnPremisesSqlLinkedService"",
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
        type: ""AzureSqlLinkedService"",
        hubName: ""testHub"",
        typeProperties:
        {
            connectionString: ""MyConnectionString"",
        }
    }
}";

#if ADF_INTERNAL
        [JsonSample]
        public const string MdsLinkedService = @"
{
    name: ""Test-MDS-LinkedService"",
    properties:
    {
        type: ""MdsLinkedService"",
        hubName: ""testHub"",
        typeProperties:
        {
            endpoint: ""MyEndpoint"",
            certificateBody: ""MyCertificateBody"",
            certificatePassword: ""MyCertificatePassword""
        }
    }
}";
#endif

        [JsonSample]
        public const string AzureMLLinkedServiceJson = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""AzureMLLinkedService"",
        hubName: ""testHub"",
        typeProperties:
        {
            mlEndpoint:""https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs"",
            apiKey:""jOeOfV4/ujgUvU5DB5cC+poDvHmHE/g==""
        }
    }
}";

        [JsonSample]
        public const string LinkedServiceOptionalHubName = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsightBYOCLinkedService"",
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

#if ADF_INTERNAL
        [JsonSample("ExtraProperties")]
        public const string ExtraPropertiesLinkedService = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""AzureMLLinkedService"",
        typeProperties:
        {
            mlEndpoint:""https://service.azureml.net/"",
            apiKey:""testApiKey"", 
            extraProperty1: ""value1"",
            extraProperty2: {
                subProp1: 5, 
                subProp2: ""subValue2""
            }
        }
    }
}";
#endif

        [JsonSample]
        public const string HDInsightBYOCWithHCatalogLinkedService = @"
{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsightBYOCLinkedService"",
        hubName: ""testHub"",
        typeProperties: 
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName"",
            hcatalog:
		    {
			    linkedServiceName : ""Asset-HcatDb"",
			    recoverPartitions : true
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
        type: ""AzureBatchLinkedService"",
        hubName: ""hubName"",
        typeProperties: {
            accountName: ""MyAzureBatchAccount"",
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
        type: ""OnPremisesSqlLinkedService"",
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
        type: ""OnPremisesOracleLinkedService"",
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
        type: ""OnPremisesFileSystemLinkedService"",
        typeProperties: {
            host: ""Myhost"",
            gatewayName: ""CherryAgent-01"",
            userId: ""MyUserId"",
            password: ""MyPassword"",
            encryptedCredential: ""MyEncryptedCredentials""
        }
    }
}";

#if ADF_INTERNAL
        [JsonSample]
        public const string DocDbLinkedService = @"
{
    name: ""LinkedService-DocDb"",
    properties:
    {
        type: ""DocumentDbLinkedService"",
        typeProperties: {
            connectionString: ""MyConnectionString""
        }
    }
}";
#endif
    }
}
