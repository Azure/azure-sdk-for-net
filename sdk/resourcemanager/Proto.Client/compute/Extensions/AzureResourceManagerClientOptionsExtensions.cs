using Azure.ResourceManager.Core;

namespace Proto.Compute.Extensions
{
    /// <summary>
    /// A class to add extension methods to ArmClientOptions.
    /// </summary>
    public static class ArmClientOptionsExtensions
    {
        /// <summary>
        /// Adds a method to ArmClientOptions which returns all the versions to all resources inside the compute resource provider.
        /// </summary>
        ///<param> The <see  cref="ArmClientOptions" /> instance the method will execute against. </param>
        /// <returns> Returns a response with the <see cref="ComputeRestApiVersions"/> operation for this resource. </returns>
        public static ComputeRestApiVersions GetComputeRestApiVersions(this ArmClientOptions ArmClientOptions)
        {
            return ArmClientOptions.GetOverrideObject<ComputeRestApiVersions>(() => new ComputeRestApiVersions()) as ComputeRestApiVersions;
        }
    }
}
