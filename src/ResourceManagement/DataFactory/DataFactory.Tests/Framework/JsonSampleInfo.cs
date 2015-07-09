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

using System.Collections.Generic;

namespace DataFactory.Tests.Framework
{
    /// <summary>
    /// Contains info about a JSON sample.
    /// </summary>
    public struct JsonSampleInfo
    {
        public string Name;
        public string Json;
        public string Version;
        public HashSet<string> PropertyBagKeys;

        public JsonSampleInfo(string name, string json, HashSet<string> propertyBagKeys)
            : this(name, json, null, propertyBagKeys)
        {
        }

        public JsonSampleInfo(
            string name,
            string json,
            string version,
            HashSet<string> propertyBagKeys)
        {
            this.Name = name;
            this.Json = json;
            this.Version = version;
            this.PropertyBagKeys = propertyBagKeys;
        }
    }
}
