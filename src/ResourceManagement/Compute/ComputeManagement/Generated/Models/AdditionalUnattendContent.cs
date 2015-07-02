namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class AdditionalUnattendContent
    {
        /// <summary>
        /// Gets or sets the pass name. Currently, the only allowable value is
        /// oobeSystem. Possible values for this property include:
        /// 'oobeSystem'
        /// </summary>
        [JsonProperty(PropertyName = "passName")]
        public PassNames? PassName { get; set; }

        /// <summary>
        /// Gets or sets the component name. Currently, the only allowable
        /// value is Microsoft-Windows-Shell-Setup. Possible values for this
        /// property include: 'Microsoft-Windows-Shell-Setup'
        /// </summary>
        [JsonProperty(PropertyName = "componentName")]
        public ComponentNames? ComponentName { get; set; }

        /// <summary>
        /// Gets or sets setting name (e.g. FirstLogonCommands, AutoLogon ).
        /// Possible values for this property include: 'AutoLogon',
        /// 'FirstLogonCommands'
        /// </summary>
        [JsonProperty(PropertyName = "settingName")]
        public SettingNames? SettingName { get; set; }

        /// <summary>
        /// Gets or sets XML formatted content that is added to the
        /// unattend.xml file in the specified pass and component.The XML
        /// must be less than 4 KB and must include the root element for the
        /// setting or feature that is being inserted.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
