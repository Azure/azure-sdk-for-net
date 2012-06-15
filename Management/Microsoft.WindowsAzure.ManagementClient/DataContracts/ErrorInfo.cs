//-----------------------------------------------------------------------
// <copyright file="ErrorInfo.cs" company="Microsoft">
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
//    Contains code for the ErrorInfo class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents extended error information for failed Windows Azure API calls.
    /// </summary>
    [DataContract(Name = "Error", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ErrorInfo : AzureDataContractBase
    {
        /// <summary>
        /// The error code of the failed operation.
        /// </summary>
        [DataMember(Order = 0)]
        public string Code { get; private set; }

        /// <summary>
        /// A message about the failed operation.
        /// </summary>
        [DataMember(Order = 1)]
        public string Message { get; private set; }
    }
}
