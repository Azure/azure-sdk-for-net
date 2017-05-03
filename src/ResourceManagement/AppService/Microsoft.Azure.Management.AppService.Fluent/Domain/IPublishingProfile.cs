// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// Endpoints and credentials for publishing to a web app.
    /// </summary>
    public interface IPublishingProfile : IBeta
    {
        /// <summary>
        /// Gets the password used for Git publishing.
        /// </summary>
        string GitPassword { get; }

        /// <summary>
        /// Gets the url for FTP publishing, with ftp:// and the root folder.
        /// E.g. ftp://ftp.contoso.com/site/wwwroot.
        /// </summary>
        string FtpUrl { get; }

        /// <summary>
        /// Gets the password used for FTP publishing.
        /// </summary>
        string FtpPassword { get; }

        /// <summary>
        /// Gets the username used for FTP publishing.
        /// </summary>
        string FtpUsername { get; }

        /// <summary>
        /// Gets the url for FTP publishing, with https:// upfront.
        /// E.g. https://contoso.com:443/myRepo.git.
        /// </summary>
        string GitUrl { get; }

        /// <summary>
        /// Gets the username used for Git publishing.
        /// </summary>
        string GitUsername { get; }
    }
}