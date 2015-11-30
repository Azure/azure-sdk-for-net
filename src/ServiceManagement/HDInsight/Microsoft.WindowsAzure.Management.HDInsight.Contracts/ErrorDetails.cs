using System.Net;
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    /// <summary>
    /// Class to represent an error that has been returned as part of a response to a passthrough request.
    /// </summary>
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ErrorDetails
    {
        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 1)]
        public HttpStatusCode StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 2)]
        public string ErrorId { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 3)]
        public string ErrorMessage { get; set; }
    }
}