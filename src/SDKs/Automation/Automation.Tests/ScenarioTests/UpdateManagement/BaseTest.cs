namespace Automation.Tests.ScenarioTests.UpdateManagement
{
    using Microsoft.Azure.Management.Automation;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Automation.Tests.Helpers;

    public class BaseTest
    {
        protected const string ResourceGroupName = "to-delete-01";
        protected const string AutomationAccountName = "fbs-aa-01";
        protected const string updateConfigurationName_01 = "test-suc-001";
        protected const string updateConfigurationName_02 = "test-suc-002";
        protected const string VM_01 = "/subscriptions/05fd3142-4b8e-4b16-8da9-98b4bbfd722d/resourceGroups/compute-01/providers/Microsoft.Compute/virtualMachines/vm-arm-01";
        protected const string VM_02 = "/subscriptions/05fd3142-4b8e-4b16-8da9-98b4bbfd722d/resourceGroups/to-delete/providers/Microsoft.Compute/virtualMachines/mo-arm-02";

        protected AutomationClient automationClient;

        protected void CreateAutomationClient(MockContext context)
        {
            if (this.automationClient == null)
            {
                var handler = new RecordedDelegatingHandler();
                this.automationClient = context.GetServiceClient<AutomationClient>(false, handler);
            }
        }
    }
}