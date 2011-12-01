//-----------------------------------------------------------------------
// <copyright file="MessageUpdateFields.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the MessageUpdateFields enum.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Enumeration controlling the options for updating queue messages.
    /// </summary>
    [Flags]
    public enum MessageUpdateFields
    {
        /// <summary>
        /// Update the message visibility timeout.
        /// This is required for calls to UpdateMessage in version 2011-08-18.
        /// </summary>
        Visibility = 0x1,

        /// <summary>
        /// Update the message content.
        /// </summary>
        Content = 0x2
    }
}
