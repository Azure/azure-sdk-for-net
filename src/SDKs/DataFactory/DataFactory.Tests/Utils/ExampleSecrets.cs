// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Newtonsoft.Json;

namespace DataFactory.Tests.Utils
{
    public class ExampleSecrets
    {
        // The constants are example values used when writing captured example json.
        // The properties are actual values used when capturing example json, read from a json config file.

        public const string ExampleTenantId = "12345678-1234-1234-1234-123456789abc";
        public const string ExampleClientId = "12345678-1234-1234-1234-123456789abc";
        public const string ExampleClientSecret = "examplePassword";
        public const string ExampleSubId = "12345678-1234-1234-1234-12345678abc";
        public const string ExampleResourceGroupName = "exampleResourceGroup";
        public const string ExampleFactoryName = "exampleFactoryName";
        public const string ExampleFactoryLocation = "East US";
        public const string ExampleStorageAccountName = "examplestorageaccount";
        public const string ExampleStorageAccountKey = "<storage key>";
        public const string ExampleBlobContainerName = "examplecontainer";

        [JsonProperty(PropertyName = "environment")]
        public string Environment { get; set; } // "prod", "test"
        [JsonProperty(PropertyName = "tenantId")]
        public string TenantId { get; set; }
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }
        [JsonProperty(PropertyName = "clientSecret")]
        public string ClientSecret { get; set; }
        [JsonProperty(PropertyName = "subId")]
        public string SubId { get; set; }
        [JsonProperty(PropertyName = "resourceGroupName")]
        public string ResourceGroupName { get; set; }
        [JsonProperty(PropertyName = "factoryName")]
        public string FactoryName { get; set; }
        [JsonProperty(PropertyName = "factoryLocation")]
        public string FactoryLocation { get; set; }
        [JsonProperty(PropertyName = "storageAccountName")]
        public string StorageAccountName { get; set; }
        [JsonProperty(PropertyName = "storageAccountKey")]
        public string StorageAccountKey { get; set; }
        [JsonProperty(PropertyName = "blobContainerName")]
        public string BlobContainerName { get; set; }
        [JsonProperty(PropertyName = "catalogServerEndpoint")]
        public string CatalogServerEndpoint { get; set; }
        [JsonProperty(PropertyName = "catalogAdminUsername")]
        public string CatalogAdminUsername { get; set; }
        [JsonProperty(PropertyName = "catalogAdminPassword")]
        public string CatalogAdminPassword { get; set; }

        public string ReplaceSecretsWithExampleStrings(string jsonActual)
        {
            string ret = jsonActual;
            ret = ReplaceOne(ret, TenantId, ExampleTenantId);
            ret = ReplaceOne(ret, ClientId, ExampleClientId);
            ret = ReplaceOne(ret, ClientSecret, ExampleClientSecret);
            ret = ReplaceOne(ret, SubId, ExampleSubId);
            ret = ReplaceOne(ret, ResourceGroupName, ExampleResourceGroupName);
            ret = ReplaceOne(ret, ResourceGroupName.ToLowerInvariant(), ExampleResourceGroupName.ToLowerInvariant());
            ret = ReplaceOne(ret, FactoryName, ExampleFactoryName);
            ret = ReplaceOne(ret, FactoryName.ToLowerInvariant(), ExampleFactoryName.ToLowerInvariant());
            ret = ReplaceOne(ret, FactoryLocation, ExampleFactoryLocation);
            ret = ReplaceOne(ret, FactoryLocation.ToLowerInvariant(), ExampleFactoryLocation.ToLowerInvariant());
            ret = ReplaceOne(ret, StorageAccountName, ExampleStorageAccountName);
            ret = ReplaceOne(ret, StorageAccountKey, ExampleStorageAccountKey);
            ret = ReplaceOne(ret, BlobContainerName, ExampleBlobContainerName);
            return ret;
        }

        private string ReplaceOne(string jsonIn, string actual, string example)
        {
            string ret = jsonIn;
            if (actual != null && !actual.Equals(example))
            {
                ret = jsonIn.Replace(actual, example);
            }
            return ret;
        }
    }
}
