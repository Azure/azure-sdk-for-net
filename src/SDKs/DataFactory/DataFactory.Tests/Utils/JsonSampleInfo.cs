// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace DataFactory.Tests.Utils
{
    /// <summary>
    /// Contains info about a JSON sample.
    /// </summary>
    public struct JsonSampleInfo
    {
        public string Name;
        public string Json;
        public string Version;

        public JsonSampleInfo(string name, string json)
            : this(name, json, null)
        {
        }

        public JsonSampleInfo(
            string name,
            string json,
            string version)
        {
            this.Name = name;
            this.Json = json;
            this.Version = version;
        }
    }
}
