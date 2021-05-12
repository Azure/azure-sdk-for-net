using Azure.ResourceManager.Core;
using System;
using System.Diagnostics;
using Azure.Identity;

namespace Proto.Client
{
    class GetSubscription : Scenario
    {
        public override void Execute()
        {
            var sandboxId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            var expectDisplayName = "Azure SDK sandbox";
            var subOp = new ArmClient(new DefaultAzureCredential()).GetSubscriptions().TryGet(sandboxId);
            Debug.Assert(expectDisplayName == subOp.Data.DisplayName);
            Console.WriteLine("Passed, got " + subOp.Data.DisplayName);
            
        }
    }
}
