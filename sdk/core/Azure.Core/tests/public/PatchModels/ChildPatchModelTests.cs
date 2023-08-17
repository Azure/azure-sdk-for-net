// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Core.Tests.PatchModels;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ChildPatchModelTests : ModelJsonTests<ChildPatchModel>
    {
        protected override string JsonPayload => """
        {
            "a": "aa", "b": "bb"
        }
        """;

        protected override string WirePayload => JsonPayload;

        protected override Func<ChildPatchModel, RequestContent> ToRequestContent => m => m == null ? null : RequestContent.Create(m, ModelSerializerOptions.DefaultWireOptions);

        protected override Func<Response, ChildPatchModel> FromResponse => r => (ChildPatchModel)r;

        protected override void CompareModels(ChildPatchModel model, ChildPatchModel model2, ModelSerializerFormat format)
        {
            Assert.AreEqual(model.A, model2.A);
            Assert.AreEqual(model.B, model2.B);
        }

        protected override string GetExpectedResult(ModelSerializerFormat format)
        {
            return RemoveWhitespace(JsonPayload);
        }

        protected override void VerifyModel(ChildPatchModel model, ModelSerializerFormat format)
        {
            Assert.AreEqual("aa", model.A);
            Assert.AreEqual("bb", model.B);
        }

        private static string RemoveWhitespace(string value) => value.Replace("\r", "").Replace("\n", "").Replace(" ", "");
    }
}
