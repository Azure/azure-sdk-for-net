using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.CustomActions
{
    /// <summary>
    /// Describes a custom action that runs a powershell or cmd script.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class ScriptCustomAction : CustomAction
    {
        /// <summary>
        /// Gets or sets the URI from which the script should be run.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the script.
        /// </summary>
        /// <value>
        /// Command-line parameters to the script
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public string Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptCustomAction"/> class.
        /// </summary>
        public ScriptCustomAction()
        {

        }
    }
}