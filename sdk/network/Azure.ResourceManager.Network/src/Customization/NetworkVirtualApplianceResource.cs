// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using LegacyModels = Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceResource
    {
        // The released 1.15.0 API returns the legacy model; the native child collection now returns a resource.
        /// <summary> Creates or updates inbound security rules using the native child collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use GetInboundSecurityRules().CreateOrUpdate instead.")]
        [ForwardsClientCalls]
        public virtual ArmOperation<LegacyModels.InboundSecurityRule> CreateOrUpdateInboundSecurityRule(WaitUntil waitUntil, string ruleCollectionName, LegacyModels.InboundSecurityRule inboundSecurityRule, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionName, nameof(ruleCollectionName));
            Argument.AssertNotNull(inboundSecurityRule, nameof(inboundSecurityRule));
            return new InboundSecurityRuleOperation(GetInboundSecurityRules().CreateOrUpdate(waitUntil, ruleCollectionName, inboundSecurityRule, cancellationToken));
        }

        // Preserve the asynchronous 1.15.0 model-valued operation while keeping native polling and cancellation.
        /// <summary> Creates or updates inbound security rules using the native child collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use GetInboundSecurityRules().CreateOrUpdateAsync instead.")]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation<LegacyModels.InboundSecurityRule>> CreateOrUpdateInboundSecurityRuleAsync(WaitUntil waitUntil, string ruleCollectionName, LegacyModels.InboundSecurityRule inboundSecurityRule, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionName, nameof(ruleCollectionName));
            Argument.AssertNotNull(inboundSecurityRule, nameof(inboundSecurityRule));
            return new InboundSecurityRuleOperation(await GetInboundSecurityRules().CreateOrUpdateAsync(waitUntil, ruleCollectionName, inboundSecurityRule, cancellationToken).ConfigureAwait(false));
        }

        // The 1.15.0 convenience overload waited for the native restart LRO and returned its raw response.
        /// <summary> Restarts the specified network virtual appliance instances and waits for completion. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response Restart(NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds = default, CancellationToken cancellationToken = default)
            => Restart(WaitUntil.Completed, networkVirtualApplianceInstanceIds, cancellationToken).GetRawResponse();

        // Preserve the asynchronous 1.15.0 convenience overload and its completed-operation response.
        /// <summary> Restarts the specified network virtual appliance instances and waits for completion. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response> RestartAsync(NetworkVirtualApplianceInstanceIds networkVirtualApplianceInstanceIds = default, CancellationToken cancellationToken = default)
            => (await RestartAsync(WaitUntil.Completed, networkVirtualApplianceInstanceIds, cancellationToken).ConfigureAwait(false)).GetRawResponse();

        // Project only the result model; all operation state and status requests belong to the native child operation.
        private sealed class InboundSecurityRuleOperation : ArmOperation<LegacyModels.InboundSecurityRule>
        {
            private readonly ArmOperation<InboundSecurityRuleResource> _operation;
            private LegacyModels.InboundSecurityRule _value;

            public InboundSecurityRuleOperation(ArmOperation<InboundSecurityRuleResource> operation) => _operation = operation;

            public override string Id => _operation.Id;
            public override bool HasCompleted => _operation.HasCompleted;
            public override bool HasValue => _operation.HasValue;
            public override LegacyModels.InboundSecurityRule Value
            {
                get
                {
                    if (_value is null)
                    {
                        var options = new ModelReaderWriterOptions("J");
                        _value = ModelReaderWriter.Read<LegacyModels.InboundSecurityRule>(
                            ModelReaderWriter.Write(_operation.Value.Data, options, AzureResourceManagerNetworkContext.Default),
                            options, AzureResourceManagerNetworkContext.Default);
                    }
                    return _value;
                }
            }

            public override Response GetRawResponse() => _operation.GetRawResponse();
            public override RehydrationToken? GetRehydrationToken() => _operation.GetRehydrationToken();
            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        }
    }
}
