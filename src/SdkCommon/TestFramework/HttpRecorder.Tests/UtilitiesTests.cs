// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text;

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

        [Fact]
        public void TestIsRequestBodyBinary()
        {
            HttpContent GenerateHeaders(string mimeType)
            {
                HttpResponseMessage message = new HttpResponseMessage();
                if (mimeType != null)
                {
                    message.Content = new StringContent(string.Empty, Encoding.UTF8, mimeType);
                }
                return message.Content;
            }

            Assert.False(Utilities.IsRequestBodyBinary(GenerateHeaders(null)));
            Assert.False(Utilities.IsRequestBodyBinary(GenerateHeaders("text/plain")));
            Assert.False(Utilities.IsRequestBodyBinary(GenerateHeaders("application/json")));
            Assert.False(Utilities.IsRequestBodyBinary(GenerateHeaders("application/xml")));
            Assert.True(Utilities.IsRequestBodyBinary(GenerateHeaders("image/jpeg")));
            Assert.True(Utilities.IsRequestBodyBinary(GenerateHeaders("video/mp4")));
            Assert.True(Utilities.IsRequestBodyBinary(GenerateHeaders("audio/ogg")));
            Assert.True(Utilities.IsRequestBodyBinary(GenerateHeaders("application/octet-stream")));
        }
    }
}
