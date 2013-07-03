//-----------------------------------------------------------------------
// <copyright file="BlobHttpResponseParsers.Common.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the CloudStorageAccount class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Globalization;
    using System.IO;

#if WINDOWS_RT
    internal
#else
    public
#endif
        static partial class BlobHttpResponseParsers
    {
        /// <summary>
        /// Reads service properties from a stream.
        /// </summary>
        /// <param name="inputStream">The stream from which to read the service properties.</param>
        /// <returns>The service properties stored in the stream.</returns>
        public static ServiceProperties ReadServiceProperties(Stream inputStream)
        {
            return HttpResponseParsers.ReadServiceProperties(inputStream);
        }

        /// <summary>
        /// Gets a <see cref="LeaseStatus"/> from a string.
        /// </summary>
        /// <param name="leaseStatus">The lease status string.</param>
        /// <returns>A <see cref="LeaseStatus"/> enumeration.</returns>
        /// <remarks>If a null or empty string is supplied, a status of <see cref="LeaseStatus.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The string contains an unrecognized value.</exception>
        internal static LeaseStatus GetLeaseStatus(string leaseStatus)
        {
            if (!string.IsNullOrEmpty(leaseStatus))
            {
                switch (leaseStatus)
                {
                    case Constants.LockedValue:
                        return LeaseStatus.Locked;

                    case Constants.UnlockedValue:
                        return LeaseStatus.Unlocked;

                    default:
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, SR.InvalidLeaseStatus, leaseStatus), "leaseStatus");
                }
            }

            return LeaseStatus.Unspecified;
        }

        /// <summary>
        /// Gets a <see cref="LeaseState"/> from a string.
        /// </summary>
        /// <param name="leaseState">The lease state string.</param>
        /// <returns>A <see cref="LeaseState"/> enumeration.</returns>
        /// <remarks>If a null or empty string is supplied, a status of <see cref="LeaseState.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The string contains an unrecognized value.</exception>
        internal static LeaseState GetLeaseState(string leaseState)
        {
            if (!string.IsNullOrEmpty(leaseState))
            {
                switch (leaseState)
                {
                    case Constants.LeaseAvailableValue:
                        return LeaseState.Available;

                    case Constants.LeasedValue:
                        return LeaseState.Leased;

                    case Constants.LeaseExpiredValue:
                        return LeaseState.Expired;

                    case Constants.LeaseBreakingValue:
                        return LeaseState.Breaking;

                    case Constants.LeaseBrokenValue:
                        return LeaseState.Broken;

                    default:
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, SR.InvalidLeaseState, leaseState), "leaseState");
                }
            }

            return LeaseState.Unspecified;
        }

        /// <summary>
        /// Gets a <see cref="LeaseDuration"/> from a string.
        /// </summary>
        /// <param name="leaseDuration">The lease duration string.</param>
        /// <returns>A <see cref="LeaseDuration"/> enumeration.</returns>
        /// <remarks>If a null or empty string is supplied, a status of <see cref="LeaseDuration.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The string contains an unrecognized value.</exception>
        internal static LeaseDuration GetLeaseDuration(string leaseDuration)
        {
            if (!string.IsNullOrEmpty(leaseDuration))
            {
                switch (leaseDuration)
                {
                    case Constants.LeaseFixedValue:
                        return LeaseDuration.Fixed;

                    case Constants.LeaseInfiniteValue:
                        return LeaseDuration.Infinite;

                    default:
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, SR.InvalidLeaseDuration, leaseDuration), "leaseDuration");
                }
            }

            return LeaseDuration.Unspecified;
        }

        /// <summary>
        /// Builds a <see cref="CopyState"/> object from the given strings containing formatted copy information.
        /// </summary>
        /// <param name="copyStatusString">The copy status, as a string.</param>
        /// <param name="copyId">The copy ID.</param>
        /// <param name="copySourceString">The source URI of the copy, as a string.</param>
        /// <param name="copyProgressString">A string formatted as progressBytes/TotalBytes.</param>
        /// <param name="copyCompletionTimeString">The copy completion time, as a string, or null.</param>
        /// <param name="copyStatusDescription">The copy status description, if any.</param>
        /// <returns>A <see cref="CopyState"/> object populated from the given strings.</returns>
        internal static CopyState GetCopyAttributes(
            string copyStatusString,
            string copyId,
            string copySourceString,
            string copyProgressString,
            string copyCompletionTimeString,
            string copyStatusDescription)
        {
            CopyState copyAttributes = new CopyState
            {
                CopyId = copyId,
                StatusDescription = copyStatusDescription
            };

            switch (copyStatusString)
            {
                case Constants.CopySuccessValue:
                    copyAttributes.Status = CopyStatus.Success;
                    break;
                
                case Constants.CopyPendingValue:
                    copyAttributes.Status = CopyStatus.Pending;
                    break;
                
                case Constants.CopyAbortedValue:
                    copyAttributes.Status = CopyStatus.Aborted;
                    break;
                
                case Constants.CopyFailedValue:
                    copyAttributes.Status = CopyStatus.Failed;
                    break;
                
                default:
                    copyAttributes.Status = CopyStatus.Invalid;
                    break;
            }

            if (!string.IsNullOrEmpty(copyProgressString))
            {
                string[] progressSequence = copyProgressString.Split('/');
                copyAttributes.BytesCopied = long.Parse(progressSequence[0], CultureInfo.InvariantCulture);
                copyAttributes.TotalBytes = long.Parse(progressSequence[1], CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(copySourceString))
            {
                copyAttributes.Source = new Uri(copySourceString);
            }

            if (!string.IsNullOrEmpty(copyCompletionTimeString))
            {
                copyAttributes.CompletionTime = copyCompletionTimeString.ToUTCTime();
            }

            return copyAttributes;
        }
    }
}
