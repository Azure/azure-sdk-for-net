// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Hosting
{
    /// <summary>
    /// Attribute used to declare <see cref="IWebJobsStartup"/> and <see cref="IWebJobsConfigurationStartup"/> Types that should be registered and invoked
    /// as part of host startup.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    public class WebJobsStartupAttribute : Attribute
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="startupType">The Type of the <see cref="IWebJobsStartup"/> or <see cref="IWebJobsConfigurationStartup"/> class to register.</param>
        /// <param name="name">The friendly human readable name for the startup action. If null, the name will be
        /// defaulted based on naming convention.</param>
        public WebJobsStartupAttribute(Type startupType, string name = null)
        {
            if (startupType == null)
            {
                throw new ArgumentNullException(nameof(startupType));
            }

            if (!typeof(IWebJobsStartup).IsAssignableFrom(startupType) && !typeof(IWebJobsConfigurationStartup).IsAssignableFrom(startupType))
            {
                throw new ArgumentException($@"""{startupType}"" does not implement {typeof(IWebJobsStartup)} or {typeof(IWebJobsConfigurationStartup)}.", nameof(startupType));
            }

            if (string.IsNullOrEmpty(name))
            {
                // for a startup class named 'CustomConfigWebJobsStartup' or 'CustomConfigStartup',
                // default to a name 'CustomConfig'
                name = startupType.Name;
                int idx = name.IndexOf("WebJobsStartup");
                if (idx < 0)
                {
                    idx = name.IndexOf("Startup");
                }
                if (idx > 0)
                {
                    name = name.Substring(0, idx);
                }
            }
            WebJobsStartupType = startupType;
            Name = name;
        }

        /// <summary>
        /// Gets the Type of the <see cref="IWebJobsStartup"/> or <see cref="IWebJobsConfigurationStartup"/> class to register.
        /// </summary>
        public Type WebJobsStartupType { get; }

        /// <summary>
        /// Gets the friendly human readable name for the startup action.
        /// </summary>
        public string Name { get; }
    }
}
