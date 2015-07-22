﻿namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    /// <summary>
    /// Represents the operation being requested for the user.
    /// </summary>
    /// <remarks>
    /// *******************************************************************************************
    /// DO NOT change any existing values, we are using string representations of these in tables
    /// where operation tracking is done, so need to be able to correctly parse values that were
    /// logged at any point.
    /// Adding new values is okay since it will not break Enum.Parse of the old values.
    /// *******************************************************************************************
    /// </remarks>
    public enum UserChangeOperationType
    {
        Disable,
        Enable
    }
}
