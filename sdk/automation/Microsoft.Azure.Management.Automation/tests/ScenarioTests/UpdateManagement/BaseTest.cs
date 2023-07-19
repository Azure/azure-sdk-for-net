namespace Automation.Tests.ScenarioTests.UpdateManagement
{
    using Microsoft.Azure.Management.Automation;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Automation.Tests.Helpers;

    public class BaseTest
    {
        protected const string ResourceGroupName = "to-delete-02";
        protected const string AutomationAccountName = "fbs-aa-01";
        protected const string updateConfigurationName_01 = "test-suc-003";
        protected const string updateConfigurationName_02 = "test-suc-004";
        protected const string VM_01 = "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/sdk-tests-UM-rg/providers/Microsoft.Compute/virtualMachines/vmj-arm-01";
        protected const string VM_02 = "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/sdk-tests-UM-rg/providers/Microsoft.Compute/virtualMachines/vmj-arm-02";

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