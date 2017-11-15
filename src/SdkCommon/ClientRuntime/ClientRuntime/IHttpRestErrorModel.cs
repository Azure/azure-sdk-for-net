using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Rest;

namespace Microsoft.Rest
{
    internal interface IHttpRestErrorModel
    {
        void CreateAndThrowException(HttpRequestMessageWrapper reqMessage, HttpResponseMessageWrapper respMessage);
    }
}