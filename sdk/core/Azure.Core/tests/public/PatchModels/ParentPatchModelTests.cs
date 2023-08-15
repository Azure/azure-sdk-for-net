// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Core.Tests.PatchModels;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ParentPatchModelTests : ModelJsonTests<ParentPatchModel>
    {
        protected override string JsonPayload => """
        {
            "id": "abc",
            "child": {"a": "aa", "b": "bb"}
        }
        """;

        protected override string WirePayload => JsonPayload;

        protected override Func<ParentPatchModel, RequestContent> ToRequestContent => m => m == null ? null:  RequestContent.Create(m, ModelSerializerOptions.DefaultWireOptions);

        protected override Func<Response, ParentPatchModel> FromResponse => r => (ParentPatchModel)r;

        protected override void CompareModels(ParentPatchModel model, ParentPatchModel model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.Child.A, model2.Child.A);
            Assert.AreEqual(model.Child.B, model2.Child.B);
            Assert.AreEqual(model.Id, model2.Id);
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            return RemoveWhitespace(JsonPayload);
        }

        protected override void VerifyModel(ParentPatchModel model, ModelSerializerFormat format)
        {
            Assert.AreEqual("aa", model.Child.A);
            Assert.AreEqual("bb", model.Child.B);
            Assert.AreEqual("abc", model.Id);
        }

        private static string RemoveWhitespace(string value) => value.Replace("\r", "").Replace("\n", "").Replace(" ", "");
    }
}
