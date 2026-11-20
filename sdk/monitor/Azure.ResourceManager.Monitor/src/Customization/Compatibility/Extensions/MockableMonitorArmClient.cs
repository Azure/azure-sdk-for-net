// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This file intentionally exposes obsolete removed-type compatibility signatures.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorArmClient
    {
        /// <summary> Gets an object representing an <see cref="AlertRuleResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns an <see cref="AlertRuleResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AlertRuleResource GetAlertRuleResource(ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");
    }
}
