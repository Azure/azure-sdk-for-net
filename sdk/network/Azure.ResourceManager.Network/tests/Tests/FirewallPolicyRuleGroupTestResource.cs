// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    internal static class FirewallPolicyRuleGroupTestResource
    {
        internal static JsonElement GetSampleResource()
        {
            string sampleResourceJson = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "FirewallPolicyRuleGroupSampleResourceAsync.json"));
            JsonElement jsonTemplate = JsonSerializer.Deserialize<JsonElement>(sampleResourceJson);

            return jsonTemplate;
        }
    }
}
