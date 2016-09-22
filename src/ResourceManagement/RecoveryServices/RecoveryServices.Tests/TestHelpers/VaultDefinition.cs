namespace Microsoft.Azure.Management.RecoveryServices.Tests
{
    public class VaultDefinition
    {
        private readonly string vaultName;

        public VaultDefinition(string vaultName)
        {
            this.vaultName = vaultName;
        }

        public string VaultName
        {
            get { return vaultName; }
        }

        public static VaultDefinition TestCrud = new VaultDefinition("SDKTestRsVault");

        public static VaultDefinition TestList = new VaultDefinition("SDKTestRsVault2");
    }
}
