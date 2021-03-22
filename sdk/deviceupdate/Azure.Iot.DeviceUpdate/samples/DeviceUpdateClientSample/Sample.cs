// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.IoT.DeviceUpdate;
using Azure.IoT.DeviceUpdate.Models;
using Newtonsoft.Json;
using Operation = Azure.IoT.DeviceUpdate.Models.Operation;

namespace ConsoleTest
{
    /// <summary>
    /// A sample runner to demonstrate use of Device Update for IoT Hub SDK library. The sample will exercise the following:
    ///     * publish new update
    ///     * retrieve the newly imported update
    ///     * wait for update to be installable to our device
    ///     * create deployment to deploy our new update to our device
    ///     * check deployment status until it's completed
    ///     * retrieve device properties to check installed update present
    ///     * retrieve all updates installed on the device
    ///     * delete the update
    ///     * retrieve the deleted update and check that we get 404 (NotFound)
    /// </summary>
    public class Sample
    {
        private const int DefaultRetryAfterValue = 5000;
        private const string SimulatorProvider = "Contoso";
        private const string SimulatorModel = "Virtual-Machine";
        private const string BlobContainer = "test";

        private readonly string _accountEndpoint;
        private readonly string _instanceId;
        private readonly string _connectionString;
        private readonly string _deviceId;
        private readonly string _deviceTag;
        private readonly bool _delete;

        private readonly UpdatesClient _updatesClient; 
        private readonly DevicesClient _devicesClient; 
        private readonly DeploymentsClient _deploymentsClient;

        /// <summary>
        /// Initializes a new instance of the Sample class.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="tenantId">Identifier for the tenant.</param>
        /// <param name="clientId">Identifier for the client.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="accountEndpoint">The account endpoint.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="deviceId">Identifier for the device.</param>
        /// <param name="deviceTag">Device tag.</param>
        /// <param name="delete">Boolean flag to indicate whether the update should be deleted when finished.</param>
        public Sample(string tenantId, string clientId, string clientSecret, string accountEndpoint, string instance, string connectionString, string deviceId, string deviceTag, bool delete)
        {
            if (tenantId == null)
            {
                throw new ArgumentNullException(nameof(tenantId));
            }
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            if (clientSecret == null)
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            _accountEndpoint = accountEndpoint ?? throw new ArgumentNullException(nameof(accountEndpoint));
            _instanceId = instance ?? throw new ArgumentNullException(nameof(instance));
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _deviceId = deviceId ?? throw new ArgumentNullException(nameof(deviceId));
            _deviceTag = deviceTag ?? throw new ArgumentNullException(nameof(deviceTag));
            _delete = delete;

            var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);

            _updatesClient = new UpdatesClient(accountEndpoint, instance, credentials);
            _devicesClient = new DevicesClient(accountEndpoint, instance, credentials);
            _deploymentsClient = new DeploymentsClient(accountEndpoint, instance, credentials);
        }

        /// <summary>
        /// Run all the sample steps asynchronously.
        /// </summary>
        /// <returns>
        /// An asynchronous result.
        /// </returns>
        public async Task RunAsync()
        {
            var provider = SimulatorProvider;
            var name = SimulatorModel;
            var version = DateTime.Now.ToString("yyyy.Mdd.Hmm.s");

            // Publish new update
            var jobId = await ImportUpdateStepAsync(version);

            // Retrieve the newly imported update
            await RetrieveUpdateStepAsync(provider, name, version);

            // Create deployment/device group
            string groupId = await CreateDeploymentGroupStepAsync();

            // Check that device group contains devices that can be updated with our new update
            await CheckGroupDevicesAreUpToDateStepAsync(groupId, provider, name, version, isCompliant:false);

            // Create deployment for our device group to deploy our new update
            string deploymentId = await DeployUpdateStepAsync(provider, name, version, groupId);

            // Check device and wait until the new update is installed there
            await CheckDeviceUpdateStepAsync(provider, name, version);

            // Check that device group contains *NO* devices that can be updated with our new update
            await CheckGroupDevicesAreUpToDateStepAsync(groupId, provider, name, version, isCompliant: true);

            if (_delete)
            {
                // Delete the update
                await DeleteUpdateStepAsync(provider, name, version);

                // Retrieve the deleted update and check that we get 404 (NotFound)
                await RetrieveUpdateStepAsync(provider, name, version, notFoundExpected: true);
            }

            // Dump test data to be used for unit-testing
            OutputTestData(version, jobId, deploymentId);
        }

        private async Task<string> ImportUpdateStepAsync(string version)
        {
            ContentFactory contentFactory = new ContentFactory(_connectionString, BlobContainer);
            ImportUpdateInput update = await contentFactory.CreateImportUpdate(SimulatorProvider, SimulatorModel, version);

            ConsoleEx.WriteLine(ConsoleColor.Yellow, "Importing update...");
            Response<string> operationIdResponse = await _updatesClient.ImportUpdateAsync(update);
            Console.WriteLine($"Import operation id: {operationIdResponse.Value}");

            Console.WriteLine("Waiting for import to finish...");
            Console.WriteLine("(this may take a minute or two)");
            bool repeat = true;
            while (repeat)
            {
                Response<Operation> operationResponse = await _updatesClient.GetOperationAsync(operationIdResponse.Value);
                if (operationResponse.Value.Status == OperationStatus.Succeeded)
                {
                    Console.WriteLine(operationResponse.Value.Status);
                    repeat = false;
                }
                else if (operationResponse.Value.Status == OperationStatus.Failed)
                {
                    throw new ApplicationException("Import failed with error: \n" + JsonConvert.SerializeObject(operationResponse.Value.Error, Formatting.Indented));
                }
                else
                {
                    Console.Write(".");
                    await Task.Delay(GetRetryAfterFromResponse(operationIdResponse));
                }
            }

            Console.WriteLine();
            return operationIdResponse.Value;
        }

        private async Task RetrieveUpdateStepAsync(string provider, string name, string version, bool notFoundExpected = false)
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "Retrieving update...");
            try
            {
                Response<Update> response = await _updatesClient.GetUpdateAsync(provider, name, version);
                if (notFoundExpected)
                {
                    throw new ApplicationException($"Service returned valid update even though NotFound response was expected");
                }
                Console.WriteLine(JsonConvert.SerializeObject(response.Value, Formatting.Indented));
            }
            catch (RequestFailedException e)
            {
                if (notFoundExpected && e.Status == (int)HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Received an expected NotFound response");
                }
                else
                {
                    throw new ApplicationException($"Service returned unexpected error status code: {e.Status}", e);
                }
            }

            Console.WriteLine();
        }

        private async Task<string> CreateDeploymentGroupStepAsync()
        {
            string groupId = _deviceTag;
            bool createNewGroup = false;

            ConsoleEx.WriteLine(ConsoleColor.Yellow, "Querying deployment group...");
            try
            {
                Response<Group> groupResponse = await _devicesClient.GetGroupAsync(groupId);
                Console.WriteLine($"Deployment group {groupId} already exists.");
            }
            catch (RequestFailedException e)
            {
                if (e.Status == (int)HttpStatusCode.NotFound)
                {
                    createNewGroup = true;
                }
            }

            if (createNewGroup)
            {
                ConsoleEx.WriteLine(ConsoleColor.Yellow, "Creating deployment group...");
                Response<Group> groupResponse = await _devicesClient.CreateOrUpdateGroupAsync(
                                                    groupId,
                                                    new Group(
                                                        groupId,
                                                        GroupType.IoTHubTag,
                                                        new[]
                                                        {
                                                            groupId
                                                        },
                                                        DateTimeOffset.UtcNow.ToString()));

                if (groupResponse.Value != null)
                {
                    Console.WriteLine($"Group {groupId} created.");
                    Console.WriteLine();

                    ConsoleEx.WriteLine(ConsoleColor.Yellow, "Waiting for the group to be populated with devices...");
                    Console.WriteLine("(this may take about five minutes to complete)");
                    bool repeat = true;
                    while (repeat)
                    {
                        groupResponse = await _devicesClient.GetGroupAsync(groupId);
                        if (groupResponse.Value.DeviceCount > 0)
                        {
                            Console.WriteLine($"Deployment group {groupId} now has {groupResponse.Value.DeviceCount} devices.");
                            repeat = false;
                        }
                        else
                        {
                            Console.Write(".");
                            await Task.Delay(DefaultRetryAfterValue);
                        }
                    }
                }
            }

            Console.WriteLine();
            return groupId;
        }

        private async Task CheckGroupDevicesAreUpToDateStepAsync(string groupId, string provider, string name, string version, bool isCompliant)
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, $"Check group {groupId} device compliance with update {provider}/{name}/{version}...");
            bool updateFound = false;
            int counter = 0;
            do
            {
                var groupResponse = _devicesClient.GetGroupBestUpdatesAsync(groupId);
                await foreach (UpdatableDevices updatableDevices in groupResponse)
                {
                    var update = updatableDevices.UpdateId;
                    if (update.Provider == provider && 
                        update.Name == name && 
                        update.Version == version)
                    {
                        updateFound = true;
                        if (isCompliant)
                        {
                            if (updatableDevices.DeviceCount == 0)
                            {
                                Console.WriteLine("All devices within the group have this update installed.");
                            }
                            else
                            {
                                Console.WriteLine($"There are still {updatableDevices.DeviceCount} devices that can be updated to update {provider}/{name}/{version}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"There are {updatableDevices.DeviceCount} devices that can be updated to update {provider}/{name}/{version}.");
                        }
                    }
                }

                counter++;
                if (!updateFound)
                {
                    Console.Write(".");
                    await Task.Delay(DefaultRetryAfterValue);
                }
            } while (!updateFound && counter <= 6 );

            if (!updateFound)
            {
                Console.WriteLine("Update is still not available for any group device.");
            }
            Console.WriteLine();
        }

        private async Task<string> DeployUpdateStepAsync(string provider, string name, string version, string groupId)
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "Deploying the update to a device...");
            string deploymentId = $"{_deviceId}-{version.Replace(".", "-")}";
            Response<Deployment> deployment = await _deploymentsClient.CreateOrUpdateDeploymentAsync(
                                                  deploymentId,
                                                  new Deployment(
                                                      deploymentId,
                                                      DeploymentType.Complete,
                                                      DateTimeOffset.UtcNow,
                                                      DeviceGroupType.DeviceGroupDefinitions,
                                                      new[] { groupId },
                                                      new UpdateId(provider, name, version)));
            Console.WriteLine($"Deployment '{deployment.Value.DeploymentId}' is created.");
            await Task.Delay(DefaultRetryAfterValue);
            
            Console.WriteLine("Checking the deployment status...");
            Response<DeploymentStatus> deploymentStatus = await _deploymentsClient.GetDeploymentStatusAsync(deploymentId);
            Console.WriteLine($"  {deploymentStatus.Value.DeploymentState}");

            Console.WriteLine();
            return deploymentId;
        }

        private async Task CheckDeviceUpdateStepAsync(string provider, string name, string version)
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, $"Checking device {_deviceId} status...");
            Console.WriteLine("Waiting for the update to be installed...");
            var repeat = true;
            while (repeat)
            {
                Response<Device> deviceResponse = await _devicesClient.GetDeviceAsync(_deviceId);
                var installedUpdateId = deviceResponse.Value.InstalledUpdateId;
                if (installedUpdateId != null && 
                    installedUpdateId.Provider == provider &&
                    installedUpdateId.Name == name && 
                    installedUpdateId.Version == version)
                {
                    repeat = false;
                }
                else
                {
                    Console.Write(".");
                    await Task.Delay(DefaultRetryAfterValue);
                }
            }

            Console.WriteLine();
        }

        private async Task DeleteUpdateStepAsync(string provider, string name, string version)
        {
            Console.WriteLine("Deleting the update...");
            Response<string> operationIdResponse = await _updatesClient.DeleteUpdateAsync(provider, name, version);
            Console.WriteLine($"Delete operation id: {operationIdResponse.Value}");

            Console.WriteLine("Waiting for delete to finish...");
            var repeat = true;
            while (repeat)
            {
                Response<Operation> operationResponse = await _updatesClient.GetOperationAsync(operationIdResponse.Value);
                if (operationResponse.Value.Status == OperationStatus.Succeeded)
                {
                    Console.WriteLine();
                    repeat = false;
                }
                else if (operationResponse.Value.Status == OperationStatus.Failed)
                {
                    throw new ApplicationException("Delete failed with error: \n" + JsonConvert.SerializeObject(operationResponse.Value.Error, Formatting.Indented));
                }
                else
                {
                    Console.Write(".");
                    await Task.Delay(GetRetryAfterFromResponse(operationIdResponse));
                }
            }
        }

        private void OutputTestData(string version, string operationId, string deploymentId)
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "Test data to use when running SDK unit tests:");
            Console.WriteLine($"$env:DEVICEUPDATE_ACCOUNT_ENDPOINT=\"{_accountEndpoint}\"");
            Console.WriteLine($"$env:DEVICEUPDATE_INSTANCE_ID=\"{_instanceId}\"");
            Console.WriteLine($"$env:DEVICEUPDATE_UPDATE_VERSION=\"{version}\"");
            Console.WriteLine($"$env:DEVICEUPDATE_UPDATE_OPERATION=\"{operationId}\"");
            Console.WriteLine($"$env:DEVICEUPDATE_DEVICE_ID=\"{_deviceId}\"");
            Console.WriteLine($"$env:DEVICEUPDATE_GROUP_ID=\"{_deviceTag}\"");
            Console.WriteLine($"$env:DEVICEUPDATE_DEPLOYMENT_ID=\"{deploymentId}\"");
            Console.WriteLine();
            Console.WriteLine("Set these environment variables before opening and running SDK unit tests.");


            Console.WriteLine();
        }

        private static int GetRetryAfterFromResponse(Response<string> jobIdResponse)
        {
            if (jobIdResponse.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
            {
                return Convert.ToInt32(value) * 1000;
            }
            else
            {
                return DefaultRetryAfterValue;
            }
        }
    }
}
