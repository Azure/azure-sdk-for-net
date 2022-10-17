// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Checkpoint for paused or ongoing transfers
    /// </summary>
    internal class DataMovementCheckpointer
    {
        /// <summary>
        /// For mocking
        /// </summary>
        protected DataMovementCheckpointer() { }

        /// <summary>
        /// Add transfers
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddTransfer(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove transfers
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveTransfer(string id)
        {
            throw new NotImplementedException();
        }
    }
}
