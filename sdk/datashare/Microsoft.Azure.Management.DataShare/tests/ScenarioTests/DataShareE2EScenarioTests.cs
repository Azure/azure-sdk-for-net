namespace DataShare.Tests.ScenarioTests
{
    using System;
    using System.Threading.Tasks;
    using DataShare.Tests.Utils;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Xunit;

    public class DataShareE2EScenarioTests : ScenarioTestBase<DataShareE2EScenarioTests>
    {
        private const string shareName = "sdktestingshare";
        private const string invitationName = "sdktestinginvitation";
        private const string shareSubscriptionName = "sdktestingsharesub";
        private const string synchronizationSettingName = "sdktestingsynchronizationsetting";
        private const string dataSetName = "sdktestingdataset";
        private const string containerName = "containername";
        private const string triggerName = "sdktestingtrigger";
        private const string dataSetMappingName = "sdktestingdatasetmapping";
        private const string sourceShareLocationName = "eastus";

        private const string subscriptionId = "SUBSCRIPTION_ID";
        public static string tenant = "AADTENANT";
        public static string servicePrincipal = "ServicePrincipal";

        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task DataShareE2E()
        {
            Account expectedAccount = new Account(identity, "DataShareId", shareName,default(SystemData), "Microsoft.DataShare", ScenarioTestBase<DataShareE2EScenarioTests>.AccountLocation); 
            string subscriptionIdVal = Environment.GetEnvironmentVariable(subscriptionId);

        Func<DataShareManagementClient, Task> action = async (client) =>
            {
                await AccountScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    expectedAccount);

                await ShareScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareName,
                    ShareScenarioTests.GetShare());

                var synchronizationSetting = await SynchronizationSettingScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareName,
                    DataShareE2EScenarioTests.synchronizationSettingName,
                    SynchronizationSettingScenarioTests.GetSynchronizationSetting()) as ScheduledSynchronizationSetting;

                DataSet dataSet = await DataSetScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareName,
                    DataShareE2EScenarioTests.dataSetName,
                    DataSetScenarioTests.GetDataSet(containerName , DataSetScenarioTests.filepath, this.ResourceGroupName, ScenarioTestBase<DataShareE2EScenarioTests>.storageActName, subscriptionIdVal));

                Invitation invitation = await InvitationScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareName,
                    DataShareE2EScenarioTests.invitationName,
                    InvitationScenarioTests.GetExpectedInvitation());

                await ShareSubscriptionScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareSubscriptionName,
                    ShareSubscriptionScenarioTests.GetShareSubscription(invitation.InvitationId, DataShareE2EScenarioTests.sourceShareLocationName));

                await TriggerScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareSubscriptionName,
                    DataShareE2EScenarioTests.triggerName,
                    TriggerScenarioTests.GetTrigger(
                        synchronizationSetting.RecurrenceInterval,
                        synchronizationSetting.SynchronizationTime));

                await DataSetMappingScenarioTests.CreateAsync(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareSubscriptionName,
                    DataShareE2EScenarioTests.dataSetMappingName,
                    DataSetMappingScenarioTests.GetDataSetMapping(containerName, DataSetScenarioTests.dataSetId, DataSetScenarioTests.filepath, this.ResourceGroupName,storageActName,subscriptionIdVal));

                ShareSubscriptionScenarioTests.Synchronize(
                    client,
                    this.ResourceGroupName,
                    this.AccountName,
                    DataShareE2EScenarioTests.shareSubscriptionName);
            };

            Func<DataShareManagementClient, Task> finallyAction = async (client) =>
            {
                await AccountScenarioTests.Delete(
                    client,
                    this.ResourceGroupName,
                    this.AccountName);
            };

            await this.RunTest(action, finallyAction);
        }
    }
}

