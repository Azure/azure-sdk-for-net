//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net.Http;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Test.HttpRecorder;

namespace HDInsightJob.Tests
{
    public static class TestUtils
    {
        public static string ClusterName = "pattipakalinuxg5.azurehdinsight.net";
        public static string UserName = "admin";
        public static string Password = "H@d00pcluster";
        public static string StorageAccountName = "pattipakalinuxg5";
        public static string StorageAccountKey = "cHm4gCGsfAFgc24XMPWFXHL8kN6syYwXQEJctPBaJQU1psnCcb1Pox99kpTkaiL1B86pSb9IQNpyFRTUacXEGg==";
        public static string DefaultContainer = "pattipakalinuxg5";

        public static string WinClusterName = "pattipakawin33.azurehdinsight.net";
        public static string WinStorageAccountName = "pattipakastorageaccount";
        public static string WinStorageAccountKey = "dFFtQ1ynNUYyo7kkyB7nkVqmegrHbtPQJXesInPnThzYqA7t1MSSfdDUQgQrm5C2BZLGpzV3hiIBHuEEZk6IHQ==";
        public static string WinDefaultContainer = "pattipakawin33";
        public static string WinUserName = "admin";
        public static string WinPassword = "H@d00pcluster";

        public static string SQLServerUserName = "jobtest@hdinsightjobtest";
        public static string SQLServerPassword = "Password@1";
        public static string SQLServerConnectionString = "jdbc:sqlserver://hdinsightjobtest.database.windows.net:1433;database=HdInsightJobTest;user=" + SQLServerUserName + ";password=" + SQLServerPassword + ";";
        public static string SQLServerTableName = "dept";

        public static TimeSpan JobPollInterval = TimeSpan.FromSeconds(30);
        public static TimeSpan JobWaitInterval = TimeSpan.FromMinutes(30);

        public static HDInsightJobManagementClient GetHDInsightJobManagementClient(bool isWindowsCluster = false)
        {
            var credentials = new BasicAuthenticationCloudCredentials
            {
                Username = isWindowsCluster ? WinUserName : UserName,
                Password = isWindowsCluster ? WinPassword : Password
            };

            return TestUtils.GetHDInsightJobManagementClient(isWindowsCluster ? WinClusterName : ClusterName, credentials);
        }

        public static HDInsightJobManagementClient GetHDInsightJobManagementClient(string dnsName, BasicAuthenticationCloudCredentials creds)
        {
            var client = new HDInsightJobManagementClient(dnsName, creds);
            return AddMockHandler(ref client);
        }

        private static T AddMockHandler<T>(ref T client) where T : class
        {
            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }
            
            var method = typeof(T).GetMethod("WithHandler", new Type[] { typeof(DelegatingHandler) });
            client = method.Invoke(client, new object[] { server }) as T;
            
            if (HttpMockServer.Mode != HttpRecorderMode.Playback) return client;
            
            var initialTimeout = typeof(T).GetProperty("LongRunningOperationInitialTimeout", typeof(int));
            var retryTimeout = typeof(T).GetProperty("LongRunningOperationRetryTimeout", typeof(int));
            if (initialTimeout == null || retryTimeout == null) return client;
            
            initialTimeout.SetValue(client, 0);
            retryTimeout.SetValue(client, 0);
            return client;
        }
    }
}
