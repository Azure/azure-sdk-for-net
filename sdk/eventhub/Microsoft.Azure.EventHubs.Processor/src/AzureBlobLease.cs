// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
	using System;
	using System.Threading.Tasks;
	using Microsoft.Azure.Storage.Blob;
	using Newtonsoft.Json;

	class AzureBlobLease : Lease
	{
        readonly bool isOwned;

	    // ctor needed for deserialization
	    internal AzureBlobLease()
		{
		}

	    internal AzureBlobLease(string partitionId, CloudBlockBlob blob) : base(partitionId)
		{
			this.Blob = blob;
            this.isOwned = blob.Properties.LeaseState == LeaseState.Leased;
        }

        internal AzureBlobLease(string partitionId, string owner, CloudBlockBlob blob) : base(partitionId)
        {
            this.Blob = blob;
            this.Owner = owner;
            this.isOwned = blob.Properties.LeaseState == LeaseState.Leased;
        }

        internal AzureBlobLease(AzureBlobLease source)
			: base(source)
		{
			this.Offset = source.Offset;
			this.SequenceNumber = source.SequenceNumber;
			this.Blob = source.Blob;
            this.isOwned = source.isOwned;
		}

	    internal AzureBlobLease(AzureBlobLease source, CloudBlockBlob blob) : base(source)
		{
			this.Offset = source.Offset;
			this.SequenceNumber = source.SequenceNumber;
			this.Blob = blob;
            this.isOwned = blob.Properties.LeaseState == LeaseState.Leased;
		}

	    // do not serialize
	    [JsonIgnore]
		public CloudBlockBlob Blob { get; }

	    public override Task<bool> IsExpired()
		{
            return Task.FromResult(!this.isOwned);
		}
	}
}