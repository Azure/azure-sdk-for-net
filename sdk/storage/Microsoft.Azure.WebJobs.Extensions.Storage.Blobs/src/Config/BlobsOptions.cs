// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Represents configuration for <see cref="BlobTriggerAttribute"/>.
    /// </summary>
    public class BlobsOptions : IOptionsFormatter
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public BlobsOptions()
        {
            // TODO
            MaxDegreeOfParallelism = 1;
        }

        /// <summary>
        /// </summary>
        public int MaxDegreeOfParallelism { get; set; }

        /// <inheritdoc/>
        public string Format()
        {
            JObject options = new JObject
            {
                { nameof(MaxDegreeOfParallelism), MaxDegreeOfParallelism }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
