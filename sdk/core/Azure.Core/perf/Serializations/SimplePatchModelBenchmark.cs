// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Tests.PatchModels;

namespace Azure.Core.Perf.Serializations
{
    public class SimplePatchModelBenchmark : JsonBenchmark<SimplePatchModel>
    {
        protected override SimplePatchModel CastFromResponse() => (SimplePatchModel)_response;

        protected override RequestContent CastToRequestContent() => _model;

        protected override SimplePatchModel Deserialize(JsonElement jsonElement)
        {
            using Stream stream = new MemoryStream();
            using Utf8JsonWriter writer = new(stream);
            jsonElement.WriteTo(writer);
            writer.Flush();
            stream.Position = 0;
            return Deserialize(BinaryData.FromStream(stream));
        }

        protected override SimplePatchModel Deserialize(BinaryData data) => SimplePatchModel.Deserialize(data);

        protected override void Serialize(Utf8JsonWriter writer) => _model.Serialize(writer);

        protected override string JsonFileName => "SimplePatchModel.json";

        protected override void ModifyValues(SimplePatchModel model)
        {
            model.Name = "xyz";
            model.Count = 2;
        }
    }
}
