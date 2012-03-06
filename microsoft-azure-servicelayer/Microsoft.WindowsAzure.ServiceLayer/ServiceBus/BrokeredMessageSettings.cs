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
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Settings of a new brokered message.
    /// </summary>
    public sealed class BrokeredMessageSettings
    {
        /// <summary>
        /// Text of the message.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messageText">Text of the message.</param>
        public BrokeredMessageSettings(string messageText)
        {
            if (messageText == null)
            {
                throw new ArgumentNullException("messageText");
            }

            Text = messageText;
        }

        /// <summary>
        /// Submits content to the given request.
        /// </summary>
        /// <param name="request">Target request.</param>
        internal void SubmitTo(HttpRequestMessage request)
        {
            request.Content = new StringContent(Text, Encoding.UTF8, Constants.MessageContentType);
        }
    }
}
