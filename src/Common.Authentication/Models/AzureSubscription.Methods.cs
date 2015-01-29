// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
