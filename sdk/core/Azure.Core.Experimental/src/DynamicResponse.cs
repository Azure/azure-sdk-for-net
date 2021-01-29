using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    public class DynamicResponse : Response<DynamicJson>
    {
        private Response Response { get; }

        public override DynamicJson Value { get; }

        public dynamic Content => Value;

        public DynamicResponse(Response response, DynamicJson value)
        {
            Response = response;
            Value = value;
        }

        public override Response GetRawResponse()
        {
            return Response;
        }
    }
}
