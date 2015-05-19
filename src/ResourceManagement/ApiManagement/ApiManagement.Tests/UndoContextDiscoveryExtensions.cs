//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace ApiManagement.Tests
{
    using Microsoft.Azure.Test;

    /// <summary>
    /// Class used to discover and construct undo handlers available in the app domain
    /// </summary>
    /// 
    [UndoHandlerFactory]
    public static class UndoContextDiscoveryExtensions
    {
        /// <summary>
        /// Create an undo handler for Api Management service operations
        /// </summary>
        /// <returns>AN undo handler for Api Management service operations</returns>
        public static OperationUndoHandler CreateApiManagementUndoHandler()
        {
            return new ApiManagementResourceProviderUndoHandler();
        }
    }
}