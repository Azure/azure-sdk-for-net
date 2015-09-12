using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// A base class representing credential for a HdInsight Connectivity endpoint
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    [KnownType(typeof(SSHConnectivityCredential))]
    [KnownType(typeof(WebConnectivityCredential))]
    internal class ConnectivityCredential
    {
        /// <summary>
        /// Type of connectivity credentials
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Type { get; set; }
    }
}