// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// This policy is used if the SecondaryUri property is passed in on the clientOptions. It allows for storage
    /// accounts configured with RA-GRS to retry GET or HEAD requests against the secondary storage Uri.
    /// </summary>
    internal class GeoRedundantReadPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _secondaryStorageHost;

        public GeoRedundantReadPolicy(Uri secondaryStorageUri)
        {
            if (secondaryStorageUri == null)
            {
                throw Errors.ArgumentNull(nameof(secondaryStorageUri));
            }
            _secondaryStorageHost = secondaryStorageUri.Host;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Method != RequestMethod.Get && message.Request.Method != RequestMethod.Head)
            {
                return;
            }

            // Look up what the alternate host is set to in the message properties. For the initial request, this will
            // not be set.
            string alternateHost =
                message.TryGetProperty(
                    Constants.GeoRedundantRead.AlternateHostKey,
                    out var alternateHostObj)
                ? alternateHostObj as string
                : null;
            if (alternateHost == null)
            {
                // queue up the secondary host for subsequent retries
                message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, _secondaryStorageHost);
                return;
            }

            // Check the flag that indicates whether the resource has not been propagated to the secondary host yet.
            // If this flag is set, we don't want to retry against the secondary host again for any subsequent retries.
            // Also, the flag being set implies that the current request must already be set to the primary host, so we
            // are safe to return without checking if the current host is secondary or primary.
            var resourceNotReplicated =
                message.TryGetProperty(Constants.GeoRedundantRead.ResourceNotReplicated, out var value)
                && (bool)value;
            if (resourceNotReplicated)
            {
                return;
            }

            // If alternateHost was not null that means the message is being retried. Hence what is stored in the Host
            // property of UriBuilder is actually the host from the last try.
            var lastTriedHost = message.Request.Uri.Host;

            // If necessary, set the flag to indicate that the resource has not yet been propagated to the secondary host.
            if (message.HasResponse
                && message.Response.Status == Constants.HttpStatusCode.NotFound
                && lastTriedHost == _secondaryStorageHost)
            {
                message.SetProperty(Constants.GeoRedundantRead.ResourceNotReplicated, true);
            }

            // Toggle the host set in the request to use the alternate host for the upcoming attempt, and update the
            // the property for the AlternateHostKey to be the host used in the last try.
            message.Request.Uri.Host = alternateHost;
            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, lastTriedHost);
        }
    }
}
