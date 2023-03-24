// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.JobPlanModels
{
    /// <summary>
    /// SMB Feature whether to preserve permissions on the folder
    /// </summary>
    internal enum FolderPropertiesMode
    {
        None = 0,
        NoFolders = 1,
        AllFoldersExceptRoot = 2,
        AllFolders = 3,
    }
}
