// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Search.Documents.Utilities
{
    internal partial class AsyncPageableWrapper<T, U> : AsyncPageable<U>
    {
        private readonly AsyncPageable<T> _source;
        private readonly Func<T, U> _converter;
        private readonly bool _supportsContinuationToken;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _scopeName;

        public AsyncPageableWrapper(AsyncPageable<T> source, Func<T, U> converter, bool supportsContinuationToken, ClientDiagnostics clientDiagnostics, string scopeName)
        {
            _source = source;
            _converter = converter;
            _supportsContinuationToken = supportsContinuationToken;
            _clientDiagnostics = clientDiagnostics;
            _scopeName = scopeName;
        }

        public override async IAsyncEnumerable<Page<U>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            if (!_supportsContinuationToken && continuationToken != null)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                scope.Start();
                try
                {
                    throw new NotSupportedException("A continuation token is unsupported.");
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            await foreach (Page<T> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
            {
                List<U> convertedItems = new List<U>();
                foreach (T item in page.Values)
                {
                    convertedItems.Add(_converter(item));
                }
                yield return Page<U>.FromValues(convertedItems, page.ContinuationToken, page.GetRawResponse());
            }
        }
    }
}
