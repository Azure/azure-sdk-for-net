namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    /// <summary>
    /// The type of user being changed.
    /// </summary>
    /// <remarks>
    /// *******************************************************************************************
    /// DO NOT change any existing values, we are using string representations of these in tables
    /// where operation tracking is done, so need to be able to correctly parse values that were
    /// logged at any point.
    /// Adding new values is okay since it will not break Enum.Parse of the old values.
    /// *******************************************************************************************
    /// </remarks>
    public enum UserType
    {
        Rdp,
        Http
    }
}