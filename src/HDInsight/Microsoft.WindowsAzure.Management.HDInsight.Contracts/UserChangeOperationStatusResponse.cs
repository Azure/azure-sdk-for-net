using System;
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    /// <summary>
    /// Class to represent the response to a request for the status of a user change operation.
    /// </summary>
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class UserChangeOperationStatusResponse
    {
        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 1)]
        public UserChangeOperationState State { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 2)]
        public UserType UserType { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 3)]
        public UserChangeOperationType OperationType { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 4)]
        public DateTime RequestIssueDate { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = false, Order = 5)]
        public ErrorDetails Error { get; set; }
    }
}
