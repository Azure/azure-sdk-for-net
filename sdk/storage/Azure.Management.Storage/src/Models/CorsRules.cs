// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Management.Storage.Models
{
    [CodeGenSchema("CorsRules")]
    public partial class CorsRules
    {
        // Override property name to avoid the class-property name conflict
        [CodeGenSchemaMember("corsRules")]
        public ICollection<CorsRule> Rules { get; set; }
    }
}