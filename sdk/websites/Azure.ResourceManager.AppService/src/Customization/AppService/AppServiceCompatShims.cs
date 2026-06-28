// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// Internal helpers for the ProxyResource-to-flat compatibility shims:
    /// converts between the newly-generated `*Data` types (resources) and the
    /// GA-shipped plain models that customizations recreate in
    /// <see cref="Azure.ResourceManager.AppService.Models"/>.
    /// </summary>
    internal static class AppServiceCompatShims
    {
        public static SiteAuthSettingsV2 ConvertAuth(SiteAuthSettingsV2Data data)
        {
            if (data == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<SiteAuthSettingsV2>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        public static SiteAuthSettingsV2Data ConvertAuthBack(SiteAuthSettingsV2 model)
        {
            if (model == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<SiteAuthSettingsV2Data>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        public static CsmDeploymentStatus ConvertCsm(CsmDeploymentStatusData data)
        {
            if (data == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<CsmDeploymentStatus>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        public static AppServiceEnvironmentAddressResult ConvertAddress(AppServiceEnvironmentAddressData data)
        {
            if (data == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<AppServiceEnvironmentAddressResult>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        /// <summary>
        /// Wraps an <see cref="ArmOperation{TIn}"/> as an <see cref="ArmOperation{TOut}"/> by projecting the completed value
        /// through a converter. The GA SDK exposed a plain ArmOperation&lt;CsmDeploymentStatus&gt; while the new SDK
        /// returns ArmOperation&lt;CsmSiteDeploymentStatusResource&gt;; this preserves the old contract.
        /// </summary>
        public static ArmOperation<TOut> ProjectOperation<TIn, TOut>(ArmOperation<TIn> inner, Func<TIn, TOut> convert)
        {
            return new ProjectedArmOperation<TIn, TOut>(inner, convert);
        }

        public static Pageable<TOut> ProjectPageable<TIn, TOut>(Pageable<TIn> inner, Func<TIn, TOut> convert)
        {
            return new ProjectedPageable<TIn, TOut>(inner, convert);
        }

        public static AsyncPageable<TOut> ProjectAsyncPageable<TIn, TOut>(AsyncPageable<TIn> inner, Func<TIn, TOut> convert)
        {
            return new ProjectedAsyncPageable<TIn, TOut>(inner, convert);
        }

        private sealed class ProjectedArmOperation<TIn, TOut> : ArmOperation<TOut>
        {
            private readonly ArmOperation<TIn> _inner;
            private readonly Func<TIn, TOut> _convert;

            public ProjectedArmOperation(ArmOperation<TIn> inner, Func<TIn, TOut> convert)
            {
                _inner = inner;
                _convert = convert;
            }

            public override TOut Value => _convert(_inner.Value);
            public override bool HasValue => _inner.HasValue;
            public override string Id => _inner.Id;
            public override bool HasCompleted => _inner.HasCompleted;
            public override Response GetRawResponse() => _inner.GetRawResponse();
            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _inner.UpdateStatus(cancellationToken);
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _inner.UpdateStatusAsync(cancellationToken);
            public override Response<TOut> WaitForCompletion(CancellationToken cancellationToken = default)
            {
                Response<TIn> r = _inner.WaitForCompletion(cancellationToken);
                return Response.FromValue(_convert(r.Value), r.GetRawResponse());
            }
            public override Response<TOut> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
            {
                Response<TIn> r = _inner.WaitForCompletion(pollingInterval, cancellationToken);
                return Response.FromValue(_convert(r.Value), r.GetRawResponse());
            }
            public override async ValueTask<Response<TOut>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            {
                Response<TIn> r = await _inner.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(_convert(r.Value), r.GetRawResponse());
            }
            public override async ValueTask<Response<TOut>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            {
                Response<TIn> r = await _inner.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(_convert(r.Value), r.GetRawResponse());
            }
            public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default) => _inner.WaitForCompletionResponse(cancellationToken);
            public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken) => _inner.WaitForCompletionResponse(pollingInterval, cancellationToken);
            public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) => _inner.WaitForCompletionResponseAsync(cancellationToken);
            public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => _inner.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);
        }

        private sealed class ProjectedPageable<TIn, TOut> : Pageable<TOut>
        {
            private readonly Pageable<TIn> _inner;
            private readonly Func<TIn, TOut> _convert;

            public ProjectedPageable(Pageable<TIn> inner, Func<TIn, TOut> convert)
            {
                _inner = inner;
                _convert = convert;
            }

            public override IEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (var page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    var converted = new List<TOut>(page.Values.Count);
                    foreach (var v in page.Values)
                    {
                        converted.Add(_convert(v));
                    }
                    yield return Page<TOut>.FromValues(converted, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class ProjectedAsyncPageable<TIn, TOut> : AsyncPageable<TOut>
        {
            private readonly AsyncPageable<TIn> _inner;
            private readonly Func<TIn, TOut> _convert;

            public ProjectedAsyncPageable(AsyncPageable<TIn> inner, Func<TIn, TOut> convert)
            {
                _inner = inner;
                _convert = convert;
            }

            public override async IAsyncEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (var page in _inner.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    var converted = new List<TOut>(page.Values.Count);
                    foreach (var v in page.Values)
                    {
                        converted.Add(_convert(v));
                    }
                    yield return Page<TOut>.FromValues(converted, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
