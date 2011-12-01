//-----------------------------------------------------------------------
// <copyright file="NullTaskReturn.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the NullTaskReturn class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A NullTaskReturn type.
    /// </summary>
    internal class NullTaskReturn
    {
        /// <summary>
        /// Represents a no-return from a task.
        /// </summary>
        public static readonly NullTaskReturn Value = new NullTaskReturn();

        /// <summary>
        /// Prevents a default instance of the <see cref="NullTaskReturn"/> class from being created.
        /// </summary>
        private NullTaskReturn()
        {
        }
    }
}