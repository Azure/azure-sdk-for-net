// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HttpRecorder.Tests
{
    [Collection("SerialCollection1")]
    public class UtilitiesTests
    {
        [Fact]
        public void GetCurrentMethodNameReturnsName()
        {
            Assert.Equal("GetCurrentMethodNameReturnsName", TestUtilities.GetCurrentMethodName());
        }

        //[Fact]
        //public void DetectContentyTypeFromPayLoad()
        //{
        //    string nullLiteral = "null";
        //    byte[] literalByteArray = Encoding.ASCII.GetBytes(nullLiteral);
        //    string s = Convert.ToBase64String(literalByteArray);
        //}
    }
}
