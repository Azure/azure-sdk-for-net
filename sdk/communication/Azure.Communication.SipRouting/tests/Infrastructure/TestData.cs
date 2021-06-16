// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Communication.SipRouting.Models;

namespace Azure.Communication.SipRouting.Tests.Infrastructure
{
    internal static class TestData
    {
        public static readonly List<string> Fqdns = new List<string>(){ "sbs1.contoso.com", "sbs2.contoso.com" };
        public static readonly TrunkPatch[] TrunkPorts = { new TrunkPatch(1122), new TrunkPatch(1123) };

        public static readonly TrunkRoute RuleNavigateToTrunk1 = new TrunkRoute(
            name: "First rule",
            numberPattern: @"\+123[0-9]+",
            trunks: new List<string> { Fqdns[0] })
        {
            Description = "Handle numbers starting with '+123'",
        };

        public static readonly TrunkRoute RuleNavigateToAllTrunks = new TrunkRoute(
            name: "Last rule",
            numberPattern: @"\+[1-9][0-9]{3,23}",
            trunks: Fqdns)
        {
            Description = "Handle all other numbers'",
        };

        public static readonly Dictionary<string, TrunkPatch> TrunkDictionary = new Dictionary<string, TrunkPatch>()
        {
            { Fqdns[0], TrunkPorts[0]},
            { Fqdns[1], TrunkPorts[1]}
        };
    }
}
