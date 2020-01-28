// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.Testing;

namespace Azure.Storage.Test
{
    public class SimulateStorageRequestFailureAttribute : SimulateFailureAttribute
    {
        public List<string> HostsSetInRequests { get; }
        public List<DateTime> DatesSetInRequests { get; }

        public bool Simulate404 { get; set; }
        public Uri SecondaryUri { get; set; }

        private readonly string[] _trackedRequestMethods;

        public SimulateStorageRequestFailureAttribute() : this(null) { }

        public SimulateStorageRequestFailureAttribute(string[] trackedRequestMethods)
        {
            HostsSetInRequests = new List<string>();
            DatesSetInRequests = new List<DateTime>();
            _trackedRequestMethods = trackedRequestMethods ?? new[] { RequestMethod.Get.Method, RequestMethod.Head.Method };
        }

        public override bool CanFail(HttpMessage message)
        {
            if (!_trackedRequestMethods.Contains(message.Request.Method.Method))
            {
                return false;
            }

            HostsSetInRequests.Add(message.Request.Uri.Host);
            if (message.Request.Headers.TryGetValue("x-ms-date", out string date))
            {
                DatesSetInRequests.Add(Convert.ToDateTime(date));
            }

            return true;
        }

        public override void Fail(HttpMessage message)
            => message.Response = new MockResponse(Simulate404 && SecondaryUri != null && message.Request.Uri.Host == SecondaryUri.Host ? 404 : 429);
    }
}
