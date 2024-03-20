// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
{
    /// <summary>
    ///   <para>A representation of the onTokenIssuanceStart event request for preview_10_01_2021.</para>
    ///   <para>Relates the EventResponse-OnTokenIssuanceStartResponseData(preview_10_01_2021) and EventData-OnTokenIssuanceStartCalloutData(preview_10_01_2021).</para>
    /// </summary>
    ///
    [Serializable]
    public class OnTokenIssuanceStartCalloutRequest : CustomExtensionCalloutRequest
    {
        /// <summary>
        /// Data for the onTokenIssuanceStart event.
        /// </summary>
        public OnTokenIssuanceStartCalloutData Data { get; set; }
    }
}
