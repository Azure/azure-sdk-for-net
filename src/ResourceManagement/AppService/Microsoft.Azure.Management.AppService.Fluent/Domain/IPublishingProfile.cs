// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// Endpoints and credentials for publishing to a web app.
    /// </summary>
    public interface IPublishingProfile 
    {
        string GitPassword { get; }

        string FtpUrl { get; }

        string FtpPassword { get; }

        string FtpUsername { get; }

        string GitUrl { get; }

        string GitUsername { get; }
    }
}