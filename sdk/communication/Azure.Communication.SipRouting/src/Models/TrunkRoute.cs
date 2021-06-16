// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.SipRouting.Models
{
    public partial class TrunkRoute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrunkRoute"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numberPattern"></param>
        /// <param name="trunks"></param>
        public TrunkRoute(string name, string numberPattern, IList<string> trunks)
            : this(null, name, numberPattern, trunks)
        {
            Argument.AssertNotNullOrWhiteSpace(name, nameof(name));
            Argument.AssertNotNullOrWhiteSpace(numberPattern, nameof(numberPattern));
            Argument.AssertNotNullOrEmpty(trunks, nameof(trunks));
        }
    }
}
