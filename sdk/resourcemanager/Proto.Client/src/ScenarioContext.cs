using Azure.ResourceManager.Core;
using System;

namespace Proto.Client
{
    class ScenarioContext
    {
        public static readonly string AzureSdkSandboxId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";

        public string Hostname => $"{Environment.UserName}";
        public string VmName => $"{Environment.UserName}";
        public string RgName { get; private set; }
        public string NsgName => $"{Environment.UserName}-test-nsg";
        public string SubscriptionId { get; private set; }
        public string Loc => LocationData.WestUS2;
        public string SubnetName => $"{Environment.UserName}-subnet";

        public string PrincipalId => "4c5ce728-7350-4ae5-bcf1-42e8e33b00fe";

        public string RoleId => "acdd72a7-3385-48ef-bd42-f606fba81ae7";

        public ScenarioContext() : this(AzureSdkSandboxId) { }

        public ScenarioContext(string subscriptionId)
        {
            RgName = $"{Environment.UserName}-{Environment.TickCount}-rg";
            SubscriptionId = subscriptionId;
        }
    }
}