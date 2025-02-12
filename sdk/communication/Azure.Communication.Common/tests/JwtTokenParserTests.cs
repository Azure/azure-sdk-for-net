// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication;
using NUnit.Framework;

namespace Azure.Communication
{
    public class JwtTokenParserTests
    {
        [Test]
        public void DecodeJwtPayload_InvalidBase64String_ShouldThrowFormatException()
        {
            string invalidBase64UrlString = "Invalid_Base64_String";
            Assert.Throws<FormatException>(() => JwtTokenParser.DecodeJwtPayload(invalidBase64UrlString), "Token payload is not formatted correctly.");
        }

        [Test]
        public void DecodeJwtPayload_InvalidTokenParts_ShouldThrowFormatException()
        {
            string invalidToken = "Invalid.Token";
            Assert.Throws<FormatException>(() => JwtTokenParser.DecodeJwtPayload(invalidToken), "Token does not have the correct number of parts.");
        }
    }
}
