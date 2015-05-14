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
    public partial class SampleResource : Resource
    {
        /// <summary>
        /// Optional. Gets or sets the size of the resource.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// Optional. Gets or sets the child resource.
        /// </summary>
        [JsonProperty("child")]
        public SampleResourceChild Child { get; set; }

        /// <summary>
        /// Optional. Gets or sets the details.
        /// </summary>
        [JsonProperty("name")]
        public dynamic Details { get; set; }
    }

    /// <summary>
    /// Information for resource.
    /// </summary>
    public abstract class SampleResourceChild
    {
        /// <summary>
        /// Optional. Gets or sets the Id of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string ChildId { get; set; }
    }

    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class SampleResourceChild1 : SampleResourceChild
    {
        /// <summary>
        /// Optional. Gets or sets the Id of the resource.
        /// </summary>
        [JsonProperty("name1")]
        public string ChildName1 { get; set; }
    }

    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class SampleResourceChild2 : SampleResourceChild
    {
        /// <summary>
        /// Optional. Gets or sets the Id of the resource.
        /// </summary>
        [JsonProperty("name2")]
        public string ChildName2 { get; set; }
    }
}
