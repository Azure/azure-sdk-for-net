//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Generates a unique topic for the test method.
    /// </summary>
    public sealed class UsesUniqueTopicAttribute: BeforeAfterTestAttribute
    {
        /// <summary>
        /// Gets name of the created topic.
        /// </summary>
        public static string TopicName { get; private set; }

        /// <summary>
        /// Creates a topic.
        /// </summary>
        /// <param name="methodUnderTest">Test method.</param>
        public override void Before(MethodInfo methodUnderTest)
        {
            base.Before(methodUnderTest);
            TopicName = Configuration.GetUniqueTopicName();
            Configuration.ServiceBus.CreateTopicAsync(TopicName).AsTask().Wait();
        }

        /// <summary>
        /// Deletes the topic.
        /// </summary>
        /// <param name="methodUnderTest">Test method.</param>
        public override void After(MethodInfo methodUnderTest)
        {
            base.After(methodUnderTest);
            Configuration.ServiceBus.DeleteTopicAsync(TopicName).AsTask().Wait();
            TopicName = null;
        }
    }
}
