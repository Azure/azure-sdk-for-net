// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace HttpRecorder.Tests.MocServerTests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;

    public class MoqServerTestBase : IDisposable
    {
        private string _currentDir;

        protected string CurrentDir { get => _currentDir; set => _currentDir = value; }

        public MoqServerTestBase()
        {
            _currentDir = Directory.GetCurrentDirectory();// Environment.CurrentDirectory;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
        }

        private FakeHttpClient CreateClient()
        {
            return new FakeHttpClient(new DelegatingHandler[] { HttpMockServer.CreateInstance(), GetRecordingHandler() });
        }

        protected FakeHttpClient CreateClient(DelegatingHandler handler)
        {
            return new FakeHttpClient(new DelegatingHandler[] { HttpMockServer.CreateInstance(), handler });
        }

        private DelegatingHandler GetRecordingHandler()
        {
            var recordingHandler = new RecordedDelegatingHandler(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'error':'message'}")
            });
            recordingHandler.StatusCodeToReturn = HttpStatusCode.OK;
            return recordingHandler;
        }

        private FakeHttpClient CreateClientWithBadResult()
        {
            return new FakeHttpClient(new DelegatingHandler[] { HttpMockServer.CreateInstance(), GetRecordingHandlerWithBacdResponse() });
        }

        private DelegatingHandler GetRecordingHandlerWithBacdResponse()
        {
            var recordingHandlerWithBadResponse = new RecordedDelegatingHandler(new HttpResponseMessage(HttpStatusCode.Conflict));
            recordingHandlerWithBadResponse.StatusCodeToReturn = HttpStatusCode.Conflict;
            return recordingHandlerWithBadResponse;
        }

        public void Dispose()
        {
            string outputDir = Path.Combine(_currentDir, this.GetType().Name);
            if (Directory.Exists(outputDir))
            {
                try
                {
                    Directory.Delete(outputDir, true);
                }
                catch { }
            }

            HttpMockServer.RecordsDirectory = "SessionRecords";
        }
    }



}
