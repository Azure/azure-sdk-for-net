namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The storage Account type for use in creating data disks or OS disk.
    /// </summary>
    public enum StorageAccountType
    {
        /// <summary>
        /// The data disk / OS disk should use standard locally redundant storage.
        /// </summary>
        StandardLrs,

        /// <summary>
        /// The data disk / OS disk should use premium locally redundant storage.
        /// </summary>
        PremiumLrs,

        /// <summary>
        /// The data disk / OS disk should use standard SSD locally redundant storage.
        /// </summary>
        StandardSSDLRS
    }
}
