using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// Class representing SSH connectivity endpoint
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class SSHConnectivityEndpoint : ConnectivityEndpoint
    {
        /// <summary>
        /// List of all avaialble connectivity credentials
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<SSHConnectivityCredential> Credentials { get; private set; }

        public SSHConnectivityEndpoint()
            : this(22)
        {
        }

        public SSHConnectivityEndpoint(uint port)
        {
            Port = port;
            Credentials = new List<SSHConnectivityCredential>();
        }
    }
}