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

    public partial class Operation
    {
        /// <summary>
        /// Initializes a new instance of the Operation class.
        /// </summary>
        public Operation() { }

        /// <summary>
        /// Initializes a new instance of the Operation class.
        /// </summary>
        public Operation(string name = default(string), Display display = default(Display))
        {
            Name = name;
            Display = display;
        }

        /// <summary>
        /// Gets or sets the name of the operation being performed on this
        /// particular object. This name should match the action name that
        /// appears in RBAC / the event service.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "display")]
        public Display Display { get; set; }

    }
}
