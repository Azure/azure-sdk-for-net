// -----------------------------------------------------------------------------------------
// <copyright file="XStoreSelectors.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------


namespace Microsoft.WindowsAzure.Test.Network
{
    using System;
    using Fiddler;

    /// <summary>
    /// XStoreSelectors are selectors and selector extensions that handle XStore traffic.
    /// </summary>
    public static class XStoreSelectors
    {
        /// <summary>
        /// BlobTraffic selects traffic intended for the XStore Blob FE.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> BlobTraffic()
        {
            return Selectors.IfHostNameContains(StorageConstants.BlobBaseDnsName);
        }

        /// <summary>
        /// ForBlobTraffic adds a selector that selects traffic intended for the XStore Blob FE.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> ForBlobTraffic(this Func<Session, bool> predicate)
        {
            return predicate.IfHostNameContains(StorageConstants.BlobBaseDnsName);
        }

        /// <summary>
        /// TableTraffic selects traffic intended for the XStore Table FE.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> TableTraffic()
        {
            return Selectors.IfHostNameContains(StorageConstants.TableBaseDnsName);
        }

        /// <summary>
        /// ForTableTraffic selects traffic intended for the XStore Table FE.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> ForTableTraffic(this Func<Session, bool> predicate)
        {
            return predicate.IfHostNameContains(StorageConstants.TableBaseDnsName);
        }

        /// <summary>
        /// QueueTraffic selects traffic intended for the XStore Queue FE.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> QueueTraffic()
        {
            return Selectors.IfHostNameContains(StorageConstants.QueueBaseDnsName);
        }

        /// <summary>
        /// ForQueueTraffic selects traffic intended for the XStore Queue FE.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector</returns>
        public static Func<Session, bool> ForQueueTraffic(this Func<Session, bool> predicate)
        {
            return predicate.IfHostNameContains(StorageConstants.QueueBaseDnsName);
        }
    }
}
