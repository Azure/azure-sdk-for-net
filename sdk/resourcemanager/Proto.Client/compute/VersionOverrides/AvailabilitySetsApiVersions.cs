using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing the valid api versions for an availability set.
    /// </summary>
    public class AvailabilitySetsApiVersions : ApiVersionsBase
    {
        /// <summary>
        /// Api version for 2020/05/01.
        /// </summary>
        public static readonly AvailabilitySetsApiVersions V2020_06_01 = new AvailabilitySetsApiVersions("2020-06-01");

        /// <summary>
        /// Api version for 2019/12/01.
        /// </summary>
        public static readonly AvailabilitySetsApiVersions V2019_12_01 = new AvailabilitySetsApiVersions("2019-12-01");

        /// <summary>
        /// Default api version to use.
        /// </summary>
        public static readonly AvailabilitySetsApiVersions Default = V2020_06_01;

        public override ResourceType ResourceType => AvailabilitySetOperations.ResourceType;

        private AvailabilitySetsApiVersions(string value) : base(value) { }

        /// <summary>
        /// Converts an api version into a string.
        /// </summary>
        /// <param name="version"> The api version instnace to convert. </param>
        public static implicit operator string(AvailabilitySetsApiVersions version)
        {
            if (version == null)
                return null;
            return version.ToString();
        }
    }
}
