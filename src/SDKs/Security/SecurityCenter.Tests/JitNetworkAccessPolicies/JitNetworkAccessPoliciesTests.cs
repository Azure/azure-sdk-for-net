// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class JitNetworkAccessPoliciesTests : TestBase
    {
        #region Test setup

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

            securityCenterClient.AscLocation = "northeurope";

            return securityCenterClient;
        }

        #endregion

        #region JIT Network Access Policies Tests

        [Fact]
        public void JitNetworkAccessPolicies_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var jitNetworkAccessPolicies = securityCenterClient.JitNetworkAccessPolicies.List();
                ValidateJitNetworkAccessPolicies(jitNetworkAccessPolicies);
            }
        }

        [Fact]
        public void JitNetworkAccessPolicies_Delete()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.JitNetworkAccessPolicies.Delete("mainWS", "default");
            }
        }

        [Fact]
        public void JitNetworkAccessPolicies_Get()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var jitNetworkAccessPolicy = securityCenterClient.JitNetworkAccessPolicies.Get("myService1", "default");
                ValidateJitNetworkAccessPolicy(jitNetworkAccessPolicy);
            }
        }

        [Fact]
        public void JitNetworkAccessPolicies_Initiate()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var vm = new JitNetworkAccessPolicyInitiateVirtualMachine() {
                    Id = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/myService1/providers/Microsoft.Compute/virtualMachines/testService",
                    Ports = new List<JitNetworkAccessPolicyInitiatePort>()
                    {
                        new JitNetworkAccessPolicyInitiatePort(3389, DateTime.UtcNow.AddHours(3))
                    }
                };
                var virtualMachines = new List<JitNetworkAccessPolicyInitiateVirtualMachine>() { vm };
                securityCenterClient.JitNetworkAccessPolicies.Initiate("myService1", "default", virtualMachines);
            }
        }

        [Fact]
        public void JitNetworkAccessPolicies_ListByRegion()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var jitNetworkAccessPolicy = securityCenterClient.JitNetworkAccessPolicies.ListByRegion();
            }
        }

        [Fact]
        public void JitNetworkAccessPolicies_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var vm = new List<JitNetworkAccessPolicyVirtualMachine>() { new JitNetworkAccessPolicyVirtualMachine() { Id = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/myService1/providers/Microsoft.Compute/virtualMachines/syslogmyservice1vm",Ports = new List<JitNetworkAccessPortRule>() { new JitNetworkAccessPortRule(8080, "TCP", "PT5H", "192.168.0.5") } } };
                var policy = new JitNetworkAccessPolicy()
                {
                    Kind = "Basic",
                    VirtualMachines = vm
                };

                var jitNetworkAccessPolicy = securityCenterClient.JitNetworkAccessPolicies.CreateOrUpdate("mainWS", "default", policy);
                ValidateJitNetworkAccessPolicy(jitNetworkAccessPolicy);
            }
        }

        [Fact]
        public void JitNetworkAccessPolicies_ListByResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var jitNetworkAccessPolicies = securityCenterClient.JitNetworkAccessPolicies.ListByResourceGroup("myService1");
                ValidateJitNetworkAccessPolicies(jitNetworkAccessPolicies);
            }
        }

        [Fact]
        public void JitNetworkAccessPolicies_ListByResourceGroupAndRegion()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var jitNetworkAccessPolicies = securityCenterClient.JitNetworkAccessPolicies.ListByResourceGroupAndRegion("myService1");
                ValidateJitNetworkAccessPolicies(jitNetworkAccessPolicies);
            }
        }

        #endregion

        #region Validations

        private void ValidateJitNetworkAccessPolicies(IPage<JitNetworkAccessPolicy> jitNetworkAccessPolicyPage)
        {
            Assert.True(jitNetworkAccessPolicyPage.IsAny());

            jitNetworkAccessPolicyPage.ForEach(ValidateJitNetworkAccessPolicy);
        }

        private void ValidateJitNetworkAccessPolicy(JitNetworkAccessPolicy jitNetworkAccessPolicy)
        {
            Assert.NotNull(jitNetworkAccessPolicy);
        }

        #endregion
    }
}
