// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EventGrid.Models
{
    // Restore the parameterless protected constructor on this abstract polymorphic base.
    // The new generator emits only a private-protected ctor with parameters, which makes the
    // class effectively sealed (ApiCompat CannotSealType + MembersMustExist .ctor()).
    public abstract partial class AdvancedFilter
    {
        /// <summary> Initializes a new instance of <see cref="AdvancedFilter"/>. </summary>
        protected AdvancedFilter() { }
    }
}
