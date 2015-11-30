using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// A HdInsight stack connectivity endpoint
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    [KnownType(typeof(SSHConnectivityEndpoint))]
    [KnownType(typeof(WebConnectivityEndpoint))]
    internal class ConnectivityEndpoint
    {
        /// <summary>
        /// Connectivity protocol for the endpoint. Example is Https, SSH, TCP etc
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Protocol { get; set; }

        /// <summary>
        /// Location for the endpoint
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Location { get; set; }

        /// <summary>
        /// Name for this connectivity endpoint as specified in document
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        /// <summary>
        /// Port for endpoint.
        /// </summary>
        [DataMember(IsRequired = true)]
        public uint Port { get; set; }
    }
}