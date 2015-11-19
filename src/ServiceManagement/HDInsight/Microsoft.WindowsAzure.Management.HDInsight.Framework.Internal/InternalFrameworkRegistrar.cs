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
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class InternalFrameworkRegistrar : ServiceLocation.IServiceLocationRegistrar
    {
        public void Register(ServiceLocation.IServiceLocationRuntimeManager manager, ServiceLocation.IServiceLocator locator)
        {
            if (ReferenceEquals(manager, null))
            {
                throw new ArgumentNullException("manager");
            }
            if (ReferenceEquals(locator, null))
            {
                throw new ArgumentNullException("locator");
            }

            var runtimeManager = new ServiceLocationRuntimeManager();
            manager.RegisterInstance<IServiceLocationRuntimeManager>(runtimeManager);
            manager.RegisterType<IServiceLocationSimulationManager, ServiceLocationSimulationManager>();
            manager.RegisterType<IServiceLocationIndividualTestManager, ServiceLocationIndividualTestManager>();
            manager.RegisterInstance(ServiceLocator.Instance);
            var sweeper = locator.Locate<IServiceLocationAssemblySweep>();
            sweeper.RegisterRegistrarProxy<IServiceLocationRegistrar>(new InternalServiceLocationRegistrarProxyFactory(runtimeManager, ServiceLocator.Instance));
        }
    }
}
