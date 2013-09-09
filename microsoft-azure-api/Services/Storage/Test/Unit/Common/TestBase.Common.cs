// -----------------------------------------------------------------------------------------
// <copyright file="TestBase.Common.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;

#if WINDOWS_DESKTOP
using System.ServiceModel.Channels;
#endif

namespace Microsoft.WindowsAzure.Storage
{
    public partial class TestBase
    {
        private const AuthenticationScheme DefaultAuthenticationScheme = AuthenticationScheme.SharedKey;

        public static byte[] GetRandomBuffer(int size)
        {
            byte[] buffer = new byte[size];
            Random random = new Random();
            random.NextBytes(buffer);
            return buffer;
        }

#if WINDOWS_DESKTOP
        public static WCFBufferManagerAdapter BlobBufferManager = new WCFBufferManagerAdapter(BufferManager.CreateBufferManager(512 * (int)Constants.MB, 64 * (int)Constants.KB), 64 * (int)Constants.KB);

        public static WCFBufferManagerAdapter TableBufferManager = new WCFBufferManagerAdapter(BufferManager.CreateBufferManager(256 * (int)Constants.MB, 64 * (int)Constants.KB), 64 * (int)Constants.KB);

        public static WCFBufferManagerAdapter QueueBufferManager = new WCFBufferManagerAdapter(BufferManager.CreateBufferManager(64 * (int)Constants.MB, (int)Constants.KB), (int)Constants.KB);
#else
        public static MockBufferManager BlobBufferManager = new MockBufferManager(64 * (int)Constants.KB);

        public static MockBufferManager TableBufferManager = new MockBufferManager(64 * (int)Constants.KB);

        public static MockBufferManager QueueBufferManager = new MockBufferManager((int)Constants.KB);

#endif

        public static CloudTableClient GenerateCloudTableClient()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.TableServiceEndpoint);
            CloudTableClient client = new CloudTableClient(baseAddressUri, TestBase.StorageCredentials);
            client.AuthenticationScheme = DefaultAuthenticationScheme;

#if WINDOWS_DESKTOP
            client.BufferManager = BlobBufferManager;
#endif

            return client;
        }

        public static CloudBlobClient GenerateCloudBlobClient()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.BlobServiceEndpoint);
            CloudBlobClient client = new CloudBlobClient(baseAddressUri, TestBase.StorageCredentials);
            client.AuthenticationScheme = DefaultAuthenticationScheme;

#if WINDOWS_DESKTOP
            client.BufferManager = TableBufferManager;
#endif

            return client;
        }

        public static CloudQueueClient GenerateCloudQueueClient()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.QueueServiceEndpoint);
            CloudQueueClient client = new CloudQueueClient(baseAddressUri, TestBase.StorageCredentials);
            client.AuthenticationScheme = DefaultAuthenticationScheme;

#if WINDOWS_DESKTOP
            client.BufferManager = QueueBufferManager;
#endif

            return client;
        }

        public static TestConfigurations TestConfigurations { get; private set; }

        public static TenantConfiguration TargetTenantConfig { get; private set; }

        public static TenantType CurrentTenantType { get; private set; }

        /// <summary>
        /// The StorageCredentials created from account settings in the target tenant config.
        /// </summary>
        public static StorageCredentials StorageCredentials { get; private set; }
    }
}
