// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ResponseErrorTests
    {
        [Test]
        public void CanDeserializeNull()
        {
            Assert.Null(JsonSerializer.Deserialize<ResponseError>("null"));
        }

        [Test]
        public void CanDeserializeSimple()
        {
            var error = JsonSerializer.Deserialize<ResponseError>(
                "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something wasn't awesome\"," +
                "\"target\":\"Error target\"," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"message\":\"Inner message\"" +
                "}}");

            Assert.AreEqual("BadError", error.Code);
            Assert.AreEqual("Something wasn't awesome", error.Message);
            Assert.AreEqual("Error target", error.Target);

            Assert.AreEqual("MoreDetailedBadError", error.InnerError.Code);

            Assert.Null(error.InnerError.InnerError);
            Assert.AreEqual("BadError: Something wasn't awesome" + Environment.NewLine +
                            "Target: Error target" + Environment.NewLine +
                            Environment.NewLine +
                            "Inner Errors:" + Environment.NewLine +
                            "MoreDetailedBadError" + Environment.NewLine +
                            Environment.NewLine +
                            "Raw:" + Environment.NewLine +
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\"}}",
                error.ToString());
        }

        [Test]
        public void CanDeserializeComplex()
        {
            var error = JsonSerializer.Deserialize<ResponseError>(
                "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something wasn't awesome\"," +
                "\"target\":\"Error target\"," +
                "\"details\": [" +
                    "{\"code\":\"Code 1\",\"message\":\"Message 1\"}," +
                    "{\"code\":\"Code 2\",\"message\":\"Message 2\"}," +
                    "null" +
                "]," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"message\":\"Inner message\"," +
                    "\"innererror\":" +
                    "{" +
                        "\"code\":\"InnerMoreDetailedBadError\"," +
                        "\"message\":\"Inner Inner message\"" +
                    "}"+
                "}}");

            Assert.AreEqual("BadError", error.Code);
            Assert.AreEqual("Something wasn't awesome", error.Message);
            Assert.AreEqual("Error target", error.Target);

            Assert.AreEqual("MoreDetailedBadError", error.InnerError.Code);

            Assert.AreEqual("InnerMoreDetailedBadError", error.InnerError.InnerError.Code);

            Assert.AreEqual("Code 1", error.Details[0].Code);
            Assert.AreEqual("Message 1", error.Details[0].Message);

            Assert.AreEqual("Code 2", error.Details[1].Code);
            Assert.AreEqual("Message 2", error.Details[1].Message);

            Assert.AreEqual(2, error.Details.Count);

            Assert.Null(error.InnerError.InnerError.InnerError);

            Assert.AreEqual("BadError: Something wasn't awesome" + Environment.NewLine +
                            "Target: Error target" + Environment.NewLine +
                            Environment.NewLine +
                            "Inner Errors:" + Environment.NewLine +
                            "MoreDetailedBadError" + Environment.NewLine +
                            "InnerMoreDetailedBadError" + Environment.NewLine +
                            Environment.NewLine +
                            "Details:" + Environment.NewLine +
                            "Code 1: Message 1" + Environment.NewLine +
                            "Code 2: Message 2" + Environment.NewLine +
                            Environment.NewLine +
                            "Raw:" + Environment.NewLine +
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"details\": [{\"code\":\"Code 1\",\"message\":\"Message 1\"},{\"code\":\"Code 2\",\"message\":\"Message 2\"},null],\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\",\"innererror\":{\"code\":\"InnerMoreDetailedBadError\",\"message\":\"Inner Inner message\"}}}", error.ToString());
        }
    }
}