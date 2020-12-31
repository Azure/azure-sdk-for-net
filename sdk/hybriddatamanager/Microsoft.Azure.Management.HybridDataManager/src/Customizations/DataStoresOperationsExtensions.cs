namespace Microsoft.Azure.Management.HybridData
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Text;
    using System.Security.Cryptography;
    //using System.Security.Cryptography.X509Certificates;
    /// <summary>
    /// Extension methods for DataStoresOperations.
    /// </summary>
    public static partial class DataStoresOperationsExtensions
    {

        #region StorSimple Helpers
        public static DataStore CreateStorSimpleDataStore(this IDataStoresOperations operations, string subscriptionIdOfDataManager,
            string subscriptionIdOfStorSimpleDevice, string resourceGroupOfDataManager, 
            string resourceGroupOfStorSimpleDevice, string dataManagerName,
            string serviceEncryptionKey, string storSimpleResourceName, HybridDataManagementClient client)
        {
            var storSimpleDataStore = new DataStore();
            var publicKey = client.PublicKeys.ListByDataManager(resourceGroupOfDataManager, dataManagerName).FirstOrDefault();
            storSimpleDataStore.State = State.Enabled;

            storSimpleDataStore.CustomerSecrets = EncryptStorSimpleCustomerSecrets(serviceEncryptionKey, publicKey);

            storSimpleDataStore.DataStoreTypeId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.HybridData"
                + "/dataManagers/{2}/dataStoreTypes/StorSimple8000Series",
                subscriptionIdOfDataManager, resourceGroupOfDataManager, dataManagerName);

            storSimpleDataStore.RepositoryId = $"/subscriptions/{subscriptionIdOfStorSimpleDevice}/resourceGroups/{resourceGroupOfStorSimpleDevice}"
                +$"/providers/Microsoft.StorSimple/managers/{storSimpleResourceName}";

            storSimpleDataStore.ExtendedProperties = GetStorSimpleExtendedProperties(storSimpleDataStore.RepositoryId);

            return storSimpleDataStore;
        }

        private static object GetStorSimpleExtendedProperties(string repositoryId)
        {
            JToken extendedPropertiesJToken = new JObject();
            extendedPropertiesJToken["resourceId"] = repositoryId;
            extendedPropertiesJToken["extendedSaKey"] = null;
            return extendedPropertiesJToken;
        }

        private static IList<CustomerSecret> EncryptStorSimpleCustomerSecrets(string serviceEncryptionKey, PublicKey publicKey)
        {
            var customerSecrets = new List<CustomerSecret>();
            customerSecrets.Add(new CustomerSecret(keyIdentifier: "ServiceEncryptionKey",
                keyValue: GetEncryptedSecret(publicKey, serviceEncryptionKey, SupportedAlgorithm.RSA15),
                //keyValue: "i4aW4iJ8xn / a / 2aT8s3rD3IZU9FMOGHcK0fpRkI1AEqeIs7 / 8hjPFOhrsvCeriA0DjMawKbUhq335o7E1hSBM6dA7AuNXaePnksrIvQtpZCr / A8o9R4CEDrEfMeiq9wEz + ENSOj6dIaN84ptmHDMHLIB1QmGFubuGAcxVS7R6LQ30SufAlv7aJIzQ9 + mJu6BF5e8BjVxb2QdyGVI + 57fm3lLZSnpzmBFxYRgOvROr5nEejdJXDzqYmsYbgS0Oswpjp / gR2 + 6tcx3lOXlCk7TSXprrdSlUgqNuGW7d4tvYsQ + oKMVFaoKJwa6lTgQ20 / KdsB + kzapXiv28BiLw0EO8g ==:U2VCaO38mHkRsUlBmB8F1UXxEyrsfD8F5edqlp + 3yCR01bDJjZaXTIKRfe4Z2DM9jKyGCxCyS9m + Tq7eun + nWoncvfaD5Q13qz2Vk9Iz771vSPItzn1eZeC8TT2AAg4AYb6uvNTWlbY9yrtbyoYHAVV6MmtkJufY6n7zZ7YRcQF / itQ1LGL / lB8cCqcLok0FbUAMItwIzfW + lFAwfeD6KcQQUvd / iTFBzg3Ji3nRf5wb1y / gw7LUQy7xstklakljxXpOHQBB10IlQoQRYVbRoiI4zLXuneas0wPmeGxdHlCvqkr + MQIupD8GRjQll2CIGEbWURfLtNKrHpXu7Dd3vg ==",
                //keyValue: "dau5RXYUsHncI65yt+pHKQfXUivOzJCYVwfePzfqA34Iae2Nqfm93ta9iM3s5dkC6m2L+dx1lFC4mnVtlqKZLyxifHc04zQl6fX1Y6xyXeJRKVCcZj273k5/shDQO94Lw0ysS/+qDDuzWygnxMRWeIok9aR6sY6XGi1VGFtdmFlpBgJ+tMnAereVV9vGR+j425O+QM0cJQeYkVsJUEa/1LUuuhy351LXo4y47YtYuxYhXGwXW2swwWdN1+0PZh5NXisGlD82ngKevTx5YZ+1C9gd99IdgFnWFAk5hwktBw7DrZpoVOXbrfxD1h2Q5ncmiAy1J1YURfmFG+qCnDGIrA==:DAej4jqDj3APhy5r/Hg1JLa1THYh1cuNsXzWAnHSDyMAnTi1Lc0OYAZg5pZJQtQva2reLaH9BqmlwYCjJrnqqZ8BFjtWCbN9vfEetU1bOkhBcHsPtd/x6B9F0i2CiUAThHDgAdZ+PftWlMs6OPLQvB0L43QjlPxJf/igFo19ZCwmH99x7fHZw0+bi+zj0/dIB+BPDx9I8yEyDh3CxtbNMvsCYb4XU6Vp6xzTTGks3ztWxUZy1iO8LH2/P8Fk4Bw/PL4pG1gOm7mYavjE+02sSRyOda+oRF3xrpsxyudtz8yADQdfc/CwZIHTD39kHrAARy9tSDHpTFuAZz2Gt7U+OQ==",
                algorithm: SupportedAlgorithm.RSA15));

            return customerSecrets;
        }

        #endregion

        #region Azure Storage Helpers

        public static DataStore CreateAzureStorageDataStore(this IDataStoresOperations operations, string subscriptionIdOfDataManager,
            string subscriptionIdOfStorageAccount, string resourceGroupOfDataManager,
            string resourceGroupOfStorageAccount, string dataManagerName,
            string storageAccountKey, string azureStorageName, HybridDataManagementClient client)
        {
            var azureStorageDataStore = new DataStore();
            var publicKey = client.PublicKeys.ListByDataManager(resourceGroupOfDataManager, dataManagerName).FirstOrDefault();
            azureStorageDataStore.State = State.Enabled;

            azureStorageDataStore.CustomerSecrets = EncryptAzureStorageCustomerSecrets(storageAccountKey, publicKey);

            azureStorageDataStore.DataStoreTypeId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.HybridData"
                + "/dataManagers/{2}/dataStoreTypes/AzureStorageAccount",
                subscriptionIdOfDataManager, resourceGroupOfDataManager, dataManagerName);

            azureStorageDataStore.RepositoryId = $"/subscriptions/{subscriptionIdOfStorageAccount}/resourceGroups/{resourceGroupOfStorageAccount}"
                + $"/providers/Microsoft.Storage/storageAccounts/{azureStorageName}";

            azureStorageDataStore.ExtendedProperties = GetAzureStorageExtendedProperties(azureStorageDataStore.RepositoryId);

            return azureStorageDataStore;
        }


        private static IList<CustomerSecret> EncryptAzureStorageCustomerSecrets(string storageAccountKey, PublicKey publicKey)
        {
            var customerSecrets = new List<CustomerSecret>();
            var keyValue = GetEncryptedSecret(publicKey, storageAccountKey, SupportedAlgorithm.RSA15);
            //var keyValue = "kxEP6ck0YetBu1RLCyj80QP2bgc713aRgzs4gtVBY4HE/jNzfWYO3aydui05LcVIqe2EX0+8Aug7S+cZLcq706W9lBTlp/v+VFyGto7pT+fiMr4banBhg8UMxz5p5ScL0B5fszGje5Wx2c/r1k2I/ycKRSZi7IURNR6en5lEjnlFsJK83ZFl9HEXcrThCi48yN8Yi5NV7jrCeQR1S7Og/ioTgrjxacHUM1ZqMtSPsDLASkMMSo+Nhs3krzjRHxpnwpjWvKbXvo7ii7GPdXnNusI0f4VD3o4u/V4GDMpr+s2Eb8ZQ7Fj50YSkIVpUp7kAOTUUiMQHLARSX8G5Db9jpg==:cDuQ2dCCwNpz6LZSJsb8T7EqzJfiJh6Hh3+hE9auLXFnkN2ajIct8HcsnU1C0cE3I+56/z8df158btHhcODBJ5xG+mNPdUvmyVYLmepWT9spL/6PeIkH8G94ZCtMg/TRi3nTwu/mH5Kx6mfibf8Di3UixPO5IjFvnGaJJkWaHNAuo1o4zTPRPJHcSFgxCFMgaaUDNW6gO+FiPWFoFD5ND6bHGxTJ6HqtWTQ9ejXi7dplfxvnQ3lwyoFNBfh2QSsSomspFP9iLu5zr4U+FtA1C02COSCf20Rd1VQrnKufB33y8D+PVBYVg6kI+Ao/Xbz9LFum8KzXTKZV/xSLnJ5Z9A==";
            customerSecrets.Add(new CustomerSecret(keyIdentifier: "StorageAccountAccessKey",
                keyValue: keyValue,
                algorithm: SupportedAlgorithm.RSA15));
            customerSecrets.Add(new CustomerSecret(keyIdentifier: "StorageAccountAccessKeyForQueue",
                keyValue: keyValue,
                algorithm: SupportedAlgorithm.RSA15));
            return customerSecrets;

        }

        private static object GetAzureStorageExtendedProperties(string repositoryId)
        {
            JToken extendedPropertiesJToken = new JObject();
            extendedPropertiesJToken["storageAccountNameForQueue"] = repositoryId;
            extendedPropertiesJToken["extendedSaName"] = repositoryId;
            extendedPropertiesJToken["extendedSaKey"] = null;
            return extendedPropertiesJToken;
        }

        #endregion

        #region Encryption Helpers
        private static string GetEncryptedSecret(PublicKey publicKeys, string dataToEncrypt, SupportedAlgorithm algorithm)
        {
            string l1KModulus = publicKeys.DataServiceLevel1Key.KeyModulus;
            string l1KExponent = publicKeys.DataServiceLevel1Key.KeyExponent;
            string l2KModulus = publicKeys.DataServiceLevel2Key.KeyModulus;
            string l2KExponent = publicKeys.DataServiceLevel2Key.KeyExponent;

            byte[] level1KeyModulus = Convert.FromBase64String(l1KModulus);
            byte[] level1KeyExponent = Convert.FromBase64String(l1KExponent);

            byte[] dataToEncryptByte = Encoding.UTF8.GetBytes(dataToEncrypt);

            int key1ChunkSize = publicKeys.DataServiceLevel1Key.EncryptionChunkSizeInBytes;
            int key2ChunkSize = publicKeys.DataServiceLevel2Key.EncryptionChunkSizeInBytes;

            string firstPass = EncryptUsingJsonWebKey(dataToEncryptByte, key1ChunkSize,
                level1KeyModulus, level1KeyExponent, SupportedAlgorithm.RSAOAEP.Equals(algorithm));

            byte[] level2KeyModulus = Convert.FromBase64String(l2KModulus);
            byte[] level2KeyExponent = Convert.FromBase64String(l2KExponent);

            string encrytedData = EncryptUsingJsonWebKey(Encoding.UTF8.GetBytes(firstPass), key2ChunkSize,
                level2KeyModulus, level2KeyExponent, SupportedAlgorithm.RSAOAEP.Equals(algorithm));

            return encrytedData;
        }

        private static string EncryptUsingJsonWebKey(byte[] plainText, int chunkSize, byte[] n, byte[] e, bool doOAEPPadding)
        {
            int start = 0;
            StringBuilder builder = new StringBuilder();
            List<byte> plainTextList = plainText.ToList();
            int remainingBytes = plainText.Length;

            while (remainingBytes >= 1)
            {
                int chunkLength = remainingBytes > 214 ? 214 : remainingBytes;
                byte[] encryptedText = null;
                byte[] plainChunkText = plainTextList.GetRange(start, chunkLength).ToArray();
#if FullNetFx
                using (var rsa = new RSACryptoServiceProvider())
                {
                    var p = new RSAParameters() { Modulus = n, Exponent = e };
                    rsa.ImportParameters(p);
                    encryptedText = rsa.Encrypt(plainChunkText, doOAEPPadding);
                }
#else
                using (var rsa = RSA.Create())
                {
                    var p = new RSAParameters() { Modulus = n, Exponent = e };
                    rsa.ImportParameters(p);
                    encryptedText = rsa.Encrypt(plainChunkText, doOAEPPadding ? System.Security.Cryptography.RSAEncryptionPadding.OaepSHA1 
                        : System.Security.Cryptography.RSAEncryptionPadding.Pkcs1);
                }
#endif
                string encryptedSecret = Convert.ToBase64String(encryptedText);
                builder.Append(encryptedSecret);
                builder.Append(":");
                start += chunkLength;
                remainingBytes -= chunkLength;
            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
#endregion
    }
}
