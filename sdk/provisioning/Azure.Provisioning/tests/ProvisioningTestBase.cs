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
        private DateTime _testStartTime;
        protected override DateTime TestStartTime => _testStartTime;

        public ProvisioningTestBase(bool async) : base(async)
        {
            // Ignore the version of the AZ CLI used to generate the ARM template as this will differ based on the environment
            JsonPathSanitizers.Add("$.._generator.version");
            JsonPathSanitizers.Add("$.._generator.templateHash");
        }

        [SetUp]
        public void Setup()
        {
            _testStartTime = base.TestStartTime;
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

                // exclude the time taken to validate the bicep file
                _testStartTime = DateTime.UtcNow;

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
