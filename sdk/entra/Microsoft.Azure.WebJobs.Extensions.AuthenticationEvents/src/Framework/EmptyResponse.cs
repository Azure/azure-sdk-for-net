// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    internal class EmptyResponse : AuthenticationEventResponse
    {
        internal override void InstanceCreated(AuthenticationEventJsonElement payload) { }
        internal override void Invalidate() { }

        #region Empty Response/Data

        internal class EmptyData : AuthenticationEventData { }

        internal class EmptyRequest : AuthenticationEventRequest<EmptyResponse, EmptyData>
        {
            public EmptyRequest(HttpRequestMessage request) : base(request)
            {
                Data = new EmptyData();
                Response = new EmptyResponse();
            }

            internal override AuthenticationEventResponse GetResponseObject()
            {
                return Response;
            }

            internal override void InstanceCreated(params object[] args) { }
        }
        #endregion
    }
}