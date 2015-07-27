// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework.HttpRecorder;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    /// <summary>
    /// A coordinator for tracking and undoing WAML operations.  Usage pattern is
    /// using(MockContext.Create())
    /// {
    ///   maml stuff
    /// }
    /// You can also manually call the Dispose() or UndoAll() methods to undo all 'undoable' operations since the
    /// UndoContext was created.
    /// Call: MockContext.Commit() to remove all undo information
    /// </summary>
    public class MockContext : IDisposable
    {
        //prevent multiple dispose events
        protected bool disposed = false;
                
        /// <summary>
        /// Return a new UndoContext
        /// </summary>
        /// <returns></returns>
        public static MockContext Start(int currentMethodStackDepth = 2)
        {
            var className = TestUtilities.GetCallingClass(currentMethodStackDepth);
            var methodName = TestUtilities.GetCurrentMethodName(currentMethodStackDepth);
            return Start(className, methodName);
        }

        /// <summary>
        /// Return a new UndoContext
        /// </summary>
        /// <returns></returns>
        public static MockContext Start(string className, string methodName)
        {
            var context = new MockContext();

            HttpMockServer.Initialize(className, methodName);
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                context.disposed = false;
            }

            return context;
        }

        /// <summary>
        /// Stop recording and Discard all undo information
        /// </summary>
        public void Stop()
        {
            HttpMockServer.Flush();
        }
        
        /// <summary>
        /// Dispose only if we have not previously been disposed
        /// </summary>
        /// <param name="disposing">true if we should dispose, otherwise false</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !this.disposed)
            {
                this.Stop();
                this.disposed = true;
            }
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
