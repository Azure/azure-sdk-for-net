// -----------------------------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Microsoft">
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

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

#if RTMD
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace Microsoft.WindowsAzure.Storage
{
    public partial class TestBase
    {
        private const AuthenticationScheme DefaultAuthenticationScheme = AuthenticationScheme.SharedKey;

        public static CloudTableClient GenerateCloudTableClient()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.TableServiceEndpoint);
            CloudTableClient client = new CloudTableClient(baseAddressUri, TestBase.StorageCredentials);
            client.AuthenticationScheme = DefaultAuthenticationScheme;
            return client;
        }

        public static CloudBlobClient GenerateCloudBlobClient()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.BlobServiceEndpoint);
            CloudBlobClient client = new CloudBlobClient(baseAddressUri, TestBase.StorageCredentials);
            client.AuthenticationScheme = DefaultAuthenticationScheme;
            return client;
        }

        public static CloudQueueClient GenerateCloudQueueClient()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.QueueServiceEndpoint);
            CloudQueueClient client = new CloudQueueClient(baseAddressUri, TestBase.StorageCredentials);
            client.AuthenticationScheme = DefaultAuthenticationScheme;
            return client;
        }

        public static TestConfigurations TestConfigurations
        {
            get;
            private set;
        }

        public static TenantConfiguration TargetTenantConfig
        {
            get;
            private set;
        }

        public static TenantType CurrentTenantType
        {
            get;
            private set;
        }

        /// <summary>
        /// The StorageCredentials created from account settings in the target tenant config.
        /// </summary>
        public static StorageCredentials StorageCredentials
        {
            get;
            private set;
        }
    }
}
