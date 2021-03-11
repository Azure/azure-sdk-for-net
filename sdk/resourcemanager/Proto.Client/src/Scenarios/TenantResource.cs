using Azure.ResourceManager.Core;
using System;
using Proto.Billing;
using System.Diagnostics;

namespace Proto.Client
{
    class TenantResource : Scenario
    {
        public override void Execute()
        {
            var client = new AzureResourceManagerClient();
            TenantOperations tenant = client.Tenant;
            string testAccount = "3984c6f4-2d2a-4b04-93ce-43cf4824b698:e2f1492a-a492-468d-909f-bf7fe6662c01_2019-05-31";
            BillingAccountOperations billingAccountOperations = tenant.GetBillingAccountsOperations(testAccount);
            var account = billingAccountOperations.Get();
            Debug.Assert(account.Value.Data.Name.Equals(testAccount));
        }
    }
}
