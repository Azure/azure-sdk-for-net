// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository.Fetchers
{
    /// <summary>
    /// The HttpModelFetcher is an implementation of IModelFetcher
    /// for supporting http[s] based model content fetching.
    /// </summary>
    internal class HttpModelFetcher : IModelFetcher
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        public HttpModelFetcher(ClientDiagnostics clientDiagnostics, ModelsRepositoryClientOptions clientOptions)
        {
            _pipeline = CreatePipeline(clientOptions);
            _clientDiagnostics = clientDiagnostics;
        }

        public FetchModelResult FetchModel(
            string dtmi, Uri repositoryUri, bool tryFromExpanded, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(HttpModelFetcher)}.{nameof(FetchModel)}");
            scope.Start();
            try
            {
                Queue<string> work = PrepareWork(dtmi, repositoryUri, tryFromExpanded);

                string remoteFetchError = string.Empty;

                while (work.Count != 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string tryContentPath = work.Dequeue();
                    ModelsRepositoryEventSource.Instance.FetchingModelContent(tryContentPath);

                    try
                    {
                        string content = EvaluatePath(tryContentPath, cancellationToken);
                        return new FetchModelResult
                        {
                            Definition = content,
                            Path = tryContentPath
                        };
                    }
                    catch (Exception)
                    {
                        remoteFetchError =
                            $"{string.Format(CultureInfo.InvariantCulture, StandardStrings.GenericGetModelsError, dtmi)} " +
                            string.Format(CultureInfo.InvariantCulture, StandardStrings.ErrorFetchingModelContent, tryContentPath);
                    }
                }

                throw new RequestFailedException(remoteFetchError);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        public async Task<FetchModelResult> FetchModelAsync(
            string dtmi, Uri repositoryUri, bool tryFromExpanded, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(HttpModelFetcher)}.{nameof(FetchModel)}");
            scope.Start();
            try
            {
                Queue<string> work = PrepareWork(dtmi, repositoryUri, tryFromExpanded);

                string remoteFetchError = string.Empty;
                RequestFailedException requestFailedExceptionThrown = null;
                Exception genericExceptionThrown = null;

                while (work.Count != 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string tryContentPath = work.Dequeue();
                    ModelsRepositoryEventSource.Instance.FetchingModelContent(tryContentPath);

                    try
                    {
                        string content = await EvaluatePathAsync(tryContentPath, cancellationToken).ConfigureAwait(false);
                        return new FetchModelResult()
                        {
                            Definition = content,
                            Path = tryContentPath
                        };
                    }
                    catch (RequestFailedException ex)
                    {
                        requestFailedExceptionThrown = ex;
                    }
                    catch (Exception ex)
                    {
                        genericExceptionThrown = ex;
                    }

                    if (genericExceptionThrown != null || requestFailedExceptionThrown != null)
                    {
                        remoteFetchError =
                            $"{string.Format(CultureInfo.InvariantCulture, StandardStrings.GenericGetModelsError, dtmi)} " +
                            string.Format(CultureInfo.InvariantCulture, StandardStrings.ErrorFetchingModelContent, tryContentPath);
                    }
                }

                if (requestFailedExceptionThrown != null)
                {
                    throw new RequestFailedException(
                        requestFailedExceptionThrown.Status,
                        remoteFetchError,
                        requestFailedExceptionThrown.ErrorCode,
                        requestFailedExceptionThrown);
                }
                else
                {
                    throw new RequestFailedException(
                        (int)HttpStatusCode.BadRequest,
                        remoteFetchError,
                        null,
                        genericExceptionThrown);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static Queue<string> PrepareWork(string dtmi, Uri repositoryUri, bool tryExpanded)
        {
            var work = new Queue<string>();

            if (tryExpanded)
            {
                work.Enqueue(DtmiConventions.GetModelUri(dtmi, repositoryUri, true).AbsoluteUri);
            }

            work.Enqueue(DtmiConventions.GetModelUri(dtmi, repositoryUri, false).AbsoluteUri);

            return work;
        }

        private string EvaluatePath(string path, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(HttpModelFetcher)}.{nameof(EvaluatePath)}");
            scope.Start();

            try
            {
                using HttpMessage message = CreateGetRequest(path);

                _pipeline.Send(message, cancellationToken);

                switch (message.Response.Status)
                {
                    case 200:
                        {
                            return GetContent(message.Response.ContentStream);
                        }
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<string> EvaluatePathAsync(string path, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(HttpModelFetcher)}.{nameof(EvaluatePath)}");
            scope.Start();

            try
            {
                using HttpMessage message = CreateGetRequest(path);

                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

                switch (message.Response.Status)
                {
                    case 200:
                        {
                            return await GetContentAsync(message.Response.ContentStream, cancellationToken).ConfigureAwait(false);
                        }
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private HttpMessage CreateGetRequest(string path)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RequestUriBuilder();
            uri.Reset(new Uri(path));
            request.Uri = uri;

            return message;
        }

        private static string GetContent(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content);
            JsonElement root = json.RootElement;
            return root.GetRawText();
        }

        private static async Task<string> GetContentAsync(Stream content, CancellationToken cancellationToken)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false);

            JsonElement root = json.RootElement;
            return root.GetRawText();
        }

        private static HttpPipeline CreatePipeline(ModelsRepositoryClientOptions options)
        {
            return HttpPipelineBuilder.Build(options);
        }

        public ModelsRepositoryMetadata FetchMetadata(Uri repositoryUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(HttpModelFetcher)}.{nameof(FetchMetadata)}");
            scope.Start();

            string metadataPath = DtmiConventions.GetMetadataUri(repositoryUri).AbsoluteUri;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                string content = EvaluatePath(metadataPath, cancellationToken);
                return JsonSerializer.Deserialize<ModelsRepositoryMetadata>(content);
            }
            catch (OperationCanceledException ex)
            {
                scope.Failed(ex);
                throw;
            }
            catch (Exception ex)
            {
                // Exceptions thrown from fetching Repository Metadata should not be terminal.
                ModelsRepositoryEventSource.Instance.FailureProcessingRepositoryMetadata(metadataPath);
                scope.Failed(ex);
            }

            ModelsRepositoryEventSource.Instance.FailureProcessingRepositoryMetadata(metadataPath);
            return null;
        }

        public async Task<ModelsRepositoryMetadata> FetchMetadataAsync(Uri repositoryUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(HttpModelFetcher)}.{nameof(FetchMetadata)}");
            scope.Start();

            string metadataPath = DtmiConventions.GetMetadataUri(repositoryUri).AbsoluteUri;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                string content = await EvaluatePathAsync(metadataPath, cancellationToken).ConfigureAwait(false);
                return JsonSerializer.Deserialize<ModelsRepositoryMetadata>(content);
            }
            catch (OperationCanceledException ex)
            {
                scope.Failed(ex);
                throw;
            }
            catch (Exception ex)
            {
                // Exceptions thrown from fetching Repository Metadata should not be terminal.
                scope.Failed(ex);
            }

            ModelsRepositoryEventSource.Instance.FailureProcessingRepositoryMetadata(metadataPath);
            return null;
        }
    }
}
