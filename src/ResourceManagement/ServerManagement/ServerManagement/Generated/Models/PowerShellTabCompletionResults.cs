
namespace Microsoft.Azure.Management.ServerManagement.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// an array of strings representing the different values that can be
    /// tabbed thru
    /// </summary>
    public partial class PowerShellTabCompletionResults
    {
        /// <summary>
        /// Initializes a new instance of the PowerShellTabCompletionResults
        /// class.
        /// </summary>
        public PowerShellTabCompletionResults() { }

        /// <summary>
        /// Initializes a new instance of the PowerShellTabCompletionResults
        /// class.
        /// </summary>
        public PowerShellTabCompletionResults(IList<string> results = default(IList<string>))
        {
            Results = results;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public IList<string> Results { get; set; }

    }
}
