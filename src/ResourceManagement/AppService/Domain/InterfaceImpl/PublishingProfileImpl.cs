// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    internal partial class PublishingProfileImpl 
    {
        /// <summary>
        /// Gets the password used for FTP publishing.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.FtpPassword
        {
            get
            {
                return this.FtpPassword();
            }
        }

        /// <summary>
        /// Gets the username used for FTP publishing.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.FtpUsername
        {
            get
            {
                return this.FtpUsername();
            }
        }

        /// <summary>
        /// Gets the url for FTP publishing, with https:// upfront.
        /// E.g. https://contoso.com:443/myRepo.git.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.GitUrl
        {
            get
            {
                return this.GitUrl();
            }
        }

        /// <summary>
        /// Gets the url for FTP publishing, with ftp:// and the root folder.
        /// E.g. ftp://ftp.contoso.com/site/wwwroot.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.FtpUrl
        {
            get
            {
                return this.FtpUrl();
            }
        }

        /// <summary>
        /// Gets the password used for Git publishing.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.GitPassword
        {
            get
            {
                return this.GitPassword();
            }
        }

        /// <summary>
        /// Gets the username used for Git publishing.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.GitUsername
        {
            get
            {
                return this.GitUsername();
            }
        }
    }
}