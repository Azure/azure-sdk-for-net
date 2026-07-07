// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
namespace Azure.ResourceManager.ServiceBus.Models
{
    /// <summary>
    /// Backward compatibility: Keep the type of RequiredMembers and RequiredZoneNames
    /// as IReadOnlyList&lt;string&gt; as they are in the baseline version.
    /// </summary>
    public partial class ServiceBusPrivateLinkResource
    {
        /// <summary> Required Members. </summary>
        [WirePath("properties.requiredMembers")]
        public IReadOnlyList<string> RequiredMembers => Properties?.RequiredMembers as IReadOnlyList<string>;

        /// <summary> Required Zone Names. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames => Properties?.RequiredZoneNames as IReadOnlyList<string>;
    }
}
