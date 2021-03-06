// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Personalizer.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// An object containing more specific information than the parent object
    /// about the error.
    /// </summary>
    public partial class InternalError
    {
        /// <summary>
        /// Initializes a new instance of the InternalError class.
        /// </summary>
        public InternalError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the InternalError class.
        /// </summary>
        /// <param name="code">Detailed error code.</param>
        /// <param name="innererror">The error object.</param>
        public InternalError(string code = default(string), InternalError innererror = default(InternalError))
        {
            Code = code;
            Innererror = innererror;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets detailed error code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the error object.
        /// </summary>
        [JsonProperty(PropertyName = "innererror")]
        public InternalError Innererror { get; set; }

    }
}
