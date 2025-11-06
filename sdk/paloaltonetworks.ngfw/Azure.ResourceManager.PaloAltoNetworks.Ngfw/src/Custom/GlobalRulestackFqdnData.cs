// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class GlobalRulestackFqdnData
    {
        /// <summary> Initializes a new instance of <see cref="GlobalRulestackFqdnData"/>. </summary>
        /// <param name="fqdnList"> fqdn list. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fqdnList"/> is null. </exception>
        public GlobalRulestackFqdnData(IEnumerable<string> fqdnList)
        {
            Argument.AssertNotNull(fqdnList, nameof(fqdnList));

            foreach (var item in FqdnList)
            {
                FqdnList.Add(item);
            }
        }
    }
}
