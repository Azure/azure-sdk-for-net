// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class FeatureImpl : IndexableWrapper<FeatureResultInner>,
        IFeature
    {
        internal FeatureImpl(FeatureResultInner innerModel) : base(innerModel) { }

        public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string State
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.State;
            }
        }

        public string Type
        {
            get
            {
                return Inner.Type;
            }
        }
    }
}
