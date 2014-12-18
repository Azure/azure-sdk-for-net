// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation
{
    using System;

    /// <summary>
    ///     Provides services to override a service location for a single test.
    /// </summary>
    internal interface IServiceLocationIndividualTestManager
    {
        /// <summary>
        ///     Override default interface-to-implementation association.
        /// </summary>
        /// <typeparam name="T"> Interface to override. </typeparam>
        /// <param name="overrideValue"> Value to override with. </param>
        void Override<T>(T overrideValue);

        /// <summary>
        ///     Override default interface-to-implementation association.
        /// </summary>
        /// <param name="type"> Interface to override. </param>
        /// <param name="overrideValue"> Value to override with. </param>
        void Override(Type type, object overrideValue);

        /// <summary>
        ///     Resets the overrides.
        /// </summary>
        void Reset();
    }
}