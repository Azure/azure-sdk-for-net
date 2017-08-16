// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Rm = Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;

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

        private IDataFactoryManagementExtendedClient client;
        private Rm.IResourceManagementClient rmClient;
        private ExampleTracingInterceptor interceptor;

        public ExampleCapture(string secretsFile, string outputFolder, string outputFolderWorkarounds = null)
        {
            this.secrets = ExampleHelpers.ReadSecretsFile(secretsFile);
            this.outputFolder = outputFolder;
            this.outputFolderWorkarounds = outputFolderWorkarounds;
            this.client = ExampleHelpers.GetRealClient(secrets);
            this.rmClient = ExampleHelpers.GetRealRmClient(secrets);
            this.interceptor = new ExampleTracingInterceptor(client.SubscriptionId, client.ApiVersion);
            ServiceClientTracing.AddTracingInterceptor(interceptor);
        }        

        public void CaptureAllExamples()
        {
            // Note: This should take under 1 minutes if everything works as expected
            try
            {
                // make sure ResourceGroup, DataFactory and Gateway exist before running the capture method
                EnsureResourceGroupExists();
                ServiceClientTracing.IsEnabled = true;
                CaptureGatewayExtended_List(); // 200
                CaptureGatewayExtended_Update(); // 200
                CaptureGatewayExtended_ForceSyncCredential(); //200
                CaptureGatewayExtended_UpdateNode(); //200
                CaptureGatewayExtended_DeleteNode(); //200
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
                try
                {
                    // rmClient will be null in nightly aka direct access case.
                    AzureOperationResponse<bool> response = rmClient.ResourceGroups.CheckExistenceWithHttpMessagesAsync(secrets.ResourceGroupName).Result;
                    if (!response.Body)
                    {
                        throw new InvalidOperationException(string.Format("Couldn't create resource group: {0}", response));
                    }
                }catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void CaptureGatewayExtended_List()
        {
            interceptor.CurrentExampleName = "GatewayExtended_List";
            List<GatewayExtended> gateway = client.GatewaysExtended.List(secrets.ResourceGroupName, secrets.FactoryName).ToList();
        }

        private const string GatewayName = "DemoDMG";
        private void CaptureGatewayExtended_Update()
        {
            interceptor.CurrentExampleName = "GatewayExtended_Update";
            var newTime = (new TimeSpan(8, 8, 8)).ToString();
            var parmas = new GatewayExtended()
            {
                Name = GatewayName,
                Properties = new GatewayExtendedProperties()
                {
                    ScheduledUpgradeTime = newTime
                }
            };
            var result = client.GatewaysExtended.Update(secrets.ResourceGroupName, secrets.FactoryName, GatewayName, parmas);
            if (result.Properties.ScheduledUpgradeTime.CompareTo(newTime) != 0)
            {
                throw new Exception("Gateway not updated correctly");
            }
        }

        private void CaptureGatewayExtended_ForceSyncCredential()
        {
            interceptor.CurrentExampleName = "GatewayExtended_ForceSyncCredential";
            client.GatewaysExtended.ForceSyncCredential(secrets.ResourceGroupName, secrets.FactoryName, GatewayName);
        }

        private void CaptureGatewayExtended_UpdateNode()
        {
            interceptor.CurrentExampleName = "GatewayExtended_UpdateNode";
            var param = new GatewayExtendedUpdateNodeParameters()
            {
                NodeName = Constants.DefaultNodeName,
                LimitConcurrentJobs = 5
            };
            client.GatewaysExtended.UpdateNode(secrets.ResourceGroupName, secrets.FactoryName, GatewayName, param);
        }

        private void CaptureGatewayExtended_DeleteNode()
        {
            interceptor.CurrentExampleName = "GatewayExtended_DeleteNode";
            var param = new GatewayExtendedDeleteNodeParameters(Constants.DefaultNodeName);
            client.GatewaysExtended.DeleteNode(secrets.ResourceGroupName, secrets.FactoryName, GatewayName, param);
        }
    }
}
