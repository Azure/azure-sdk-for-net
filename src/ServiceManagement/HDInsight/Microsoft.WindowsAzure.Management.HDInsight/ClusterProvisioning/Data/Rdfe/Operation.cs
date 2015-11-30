namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class Operation : IExtensibleDataObject
    {
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        public string OperationId { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public string Status { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public HttpStatusCode HttpStatusCode { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public Error Error { get; private set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    internal class Error : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false)]
        public string Code { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; private set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }

    internal static class OperationStatus
    {
        public const string InProgress = "InProgress";
        public const string Failed = "Failed";
        public const string Succeeded = "Succeeded";
    }
}