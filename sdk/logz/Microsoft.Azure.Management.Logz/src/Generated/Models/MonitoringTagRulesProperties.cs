// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Logz.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Definition of the properties for a TagRules resource.
    /// </summary>
    public partial class MonitoringTagRulesProperties
    {
        /// <summary>
        /// Initializes a new instance of the MonitoringTagRulesProperties
        /// class.
        /// </summary>
        public MonitoringTagRulesProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MonitoringTagRulesProperties
        /// class.
        /// </summary>
        public MonitoringTagRulesProperties(LogRules logRules = default(LogRules), SystemData systemData = default(SystemData))
        {
            LogRules = logRules;
            SystemData = systemData;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "logRules")]
        public LogRules LogRules { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "systemData")]
        public SystemData SystemData { get; set; }

    }
}
