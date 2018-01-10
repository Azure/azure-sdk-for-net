using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Rest;

namespace Microsoft.Rest
{
    public interface IRestErrorModel
    {
        void CreateAndThrowException(HttpRequestMessageWrapper reqMessage, HttpResponseMessageWrapper respMessage);
    }
}