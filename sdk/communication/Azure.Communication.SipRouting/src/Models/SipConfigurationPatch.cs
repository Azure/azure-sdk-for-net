// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.SipRouting.Models
{
    public partial class SipConfigurationPatch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SipConfigurationPatch"/> class.
        /// </summary>
        /// <param name="trunks"></param>
        /// <param name="routes"></param>
        public SipConfigurationPatch(IDictionary<string,TrunkPatch> trunks, IList<TrunkRoute> routes):this()
        {
            Argument.AssertNotNull(trunks, nameof(trunks));
            Argument.AssertNotNull(routes, nameof(routes));

            foreach (var trunk in trunks)
            {
                Trunks.Add(trunk);
            }

            foreach (var route in routes)
            {
                Routes.Add(route);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipConfigurationPatch"/> class.
        /// </summary>
        /// <param name="trunks"></param>
        public SipConfigurationPatch(IDictionary<string, TrunkPatch> trunks) : this()
        {
            Argument.AssertNotNull(trunks, nameof(trunks));

            foreach (var trunk in trunks)
            {
                Trunks.Add(trunk);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipConfigurationPatch"/> class.
        /// </summary>
        /// <param name="routes"></param>
        public SipConfigurationPatch(IList<TrunkRoute> routes) : this()
        {
            Argument.AssertNotNull(routes, nameof(routes));

            foreach (var route in routes)
            {
                Routes.Add(route);
            }
        }
    }
}
