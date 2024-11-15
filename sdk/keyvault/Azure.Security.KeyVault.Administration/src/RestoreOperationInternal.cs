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
    internal class RestoreOperationInternal<THeaders, TResult, TResponseType> : Operation<TResult>
        where TResult : class
        where TResponseType : class
    {
        /// <summary>
        /// The number of seconds recommended by the service to delay before checking on completion status.
        /// </summary>
        internal int? _retryAfterSeconds;
        private readonly KeyVaultBackupClient _client;
        private Response _response;
        private TResponseType _value;
        private readonly string _id;
        private RequestFailedException _requestFailedException;

        /// <summary>
        /// Creates an instance of a RestoreOperation from a previously started operation.
        ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
        /// to re-populate the details of this operation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id">The <see cref="Id" /> from a previous <see cref="KeyVaultBackupOperation" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="client"/> is null.</exception>
        public RestoreOperationInternal(KeyVaultBackupClient client, string id)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(client, nameof(client));

            _client = client;
            _id = id;
        }

        /// <summary>
        /// Initializes a new instance of a RestoreOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartRestore"/> or <see cref="KeyVaultBackupClient.StartRestoreAsync"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="response"/> is null.</exception>
        internal RestoreOperationInternal(KeyVaultBackupClient client, ResponseWithHeaders<THeaders> response)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(response, nameof(response));

            _client = client;
            _response = response.GetRawResponse();

            if (response is ResponseWithHeaders<AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders> fullRestoreHeaders)
            {
                _id = fullRestoreHeaders.Headers.JobId() ?? throw new InvalidOperationException("The response does not contain an Id");
                _retryAfterSeconds = fullRestoreHeaders.Headers.RetryAfter;
            }
            else if (response is ResponseWithHeaders<AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders> selectiveRestoreHeaders)
            {
                _id = selectiveRestoreHeaders.Headers.JobId() ?? throw new InvalidOperationException("The response does not contain an Id");
                _retryAfterSeconds = selectiveRestoreHeaders.Headers.RetryAfter;
            }
            else
            {
                throw new ArgumentException("Invalid header type", nameof(response));
            }
        }

        /// <summary>
        /// Initializes a new instance of a RestoreOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The response value that will be used to populate various properties.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> or <paramref name="response"/> or <paramref name="client"/> is null.</exception>
        internal RestoreOperationInternal(TResponseType value, Response response, KeyVaultBackupClient client)
        {
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(response, nameof(response));
            Argument.AssertNotNull(client, nameof(client));

            _client = client;
            _response = response;
            _value = value;
            _id = value switch
            {
                SelectiveKeyRestoreDetailsInternal r => r.JobId,
                RestoreDetailsInternal r => r.JobId,
                null => default,
                _ => throw new InvalidOperationException("Unknown type")
            };
        }

        /// <summary>
        /// The start time of the restore operation.
        /// </summary>
        public DateTimeOffset? StartTime => _value switch
        {
            SelectiveKeyRestoreDetailsInternal r => r.StartTime,
            RestoreDetailsInternal r => r.StartTime,
            null => default,
            _ => throw new InvalidOperationException("Unknown type")
        };

        /// <summary>
        /// The end time of the restore operation.
        /// </summary>
        public DateTimeOffset? EndTime => _value switch
        {
            SelectiveKeyRestoreDetailsInternal r => r.EndTime,
            RestoreDetailsInternal r => r.EndTime,
            null => default,
            _ => throw new InvalidOperationException("Unknown type")
        };

        /// <summary>
        /// The error value returned by the service call.
        /// </summary>
        internal KeyVaultServiceError Error => _value switch
        {
            SelectiveKeyRestoreDetailsInternal r => r.Error,
            RestoreDetailsInternal r => r.Error,
            null => default,
            _ => throw new InvalidOperationException("Unknown type")
        };

        /// <inheritdoc/>
        public override string Id => _id;

        /// <inheritdoc/>
        public override TResult Value
        {
            get
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                if (!HasCompleted)
                {
                    throw new InvalidOperationException("The operation is not complete.");
                }
                if (_requestFailedException != null)
                {
                    throw _requestFailedException;
                }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

                TResult result = null;
                Type resultType = typeof(TResult);

                if (resultType == typeof(KeyVaultRestoreResult))
                {
                    result = new KeyVaultRestoreResult(StartTime.Value, EndTime.Value) as TResult;
                }
                else if (resultType == typeof(KeyVaultSelectiveKeyRestoreResult))
                {
                    result = new KeyVaultSelectiveKeyRestoreResult(StartTime.Value, EndTime.Value) as TResult;
                }
                return result;
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => EndTime.HasValue;

        /// <inheritdoc/>
        public override bool HasValue => _response != null && Error == null && HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                try
                {
                    Type resultType = typeof(TResponseType);
                    Response<TResponseType> response = null;

                    if (resultType == typeof(RestoreDetailsInternal))
                    {
                        response = async ?
                            await _client.GetRestoreDetailsAsync(Id, cancellationToken).ConfigureAwait(false) as Response<TResponseType>
                            : _client.GetRestoreDetails(Id, cancellationToken) as Response<TResponseType>;
                    }
                    else if (resultType == typeof(SelectiveKeyRestoreDetailsInternal))
                    {
                        response = async ?
                            await _client.GetSelectiveKeyRestoreDetailsAsync(Id, cancellationToken).ConfigureAwait(false) as Response<TResponseType>
                            : _client.GetSelectiveKeyRestoreDetails(Id, cancellationToken) as Response<TResponseType>;
                    }

                    _value = response.Value;
                    _response = response.GetRawResponse();
                }
                catch (RequestFailedException ex)
                {
                    _requestFailedException = ex;
                    throw;
                }
                catch (Exception ex)
                {
                    _requestFailedException = new RequestFailedException("Unexpected Failure.", ex);
                    throw _requestFailedException;
                }

                if (_value != null && EndTime.HasValue && Error?.Code != null)
                {
                    _requestFailedException = _response != null ?
                        new RequestFailedException(_response)
                        : new RequestFailedException($"{Error.Message}\nInnerError: {Error.InnerError}\nCode: {Error.Code}");
                    throw _requestFailedException;
                }
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override ValueTask<Response<TResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _retryAfterSeconds.HasValue ? this.DefaultWaitForCompletionAsync(TimeSpan.FromSeconds(_retryAfterSeconds.Value), cancellationToken) :
                this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<TResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
