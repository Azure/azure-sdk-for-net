namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The mode to use when logging in to a Windows user.
    /// </summary>
    public enum LoginMode
    {
        /// <summary>
        /// The LOGON32_LOGON_BATCH Win32 login mode. The batch login mode is
        /// recommended for long running parallel processes.
        /// </summary>
        Batch,

        /// <summary>
        /// The LOGON32_LOGON_INTERACTIVE Win32 login mode. Some applications
        /// require having permissions associated with the interactive login
        /// mode. If this is the case for an application used in your task,
        /// then this option is recommended.
        /// </summary>
        Interactive
    }
}
