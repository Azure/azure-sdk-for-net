namespace Microsoft.Azure.Management.HybridData
{
    using Microsoft.Azure.Management.HybridData.Models;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class JobDefinitionsOperationsExtensions
    {
        /// <summary>
        /// This method runs a job instance of the given job definition and returns the jobId.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='dataServiceName'>
        /// The data service type of the job definition.
        /// </param>
        /// <param name='jobDefinitionName'>
        /// Name of the job definition.
        /// </param>
        /// <param name='runParameters'>
        /// Run time parameters for the job definition.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The Resource Group Name
        /// </param>
        /// <param name='dataManagerName'>
        /// The name of the DataManager Resource within the specified resource group.
        /// DataManager names must be between 3 and 24 characters in length and use any
        /// alphanumeric and underscore only
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>The jobId of the triggered job<returns></returns>
        public static string BeginRunAndGetJobId(this IJobDefinitionsOperations operations, string dataServiceName, 
            string jobDefinitionName, RunParameters runParameters, string resourceGroupName, string dataManagerName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = operations.BeginRunWithHttpMessagesAsync(dataServiceName, jobDefinitionName, runParameters, resourceGroupName,
               dataManagerName).GetAwaiter().GetResult();
            string jobId = result == null ? String.Empty : result.Response.Headers.Location.AbsolutePath.Split('/').Last()
                .Split('?').First();
            return jobId;
        }

        public static JobDefinition GetJobDefinition(this IJobDefinitionsOperations operations, HybridDataManagementClient client,
            string dataSourceName, string dataSinkName, string resourceGroupName, string dataManagerName, string runLocation,
            UserConfirmation userConfirmation, string deviceName, string containerName, string[] volumeNames, BackupChoice backupChoice,
            string fileNameFilter = null, string[] rootDirectories = null, AzureStorageType azureStorageType = AzureStorageType.Blob, bool isDirectoryMode = false)
        {
            var jobDefinition = new JobDefinition();
            
            jobDefinition.DataSinkId = client.DataStores.Get(dataStoreName: dataSinkName,
                resourceGroupName: resourceGroupName, dataManagerName: dataManagerName).Id;
            jobDefinition.DataSourceId = client.DataStores.Get(dataStoreName: dataSourceName,
                resourceGroupName: resourceGroupName, dataManagerName: dataManagerName).Id;

            RunLocation parsedRunLocation = RunLocation.None;
            if(Enum.TryParse(runLocation, true, out parsedRunLocation))
                jobDefinition.RunLocation = parsedRunLocation;

            jobDefinition.State = State.Enabled;
            jobDefinition.UserConfirmation = userConfirmation;
            jobDefinition.DataServiceInput = GetDataServiceInput(deviceName, containerName, volumeNames, backupChoice, fileNameFilter,
                rootDirectories, azureStorageType, isDirectoryMode);
            return jobDefinition;
        }

        private static object GetDataServiceInput(string deviceName, string containerName, string[] volumeNames, BackupChoice backupChoice,
            string fileNameFilter = null, string[] rootDirectories = null, AzureStorageType azureStorageType = AzureStorageType.Blob, bool isDirectoryMode = false)
        {
            JToken dataServiceInputJToken = new JObject();
            dataServiceInputJToken["DeviceName"] = deviceName;
            dataServiceInputJToken["FileNameFilter"] = fileNameFilter ?? "*";
            dataServiceInputJToken["ContainerName"] = containerName;
            JArray rootDirectoriesObj = new JArray();
            if (rootDirectories != null)
                foreach (var rootDirectory in rootDirectories)
                    rootDirectoriesObj.Add(rootDirectory);
            else
                rootDirectoriesObj.Add("\\");
            dataServiceInputJToken["RootDirectories"] = rootDirectoriesObj;
            JArray volumeNamesObj = new JArray();
            foreach (var volumeName in volumeNames)
                volumeNamesObj.Add(volumeName);
            dataServiceInputJToken["VolumeNames"] = volumeNamesObj;
            dataServiceInputJToken["BackupChoice"] = backupChoice.ToSerializedValue();
            dataServiceInputJToken["IsDirectoryMode"] = isDirectoryMode;
            dataServiceInputJToken["AzureStorageType"] = azureStorageType.ToSerializedValue();
            return dataServiceInputJToken;
        }

        public static RunParameters GetRunParameters(this IJobDefinitionsOperations operations,
            HybridDataManagementClient client, string jobDefinitionName, string dataServiceName,
            string dataManagerName, string resourceGroupName,
            UserConfirmation userConfirmation, string deviceName = null, string containerName = null,
            string[] volumeNames = null, BackupChoice backupChoice = BackupChoice.UseExistingLatest,
            string fileNameFilter = null, string[] rootDirectories = null, 
            string azureStorageType = null, bool isDirectoryMode = false)
        {
            RunParameters runParameters = new RunParameters();
            runParameters.CustomerSecrets = new List<CustomerSecret>();
            runParameters.UserConfirmation = userConfirmation;
            //JToken dataServiceInputJToken = client.JobDefinitions.Get(dataServiceName: dataServiceName,
            JToken dataServiceInputJToken = operations.Get(dataServiceName: dataServiceName,
                    jobDefinitionName: jobDefinitionName,
                    resourceGroupName: resourceGroupName,
                    dataManagerName: dataManagerName).DataServiceInput as JToken;
            dataServiceInputJToken["DeviceName"] = deviceName ?? dataServiceInputJToken["DeviceName"];
            dataServiceInputJToken["FileNameFilter"] = fileNameFilter ?? dataServiceInputJToken["FileNameFilter"];
            dataServiceInputJToken["ContainerName"] = containerName ?? dataServiceInputJToken["ContainerName"];

            if (rootDirectories != null)
            {
                JArray rootDirectoriesObj = new JArray();
                foreach (var rootDirectory in rootDirectories)
                    rootDirectoriesObj.Add(rootDirectory);
                dataServiceInputJToken["RootDirectories"] = rootDirectoriesObj;
            }
            if (volumeNames != null)
            {
                JArray volumeNamesObj = new JArray();
                foreach (var volumeName in volumeNames)
                    volumeNamesObj.Add(volumeName);
                dataServiceInputJToken["VolumeNames"] = volumeNamesObj;
            }
            dataServiceInputJToken["BackupChoice"] = backupChoice.ToString() ?? dataServiceInputJToken["BackupChoice"];
            dataServiceInputJToken["IsDirectoryMode"] = isDirectoryMode;
            dataServiceInputJToken["AzureStorageType"] = azureStorageType ?? dataServiceInputJToken["AzureStorageType"];
            runParameters.DataServiceInput = dataServiceInputJToken;
            return runParameters;
        }
    }
}
