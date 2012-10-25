// -----------------------------------------------------------------------------------------
// <copyright file="BufferBehaviors.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------



namespace Microsoft.WindowsAzure.Test.Network.Behaviors
{
    /// <summary>
    /// BufferBehaviors describes behaviors that affect the buffering of responses before they're returned to the calling code.
    /// </summary>
    public static class BufferBehaviors
    {
        /// <summary>
        /// BufferRequests returns a behavior that ensures the responses from the server are fully buffered 
        /// before they're delivered to user code.
        /// </summary>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior BufferResponses()
        {
            return new ProxyBehavior(session => session.bBufferResponse = true, type: TriggerType.BeforeRequest);
        }

        /// <summary>
        /// BufferRequests returns a behavior that ensures the responses from the server are not buffered.
        /// </summary>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DoNotBufferResponses()
        {
            return new ProxyBehavior(session => session.bBufferResponse = false, type: TriggerType.BeforeRequest);
        }
    }
}
