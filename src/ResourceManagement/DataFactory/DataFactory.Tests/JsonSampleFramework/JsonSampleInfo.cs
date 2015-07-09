//==============================================================================
// Copyright (c) Microsoft Corporation. All Rights Reserved.
//==============================================================================

using System.Collections.Generic;

namespace Microsoft.DataPipeline.TestFramework.JsonSamples
{
    /// <summary>
    /// Contains info about a JSON sample.
    /// </summary>
    public struct JsonSampleInfo
    {
        public string Name;
        public string Json;
        public string Version;
        public JsonSampleType SampleType;
        public HashSet<string> PropertyBagKeys;

        public JsonSampleInfo(string name, string json, HashSet<string> propertyBagKeys)
            : this(name, json, null, propertyBagKeys)
        {
        }

        public JsonSampleInfo(
            string name,
            string json,
            string version,
            HashSet<string> propertyBagKeys,
            JsonSampleType sampleType = JsonSampleType.Both)
        {
            this.Name = name;
            this.Json = json;
            this.Version = version;
            this.PropertyBagKeys = propertyBagKeys;
            this.SampleType = sampleType;
        }
    }
}
