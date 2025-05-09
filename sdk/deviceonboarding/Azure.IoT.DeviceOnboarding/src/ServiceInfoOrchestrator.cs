// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;
using Microsoft.VisualBasic;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Service Info Orchestrator
    /// </summary>
    internal class ServiceInfoOrchestrator
    {
        #region Private variables

        /// <summary>
        /// Queue to manage outgoing ServiceInfo
        /// </summary>
        private Queue<ServiceInfoKeyValuePair> _outgoingDeviceServiceInfo;

        /// <summary>
        /// Queue to manage processed ServiceInfo
        /// </summary>
        private Queue<ServiceInfoKeyValuePair> _processedDeviceServiceInfo;

        /// <summary>
        /// Registered Service Info Modules
        /// </summary>
        private Dictionary<string, BaseServiceInfoModuleDevice> _registeredModules;

        /// <summary>
        /// Service Info Exchange Initialization Modules
        /// </summary>
        private List<BaseServiceInfoModuleDevice> _firstModules;

        /// <summary>
        /// Max Service Info Message Size
        /// </summary>
        private int _maxServiceInfoSize;

        /// <summary>
        /// Key to activate a module
        /// </summary>
        private readonly string _activateModuleKey = "active";

        /// <summary>
        /// Service Info Key Delimiter
        /// </summary>
        public const char ServiceInfoKeyDelimiter = ':';

        /// <summary>
        /// Consumer provided implementation for CBOR conversion
        /// </summary>
        private CBORConverterProvider _CBORConverterProvider;

        #endregion

        #region Constructor

        /// <summary>
        /// C'tor for <see cref="ServiceInfoOrchestrator"/>
        /// </summary>
        public ServiceInfoOrchestrator(int serviceInfoSize, Dictionary<string, BaseServiceInfoModuleDevice> registeredModules,CBORConverterProvider cborConverter)
        {
            InitializeRegisteredModules(registeredModules);
            _maxServiceInfoSize = serviceInfoSize;
            _CBORConverterProvider = cborConverter;
            _outgoingDeviceServiceInfo = new Queue<ServiceInfoKeyValuePair>();
            _processedDeviceServiceInfo = new Queue<ServiceInfoKeyValuePair>();
        }

        #endregion

        #region Private and Internal Methods

        /// <summary>
        /// Get the List of all registered Service Info Modules
        /// </summary>
        private void InitializeRegisteredModules(Dictionary<string, BaseServiceInfoModuleDevice> registeredModules)
        {
            _registeredModules = registeredModules;
            _firstModules = _registeredModules.Values.Where(i => i.IsFirstModule == true).ToList();
        }

        /// <summary>
        /// Generate First Devmod Message
        /// </summary>
        /// <returns></returns>
        internal TO2DeviceServiceInfo GenerateFirstServiceInfoMessage()
        {
            if (_firstModules == null || _firstModules.Count == 0)
            {
                throw new Exception("No Registered Initialization Modules found for Service Info.");
            }

                foreach (var module in _firstModules)
                {
                    var outgoingSI = module.GenerateModulesFirstServiceInfo();
                    if (outgoingSI != null)
                    {
                        foreach (var outgoingInfo in outgoingSI)
                        {
                            _outgoingDeviceServiceInfo.Enqueue(outgoingInfo);
                        }
                    }
                }
                var serviceInfo = ConstructServiceInfo();
                if (serviceInfo == null)
                {
                    var msg = "First ServiceInfo cannot be null.";
                    throw new InvalidOperationException(msg);
                }
                return serviceInfo;
        }

        /// <summary>
        /// Process Owner Service Info Messages
        /// </summary>
        /// <param name="ownerServiceInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        internal TO2DeviceServiceInfo ProcessServiceInfoMessage(TO2OwnerServiceInfo ownerServiceInfo)
        {
            TO2DeviceServiceInfo deviceServiceInfo = new();

            // Possible Cases
            // 1. Owner send SI and ismore is false, the device will process and send SI
            // 2. Owner sends SI and ismore is true, the device will process SI and save in queue
            // 3. Onwer lets the device send SI, the device will send from queue
            foreach (var serviceInfo in ownerServiceInfo.ServiceInfo)
            {
                var serviceInfoKey = serviceInfo.Key;
                var info = serviceInfoKey.Split(ServiceInfoKeyDelimiter);
                string moduleName = info[0];
                string keyType = info[1];
                if (!_registeredModules.TryGetValue(moduleName, out BaseServiceInfoModuleDevice value))
                {
                    throw new Exception($"Module requested in Owner Service Info {moduleName} is not registered on the device.");
                }

                var module = value;
                if (!module.IsActive && !keyType.Equals(_activateModuleKey))
                {
                    throw new Exception($"Requested module {moduleName} is not activated, cannot process ServiceInfo.");
                }

                var outgoingSI = module.ProcessRequest(serviceInfo);
                if (outgoingSI != null)
                {
                    foreach (var outgoingInfo in outgoingSI)
                    {
                        _outgoingDeviceServiceInfo.Enqueue(outgoingInfo);
                    }
                }
            }

            if (ownerServiceInfo.IsMoreServiceInfo)
            {
                // Process the service info and save in queue
                deviceServiceInfo.IsMoreServiceInfo = false; // This should be false
                deviceServiceInfo.ServiceInfo = new ServiceInfo(); // This should be an empty array
            }
            else
            {
                deviceServiceInfo = ConstructServiceInfo();
            }
            return deviceServiceInfo;
        }

        /// <summary>
        /// Construct Device Service Info message based on ServiceInfo Message size
        /// </summary>
        /// <returns>To2DeviceServiceInfo</returns>
        private TO2DeviceServiceInfo ConstructServiceInfo()
        {
            if (_outgoingDeviceServiceInfo != null && _outgoingDeviceServiceInfo.Count > 0)
            {
                TO2DeviceServiceInfo deviceServiceInfo = new()
                {
                    IsMoreServiceInfo = true,
                    ServiceInfo = new ServiceInfo()
                };
                var to2ServiceInfoBytes = _CBORConverterProvider.Serialize(deviceServiceInfo);
                var size = to2ServiceInfoBytes.Length;
                var newSize = size;

                while (size < _maxServiceInfoSize && _outgoingDeviceServiceInfo != null && _outgoingDeviceServiceInfo.Count > 0)
                {
                    var svcInfo = _outgoingDeviceServiceInfo.Peek();
                    var svcInfoPair = new ServiceInfoKeyValuePair
                    {
                        Key = svcInfo.Key,
                        Value = svcInfo.Value,
                    };

                    var svcInfoPairBytes = _CBORConverterProvider.Serialize(svcInfoPair);
                    if (svcInfoPairBytes.Length + size > _maxServiceInfoSize)
                    {
                        throw new Exception("ServiceInfo cannot fit into single message.");
                    }

                    newSize += svcInfoPairBytes.Length;
                    if (newSize < _maxServiceInfoSize)
                    {
                        _ = deviceServiceInfo.ServiceInfo.AddLast(svcInfoPair);
                        _outgoingDeviceServiceInfo.Dequeue();
                        _processedDeviceServiceInfo.Enqueue(svcInfoPair);
                    }
                    else
                    {
                        break;
                    }
                }

                if (_outgoingDeviceServiceInfo.Count < 1)
                {
                    deviceServiceInfo.IsMoreServiceInfo = false;
                }
                return deviceServiceInfo;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
