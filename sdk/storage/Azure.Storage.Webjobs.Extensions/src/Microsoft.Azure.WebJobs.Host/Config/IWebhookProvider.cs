// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Config
{
    /// <summary>
    /// Allow a host to expose a HTTP web hook for extensions. 
    /// </summary>
    [Obsolete("Not ready for public consumption.")]
    public interface IWebHookProvider
    {
        /// <summary>
        /// Gets the WebHook URL for an extension.
        /// </summary>
        /// <param name="extension">An instance of the extension <see cref="IExtensionConfigProvider"/> to own the http handler.</param>
        /// <returns>A URL (without a query string). Caller may append a query string.</returns>
        Uri GetUrl(IExtensionConfigProvider extension);
    }
}
