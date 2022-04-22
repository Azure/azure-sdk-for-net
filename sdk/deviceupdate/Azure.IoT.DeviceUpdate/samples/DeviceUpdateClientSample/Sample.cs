// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.IoT.DeviceUpdate;
using Newtonsoft.Json;

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

        private readonly DeviceUpdateClient _updatesClient;
        private readonly DeviceManagementClient _managementClient;
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

            _updatesClient = new DeviceUpdateClient(accountEndpoint, instance, credentials);
            _managementClient = new DeviceManagementClient(accountEndpoint, instance, credentials);
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
            await CheckDeviceUpdateStepAsync(groupId, provider, name, version);

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
            await contentFactory.CreateImportUpdate(SimulatorProvider, SimulatorModel, version);

            ConsoleEx.WriteLine(ConsoleColor.Yellow, "Importing update...");
            string action = "import";
            var updateToImport = new
            {
                importManifest = new
                {
                    url = "http://test.blob.core.windows.net/test/uploadimportMan.json",
                    sizeInBytes = 816,
                    hashes = new
                    {
                        sha256 = "O19LyyncPe1AGstOdkcmozLV8pSbBdqrE18HdYVohRc="
                    },
                },
                files = new Object[3] {
                    new
                    {
                        filename = "file1.bin",
                        url = "http://test.blob.core.windows.net/test/upload1v5uww1q"
                    },
                    new
                    {
                        filename = "file2.bin",
                        url = "http://test.blob.core.windows.net/test/uploadkrmn5yw0"
                    },
                    new
                    {
                        filename = "file3.bin",
                        url = "http://test.blob.core.windows.net/test/uploaddq52ky5m"
                    }
                }
            };
            Operation<BinaryData> operationResponse = await _updatesClient.ImportUpdateAsync(true, action, RequestContent.Create(updateToImport), new RequestContext());
            string operationId = GetJobIdFromLocationHeader(operationResponse.GetRawResponse());
            Console.WriteLine($"Import operation id: {operationId}");

            Console.WriteLine("Waiting for import to finish...");
            Console.WriteLine("(this may take a minute or two)");
            bool repeat = true;
            while (repeat)
            {
                Response getResponse = await _updatesClient.GetOperationAsync(operationId);
                var operationDoc = JsonDocument.Parse(getResponse.Content.ToMemory());
                switch (operationDoc.RootElement.GetProperty("status").GetString())
                {
                    case "Succeeded":
                        Console.WriteLine("Succeeded");
                        repeat = false;
                        break;
                    case "Failed":
                        throw new ApplicationException("Import failed with error: \n" + JsonConvert.SerializeObject(operationDoc.RootElement.ToString(), Formatting.Indented));
                    default:
                        Console.Write(".");
                        await Task.Delay(GetRetryAfterFromResponse(getResponse));
                        break;
                }
            }

            Console.WriteLine();
            return JsonDocument.Parse(operationResponse.GetRawResponse().Content.ToMemory()).RootElement.GetProperty("operationId").ToString();
        }

        private async Task RetrieveUpdateStepAsync(string provider, string name, string version, bool notFoundExpected = false)
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "Retrieving update...");
            try
            {
                Response response = await _updatesClient.GetUpdateAsync(provider, name, version);
                if (notFoundExpected)
                {
                    throw new ApplicationException($"Service returned valid update even though NotFound response was expected");
                }
                var doc = JsonDocument.Parse(response.Content.ToMemory());
                Console.WriteLine(JsonConvert.SerializeObject(doc.ToObject(), Formatting.Indented));
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
                Response groupResponse = await _managementClient.GetGroupAsync(groupId, new RequestContext());
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
                var group = RequestContent.Create(new {
                    groupId = groupId,
                    groupType = "IoTHubTag",
                    tags = new [] {
                        groupId
                    },
					deviceClassId =  "0919e3ae422a2bfa8c84ff905813e60351e456d1",
                    createdDateTime  = DateTimeOffset.UtcNow.ToString()
                });

                Response groupResponse = await _managementClient.CreateOrUpdateGroupAsync(groupId, group);
                var groupDoc = JsonDocument.Parse(groupResponse.Content.ToMemory());

                if (groupDoc.RootElement.TryGetProperty("value", out var groupValue))
                {
                    Console.WriteLine($"Group {groupId} created.");
                    Console.WriteLine();

                    ConsoleEx.WriteLine(ConsoleColor.Yellow, "Waiting for the group to be populated with devices...");
                    Console.WriteLine("(this may take about five minutes to complete)");
                    bool repeat = true;
                    while (repeat)
                    {
                        groupResponse = await _managementClient.GetGroupAsync(groupId, new RequestContext());
                        if (groupValue.TryGetProperty("deviceCount", out var deviceCountValue) && deviceCountValue.GetInt32() > 0)
                        {
                            Console.WriteLine($"Deployment group {groupId} now has {deviceCountValue.GetInt32()} devices.");
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
                 var groupResponse = _managementClient.GetBestUpdatesForGroupsAsync(groupId);
                 await foreach (var updatableDevices in groupResponse)
                 {
                     var updatableDevicesDoc = JsonDocument.Parse(updatableDevices.ToMemory());
                     if (updatableDevicesDoc.RootElement.TryGetProperty("updateId", out var updateId))
                     {
                         if (updateId.GetProperty("provider").GetString() == provider &&
                             updateId.GetProperty("name").GetString() == name &&
                             updateId.GetProperty("version").GetString() == version)
                         {
                             updateFound = true;
                             var deviceCount = updatableDevicesDoc.RootElement.GetProperty("deviceCount").GetInt32();
                             if (isCompliant)
                             {
                                 if (deviceCount == 0)
                                 {
                                     Console.WriteLine("All devices within the group have this update installed.");
                                 }
                                 else
                                 {
                                     Console.WriteLine($"There are still {deviceCount} devices that can be updated to update {provider}/{name}/{version}.");
                                 }
                             }
                             else
                             {
                                 Console.WriteLine($"There are {deviceCount} devices that can be updated to update {provider}/{name}/{version}.");
                             }
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
			string groupid = "groupid";
            string deploymentId = $"{groupid}-{version.Replace(".", "-")}";
            var data = new
            {
                deploymentId,
                startDateTime = DateTime.UtcNow.ToString("O"),
                groupId,
                updateId = new
                {
                    manufacturer = provider,
                    name,
                    version
                }
            };
            Response deployment = await _managementClient.CreateOrUpdateDeploymentAsync(deploymentId, groupid, RequestContent.Create(data), new RequestContext());
            var deploymentDoc = JsonDocument.Parse(deployment.Content.ToMemory());

            Console.WriteLine($"Deployment '{deploymentDoc.RootElement.GetProperty("deploymentId").GetString()}' is created.");
            await Task.Delay(DefaultRetryAfterValue);
            
            Console.WriteLine("Checking the deployment status...");
            bool repeat = true;
            while (repeat)
            {
                var deploymentStatusResponse = await _managementClient.GetDeploymentStatusAsync(groupId, deploymentId);
                var deploymentStatusDoc = JsonDocument.Parse(deploymentStatusResponse.Content.ToMemory());
                if (deploymentStatusDoc.RootElement.TryGetProperty("devicesCompletedSucceededCount", out var deviceCountValue) && deviceCountValue.GetInt32() > 0)
                {
                    Console.WriteLine($"\nDeployment {deploymentId} successfully deployed to {deviceCountValue.GetInt32()} devices.");
                    repeat = false;
                }
                else
                {
                    Console.Write(".");
                    await Task.Delay(DefaultRetryAfterValue);
                }
            }
            Console.WriteLine();
            return deploymentId;
        }

        private async Task CheckDeviceUpdateStepAsync(string groupId, string provider, string name, string version)
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, $"Checking device {_deviceId} status...");
            Console.WriteLine("Waiting for the update to be installed...");
            var repeat = true;
            while (repeat)
            {
                Response deviceResponse = await _managementClient.GetDeviceAsync(_deviceId, new RequestContext());
                var deviceResponseDoc = JsonDocument.Parse(deviceResponse.Content.ToMemory());

                if (deviceResponseDoc.RootElement.TryGetProperty("installedUpdateId", out var installedUpdateId))
                {
                    if (installedUpdateId.GetProperty("provider").GetString() == provider &&
                        installedUpdateId.GetProperty("name").GetString() == name && 
                        installedUpdateId.GetProperty("version").GetString() == version)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.Write(".");
                        await Task.Delay(DefaultRetryAfterValue);
                    }
                }
            }

            Console.WriteLine();
        }

        private async Task DeleteUpdateStepAsync(string provider, string name, string version)
        {
            Console.WriteLine("Deleting the update...");
            Operation<BinaryData> operationResponse = await _updatesClient.DeleteUpdateAsync(true, provider, name, version);
            string operationId = GetJobIdFromLocationHeader(operationResponse.GetRawResponse());
            Console.WriteLine($"Delete operation id: {operationId}");

            Console.WriteLine("Waiting for delete to finish...");
            var repeat = true;
            while (repeat)
            {
                Response getResponse = await _updatesClient.GetOperationAsync(operationId);
                var operationDoc = JsonDocument.Parse(getResponse.Content.ToMemory());
                switch (operationDoc.RootElement.GetProperty("status").GetString())
                {
                    case "Succeeded":
                        Console.WriteLine();
                        repeat = false;
                        break;
                    case "Failed":
                        throw new ApplicationException("Delete failed with error: \n" + JsonConvert.SerializeObject(operationDoc.RootElement.ToString(), Formatting.Indented));
                    default:
                        Console.Write(".");
                        await Task.Delay(GetRetryAfterFromResponse(getResponse));
                        break;
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

        private static int GetRetryAfterFromResponse(Response jobIdResponse)
        {
            if (jobIdResponse.Headers.TryGetValue("Retry-After", out string value))
            {
                return Convert.ToInt32(value) * 1000;
            }
            else
            {
                return DefaultRetryAfterValue;
            }
        }

        private static string GetJobIdFromLocationHeader(Response response)
        {
            if (response.Headers.TryGetValue("Operation-Location", out string location))
            {
                string jobId = null;
                if (location != null)
                {
                    jobId = location.Split("/").Last().Split("?")[0];
                }

                return jobId;
            }

            throw new NotSupportedException();
        }
    }
}
