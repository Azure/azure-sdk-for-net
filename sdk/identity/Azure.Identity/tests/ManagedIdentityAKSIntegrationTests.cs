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
            string secret = Environment.GetEnvironmentVariable("IDENTITY_CLIENT_SECRET");
            string tenant = Environment.GetEnvironmentVariable("IDENTITY_TENANT_ID");
            string rg = Environment.GetEnvironmentVariable("IDENTITY_RESOURCE_GROUP");
            string aks = Environment.GetEnvironmentVariable("IDENTITY_AKS_CLUSTER_NAME");
            string subscription = Environment.GetEnvironmentVariable("IDENTITY_SUBSCRIPTION_ID");
            string buildArtifacts = Environment.GetEnvironmentVariable("BUILD_SOURCESDIRECTORY");
            string targetFramework = Environment.GetEnvironmentVariable("TESTTARGETFRAMEWORK");
            podName = Environment.GetEnvironmentVariable("IDENTITY_AKS_POD_NAME");

            // Ge the path to az
            string azPath = RunCommand("which", "az");

            // Get the path to kubectl
            kubectlPath = RunCommand("which", "kubectl");

            // Login to Azure
            RunCommand(azPath, $"login --service-principal -u {sp} -p {secret} --tenant {tenant}");

            // Set the subscription
            RunCommand(azPath, $"account set --subscription {subscription}");

            // Get the AKS credentials
            RunCommand(azPath, $"aks get-credentials --resource-group {rg} --name {aks} --overwrite-existing");

            // Get the pod name
            string podOutput = RunCommand(kubectlPath, "get pods -o jsonpath='{.items[0].metadata.name}'");
            Assert.That(podOutput, Does.Contain(podName));

            // copy the test binaries to the cluster
            RunCommand(kubectlPath, $"cp {buildArtifacts}/artifacts/bin/Azure.Identity.Tests/Debug/{targetFramework} {podName}:./tests/");
        }

        [Test]
        public void KubectlExecuteIdentityAKSTests()
        {
            SetupKubernetesEnvironment();
            // Run the test app on the cluster
            string output = RunCommand(kubectlPath, $"exec {podName} -- ./tests/Integration.Identity.Container");
            Assert.That(output, Does.Contain("Passed!"));
        }

        private string RunCommand(string fileName, string args)
        {
            try
            {
                Console.WriteLine($"Running command: {fileName} {args}");
                ProcessRunner runner = new ProcessRunner(
                    ProcessService.Default.Create(new ProcessStartInfo(fileName, args)),
                    TimeSpan.FromSeconds(30),
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
