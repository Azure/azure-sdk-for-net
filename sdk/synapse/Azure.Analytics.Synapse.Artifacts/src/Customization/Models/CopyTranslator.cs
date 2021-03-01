// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> A copy activity translator. </summary>
    public partial class CopyTranslator : IReadOnlyDictionary<string, object>
    {
        public CopyTranslator()
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
            Type = "CopyTranslator";
        }
    }
}
