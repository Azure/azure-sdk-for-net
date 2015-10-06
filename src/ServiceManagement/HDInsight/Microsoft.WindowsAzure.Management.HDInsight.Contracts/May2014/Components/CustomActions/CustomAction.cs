using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.CustomActions
{
    /// <summary>
    /// Represents a customer-provided custom action.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    [KnownType(typeof(ScriptCustomAction))]
    internal abstract class CustomAction : RestDataContract
    {
        /// <summary>
        /// Gets or sets the name of the custom action.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the roles associated with this action.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public ClusterRoleCollection ClusterRoleCollection { get; set; }
    }
}