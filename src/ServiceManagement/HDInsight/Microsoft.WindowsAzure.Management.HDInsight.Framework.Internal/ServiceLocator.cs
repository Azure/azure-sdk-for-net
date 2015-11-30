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
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using FrameworkLocator = Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation.ServiceLocator;
    using IFrameworkLocator = Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation.IServiceLocator;

    /// <summary>
    ///     The main service locator for the application.
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        private static IServiceLocator instance = new ServiceLocator();

        /// <summary>
        /// Gets an instance of the service locator.
        /// </summary>
        public static IServiceLocator Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        ///     Locates an instance that implements the specified interface.
        /// </summary>
        /// <typeparam name="T"> Interface to locate. </typeparam>
        /// <returns> Instance of the interface. </returns>
        T IServiceLocator.Locate<T>()
        {
            return FrameworkLocator.Instance.Locate<T>();
        }

        /// <summary>
        ///     Locates an instance that implements the specified interface.
        /// </summary>
        /// <param name="type"> Interface to locate. </param>
        /// <returns> Instance of the interface. </returns>
        object IServiceLocator.Locate(Type type)
        {
            return FrameworkLocator.Instance.Locate(type);
        }

        /// <summary>
        ///     Locates an instance that implements the specified interface.
        /// </summary>
        /// <typeparam name="T"> Interface to locate. </typeparam>
        /// <returns> Instance of the interface. </returns>
        public static T Locate<T>()
        {
            return instance.Locate<T>();
        }

        /// <summary>
        ///     Locates an instance that implements the specified interface.
        /// </summary>
        /// <param name="type"> Interface to locate. </param>
        /// <returns> Instance of the interface. </returns>
        public static object Locate(Type type)
        {
            return instance.Locate(type);
        }
    }
}
