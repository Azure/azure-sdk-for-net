using Azure.ResourceManager.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;

namespace Proto.Client
{
    class All : Scenario
    {
        public override void Execute()
        {
            var list = Enum.GetValues(typeof(Scenarios)).Cast<Scenarios>().ToList();
            try
            {
                foreach(var scenario in list)
                {
                    if (scenario != Scenarios.All)
                    {
                        Console.WriteLine($"########## Starting Scenario {scenario} ##########");
                        var executable = ScenarioFactory.GetScenario(scenario);
                        executable.Execute();
                        Console.WriteLine($"########## Finished Scenario {scenario} ##########");
                    }
                }
            }
            finally
            {
                foreach (var rgId in CleanUp)
                {
                    ResourceIdentifier id = new ResourceIdentifier(rgId);
                    var rg = new AzureResourceManagerClient(new DefaultAzureCredential()).GetResourceGroupOperations(rgId);
                    Console.WriteLine($"--------Deleting {rg.Id.Name}--------");
                    try
                    {
                        _ = rg.DeleteAsync();
                    }
                    catch
                    {
                        //ignore exceptions in case rg doesn't exist
                    }
                }
            }
        }
    }
}
