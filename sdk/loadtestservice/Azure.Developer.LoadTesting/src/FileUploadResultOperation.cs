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

namespace Azure.Developer.LoadTesting
{
    /// <summary>
    /// FileUploadResultOperation.
    /// </summary>
    public class FileUploadResultOperation : Operation<BinaryData>
    {
        private bool _completed;
        private Response _response;
        private BinaryData _value;
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
        public FileUploadResultOperation(string testId, string fileName, LoadTestAdministrationClient client, Response initialResponse = null)
        {
            _testId = testId;
            _fileName = fileName;
            _client = client;
            Id = $"{_testId}/{_fileName}";
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

            _response = _client.GetTestFile(_testId, _fileName);
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

            try
            {
                _response = await _client.GetTestFileAsync(_testId, _fileName).ConfigureAwait(false);
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
            string fileValidationStatus;
            JsonDocument jsonDocument;

            try
            {
                jsonDocument = JsonDocument.Parse(_value.ToMemory());
            }
            catch (Exception e)
            {
                throw new RequestFailedException("Unable to parse JOSN " + e.Message);
            }

            try
            {
                fileValidationStatus = jsonDocument.RootElement.GetProperty("validationStatus").GetString();
            }
            catch
            {
                throw new RequestFailedException("No property validationStatus in reposne JSON: " + _value.ToString());
            }

            if (_terminalStatus.Contains(fileValidationStatus))
            {
                _completed = true;
            }

            return GetRawResponse();
        }
    }
}
