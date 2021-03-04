using Azure.ResourceManager.Core;
using System;
using Proto.Billing;

namespace Proto.Client
{
    class TenantResource : Scenario
    {
        public override void Execute()
        {
            var client = new AzureResourceManagerClient();
            TenantOperations tenant = client.Tenant;
            BillingAccountOperations billingAccountOperations = tenant.GetBillingAccountsOperations("AME-Redmond-Account");
        }
    }
}
