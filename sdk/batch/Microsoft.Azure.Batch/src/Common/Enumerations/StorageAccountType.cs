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
        PremiumLrs
    }
}
