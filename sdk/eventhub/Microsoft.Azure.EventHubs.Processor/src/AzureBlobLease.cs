// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Threading.Tasks;
	using Newtonsoft.Json;
	using WindowsAzure.Storage.Blob;

	class AzureBlobLease : Lease
	{
        readonly bool isOwned;

        readonly TimeSpan LeaseDuration;

        private bool IsInfiniteLease => this.LeaseDuration > TimeSpan.FromSeconds(60);

        // ctor needed for deserialization
        internal AzureBlobLease()
		{
		}

	    internal AzureBlobLease(string partitionId, CloudBlockBlob blob, TimeSpan LeaseDuration) : base(partitionId)
		{
			this.Blob = blob;
            this.isOwned = blob.Properties.LeaseState == LeaseState.Leased;
            this.LeaseDuration = LeaseDuration;
        }

        internal AzureBlobLease(string partitionId, string owner, CloudBlockBlob blob, TimeSpan LeaseDuration) : base(partitionId)
        {
            this.Blob = blob;
            this.Owner = owner;
            this.isOwned = blob.Properties.LeaseState == LeaseState.Leased;
            this.LeaseDuration = LeaseDuration;
        }

        internal AzureBlobLease(AzureBlobLease source, TimeSpan LeaseDuration)
			: base(source)
		{
			this.Offset = source.Offset;
			this.SequenceNumber = source.SequenceNumber;
			this.Blob = source.Blob;
            this.isOwned = source.isOwned;
            this.LeaseDuration = LeaseDuration;
        }

	    internal AzureBlobLease(AzureBlobLease source, CloudBlockBlob blob, TimeSpan LeaseDuration) : base(source)
		{
			this.Offset = source.Offset;
			this.SequenceNumber = source.SequenceNumber;
			this.Blob = blob;
            this.isOwned = blob.Properties.LeaseState == LeaseState.Leased;
            this.LeaseDuration = LeaseDuration;
        }

	    // do not serialize
	    [JsonIgnore]
		public CloudBlockBlob Blob { get; }

	    public override Task<bool> IsExpired()
		{
            if (IsInfiniteLease)
            {
                DateTime lastModifiedTime = this.Blob.Properties.LastModified.Value.DateTime;
                if (DateTime.UtcNow - lastModifiedTime > this.LeaseDuration)
                {
                    return Task.FromResult<bool>(true);
                }
                return Task.FromResult<bool>(false);
            }
                return Task.FromResult(!this.isOwned);
		}

	}
}