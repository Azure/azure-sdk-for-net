// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // Compatibility shims intentionally reference obsolete API.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityCenterLocationResource
    {
        private ClientDiagnostics _legacyDiscoveredSecuritySolutionsClientDiagnostics;
        private DiscoveredSecuritySolutions _legacyDiscoveredSecuritySolutionsRestClient;

        private ClientDiagnostics LegacyDiscoveredSecuritySolutionsClientDiagnostics
            => _legacyDiscoveredSecuritySolutionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", DiscoveredSecuritySolutionResource.ResourceType.Namespace, Diagnostics);

        private DiscoveredSecuritySolutions LegacyDiscoveredSecuritySolutionsRestClient
        {
            get
            {
                if (_legacyDiscoveredSecuritySolutionsRestClient is null)
                {
                    TryGetApiVersion(DiscoveredSecuritySolutionResource.ResourceType, out string apiVersion);
                    _legacyDiscoveredSecuritySolutionsRestClient = new DiscoveredSecuritySolutions(LegacyDiscoveredSecuritySolutionsClientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2020-01-01");
                }

                return _legacyDiscoveredSecuritySolutionsRestClient;
            }
        }

        [ForwardsClientCalls]
        public virtual AsyncPageable<DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new LegacyDiscoveredSecuritySolutionAsyncPageable(new DiscoveredSecuritySolutionsGetByHomeRegionAsyncCollectionResultOfT(LegacyDiscoveredSecuritySolutionsRestClient, Guid.Parse(Id.SubscriptionId), new AzureLocation(Id.Name), context, "SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegion"));
        }

        [ForwardsClientCalls]
        public virtual Pageable<DiscoveredSecuritySolution> GetDiscoveredSecuritySolutionsByHomeRegion(CancellationToken cancellationToken = default(CancellationToken))
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new LegacyDiscoveredSecuritySolutionPageable(new DiscoveredSecuritySolutionsGetByHomeRegionCollectionResultOfT(LegacyDiscoveredSecuritySolutionsRestClient, Guid.Parse(Id.SubscriptionId), new AzureLocation(Id.Name), context, "SecurityCenterLocationResource.GetDiscoveredSecuritySolutionsByHomeRegion"));
        }

        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroup(string groupName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<AdaptiveApplicationControlGroupResource>> GetAdaptiveApplicationControlGroupAsync(string groupName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AdaptiveApplicationControlGroupCollection GetAdaptiveApplicationControlGroups() { throw new NotSupportedException("This API is no longer supported by the service."); }

        private sealed class LegacyDiscoveredSecuritySolutionPageable : Pageable<DiscoveredSecuritySolution>
        {
            private readonly Pageable<DiscoveredSecuritySolutionData> _inner;

            public LegacyDiscoveredSecuritySolutionPageable(Pageable<DiscoveredSecuritySolutionData> inner)
            {
                _inner = inner;
            }

            public override IEnumerable<Page<DiscoveredSecuritySolution>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<DiscoveredSecuritySolutionData> page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    yield return Page<DiscoveredSecuritySolution>.FromValues(page.Values.Select(data => new DiscoveredSecuritySolution(data)).ToArray(), page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class LegacyDiscoveredSecuritySolutionAsyncPageable : AsyncPageable<DiscoveredSecuritySolution>
        {
            private readonly AsyncPageable<DiscoveredSecuritySolutionData> _inner;

            public LegacyDiscoveredSecuritySolutionAsyncPageable(AsyncPageable<DiscoveredSecuritySolutionData> inner)
            {
                _inner = inner;
            }

            public override async IAsyncEnumerable<Page<DiscoveredSecuritySolution>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<DiscoveredSecuritySolutionData> page in _inner.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    yield return Page<DiscoveredSecuritySolution>.FromValues(page.Values.Select(data => new DiscoveredSecuritySolution(data)).ToArray(), page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
