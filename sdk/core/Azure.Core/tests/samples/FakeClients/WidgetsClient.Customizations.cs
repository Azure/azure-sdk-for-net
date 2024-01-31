// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Core.Samples
{
    /// <summary> The Widgets service client. </summary>
    public partial class WidgetsClient
    {
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/WidgetsClient.xml" path="doc/members/member[@name='GetWidgetAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetLargeWidgetAsync(RequestContext context = null)
        {
            return await GetWidgetAsync(context).ConfigureAwait(false);
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/WidgetsClient.xml" path="doc/members/member[@name='GetWidget(RequestContext)']/*" />
        public virtual Response GetLargeWidget(RequestContext context = null)
        {
            return GetWidget(context);
        }
    }
}
