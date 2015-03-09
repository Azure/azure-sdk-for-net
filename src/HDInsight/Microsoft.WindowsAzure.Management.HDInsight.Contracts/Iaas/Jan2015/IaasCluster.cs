using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// Class representing information about a provisioned IaaS deployment in HdInsight
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class IaasCluster
    {
        /// <summary>
        /// Azure subscriptionId owning this instance
        /// </summary>
        [DataMember(IsRequired = true)]
        public string UserSubscriptionId { get; set; }

        /// <summary>
        /// Azure location where this cluster is provisioned
        /// </summary>
        [DataMember(IsRequired = true)]
        public String Location { get; set; }

        /// <summary>
        /// Unique client specified id for the stack instance
        /// </summary>
        [DataMember(IsRequired = true)]
        public String Id { get; set; }

        /// <summary>
        /// Remote HdInsight id for the stack instance
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public long TenantId { get; set; }

        /// <summary>
        /// State of the stack instance
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public String State { get; set; }

        /// <summary>
        /// API Schema version with which this deployment was created.
        /// </summary>
        [DataMember(IsRequired = true)]
        public String ApiVersion { get; set; }

        /// <summary>
        /// Version of the stack
        /// </summary>
        [DataMember(IsRequired = true)]
        public String HdiVersion { get; set; }

        /// <summary>
        /// Date this deployment was created
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// A list of the user specified stack configuration documents
        /// </summary>
        [DataMember(IsRequired = true)]
        public IDictionary<string, string> DeploymentDocuments { get; set; }

        /// <summary>
        /// A list of errors object indicating failure if State is error
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public List<IaasClusterError> Errors { get; set; }

        /// <summary>
        /// A generic key value properties bag for passing additional adhoc information.
        /// Examples of adhoc information can be following
        /// - User specified tags
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IDictionary<String, String> UserTags { get; set; }

        /// <summary>
        /// A collection of Connectivity endpoints that is available for this cluster.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IList<ConnectivityEndpoint> ConnectivityEndpoints { get; set; }
    }
}
