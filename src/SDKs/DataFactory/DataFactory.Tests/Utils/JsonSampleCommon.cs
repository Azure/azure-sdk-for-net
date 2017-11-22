// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataFactory.Tests.Utils
{
    public static class JsonSampleCommon
    {
        private const BindingFlags DefaultBindings = BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField;

        /// <summary>
        /// Gets all JSON samples (public constant strings) defined in <typeparamref name="TSampleClass"/>
        /// </summary>
        /// <typeparam name="TSampleClass">contains JSON samples as public constants.</typeparam>
        /// <returns>JSON samples to test.</returns>
        public static IEnumerable<JsonSampleInfo> GetJsonSamplesFromType<TSampleClass>()
        {
            Type sampleType = typeof(TSampleClass);
            FieldInfo[] fieldInfos = sampleType.GetFields(DefaultBindings);

            return fieldInfos.Select(fieldInfo => GetJsonSampleInfo(sampleType, fieldInfo));
        }

        /// <summary>
        /// Get a JSON sample of type <paramref name="sampleType"/> for the field <paramref name="fieldInfo"/>.
        /// </summary>
        /// <param name="sampleType">The type of the JSON sample.</param>
        /// <param name="fieldInfo">Info about the JSON sample field.</param>
        /// <returns>Info about the JSON sample.</returns>
        public static JsonSampleInfo GetJsonSampleInfo(Type sampleType, FieldInfo fieldInfo)
        {
            string sampleName = sampleType.Name + "." + fieldInfo.Name;
            string json = fieldInfo.GetRawConstantValue().ToString();

            string version = null;

            JsonSampleAttribute sampleAttribute = fieldInfo.GetCustomAttribute<JsonSampleAttribute>();
            if (sampleAttribute != null)
            {
                version = sampleAttribute.Version;
            }

            return new JsonSampleInfo(sampleName, json, version);
        }
    }
}
