// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter
{
    // The generated filter overload collides with the GA no-filter overload when IEnumerable calls GetAll().
    [CodeGenSuppress("GetAll", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(CancellationToken))]
    public partial class SecurityCenterPricingCollection
    {
    }
}
