// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class OperationList
    {
        /// <summary>
        /// Initializes a new instance of the OperationList class.
        /// </summary>
        public OperationList() { }

        /// <summary>
        /// Initializes a new instance of the OperationList class.
        /// </summary>
        public OperationList(IList<Operation> value = default(IList<Operation>))
        {
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Operation> Value { get; set; }

    }
}
