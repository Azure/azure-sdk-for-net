// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class JsonBinaryDataConverterTests
    {
        [Test]
        public void WriteTest()
        {
            IList<BinaryData> contextFeatures = new List<BinaryData>() {
                BinaryData.FromObjectAsJson(new { videoType = "documentary" }) ,
                BinaryData.FromObjectAsJson(new { day = "Monday"})
            };

            JsonSerializerOptions options = new()
            {
                Converters =
                {
                    new JsonBinaryDataConverter(),
                }
            };
            string content = JsonSerializer.Serialize(contextFeatures, options);
            Assert.IsTrue(content.Equals("[{\"videoType\":\"documentary\"},{\"day\":\"Monday\"}]"));
        }
    }
}
