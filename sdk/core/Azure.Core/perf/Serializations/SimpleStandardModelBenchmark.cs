// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Tests.PatchModels;

namespace Azure.Core.Perf.Serializations
{
    public class SimpleStandardModelBenchmark : JsonBenchmark<SimpleStandardModel>
    {
        protected override SimpleStandardModel CastFromResponse() => (SimpleStandardModel)_response;

        protected override RequestContent CastToRequestContent() => _model;

        protected override SimpleStandardModel Deserialize(JsonElement jsonElement)
        {
            return SimpleStandardModel.DeserializeSimpleStandardModel(jsonElement, new("J"));
        }

        protected override void Serialize(Utf8JsonWriter writer) => _model.Serialize(writer);

        protected override string JsonFileName => "SimpleStandardModel.json";

        protected override void ModifyValues(SimpleStandardModel model)
        {
            model.Name = "xyz";
            model.Count = 2;
        }
    }
}
