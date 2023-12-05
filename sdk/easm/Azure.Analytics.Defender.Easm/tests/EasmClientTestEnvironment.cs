// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    public class EasmClientTestEnvironment : TestEnvironment
    {
        // public string Endpoint => GetRecordedVariable("ENDPOINT");
        public string Endpoint = "https://eastus.easm.defender.microsoft.com";
        // Add other client paramters here as above.
        public string ResourceGroupName => GetRecordedVariable("RESOURCEGROUPNAME", options => options.IsSecret());
        public string WorkspaceName => GetRecordedVariable("WORKSPACENAME", options => options.IsSecret());
        public string Region => GetRecordedVariable("REGION");

        public string Hosts = "ns1.ku.edu,ns2.ku.edu";
        public string Domains = "jayhawkconsulting.org,redtire.org";
        public string Mapping = "[{\"name\": \"example.com\",\"kind\": \"host\",\"external_id\": \"EXT040\"},{\"name\": \"example.com\",\"kind\": \"domain\",\"external_id\": \"EXT041\"}]";
        public string PartialName = "ku";
        public string TemplateId = "43488";
    }
}
