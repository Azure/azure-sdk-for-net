// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Core.Tests.PatchModels;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class RoundTripPatchModelTests : ModelJsonTests<RoundTripPatchModel>
    {
        protected override string JsonPayload => """
            {
                "id": "abc",
                "value": 1
            }
            """;

        protected override string WirePayload => JsonPayload;

        protected override Func<RoundTripPatchModel, RequestContent> ToRequestContent => m => m == null ? null:  RequestContent.Create(m, ModelSerializerOptions.DefaultWireOptions);

        protected override Func<Response, RoundTripPatchModel> FromResponse => r => (RoundTripPatchModel)r;

        protected override void CompareModels(RoundTripPatchModel model, RoundTripPatchModel model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Id, model2.Id);
            Assert.AreEqual(model.Value, model2.Value);
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            return RemoveWhitespace(JsonPayload);
        }

        protected override void VerifyModel(RoundTripPatchModel model, ModelSerializerFormat format)
        {
            Assert.AreEqual("abc", model.Id);
            Assert.AreEqual(1, model.Value);
        }

        private static string RemoveWhitespace(string value) => value.Replace("\r", "").Replace("\n", "").Replace(" ", "");
    }
}
