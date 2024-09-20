namespace Azure.Provisioning.CloudMachine
{
    public partial class CloudMachineInfrastructure : Azure.Provisioning.Infrastructure
    {
        public CloudMachineInfrastructure(string? name = "cm") : base (default(string)) { }
        public Azure.Provisioning.BicepParameter PrincipalIdParameter { get { throw null; } }
        public Azure.Provisioning.BicepParameter PrincipalNameParameter { get { throw null; } }
        public Azure.Provisioning.BicepParameter PrincipalTypeParameter { get { throw null; } }
        public override Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningContext? context = null) { throw null; }
    }
}
