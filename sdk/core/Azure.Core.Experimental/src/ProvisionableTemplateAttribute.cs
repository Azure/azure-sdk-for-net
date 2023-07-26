// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Attribute used to describe a deployment template.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class ProvisionableTemplateAttribute : Attribute
    {
        /// <summary>
        /// Deployment teplate stored in resources.
        /// </summary>
        /// <param name="resourceName"></param>
        public ProvisionableTemplateAttribute(string resourceName)
            => ResourceName = resourceName;

        /// <summary>
        /// Name of assembly resource file containing a deployment template.
        /// </summary>
        public string ResourceName { get; }
    }
}
