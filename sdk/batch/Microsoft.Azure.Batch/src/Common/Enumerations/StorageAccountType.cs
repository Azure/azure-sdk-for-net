namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The storage account type for use in creating data disks.
    /// </summary>
    public enum StorageAccountType
    {
        /// <summary>
        /// The data disk should use standard locally redundant storage.
        /// </summary>
        StandardLrs,

        /// <summary>
        /// The data disk should use premium locally redundant storage.
        /// </summary>
        PremiumLrs,

        /// <summary>
        /// The data disk / OS disk should use standard SSD locally redundant
        /// </summary>
        StandardSSDLRS
    }
}
