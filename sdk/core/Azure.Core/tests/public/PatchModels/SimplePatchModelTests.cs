// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Core.Tests.PatchModels;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class SimplePatchModelTests : ModelJsonTests<SimplePatchModel>
    {
        protected override string JsonPayload => """
            {
                "name": "abc",
                "count": 1,
                "updatedOn": "2023-10-19T10:19:10.0190001Z"
            }
            """;

        protected override string WirePayload => JsonPayload;

        protected override Func<SimplePatchModel, RequestContent> ToRequestContent => m => m == null ? null:  RequestContent.Create(m, ModelSerializerOptions.DefaultWireOptions);

        protected override Func<Response, SimplePatchModel> FromResponse => r => (SimplePatchModel)r;

        protected override void CompareModels(SimplePatchModel model, SimplePatchModel model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Count, model2.Count);
            Assert.AreEqual(model.UpdatedOn, model2.UpdatedOn);
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            return RemoveWhitespace(JsonPayload);
        }

        protected override void VerifyModel(SimplePatchModel model, ModelSerializerFormat format)
        {
            Assert.AreEqual("abc", model.Name);
            Assert.AreEqual(1, model.Count);
            Assert.AreEqual(DateTimeOffset.Parse("2023-10-19T10:19:10.0190001Z"), model.UpdatedOn);
        }

        private static string RemoveWhitespace(string value) => value.Replace("\r", "").Replace("\n", "").Replace(" ", "");
    }
}
