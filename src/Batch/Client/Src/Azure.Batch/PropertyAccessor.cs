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

    [Flags]
    internal enum BindingAccess
    {
        None = 0, 
        Read = 1, 
        Write = 2
    };

    /// <summary>
    /// Controls access to an individual property of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    internal class PropertyAccessor<T> : IPropertyMetadata
    {
        private readonly PropertyAccessController propertyAccessController;
        private readonly BindingAccess allowedAccess;
        private readonly string propertyName;
        private bool valueHasChanged;
        private bool readOnly;
        private T value;

        /// <summary>
        /// Creates a new instance of <see cref="PropertyAccessor{T}"/> with the default underlying property value.
        /// </summary>
        /// <param name="propertyAccessController">The access controller to use.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="allowedAccess">The allowed access of the property.</param>
        internal PropertyAccessor(PropertyAccessController propertyAccessController, string propertyName, BindingAccess allowedAccess)
        {
            this.propertyAccessController = propertyAccessController;
            this.allowedAccess = allowedAccess;
            this.propertyName = propertyName;
        }

        /// <summary>
        /// Creates a new instance of <see cref="PropertyAccessor{T}"/> with a specific underlying property value.
        /// </summary>
        /// <param name="value">The value of the property.</param>
        /// <param name="propertyAccessController">The access controller to use.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="allowedAccess">The allowed access of the property.</param>
        internal PropertyAccessor(T value, PropertyAccessController propertyAccessController, string propertyName, BindingAccess allowedAccess)
        {
            this.propertyAccessController = propertyAccessController;
            this.allowedAccess = allowedAccess;
            this.propertyName = propertyName;

            this.value = value; //This bypasses change tracking and locking - but it's okay since we're in the constructor
        }

        /// <summary>
        /// Gets or sets the value of the underlying property.
        /// </summary>
        public T Value
        {
            get { return this.GetValue(); }
            set { this.SetValue(value); }
        }

        /// <summary>
        /// Gets if this property has been modified.
        /// </summary>
        public bool HasBeenModified
        {
            get
            {
                T localValue = this.GetValue(overrideAccessControl: true);
                IModifiable modifiable = localValue as IModifiable;
                if (modifiable != null && !this.valueHasChanged)
                {
                    return modifiable.HasBeenModified;
                }
                else
                {
                    return this.valueHasChanged;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if this <see cref="PropertyAccessor{T}"/> is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return this.readOnly;
            }

            set
            {
                this.readOnly = value;

                //Propagate the value to all children too
                IReadOnly valueAsReadOnly = this.GetValue(overrideAccessControl: true) as IReadOnly;
                if (valueAsReadOnly != null)
                {
                    valueAsReadOnly.IsReadOnly = value;
                }
            }
        }

        internal T GetValue()
        {
            return this.GetValue(overrideAccessControl: false);
        }

        internal void SetValue(T value, bool overrideReadOnly = false)
        {
            this.SetValue(value, overrideReadOnly: overrideReadOnly, overrideAccessControl: false);
        }

        private T GetValue(bool overrideAccessControl)
        {
            BindingAccess access = overrideAccessControl ? BindingAccess.Read : this.allowedAccess;
            return this.propertyAccessController.ReadProperty(() => this.value, access, this.propertyName);
        }

        private void SetValue(T value, bool overrideReadOnly, bool overrideAccessControl)
        {
            T originalValue = this.value;

            BindingAccess access = overrideAccessControl ? BindingAccess.Write : this.allowedAccess;
            this.propertyAccessController.WriteProperty(() =>
            {
                this.ThrowIfReadOnly(overrideReadOnly);
                this.value = value;
            },
            access,
            this.propertyName);

            //It makes sense to set this to true even if the value didn't change because in some cases the current client state of the property
            //doesn't actually match the real server state (for example in cases where a select clause is used). In cases like this, the client has made
            //a property assignment, and they want their property assignment to propagate to the server.
            this.valueHasChanged = true;
        }

        /// <summary>
        /// Throws an exception if this is marked readonly.
        /// </summary>
        /// <param name="overrideReadOnly">If true, this method call will not throw an exception.</param>
        private void ThrowIfReadOnly(bool overrideReadOnly)
        {
            if (overrideReadOnly)
            {
                return;
            }

            if (this.IsReadOnly)
            {
                throw new InvalidOperationException(BatchErrorMessages.GeneralObjectInInvalidState);
            }
        }
    }
}
