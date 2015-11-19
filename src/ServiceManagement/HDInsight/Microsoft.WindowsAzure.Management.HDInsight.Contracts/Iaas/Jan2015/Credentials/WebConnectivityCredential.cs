using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// Web endpoint credentials
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class WebConnectivityCredential : ConnectivityCredential
    {
        /// <summary>
        /// Username 
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Username { get; set; }

        /// <summary>
        /// Password 
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Password { get; set; }
    }
}