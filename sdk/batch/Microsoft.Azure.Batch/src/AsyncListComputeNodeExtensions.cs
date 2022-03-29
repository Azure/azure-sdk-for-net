using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListComputeNodeExtensionsEnumerator : AsyncListEnumerator<NodeVMExtension, Models.NodeVMExtension, Models.ComputeNodeExtensionListHeaders>
    {
        private readonly PoolOperations _parentPoolOperations;
        private readonly string _poolId;
        private readonly string _nodeId;

        internal AsyncListComputeNodeExtensionsEnumerator(PoolOperations parentPoolOperations, string poolId, string nodeId, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentPoolOperations = parentPoolOperations;
            _poolId = poolId;
            _nodeId = nodeId;
        }

        internal override NodeVMExtension Wrap(Models.NodeVMExtension protocolObj)
        {
            return new NodeVMExtension(protocolObj);
        }

        internal override Task<AzureOperationResponse<IPage<Models.NodeVMExtension>, Models.ComputeNodeExtensionListHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentPoolOperations.ParentBatchClient.ProtocolLayer.ListComputeNodeExtensions(
                _poolId,
                _nodeId,
                skipHandler.SkipToken,
                behaviorMgr,
                detailLevel,
                cancellationToken);
        }
    }
}
