// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public partial class MetadataValue
    {
        /// <summary> the name of the metadata. </summary>
        [CodeGenMember("Name")]
        internal LocalizableString LocalizedName { get; }

        public string Name => LocalizedName.Value;
    }
}