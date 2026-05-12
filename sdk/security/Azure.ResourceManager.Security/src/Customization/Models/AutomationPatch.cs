// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Security.Models
{
    // Generated update helpers expect the standard Tags property name, while this patch model generated TagsProperty.
    public partial class AutomationPatch
    {
        public IDictionary<string, string> Tags => TagsProperty;
    }
}
