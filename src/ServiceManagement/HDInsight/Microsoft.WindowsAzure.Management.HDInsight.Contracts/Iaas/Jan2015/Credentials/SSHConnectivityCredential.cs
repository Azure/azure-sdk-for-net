using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// Represents a SSH public key credential. Represents the public key certs configured by user.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    [KnownType(typeof(SSHFullConnectivityCredential))]
    internal class SSHConnectivityCredential : ConnectivityCredential
    {
        /// <summary>
        /// Public key part for a SSH credential
        /// </summary>
        [DataMember(IsRequired = true)]
        public string PublicKey { get; private set; }
    }
}