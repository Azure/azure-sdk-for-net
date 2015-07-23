using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// Complext type holding Error information about Stack configurations
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class IaasClusterError
    {
        /// <summary>
        /// A simple code for the failure
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// User friendly message about the failure.
        /// </summary>
        [DataMember(IsRequired = true)]
        public String ErrorDescription { get; set; }
    }
}