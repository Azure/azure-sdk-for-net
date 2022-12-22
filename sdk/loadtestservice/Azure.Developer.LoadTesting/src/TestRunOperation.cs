// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    /// <summary>
    /// TestRunOperation.
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
            string status;
            try
            {
                JsonNode jsonDocument = JsonNode.Parse(_value.ToString());
                JsonNode validationStatus = jsonDocument!["status"]!;

                status = validationStatus.ToString();
            }
            catch
            {
                throw new Exception($"Test run status not found for test run {_testRunId}");
            }

            if (_terminalStatus.Contains(status))
            {
                _completed = true;
            }

            return GetRawResponse();
        }
    }
}
