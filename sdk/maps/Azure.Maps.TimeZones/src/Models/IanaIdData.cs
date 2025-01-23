// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Maps.TimeZones
{
    /// <summary> The Iana IDs information. </summary>
    public partial class IanaIdData
    {
        /// <summary> Initializes a new instance of <see cref="IanaIdData"/>. </summary>
        internal IanaIdData(IReadOnlyList<IanaId> ianaIds)
        {
            IanaIds = ianaIds;
        }

        /// <summary> The list of IANA IDs. </summary>
        public IReadOnlyList<IanaId> IanaIds { get; }
    }
}
