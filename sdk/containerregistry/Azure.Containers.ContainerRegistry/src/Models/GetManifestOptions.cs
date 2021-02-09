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
        public GetManifestOptions(IEnumerable<string> orderBy)
        {
            OrderBy = orderBy.ToList();
        }
        
        // TODO: determine syntax supported by orderby to model this correctly
        public IList<string> OrderBy { get; }
    }
}
