// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    
    /// <summary>
    /// Controls access to a set of properties.  All reads/writes pass through here.
    /// </summary>
    internal class PropertyAccessController
    {
        private readonly BindingState bindingState;

        internal BindingState BindingState
        {
            get { return this.bindingState; }
        }

        /// <summary>
        /// Creates a new instance of a <see cref="PropertyAccessController"/>.
        /// </summary>
        /// <param name="bindingState">The binding state to set this on this acesss controller.</param>
        public PropertyAccessController(BindingState bindingState)
        {
            this.bindingState = bindingState;
        }

        /// <summary>
        /// Executes the specified <paramref name="propertyReadAction"/>.
        /// </summary>
        /// <typeparam name="T">The type of the property to read.</typeparam>
        /// <param name="propertyReadAction">The property read action to execute.</param>
        /// <param name="allowedAccess">The allowed access of the particular property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The result of the <paramref name="propertyReadAction"/>.</returns>
        public T ReadProperty<T>(Func<T> propertyReadAction, BindingAccess allowedAccess, string propertyName)
        {
            if (!this.IsAccessAllowed(BindingAccess.Read, allowedAccess))
            {
                throw new InvalidOperationException(string.Format(BatchErrorMessages.PropertiesReadAccessViolation, propertyName, this.bindingState.ToString()));
            }

            return propertyReadAction();
        }

        /// <summary>
        /// Executes the specified <paramref name="propertyWriteAction"/>
        /// </summary>
        /// <param name="propertyWriteAction">The write action.</param>
        /// <param name="allowedAccess">The allowed access of the particular property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public void WriteProperty(Action propertyWriteAction, BindingAccess allowedAccess, string propertyName)
        {
            if (!this.IsAccessAllowed(BindingAccess.Write, allowedAccess))
            {
                throw new InvalidOperationException(string.Format(BatchErrorMessages.PropertiesWriteAccessViolation, propertyName, this.bindingState.ToString()));
            }

            propertyWriteAction();
        }
        
        private bool IsAccessAllowed(BindingAccess requestedAccess, BindingAccess allowedAccess)
        {
            bool accessAllowed = allowedAccess.HasFlag(requestedAccess);

            return accessAllowed;
        }
    }
}
