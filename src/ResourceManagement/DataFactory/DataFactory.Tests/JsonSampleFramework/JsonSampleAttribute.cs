//==============================================================================
// Copyright (c) Microsoft Corporation. All Rights Reserved.
//==============================================================================

using System;
using System.Collections.Generic;
using Microsoft.DataPipeline.Metadata.JsonHelpers;
using Microsoft.DataPipeline.Metadata.ObjectModel;

namespace Microsoft.DataPipeline.TestFramework.JsonSamples
{
    /// <summary>
    /// Contains JSON sample metadata used by test automation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonSampleAttribute : Attribute
    {
        /// <summary>
        /// Paths of property names that are user-specified. That is, in the OM they are a keys in a property bag dictionary and not
        /// first-class citizens of the object model. Such properties should always be represented with the exact
        /// casing specified by the user. Unlike first-class object model properties, the des/ser process should not convert them to camel/Pascal case.
        /// </summary>
        public HashSet<string> PropertyBagKeys
        {
            get;
            private set;
        }

        public string Version
        {
            get;
            private set;
        }

        /// <summary>
        /// The test types to use this sample for. 
        /// </summary>
        public JsonSampleType SampleType { get; set; }

        public JsonSampleAttribute(JsonSampleType sampleType = JsonSampleType.Both)
        {
            this.SampleType = sampleType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version">
        /// Json Payload may be only effect to some version of API, test should be able to specify which API version to be used.
        /// </param>
        public JsonSampleAttribute(string version) 
            : this()
        {
            if (!string.IsNullOrEmpty(version))
            {
                this.Version = version;
            }
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyBagKeys">
        /// Paths of property names that are user-specified. That is, in the OM they are a keys in a property bag dictionary and not
        /// first-class citizens of the object model. Such properties should always be represented with the exact
        /// casing specified by the user. Unlike first-class object model properties, the des/ser process should not convert them to camel/Pascal case.
        /// </param>
        public JsonSampleAttribute(params string[] propertyBagKeys) 
            : this()
        {
            this.PropertyBagKeys = new HashSet<string>(JsonUtilities.PropertyNameComparer);

            if (propertyBagKeys != null)
            {
                this.PropertyBagKeys.AddRange(propertyBagKeys);
            }
        }
    }
}
