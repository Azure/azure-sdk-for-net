// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat overload: previous SDK ordered ServiceGroupData factory parameters as
// (id, name, resourceType, systemData, kind, tags, properties). The regenerated factory
// puts properties before kind/tags. Keep the old signature so existing callers compile.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceGroups.Models;

namespace Azure.ResourceManager.ServiceGroups.Models
{
    public static partial class ArmServiceGroupsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ServiceGroups.ServiceGroupData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceGroupData ServiceGroupData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            string kind,
            IDictionary<string, string> tags,
            ServiceGroupProperties properties)
            => ServiceGroupData(id, name, resourceType, systemData, properties, kind, tags);
    }
}
