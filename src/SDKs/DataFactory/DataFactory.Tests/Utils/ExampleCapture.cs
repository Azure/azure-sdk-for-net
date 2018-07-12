// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Rm = Microsoft.Azure.Management.Resources;

namespace DataFactory.Tests.Utils
{
    public class ExampleCapture
    {
        private const string integrationRuntimeName = "exampleIntegrationRuntime";
        private const string managedIntegrationRuntimeName = "exampleManagedIntegrationRuntime";
        private const string linkedServiceName = "exampleLinkedService";
        private const string triggerName = "exampleTrigger";
        private const string datasetName = "exampleDataset";
        private const string pipelineName = "examplePipeline";
        private const string outputBlobName = "exampleoutput.csv";
        private ExampleSecrets secrets;
        private string outputFolder;
        private string outputFolderWorkarounds;

        private IAuthorizationManagementClient authClient;
        private IDataFactoryManagementClient client;
        private Rm.IResourceManagementClient rmClient;
        private ExampleTracingInterceptor interceptor;

        private string roleAssignmentName = Guid.NewGuid().ToString();

        public ExampleCapture(string secretsFile, string outputFolder, string outputFolderWorkarounds = null)
        {
            this.secrets = ExampleHelpers.ReadSecretsFile(secretsFile);
            this.outputFolder = outputFolder;
            this.outputFolderWorkarounds = outputFolderWorkarounds;
            this.client = ExampleHelpers.GetRealClient(secrets);
            this.rmClient = ExampleHelpers.GetRealRmClient(secrets);
            this.authClient = ExampleHelpers.GetAuthorizationClient(secrets);
            this.interceptor = new ExampleTracingInterceptor(client.SubscriptionId, client.ApiVersion);
            ServiceClientTracing.AddTracingInterceptor(interceptor);
        }        

        public void CaptureAllExamples()
        {
            // Note: This should take under two minutes if everything works as expected
            try
            {
                // Delete factory if it exists, before turning on tracing, to give consistent clean state for capture
                EnsureResourceGroupExists();
                EnsureFactoryDoesNotExist();
                ServiceClientTracing.IsEnabled = true;

                // Start Factories operations, leaving factory available
                CaptureFactories_CreateOrUpdate(); // 200
                CaptureFactories_Update(); // 200
                CaptureFactories_ConfigureRepo(); // 200
                CaptureFactories_Get(); // 200
                CaptureFactories_ListByResourceGroup(); // 200
                CaptureFactories_List();

                // All Integration runtime operations, creating/deleting integration runtime
                CaptureIntegrationRuntimes_Create(); // 200
                // Before running this method, please make sure the SQL Database "SSISDB" does *NOT* exist in yandongeverest.database.windows.net by SSMS,
                // otherwise the operation will fail. The connection string for this server could be found in GetIntegrationRuntimeResource().
                // Note this operation is quite time consuming, normally it will take more than 30 minutes to finish the starting process.
                CaptureIntegrationRuntimes_Start(); // 200, 202
                CaptureIntegrationRuntimes_Stop(); // 200, 202
                CaptureIntegrationRuntimes_Update(); // 200
                CaptureIntegrationRuntimes_Get(); // 200
                CaptureIntegrationRuntimes_ListByFactory(); // 200
                CaptureIntegrationRuntimes_GetConnectionInfo(); // 200
                CaptureIntegrationRuntimes_ListAuthKeys(); // 200
                CaptureIntegrationRuntimes_RegenerateAuthKey(); // 200
                CaptureIntegrationRuntimes_GetStatus(); // 200
                CaptureIntegrationRuntimes_Upgrade();

                // The following 3 methods invovling a mannual step as prerequisites. We need to install an integration runtime node and register it.
                // After the integration runtime node is online, we can run methods.
                CaptureIntegrationRuntimeNodes_GetIpAddress();
                CaptureIntegrationRuntimeNodes_Update(); // 200
                CaptureIntegrationRuntimeNodes_Delete(); // 200
                CaptureIntegrationRuntimeNodes_Delete(); // 204

                // Start LinkedServices operations, leaving linked service available
                CaptureLinkedServices_Create(); // 200
                CaptureLinkedServices_Update(); // 200
                CaptureLinkedServices_Get(); // 200
                CaptureLinkedServices_ListByFactory(); // 200

                // Start Datasets operations, leaving dataset available
                CaptureDatasets_Create(); // 200
                CaptureDatasets_Update(); // 200
                CaptureDatasets_Get(); // 200
                CaptureDatasets_ListByFactory(); // 200

                // All Pipelines and PipelineRuns operations, creating/running/monitoring/deleting pipeline
                CapturePipelines_Create(); // 200
                CapturePipelines_Update(); // 200
                CapturePipelines_Get(); // 200
                CapturePipelines_ListByFactory(); // 200
                DateTime beforeStartTime = DateTime.UtcNow.AddMinutes(-1); // allow 1 minute for clock skew
                string runId = CapturePipelines_CreateRun(); // 200
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(120)); // Prefer to get succeeded monitoring result on first attempt even if it slows capture
                DateTime afterEndTime = DateTime.UtcNow.AddMinutes(10); // allow 10 minutes for run time, monitoring latency, and clock skew
                CapturePipelineRuns_Cancel();

                CapturePipelineRuns_QueryByFactory(runId, beforeStartTime, afterEndTime); // 200, waits until succeeded so ready to get logs
                CapturePipelineRuns_Get(runId); // 200
                CaptureActivityRuns_QueryByPipelineRun(runId, beforeStartTime, afterEndTime); // 200

                // Start Trigger operations, leaving triggers available
                CaptureTriggers_Create(); // 200
                CaptureTriggers_Update(); // 200
                CaptureTriggers_Get(); // 200
                CaptureTriggers_Start(); // 202
                CaptureTriggers_ListByFactory(); // 200
                CaptureTriggerRuns_QueryByFactory(beforeStartTime, afterEndTime); // 200
                CaptureTriggers_Stop(); // 202

                // Finish Triggers operations, deleting triggers
                CaptureTriggers_Delete(); // 200
                CaptureTriggers_Delete(); // 204

                CapturePipelines_Delete(); // 200
                CapturePipelines_Delete(); // 204

                // Finish Datasets operations, deleting dataset
                CaptureDatasets_Delete(); // 200
                CaptureDatasets_Delete(); // 204

                // Finish LinkedServices operations, deleting linked service
                CaptureLinkedServices_Delete(); // 200
                CaptureLinkedServices_Delete(); // 204

                // Finish integration runtime operations, deleting integration runtime
                CaptureIntegrationRuntimes_Delete(); // 202
                CaptureIntegrationRuntimes_Delete(); // 204

                // Finish Factories operations, deleting factory
                CaptureFactories_Delete(); // 200
                CaptureFactories_Delete(); // 204

                CaptureOperations_List(); // 200
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ServiceClientTracing.IsEnabled = false;
                ServiceClientTracing.RemoveTracingInterceptor(this.interceptor);
                // Merge and write all captured examples, whether or not the entire run was successful
                List<Example> examples = ExampleHelpers.GetMergedExamples(interceptor);
                ExampleHelpers.FixExampleModelParameters(examples, client);
                ExampleHelpers.WriteExamples(examples, outputFolder, secrets);
                if (outputFolderWorkarounds != null)
                {
                    ExampleHelpers.ApplyTemporaryWorkaroundsForServiceDefects(examples, client);
                    ExampleHelpers.WriteExamples(examples, outputFolderWorkarounds, secrets);
                }
            }
        }

        private void EnsureResourceGroupExists()
        {
            if (rmClient != null)
            {
                // rmClient will be null in nightly aka direct access case.
                AzureOperationResponse<Rm.Models.ResourceGroup> response = rmClient.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(secrets.ResourceGroupName, new Rm.Models.ResourceGroup(secrets.FactoryLocation)).Result;
                if (!response.Response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(string.Format("Couldn't create resource group: {0}", response));
                }
            }
        }

        private void EnsureFactoryDoesNotExist()
        {
            try
            {
                client.Factories.Delete(secrets.ResourceGroupName, secrets.FactoryName);
                client.Factories.Delete(secrets.ResourceGroupName, secrets.FactoryName + "-linked");
            }
            catch (CloudException)
            {
                // in direct access case might get exception rather than 204 since rg doesn't exist
            }
            bool gone = false;
            do
            {
                try
                {
                    client.Factories.Get(secrets.ResourceGroupName, secrets.FactoryName);
                }
                catch (CloudException e)
                {
                    if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        gone = true;
                    }
                }
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            } while (!gone);
        }

        private void CaptureFactories_CreateOrUpdate()
        {
            interceptor.CurrentExampleName = "Factories_CreateOrUpdate";
            Factory resource = client.Factories.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName,
                new Factory
                {
                    Identity = new FactoryIdentity(),
                    Location = secrets.FactoryLocation
                });
        }

        private void CaptureFactories_Update()
        {
            // Issue: For update, service requires location to be specified and also to match existing location
            interceptor.CurrentExampleName = "Factories_Update";
            var tags = new Dictionary<string, string>
            {
                { "exampleTag", "exampleValue" }
            };
            Factory resource = client.Factories.Update(secrets.ResourceGroupName, secrets.FactoryName, new FactoryUpdateParameters { Tags = tags });
        }

        private void CaptureFactories_ConfigureRepo()
        {
            interceptor.CurrentExampleName = "Factories_ConfigureFactoryRepo";
            var repoUpdate = new FactoryRepoUpdate()
            {
                FactoryResourceId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DataFactory/factories/{2}", secrets.SubId, secrets.ResourceGroupName, secrets.FactoryName),
                RepoConfiguration = new FactoryVSTSConfiguration()
                {
                    AccountName = "ADF",
                    ProjectName= "project",
                    RepositoryName= "repo",
                    CollaborationBranch= "master",
                    RootFolder= "/",
                    LastCommitId= "",
                    TenantId= ""
                }
            };
            Factory resource = client.Factories.ConfigureFactoryRepo(secrets.FactoryLocation, repoUpdate);
        }

        private void CaptureFactories_Get()
        {
            interceptor.CurrentExampleName = "Factories_Get";
            Factory resource = client.Factories.Get(secrets.ResourceGroupName, secrets.FactoryName);
        }

        private void CaptureFactories_ListByResourceGroup()
        {
            interceptor.CurrentExampleName = "Factories_ListByResourceGroup";
            IPage<Factory> page = client.Factories.ListByResourceGroup(secrets.ResourceGroupName);
        }

        private void CaptureFactories_List()
        {
            interceptor.CurrentExampleName = "Factories_List";
            IPage<Factory> page = client.Factories.List();
        }

        private void CaptureFactories_Delete()
        {
            interceptor.CurrentExampleName = "Factories_Delete";
            client.Factories.Delete(secrets.ResourceGroupName, secrets.FactoryName);
        }

        private IntegrationRuntimeResource GetIntegrationRuntimeResource(string type, string description, string location = null, string resourceId = null)
        {
            if (type.Equals("Managed", StringComparison.OrdinalIgnoreCase))
            {
                return new IntegrationRuntimeResource
                {
                    Properties = new ManagedIntegrationRuntime
                    {
                        Description = description,
                        ComputeProperties = new IntegrationRuntimeComputeProperties
                        {
                            NodeSize = "Standard_D1_v2",
                            MaxParallelExecutionsPerNode = 1,
                            NumberOfNodes = 1,
                            Location = location
                        },
                        SsisProperties = new IntegrationRuntimeSsisProperties
                        {
                            CatalogInfo = new IntegrationRuntimeSsisCatalogInfo
                            {
                                CatalogAdminUserName = this.secrets.CatalogAdminUsername,
                                CatalogAdminPassword = new SecureString(this.secrets.CatalogAdminPassword),
                                CatalogServerEndpoint = this.secrets.CatalogServerEndpoint,
                                CatalogPricingTier = "Basic"
                            }
                        }
                    }
                };
            }
            else if (type.Equals("SelfHosted", StringComparison.OrdinalIgnoreCase))
            {
                return new IntegrationRuntimeResource
                {
                    Properties = new SelfHostedIntegrationRuntime
                    {
                        Description = description
                    }
                };
            }
            else if (type.Equals("Linked", StringComparison.OrdinalIgnoreCase))
            {
                return new IntegrationRuntimeResource
                {
                    Properties = new SelfHostedIntegrationRuntime()
                    {
                        Description = description,
                        LinkedInfo = new LinkedIntegrationRuntimeRbacAuthorization()
                        {
                            ResourceId = resourceId
                        }
                    }
                };
            }
            else
            {
                throw new ArgumentException("Not supported integration runtime type.");
            }
        }

        private void CaptureIntegrationRuntimes_Create()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_Create";
            IntegrationRuntimeResource resource = client.IntegrationRuntimes.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName,
                GetIntegrationRuntimeResource("SelfHosted", "A selfhosted integration runtime"));
        }

        private void CaptureIntegrationRuntimes_Update()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_Update";
            IntegrationRuntimeResource response = client.IntegrationRuntimes.Update(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName,
                new UpdateIntegrationRuntimeRequest
                {
                    AutoUpdate = IntegrationRuntimeAutoUpdate.Off,
                    UpdateDelayOffset = SafeJsonConvert.SerializeObject(TimeSpan.FromHours(3), client.SerializationSettings)
                });
        }

        private void CaptureIntegrationRuntimes_Get()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_Get";
            IntegrationRuntimeResource resource = client.IntegrationRuntimes.Get(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);
        }

        private void CaptureIntegrationRuntimes_Delete()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_Delete";
            client.IntegrationRuntimes.Delete(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);
        }

        private void CaptureIntegrationRuntimes_ListByFactory()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_ListByFactory";
            IPage<IntegrationRuntimeResource> resources = client.IntegrationRuntimes.ListByFactory(secrets.ResourceGroupName, secrets.FactoryName);
        }

        private void CaptureIntegrationRuntimes_GetStatus()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_GetStatus";
            IntegrationRuntimeStatusResponse resource = client.IntegrationRuntimes.GetStatus(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);
        }

        private void CaptureIntegrationRuntimes_GetConnectionInfo()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_GetConnectionInfo";
            IntegrationRuntimeConnectionInfo connInfo = client.IntegrationRuntimes.GetConnectionInfo(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);
        }

        private void CaptureIntegrationRuntimes_ListAuthKeys()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_ListAuthKeys";
            IntegrationRuntimeAuthKeys key = client.IntegrationRuntimes.ListAuthKeys(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);
        }

        private void CaptureIntegrationRuntimes_RegenerateAuthKey()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_RegenerateAuthKey";
            IntegrationRuntimeAuthKeys key = client.IntegrationRuntimes.RegenerateAuthKey(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName, new IntegrationRuntimeRegenerateKeyParameters { KeyName = "authKey2"});
        }

        private void CaptureIntegrationRuntimes_Start()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_Start";

            ServiceClientTracing.IsEnabled = false;
            client.IntegrationRuntimes.CreateOrUpdate(
                secrets.ResourceGroupName,
                secrets.FactoryName,
                managedIntegrationRuntimeName,
                GetIntegrationRuntimeResource("Managed", "A managed reserved integration runtime", "West US"));
            ServiceClientTracing.IsEnabled = true;

            client.IntegrationRuntimes.Start(secrets.ResourceGroupName, secrets.FactoryName, managedIntegrationRuntimeName);
        }

        private void CaptureIntegrationRuntimes_Stop()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_Stop";
            client.IntegrationRuntimes.Stop(secrets.ResourceGroupName, secrets.FactoryName, managedIntegrationRuntimeName);

            ServiceClientTracing.IsEnabled = false;
            client.IntegrationRuntimes.Delete(secrets.ResourceGroupName, secrets.FactoryName, managedIntegrationRuntimeName);
            ServiceClientTracing.IsEnabled = true;
        }

        private void CaptureIntegrationRuntimes_Upgrade()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_Upgrade";

            client.IntegrationRuntimes.Upgrade(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);
        }

        private void CaptureIntegrationRuntimeNodes_Update()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimeNodes_Update";

            SelfHostedIntegrationRuntimeNode response = client.IntegrationRuntimeNodes.Update(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName, "Node_1",
                new UpdateIntegrationRuntimeNodeRequest
                {
                    ConcurrentJobsLimit = 2
                });
        }

        private void CaptureIntegrationRuntimeNodes_Delete()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimeNodes_Delete";

            client.IntegrationRuntimeNodes.Delete(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName, "Node_1");
        }

        private void CaptureIntegrationRuntimeNodes_GetIpAddress()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimeNodes_GetIpAddress";

            client.IntegrationRuntimeNodes.GetIpAddress(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName, "YANZHANG-02");
        }

        private void CaptureIntegrationRuntimes_GrantPermission()
        {
            ServiceClientTracing.IsEnabled = false;
            IntegrationRuntimeResource origIntegrationRuntime = client.IntegrationRuntimes.Get(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);
            Factory LinkedFactory = client.Factories.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName + "-linked",
                new Factory
                {
                    Identity = new FactoryIdentity(),
                    Location = secrets.FactoryLocation
                });

            Task.Delay(TimeSpan.FromSeconds(30)).Wait();

            // Create role assignment
            authClient.RoleAssignments.Create(
                origIntegrationRuntime.Id,
                roleAssignmentName,
                new RoleAssignmentCreateParameters()
                {
                    // Contributor
                    RoleDefinitionId =
                        "/providers/Microsoft.Authorization/roleDefinitions/b24988ac-6180-42a0-ab88-20f7382dd24c",
                    PrincipalId = LinkedFactory.Identity.PrincipalId.Value.ToString()
                });

            ServiceClientTracing.IsEnabled = true;
        }

        private void CaptureIntegrationRuntimes_RevokePermission()
        {
            ServiceClientTracing.IsEnabled = false;
            Factory LinkedFactory = client.Factories.Get(secrets.ResourceGroupName, secrets.FactoryName + "-linked");
            IntegrationRuntimeResource origIntegrationRuntime = client.IntegrationRuntimes.Get(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);

            authClient.RoleAssignments.Delete(origIntegrationRuntime.Id, roleAssignmentName);

            client.Factories.Delete(secrets.ResourceGroupName, secrets.FactoryName + "-linked");
            ServiceClientTracing.IsEnabled = true;
        }

        private void CaptureIntegrationRuntimes_CreateLinkedIntegrationRuntime()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_CreateLinkedIntegrationRuntime";

            ServiceClientTracing.IsEnabled = false;
            IntegrationRuntimeResource resource = client.IntegrationRuntimes.Get(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName);

            ServiceClientTracing.IsEnabled = true;
            IntegrationRuntimeResource resource2 = client.IntegrationRuntimes.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName + "-linked", integrationRuntimeName + "-linked",
                GetIntegrationRuntimeResource(type: "Linked", description: "A Linked integration runtime", resourceId: resource.Id));
        }

        private void CaptureIntegrationRuntimes_GetLinkedIntegrationRuntime()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_GetLinkedIntegrationRuntime";
            IntegrationRuntimeResource resource = client.IntegrationRuntimes.Get(secrets.ResourceGroupName, secrets.FactoryName + "-linked", integrationRuntimeName + "-linked");
        }

        private void CaptureIntegrationRuntimes_GetStatusLinkedIntegrationRuntime()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_GetStatusLinkedIntegrationRuntime";
            IntegrationRuntimeStatusResponse response = client.IntegrationRuntimes.GetStatus(secrets.ResourceGroupName, secrets.FactoryName + "-linked", integrationRuntimeName + "-linked");
        }

        private void CaptureIntegrationRuntimes_UpdateLinkedIntegrationRuntime()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_UpdateLinkedIntegrationRuntime";

            IntegrationRuntimeResource resource2 = client.IntegrationRuntimes.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName + "-linked", integrationRuntimeName + "-linked",
                GetIntegrationRuntimeResource(type: "Linked", description: "A Linked integration runtime"));
        }

        private void CaptureIntegrationRuntimes_DeleteLinkedIntegrationRuntime()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_DeleteLinkedIntegrationRuntime";
            try
            {
                client.IntegrationRuntimes.Delete(secrets.ResourceGroupName, secrets.FactoryName + "-linked", integrationRuntimeName + "-linked");
            }
            catch (Exception e)
            {
            }
        }

        private void CaptureIntegrationRuntimes_RemoveLinks()
        {
            interceptor.CurrentExampleName = "IntegrationRuntimes_RemoveLinks";
            try
            {
                client.IntegrationRuntimes.RemoveLinks(secrets.ResourceGroupName, secrets.FactoryName, integrationRuntimeName, new LinkedIntegrationRuntimeRequest(secrets.FactoryName + "-linked"));
            }
            catch (Exception e)
            {
            }
        }

        private LinkedServiceResource GetLinkedServiceResource(string description)
        {
            LinkedServiceResource resource = new LinkedServiceResource
            {
                Properties = new AzureStorageLinkedService
                {
                    Description = description,
                    ConnectionString = new SecureString(string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", secrets.StorageAccountName, secrets.StorageAccountKey))
                }
            };
            return resource;
        }

        private void CaptureLinkedServices_Create()
        {
            interceptor.CurrentExampleName = "LinkedServices_Create";
            LinkedServiceResource resourceIn = GetLinkedServiceResource(null);
            LinkedServiceResource resource = client.LinkedServices.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, linkedServiceName, resourceIn);
        }

        private void CaptureLinkedServices_Update()
        {
            interceptor.CurrentExampleName = "LinkedServices_Update";
            LinkedServiceResource resourceIn = GetLinkedServiceResource("Example description");
            LinkedServiceResource resource = client.LinkedServices.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, linkedServiceName, resourceIn);
        }

        private void CaptureLinkedServices_Get()
        {
            interceptor.CurrentExampleName = "LinkedServices_Get";
            LinkedServiceResource resource = client.LinkedServices.Get(secrets.ResourceGroupName, secrets.FactoryName, linkedServiceName);
        }

        private void CaptureLinkedServices_ListByFactory()
        {
            interceptor.CurrentExampleName = "LinkedServices_ListByFactory";
            IPage<LinkedServiceResource> resources = client.LinkedServices.ListByFactory(secrets.ResourceGroupName, secrets.FactoryName);
        }

        private void CaptureLinkedServices_Delete()
        {
            interceptor.CurrentExampleName = "LinkedServices_Delete";
            client.LinkedServices.Delete(secrets.ResourceGroupName, secrets.FactoryName, linkedServiceName);
        }


        private DatasetResource GetDatasetResource(string description)
        {
            DatasetResource resource = new DatasetResource
            {
                Properties = new AzureBlobDataset
                {
                    Description = description,
                    FolderPath = new Expression { Value = "@dataset().MyFolderPath" },
                    FileName = new Expression { Value = "@dataset().MyFileName" },
                    Format = new TextFormat(),
                    LinkedServiceName = new LinkedServiceReference
                    {
                        ReferenceName = linkedServiceName
                    },                     
                }
            };

            resource.Properties.Parameters = new Dictionary<string, ParameterSpecification>()
            {
                { "MyFolderPath",  new ParameterSpecification { Type = ParameterType.String } },
                { "MyFileName",  new ParameterSpecification { Type = ParameterType.String } }
            };

            return resource;
        }

        private void CaptureDatasets_Create()
        {
            interceptor.CurrentExampleName = "Datasets_Create";
            DatasetResource resourceIn = GetDatasetResource(null);
            DatasetResource resource = client.Datasets.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, datasetName, resourceIn);
        }

        private void CaptureDatasets_Update()
        {
            interceptor.CurrentExampleName = "Datasets_Update";
            DatasetResource resourceIn = GetDatasetResource("Example description");
            DatasetResource resource = client.Datasets.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, datasetName, resourceIn);
        }

        private void CaptureDatasets_Get()
        {
            interceptor.CurrentExampleName = "Datasets_Get";
            DatasetResource resource = client.Datasets.Get(secrets.ResourceGroupName, secrets.FactoryName, datasetName);
        }

        private void CaptureDatasets_ListByFactory()
        {
            interceptor.CurrentExampleName = "Datasets_ListByFactory";
            IPage<DatasetResource> resources = client.Datasets.ListByFactory(secrets.ResourceGroupName, secrets.FactoryName);
        }

        private void CaptureDatasets_Delete()
        {
            interceptor.CurrentExampleName = "Datasets_Delete";
            client.Datasets.Delete(secrets.ResourceGroupName, secrets.FactoryName, datasetName);
        }

        private PipelineResource GetPipelineResource(string description)
        {
            PipelineResource resource = new PipelineResource
            {
                Description = description,
                Parameters = new Dictionary<string, ParameterSpecification>
                    {
                        { "OutputBlobNameList", new ParameterSpecification { Type = ParameterType.Array } }
                    },
                Activities = new List<Activity>()
            };
            CopyActivity copyActivity = new CopyActivity
            {
                Name = "ExampleCopyActivity",
                DataIntegrationUnits = 32,
                Inputs = new List<DatasetReference>
                            {
                                new DatasetReference
                                {
                                    ReferenceName = datasetName,
                                    Parameters = new Dictionary<string, object>()
                                    {
                                        { "MyFolderPath",  secrets.BlobContainerName},
                                        { "MyFileName",  "entitylogs.csv"}
                                    }
                                }
                            },
                Outputs = new List<DatasetReference>
                            {
                                new DatasetReference
                                {
                                    ReferenceName = datasetName,
                                    Parameters = new Dictionary<string, object>()
                                    {
                                        { "MyFolderPath",  secrets.BlobContainerName},
                                        { "MyFileName",  new Expression("@item()")}
                                    }
                                }
                            },
                Source = new BlobSource
                {
                },
                Sink = new BlobSink
                {
                }
            };
            ForEachActivity forEachActivity = new ForEachActivity
            {
                Name = "ExampleForeachActivity",
                IsSequential = true,
                Items = new Expression("@pipeline().parameters.OutputBlobNameList"),
                Activities = new List<Activity>() { copyActivity }
            };
            resource.Activities.Add(forEachActivity);
            return resource;
        }

        private void CapturePipelines_Create()
        {
            interceptor.CurrentExampleName = "Pipelines_Create";
            PipelineResource resourceIn = GetPipelineResource(null);
            PipelineResource resource = client.Pipelines.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, pipelineName, resourceIn);
        }

        private void CapturePipelines_Update()
        {
            interceptor.CurrentExampleName = "Pipelines_Update";
            PipelineResource resourceIn = GetPipelineResource("Example description");
            PipelineResource resource = client.Pipelines.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, pipelineName, resourceIn);
        }

        private void CapturePipelines_Get()
        {
            interceptor.CurrentExampleName = "Pipelines_Get";
            PipelineResource resource = client.Pipelines.Get(secrets.ResourceGroupName, secrets.FactoryName, pipelineName);
        }

        private void CapturePipelines_ListByFactory()
        {
            interceptor.CurrentExampleName = "Pipelines_ListByFactory";
            IPage<PipelineResource> resources = client.Pipelines.ListByFactory(secrets.ResourceGroupName, secrets.FactoryName);
        }

        private string CapturePipelines_CreateRun()
        {
            interceptor.CurrentExampleName = "Pipelines_CreateRun";
            string[] outputBlobNameList = new string[1];
            outputBlobNameList[0] = outputBlobName;

            JArray outputBlobNameArray = JArray.FromObject(outputBlobNameList);

            Dictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "OutputBlobNameList",  outputBlobNameArray }
            };

            CreateRunResponse rtr = client.Pipelines.CreateRun(secrets.ResourceGroupName, secrets.FactoryName, pipelineName, parameters: arguments);
            return rtr.RunId;
        }

        private void CapturePipelineRuns_Cancel()
        {
            string runId = this.CapturePipelines_CreateRun();
            interceptor.CurrentExampleName = "PipelineRuns_Cancel";
            client.PipelineRuns.Cancel(secrets.ResourceGroupName, secrets.FactoryName, runId);
        }

        private void CapturePipelines_Delete()
        {
            interceptor.CurrentExampleName = "Pipelines_Delete";
            client.Pipelines.Delete(secrets.ResourceGroupName, secrets.FactoryName, pipelineName);
        }

        private void CapturePipelineRuns_QueryByFactory(string runId, DateTime lastUpdatedAfter, DateTime lastUpdatedBefore)
        {
            // Assumes run will be on first page if found, which is currently true.
            interceptor.CurrentExampleName = "PipelineRuns_QueryByFactory";
            PipelineRunsQueryResponse response;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            do
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));

                response = client.PipelineRuns.QueryByFactory(secrets.ResourceGroupName, secrets.FactoryName, new RunFilterParameters
                {
                    Filters = new List<RunQueryFilter>
                    {
                        new RunQueryFilter(RunQueryFilterOperand.PipelineName, RunQueryFilterOperator.Equals, new List<string> { pipelineName })
                    },
                    LastUpdatedAfter = lastUpdatedAfter,
                    LastUpdatedBefore = lastUpdatedBefore
                });
                if (response != null)
                {
                    foreach (PipelineRun item in response.Value)
                    {
                        if (item.RunId == runId && item.Status == "Succeeded")
                        {
                            return; // found successful run
                        }
                    }
                }
            } while (sw.Elapsed.TotalMinutes <= 3);
            throw new TimeoutException("CapturePipelineRuns_ListByFactory didn't finish in 3 minutes, should take about 1");
        }

        private void CapturePipelineRuns_Get(string runId)
        {
            interceptor.CurrentExampleName = "PipelineRuns_Get";
            PipelineRun run = client.PipelineRuns.Get(secrets.ResourceGroupName, secrets.FactoryName, runId);
        }

        private void CaptureActivityRuns_QueryByPipelineRun(string runId, DateTime lastUpdatedAfter, DateTime lastUpdatedBefore)
        {
            // Assumes activity runs are on first page if found, which is currently true
            interceptor.CurrentExampleName = "ActivityRuns_QueryByPipelineRun";
            ActivityRunsQueryResponse response;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            do
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
                response = client.ActivityRuns.QueryByPipelineRun(secrets.ResourceGroupName, secrets.FactoryName, runId, new RunFilterParameters
                {
                    LastUpdatedAfter = lastUpdatedAfter,
                    LastUpdatedBefore = lastUpdatedBefore
                });
                if (response != null)
                {
                    foreach (ActivityRun item in response.Value)
                    {
                        if (item.Status == "Succeeded")
                        {
                            return; // found successful activity run
                        }
                    }
                }
            } while (sw.Elapsed.TotalMinutes <= 3);
            throw new TimeoutException("ActivityRuns_QueryByPipelineRun didn't finish in 3 minutes, should take about 1");
        }

        private TriggerResource GetTriggerResource(string description)
        {
            TriggerResource resource = new TriggerResource()
            {
                Properties = new ScheduleTrigger()
                {
                    Description = description,
                    Recurrence = new ScheduleTriggerRecurrence()
                    {
                        TimeZone = "UTC",
                        StartTime = DateTime.UtcNow.AddMinutes(-1),
                        EndTime = DateTime.UtcNow.AddMinutes(15),
                        Frequency = RecurrenceFrequency.Minute,
                        Interval = 4,
                        Schedule = null
                    },
                    Pipelines = new List<TriggerPipelineReference>()
                }
            };

            TriggerPipelineReference triggerPipelineReference = new TriggerPipelineReference()
            {
                PipelineReference = new PipelineReference(pipelineName),
                Parameters = new Dictionary<string, object>()
            };

            string[] outputBlobNameList = new string[1];
            outputBlobNameList[0] = outputBlobName;

            JArray outputBlobNameArray = JArray.FromObject(outputBlobNameList);

            triggerPipelineReference.Parameters.Add("OutputBlobNameList", outputBlobNameArray);

            (resource.Properties as MultiplePipelineTrigger).Pipelines.Add(triggerPipelineReference);

            return resource;
        }

        private TriggerResource GetTWTriggerResource(string description)
        {
            TriggerResource resource = new TriggerResource() 
            {
                Properties = new TumblingWindowTrigger()
                {
                    Description = description,
                    StartTime = DateTime.UtcNow.AddMinutes(-10),
                    EndTime = DateTime.UtcNow.AddMinutes(5),
                    Frequency = RecurrenceFrequency.Minute,
                    Interval = 1,
                    Delay = "00:00:01",
                    MaxConcurrency = 1,
                    RetryPolicy = new RetryPolicy(1, 1),
                    Pipeline = new TriggerPipelineReference()
                }
            };

            TriggerPipelineReference triggerPipelineReference = new TriggerPipelineReference()
            {
                PipelineReference = new PipelineReference(pipelineName),
                Parameters = new Dictionary<string, object>()
            };

            string[] outputBlobNameList = new string[1];
            outputBlobNameList[0] = string.Format(CultureInfo.InvariantCulture, "{0}-{1}", outputBlobName, "@{concat('output',formatDateTime(trigger().outputs.windowStartTime,'-dd-MM-yyyy-HH-mm-ss-ffff'))}");
            outputBlobNameList[0] = string.Format(CultureInfo.InvariantCulture, "{0}-{1}", outputBlobName, "@{concat('output',formatDateTime(trigger().outputs.windowEndTime,'-dd-MM-yyyy-HH-mm-ss-ffff'))}");

            JArray outputBlobNameArray = JArray.FromObject(outputBlobNameList);

            triggerPipelineReference.Parameters.Add("OutputBlobNameList", outputBlobNameArray);

            (resource.Properties as TumblingWindowTrigger).Pipeline = triggerPipelineReference;

            return resource;
        }

        private void CaptureTriggers_Create()
        {
            interceptor.CurrentExampleName = "Triggers_Create";
            TriggerResource resourceIn = this.GetTriggerResource(null);
            TriggerResource resource = client.Triggers.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, triggerName, resourceIn);
        }

        private void CaptureTriggers_Update()
        {
            interceptor.CurrentExampleName = "Triggers_Update";
            TriggerResource resourceIn = this.GetTriggerResource("Example description");
            TriggerResource resource = client.Triggers.CreateOrUpdate(secrets.ResourceGroupName, secrets.FactoryName, triggerName, resourceIn);
        }

        private void CaptureTriggers_Get()
        {
            interceptor.CurrentExampleName = "Triggers_Get";
            TriggerResource resource = client.Triggers.Get(secrets.ResourceGroupName, secrets.FactoryName, triggerName);
        }

        private void CaptureTriggers_ListByFactory()
        {
            interceptor.CurrentExampleName = "Triggers_ListByFactory";
            IPage<TriggerResource> resources = client.Triggers.ListByFactory(secrets.ResourceGroupName, secrets.FactoryName);
        }

        private void CaptureTriggers_Start()
        {
            interceptor.CurrentExampleName = "Triggers_Start";
            client.Triggers.Start(secrets.ResourceGroupName, secrets.FactoryName, triggerName);
        }

        private void CaptureTriggers_Stop()
        {
            interceptor.CurrentExampleName = "Triggers_Stop";
            client.Triggers.Stop(secrets.ResourceGroupName, secrets.FactoryName, triggerName);
        }

        private void CaptureTriggerRuns_QueryByFactory(DateTime lastUpdatedAfter, DateTime lastUpdatedBefore)
        {
            interceptor.CurrentExampleName = "TriggerRuns_QueryByFactory";

            //Wait for the Trigger to Run
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(6));

            TriggerRunsQueryResponse response = client.TriggerRuns.QueryByFactory(secrets.ResourceGroupName, secrets.FactoryName, new RunFilterParameters
            {
                Filters = new List<RunQueryFilter>
                    {
                        new RunQueryFilter("TriggerName", RunQueryFilterOperator.Equals, new List<string> { triggerName })
                    },
                LastUpdatedAfter = lastUpdatedAfter,
                LastUpdatedBefore = lastUpdatedBefore
            });
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            do
            {
                if (response != null && response.Value.Count > 0)
                {
                    return; // found successful run
                }

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));

                response = client.TriggerRuns.QueryByFactory(secrets.ResourceGroupName, secrets.FactoryName, new RunFilterParameters
                {
                    Filters = new List<RunQueryFilter>
                    {
                        new RunQueryFilter("TriggerName", RunQueryFilterOperator.Equals, new List<string> { triggerName })
                    },
                    LastUpdatedAfter = lastUpdatedAfter,
                    LastUpdatedBefore = lastUpdatedBefore,
                    ContinuationToken = response.ContinuationToken
                });

            } while (sw.Elapsed.TotalMinutes <= 3);

            throw new TimeoutException("TriggerRuns_QueryByFactory didn't finish in 5 minutes");
        }

        private void CaptureTriggers_Delete()
        {
            interceptor.CurrentExampleName = "Triggers_Delete";
            client.Triggers.Delete(secrets.ResourceGroupName, secrets.FactoryName, triggerName);
        }

        private void CaptureOperations_List()
        {
            interceptor.CurrentExampleName = "Operations_List";
            IPage<Operation> operations = client.Operations.List();
        }

    }
}
