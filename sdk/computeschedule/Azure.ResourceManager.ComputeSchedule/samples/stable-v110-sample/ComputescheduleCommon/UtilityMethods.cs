using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ComputeSchedule;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace UtilityMethods
{
    public static class HelperMethods
    {
        // Static JSON representation for create vm operations

        private static readonly string _ = @"
            {
              ""resourceConfigParameters"": {
                ""resourceCount"": 1,
                ""baseProfile"": {
                  ""resourcegroupName"": ""computeschedule-azcliext-resources"",
                  ""computeApiVersion"": ""2023-09-01"",
                  ""location"": ""eastus2euap"",
                  ""properties"": {
                    ""vmExtensions"": [
                      {
                        ""name"": ""Microsoft.Azure.Geneva.GenevaMonitoring"",
                        ""location"": ""eastus2euap"",
                        ""properties"": {
                          ""autoUpgradeMinorVersion"": true,
                          ""enableAutomaticUpgrade"": true,
                          ""suppressFailures"": true,
                          ""publisher"": ""Microsoft.Azure.Geneva"",
                          ""type"": ""GenevaMonitoring"",
                          ""typeHandlerVersion"": ""2.0""
                        }
                      }
                    ],
                    ""hardwareProfile"": {
                      ""vmSize"": ""Standard_D2ads_v5""
                    },
                    ""storageProfile"": {
                      ""imageReference"": {
                        ""publisher"": ""MicrosoftWindowsServer"",
                        ""offer"": ""WindowsServer"",
                        ""sku"": ""2022-datacenter-azure-edition"",
                        ""version"": ""latest""
                      },
                      ""osDisk"": {
                        ""osType"": ""Windows"",
                        ""createOption"": ""FromImage"",
                        ""caching"": ""ReadWrite"",
                        ""managedDisk"": {
                          ""storageAccountType"": ""Standard_LRS""
                        },
                        ""deleteOption"": ""Detach"",
                        ""diskSizeGB"": 127
                      },
                      ""diskControllerType"": ""SCSI""
                    },
                    ""networkProfile"": {
                      ""networkInterfaceConfigurations"": [
                        {
                          ""name"": ""vmTest"",
                          ""properties"": {
                            ""primary"": true,
                            ""enableIPForwarding"": true,
                            ""ipConfigurations"": [
                              {
                                ""name"": ""vmTest"",
                                ""properties"": {
                                  ""subnet"": {
                                    ""id"": ""/subscriptions/38dcfe37-18ca-4560-b49e-4ddcd6423cc5/resourceGroups/computeschedule-azcliext-resources/providers/Microsoft.Network/virtualNetworks/kronox-vnet/subnets/default"",
                                    ""properties"": {
                                      ""defaultoutboundaccess"": false
                                    }
                                  },
                                  ""primary"": true,
                                  ""applicationGatewayBackendAddressPools"": [],
                                  ""loadBalancerBackendAddressPools"": []
                                }
                              }
                            ]
                          }
                        }
                      ],
                      ""networkApiVersion"": ""2022-07-01""
                    }
                  }
                },
                ""resourceOverrides"": [
                  {
                    ""name"": ""validvmtestTwo"",
                    ""location"": ""eastus2euap"",
                    ""properties"": {
                      ""hardwareProfile"": {
                        ""vmSize"": ""Standard_D2ads_v5""
                      },
                      ""osProfile"": {
                        ""computerName"": ""validtestTwo"",
                        ""adminUsername"": ""testUserName"",
                        ""adminPassword"": ""YourStr0ngP@ssword123!"",
                        ""windowsConfiguration"": {
                          ""provisionVmAgent"": true,
                          ""enableAutomaticUpdates"": true,
                          ""patchSettings"": {
                            ""patchMode"": ""AutomaticByPlatform"",
                            ""assessmentMode"": ""ImageDefault""
                          }
                        }
                      }
                    }
                  }
                ]
              }
            }";

        // Amount of time to wait between each polling request
        private static readonly int s_pollingIntervalInSeconds = 15;

        // Amount of time to wait before polling requests start, this is because the p50 for compute operations is approximately 2 minutes
        private static readonly int s_initialWaitTimeBeforePollingInSeconds = 30;

        // Timeout for polling operation status
        private static readonly int s_operationTimeoutInMinutes = 125;

        /// <summary>
        ///   Utility method to get the first subnet id from a virtual network  
        /// </summary>
        /// <param name="vnet">The vnet resource created.</param>
        /// <returns></returns>
        public static ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            if (vnet.Data.Properties.ToObjectFromJson() is not Dictionary<string, object> properties || !properties.TryGetValue("subnets", out var subnetsObj) || subnetsObj is not IEnumerable<object> subnets)
            {
                throw new InvalidOperationException("The virtual network does not contain any subnets.");
            }
            if (subnets.FirstOrDefault() is not IDictionary<string, object> subnet || !subnet.TryGetValue("id", out var idObj) || idObj is not string id)
            {
                throw new InvalidOperationException("The subnet does not contain a valid 'id' property.");
            }
            return new ResourceIdentifier(id);
        }

        /// <summary>
        /// Create a virtual network with a subnet for virtual machine creation.
        /// </summary>
        /// <param name="resourceGroupResource">Resource group name</param>
        /// <param name="vnetName">Proposed vnet name</param>
        /// <param name="subnetName">Proposed subnet name</param>
        /// <param name="location">Proposed location for vnet and subnet creation</param>
        /// <param name="client">ARM Client</param>
        /// <returns></returns>

        public static async Task<GenericResource> CreateVirtualNetwork(ResourceGroupResource resourceGroupResource, string subnetName, string vnetName, AzureLocation location, ArmClient client)
        {
            ResourceIdentifier vnetId = new($"{resourceGroupResource.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" },
                    { "defaultoutboundaccess", false }
                }
                }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            ArmOperation<GenericResource> operation = await client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            return operation.Value;
        }

        /// <summary>
        /// Generates a resource identifier for the subscriptionId
        /// </summary>
        /// <param name="client"></param>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public static SubscriptionResource GetSubscriptionResource(ArmClient client, string subscriptionId)
        {
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            return client.GetSubscriptionResource(subscriptionResourceId);
        }


        /// <summary>
        /// Determine if the operation state is complete
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool IsOperationTerminal(ScheduledActionOperationState? state)
        {
            return state != null &&
                (state == ScheduledActionOperationState.Succeeded ||
                state == ScheduledActionOperationState.Failed ||
                state == ScheduledActionOperationState.Cancelled);
        }

        /// <summary>
        /// Determine if polling for operation status should continue based on the response from GetOperationsRequest
        /// </summary>
        /// <param name="response"> Response from GetOperationsRequest that is used to determine if polling should continue </param>
        /// <param name="totalVmsCount">Total number of virtual machines in the initial Start/Hibernate/Deallocate operation </param>
        /// <param name="completedOps"> Dictionary of completed operations, that is, operations where state is either Succeeded, Failed, Cancelled </param>
        /// <returns></returns>
        public static bool ShouldRetryPolling(GetOperationStatusResult response, int totalVmsCount, Dictionary<string, ResourceOperationDetails> completedOps)
        {
            var shouldRetry = true;
            foreach (var operationResult in response.Results)
            {
                var operation = operationResult.Operation;
                var operationId = operation.OperationId;
                var operationState = operation.State;
                var operationError = operation.ResourceOperationError;

                Console.WriteLine($"Trying polling for operation with id {operationId}.");
                if (IsOperationTerminal(operationState))
                {
                    completedOps.TryAdd(operationId, operation);
                    Console.WriteLine($"Operation {operationId} completed with state {operationState}");

                    if (operationError != null)
                    {
                        Console.WriteLine($"Operation {operationId} encountered the following error: errorCode {operationError.ErrorCode}, errorDetails: {operationError.ErrorDetails}");
                    }
                }
            }

            // CompletedOps.Count == TotalVmsCount means that all the operations have completed and there would be no need to retry polling
            if (completedOps.Count == totalVmsCount)
            {
                shouldRetry = false;
            }
            return shouldRetry;
        }


        /// <summary>
        /// Removes the operations that have completed from the list of operations to poll
        /// </summary>
        /// <param name="completedOps"> Dictionary of completed operations, that is, operations where state is either Succeeded, Failed, Cancelled </param>
        /// <param name="allOps"></param>
        /// <returns></returns>
        private static HashSet<string?> ExcludeCompletedOperations(Dictionary<string, ResourceOperationDetails> completedOps, HashSet<string> allOps)
        {
            var incompleteOps = new HashSet<string?>(allOps);

            foreach (var op in allOps)
            {
                if (op != null && completedOps.ContainsKey(op))
                {
                    incompleteOps.Remove(op);
                }
            }
            Console.WriteLine(string.Join(", ", incompleteOps));
            return incompleteOps;
        }

        /// <summary>
        /// This method excludes resources not processed in Scheduledactions due to a number of reasons like operation conflicts,
        /// operations in a blocked state due to scenarios like outages in downstream services, internal outages etc.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static Dictionary<string, ResourceIdentifier?> ExcludeResourcesNotProcessed(IEnumerable<ResourceOperationResult> results)
        {
            var validOperations = new Dictionary<string, ResourceIdentifier?>();
            foreach (var result in results)
            {
                if (result.ErrorCode != null)
                {
                    Console.WriteLine($"VM with resourceId: {result.ResourceId} encountered the following error: errorCode {result.ErrorCode}, errorDetails: {result.ErrorDetails}");
                }
                else if (result.Operation.State == ScheduledActionOperationState.Blocked)
                {
                    /// Operations on virtual machines are set to blocked state in Computeschedule when there is an ongoing outage internally or in downstream services.
                    /// These operations could still be processed later as long as their due time for execution is not past deadline time + retrywindowinminutes
                    Console.WriteLine($"Operation on VM with resourceId: {result.ResourceId} is currently blocked, operation may still complete");
                }
                else
                {
                    validOperations.Add(result.Operation.OperationId, result.ResourceId);
                }
            }
            return validOperations;
        }

        /// <summary>
        /// Polls the operation status for the operations that are in not yet in completed state
        /// </summary>
        /// <param name="cts"></param>
        /// <param name="opIdsFromOperationReq"> OperationIds from execute type operations </param>
        /// <param name="completedOps"> OperationIds of completed operations </param>
        /// <param name="location"> Location of the virtual machines from execute type operations </param>
        /// <param name="resource"> ARM subscription resource </param>
        /// <returns></returns>

        public static async Task<Dictionary<string, ResourceIdentifier>> PollOperationStatus(HashSet<string> opIdsFromOperationReq, Dictionary<string, ResourceOperationDetails> completedOps, string location, SubscriptionResource resource)
        {
            await Task.Delay(s_initialWaitTimeBeforePollingInSeconds);

            GetOperationStatusContent getOpsStatusRequest = new(opIdsFromOperationReq, Guid.NewGuid().ToString());
            GetOperationStatusResult? response = await resource.GetVirtualMachineOperationStatusAsync(location, getOpsStatusRequest);

            var opIdsToResourceIds = new Dictionary<string, ResourceIdentifier>();

            // Cancellation token source is used in this case to cancel the polling operation after a certain time
            using CancellationTokenSource cts = new(TimeSpan.FromMinutes(s_operationTimeoutInMinutes));
            while (!cts.Token.IsCancellationRequested)
            {

                if (!ShouldRetryPolling(response, opIdsFromOperationReq.Count, completedOps))
                {
                    opIdsToResourceIds = response.Results.ToDictionary(x => x.Operation.OperationId, x => x.ResourceId);
                    Console.WriteLine(ModelReaderWriter.Write(response, ModelReaderWriterOptions.Json).ToString());
                    break;
                }
                else
                {
                    var incompleteOperations = ExcludeCompletedOperations(completedOps, opIdsFromOperationReq);
                    GetOperationStatusContent pendingOpIds = new(incompleteOperations, Guid.NewGuid().ToString());
                    response = await resource.GetVirtualMachineOperationStatusAsync(location, pendingOpIds);
                }

                await Task.Delay(TimeSpan.FromSeconds(s_pollingIntervalInSeconds), cts.Token);
            }

            return opIdsToResourceIds;
        }

        /// <summary>
        /// Utility method to print items in a dictionary
        /// </summary>
        /// <param name="dict"></param>
        public static void PrintDictionaryContents(IDictionary<string, BinaryData> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }


        /// <summary>
        /// Generates a resource override item for virtual machines.
        /// Computeschedule allows customers override certain properties of the base profile for each resource created.
        /// </summary>
        /// <param name="name">Name of the virtual machine</param>
        /// <param name="locationProperty">Location of the virtual machine</param>
        /// <param name="vmsize">Size of the virtual machine</param>
        /// <param name="password">Admin password for the virtual machine</param>
        /// <param name="adminUsername">Admin username for the virtual machine</param>
        public static Dictionary<string, BinaryData> GenerateResourceOverrideItem(
            string name,
            string locationProperty,
            string vmsize,
            string password,
            string adminUsername)
        {
            var resourceOverrideDetail = new Dictionary<string, BinaryData>
            {
                { "name", BinaryData.FromObjectAsJson(name) },
                { "location", BinaryData.FromObjectAsJson(locationProperty) },
                { "properties", BinaryData.FromObjectAsJson(new {
                    hardwareProfile = new {
                        vmSize = vmsize
                    },
                    osProfile = new {
                        computerName = name,
                        adminUsername = adminUsername,
                        adminPassword = password,
                        windowsConfiguration = new {
                            provisionVmAgent = true,
                            enableAutomaticUpdates = true,
                            patchSettings = new {
                                patchMode = "AutomaticByPlatform",
                                assessmentMode = "ImageDefault"
                            }
                        }
                    }
                })
                }
            };

            return resourceOverrideDetail;
        }

        /// <summary>
        /// Builds the execute create request content for virtual machines
        /// </summary>
        /// <param name="resourcePrefix">Resource prefix for the virtual machines</param>
        /// <param name="correlationId">Correlation ID for the request</param>
        /// <param name="resourceCount">Number of virtual machines to create</param>
        /// <param name="executionParameter">Execution parameters for the request</param>
        /// <param name="rgName">Resource group name</param>
        /// <param name="vnetName">Virtual network name</param>
        /// <param name="subnetName">Subnet name</param>
        /// <param name="azureLocation">Azure location</param>
        /// <param name="resourceOverrideDetail">Resource override details</param>
        public static ExecuteCreateContent BuildExecuteCreateRequest(
            string resourcePrefix,
            string correlationId,
            int resourceCount,
            ScheduledActionExecutionParameterDetail executionParameter,
            string rgName,
            string vnetName,
            string subnetName,
            string azureLocation,
            List<Dictionary<string, BinaryData>> resourceOverrideDetail,
            string subId,
            bool enableResourceOverride = false)
        {
            var payload = new ResourceProvisionPayload(resourceCount)
            {
                ResourcePrefix = resourcePrefix,
                BaseProfile =
                {
                    { "resourcegroupName", BinaryData.FromObjectAsJson(rgName) },
                    { "computeApiVersion", BinaryData.FromObjectAsJson("2023-09-01") },
                    { "location", BinaryData.FromObjectAsJson(azureLocation) },
                    { "properties", BinaryData.FromObjectAsJson(new {
                        vmExtensions = new[]{
                            new {
                                name = "Microsoft.Azure.Geneva.GenevaMonitoring",
                                location = azureLocation,
                                properties = new {
                                    publisher = "Microsoft.Azure.Geneva",
                                    type = "GenevaMonitoring",
                                    typeHandlerVersion = "2.0",
                                    autoUpgradeMinorVersion = true,
                                    enableAutomaticUpgrade = true,
                                    suppressFailures = true
                                }
                            }
                        },
                        osProfile = new {
                            computerName = $"{resourcePrefix}defaultvm",
                            adminUsername = "adminUser",
                            adminPassword = "adminUserPassword@@",
                            windowsConfiguration = new {
                                provisionVmAgent = true,
                                enableAutomaticUpdates = true,
                                patchSettings = new {
                                    patchMode = "AutomaticByPlatform",
                                    assessmentMode = "ImageDefault"
                                }
                            }
                        },
                        hardwareProfile = new {
                            vmSize = "Standard_D2s_v3"
                        },
                        storageProfile = new {
                            imageReference = new {
                                publisher = "MicrosoftWindowsServer",
                                offer = "WindowsServer",
                                sku = "2022-datacenter-azure-edition",
                                version = "latest"
                            },
                            osDisk = new {
                                createOption = "FromImage",
                                osType = "Windows",
                                caching = "ReadWrite",
                                managedDisk = new {
                                    storageAccountType = "Standard_LRS"
                                },
                                deleteOption = "Detach",
                                diskSizeGB = 127,
                            }
                        },
                        networkProfile = new {
                            networkApiVersion = "2022-07-01",
                            networkInterfaceConfigurations = new[] {
                                new {
                                    name = "vmTest",
                                    properties = new {
                                        primary = true,
                                        enableIPForwarding = true,
                                        ipConfigurations = new[] {
                                            new {
                                                name = "vmTest",
                                                properties = new {
                                                    primary = true,
                                                    subnet = new {
                                                        id = $"/subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}",
                                                        properties = new {
                                                            defaultoutboundaccess = false,
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    })
                    }
                }
            };

            if (enableResourceOverride && resourceOverrideDetail.Count > 0)
            {
                foreach (var overrideDict in resourceOverrideDetail)
                {
                    payload.ResourceOverrides.Add(overrideDict);
                }
            }

            return new ExecuteCreateContent(payload, executionParameter)
            {
                CorrelationId = correlationId
            };
        }


        /// <summary>
        /// Builds the execute create request content from JSON body for virtual machines
        /// </summary>
        /// <param name="jsonContent">JSON content for the request</param>
        /// <param name="resourcePrefix">Resource prefix for the virtual machines</param>
        /// <param name="correlationId">Correlation ID for the request</param>
        /// <param name="resourceCount">Number of virtual machines to create</param>
        /// <param name="executionParameter">Execution parameters for the request</param>
        public static ExecuteCreateContent BuildExecuteCreateRequestFromJsonContent(
            string jsonContent,
            string resourcePrefix,
            string correlationId,
            int resourceCount,
            ScheduledActionExecutionParameterDetail executionParameter)
        {
            var root = JsonNode.Parse(jsonContent)!;

            var resourceConfig = root["resourceConfigParameters"]!;
            var baseProfileNode = resourceConfig["baseProfile"]!;
            var resourceOverridesNode = resourceConfig["resourceOverrides"]?.AsArray() ?? [];

            var payload = new ResourceProvisionPayload(resourceCount)
            {
                ResourcePrefix = resourcePrefix
            };

            foreach (var prop in baseProfileNode.AsObject())
            {
                payload.BaseProfile[prop.Key] = BinaryData.FromObjectAsJson(prop.Value!.Deserialize<object>());
            }

            foreach (var overrideNode in resourceOverridesNode)
            {
                var overrideDict = new Dictionary<string, BinaryData>();
                foreach (var prop in overrideNode!.AsObject())
                {
                    overrideDict[prop.Key] = BinaryData.FromObjectAsJson(prop.Value!.Deserialize<object>());
                }
                payload.ResourceOverrides.Add(overrideDict);
            }

            return new ExecuteCreateContent(payload, executionParameter)
            {
                CorrelationId = correlationId
            };
        }
    }
}
