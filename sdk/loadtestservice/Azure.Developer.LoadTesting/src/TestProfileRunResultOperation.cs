// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.LoadTesting
{
    /// <summary>
    /// Represents a long running operation for Test Profile Run.
    /// </summary>
    public class TestProfileRunResultOperation : Operation<TestProfileRun>
    {
        private bool _completed;
        private Response<TestProfileRun> _response;
        private TestProfileRun _value;
        private readonly string _testProfileRunId;
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
        public override TestProfileRun Value
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
        /// TestProfileRunResultOperation.
        /// </summary>
        protected TestProfileRunResultOperation() { }

        /// <summary>
        /// TestProfileRunResultOperation.
        /// </summary>
        public TestProfileRunResultOperation(string testProfileRunId, LoadTestRunClient client, Response<TestProfileRun> initialResponse = null)
        {
            _testProfileRunId = Id = testProfileRunId;
            _client = client;
            _completed = false;
            if (initialResponse != null)
            {
                _response = initialResponse;
                _value = _response.Value;
                GetCompletionResponse();
            }
        }

        /// <summary>
        /// GetRawResponse.
        /// </summary>
        public override Response GetRawResponse()
        {
            return _response.GetRawResponse();
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

            _response = _client.GetTestProfileRun(_testProfileRunId);
            _value = _response.Value;

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

            try
            {
                _response = await _client.GetTestProfileRunAsync(_testProfileRunId).ConfigureAwait(false);
                _value = _response.Value;
            }
            catch
            {
                throw new RequestFailedException(_response.GetRawResponse());
            }

            return GetCompletionResponse();
        }

        private Response GetCompletionResponse()
        {
            string testProfileRunStatus = _value.Status.ToString();

            if (_terminalStatus.Contains(testProfileRunStatus))
            {
                _completed = true;
            }

            return GetRawResponse();
        }
    }
}
