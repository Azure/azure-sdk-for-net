using Azure.ResourceManager.Core;
using Proto.Compute;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class CheckResourceExists : Scenario
    {
        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subOp = client.DefaultSubscription;
            var rgContainer = subOp.GetResourceGroups();

            Console.WriteLine($"Making sure {Context.RgName} doesn't exist yet.");
            if (rgContainer.DoesExist(Context.RgName))
                throw new Exception($"The resource group {Context.RgName} should not have existed.");

            Console.WriteLine($"Creating {Context.RgName}");
            _ = rgContainer.Construct(LocationData.Default).CreateOrUpdate(Context.RgName).Value;

            Console.WriteLine($"Making sure {Context.RgName} exists now.");
            if (!rgContainer.DoesExist(Context.RgName))
                throw new Exception($"The resource group {Context.RgName} should have existed.");

            Console.WriteLine($"Using try get value to retrieve {Context.RgName}");
            ResourceGroup rgOutput = rgContainer.TryGet(Context.RgName);
            if(rgOutput == null)
                throw new Exception($"The resource group {Context.RgName} should have existed.");

            var asetContainer = rgOutput.GetAvailabilitySets();
            var asetName = Context.VmName + "_aSet";

            Console.WriteLine($"Making sure {asetName} doesn't exist yet.");
            if (asetContainer.DoesExist(asetName))
                throw new Exception($"The availability set {asetName} should not have existed.");

            Console.WriteLine($"Creating {asetName}");
            var aset = asetContainer.Construct("Aligned").CreateOrUpdate(asetName).Value;

            Console.WriteLine($"Making sure {asetName} exists now.");
            if (!asetContainer.DoesExist(asetName))
                throw new Exception($"The availability set {asetName} should have existed.");

            Console.WriteLine("Using try get value to retrieve the rg");
            AvailabilitySet asetOutput = asetContainer.TryGet(asetName);
            if (asetOutput == null)
                throw new Exception($"The availability set {asetName} should have existed.");
                
            
        }
    }
}
