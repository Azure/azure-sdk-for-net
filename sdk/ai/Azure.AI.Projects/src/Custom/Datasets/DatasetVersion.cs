// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Projects
{
    /// <summary>
    /// DatasetVersion Definition
    /// Please note <see cref="DatasetVersion"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="FileDatasetVersion"/> and <see cref="FolderDatasetVersion"/>.
    /// </summary>
    public abstract partial class DatasetVersion
    {
        public Uri DataUri { get; set; }
    }
}
