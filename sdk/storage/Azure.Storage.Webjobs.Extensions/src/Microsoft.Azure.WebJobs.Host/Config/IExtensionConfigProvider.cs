// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Config
{
    /// <summary>
    /// Defines an interface enabling 3rd party extensions to participate in the <see cref="JobHost"/> configuration
    /// process to register their own extension types. Any registered <see cref="IExtensionConfigProvider"/> instances
    /// registered with dependency container will be invoked at the right time during startup.
    /// </summary>
    public interface IExtensionConfigProvider
    {
        /// <summary>
        /// Initializes the extension. Initialization should register any extension bindings
        /// with the <see cref="IExtensionRegistry"/> instance, which can be obtained from the
        /// <see cref="JobHostConfiguration"/> which is an <see cref="System.IServiceProvider"/>.
        /// </summary>
        /// <param name="context">The <see cref="ExtensionConfigContext"/></param>
        void Initialize(ExtensionConfigContext context);
    }
}
