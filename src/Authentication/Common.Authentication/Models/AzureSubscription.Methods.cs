// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Common.Authentication.Utilities;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public partial class AzureSubscription
    {
        public AzureSubscription()
        {
            Properties = new Dictionary<Property, string>();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public string GetProperty(Property property)
        {
            return Properties.GetProperty(property);
        }

        public string[] GetPropertyAsArray(Property property)
        {
            return Properties.GetPropertyAsArray(property);
        }

        public void SetProperty(Property property, params string[] values)
        {
            Properties.SetProperty(property, values);
        }

        public void SetOrAppendProperty(Property property, params string[] values)
        {
            Properties.SetOrAppendProperty(property, values);
        }

        public bool IsPropertySet(Property property)
        {
            return Properties.IsPropertySet(property);
        }

        public override bool Equals(object obj)
        {
            var anotherSubscription = obj as AzureSubscription;
            if (anotherSubscription == null)
            {
                return false;
            }
            else
            {
                return anotherSubscription.Id == Id;
            }
        }
    }
}
