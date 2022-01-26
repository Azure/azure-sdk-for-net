// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    [CodeGenClient("TrunkRoute")]
    public partial class SipTrunkRoute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SipTrunkRoute"/> class.
        /// </summary>
        ///<param name="description">Description of the routing setting for the users.</param>
        /// <param name="name">Name of the route.</param>
        /// <param name="numberPattern">Regex number pattern for routing the calls.</param>
        /// <param name="trunks">List of trunks on the route.</param>
        public SipTrunkRoute(string description, string name, string numberPattern, IEnumerable<string> trunks)
        {
            Description = description;
            Name = name;
            NumberPattern = numberPattern;
            Trunks = trunks.ToList();
        }
    }
}
