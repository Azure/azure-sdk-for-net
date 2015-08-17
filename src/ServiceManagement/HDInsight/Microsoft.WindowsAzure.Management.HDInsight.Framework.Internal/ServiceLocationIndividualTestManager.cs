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
    using FrameworkIndividualTestManager = Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation.IServiceLocationIndividualTestManager;
    using FrameworkServiceLocator = Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation.ServiceLocator;

    internal class ServiceLocationIndividualTestManager : IServiceLocationIndividualTestManager
    {
        public void Override<T>(T overrideValue)
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkIndividualTestManager>();
            manager.Override<T>(overrideValue);
        }

        public void Override(Type type, object overrideValue)
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkIndividualTestManager>();
            manager.Override(type, overrideValue);
        }

        public void Reset()
        {
            var manager = FrameworkServiceLocator.Instance.Locate<FrameworkIndividualTestManager>();
            manager.Reset();
        }
    }
}
