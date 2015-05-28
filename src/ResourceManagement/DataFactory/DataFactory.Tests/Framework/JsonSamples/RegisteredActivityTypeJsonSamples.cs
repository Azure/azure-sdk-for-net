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

#if ADF_INTERNAL
namespace DataFactory.Tests.Framework.JsonSamples
{
    /// <summary>
    /// Contains Registerd ActivityType JSON samples. Samples added here will automatically be hit by the serialization unit tests. 
    /// </summary>
    public class RegisteredActivityTypeJsonSamples
    {
        [JsonSample]
        public const string DotNetActivity = @"
{ 
    ""name"": ""CloudMLActivity"", 
    ""properties"": { 
        ""baseType"": ""DotNetActivity"", 
        ""scope"": ""DataFactory"", 
        ""schema"": {
            ""properties"":{
                ""PackageFile"": {
                    ""type"": ""string"",
                    ""default"": ""container/Foo.Zip""
                },
                ""Bar"": {
                    ""type"": ""string""
                }
            },
            ""required"": [ ""PackageFile"", ""Bar"" ]
        }
    }
}";

        [JsonSample]
        public const string DotNetActivityNestedProperties = @"
{ 
    ""name"": ""CloudMLActivity"", 
    ""properties"": { 
        ""baseType"": ""DotNetActivity"", 
        ""scope"": ""DataFactory"", 
        ""schema"": {
            ""properties"":{
                ""PackageFile"": {
                    ""type"": ""object"",
                    ""properties"":{
                        ""prop1"":
                            {   
                                ""type"": ""string"",
                                ""default"":""container/Foo.Zip"",
                            },
                    },
                    ""required"":[ ""prop1"" ]
                },
                ""Bar"": {
                    ""type"": ""string""
                }
            },
            ""required"": [ ""PackageFile"", ""Bar"" ]
        }
        }
    }";
    }
}
#endif