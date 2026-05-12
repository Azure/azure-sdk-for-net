// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Security.Models
{
    public partial class AutomationPatch
    {
        public IDictionary<string, string> Tags => TagsProperty;
    }
}
