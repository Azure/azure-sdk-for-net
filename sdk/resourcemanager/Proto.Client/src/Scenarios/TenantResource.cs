using Azure.ResourceManager.Core;
using System;
using Proto.Billing;
using System.Diagnostics;
using Azure.Identity;

namespace Proto.Client
{
    class TenantResource : Scenario
    {
        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            TenantOperations tenant = client.Tenant;
            string testAccount = "9b84fb4c-c79a-4819-bd24-1e58f88885bd";
            // old value: "3984c6f4-2d2a-4b04-93ce-43cf4824b698:e2f1492a-a492-468d-909f-bf7fe6662c01_2019-05-31";
            // Note that the account may or may not be accessible, depending on your credentials
            BillingAccountOperations billingAccountOperations = tenant.GetBillingAccountsOperations(testAccount);
            var account = billingAccountOperations.Get();
            Debug.Assert(account.Value.Data.Name.Equals(testAccount));
        }
    }
}
