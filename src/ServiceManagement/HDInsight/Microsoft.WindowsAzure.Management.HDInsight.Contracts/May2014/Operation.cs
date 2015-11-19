namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class Operation : RestDataContract
    {
        /// <summary>
        /// Gets or sets the operation id.
        /// </summary>
        /// <value>
        /// The operation id.
        /// </value>
        [DataMember]
        public string OperationId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the error details.
        /// </summary>
        /// <value>
        /// The error details.
        /// </value>
        [DataMember]
        public ErrorDetails ErrorDetails { get; set; }
    }

    public static class OperationStatus
    {
        public const string InProgress = "InProgress";
        public const string Failed = "Failed";
        public const string Succeeded = "Succeeded";
    }
}
