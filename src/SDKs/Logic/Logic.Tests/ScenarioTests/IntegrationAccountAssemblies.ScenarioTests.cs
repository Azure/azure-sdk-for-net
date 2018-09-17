// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.IO;
    using System.Linq;
    using Xunit;

    [Collection("IntegrationAccountAssembliesScenarioTests")]
    public class IntegrationAccountAssembliesScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly string assemblyName;
        private readonly IntegrationAccount integrationAccount;

        public IntegrationAccountAssembliesScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.CreateIntegrationAccount(this.integrationAccountName));

            this.assemblyName = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
        }

        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccountAssemblies_Create_OK()
        {
            var assembly = this.CreateIntegrationAccountAssembly(this.assemblyName);
            var createdAssembly = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup, 
                this.integrationAccountName, 
                this.assemblyName, 
                assembly);

            this.ValidateAssembly(assembly, createdAssembly);
        }

        [Fact]
        public void IntegrationAccountAssemblies_Get_OK()
        {
            var assembly = this.CreateIntegrationAccountAssembly(this.assemblyName);
            var createdAssembly = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.assemblyName,
                assembly);

            var retrievedAssembly = this.client.IntegrationAccountAssemblies.Get(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.assemblyName);

            this.ValidateAssembly(assembly, retrievedAssembly);
        }

        [Fact]
        public void IntegrationAccountAssemblies_List_OK()
        {
            var assembly1 = this.CreateIntegrationAccountAssembly(this.assemblyName);
            var createdAssembly1 = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.assemblyName,
                assembly1);

            var assemblyName2 = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
            var assembly2 = this.CreateIntegrationAccountAssembly(assemblyName2);
            var createdAssembly2 = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                assemblyName2,
                assembly2);

            var assemblyName3 = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
            var assembly3 = this.CreateIntegrationAccountAssembly(assemblyName3);
            var createdAssembly3 = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                assemblyName3,
                assembly3);

            var assemblies = this.client.IntegrationAccountAssemblies.List(Constants.DefaultResourceGroup, this.integrationAccountName);

            Assert.Equal(3, assemblies.Count());
            this.ValidateAssembly(assembly1, createdAssembly1);
            this.ValidateAssembly(assembly2, createdAssembly2);
            this.ValidateAssembly(assembly3, createdAssembly3);
        }

        [Fact]
        public void IntegrationAccountAssemblies_Delete_OK()
        {
            var assembly = this.CreateIntegrationAccountAssembly(this.assemblyName);
            var createdAssembly = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.assemblyName,
                assembly);

            this.client.IntegrationAccountAssemblies.Delete(Constants.DefaultResourceGroup, this.integrationAccountName, this.assemblyName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountAssemblies.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.assemblyName));
        }

        [Fact]
        public void IntegrationAccountAssemblies_DeleteWhenDeleteIntegrationAccount_OK()
        {
            var assembly = this.CreateIntegrationAccountAssembly(this.assemblyName);
            var createdAssembly = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.assemblyName,
                assembly);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountAssemblies.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.assemblyName));
        }

        [Fact]
        public void IntegrationAccountAssemblies_ListContentCallbackUrl_OK()
        {
            var assembly = this.CreateIntegrationAccountAssembly(this.assemblyName);
            var createdAssembly = this.client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.assemblyName,
                assembly);

            var contentCallbackUrl = this.client.IntegrationAccountAssemblies.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.assemblyName);

            Assert.Equal("GET", contentCallbackUrl.Method);
            Assert.Contains(this.assemblyName, contentCallbackUrl.Value);
        }

        #region Private

        private void ValidateAssembly(AssemblyDefinition expected, AssemblyDefinition actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Properties.AssemblyName, actual.Properties.AssemblyName);
            Assert.NotEmpty(actual.Properties.ContentLink.Uri);
            Assert.NotNull(actual.Properties.CreatedTime);
            Assert.NotNull(actual.Properties.ChangedTime);

        }

        private AssemblyDefinition CreateIntegrationAccountAssembly(string assemblyName)
        {
            var assemblyProperties = new AssemblyProperties(assemblyName,
                content: File.ReadAllBytes(@"TestData/IntegrationAccountAssemblyContent.dll"),
                contentType: "application/octet-stream");

            var assembly = new AssemblyDefinition(assemblyProperties,
                location: Constants.DefaultLocation, 
                name: assemblyName);

            return assembly;
        }

        #endregion Private
    }
}