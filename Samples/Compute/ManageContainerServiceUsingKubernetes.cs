// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.IO;

namespace ManageContainerServiceUsingKubernetes
{
    public class Program
    {
        /**
         * An Azure Container Services sample for managing a container service with Docker Swarm orchestration.
         *    - Create an Azure Container Service with Docker Swarm orchestration
         *    - Create a SSH private/public key
         *    - Update the number of agent virtual machines in an Azure Container Service
         */
        public static void RunSample(IAzure azure, string clientId, string secret)
        {
            string rgName = SdkContext.RandomResourceName("rgACS", 15);
            string acsName = SdkContext.RandomResourceName("acssample", 30);
            Region region = Region.USEast;
            string rootUserName = "acsuser";
            string sshPublicKey = // replace with a real SSH public key
                "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCyhPdNuJUmTeLsaZL83vARuSVlN5qbKs7j"
                + "Cm723fqH85rIRQHgwEUXJbENEgZT0cXEgz4h36bQLMYT3/30fRnxYl8U6gRn27zFiMwaDstOjc9EofStODbiHx9A"
                + "Y1XYStjegdf+LNa5tmRv8dZEdj47XDxosSG3JKHpSuf0fXr4u7NjgAxdYOxyMSPAEcfXQctA+ybHkGDLdjLHT7q5C"
                + "4RXlQT7S9v5z532C3KuUSQW7n3QBP3xw/bC8aKcJafwZUYjYnw7owkBnv4TsZVva2le7maYkrtLH6w+XbhfHY4WwK"
                + "Y2Xxl1TxSGkb8tDsa6XgTmGfAKcDpnIe0DASJD8wFF dotnet.sample@azure.com";
            string servicePrincipalClientId = clientId; // replace with a real service principal client id
            string servicePrincipalSecret = secret; // and corresponding secret

            try
            {
                //=============================================================
                // ...
                //=============================================================
                // If service principal client id and secret are not set via the local variables, attempt to read the service
                //     principal client id and secret from a secondary ".azureauth" file set through an environment variable.
                //
                //     If the environment variable was not set then reuse the main service principal set for running this sample.

                if (String.IsNullOrWhiteSpace(servicePrincipalClientId) || String.IsNullOrWhiteSpace(servicePrincipalSecret))
                {
                    string envSecondaryServicePrincipal = Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION_2");

                    if (String.IsNullOrWhiteSpace(envSecondaryServicePrincipal) || !File.Exists(envSecondaryServicePrincipal))
                    {
                        envSecondaryServicePrincipal = Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION");
                    }

                    servicePrincipalClientId = Utilities.GetSecondaryServicePrincipalClientID(envSecondaryServicePrincipal);
                    servicePrincipalSecret = Utilities.GetSecondaryServicePrincipalSecret(envSecondaryServicePrincipal);
                }

                //=============================================================
                // Create an Azure Container Service with Kubernetes orchestration

                Utilities.Log("Creating an Azure Container Service with Kubernetes ochestration and one agent (virtual machine)");

                IContainerService azureContainerService = azure.ContainerServices.Define(acsName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithKubernetesOrchestration()
                    .WithServicePrincipal(servicePrincipalClientId, servicePrincipalSecret)
                    .WithLinux()
                    .WithRootUsername(rootUserName)
                    .WithSshKey(sshPublicKey)
                    .WithMasterNodeCount(ContainerServiceMasterProfileCount.MIN)
                    .WithMasterLeafDomainLabel("dns-" + acsName)
                        .DefineAgentPool("agentpool")
                        .WithVMCount(1)
                        .WithVMSize(ContainerServiceVMSizeTypes.StandardD1V2)
                        .WithLeafDomainLabel("dns-ap-" + acsName)
                        .Attach()
                    .Create();

                Utilities.Log("Created Azure Container Service: " + azureContainerService.Id);
                Utilities.Print(azureContainerService);

                //=============================================================
                // Update a Docker Swarm Azure Container Service with two agents (virtual machines)

                Utilities.Log("Updating a Kubernetes Azure Container Service with two agents (virtual machines)");

                azureContainerService.Update()
                    .WithAgentVMCount(2)
                    .Apply();

                Utilities.Log("Updated Azure Container Service: " + azureContainerService.Id);
                Utilities.Print(azureContainerService);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure, "", "");
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}