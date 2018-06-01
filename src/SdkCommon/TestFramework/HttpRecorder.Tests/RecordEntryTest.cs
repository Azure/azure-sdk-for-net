// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace HttpRecorder.Tests
{
    [Collection("SerialCollection1")]
    public class RecordEntryTest
    {
        [Fact]
        public void AddingETagWithGuidFormat_Works()
        {
            //Arrange
            string randomETagHeaderValue = "9792136f-ef2b-4a7c-98ce-c23f1be6bce4";
            string eTagHeaderName = "ETag";
            RecordEntry entry = new RecordEntry();
            Dictionary<string, List<string>> headers = new Dictionary<string, List<string>>();
            headers.Add(eTagHeaderName, new List<string> { randomETagHeaderValue });
            entry.ResponseHeaders = headers;
            entry.ResponseBody = "";

            //Act
            HttpResponseMessage response = entry.GetResponse();

            //Assert
            string actualHeaderValue = (response.Headers.GetValues(eTagHeaderName) as string[])[0];
            Assert.Equal(randomETagHeaderValue, actualHeaderValue);
        }

        [Fact]
        public void BinaryPayloadSurvivesSerialization()
        {
            byte[] imageSegment = new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70 };

            //Arrange
            HttpResponseMessage inResponse = new HttpResponseMessage()
            {
                Content = new ByteArrayContent(imageSegment),
                RequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.com/test")
            };
            inResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            //Act
            RecordEntry entry = new RecordEntry(inResponse);
            HttpResponseMessage outResponse = entry.GetResponse();

            //Assert
            byte[] bytes = outResponse.Content.ReadAsByteArrayAsync().Result;
            Assert.Equal(imageSegment, bytes);
        }
    }
}
