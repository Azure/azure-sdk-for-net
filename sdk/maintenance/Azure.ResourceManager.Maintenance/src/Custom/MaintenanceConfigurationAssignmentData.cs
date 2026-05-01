// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Maintenance.Models;

namespace Azure.ResourceManager.Maintenance
{
    public partial class MaintenanceConfigurationAssignmentData
    {
        // C# does not allow chaining two implicit conversions. The generated test samples
        // do: `MaintenanceConfigurationAssignmentData result = await ...Async(options);`
        // where the method returns Task<Response<Models.MaintenanceConfigurationAssignmentData>>.
        // After await, the compiler sees Response<Models.X> and needs to convert to Root.X.
        // Without this operator, the compiler would need TWO implicit conversions:
        //   1. Response<Models.X> → Models.X  (via Response<T>.operator T)
        //   2. Models.X → Root.X              (via our custom implicit operator)
        // C# spec §10.4 forbids chaining user-defined implicit conversions.
        // This single-step operator bridges Response<Models.X> directly to Root.X,
        // enabling assignment without intermediate variables.

        /// <summary>
        /// Converts a <see cref="Response{T}"/> of <see cref="Models.MaintenanceConfigurationAssignmentData"/>
        /// directly to the root namespace <see cref="MaintenanceConfigurationAssignmentData"/>.
        /// </summary>
        /// <param name="response"> The response containing the Models namespace instance. </param>
        public static implicit operator MaintenanceConfigurationAssignmentData(Response<Models.MaintenanceConfigurationAssignmentData> response)
        {
            if (response == null) return null;
            Models.MaintenanceConfigurationAssignmentData modelsValue = response.Value;
            return modelsValue;
        }
    }
}
