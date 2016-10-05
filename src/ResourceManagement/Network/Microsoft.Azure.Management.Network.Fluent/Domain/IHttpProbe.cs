// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{


    /// <summary>
    /// An immutable client-side representation of an HTTP load balancing probe.
    /// </summary>
    public interface IHttpProbe  :
        IProbe
    {
        /// <returns>the HTTP request path for the HTTP probe to call to check the health status</returns>
        string RequestPath { get; }

    }
}