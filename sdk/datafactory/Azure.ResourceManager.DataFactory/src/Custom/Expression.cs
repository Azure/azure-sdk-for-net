// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary>
    /// Suppresses AZC0012 on the generated <c>Expression</c> model. The
    /// spec defines the class as <c>Expression</c> and the rename to
    /// <c>DataFactoryExpression</c> via <c>@@clientName</c> requires a
    /// regeneration; until then we suppress the analyzer to keep CI green.
    /// </summary>
    [SuppressMessage("Usage", "AZC0012:Avoid type names that may collide with BCL types.")]
    public partial class Expression
    {
    }
}
