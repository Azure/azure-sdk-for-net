// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Dynatrace.Models;

namespace Azure.ResourceManager.Dynatrace
{
    // The Patch operation is removed in the swagger, we add it back for compatibility reason.
    public partial class DynatraceTagRuleResource
    {
        /// <summary>
        /// Update a TagRule
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Dynatrace.Observability/monitors/{monitorName}/tagRules/{ruleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TagRules_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DynatraceTagRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DynatraceTagRuleResource>> UpdateAsync(DynatraceTagRulePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            var data = new DynatraceTagRuleData()
            {
                LogRules = patch.LogRules,
                MetricRules = patch.MetricRules
            };

            using var scope = _dynatraceTagRuleTagRulesClientDiagnostics.CreateScope("DynatraceTagRuleResource.UpdateAsync");
            scope.Start();
            try
            {
                var operation = await UpdateAsync(WaitUntil.Completed, data, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(operation.Value, operation.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update a TagRule
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Dynatrace.Observability/monitors/{monitorName}/tagRules/{ruleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TagRules_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DynatraceTagRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DynatraceTagRuleResource> Update(DynatraceTagRulePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            var data = new DynatraceTagRuleData()
            {
                LogRules = patch.LogRules,
                MetricRules = patch.MetricRules
            };

            using var scope = _dynatraceTagRuleTagRulesClientDiagnostics.CreateScope("DynatraceTagRuleResource.UpdateAsync");
            scope.Start();
            try
            {
                var operation = Update(WaitUntil.Completed, data, cancellationToken);
                return Response.FromValue(operation.Value, operation.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
