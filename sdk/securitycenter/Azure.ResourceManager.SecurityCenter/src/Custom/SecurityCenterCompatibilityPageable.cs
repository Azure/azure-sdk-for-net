// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.SecurityCenter
{
    internal sealed class SecurityCenterCompatibilityPageable<T> : Pageable<T>
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;
        private readonly Func<Uri, RequestContext, HttpMessage> _createRequest;
        private readonly Func<Response, (IReadOnlyList<T> Values, string NextLink)> _parseResponse;

        public SecurityCenterCompatibilityPageable(
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            RequestContext context,
            string diagnosticScope,
            Func<Uri, RequestContext, HttpMessage> createRequest,
            Func<Response, (IReadOnlyList<T> Values, string NextLink)> parseResponse)
            : base(context?.CancellationToken ?? default)
        {
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            _context = context;
            _diagnosticScope = diagnosticScope;
            _createRequest = createRequest;
            _parseResponse = parseResponse;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken, UriKind.RelativeOrAbsolute) : null;
            while (true)
            {
                Response response = GetNextResponse(nextPage);
                (IReadOnlyList<T> values, string nextLink) = _parseResponse(response);
                yield return Page<T>.FromValues(values, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                if (string.IsNullOrEmpty(nextLink))
                {
                    yield break;
                }
                nextPage = new Uri(nextLink, UriKind.RelativeOrAbsolute);
            }
        }

        private Response GetNextResponse(Uri nextLink)
        {
            HttpMessage message = _createRequest(nextLink, _context);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(_diagnosticScope);
            scope.Start();
            try
            {
                return _pipeline.ProcessMessage(message, _context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
