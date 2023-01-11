// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.LoadTesting
{
    /// <summary>
    /// Represents a long-running operation for TestRun.
    /// </summary>
    public class TestRunOperation : Operation<BinaryData>
    {
        private bool _completed;
        private Response _response;
        private BinaryData _value;
        private readonly string _testRunId;
        private readonly LoadTestRunClient _client;
        private readonly List<string> _terminalStatus = new()
            {
                "DONE",
                "FAILED",
                "CANCELLED"
            };

        /// <summary>
        /// Value.
        /// </summary>
        public override BinaryData Value => _value;

        /// <summary>
        /// HasValue
        /// </summary>
        public override bool HasValue => _completed;

        /// <summary>
        /// Id.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// HasCompleted
        /// </summary>
        public override bool HasCompleted => _completed;

        /// <summary>
        /// FileUploadOperation.
        /// </summary>
        protected TestRunOperation() { }

        /// <summary>
        /// FileUploadOperation.
        /// </summary>
        public TestRunOperation(string testRunId, LoadTestRunClient client, Response initialResponse = null)
        {
            _testRunId = Id = testRunId;
            _client = client;
            _completed = false;
            if (initialResponse != null)
            {
                _response = initialResponse;
                _value = _response.Content;
                GetCompletionResponse();
            }
        }

        /// <summary>
        /// GetRawResponse.
        /// </summary>
        public override Response GetRawResponse()
        {
            return _response;
        }

        /// <summary>
        /// UpdateStatus.
        /// </summary>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                return GetRawResponse();
            }

            _response = _client.GetTestRun(_testRunId);
            _value = _response.Content;

            return GetCompletionResponse();
        }

        /// <summary>
        /// UpdateStatusAsync.
        /// </summary>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                return GetRawResponse();
            }

            _response = await _client.GetTestRunAsync(_testRunId).ConfigureAwait(false);
            _value = _response.Content;

            return GetCompletionResponse();
        }

        private Response GetCompletionResponse()
        {
            string testRunStatus;

            JsonDocument jsonDocument = JsonDocument.Parse(_value.ToString());
            testRunStatus = jsonDocument.RootElement.GetProperty("status").GetString();

            if (_terminalStatus.Contains(testRunStatus))
            {
                _completed = true;
            }

            return GetRawResponse();
        }
    }
}
