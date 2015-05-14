// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Common.Test
{
    public class ResourceJsonConverterTest
    {
        [Fact]
        public void TestResourceSerialization()
        {
            var sampleResource = new SampleResource()
            {
                Size = "3",
                Child = new SampleResourceChild1()
                {
                    ChildId = "child",
                    ChildName1 = "name1"
                },
                Location = "EastUS"
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            
            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(json, deserializeSettings);
        }

        [Fact]
        public void TestResourceSerializationWithPolymorphism()
        {
            var sampleResource = new SampleResource()
            {
                Size = "3",
                Child = new SampleResourceChild()
                {
                    ChildId = "child"
                },
                Location = "EastUS"
            };
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Resource>("dType"));
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            string json = JsonConvert.SerializeObject(sampleResource, Formatting.Indented);
        }
    }
}
