namespace Azure.CloudMachine
{
    public partial class CloudMachineInfrastructure
    {
        public CloudMachineInfrastructure(string cmId) { }
        public string Id { get { throw null; } }
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public void AddEndpoints<T>() { }
        public void AddFeature(Azure.Provisioning.CloudMachine.CloudMachineFeature resource) { }
        public void AddResource(Azure.Provisioning.Primitives.NamedProvisionableConstruct resource) { }
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
        public static bool Configure(string[] args, System.Action<Azure.CloudMachine.CloudMachineInfrastructure>? configure = null) { throw null; }
    }
}
namespace Azure.CloudMachine.KeyVault
{
    public partial class KeyVaultFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public KeyVaultFeature(Azure.Provisioning.KeyVault.KeyVaultSku? sku = null) { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        public override void AddTo(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { }
    }
}
namespace Azure.CloudMachine.OpenAI
{
    public partial class AIModel
    {
        public AIModel(string model, string modelVersion) { }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
    }
    public partial class OpenAIFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public OpenAIFeature() { }
        public Azure.CloudMachine.OpenAI.AIModel? Chat { get { throw null; } set { } }
        public Azure.CloudMachine.OpenAI.AIModel? Embeddings { get { throw null; } set { } }
        public override void AddTo(Azure.CloudMachine.CloudMachineInfrastructure cloudMachine) { }
    }
}
namespace Azure.Provisioning.CloudMachine
{
    public abstract partial class CloudMachineFeature
    {
        protected CloudMachineFeature() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public abstract void AddTo(Azure.CloudMachine.CloudMachineInfrastructure cm);
    }
}
namespace System.ClientModel.TypeSpec
{
    public static partial class TypeSpecWriter
    {
        public static void WriteModel(System.IO.Stream output, System.Type model) { }
        public static void WriteModel<T>(System.IO.Stream output) { }
        public static void WriteServer(System.IO.Stream output, System.Type service) { }
        public static void WriteServer<T>(System.IO.Stream output) { }
    }
}
