// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.SelfHelp.Models;
using System.ComponentModel;
using System.Threading;
using System;
using Autorest.CSharp.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.SelfHelp.Mocking
{
    public partial class MockableSelfHelpArmClient : ArmResource
    {
        private ClientDiagnostics _discoverySolutionClientDiagnostics;
        private DiscoverySolution _discoverySolutionRestClient;

        private ClientDiagnostics DiscoverySolutionClientDiagnostics => _discoverySolutionClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SelfHelp", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private DiscoverySolution DiscoverySolutionRestClient => _discoverySolutionRestClient ??= new DiscoverySolution(DiscoverySolutionClientDiagnostics, Pipeline, Endpoint, "2024-03-01-preview");

        /// <summary>
        /// Lists the relevant Azure diagnostics and solutions using [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) AND  resourceUri or resourceType.&lt;br/&gt; Discovery Solutions is the initial entry point within Help API, which identifies relevant Azure diagnostics and solutions. We will do our best to return the most effective solutions based on the type of inputs, in the request URL  &lt;br/&gt;&lt;br/&gt; Mandatory input :  problemClassificationId (Use the [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) &lt;br/&gt;Optional input: resourceUri OR resource Type &lt;br/&gt;&lt;br/&gt; &lt;b&gt;Note: &lt;/b&gt;  ‘requiredInputs’ from Discovery solutions response must be passed via ‘additionalParameters’ as an input to Diagnostics and Solutions API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Help/discoverySolutions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiscoverySolution_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> 'ProblemClassificationId' or 'Id' is a mandatory filter to get solutions ids. It also supports optional 'ResourceType' and 'SolutionType' filters. The filter supports only 'and', 'or' and 'eq' operators. Example: $filter=ProblemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e'. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutions(ResourceIdentifier scope, string filter = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new DiscoverySolutionDiscoverSolutionsCollectionResultOfT(DiscoverySolutionRestClient, filter, skiptoken, context);
        }

        /// <summary>
        /// Lists the relevant Azure diagnostics and solutions using [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) AND  resourceUri or resourceType.&lt;br/&gt; Discovery Solutions is the initial entry point within Help API, which identifies relevant Azure diagnostics and solutions. We will do our best to return the most effective solutions based on the type of inputs, in the request URL  &lt;br/&gt;&lt;br/&gt; Mandatory input :  problemClassificationId (Use the [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) &lt;br/&gt;Optional input: resourceUri OR resource Type &lt;br/&gt;&lt;br/&gt; &lt;b&gt;Note: &lt;/b&gt;  ‘requiredInputs’ from Discovery solutions response must be passed via ‘additionalParameters’ as an input to Diagnostics and Solutions API.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Help/discoverySolutions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiscoverySolution_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> 'ProblemClassificationId' or 'Id' is a mandatory filter to get solutions ids. It also supports optional 'ResourceType' and 'SolutionType' filters. The filter supports only 'and', 'or' and 'eq' operators. Example: $filter=ProblemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e'. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutionsAsync(ResourceIdentifier scope, string filter = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new DiscoverySolutionDiscoverSolutionsAsyncCollectionResultOfT(DiscoverySolutionRestClient, filter, skiptoken, context);
        }
    }
}
