using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;

namespace Microsoft.Azure.Management.SecurityInsights.Tests.AlertRules
{
    public static class AlertRulesUtils
    {
        public static MicrosoftSecurityIncidentCreationAlertRule GetDefaultAlertRuleProperties() => new MicrosoftSecurityIncidentCreationAlertRule()
        {
            ProductFilter = "Microsoft Cloud App Security",
            Enabled = true,
            DisplayName = "SDKTest"
        };

        public static ActionRequest GetDefaultAlertRuleActionProperties() => new ActionRequest
        {
            LogicAppResourceId = TestHelper.ActionLAResourceID,
            TriggerUri = TestHelper.ActionLATriggerUri
        };
    }
}
