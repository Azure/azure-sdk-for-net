// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListSupportedImagesEnumerator : AsyncListEnumerator<ImageInformation, Models.ImageInformation, Models.AccountListSupportedImagesHeaders>
    {
        private readonly PoolOperations _parentPoolOps;

        internal AsyncListSupportedImagesEnumerator(PoolOperations parentPoolOps, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentPoolOps = parentPoolOps;
        }

        internal override ImageInformation Wrap(Models.ImageInformation protocolObj)
        {
            return new ImageInformation(protocolObj);
        }

        internal override Task<AzureOperationResponse<IPage<Models.ImageInformation>, Models.AccountListSupportedImagesHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentPoolOps.ParentBatchClient.ProtocolLayer.ListSupportedImages(
                    skipHandler.SkipToken,
                    behaviorMgr,
                    detailLevel,
                    cancellationToken);
        }
    }
}
