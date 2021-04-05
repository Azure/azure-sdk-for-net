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
                scenario = ScenarioFactory.GetScenario(Scenarios.GenericResourceOperationsExample);
                scenario.Execute();
            }
            finally
            {
                foreach (var rgId in Scenario.CleanUp)
                {
                    var id = new ResourceGroupResourceIdentifier(rgId);
                    var rg = new ArmClient(new DefaultAzureCredential()).GetSubscriptionOperations(id.SubscriptionId).GetResourceGroupOperations(id.ResourceGroupName);
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
