using Azure.ResourceManager.Core;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenario scenario = null;
            try
            {
                scenario = ScenarioFactory.GetScenario(Scenarios.TenantResource);
                scenario.Execute();
            }
            finally
            {
                foreach (var rgId in Scenario.CleanUp)
                {
                    ResourceIdentifier id = new ResourceIdentifier(rgId);
                    var rg = new AzureResourceManagerClient(new DefaultAzureCredential()).GetSubscriptionOperations(id.Subscription).GetResourceGroupOperations(id.ResourceGroup);
                    Console.WriteLine($"--------Deleting {rg.Id.Name}--------");
                    try
                    {
                        _ = rg.DeleteAsync();
                    }
                    catch
                    {
                        //ignore exceptions in case the rg doesn't exist
                    }
                }
            }
        }
    }
}
