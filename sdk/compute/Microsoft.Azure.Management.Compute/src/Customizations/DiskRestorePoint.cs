namespace Microsoft.Azure.Management.Compute.Models
{
    /// <summary>
    /// Properties of disk restore point
    /// </summary>
    public partial class DiskRestorePoint : ProxyOnlyResource
    {
        /// <summary>
        /// Initializes a new instance of the DiskRestorePoint class.
        /// </summary>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="timeCreated">The timestamp of restorePoint
        /// creation</param>
        /// <param name="sourceResourceId">arm id of source disk</param>
        /// <param name="osType">The Operating System type. Possible values
        /// include: 'Windows', 'Linux'</param>
        /// <param name="hyperVGeneration">The hypervisor generation of the
        /// Virtual Machine. Applicable to OS disks only. Possible values
        /// include: 'V1', 'V2'</param>
        /// <param name="purchasePlan">Purchase plan information for the the
        /// image from which the OS disk was created.</param>
        /// was created.</param>
        /// <param name="familyId">id of the backing snapshot's MIS
        /// family</param>
        /// <param name="sourceUniqueId">unique incarnation id of the source
        /// disk</param>
        /// <param name="encryption">Encryption property can be used to encrypt
        /// data at rest with customer managed keys or platform managed
        /// keys.</param>
        /// <param name="supportsHibernation">Indicates the OS on a disk
        /// supports hibernation.</param>
        /// <param name="networkAccessPolicy">Possible values include:
        /// 'AllowAll', 'AllowPrivate', 'DenyAll'</param>
        /// <param name="publicNetworkAccess">Possible values include:
        /// 'Enabled', 'Disabled'</param>
        /// <param name="diskAccessId">ARM id of the DiskAccess resource for
        /// using private endpoints on disks.</param>
        /// <param name="completionPercent">Percentage complete for the
        /// background copy when a resource is created via the CopyStart
        /// operation.</param>
        /// <param name="supportedCapabilities">List of supported capabilities
        /// (like accelerated networking) for the image from which the OS disk
        public DiskRestorePoint(string id, string name, string type, System.DateTime? timeCreated, string sourceResourceId, OperatingSystemTypes? osType, string hyperVGeneration, PurchasePlan purchasePlan, string familyId, string sourceUniqueId = default(string), Encryption encryption = default(Encryption), bool? supportsHibernation = default(bool?))
                    : base(id, name, type)
        {
            TimeCreated = timeCreated;
            SourceResourceId = sourceResourceId;
            OsType = osType;
            HyperVGeneration = hyperVGeneration;
            PurchasePlan = purchasePlan;
            FamilyId = familyId;
            SourceUniqueId = sourceUniqueId;
            Encryption = encryption;
            SupportsHibernation = supportsHibernation;
            CustomInit();
        }

    }
}
