// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobReceipt
    {
        private const string IncompleteKey = "Incomplete";

        private static readonly BlobReceipt CompletedInstance = new BlobReceipt(incomplete: false);
        private static readonly BlobReceipt IncompleteInstance = new BlobReceipt(incomplete: true);

        private readonly bool _incomplete;

        private BlobReceipt(bool incomplete)
        {
            _incomplete = incomplete;
        }

        public static BlobReceipt Complete
        {
            get { return CompletedInstance; }
        }

        public static BlobReceipt Incomplete
        {
            get { return IncompleteInstance; }
        }

        public bool IsCompleted
        {
            get { return !_incomplete; }
        }

        public void ToMetadata(IDictionary<string, string> metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            if (_incomplete)
            {
                // re-use the key as the value, ala HTML (the presence of the key is what matters, not its value).
                metadata[IncompleteKey] = IncompleteKey;
            }
            else
            {
                metadata.Remove(IncompleteKey);
            }
        }

        public static BlobReceipt FromMetadata(IDictionary<string, string> metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            bool incomplete = metadata.ContainsKey(IncompleteKey);

            return incomplete ? Incomplete : Complete;
        }
    }
}
