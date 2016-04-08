
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
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Azure.Management.DataLake.AnalyticsJob;
using Microsoft.Azure.Management.DataLake.AnalyticsJob.Models;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;
using DataLakeStoreAccount = Microsoft.Azure.Management.DataLake.Store.Models.DataLakeStoreAccount;
using DataLakeStoreAccountProperties = Microsoft.Azure.Management.DataLake.Analytics.Models.DataLakeStoreAccountProperties;

namespace DataLakeAnalyticsCatalog.Tests
{
    public class DataLakeAnalyticsCatalogManagementHelper
    {
        private ResourceManagementClient resourceManagementClient;
        private DataLakeStoreManagementClient dataLakeStoreManagementClient;
        private DataLakeAnalyticsManagementClient dataLakeAnalyticsManagementClient;
        private DataLakeAnalyticsJobManagementClient dataLakeAnalyticsJobManagementClient;
        private TestBase testBase;

        public DataLakeAnalyticsCatalogManagementHelper(TestBase testBase)
        {
            this.testBase = testBase;
            resourceManagementClient = ClientManagementUtilities.GetResourceManagementClient(this.testBase);
            dataLakeStoreManagementClient = ClientManagementUtilities.GetDataLakeStoreManagementClient(this.testBase);
            dataLakeAnalyticsManagementClient =
                ClientManagementUtilities.GetDataLakeAnalyticsManagementClient(this.testBase);
            dataLakeAnalyticsJobManagementClient =
                ClientManagementUtilities.GetDataLakeAnalyticsJobManagementClient(this.testBase);
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeAnalytics")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK,
                string.Format("resourceManagementClient.Providers.Register returned with status code {0}",
                    reg.StatusCode));

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace),
                string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                        ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format(
                    "Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'",
                    resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(
                resultAfterRegister.Provider.ResourceTypes == null ||
                resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(
                resultAfterRegister.Provider.ResourceTypes[0].Locations == null ||
                resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0,
                "Provider.ResourceTypes[0].Locations is empty.");
        }

        public void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceGroupCreateOrUpdateResult result =
                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup {Location = location});
            var newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name),
                string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        public string TryCreateDataLakeStoreAccount(string resourceGroupName, string location, string accountName)
        {
            var accountCreateResponse = dataLakeStoreManagementClient.DataLakeStoreAccount.Create(resourceGroupName,
                new DataLakeStoreAccountCreateOrUpdateParameters
                {
                    DataLakeStoreAccount =
                        new DataLakeStoreAccount
                        {
                            Location = location,
                            Name = accountName
                        }
                });
            var accountGetResponse = dataLakeStoreManagementClient.DataLakeStoreAccount.Get(resourceGroupName,
                accountName);

            // wait for provisioning state to be Succeeded
            // we will wait a maximum of 15 minutes for this to happen and then report failures
            int timeToWaitInMinutes = 15;
            int minutesWaited = 0;
            while (accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState !=
                   DataLakeStoreAccountStatus.Succeeded &&
                   accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState !=
                   DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
            {
                TestUtilities.Wait(60000); // Wait for one minute and then go again.
                minutesWaited++;
                accountGetResponse = dataLakeStoreManagementClient.DataLakeStoreAccount.Get(resourceGroupName,
                    accountName);
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(
                accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState !=
                DataLakeStoreAccountStatus.Succeeded,
                "Account failed to be provisioned into the success state after " + timeToWaitInMinutes + " minutes.");

            return accountGetResponse.DataLakeStoreAccount.Properties.Endpoint;
        }

        public string TryCreateDataLakeAnalyticsAccount(string resourceGroupName, string location,
            string dataLakeStoreAccountName, string accountName)
        {
            var datalakeStoreEndpoint = TryCreateDataLakeStoreAccount(resourceGroupName, location,
                dataLakeStoreAccountName);

            var accountCreateResponse =
                dataLakeAnalyticsManagementClient.DataLakeAnalyticsAccount.Create(resourceGroupName,
                    new DataLakeAnalyticsAccountCreateOrUpdateParameters
                    {
                        DataLakeAnalyticsAccount =
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
                                                    Microsoft.Azure.Management.DataLake.Analytics.Models.
                                                        DataLakeStoreAccount>
                                            {
                                                new Microsoft.Azure.Management.DataLake.Analytics.Models.
                                                    DataLakeStoreAccount
                                                {
                                                    Name = dataLakeStoreAccountName,
                                                    Properties = new DataLakeStoreAccountProperties
                                                    {
                                                        Suffix =
                                                            datalakeStoreEndpoint.Replace(
                                                                string.Format("{0}.", dataLakeStoreAccountName), "")
                                                    }
                                                }
                                            },
                                        DefaultDataLakeStoreAccount = dataLakeStoreAccountName
                                    }
                            }
                    });
            var accountGetResponse = dataLakeAnalyticsManagementClient.DataLakeAnalyticsAccount.Get(resourceGroupName,
                accountName);

            // wait for provisioning state to be Succeeded
            // we will wait a maximum of 15 minutes for this to happen and then report failures
            int timeToWaitInMinutes = 15;
            int minutesWaited = 0;
            while (accountGetResponse.DataLakeAnalyticsAccount.Properties.ProvisioningState !=
                   DataLakeAnalyticsAccountStatus.Succeeded &&
                   accountGetResponse.DataLakeAnalyticsAccount.Properties.ProvisioningState !=
                   DataLakeAnalyticsAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
            {
                TestUtilities.Wait(60000); // Wait for one minute and then go again.
                minutesWaited++;
                accountGetResponse = dataLakeAnalyticsManagementClient.DataLakeAnalyticsAccount.Get(resourceGroupName,
                    accountName);
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(
                accountGetResponse.DataLakeAnalyticsAccount.Properties.ProvisioningState !=
                DataLakeAnalyticsAccountStatus.Succeeded,
                "Account failed to be provisioned into the success state after " + timeToWaitInMinutes + " minutes.");

            return datalakeStoreEndpoint;
        }

        public void CreateCatalog(string resourceGroupName, string dataLakeAnalyticsAccountName, string dbName,
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
    PARTITIONED BY HASH (Region) //Column to partition by
);
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

            RunJobToCompletion(dataLakeAnalyticsJobManagementClient, resourceGroupName, dataLakeAnalyticsAccountName, TestUtilities.GenerateGuid(), scriptToRun);
        }

        internal void RunJobToCompletion(DataLakeAnalyticsJobManagementClient jobClient, string resourceGroupName, string dataLakeAnalyticsAccountName, Guid jobIdToUse, string scriptToRun)
        {
            var createOrBuildParams = new JobInfoBuildOrCreateParameters
            {
                Job = new JobInformation
                {
                    Name = TestUtilities.GenerateName("testjob1"),
                    JobId = jobIdToUse,
                    Type = JobType.USql,
                    DegreeOfParallelism = 2,
                    Properties = new USqlProperties
                    {
                        Type = JobType.USql,
                        Script = scriptToRun
                    }
                }
            };
            var jobCreateResponse = jobClient.Jobs.Create(resourceGroupName,
                dataLakeAnalyticsAccountName, createOrBuildParams);

            Assert.NotNull(jobCreateResponse);

            // Poll the job until it finishes
            JobInfoGetResponse getJobResponse = jobClient.Jobs.Get(resourceGroupName,
                dataLakeAnalyticsAccountName, jobCreateResponse.Job.JobId);
            Assert.NotNull(getJobResponse);

            int maxWaitInSeconds = 180; // 3 minutes should be long enough
            int curWaitInSeconds = 0;
            while (getJobResponse.Job.State != JobState.Ended && curWaitInSeconds < maxWaitInSeconds)
            {
                // wait 5 seconds before polling again
                TestUtilities.Wait(5000);
                curWaitInSeconds += 5;
                getJobResponse = jobClient.Jobs.Get(resourceGroupName,
                    dataLakeAnalyticsAccountName, jobCreateResponse.Job.JobId);
                Assert.NotNull(getJobResponse);
            }

            Assert.True(curWaitInSeconds <= maxWaitInSeconds);

            // Verify the job completes successfully
            Assert.True(
                getJobResponse.Job.State == JobState.Ended && getJobResponse.Job.Result == JobResult.Succeeded,
                string.Format(
                    "Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                    getJobResponse.Job.JobId, getJobResponse.Job.State, getJobResponse.Job.Result,
                    getJobResponse.Job.ErrorMessage));
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
