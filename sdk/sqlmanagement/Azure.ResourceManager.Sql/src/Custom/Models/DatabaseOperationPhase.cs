// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct DatabaseOperationPhase
    {
        private const string BuildingHyperscaleComponentsValue = "BuildingHyperscaleComponents";
        private const string LogTransitionInProgressValue = "LogTransitionInProgress";

        /// <summary> LogTransitionInProgress. </summary>
        public static DatabaseOperationPhase LogTransitionInProgress { get; } = new DatabaseOperationPhase(LogTransitionInProgressValue);
        /// <summary> BuildingHyperscaleComponents. </summary>
        public static DatabaseOperationPhase BuildingHyperscaleComponents { get; } = new DatabaseOperationPhase(BuildingHyperscaleComponentsValue);
    }
}
