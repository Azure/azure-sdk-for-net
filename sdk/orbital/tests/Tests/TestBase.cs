using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Xunit;


using Microsoft.Azure.Management.Orbital.Models;
using Microsoft.Azure.Management.Orbital.Tests.Helpers;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Microsoft.Azure.Management.Orbital.Tests.Tests
{
    public class TestBase
    {
        protected bool IsRecording { get; set; }
        protected ResourceManagementClient ResourceManagementClient { get; private set; }

        public string spacecraftName { get; set; }

        public string contactProfileName { get; set; }

        public string rgName { get; set; }

        public string location { get; set; }

        public string gsName { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string contactName { get; set; }

        public TestBase()
        {
            this.IsRecording = false;
            setEnvironmentVariables();
            initializeLocalVariables();
        }

        public void initializeLocalVariables()
        {
            this.spacecraftName = "spacecraftnetsdktest";
            this.contactProfileName = "contactprofilenetsdktest";
            this.rgName = "orbital-dot-net-sdk-testing-rg";
            this.location = "westus2";
            this.gsName = "West US 2";
            this.contactName = "contactnetsdktest";
            this.startTime = DateTime.Now;
            this.startTime = this.startTime.AddDays(2);
            this.endTime = DateTime.Now;
            this.endTime = this.endTime.AddDays(3);
        }


        public void setEnvironmentVariables()
        {
            using (var file = File.OpenText("Properties\\launchSettings.json"))
            {
                var reader = new JsonTextReader(file);
                var jObject = JObject.Load(reader);

                var variables = jObject
                    .GetValue("profiles")
                    //select a proper profile here
                    .SelectMany(profiles => profiles.Children())
                    .SelectMany(profile => profile.Children<JProperty>())
                    .Where(prop => prop.Name == "environmentVariables")
                    .SelectMany(prop => prop.Value.Children<JProperty>())
                    .ToList();

                foreach (var variable in variables)
                {
                    Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                }
            }
        }

        protected AzureOrbitalClient GetAzureOrbitalClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            AzureOrbitalClient client;
            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            if (string.Equals(testMode, "record", StringComparison.OrdinalIgnoreCase))
            {
                this.IsRecording = true;
                string connectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");

                TestEnvironment env = new TestEnvironment(connectionString: connectionString);
                client = context.GetServiceClient<AzureOrbitalClient>(
                    currentEnvironment: env,
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });

                this.SetResourceManagementClient(env: env, context: context, handler: handler);
            }
            else
            {
                client = context.GetServiceClient<AzureOrbitalClient>(
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });

                this.SetResourceManagementClient(env: null, context: context, handler: handler);
            }

            return client;
        }

        private void SetResourceManagementClient(TestEnvironment env, MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            if (env != null)
            {
                this.ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>(
                    currentEnvironment: env,
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }
            else
            {
                this.ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>(
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }
        }

        protected bool VerifyExistenceOrCreateResourceGroup(string resourceGroupName, string location)
        {
            if (this.ResourceManagementClient == null)
            {
                throw new NullReferenceException("ResourceManagementClient not created.");
            }

            if (this.ResourceManagementClient.ResourceGroups.CheckExistence(resourceGroupName: resourceGroupName))
            {
                return true;
            }

            ResourceGroup resourceGroup = new ResourceGroup(location, null, resourceGroupName);

            resourceGroup = this.ResourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName: resourceGroupName, parameters: resourceGroup);

            return true;
        }


        protected bool DeleteResourceGroup(string rgName)
        {
            this.ResourceManagementClient.ResourceGroups.Delete(rgName);
            return true;
        }

    }
}
