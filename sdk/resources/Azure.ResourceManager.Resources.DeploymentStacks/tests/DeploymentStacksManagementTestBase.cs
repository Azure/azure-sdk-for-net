// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.DeploymentStacks.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.DeploymentStacks.Tests
{
    public class DeploymentStacksManagementTestBase : ManagementRecordedTestBase<DeploymentStacksManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected DeploymentStacksManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DeploymentStacksManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected static DeploymentStackData CreateRGDeploymentStackDataWithTemplate()
        {
            var data = new DeploymentStackData();

            data.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Scenario",
                    "DeploymentTemplates",
                    $"rg-stack-template.json")));

            data.DenySettings = new DeploymentStackDenySettings(DeploymentStackDenySettingsMode.None);

            data.ActionOnUnmanage = new ActionOnUnmanage()
            {
                Resources = UnmanageActionResourceMode.Detach,
                ResourceGroups = UnmanageActionResourceGroupMode.Detach,
                ManagementGroups = UnmanageActionManagementGroupMode.Detach
            };

            data.BypassStackOutOfSyncError = false;

            data.Parameters.Add("templateSpecName", new DeploymentParameterItem { Value = BinaryData.FromString("\"stacksTestTemplate4321\"") });

            return data;
        }

        protected static DeploymentStackData CreateSubDeploymentStackDataWithTemplate(AzureLocation location)
        {
            var data = new DeploymentStackData();

            data.Location = location;

            data.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Scenario",
                    "DeploymentTemplates",
                    $"sub-stack-template.json")));

            data.DenySettings = new DeploymentStackDenySettings(DeploymentStackDenySettingsMode.None);

            data.ActionOnUnmanage = new ActionOnUnmanage()
            {
                Resources = UnmanageActionResourceMode.Detach,
                ResourceGroups = UnmanageActionResourceGroupMode.Detach,
                ManagementGroups = UnmanageActionManagementGroupMode.Detach
            };

            data.BypassStackOutOfSyncError = false;

            data.Parameters.Add("rgName", new DeploymentParameterItem { Value = BinaryData.FromString("\"stacksTestRG4321\"") });

            return data;
        }

        protected static DeploymentStackData CreateMGDeploymentStackDataWithTemplate(AzureLocation location)
        {
            var data = new DeploymentStackData();

            data.Location = location;

            data.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Scenario",
                    "DeploymentTemplates",
                    $"mg-stack-template.json")));

            data.DenySettings = new DeploymentStackDenySettings(DeploymentStackDenySettingsMode.None);

            data.ActionOnUnmanage = new ActionOnUnmanage()
            {
                Resources = UnmanageActionResourceMode.Detach,
                ResourceGroups = UnmanageActionResourceGroupMode.Detach,
                ManagementGroups = UnmanageActionManagementGroupMode.Detach
            };

            data.BypassStackOutOfSyncError = false;

            data.Parameters.Add("message", new DeploymentParameterItem { Value = BinaryData.FromString("\"hello world\"") });

            return data;
        }
    }
}
