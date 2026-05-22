// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // 1.1.0 back-compat: the previous shipped surface returned IReadOnlyList<string> for
    // these two collections. The TypeSpec generator emits IList<string> from the flattened
    // Properties envelope. We suppress the generated properties and re-expose them with the
    // legacy IReadOnlyList signature so existing callers continue to compile and the
    // ApiCompat baseline (1.1.0) check passes without an ApiCompatBaseline.txt entry.
    [CodeGenSuppress("RequiredMembers")]
    [CodeGenSuppress("RequiredZoneNames")]
    public partial class EventGridPrivateLinkResourceData
    {
        /// <summary> Gets the required members. </summary>
        [WirePath("properties.requiredMembers")]
        public IReadOnlyList<string> RequiredMembers
        {
            get
            {
                IList<string> list = Properties?.RequiredMembers;
                return list is null ? null : new List<string>(list);
            }
        }

        /// <summary> Gets the required zone names. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames
        {
            get
            {
                IList<string> list = Properties?.RequiredZoneNames;
                return list is null ? null : new List<string>(list);
            }
        }
    }
}
