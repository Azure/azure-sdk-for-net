// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    [CodeGenClient("TrunkRoute")]
    [CodeGenSuppress("SipTrunkRoute", typeof(string), typeof(string))]
    public partial class SipTrunkRoute
    {
        /// <summary> Initializes a new instance of <see cref="SipTrunkRoute"/>. </summary>
        /// <param name="name"> Name of the route. </param>
        /// <param name="numberPattern">
        /// Regex number pattern for routing calls. .NET regex format is supported.
        /// The regex should match only digits with an optional &apos;+&apos; prefix without spaces.
        /// I.e. &quot;^\+[1-9][0-9]{3,23}$&quot;.
        ///<param name="description">Description of the routing setting for the users.</param>
        /// <param name="trunks">List of trunks on the route.</param>
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="numberPattern"/> is null. </exception>
        public SipTrunkRoute(string name, string numberPattern, string description = default, IEnumerable<string> trunks = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            NumberPattern = numberPattern ?? throw new ArgumentNullException(nameof(numberPattern));
            Description = description;
            Trunks = trunks?.ToList().AsReadOnly() ?? new List<string>().AsReadOnly();
        }

        /// <summary> Description of the route. </summary>
        public string Description { get; }

        /// <summary> Name of the route. </summary>
        public string Name { get; }

        /// <summary>
        /// Regex number pattern for routing calls. .NET regex format is supported.
        /// The regex should match only digits with an optional &apos;+&apos; prefix without spaces.
        /// I.e. &quot;^\+[1-9][0-9]{3,23}$&quot;.
        /// </summary>
        public string NumberPattern { get; }

        /// <summary> List of SIP trunks for routing calls. Trunks are represented as FQDN. </summary>
        public IReadOnlyList<string> Trunks { get; }
    }
}
