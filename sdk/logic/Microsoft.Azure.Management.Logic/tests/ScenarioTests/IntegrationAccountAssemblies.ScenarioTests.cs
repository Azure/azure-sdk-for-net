// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.IO;
    using System.Linq;
    using Xunit;

    [Collection("IntegrationAccountAssembliesScenarioTests")]
    public class IntegrationAccountAssembliesScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void IntegrationAccountAssemblies_Create_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var assemblyName = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly = this.CreateIntegrationAccountAssembly(assemblyName);
                var createdAssembly = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName,
                    assembly);

                this.ValidateAssembly(assembly, createdAssembly);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAssemblies_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var assemblyName = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly = this.CreateIntegrationAccountAssembly(assemblyName);
                var createdAssembly = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName,
                    assembly);

                var retrievedAssembly = client.IntegrationAccountAssemblies.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName);

                this.ValidateAssembly(assembly, retrievedAssembly);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAssemblies_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var assemblyName1 = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly1 = this.CreateIntegrationAccountAssembly(assemblyName1);
                var createdAssembly1 = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName1,
                    assembly1);

                var assemblyName2 = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly2 = this.CreateIntegrationAccountAssembly(assemblyName2);
                var createdAssembly2 = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName2,
                    assembly2);

                var assemblyName3 = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly3 = this.CreateIntegrationAccountAssembly(assemblyName3);
                var createdAssembly3 = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName3,
                    assembly3);

                var assemblies = client.IntegrationAccountAssemblies.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.Equal(3, assemblies.Count());
                this.ValidateAssembly(assembly1, createdAssembly1);
                this.ValidateAssembly(assembly2, createdAssembly2);
                this.ValidateAssembly(assembly3, createdAssembly3);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAssemblies_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var assemblyName = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly = this.CreateIntegrationAccountAssembly(assemblyName);
                var createdAssembly = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName,
                    assembly);

                client.IntegrationAccountAssemblies.Delete(Constants.DefaultResourceGroup, integrationAccountName, assemblyName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountAssemblies.Get(Constants.DefaultResourceGroup, integrationAccountName, assemblyName));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAssemblies_DeleteWhenDeleteIntegrationAccount_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var assemblyName = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly = this.CreateIntegrationAccountAssembly(assemblyName);
                var createdAssembly = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName,
                    assembly);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountAssemblies.Get(Constants.DefaultResourceGroup, integrationAccountName, assemblyName));
            }
        }

        [Fact]
        public void IntegrationAccountAssemblies_ListContentCallbackUrl_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var assemblyName = TestUtilities.GenerateName(Constants.IntegrationAccountAssemblyPrefix);
                var assembly = this.CreateIntegrationAccountAssembly(assemblyName);
                var createdAssembly = client.IntegrationAccountAssemblies.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName,
                    assembly);

                var contentCallbackUrl = client.IntegrationAccountAssemblies.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    assemblyName);

                Assert.Equal("GET", contentCallbackUrl.Method);
                Assert.Contains(assemblyName, contentCallbackUrl.Value);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
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
