// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Protocol.Models;

    internal class AsyncListCertificatesEnumerator : AsyncListEnumerator<Certificate, Models.Certificate, Models.CertificateListHeaders>
    {
        private readonly CertificateOperations _parentCertOps;

        internal AsyncListCertificatesEnumerator(CertificateOperations parentCertOps, BehaviorManager behaviorMgr, DetailLevel detailLevel)
        : base(behaviorMgr, detailLevel)
        {
            _parentCertOps = parentCertOps;
        }

        internal override Certificate Wrap(Models.Certificate protocolObj)
        {
            return new Certificate(_parentCertOps.ParentBatchClient, protocolObj, behaviorMgr.BaseBehaviors);
        }

        internal override Task<AzureOperationResponse<IPage<Models.Certificate>, Models.CertificateListHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            return _parentCertOps.ParentBatchClient.ProtocolLayer.ListCertificates(
                skipHandler.SkipToken,
                behaviorMgr,
                detailLevel,
                cancellationToken);
        }
    }
}
