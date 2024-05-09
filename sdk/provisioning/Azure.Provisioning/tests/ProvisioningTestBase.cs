// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using CoreTestEnvironment = Azure.Core.TestFramework.TestEnvironment;

namespace Azure.Provisioning.Tests
{
    [AsyncOnly]
    public class ProvisioningTestBase : ManagementRecordedTestBase<ProvisioningTestEnvironment>
    {
        public ProvisioningTestBase(bool async) : base(async)
        {
        }

        protected async Task ValidateBicepAsync(BinaryData? parameters = null, bool interactiveMode = false)
        {
            var testPath = GetOutputPath();
            var client = GetArmClient();
            ResourceGroupResource? rg = null;

            SubscriptionResource subscription =
                await client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);

            try
            {
                var bicepPath = Path.Combine(testPath, "main.bicep");
                var args = Path.Combine(
                    CoreTestEnvironment.RepositoryRoot,
                    "eng",
                    "scripts",
                    $"Validate-Bicep.ps1 {bicepPath}");
                var processInfo = new ProcessStartInfo("pwsh", args)
                {
                    UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true,
                };
                var process = Process.Start(processInfo);
                while (!process!.HasExited && !process!.StandardError.EndOfStream)
                {
                    var error = process.StandardError.ReadLine();
                    TestContext.Progress.WriteLine(error);
                    if (error!.Contains("Error"))
                    {
                        Assert.Fail(error);
                    }
                }

                ResourceIdentifier scope;
                if (interactiveMode)
                {
                    var rgs = subscription.GetResourceGroups();
                    var data = new ResourceGroupData("westus");
                    rg = (await rgs.CreateOrUpdateAsync(WaitUntil.Completed, TestContext.CurrentContext.Test.Name,
                        data)).Value;
                    scope = ResourceGroupResource.CreateResourceIdentifier(subscription.Id.SubscriptionId,
                        TestContext.CurrentContext.Test.Name);
                }
                else
                {
                    scope = subscription.Id;
                }

                var resource = client.GetArmDeploymentResource(
                    ArmDeploymentResource.CreateResourceIdentifier(scope, TestContext.CurrentContext.Test.Name));
                var content = new ArmDeploymentContent(
                    new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
                    {
                        Template = new BinaryData(File.ReadAllText(Path.Combine(testPath, "main.json"))),
                        Parameters = parameters
                    });
                if (!interactiveMode)
                {
                    content.Location = "westus";
                }

                await resource.ValidateAsync(WaitUntil.Completed, content);
            }
            finally
            {
                File.Delete(Path.Combine(testPath, "main.json"));
                if (rg != null)
                {
                    await rg.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        private static string GetGitRoot()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "rev-parse --show-toplevel",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo)!)
            {
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    string gitRoot = process.StandardOutput.ReadToEnd().Trim();
                    return gitRoot;
                }
                else
                {
                    throw new Exception("Failed to get the root of the Git repository.");
                }
            }
        }

        protected string GetOutputPath()
        {
            var output = Path.Combine(CoreTestEnvironment.GetSourcePath(GetType().Assembly), "Infrastructure",
                TestContext.CurrentContext.Test.Name);

            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }

            return output;
        }
    }
}
