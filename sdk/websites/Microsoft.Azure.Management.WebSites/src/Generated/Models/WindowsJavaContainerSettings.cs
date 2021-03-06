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
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Windows Java Container settings.
    /// </summary>
    public partial class WindowsJavaContainerSettings
    {
        /// <summary>
        /// Initializes a new instance of the WindowsJavaContainerSettings
        /// class.
        /// </summary>
        public WindowsJavaContainerSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WindowsJavaContainerSettings
        /// class.
        /// </summary>
        /// <param name="javaContainer">Java container (runtime only).</param>
        /// <param name="javaContainerVersion">Java container version (runtime
        /// only).</param>
        /// <param name="isPreview">&lt;code&gt;true&lt;/code&gt; if the stack
        /// is in preview; otherwise, &lt;code&gt;false&lt;/code&gt;.</param>
        /// <param name="isDeprecated">&lt;code&gt;true&lt;/code&gt; if the
        /// stack is deprecated; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;.</param>
        /// <param name="isHidden">&lt;code&gt;true&lt;/code&gt; if the stack
        /// should be hidden; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;.</param>
        /// <param name="endOfLifeDate">End-of-life date for the minor
        /// version.</param>
        /// <param name="isAutoUpdate">&lt;code&gt;true&lt;/code&gt; if the
        /// stack version is auto-updated; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;.</param>
        /// <param name="isEarlyAccess">&lt;code&gt;true&lt;/code&gt; if the
        /// minor version is early-access; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;.</param>
        public WindowsJavaContainerSettings(string javaContainer = default(string), string javaContainerVersion = default(string), bool? isPreview = default(bool?), bool? isDeprecated = default(bool?), bool? isHidden = default(bool?), System.DateTime? endOfLifeDate = default(System.DateTime?), bool? isAutoUpdate = default(bool?), bool? isEarlyAccess = default(bool?))
        {
            JavaContainer = javaContainer;
            JavaContainerVersion = javaContainerVersion;
            IsPreview = isPreview;
            IsDeprecated = isDeprecated;
            IsHidden = isHidden;
            EndOfLifeDate = endOfLifeDate;
            IsAutoUpdate = isAutoUpdate;
            IsEarlyAccess = isEarlyAccess;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets java container (runtime only).
        /// </summary>
        [JsonProperty(PropertyName = "javaContainer")]
        public string JavaContainer { get; private set; }

        /// <summary>
        /// Gets java container version (runtime only).
        /// </summary>
        [JsonProperty(PropertyName = "javaContainerVersion")]
        public string JavaContainerVersion { get; private set; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the stack is
        /// in preview; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        [JsonProperty(PropertyName = "isPreview")]
        public bool? IsPreview { get; private set; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the stack is
        /// deprecated; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        [JsonProperty(PropertyName = "isDeprecated")]
        public bool? IsDeprecated { get; private set; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the stack
        /// should be hidden; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        [JsonProperty(PropertyName = "isHidden")]
        public bool? IsHidden { get; private set; }

        /// <summary>
        /// Gets end-of-life date for the minor version.
        /// </summary>
        [JsonProperty(PropertyName = "endOfLifeDate")]
        public System.DateTime? EndOfLifeDate { get; private set; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the stack
        /// version is auto-updated; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        [JsonProperty(PropertyName = "isAutoUpdate")]
        public bool? IsAutoUpdate { get; private set; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the minor
        /// version is early-access; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        [JsonProperty(PropertyName = "isEarlyAccess")]
        public bool? IsEarlyAccess { get; private set; }

    }
}
