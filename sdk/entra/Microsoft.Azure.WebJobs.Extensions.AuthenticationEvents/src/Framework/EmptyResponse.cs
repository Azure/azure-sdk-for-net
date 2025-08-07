// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class EmptyResponse : WebJobsAuthenticationEventResponse
    {
        internal override void InstanceCreated(AuthenticationEventJsonElement payload) { }
        internal override void BuildJsonElement() { }

        #region Empty Response/Data

        internal class EmptyData : WebJobsAuthenticationEventData { }

        internal class EmptyRequest : WebJobsAuthenticationEventRequest<EmptyResponse, EmptyData>
        {
            public EmptyRequest(HttpRequestMessage request) : base(request)
            {
                Data = new EmptyData();
                Response = new EmptyResponse();
            }

            internal override WebJobsAuthenticationEventResponse GetResponseObject()
            {
                return Response;
            }

            internal override void InstanceCreated(params object[] args) { }
        }
        #endregion
    }
}