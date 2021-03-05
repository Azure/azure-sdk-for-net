using Azure.ResourceManager.Core;
using System;
using Proto.Billing;

namespace Proto.Client
{
    class TenantResource : Scenario
    {
        public override void Execute()
        {
            var sandboxId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            var subOp = new AzureResourceManagerClient().GetSubscriptionOperations(sandboxId);
            var result = subOp.Get();
            var client = new AzureResourceManagerClient();
            TenantOperations tenant = client.Tenant;
            BillingAccountOperations billingAccountOperations = tenant.GetBillingAccountsOperations("3984c6f4-2d2a-4b04-93ce-43cf4824b698:e2f1492a-a492-468d-909f-bf7fe6662c01_2019-05-31");
            billingAccountOperations.Get();
        }
    }
}
