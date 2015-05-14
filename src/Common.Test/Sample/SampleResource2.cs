// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure
{
    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class SampleResource2 : Resource
    {
        /// <summary>
        /// Optional. Gets or sets the size of the resource.
        /// </summary>
        [JsonProperty("size")]
        public string Size2 { get; set; }
    }
}
