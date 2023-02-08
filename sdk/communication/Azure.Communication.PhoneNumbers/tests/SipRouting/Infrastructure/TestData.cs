// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests
{
    public class TestData
    {
        public readonly List<string> Fqdns;
        public readonly int[] TrunkPorts = { 1122, 1123 };

        public readonly List<SipTrunk> TrunkList;
        public readonly SipTrunk NewTrunk;

        public readonly SipTrunkRoute RuleNavigateToTrunk1;
        public readonly SipTrunkRoute RuleNavigateToAllTrunks;
        public readonly SipTrunkRoute RuleNavigateToNewTrunk;
        public readonly SipTrunkRoute RuleWithoutTrunks;

        public TestData(string domain)
        {
            Fqdns = new List<string>() { "sbs1." + domain + ".com", "sbs2." + domain + ".com" };
            TrunkList = new List<SipTrunk>
            {
                new SipTrunk(Fqdns[0], TrunkPorts[0]),
                new SipTrunk(Fqdns[1], TrunkPorts[1])
            };
            NewTrunk = new SipTrunk("newsbs." + domain + ".com", 3333);

            RuleNavigateToTrunk1 = new SipTrunkRoute(
                name: "First rule",
                description: "Handle numbers starting with '+123'",
                numberPattern: @"\+123[0-9]+",
                trunks: new List<string> { Fqdns[0] });
            RuleNavigateToAllTrunks = new SipTrunkRoute(
                name: "Last rule",
                description: "Handle all other numbers'",
                numberPattern: @"\+[1-9][0-9]{3,23}",
                trunks: Fqdns);
            RuleNavigateToNewTrunk = new SipTrunkRoute(
                name: "Alternative rule",
                description: "Handle all numbers'",
                numberPattern: @"\+[1-9][0-9]{3,23}",
                trunks: new List<string> { NewTrunk.Fqdn });
            RuleWithoutTrunks = new SipTrunkRoute(
                name: "Rule without trunks",
                description: "Handle all numbers'",
                numberPattern: @"\+[1-9][0-9]{3,23}",
                trunks: new List<string> ());
        }
    }
}
