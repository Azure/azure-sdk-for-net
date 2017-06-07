//-----------------------------------------------------------------------
// <copyright file="OperationStatusInfo.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the OperationStatusInfo class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Net;
using System.Runtime.Serialization;

//disable warning about field never assigned to. It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents information about an ongoing, long-running operation.
    /// </summary>
    [DataContract(Name="Operation", Namespace=AzureConstants.AzureSchemaNamespace)]
    public class OperationStatusInfo : AzureDataContractBase
    {
        /// <summary>
        /// Gets the request id of the operation.
        /// </summary>
        [DataMember(Name = "ID", Order = 0)]
        public string RequestId { get; private set; }

        /// <summary>
        /// Gets the current <see cref="OperationStatus"/> of the operation. />
        /// </summary>
        [DataMember(Order=1)]
        public OperationStatus Status { get; private set; }

        /// <summary>
        /// If the operation is complete, will contain the HttpStatusCode for the operation.
        /// If the operation is in progress this will be null.
        /// </summary>
        public HttpStatusCode? HttpStatusCode 
        { 
            get
            {
                if(!string.IsNullOrEmpty(_httpStatusCode))
                {
                    return (HttpStatusCode)Enum.Parse(typeof(System.Net.HttpStatusCode), _httpStatusCode);
                }

                return null;
            }
        }

        /// <summary>
        /// If the operation status is Failed, this will contain the <see cref="ErrorInfo"/>
        /// for the failed operation. Null otherwise.
        /// </summary>
        [DataMember(Order=3, Name="Error", IsRequired=false, EmitDefaultValue=false)]
        public ErrorInfo ErrorInfo { get; private set; }

        [DataMember(Name = "HttpStatusCode", Order = 2, IsRequired = false, EmitDefaultValue = false)]
        private string _httpStatusCode;

        /// <summary>
        /// This method will throw an <see cref="AzureHttpRequestException"/> containing
        /// the corresponding <see cref="ErrorInfo"/> if the status of the operation info is "Failed."
        /// </summary>
        public void EnsureSuccessStatus()
        {
            if (Status == OperationStatus.Failed)
            {
                throw new AzureHttpRequestException(this);
            }
        }

    }


}
