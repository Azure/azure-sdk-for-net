// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Models
{
    public class GetManifestOptions
    {
        public GetManifestOptions(ManifestOrderBy orderBy)
        {
            OrderBy = orderBy;
        }
        
        public ManifestOrderBy OrderBy { get; }
    }
}
