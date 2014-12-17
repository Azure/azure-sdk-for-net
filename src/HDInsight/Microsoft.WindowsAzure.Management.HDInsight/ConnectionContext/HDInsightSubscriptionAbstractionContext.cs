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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;

    /// <summary>
    /// Represents an Abstraction Context for a Hadoop Subscription.
    /// </summary>
    public class HDInsightSubscriptionAbstractionContext : AbstractionContext, IHDInsightSubscriptionAbstractionContext
    {
        /// <summary>
        /// Initializes a new instance of the HDInsightSubscriptionAbstractionContext class.
        /// </summary>
        /// <param name="credentials">
        /// The subscription credentials.
        /// </param>
        /// <param name="token">
        /// A Cancelation Token.
        /// </param>
        public HDInsightSubscriptionAbstractionContext(IHDInsightSubscriptionCredentials credentials, CancellationToken token)
            : base(token)
        {
            this.Credentials = credentials;
        }

        /// <summary>
        /// Initializes a new instance of the HDInsightSubscriptionAbstractionContext class.
        /// </summary>
        /// <param name="credentials">
        /// The subscription credentials.
        /// </param>
        /// <param name="context">
        /// An abstraction context to clone.
        /// </param>
        public HDInsightSubscriptionAbstractionContext(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context)
            : base(context)
        {
            this.Credentials = credentials;
        }

        /// <inheritdoc />
        public IHDInsightSubscriptionCredentials Credentials { get; private set; }
    }
}
