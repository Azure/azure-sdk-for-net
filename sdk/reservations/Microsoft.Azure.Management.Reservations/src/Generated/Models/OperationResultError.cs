// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Reservations.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Required if status == failed or status == canceled.
    /// </summary>
    public partial class OperationResultError
    {
        /// <summary>
        /// Initializes a new instance of the OperationResultError class.
        /// </summary>
        public OperationResultError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OperationResultError class.
        /// </summary>
        /// <param name="code">Required if status == failed or status ==
        /// cancelled. If status == failed, provide an invariant error code
        /// used for error troubleshooting, aggregation, and analysis.</param>
        /// <param name="message">Required if status == failed. Localized. If
        /// status == failed, provide an actionable error message indicating
        /// what error occurred, and what the user can do to address the
        /// issue.</param>
        public OperationResultError(string code = default(string), string message = default(string))
        {
            Code = code;
            Message = message;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets required if status == failed or status == cancelled.
        /// If status == failed, provide an invariant error code used for error
        /// troubleshooting, aggregation, and analysis.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets required if status == failed. Localized. If status ==
        /// failed, provide an actionable error message indicating what error
        /// occurred, and what the user can do to address the issue.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
