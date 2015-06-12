// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Test;

namespace OperationalInsights.Tests.Helpers
{
    /// <summary>
    /// Discovery extensions - used to discover and construct available undo handlers 
    /// in the current app domain
    /// </summary>
    [UndoHandlerFactory]
    public static class UndoContextDiscoveryExtensions
    {
        /// <summary>
        /// Create the undo handler for workspace operations
        /// </summary>
        /// <returns>An undo handler for workspace operations</returns>
        public static OperationUndoHandler CreateWorkspaceUndoHandler()
        {
            return new WorkspaceUndoHandler();
        }

        /// <summary>
        /// Create the undo handler for storage insight operations
        /// </summary>
        /// <returns>An undo handler for storage insight operations</returns>
        public static OperationUndoHandler CreateStorageInsightUndoHandler()
        {
            return new StorageInsightUndoHandler();
        }
    }
}
