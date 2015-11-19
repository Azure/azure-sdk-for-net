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
    using FrameworkMockingLevel = Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation.ServiceLocationMockingLevel;
    using FrameworkServiceLocator = Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation.ServiceLocator;
    using FrameworkSimulationManager = Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation.IServiceLocationSimulationManager;

    internal class ServiceLocationSimulationManager : IServiceLocationSimulationManager
    {
        /// <inheritdoc />
        public void RegisterInstance<TService>(TService instance)
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkSimulationManager>();
            manager.RegisterInstance<TService>(instance);
        }

        /// <inheritdoc />
        public void RegisterInstance(Type type, object instance)
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkSimulationManager>();
            manager.RegisterInstance(type, instance);
        }

        /// <inheritdoc />
        public void RegisterType<T>(Type type)
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkSimulationManager>();
            manager.RegisterType<T>(type);
        }

        /// <inheritdoc />
        public void RegisterType<TInterface, TConcretion>() where TConcretion : class, TInterface
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkSimulationManager>();
            manager.RegisterType<TInterface, TConcretion>();
        }

        /// <inheritdoc />
        public void RegisterType(Type type, Type registrationValue)
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkSimulationManager>();
            manager.RegisterType(type, registrationValue);
        }

        /// <inheritdoc />
        public ServiceLocationMockingLevel MockingLevel
        {
            get
            {
                var manager = FrameworkServiceLocator.Instance.Locate<FrameworkSimulationManager>();
                return (ServiceLocationMockingLevel)(int)manager.MockingLevel;
            }

            set
            {
                var manager = FrameworkServiceLocator.Instance.Locate<FrameworkSimulationManager>();
                manager.MockingLevel = (FrameworkMockingLevel)(int)value;
            }
        }
    }
}
