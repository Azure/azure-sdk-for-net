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
                var client = new ArmClient(new DefaultAzureCredential());
                foreach (var rgId in CleanUp)
                {
                    var id = new ResourceGroupResourceIdentifier(rgId);
                    var rg = client.GetResourceGroupOperations(id);
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
