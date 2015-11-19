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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Internal
{
    using System;

    /// <summary>
    ///     Locates services that ViewModels need.
    /// </summary>
    public interface IServiceLocationManager
    {
        /// <summary>
        ///     Registers a new instance with of a service with the container.
        /// </summary>
        /// <typeparam name="TService">
        ///     The type to register.
        /// </typeparam>
        /// <param name="instance">
        ///     The instance to register.
        /// </param>
        void RegisterInstance<TService>(TService instance);

        /// <summary>
        ///     Registers a new instance with of a service with the container.
        /// </summary>
        /// <param name="type">
        ///     The type to register.
        /// </param>
        /// <param name="instance">
        ///     The instance to register.
        /// </param>
        void RegisterInstance(Type type, object instance);

        /// <summary>
        ///     Register type.
        /// </summary>
        /// <typeparam name="T">Type to map.</typeparam>
        /// <param name="type">Type to map to.</param>
        void RegisterType<T>(Type type);

        /// <summary>
        ///     Register type.
        /// </summary>
        /// <typeparam name="TInterface">The service interface.</typeparam>
        /// <typeparam  name="TConcretion">The implementation type.</typeparam>
        void RegisterType<TInterface, TConcretion>() where TConcretion : class, TInterface;

        /// <summary>
        ///     Register type.
        /// </summary>
        /// <param name="type">Type to map.</param>
        /// <param name="registrationValue">Type to map to.</param>
        void RegisterType(Type type, Type registrationValue);
    }
}