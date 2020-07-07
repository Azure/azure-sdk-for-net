// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
            CentralizedPoisonQueue = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a single centralized
        /// poison queue for poison blobs should be used (in the primary
        /// storage account) or whether the poison queue for a blob triggered
        /// function should be co-located with the target blob container.
        /// This comes into play only when using multiple storage accounts via
        /// <see cref="StorageAccountAttribute"/>. The default is false.
        /// </summary>
        public bool CentralizedPoisonQueue { get; set; }

        public string Format()
        {
            JObject options = new JObject
            {
                { nameof(CentralizedPoisonQueue), CentralizedPoisonQueue }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
