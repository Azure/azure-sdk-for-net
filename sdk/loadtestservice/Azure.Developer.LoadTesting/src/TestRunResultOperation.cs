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
    public class TestRunResultOperation : Operation<BinaryData>
    {
        private bool _completed;
        private Response _response;
        private BinaryData _value;
        private readonly string _testRunId;
        private readonly LoadTestRunClient _client;
        private readonly List<string> _terminalStatuses = new()
            {
                "DONE",
                "FAILED",
                "CANCELLED"
            };

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public override BinaryData Value
        {
            get
            {
                if (HasCompleted && !HasValue)
                {
                    throw new InvalidOperationException("The operation is not complete.");
                }
                else
                {
                    return _value;
                }
            }
        }

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public override bool HasValue => _completed;

        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public override bool HasCompleted => _completed;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRunResultOperation"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected TestRunResultOperation() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRunResultOperation"/> class which
        /// tracks the status of a long-running operation for uploading a file to a test.
        /// </summary>
        /// <param name="testRunId">The ID of the test run.</param>
        /// <param name="client">An instance of the Load Test Run Client.</param>
        /// <param name="initialResponse">The initial response from the server.</param>
        public TestRunResultOperation(string testRunId, LoadTestRunClient client, Response initialResponse = null)
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
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="TestRunResultOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public override Response GetRawResponse()
        {
            return _response;
        }

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                return GetRawResponse();
            }

            _response = _client.GetTestRun(_testRunId).GetRawResponse();
            _value = _response.Content;

            return GetCompletionResponse();
        }

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (_completed)
            {
                return GetRawResponse();
            }

            try
            {
                var initialResponse = await _client.GetTestRunAsync(_testRunId).ConfigureAwait(false);
                _response = initialResponse.GetRawResponse();
                _value = _response.Content;
            }
            catch
            {
                throw new RequestFailedException(_response);
            }

            return GetCompletionResponse();
        }

        private Response GetCompletionResponse()
        {
            string testRunStatus;
            JsonDocument jsonDocument;

            try
            {
                jsonDocument = JsonDocument.Parse(_value.ToMemory());
            }
            catch (Exception e)
            {
                throw new RequestFailedException("Unable to parse JSON: " + e.Message, e);
            }

            try
            {
                testRunStatus = jsonDocument.RootElement.GetProperty("status").GetString();
            }
            catch
            {
                throw new RequestFailedException("No property status in response JSON: " + _value.ToString());
            }

            if (_terminalStatuses.Contains(testRunStatus))
            {
                _completed = true;
            }

            return GetRawResponse();
        }
    }
}
