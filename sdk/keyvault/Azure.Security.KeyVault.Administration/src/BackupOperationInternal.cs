// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    internal class BackupOperationInternal<THeaders, TResult, TResponseType> : Operation<TResult>
        where TResult : class
        where TResponseType : class
    {
        internal int? _retryAfterSeconds;
        private readonly KeyVaultBackupClient _client;
        private Response _response;
        private TResponseType _value;
        private readonly string _id;
        private RequestFailedException _requestFailedException;

        public BackupOperationInternal(KeyVaultBackupClient client, string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(client, nameof(client));
            _client = client;
            _id = id;
        }

        internal BackupOperationInternal(KeyVaultBackupClient client, ResponseWithHeaders<THeaders> response)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(response, nameof(response));
            _client = client;
            _response = response.GetRawResponse();

            if (response is ResponseWithHeaders<AzureSecurityKeyVaultAdministrationFullBackupHeaders> fullBackupHeaders)
            {
                _id = fullBackupHeaders.Headers.JobId() ?? throw new InvalidOperationException("The response does not contain an Id");
                _retryAfterSeconds = fullBackupHeaders.Headers.RetryAfter;
            }
            else if (response is ResponseWithHeaders<AzureSecurityKeyVaultAdministrationPreFullBackupHeaders> preFullBackupHeaders)
            {
                _id = preFullBackupHeaders.Headers.JobId() ?? throw new InvalidOperationException("The response does not contain an Id");
                _retryAfterSeconds = preFullBackupHeaders.Headers.RetryAfter;
            }
            else
            {
                throw new ArgumentException("Invalid header type", nameof(response));
            }
        }

        internal BackupOperationInternal(TResponseType value, Response response, KeyVaultBackupClient client)
        {
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(response, nameof(response));
            Argument.AssertNotNull(client, nameof(client));

            _client = client;
            _response = response;
            _value = value;
            _id = value switch
            {
                FullBackupDetailsInternal r => r.JobId,
                null => default,
                _ => throw new InvalidOperationException("Unknown type")
            };
        }

        public DateTimeOffset? StartTime => _value switch
        {
            FullBackupDetailsInternal backup => backup.StartTime,
            null => default,
            _ => throw new InvalidOperationException("Unknown type")
        };

        public DateTimeOffset? EndTime => _value switch
        {
            FullBackupDetailsInternal backup => backup.EndTime,
            null => default,
            _ => throw new InvalidOperationException("Unknown type")
        };

        internal KeyVaultServiceError Error => _value switch
        {
            FullBackupDetailsInternal backup => backup.Error,
            null => default,
            _ => throw new InvalidOperationException("Unknown type")
        };

        public override string Id => _id;

        public override TResult Value
        {
            get
            {
                if (!HasCompleted)
                {
                    throw new InvalidOperationException("The operation is not complete.");
                }
                if (_requestFailedException != null)
                {
                    throw _requestFailedException;
                }

                TResult result = null;
                Type resultType = typeof(TResult);

                if (resultType == typeof(KeyVaultBackupResult))
                {
                    FullBackupDetailsInternal details = _value as FullBackupDetailsInternal;
                    result = new KeyVaultBackupResult(new Uri(details.AzureStorageBlobContainerUri), StartTime.Value, EndTime.Value) as TResult;
                }
                return result;
            }
        }

        public override bool HasCompleted => EndTime.HasValue;

        public override bool HasValue => _response != null && Error == null && HasCompleted;

        public override Response GetRawResponse() => _response;

        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                try
                {
                    Response<FullBackupDetailsInternal> response = async ?
                        await _client.GetBackupDetailsAsync(Id, cancellationToken).ConfigureAwait(false) :
                        _client.GetBackupDetails(Id, cancellationToken);

                    _value = response.Value as TResponseType;
                    _response = response.GetRawResponse();
                }
                catch (RequestFailedException ex)
                {
                    _requestFailedException = ex;
                    throw;
                }
                catch (Exception ex)
                {
                    _requestFailedException = new RequestFailedException("Unexpected failure", ex);
                    throw _requestFailedException;
                }

                if (_value != null && EndTime.HasValue && Error?.Code != null)
                {
                    _requestFailedException = _response != null ?
                        new RequestFailedException(_response) :
                        new RequestFailedException($"{Error.Message}\nInnerError: {Error.InnerError}\nCode: {Error.Code}");
                    throw _requestFailedException;
                }
            }

            return GetRawResponse();
        }

        public override ValueTask<Response<TResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _retryAfterSeconds.HasValue ? this.DefaultWaitForCompletionAsync(TimeSpan.FromSeconds(_retryAfterSeconds.Value), cancellationToken) :
                this.DefaultWaitForCompletionAsync(cancellationToken);

        public override ValueTask<Response<TResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}