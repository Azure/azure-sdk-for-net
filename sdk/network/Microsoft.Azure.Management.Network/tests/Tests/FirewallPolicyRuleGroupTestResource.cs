// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Networks.Tests
{
    using System.IO;
    using Newtonsoft.Json.Linq;

    internal static class FirewallPolicyRuleGroupTestResource
    {
        internal static JObject GetSampleResource()
        {
            var sampleResourceJson = File.ReadAllText("TestData/FirewallPolicyRuleGroupSampleResource.json");
            var json = sampleResourceJson.Replace("'", "\"");
            var resource = JObject.Parse(json).ToObject<JObject>();

            return resource;
        }
    }
}