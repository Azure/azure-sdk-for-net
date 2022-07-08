// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests
{
    internal static class TestData
    {
        public static readonly List<string> Fqdns = new List<string>(){ "sbs1.sipconfigtest.com", "sbs2.sipconfigtest.com" };
        public static readonly int[] TrunkPorts = { 1122, 1123 };
        public static readonly List<string> Domains = new List<string>() { "sipconfigtest1.com", "sipconfigtest2.com" };
        public static readonly string CustomDomainType = DomainType.Custom.ToString();

        public static readonly List<SipTrunk> TrunkList = new List<SipTrunk>
        {
            new SipTrunk(Fqdns[0], TrunkPorts[0]),
            new SipTrunk(Fqdns[1], TrunkPorts[1])
        };

        public static readonly SipTrunk NewTrunk = new SipTrunk("newsbs.sipconfigtest.com", 3333);

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

        public static readonly SipTrunkRoute RuleNavigateToNewTrunk = new SipTrunkRoute(
            name: "Alternative rule",
            description: "Handle all numbers'",
            numberPattern: @"\+[1-9][0-9]{3,23}",
            trunks: new List<string> { NewTrunk.Fqdn });

        public static readonly SipDomain NewDomain = new SipDomain("sipconfigtest3.com", CustomDomainType);

        public static readonly List<SipDomain> DomainList = new List<SipDomain>
        {
            new SipDomain(Domains[0], CustomDomainType),
            new SipDomain(Domains[1], CustomDomainType)
        };
    }
}
