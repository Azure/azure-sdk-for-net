using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Rest;

namespace Microsoft.Rest
{
    public interface IHttpRestException<V>
    {
        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        HttpResponseMessageWrapper Response { get; set; }

        void SetErrorModel(V model);

    }
}