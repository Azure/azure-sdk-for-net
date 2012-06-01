// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Data.Services.Client;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents a Collection of AccessPolicies.
    /// </summary>
    public class AccessPolicyCollection : BaseCloudCollection<IAccessPolicy>
    {
        internal const string AccessPolicySet = "AccessPolicies";
        internal AccessPolicyCollection(DataServiceContext dataContext)
            : base(dataContext, dataContext.CreateQuery<AccessPolicyData>(AccessPolicySet))
        {
        }

        /// <summary>
        /// Deletes an access policy
        /// </summary>
        /// <param name="accessPolicy"></param>
        public void Delete(IAccessPolicy accessPolicy)
        {
            VerifyAccessPolicy(accessPolicy);
            DataContext.DeleteObject(accessPolicy);
            DataContext.SaveChanges();
        }
        
        internal static void VerifyAccessPolicy(IAccessPolicy accessPolicy)
        {
            if (!(accessPolicy is AccessPolicyData))
            {
                throw new ArgumentException(StringTable.ErrorInvalidAccessPolicyType, "accessPolicy");
            }
        }

        /// <summary>
        /// Creates an AccessPolicy with the provided name and permissions, valid for the provided duration.
        /// </summary>
        /// <param name="name">Specifies a friendly name for the AccessPolicy.</param>
        /// <param name="duration">Specifies the duration that locators created from this AccessPolicy will be valid for.</param>
        /// <param name="permissions">Specifies permissions for the created AccessPolicy.</param>
        /// <returns>A AccessPolicy with the provided <paramref name="name"/>, <paramref name="duration"/> and <paramref name="permissions"/>.</returns>              
        public IAccessPolicy Create(string name, TimeSpan duration, AccessPermissions permissions)
        {
            AccessPolicyData accessPolicy = new AccessPolicyData();
            accessPolicy.Name = name;
            accessPolicy.DurationInMinutes = AccessPolicyData.GetInternalDuration(duration);
            accessPolicy.Permissions = AccessPolicyData.GetInternalPermissions(permissions);
            DataContext.AddObject(AccessPolicySet, accessPolicy);
            DataContext.SaveChanges();

            return accessPolicy;
        }
    }
}
