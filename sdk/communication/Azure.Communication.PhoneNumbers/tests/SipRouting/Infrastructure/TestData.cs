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
        public static readonly bool Enabled = true;

        public static readonly List<SipTrunk> TrunkList = new List<SipTrunk>
        {
            new SipTrunk(Fqdns[0], TrunkPorts[0], Enabled),
            new SipTrunk(Fqdns[1], TrunkPorts[1], Enabled)
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

        public static readonly SipDomain NewDomain = new SipDomain("sipconfigtest3.com", Enabled);

        public static readonly List<SipDomain> DomainList = new List<SipDomain>
        {
            new SipDomain(Domains[0], Enabled),
            new SipDomain(Domains[1], Enabled)
        };

        public static readonly List<SipDomain> DomainList_Mocked = new List<SipDomain>
        {
            new SipDomain("contoso.com", Enabled)
        };

        public static readonly List<SipTrunk> TrunksList_Mocked = new List<SipTrunk>
        {
            new SipTrunk("acs.contoso.com", 123, Enabled)
        };

        public static readonly List<SipTrunkRoute> RoutesList_Mocked = new List<SipTrunkRoute>
        {
            new SipTrunkRoute(
                name: "R1",
                description: null,
                numberPattern: ".*",
                trunks: new List<string> { "acs.contoso.com" })
        };

        public static readonly List<SipDomain> DomainList_NewMocked = new List<SipDomain>
        {
            new SipDomain("contoso123.com", Enabled)
        };

        public static readonly List<SipTrunk> TrunksList_NewMocked = new List<SipTrunk>
        {
            new SipTrunk("acs.contoso123.com", 124, Enabled)
        };

        public static readonly List<SipTrunkRoute> RoutesList_NewMocked = new List<SipTrunkRoute>
        {
            new SipTrunkRoute(
                name: "R123",
                description: "New route",
                numberPattern: ".*",
                trunks: new List<string> { "acs.contoso123.com" })
        };
    }
}
