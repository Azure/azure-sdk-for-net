// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.RepositoryType
{
    /// <summary>
    /// The type of a repository.
    /// </summary>
    public enum RepositoryType  :
        enum<Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.RepositoryType.RepositoryType>
    {
        public RepositoryType GIT;
        public RepositoryType MERCURIAL;
    }
}