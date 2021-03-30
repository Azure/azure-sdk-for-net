using Azure.ResourceManager.Core;

namespace Proto.Network
{
    /// <summary>
    /// A class representing a builder object to help create a subnet.
    /// </summary>
    public class SubnetBuilder : ArmBuilder<ResourceGroupResourceIdentifier, Subnet, SubnetData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubnetBuilder"/> class.
        /// </summary>
        /// <param name="container"> The container to create the subnet in. </param>
        /// <param name="subnet"> The data model representing the subnet to create. </param>
        internal SubnetBuilder(SubnetContainer container, SubnetData subnet)
            : base(container, subnet)
        {

        }

        /// <inheritdoc/>
        protected override void OnBeforeBuild()
        {
            Resource.Model.Name = ResourceName;
        }
    }
}
