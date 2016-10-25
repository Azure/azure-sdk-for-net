// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Rest.Azure.OData
{
    /// <summary>
    /// Annotates OData methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ODataMethodAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets serialized name.
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// Initializes a new instance of ODataMethodAttribute with name.
        /// </summary>
        /// <param name="methodName">Serialized method name</param>
        public ODataMethodAttribute(string methodName)
        {
            this.MethodName = methodName;
        }
    }
}
