// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Communication.SipRouting;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests.Infrastructure
{
    internal static class TestData
    {
        public static readonly List<string> Fqdns = new List<string>(){ "sbs1.sipconfigtest.com", "sbs2.sipconfigtest.com" };
        public static readonly SipTrunk[] TrunkPorts = { new SipTrunk(1122), new SipTrunk(1123) };

        public static readonly SipTrunkRoute RuleNavigateToTrunk1 = new SipTrunkRoute(
            name: "First rule",
            description: "Handle numbers starting with '+123'",
            numberPattern: @"\+123[0-9]+",
            trunks: new List<string> { Fqdns[0] });

        public static readonly SipTrunkRoute RuleNavigateToAllTrunks = new SipTrunkRoute(
            name: "Last rule",
            description: "Handle all other numbers'",
            numberPattern: @"\+[1-9][0-9]{3,23}",
            trunks: Fqdns);

        public static readonly Dictionary<string, SipTrunk> TrunkDictionary = new Dictionary<string, SipTrunk>()
        {
            { Fqdns[0], TrunkPorts[0]},
            { Fqdns[1], TrunkPorts[0]}
        };
    }
}
