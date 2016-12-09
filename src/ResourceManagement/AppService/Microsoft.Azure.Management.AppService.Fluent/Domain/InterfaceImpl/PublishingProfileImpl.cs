// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Java.Util.Regex;

    internal partial class PublishingProfileImpl 
    {
        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.GitPassword
        {
            get
            {
                return this.GitPassword();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.GitUrl
        {
            get
            {
                return this.GitUrl();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.FtpUsername
        {
            get
            {
                return this.FtpUsername();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.FtpUrl
        {
            get
            {
                return this.FtpUrl();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.GitUsername
        {
            get
            {
                return this.GitUsername();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile.FtpPassword
        {
            get
            {
                return this.FtpPassword();
            }
        }
    }
}