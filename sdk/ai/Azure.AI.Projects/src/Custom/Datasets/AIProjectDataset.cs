// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Projects
{
    /// <summary>
    /// AIProjectDataset Definition
    /// Please note <see cref="AIProjectDataset"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="FileDataset"/> and <see cref="FolderDataset"/>.
    /// </summary>
    public abstract partial class AIProjectDataset
    {
        public Uri DataUri { get; set; }
    }
}
