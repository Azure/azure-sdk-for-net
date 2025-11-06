// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class LocalRulestackPrefixData
    {
        /// <summary> Initializes a new instance of <see cref="LocalRulestackPrefixData"/>. </summary>
        /// <param name="prefixList"> prefix list. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prefixList"/> is null. </exception>
        public LocalRulestackPrefixData(IEnumerable<string> prefixList)
        {
            Argument.AssertNotNull(prefixList, nameof(prefixList));

            foreach (var item in prefixList)
            {
                PrefixList.Add(item);
            }
        }
    }
}
