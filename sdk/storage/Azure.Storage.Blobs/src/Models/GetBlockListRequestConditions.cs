// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class GetBlockListRequestConditions : IRequestConditions.ILeaseId, IRequestConditions.ITags
    {
        ///<inheritdoc/>
        public string LeaseId { get; set; }

        ///<inheritdoc/>
        public string TagConditions { get; set; }
    }
}
