// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Experimental;
using System.Threading;

namespace System.ServiceModel.Rest.Core
{
    /// <summary>
    /// TBD.
    /// </summary>
    public abstract class RestMessage : IDisposable
    {
        protected RestMessage(RestRequest request)
        {
            ClientUtilities.AssertNotNull(request, nameof(RestRequest));

            RestRequest = request;
        }

        /// <summary>
        /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="RestMessage"/> processing.
        /// </summary>
        // TODO: we have to make CancellationToken publicly settable, but we might not want this.  Rethink?
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// TBD.
        /// </summary>
        public RestRequest RestRequest { get; }

        /// <summary>
        /// TBD.
        /// </summary>
        public abstract Result? Result { get; }

        /// <inheritdoc/>
        public abstract void Dispose();
    }
}