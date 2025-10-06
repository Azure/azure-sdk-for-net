// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SelfHelp.Mocking;
using Azure.ResourceManager.SelfHelp.Models;

namespace Azure.ResourceManager.SelfHelp
{
    public static partial class SelfHelpExtensions
    {
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
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> 'ProblemClassificationId' or 'Id' is a mandatory filter to get solutions ids. It also supports optional 'ResourceType' and 'SolutionType' filters. The filter supports only 'and', 'or' and 'eq' operators. Example: $filter=ProblemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e'. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutions(this ArmClient client, ResourceIdentifier scope, string filter = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSelfHelpArmClient(client).GetSelfHelpDiscoverySolutions(scope, filter, skiptoken, cancellationToken);
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
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> 'ProblemClassificationId' or 'Id' is a mandatory filter to get solutions ids. It also supports optional 'ResourceType' and 'SolutionType' filters. The filter supports only 'and', 'or' and 'eq' operators. Example: $filter=ProblemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e'. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutionsAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            return GetMockableSelfHelpArmClient(client).GetSelfHelpDiscoverySolutionsAsync(scope, filter, skiptoken, cancellationToken);
        }
    }
}
