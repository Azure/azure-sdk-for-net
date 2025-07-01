// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary>
    /// Autonomous Database base resource model.
    /// Please note <see cref="AutonomousDatabaseBaseProperties"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AutonomousDatabaseCloneProperties"/> and <see cref="AutonomousDatabaseProperties"/>.
    /// </summary>
    public abstract partial class AutonomousDatabaseBaseProperties
    {
        /// <summary> The compute model of the Autonomous Database. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutonomousDatabaseComputeModel? ComputeModel { get => DatabaseComputeModel.ToString(); set => DatabaseComputeModel = value.ToString(); }

        /// <summary> Database ocid. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(DatabaseOcid); }
    }
}
