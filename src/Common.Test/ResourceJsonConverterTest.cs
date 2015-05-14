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
                Child = new SampleResourceChild()
                {
                    ChildId = "child"
                },
                Location = "EastUS"
            };
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            string json = JsonConvert.SerializeObject(sampleResource, Formatting.Indented);
        }
    }
}
