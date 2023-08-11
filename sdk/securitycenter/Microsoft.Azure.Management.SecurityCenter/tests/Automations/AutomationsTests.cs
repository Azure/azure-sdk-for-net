// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class AutomationsTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static string ResourceGroupName = "automations-sdk-tests";
        private static string AutomationName = "sampleAutomation";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "centralus";

            securityCenterClient.SubscriptionId = SubscriptionId;

            return securityCenterClient;
        }

        #endregion

        #region Automations Tests

        [Fact]
        public async Task Automations_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var automations = await securityCenterClient.Automations.ListAsync();
                ValidateAutomations(automations);
            }
        }



        [Fact]
        public async Task Automations_ListAtResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var automations = await securityCenterClient.Automations.ListByResourceGroupAsync(ResourceGroupName);
                ValidateAutomations(automations);
            }
        }

        [Fact]
        public async Task Automations_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var automation = await securityCenterClient.Automations.GetAsync(ResourceGroupName, AutomationName);
                ValidateAutomation(automation);
            }
        }


        [Fact]
        public async Task Automations_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var automation = await securityCenterClient.Automations.CreateOrUpdateAsync(ResourceGroupName, AutomationName, new Automation()
                {
                    Location = "Central US",
                    Etag = "etag value (must be supplied for update)",
                    Tags = new Dictionary<string, string>(),
                    IsEnabled = true,
                    Scopes = new List<AutomationScope>()
                    {
                        new AutomationScope()
                        {
                            Description = "A description that helps to identify this scope - for example: security assessments that relate to the resource group myResourceGroup within the subscription a5caac9c-5c04-49af-b3d0-e204f40345d5",
                            ScopePath = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}"
                        }
                    },
                    Sources = new List<AutomationSource>()
                    {
                        new AutomationSource()
                        {
                            EventSource = EventSource.Assessments,
                        }
                    },
                    Actions = new List<AutomationAction>()
                    {
                        new AutomationActionLogicApp()
                        {
                            LogicAppResourceId = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Logic/workflows/MyTest1",
                            Uri = "https://exampleTriggerUri1.com"
                        }
                    }
                });
                ValidateAutomation(automation);
            }
        }

        [Fact]
        public async Task Automations_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                await securityCenterClient.Automations.DeleteAsync(ResourceGroupName, AutomationName);
            }
        }

        #endregion

        #region Validations

        private void ValidateAutomations(IPage<Automation> AutomationsPage)
        {
            Assert.True(AutomationsPage.IsAny());

            AutomationsPage.ForEach(ValidateAutomation);
        }

        private void ValidateAutomation(Automation automation)
        {
            Assert.NotNull(automation);
        }

        #endregion
    }
}
