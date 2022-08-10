// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    internal class EmptyResponse : AuthEventResponse
    {
        internal override void InstanceCreated(AuthEventJsonElement payload) { }

        internal override void Invalidate() { }

        #region Empty Response/Data

        internal class EmptyData : AuthEventData { }

        internal class EmptyRequest : AuthEventRequest<EmptyResponse, EmptyData>
        {
            public EmptyRequest(HttpRequestMessage request) : base(request)
            {
                Payload = new EmptyData();
                Response = new EmptyResponse();
            }

            internal override AuthEventResponse GetResponseObject()
            {
                return Response;
            }

            internal override void InstanceCreated(params object[] args) { }
        }
        #endregion
    }
}