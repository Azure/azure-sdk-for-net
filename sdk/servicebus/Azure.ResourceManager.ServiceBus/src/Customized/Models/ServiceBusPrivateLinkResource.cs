// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceBus.Models
{
    [CodeGenSuppress("RequiredMembers")]
    [CodeGenSuppress("RequiredZoneNames")]
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
