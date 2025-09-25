// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [RunOnlyOnPlatforms(Linux = true)]
    [LiveOnly]
    [AsyncOnly]
    public class ManagedIdentityAKSIntegrationTests : ClientTestBase
    {
        public ManagedIdentityAKSIntegrationTests(bool isAsync) : base(isAsync)
        { }

        private string kubectlPath;
        private string podName;

        public void SetupKubernetesEnvironment()
        {
            string sp = Environment.GetEnvironmentVariable("IDENTITY_CLIENT_ID");
            string tenant = Environment.GetEnvironmentVariable("IDENTITY_TENANT_ID");
            string oidc = Environment.GetEnvironmentVariable("ARM_OIDC_TOKEN");
            string rg = Environment.GetEnvironmentVariable("IDENTITY_RESOURCE_GROUP");
            string aks = Environment.GetEnvironmentVariable("IDENTITY_AKS_CLUSTER_NAME");
            string subscription = Environment.GetEnvironmentVariable("IDENTITY_SUBSCRIPTION_ID");
            string buildArtifacts = Environment.GetEnvironmentVariable("BUILD_SOURCESDIRECTORY");
            string targetFramework = Environment.GetEnvironmentVariable("TESTTARGETFRAMEWORK");
            podName = Environment.GetEnvironmentVariable("IDENTITY_AKS_POD_NAME");

            // Get the path to az
            string azPath = RunCommand("which", "az");

            // Get the path to kubectl
            kubectlPath = RunCommand("which", "kubectl");

            // Login to Azure
            RunCommand(azPath, $"login --federated-token {oidc} --service-principal -u {sp} --tenant {tenant}");

            // Set the subscription
            RunCommand(azPath, $"account set --subscription {subscription}");

            // Get the AKS credentials
            RunCommand(azPath, $"aks get-credentials --resource-group {rg} --name {aks} --overwrite-existing");

            // Get the pod name
            string podOutput = RunCommand(kubectlPath, "get pods -o jsonpath='{.items[0].metadata.name}'");
            Assert.That(podOutput, Does.Contain(podName));

            // Publish the Integration.Identity.Container project as self-contained
            string containerProjectPath = $"{buildArtifacts}/sdk/identity/Azure.Identity/integration/Integration.Identity.Container/Integration.Identity.Container.csproj";
            string publishDir = $"{buildArtifacts}/artifacts/publish/Integration.Identity.Container/{targetFramework}";
            RunCommand("dotnet", $"publish {containerProjectPath} -c Debug -f {targetFramework} --self-contained -r linux-x64 -o {publishDir}", TimeSpan.FromMinutes(2));

            // Copy the published self-contained app to the cluster
            RunCommand(kubectlPath, $"cp {publishDir}/Integration.Identity.Container {podName}:./Integration.Identity.Container");
        }

        [Test]
        public void KubectlExecuteIdentityAKSTests()
        {
            SetupKubernetesEnvironment();
            
            // Make the executable file executable and run it
            RunCommand(kubectlPath, $"exec {podName} -- chmod +x ./Integration.Identity.Container");
            string output = RunCommand(kubectlPath, $"exec {podName} -- ./Integration.Identity.Container");
            Assert.That(output, Does.Contain("Passed!"));
        }

        private string RunCommand(string fileName, string args, TimeSpan timeout = default)
        {
            if (timeout == default)
                timeout = TimeSpan.FromSeconds(60);
                
            try
            {
                Console.WriteLine($"Running command: {fileName} {args}");
                ProcessRunner runner = new ProcessRunner(
                    ProcessService.Default.Create(new ProcessStartInfo(fileName, args)),
                    timeout,
                    true,
                    default);
                var output = runner.Run();
                Console.WriteLine($"output:" + Environment.NewLine + output);
                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail(e.ToString());
            }
            return string.Empty;
        }
    }
}
