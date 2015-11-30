// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    /// <summary>
    ///     The main service locator for any application.
    /// </summary>
    internal class ServiceLocator : IServiceLocator
    {
        private static ServiceLocator singletonInstance = new ServiceLocator();
        private readonly Dictionary<Type, object> runtimeServices = new Dictionary<Type, object>();
        private readonly Dictionary<Type, object> testRunServices = new Dictionary<Type, object>();
        private Dictionary<Type, object> individualTestServices = new Dictionary<Type, object>();
        private ServiceLocationMockingLevel mockingLevel = ServiceLocationMockingLevel.ApplyFullMocking;
        private readonly IServiceLocationAssemblySweep sweeper = new ServiceLocationAssemblySweep();
        private ServiceLocationRuntimeManager runtimeManager;

        /// <summary>
        ///     Gets the singleton instance of the ServiceLocator.
        /// </summary>
        public static IServiceLocator Instance
        {
            get
            {
                return singletonInstance;
            }
        }

        /// <summary>
        ///     Prevents a default instance of the ServiceLocator class from being created.
        /// </summary>
        private ServiceLocator()
        {
            this.sweeper.RegisterRegistrarProxy<IServiceLocationRegistrar>(new ServiceLocationRegistrarProxyFactory());
            this.runtimeManager = new ServiceLocationRuntimeManager(this);
            this.runtimeServices.Add(typeof(IServiceLocationRuntimeManager), this.runtimeManager);
            this.runtimeServices.Add(typeof(IServiceLocationSimulationManager), new ServiceLocationSimulationManager(this));
            this.runtimeServices.Add(typeof(IServiceLocationIndividualTestManager), new ServiceLocationIndividualTestManager(this));
            this.runtimeServices.Add(typeof(IServiceLocationAssemblySweep), this.sweeper);
            this.runtimeServices.Add(typeof(IServiceLocator), this);
            this.RegisterAssemblies();
        }

        private void RegisterAssemblies()
        {
            var registrars = this.sweeper.GetRegistrars().ToList();
            foreach (var serviceLocationRegistrar in registrars)
            {
                serviceLocationRegistrar.Register(this.runtimeManager, this);
            }
        }

        internal static void ThrowIfNullInstance([ValidatedNotNull] Type type, [ValidatedNotNull] object implementation)
        {
            if (ReferenceEquals(type,
                                null))
            {
                string msg = string.Format(CultureInfo.InvariantCulture,
                                           "An attempt was made to register a null type as service");
                throw new InvalidOperationException(msg);
            }
            if (ReferenceEquals(implementation,
                                null))
            {
                string msg = string.Format(
                    CultureInfo.InvariantCulture,
                    "An attempt was made to register or override a service with a null implementation '{0}'",
                    type.FullName);
                throw new InvalidOperationException(msg);
            }
        }

        internal static void ThrowIfInvalidRegistration(Type type, Type implementation)
        {
            ThrowIfNullInstance(type,
                                implementation);
            if (type == typeof(IServiceLocationRuntimeManager) || type == typeof(IServiceLocationSimulationManager) ||
                type == typeof(IServiceLocationIndividualTestManager) || type == typeof(IServiceLocator))
            {
                string msg = string.Format(
                    CultureInfo.InvariantCulture,
                    "An attempt was made to register or override the restrictive service '{0}'",
                    type.FullName);
                throw new InvalidOperationException(msg);
            }
            if (!type.IsInterface)
            {
                string msg = string.Format(
                    CultureInfo.InvariantCulture,
                    "An attempt was made to register or override a service for the type '{0}' that was not an interface",
                    type.FullName);
                throw new InvalidOperationException(msg);
            }
            if (!type.IsAssignableFrom(implementation))
            {
                string msg = string.Format(
                    CultureInfo.InvariantCulture,
                    "An attempt was made to register or override the service '{0}' for the type '{1}' which was not derived from the service",
                    implementation.FullName,
                    type.FullName);
                throw new InvalidOperationException(msg);
            }
        }

        private abstract class ServiceLocationManager : IServiceLocationManager
        {
            /// <inheritdoc />
            public void RegisterInstance<TService>(TService instance)
            {
                this.RegisterInstance(typeof(TService),
                                      instance);
            }

            /// <inheritdoc />
            public abstract void RegisterInstance(Type type, object instance);

            /// <inheritdoc />
            public void RegisterType<T>(Type registrationValue)
            {
                this.RegisterType(typeof(T),
                                  registrationValue);
            }

            /// <inheritdoc />
            public void RegisterType<TInterface, TConcreate>() where TConcreate : class, TInterface
            {
                this.RegisterType(typeof(TInterface), typeof(TConcreate));
            }

            /// <inheritdoc />
            public void RegisterType(Type type, Type registrationValue)
            {
                // TODO: see if an injection is necessary here (for Service Locator)
                ThrowIfInvalidRegistration(type, registrationValue);
                object obj = Activator.CreateInstance(registrationValue);
                this.RegisterInstance(type,
                                      obj);
            }
        }

        private class InternalRuntimeRegistrationManager : ServiceLocationManager, IServiceLocationRuntimeManager
        {
            private IServiceLocator locator;

            public InternalRuntimeRegistrationManager(IServiceLocator locator)
            {
                this.locator = locator;
            }

            private readonly Dictionary<Type, object> discovered = new Dictionary<Type, object>();

            public override void RegisterInstance(Type serviceType, object instance)
            {
                var registering = instance as IRegisteringService;
                object discoveredInstance;
                if (this.discovered.TryGetValue(serviceType,
                                                out discoveredInstance))
                {
                    if (!ReferenceEquals(discoveredInstance,
                                         instance) && !ReferenceEquals(registering,
                                                                       null))
                    {
                        this.discovered[serviceType] = instance;
                        registering.Register(this, this.locator);
                    }
                }
                else
                {
                    this.discovered[serviceType] = instance;
                    if (!ReferenceEquals(registering,
                                         null))
                    {
                        registering.Register(this, this.locator);
                    }
                }
            }

            public IEnumerable<KeyValuePair<Type, object>> GetDiscovered()
            {
                return this.discovered;
            }
        }

        private class ServiceLocationRuntimeManager : ServiceLocationManager, IServiceLocationRuntimeManager
        {
            private readonly ServiceLocator locator;

            public ServiceLocationRuntimeManager(ServiceLocator locator)
            {
                this.locator = locator;
            }

            /// <inheritdoc />
            public override void RegisterInstance(Type type, object instance)
            {
                ThrowIfNullInstance(type,
                                    instance);
                ThrowIfInvalidRegistration(type,
                                           instance.GetType());
                var internalManager = new InternalRuntimeRegistrationManager(this.locator);
                internalManager.RegisterInstance(type,
                                                 instance);
                foreach (KeyValuePair<Type, object> keyValuePair in internalManager.GetDiscovered())
                {
                    this.locator.runtimeServices[keyValuePair.Key] = keyValuePair.Value;
                }
            }
        }

        private class ServiceLocationSimulationManager : ServiceLocationManager, IServiceLocationSimulationManager
        {
            private readonly ServiceLocator locator;

            public ServiceLocationSimulationManager(ServiceLocator locator)
            {
                this.locator = locator;
            }

            /// <inheritdoc />
            public override void RegisterInstance(Type type, object instance)
            {
                ThrowIfNullInstance(type,
                                    instance);
                ThrowIfInvalidRegistration(type,
                                           instance.GetType());
                this.locator.testRunServices[type] = instance;
            }

            public ServiceLocationMockingLevel MockingLevel
            {
                get { return this.locator.mockingLevel; }
                set { this.locator.mockingLevel = value; }
            }
        }

        private class ServiceLocationIndividualTestManager : IServiceLocationIndividualTestManager
        {
            private readonly ServiceLocator locator;

            public ServiceLocationIndividualTestManager(ServiceLocator locator)
            {
                this.locator = locator;
            }

            public void Override<T>(T overrideValue)
            {
                this.Override(typeof(T),
                              overrideValue);
            }

            public void Override(Type type, object overrideValue)
            {
                ThrowIfNullInstance(type,
                                    overrideValue);
                ThrowIfInvalidRegistration(type,
                                           overrideValue.GetType());
                this.locator.individualTestServices.Add(type,
                                           overrideValue);
            }

            public void Reset()
            {
                this.locator.individualTestServices = new Dictionary<Type, object>();
            }
        }

        /// <inheritdoc />
        public T Locate<T>()
        {
            return (T)this.Locate(typeof(T));
        }

        /// <inheritdoc />
        public object Locate(Type type)
        {
            var retval = this.InternalLocate(type);
            if (retval.IsNull())
            {
                if (this.sweeper.NewAssembliesPresent())
                {
                    this.RegisterAssemblies();
                    retval = this.InternalLocate(type);
                }
                if (retval.IsNull())
                {
                    string message = string.Format(CultureInfo.InvariantCulture,
                                                   "Attempt to locate a service '{0}' that has not been registered",
                                                   type.FullName);
                    throw new InvalidOperationException(message);
                }
            }
            return retval;
        }

        private object InternalLocate(Type type)
        {
            if (ReferenceEquals(type,
                                null))
            {
                throw new ArgumentNullException("type");
            }
            object runtimeVersion = null;
            object fakeVersion = null;
            object overrideVersion = null;

                // First try to get a IndiviudalTest Mock
            if (!((this.mockingLevel == ServiceLocationMockingLevel.ApplyFullMocking ||
                   this.mockingLevel == ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly) &&
                   this.individualTestServices.TryGetValue(type, out overrideVersion)) &&
                // Next try to get a TestRun Mock
                !((this.mockingLevel == ServiceLocationMockingLevel.ApplyFullMocking ||
                   this.mockingLevel == ServiceLocationMockingLevel.ApplyTestRunMockingOnly) &&
                   this.testRunServices.TryGetValue(type, out fakeVersion)) &&
                // Finally try to get the actual service
                !this.runtimeServices.TryGetValue(type, out runtimeVersion))
            {
            }
            object retval = overrideVersion;
            if (retval.IsNull())
            {
                retval = fakeVersion;
                if (retval.IsNull())
                {
                    retval = runtimeVersion;
                }
            }
            return retval;
        }
    }
}