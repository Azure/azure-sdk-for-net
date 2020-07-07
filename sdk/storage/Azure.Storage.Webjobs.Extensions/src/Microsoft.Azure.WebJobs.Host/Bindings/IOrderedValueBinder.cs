// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Defines an <see cref="IValueBinder"/> that provides an ordering hint./>
    /// </summary>
    public interface IOrderedValueBinder : IValueBinder
    {
        /// <summary>
        /// Gets the bind order for the binder.
        /// </summary>
        BindStepOrder StepOrder { get; }
    }
}
