// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Defines methods for binding to a value.
    /// </summary>
    public interface IValueBinder : IValueProvider
    {
        /// <summary>
        /// Sets the value
        /// </summary>
        /// <param name="value">The new value to set.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A <see cref="Task"/> for the operation.</returns>
        Task SetValueAsync(object value, CancellationToken cancellationToken);
    }
}
