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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight;

    internal class UserChangeRequestManager : IUserChangeRequestManager
    {
        private Dictionary<UserChangeRequestUserType,
                           Tuple<Func<IHDInsightSubscriptionAbstractionContext, string, string, Uri>,
                           Func<UserChangeRequestOperationType, string, string, DateTimeOffset, string>>>
        userChangeRequestHandlers = new Dictionary<UserChangeRequestUserType, Tuple<Func<IHDInsightSubscriptionAbstractionContext, string, string, Uri>, Func<UserChangeRequestOperationType, string, string, DateTimeOffset, string>>>();

        public Tuple<Func<IHDInsightSubscriptionAbstractionContext, string, string, Uri>,
                     Func<UserChangeRequestOperationType, string, string, DateTimeOffset, string>> LocateUserChangeRequestHandler(Type credentialsType, UserChangeRequestUserType changeType)
        {
            return this.userChangeRequestHandlers[changeType];
        }

        public void RegisterUserChangeRequestHandler(Type credentialsType,
                                                     UserChangeRequestUserType changeType,
                                                     Func<IHDInsightSubscriptionAbstractionContext, string, string, Uri> uriBuilder,
                                                     Func<UserChangeRequestOperationType, string, string, DateTimeOffset, string> payloadConverter)
        {
            this.userChangeRequestHandlers[changeType] = new Tuple<Func<IHDInsightSubscriptionAbstractionContext, string, string, Uri>, Func<UserChangeRequestOperationType, string, string, DateTimeOffset, string>>(uriBuilder, payloadConverter);
        }
    }
}
