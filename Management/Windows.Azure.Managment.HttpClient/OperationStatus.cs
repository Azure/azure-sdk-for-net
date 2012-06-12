using System;
using System.Net;
using System.Runtime.Serialization;

//disable warning about field never assigned to. It gets assigned at deserialization time
#pragma warning disable 649

namespace Windows.Azure.Management.v1_7
{
    [DataContract(Name = "Status")]
    public enum OperationStatus
    {
        [EnumMember]
        InProgress,

        [EnumMember]
        Succeeded,

        [EnumMember]
        Failed
    }

    [DataContract(Name="Operation", Namespace=AzureConstants.AzureSchemaNamespace)]
    public class OperationStatusInfo : AzureDataContractBase
    {
        [DataMember(Name = "ID", Order = 0)]
        public String RequestId { get; private set; }

        [DataMember(Order=1)]
        public OperationStatus Status { get; private set; }

        public HttpStatusCode? HttpStatusCode 
        { 
            get
            {

                if(!String.IsNullOrEmpty(_httpStatusCode))
                {
                    return (HttpStatusCode)Enum.Parse(typeof(System.Net.HttpStatusCode), _httpStatusCode);
                }

                return null;
            }
        }

        [DataMember(Order=3, Name="Error", IsRequired=false, EmitDefaultValue=false)]
        public ErrorInfo ErrorInfo { get; private set; }

        [DataMember(Name = "HttpStatusCode", Order = 2, IsRequired = false, EmitDefaultValue = false)]
        private String _httpStatusCode;

        public void EnsureSuccessStatus()
        {
            if (this.Status == OperationStatus.Failed)
            {
                throw new AzureHttpRequestException(this);
            }
        }

    }

    [DataContract(Name="Error", Namespace=AzureConstants.AzureSchemaNamespace)]
    public class ErrorInfo :  AzureDataContractBase
    {
        [DataMember(Order=0)]
        public String Code { get; private set; }

        [DataMember(Order=1)]
        public String Message { get; private set; }
    }
}
