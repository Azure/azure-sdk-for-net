// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace DataFactory.Tests.Framework.JsonSamples
{
    /// <summary>
    /// Contains Hub JSON samples. Samples added here will automatically be hit by the serialization unit tests. 
    /// </summary>
    public class HubJsonSamples : JsonSampleCollection<HubJsonSamples>
    {
        [JsonSample]
        public const string AzureHubWithDefault = @"
{
  ""name"": ""SampleHub"",
  ""properties"": {
    ""type"": ""Hub"",
    ""hubId"": ""00000000-0000-0000-0000-000000000001"",
    ""provisioningState"": ""Succeeded""
  }
}
";

        [JsonSample]
        public const string AzureHubNoDefault = @"
{
  ""name"": ""SampleHub"",
  ""properties"": {
    ""type"": ""Hub"",
    ""hubId"": ""00000000-0000-0000-0000-000000000001"",
    ""provisioningState"": ""Succeeded""
  }
}
";

        [JsonSample]
        public const string InternalHub = @"
{
  ""name"": ""SampleHub"",
  ""properties"": {
    ""type"": ""InternalHub"",
    ""hubId"": ""00000000-0000-0000-0000-000000000001"",
    ""provisioningState"": ""Succeeded""
  }
}
";
    }
}
