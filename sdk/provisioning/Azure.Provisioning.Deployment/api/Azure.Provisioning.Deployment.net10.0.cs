namespace Azure.Provisioning
{
    public partial class ProvisioningDeployment
    {
        internal ProvisioningDeployment() { }
        public Azure.ResourceManager.Resources.ArmDeploymentResource Deployment { get { throw null; } }
        public Azure.ResponseError? Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?> Outputs { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ProvisioningDeploymentOptions
    {
        public ProvisioningDeploymentOptions() { }
        public Azure.ResourceManager.ArmClient ArmClient { get { throw null; } set { } }
        public Azure.Core.TokenCredential DefaultArmCredential { get { throw null; } set { } }
        public Azure.Core.TokenCredential DefaultClientCredential { get { throw null; } set { } }
        public Azure.Core.TokenCredential? DefaultCredential { get { throw null; } set { } }
        public System.Func<Azure.Core.TokenCredential> DefaultCredentialProvider { get { throw null; } set { } }
        public string? DefaultSubscriptionId { get { throw null; } set { } }
    }
    public static partial class ProvisioningPlanExtensions
    {
        public static string CompileArmTemplate(this Azure.Provisioning.ProvisioningPlan plan, string? optionalDirectoryPath = null) { throw null; }
        public static Azure.Provisioning.ProvisioningDeployment DeployToNewResourceGroup(this Azure.Provisioning.ProvisioningPlan plan, string resourceGroupName, Azure.Core.AzureLocation location, Azure.Provisioning.ProvisioningDeploymentOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Provisioning.ProvisioningDeployment> DeployToNewResourceGroupAsync(this Azure.Provisioning.ProvisioningPlan plan, string resourceGroupName, Azure.Core.AzureLocation location, Azure.Provisioning.ProvisioningDeploymentOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Provisioning.ProvisioningDeployment DeployToResourceGroup(this Azure.Provisioning.ProvisioningPlan plan, string resourceGroupName, Azure.Provisioning.ProvisioningDeploymentOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Provisioning.ProvisioningDeployment> DeployToResourceGroupAsync(this Azure.Provisioning.ProvisioningPlan plan, string resourceGroupName, Azure.Provisioning.ProvisioningDeploymentOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Collections.Generic.IReadOnlyList<Azure.Provisioning.Primitives.BicepErrorMessage> Lint(this Azure.Provisioning.ProvisioningPlan plan, string? optionalDirectoryPath = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult ValidateInResourceGroup(this Azure.Provisioning.ProvisioningPlan plan, string resourceGroupName, Azure.Provisioning.ProvisioningDeploymentOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult> ValidateInResourceGroupAsync(this Azure.Provisioning.ProvisioningPlan plan, string resourceGroupName, Azure.Provisioning.ProvisioningDeploymentOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Provisioning.Primitives
{
    public partial class BicepErrorMessage
    {
        internal BicepErrorMessage() { }
        public string? Code { get { throw null; } }
        public int? ColumnNumber { get { throw null; } }
        public string? FilePath { get { throw null; } }
        public bool? IsError { get { throw null; } }
        public int? LineNumber { get { throw null; } }
        public string? Message { get { throw null; } }
        public string RawText { get { throw null; } }
        public override string ToString() { throw null; }
    }
}
