namespace Microsoft.Azure.Management.ResourceManager.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Resource information.
    /// </summary>
    public partial class GenericResourceExpanded : GenericResource
    {
        /// <summary>
        /// Initializes a new instance of the GenericResourceExpanded class.
        /// </summary>
        /// <param name="id">Resource ID</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="location">Resource location</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="plan">The plan of the resource.</param>
        /// <param name="properties">The resource properties.</param>
        /// <param name="kind">The kind of the resource.</param>
        /// <param name="managedBy">ID of the resource that manages this
        /// resource.</param>
        /// <param name="sku">The SKU of the resource.</param>
        /// <param name="identity">The identity of the resource.</param>
        /// <param name="createdTime">The created time of the resource. This is
        /// only present if requested via the $expand query parameter.</param>
        /// <param name="changedTime">The changed time of the resource. This is
        /// only present if requested via the $expand query parameter.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// resource. This is only present if requested via the $expand query
        /// parameter.</param>
        public GenericResourceExpanded(string id, string name, string type, string location, IDictionary<string, string> tags, Plan plan = default(Plan), object properties = default(object), string kind = default(string), string managedBy = default(string), Sku sku = default(Sku), Identity identity = default(Identity), System.DateTime? createdTime = default(System.DateTime?), System.DateTime? changedTime = default(System.DateTime?), string provisioningState = default(string))
            : this(id, name, type, location, default(ExtendedLocation), tags, plan, properties, kind, managedBy, sku, identity, createdTime, changedTime, provisioningState)
        {
        }
    }
}
