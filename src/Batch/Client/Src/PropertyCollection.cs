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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A collection of properties.
    /// </summary>
    internal abstract class PropertyCollection : IPropertyMetadata
    {
        private readonly IList<IPropertyMetadata> propertyMetadata;
        private readonly PropertyAccessController propertyAccessController;

        private bool isReadOnly;

        /// <summary>
        /// Creates a new instance of a <see cref="PropertyCollection"/>.
        /// </summary>
        /// <param name="bindingState">The binding state for the collection.</param>
        protected PropertyCollection(BindingState bindingState)
        {
            this.propertyMetadata = new List<IPropertyMetadata>();
            this.propertyAccessController = new PropertyAccessController(bindingState);
            this.isReadOnly = false;
        }

        /// <summary>
        /// Gets if any properties in the collection have been modified.
        /// </summary>
        public bool HasBeenModified
        {
            get
            {
                bool hasChanged = this.propertyMetadata.Any(p => p.HasBeenModified);

                return hasChanged;
            }
        }

        /// <summary>
        /// Gets or sets the readonlyness of this collection and all of it's properties.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return this.isReadOnly;
            }

            set
            {
                this.isReadOnly = value;
                foreach (IPropertyMetadata metadata in this.propertyMetadata)
                {
                    metadata.IsReadOnly = value;
                }
            }
        }
        
        internal BindingState BindingState
        {
            get { return this.propertyAccessController.BindingState; }
        }

        #region Property creation helpers

        /// <summary>
        /// Creates a <see cref="PropertyAccessor{T}"/> included in this <see cref="PropertyCollection"/>.
        /// </summary>
        /// <typeparam name="T">The type of the underlying property.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="allowedAccess">The allowed access of the <see cref="PropertyAccessor{T}"/>.</param>
        /// <returns>A <see cref="PropertyAccessor{T}"/> included in this <see cref="PropertyCollection"/>.</returns>
        internal PropertyAccessor<T> CreatePropertyAccessor<T>(string propertyName, BindingAccess allowedAccess)
        {
            var result = new PropertyAccessor<T>(this.propertyAccessController, propertyName, allowedAccess);

            this.propertyMetadata.Add(result);

            return result;
        }

        /// <summary>
        /// Creates a <see cref="PropertyAccessor{T}"/> included in this <see cref="PropertyCollection"/>.
        /// </summary>
        /// <typeparam name="T">The type of the underlying property.</typeparam>
        /// <param name="value">The initial value of the underlying property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="allowedAccess">The allowed access of the <see cref="PropertyAccessor{T}"/>.</param>
        /// <returns>A <see cref="PropertyAccessor{T}"/> included in this <see cref="PropertyCollection"/>.</returns>
        internal PropertyAccessor<T> CreatePropertyAccessor<T>(T value, string propertyName, BindingAccess allowedAccess)
        {
            var result = new PropertyAccessor<T>(value, this.propertyAccessController, propertyName, allowedAccess);

            this.propertyMetadata.Add(result);

            return result;
        }

        #endregion
    }

}
