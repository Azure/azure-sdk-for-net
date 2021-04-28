// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public partial class MetadataValue
    {
        [CodeGenMember("Name")]
        private LocalizableString LocalizedName { get; }

        /// <summary>
        /// Gets the name of the metadata value.
        /// </summary>
        public string Name => LocalizedName.Value;
    }
}