// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System;
using System.Reflection;
using Azure.IoT.DeviceOnboarding.Models.Providers;
using Microsoft.Identity.Client;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    public class Sample_CBORConverter : CBORConverterProvider
    {
        internal static CBORTypeMapper CBORTypeMapper;

        static Sample_CBORConverter()
        {
            CBORTypeMapper = new CBORTypeMapper();
        }
        public Sample_CBORConverter()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            System.Collections.Generic.IEnumerable<Type> converterTypes = types.Where(t => t.GetCustomAttribute<CBORConverterAttribute>() != null);

            foreach (Type converterType in converterTypes)
            {
                CBORConverterAttribute attribute = converterType.GetCustomAttribute<CBORConverterAttribute>();

                object converterInstance = Activator.CreateInstance(converterType);

                MethodInfo addConverterMethod = typeof(CBORTypeMapper).GetMethod("AddConverter");
                MethodInfo genericAddConverterMethod = addConverterMethod.MakeGenericMethod(attribute.TargetType);
                _ = genericAddConverterMethod.Invoke(CBORTypeMapper, new[] { attribute.TargetType, converterInstance });
            }
        }
        public override T Deserialize<T>(byte[] bytes)
        {
            try
            {
                CBORObject obj = CBORObject.DecodeFromBytes(bytes);
                return obj.ToObject<T>(CBORTypeMapper);
            }
            catch (TargetInvocationException exp)
            {
                throw exp.InnerException;
            }
        }

        public override byte[] Serialize<T>(T content)
        {
            CBORObject response = CBORObject.FromObject(content, CBORTypeMapper);
            return response.EncodeToBytes();
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type T, for internal use only
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static T ToObject<T>(CBORObject obj)
        {
            try
            {
                return obj.ToObject<T>(CBORTypeMapper);
            }
            catch (TargetInvocationException exp)
            {
                throw exp.InnerException;
            }
        }

        /// <summary>
        /// Convert any Object to the type CBORObject, for internal use only
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static CBORObject FromObjectToCBOR(object obj)
        {
            return CBORObject.FromObject(obj, CBORTypeMapper);
        }
    }
}
