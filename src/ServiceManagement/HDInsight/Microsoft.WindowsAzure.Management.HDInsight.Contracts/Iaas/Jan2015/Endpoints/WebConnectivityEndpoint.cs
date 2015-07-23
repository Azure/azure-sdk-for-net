using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// Class representing Web(Https) connectivity endpoint
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class WebConnectivityEndpoint : ConnectivityEndpoint
    {
        /// <summary>
        /// List of all avaialble connectivity credentials
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<WebConnectivityCredential> Credentials { get; private set; }

        public WebConnectivityEndpoint()
            : this(443)
        {

        }

        public WebConnectivityEndpoint(uint port)
        {
            Port = port;
            Credentials = new List<WebConnectivityCredential>();
        }
    }
}