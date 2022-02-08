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
        /// <param name="name"> Gets or sets name of the route. </param>
        /// <param name="numberPattern">
        /// Gets or sets regex number pattern for routing calls. .NET regex format is supported.
        /// The regex should match only digits with an optional &apos;+&apos; prefix without spaces.
        /// I.e. &quot;^\+[1-9][0-9]{3,23}$&quot;.
        ///<param name="description">Description of the routing setting for the users.</param>
        /// <param name="trunks">List of trunks on the route.</param>
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="numberPattern"/> is null. </exception>
        public SipTrunkRoute(string name, string numberPattern, string description = default, IEnumerable<string> trunks = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (numberPattern == null)
            {
                throw new ArgumentNullException(nameof(numberPattern));
            }

            Name = name;
            NumberPattern = numberPattern;
            Description = description;
            Trunks = trunks.ToList().AsReadOnly() ?? new List<string>().AsReadOnly();
        }

        /// <summary> Gets or sets description of the route. </summary>
        public string Description { get; }

        /// <summary> Gets or sets name of the route. </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets regex number pattern for routing calls. .NET regex format is supported.
        /// The regex should match only digits with an optional &apos;+&apos; prefix without spaces.
        /// I.e. &quot;^\+[1-9][0-9]{3,23}$&quot;.
        /// </summary>
        public string NumberPattern { get; }

        /// <summary> Gets or sets list of SIP trunks for routing calls. Trunks are represented as FQDN. </summary>
        public IReadOnlyList<string> Trunks { get; }
    }
}
