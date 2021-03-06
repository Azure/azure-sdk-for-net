// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.WebSites.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Web App stack.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class WebAppStack : ProxyOnlyResource
    {
        /// <summary>
        /// Initializes a new instance of the WebAppStack class.
        /// </summary>
        public WebAppStack()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WebAppStack class.
        /// </summary>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="location">Web App stack location.</param>
        /// <param name="displayText">Web App stack (display only).</param>
        /// <param name="value">Web App stack name.</param>
        /// <param name="majorVersions">List of major versions
        /// available.</param>
        /// <param name="preferredOs">Web App stack preferred OS. Possible
        /// values include: 'Windows', 'Linux'</param>
        public WebAppStack(string id = default(string), string name = default(string), string kind = default(string), string type = default(string), string location = default(string), string displayText = default(string), string value = default(string), IList<WebAppMajorVersion> majorVersions = default(IList<WebAppMajorVersion>), StackPreferredOs? preferredOs = default(StackPreferredOs?))
            : base(id, name, kind, type)
        {
            Location = location;
            DisplayText = displayText;
            Value = value;
            MajorVersions = majorVersions;
            PreferredOs = preferredOs;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets web App stack location.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; private set; }

        /// <summary>
        /// Gets web App stack (display only).
        /// </summary>
        [JsonProperty(PropertyName = "properties.displayText")]
        public string DisplayText { get; private set; }

        /// <summary>
        /// Gets web App stack name.
        /// </summary>
        [JsonProperty(PropertyName = "properties.value")]
        public string Value { get; private set; }

        /// <summary>
        /// Gets list of major versions available.
        /// </summary>
        [JsonProperty(PropertyName = "properties.majorVersions")]
        public IList<WebAppMajorVersion> MajorVersions { get; private set; }

        /// <summary>
        /// Gets web App stack preferred OS. Possible values include:
        /// 'Windows', 'Linux'
        /// </summary>
        [JsonProperty(PropertyName = "properties.preferredOs")]
        public StackPreferredOs? PreferredOs { get; private set; }

    }
}
