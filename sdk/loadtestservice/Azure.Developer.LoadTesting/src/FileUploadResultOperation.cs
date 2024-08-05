// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.LoadTesting.Models;

namespace Azure.Developer.LoadTesting
{
    /// <summary>
    /// FileUploadResultOperation.
    /// </summary>
    public class FileUploadResultOperation : Operation<TestFileInfo>
    {
        private bool _completed;
        private Response<TestFileInfo> _response;
        private TestFileInfo _value;
        private readonly string _testId;
        private readonly string _fileName;
        private readonly LoadTestAdministrationClient _client;
        private readonly List<string> _terminalStatus = new()
            {
                "VALIDATION_SUCCESS",
                "VALIDATION_FAILURE",
                "VALIDATION_NOT_REQUIRED"
            };

        /// <summary>
        /// Value.
        /// </summary>
        public override TestFileInfo Value
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
        /// FileUploadOperation.
        /// </summary>
        protected FileUploadResultOperation() { }

        /// <summary>
        /// FileUploadOperation.
        /// </summary>
        public FileUploadResultOperation(string testId, string fileName, LoadTestAdministrationClient client, Response<TestFileInfo> initialResponse = null)
        {
            _testId = testId;
            _fileName = fileName;
            _client = client;
            Id = $"{_testId}/{_fileName}";
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

            _response = _client.GetTestFile(_testId, _fileName);
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
                _response = await _client.GetTestFileAsync(_testId, _fileName).ConfigureAwait(false);
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
            string fileValidationStatus = _value.ValidationStatus.ToString();

            if (_terminalStatus.Contains(fileValidationStatus))
            {
                _completed = true;
            }

            return GetRawResponse();
        }
    }
}
