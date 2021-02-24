namespace Proto.Compute
{
    /// <summary>
    /// A class representing which api version to use for each compute resource.
    /// </summary>
    public class ComputeRestApiVersions
    {
        internal ComputeRestApiVersions()
        {
            VirtualMachinesVersion = VirtualMachinesApiVersions.Default;
            AvailabilitySetsVersion = AvailabilitySetsApiVersions.Default;
        }

        /// <summary>
        /// Gets or sets the virtual machine api version.
        /// </summary>
        public VirtualMachinesApiVersions VirtualMachinesVersion { get; set; }

        /// <summary>
        /// Gets or sets the availability set api version.
        /// </summary>
        public AvailabilitySetsApiVersions AvailabilitySetsVersion { get; set; }
    }
}
