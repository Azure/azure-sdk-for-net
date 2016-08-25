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
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Net;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System.Collections.Generic;
using Xunit;

namespace DataLakeAnalytics.Tests
{
    public class DataLakeAnalyticsManagementHelper
    {
        private ResourceManagementClient resourceManagementClient;
        private StorageManagementClient storageManagementClient;
        private DataLakeStoreAccountManagementClient dataLakeStoreManagementClient;
        private DataLakeAnalyticsAccountManagementClient dataLakeAnalyticsManagementClient;
        private DataLakeAnalyticsJobManagementClient dataLakeAnalyticsJobManagementClient;
        private TestBase testBase;

        public DataLakeAnalyticsManagementHelper(TestBase testBase, MockContext context)
        {
            this.testBase = testBase;
            resourceManagementClient = this.testBase.GetResourceManagementClient(context);
            storageManagementClient = this.testBase.GetStorageManagementClient(context);
            dataLakeStoreManagementClient = this.testBase.GetDataLakeStoreAccountManagementClient(context);
            dataLakeAnalyticsManagementClient = this.testBase.GetDataLakeAnalyticsAccountManagementClient(context);
            dataLakeAnalyticsJobManagementClient = this.testBase.GetDataLakeAnalyticsJobManagementClient(context);
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeAnalytics")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.NamespaceProperty), string.Format("Provider name: {0} is not equal to {1}.", resultAfterRegister.NamespaceProperty, providerName));
            ThrowIfTrue(!resultAfterRegister.RegistrationState.Equals("Registered") &&
                        !resultAfterRegister.RegistrationState.Equals("Registering"),
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.RegistrationState));
            ThrowIfTrue(resultAfterRegister.ResourceTypes == null || resultAfterRegister.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
        }

        public void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            // get the resource group first
            bool exists = false;
            ResourceGroup newlyCreatedGroup = null;
            try
            {
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
                exists = true;
            }
            catch
            {
                // do nothing because it means it doesn't exist
            }

            if (!exists)
            {
                var result =
                    resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                        new ResourceGroup { Location = location });
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            }

            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.Name),
                string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            { 
                throw new Exception(message);
            }
        }

        public string TryCreateDataLakeStoreAccount(string resourceGroupName, string location, string accountName)
        {
            bool exists = false;
            Microsoft.Azure.Management.DataLake.Store.Models.DataLakeStoreAccount accountGetResponse = null;
            try
            {
                accountGetResponse = dataLakeStoreManagementClient.Account.Get(resourceGroupName, accountName);
                exists = true;
            }
            catch
            {
                // do nothing because it doesn't exist
            }


            if (!exists)
            {
                dataLakeStoreManagementClient.Account.Create(resourceGroupName, accountName,
                    new Microsoft.Azure.Management.DataLake.Store.Models.DataLakeStoreAccount { Location = location, Name = accountName });

                accountGetResponse = dataLakeStoreManagementClient.Account.Get(resourceGroupName,
                    accountName);

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                int minutesWaited = 0;
                int timeToWaitInMinutes = 15;
                while (accountGetResponse.Properties.ProvisioningState !=
                       DataLakeStoreAccountStatus.Succeeded &&
                       accountGetResponse.Properties.ProvisioningState !=
                       DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    accountGetResponse = dataLakeStoreManagementClient.Account.Get(resourceGroupName,
                        accountName);
                }
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(
                accountGetResponse.Properties.ProvisioningState !=
                DataLakeStoreAccountStatus.Succeeded,
                "Account failed to be provisioned into the success state. Actual State: " +
                accountGetResponse.Properties.ProvisioningState);

            return accountGetResponse.Properties.Endpoint.Replace(string.Format("{0}.",accountName), "");
        }

        public string TryCreateStorageAccount(string resourceGroupName, string storageAccountName, string label, string description, string location, out string storageAccountSuffix)
        {
            var stoInput = new StorageAccountCreateParameters
            {
                Location = location,
                Kind = Kind.Storage,
                Sku = new Microsoft.Azure.Management.Storage.Models.Sku
                {
                    Name = SkuName.StandardGRS
                }
            };


            // retrieve the storage account
            storageManagementClient.StorageAccounts.Create(resourceGroupName, storageAccountName, stoInput);

            // retrieve the storage account primary access key
            var accessKey = storageManagementClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName).Keys[0].Value;
            ThrowIfTrue(string.IsNullOrEmpty(accessKey), "storageManagementClient.StorageAccounts.ListKeys returned null.");

            // set the storage account suffix
            var getResponse = storageManagementClient.StorageAccounts.GetProperties(resourceGroupName, storageAccountName);
            storageAccountSuffix = getResponse.PrimaryEndpoints.Blob.ToString();
            storageAccountSuffix = storageAccountSuffix.Replace("https://", "").TrimEnd('/');
            storageAccountSuffix = storageAccountSuffix.Replace(storageAccountName, "").TrimStart('.');
            storageAccountSuffix = storageAccountSuffix.Replace("blob.",""); // remove the opening "blob." if it exists.

            return accessKey;
        }

        public string TryCreateDataLakeAnalyticsAccount(string resourceGroupName, string location,
            string dataLakeStoreAccountName, string accountName)
        {
            var datalakeStoreEndpoint = TryCreateDataLakeStoreAccount(resourceGroupName, location,
                dataLakeStoreAccountName);

            var accountCreateResponse =
                dataLakeAnalyticsManagementClient.Account.Create(resourceGroupName, accountName,
                new DataLakeAnalyticsAccount
                {
                    Location = location,
                    Name = accountName,
                    Properties =
                        new DataLakeAnalyticsAccountProperties
                        {
                            DataLakeStoreAccounts =
                                new List
                                    <
                                        DataLakeStoreAccountInfo>
                                {
                                    new DataLakeStoreAccountInfo
                                    {
                                        Name = dataLakeStoreAccountName,
                                        Properties = new DataLakeStoreAccountInfoProperties
                                        {
                                            Suffix =
                                                datalakeStoreEndpoint.Replace(
                                                    string.Format("{0}.", dataLakeStoreAccountName), "")
                                        }
                                    }
                                },
                            DefaultDataLakeStoreAccount = dataLakeStoreAccountName
                        }     
                });
            var accountGetResponse = dataLakeAnalyticsManagementClient.Account.Get(resourceGroupName,
                accountName);

            // wait for provisioning state to be Succeeded
            // we will wait a maximum of 15 minutes for this to happen and then report failures
            int timeToWaitInMinutes = 15;
            int minutesWaited = 0;
            while (accountGetResponse.Properties.ProvisioningState !=
                   DataLakeAnalyticsAccountStatus.Succeeded &&
                   accountGetResponse.Properties.ProvisioningState !=
                   DataLakeAnalyticsAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
            {
                TestUtilities.Wait(60000); // Wait for one minute and then go again.
                minutesWaited++;
                accountGetResponse = dataLakeAnalyticsManagementClient.Account.Get(resourceGroupName,
                    accountName);
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(
                accountGetResponse.Properties.ProvisioningState !=
                DataLakeAnalyticsAccountStatus.Succeeded,
                "Account failed to be provisioned into the success state after " + timeToWaitInMinutes + " minutes.");

            return datalakeStoreEndpoint;
        }

        public Guid CreateCatalog(string resourceGroupName, string dataLakeAnalyticsAccountName, string dbName,
            string tableName, string tvfName, string viewName, string procName)
        {
            // build a simple catalog that can be used to retrieve items.
            var scriptToRun = string.Format(@"
DROP DATABASE IF EXISTS {0}; CREATE DATABASE {0}; 
//Create Table
CREATE TABLE {0}.dbo.{1}
(
        //Define schema of table
        UserId          int, 
        Start           DateTime, 
        Region          string, 
        Query           string, 
        Duration        int, 
        Urls            string, 
        ClickedUrls     string,
    INDEX idx1 //Name of index
    CLUSTERED (Region ASC) //Column to cluster by
    PARTITIONED BY BUCKETS (UserId) HASH (Region) //Column to partition by
);

ALTER TABLE {0}.dbo.{1} ADD IF NOT EXISTS PARTITION (1);

DROP FUNCTION IF EXISTS {0}.dbo.{2};

//create table weblogs on space-delimited website log data
CREATE FUNCTION {0}.dbo.{2}()
RETURNS @result TABLE
(
    s_date DateTime,
    s_time string,
    s_sitename string,
    cs_method string, 
    cs_uristem string,
    cs_uriquery string,
    s_port int,
    cs_username string, 
    c_ip string,
    cs_useragent string,
    cs_cookie string,
    cs_referer string, 
    cs_host string,
    sc_status int,
    sc_substatus int,
    sc_win32status int, 
    sc_bytes int,
    cs_bytes int,
    s_timetaken int
)
AS
BEGIN

    @result = EXTRACT
        s_date DateTime,
        s_time string,
        s_sitename string,
        cs_method string,
        cs_uristem string,
        cs_uriquery string,
        s_port int,
        cs_username string,
        c_ip string,
        cs_useragent string,
        cs_cookie string,
        cs_referer string,
        cs_host string,
        sc_status int,
        sc_substatus int,
        sc_win32status int,
        sc_bytes int,
        cs_bytes int,
        s_timetaken int
    FROM @""/Samples/Data/WebLog.log""
    USING Extractors.Text(delimiter:' ');

RETURN;
END;
CREATE VIEW {0}.dbo.{3} 
AS 
    SELECT * FROM 
    (
        VALUES(1,2),(2,4)
    ) 
AS 
T(a, b);
CREATE PROCEDURE {0}.dbo.{4}()
AS BEGIN
  CREATE VIEW {0}.dbo.{3} 
  AS 
    SELECT * FROM 
    (
        VALUES(1,2),(2,4)
    ) 
  AS 
  T(a, b);
END;", dbName, tableName, tvfName, viewName, procName);

            return RunJobToCompletion(dataLakeAnalyticsJobManagementClient, dataLakeAnalyticsAccountName, TestUtilities.GenerateGuid(), scriptToRun);
        }

        internal Guid RunJobToCompletion(DataLakeAnalyticsJobManagementClient jobClient, string dataLakeAnalyticsAccountName, Guid jobIdToUse, string scriptToRun)
        { 
            var createOrBuildParams = new JobInformation
            {
                Name = TestUtilities.GenerateName("testjob1"),
                Type = JobType.USql,
                DegreeOfParallelism = 2,
                Properties = new USqlJobProperties
                {
                    // Type = JobType.USql,
                    Script = scriptToRun
                },
                JobId = jobIdToUse
            };
            var jobCreateResponse = jobClient.Job.Create(dataLakeAnalyticsAccountName, jobIdToUse, createOrBuildParams);

            Assert.NotNull(jobCreateResponse);

            // Poll the job until it finishes
            var getJobResponse = jobClient.Job.Get(dataLakeAnalyticsAccountName, jobCreateResponse.JobId.GetValueOrDefault());
            Assert.NotNull(getJobResponse);

            int maxWaitInSeconds = 180; // 3 minutes should be long enough
            int curWaitInSeconds = 0;
            while (getJobResponse.State != JobState.Ended && curWaitInSeconds < maxWaitInSeconds)
            {
                // wait 5 seconds before polling again
                TestUtilities.Wait(5000);
                curWaitInSeconds += 5;
                getJobResponse = jobClient.Job.Get(dataLakeAnalyticsAccountName, jobCreateResponse.JobId.GetValueOrDefault());
                Assert.NotNull(getJobResponse);
            }

            Assert.True(curWaitInSeconds <= maxWaitInSeconds);

            // Verify the job completes successfully
            Assert.True(
                getJobResponse.State == JobState.Ended && getJobResponse.Result == JobResult.Succeeded,
                string.Format(
                    "Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                    getJobResponse.JobId, getJobResponse.State, getJobResponse.Result,
                    getJobResponse.ErrorMessage != null && getJobResponse.ErrorMessage.Count > 0 ? getJobResponse.ErrorMessage[0].Details : "no error information returned"));
            return getJobResponse.JobId.GetValueOrDefault();
        }
    }
}
