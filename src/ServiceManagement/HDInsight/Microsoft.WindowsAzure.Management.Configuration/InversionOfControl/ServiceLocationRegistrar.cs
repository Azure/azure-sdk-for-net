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
namespace Microsoft.WindowsAzure.Management.Configuration.InversionOfControl
{
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    /// <summary>
    /// Registrar for IOC injections in this assembly.
    /// </summary>
    internal class ServiceLocationRegistrar : IServiceLocationRegistrar
    {
        /// <summary>
        /// Registers all known contracts and their concretes.
        /// </summary>
        /// <param name="manager">The Servicelocation manager.</param>
        /// <param name="locator">The service locator.</param>
        public void Register(IServiceLocationRuntimeManager manager, IServiceLocator locator)
        {
            manager.ArgumentNotNull("manager");

            manager.RegisterType<IAzureHDInsightClusterConfigurationAccessorFactory, AzureHDInsightClusterConfigurationAccessorFactory>();
            manager.RegisterType<IAzureHDInsightConfigurationRestClientFactory, AzureHDInsightConfigurationRestClientFactory>();
        }
    }
}