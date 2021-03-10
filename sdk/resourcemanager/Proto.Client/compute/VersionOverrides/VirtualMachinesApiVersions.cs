using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing the valid api versions for a virtual machine.
    /// </summary>
    public class VirtualMachinesApiVersions : ApiVersionsBase
    {
        /// <summary>
        /// Api version 2020/06/01
        /// </summary>
        public static readonly VirtualMachinesApiVersions V2020_06_01 = new VirtualMachinesApiVersions("2020-06-01");

        /// <summary>
        /// Api version 2019/12/01
        /// </summary>
        public static readonly VirtualMachinesApiVersions V2019_12_01 = new VirtualMachinesApiVersions("2019-12-01");

        /// <summary>
        /// Default api version to use.
        /// </summary>
        public static readonly VirtualMachinesApiVersions Default = V2020_06_01;

        /// <inheritdoc/>
        public override ResourceType ResourceType => VirtualMachineOperations.ResourceType;

        private VirtualMachinesApiVersions(string value) : base(value) { }

        /// <summary>
        /// Converts an api version into a string.
        /// </summary>
        /// <param name="version"> The api version instnace to convert. </param>
        public static implicit operator string(VirtualMachinesApiVersions version)
        {
            if (version == null)
                return null;
            return version.ToString();
        }
    }
}
