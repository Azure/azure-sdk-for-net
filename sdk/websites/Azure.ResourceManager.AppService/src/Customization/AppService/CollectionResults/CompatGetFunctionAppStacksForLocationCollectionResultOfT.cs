// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    // ROOT CAUSE: see CompatGetFunctionAppStacksForLocationAsyncCollectionResultOfT.
    internal partial class CompatGetFunctionAppStacksForLocationCollectionResultOfT : Pageable<FunctionAppStack>
    {
        private readonly ProviderOperationGroup _client;
        private readonly AzureLocation _location;
        private readonly string _stackOsType;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public CompatGetFunctionAppStacksForLocationCollectionResultOfT(ProviderOperationGroup client, AzureLocation location, string stackOsType, RequestContext context, string diagnosticScope)
            : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _location = location;
            _stackOsType = stackOsType;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override IEnumerable<Page<FunctionAppStack>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                FunctionAppStackListResult result = FunctionAppStackListResult.FromResponse(response);
                yield return Page<FunctionAppStack>.FromValues((IReadOnlyList<FunctionAppStack>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null
                ? _client.CreateNextGetFunctionAppStacksForLocationProvidersRequest(nextLink, _location, _stackOsType, _context)
                : _client.CreateGetFunctionAppStacksForLocationProvidersRequest(_location, _stackOsType, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
            scope.Start();
            try
            {
                return _client.Pipeline.ProcessMessage(message, _context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
