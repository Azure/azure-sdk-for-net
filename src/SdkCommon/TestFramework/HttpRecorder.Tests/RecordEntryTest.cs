// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net.Http;
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
    }
}
