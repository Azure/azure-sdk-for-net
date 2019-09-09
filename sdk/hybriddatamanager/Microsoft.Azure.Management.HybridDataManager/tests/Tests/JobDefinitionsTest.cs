namespace HybridData.Tests.Tests
{
    using Microsoft.Azure.Management.HybridData;
    using Microsoft.Azure.Management.HybridData.Models;
    using Microsoft.Rest.Azure;
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class JobDefinitionsTest : HybridDataTestBase
    {

        public JobDefinitionsTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            JobDefinitionName = TestConstants.DefaultJobDefinitiontName;
        }

        //JobDefinitions_ListByDataService
        [Fact]
        public void JobDefinitions_ListByDataService()
        {
            try
            {
                var jobDefinitonList = Client.JobDefinitions.ListByDataService(dataServiceName: DataServiceName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(jobDefinitonList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //JobDefinitions_Get
        [Fact]
        public void JobDefinitions_Get()
        {
            try
            {
                var jobDefiniton = Client.JobDefinitions.Get(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(jobDefiniton);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //JobDefinitions_CreateOrUpdate
        [Fact]
        public void JobDefinitions_CreateOrUpdate()
        {
            try
            {
                UserConfirmation userConfirmation = UserConfirmation.Required;
                BackupChoice backupChoice = BackupChoice.UseExistingLatest;
                string[] rootDirectories = new string[] { "\\" },
                    volumeNames = new string[] { TestConstants.DefaultStorSimpleVolumeName };

                var jobDefinition = Client.JobDefinitions.GetJobDefinition(
                    client: Client,
                    dataSourceName: TestConstants.DefaultDataSourceName,
                    dataSinkName: TestConstants.DefaultDataSinkName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName,
                    runLocation: TestConstants.DefaultLocation,
                    userConfirmation: userConfirmation,
                    deviceName: TestConstants.DefaultStorSimpleDeviceName,
                    containerName: TestConstants.DefaultStorageContainerName,
                    volumeNames: volumeNames,
                    backupChoice: backupChoice);

                var returnedJobDefinition = Client.JobDefinitions.CreateOrUpdate(
                    dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    jobDefinition: jobDefinition,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(returnedJobDefinition);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //JobDefinitions_Delete
        [Fact]
        public void JobDefinitions_Delete()
        {
            try
            {
                Client.JobDefinitions.Delete(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                var jobDefiniton = Client.JobDefinitions.Get(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.Null(jobDefiniton);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Body.Code.Equals(TestConstants.ResourceNotFoundErrorCode) ||
                    ex.Body.Code.Equals(TestConstants.DmsUserErrorEntityNotFoundErrorCode));
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //JobDefinitions_ListByDataManager
        [Fact]
        public void JobDefinitions_ListByDataManager()
        {
            try
            {
                var jobDefinitonList = Client.JobDefinitions.ListByDataManager(
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(jobDefinitonList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //JobDefinitions_Run
        [Fact]
        public void JobDefinitions_Run()
        {
            try
            {
                //string deviceName = "dmsdatasource";
                //string containerName = "contforportal";
                //BackupChoice backupChoice = BackupChoice.UseExistingLatest;
                UserConfirmation userConfirmation = UserConfirmation.NotRequired;
                //string[] rootDirectories = new string[] { "\\" };
                //string[] volumeNames = new string[] { "dmsbvtvol" };

                RunParameters runParameters = Client.JobDefinitions.GetRunParameters(
                    client: Client,
                    dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName,
                    userConfirmation: userConfirmation
                    //deviceName: deviceName,
                    //containerName: containerName,
                    //volumeNames: volumeNames,
                    //backupChoice: backupChoice
                    );
                var jobId = Client.JobDefinitions.BeginRunAndGetJobId(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    runParameters: runParameters,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(jobId);
                Assert.True(jobId != String.Empty);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
    }
}

