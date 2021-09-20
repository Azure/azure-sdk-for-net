using Microsoft.Azure.Management.Orbital.Tests.Helpers;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.Management.Orbital.Tests.Tests
{
    public class TestBase
    {
        protected bool IsRecording { get; set; }
        protected ResourceManagementClient ResourceManagementClient { get; private set; }

        public string spacecraftName { get; set; }

        public string contactProfileName { get; set; }

        static public  string rgName { get; set; }

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

        static TestBase()
        {
            rgName = "orbital-dot-net-sdk-testing-rg" + DateTime.Now.Millisecond.ToString();

        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static AzureOrbitalClient GetClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return context.GetServiceClient<AzureOrbitalClient>(handlers: handler);
        }

        public void initializeLocalVariables()
        {
            this.spacecraftName = "spacecraftnetsdktest";
            this.contactProfileName = "contactprofilenetsdktest";
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