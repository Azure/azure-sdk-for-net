// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;

namespace Azure.Storage.Files.Shares.Specialized
{
    /// <summary>
    /// The <see cref="FileLeaseClient"/> allows you to manipulate Azure
    /// Storage leases on files.
    /// </summary>
    public class FileLeaseClient
    {
        /// <summary>
        /// The <see cref="ShareFileClient"/> to manage leases for.
        /// </summary>
        private readonly ShareFileClient _file;

        /// <summary>
        /// The <see cref="ShareFileClient"/> to manage leases for.
        /// </summary>
        protected virtual ShareFileClient FileClient => _file;

        /// <summary>
        /// Gets the URI of the object being leased.
        /// </summary>
        public Uri Uri => FileClient?.Uri;

        /// <summary>
        /// Gets the Lease ID for this lease.
        /// </summary>
        public virtual string LeaseId { get; private set; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private HttpPipeline Pipeline => FileClient?.Pipeline;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => FileClient?.ClientDiagnostics;

        /// <summary>
        /// The <see cref="TimeSpan"/> representing an infinite lease duration.
        /// </summary>
        public static readonly TimeSpan InfiniteLeaseDuration = TimeSpan.FromSeconds(Constants.File.Lease.InfiniteLeaseDuration);

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLeaseClient"/> class
        /// for mocking.
        /// </summary>
        protected FileLeaseClient()
        {
            _file = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="ShareFileClient"/> representing the file being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public FileLeaseClient(ShareFileClient client, string leaseId = null)
        {
            _file = client ?? throw Errors.ArgumentNull(nameof(client));
            LeaseId = leaseId ?? CreateUniqueLeaseId();
        }
    }
}
