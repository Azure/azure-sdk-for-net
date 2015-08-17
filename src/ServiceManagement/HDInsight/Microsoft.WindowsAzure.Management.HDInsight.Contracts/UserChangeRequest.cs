using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    /// <summary>
    /// Base class for Http or RDP User change requests
    /// </summary>
    [DataContract(Namespace = Constants.XsdNamespace)]
    [KnownType(typeof(HttpUserChangeRequest))]
    [KnownType(typeof(RdpUserChangeRequest))]
    public abstract class UserChangeRequest
    {
        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 1)]
        public UserChangeOperationType Operation { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 2)]
        public string Username { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 3)]
        public string Password { get; set; }
    }
}
