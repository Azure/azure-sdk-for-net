using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// Class representing a SSH credential containing both private and public keys
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class SSHFullConnectivityCredential : SSHConnectivityCredential
    {
        /// <summary>
        /// Private key of the SSH credential
        /// </summary>
        [DataMember(IsRequired = true)]
        public string PrivateKey { get; private set; }
    }
}