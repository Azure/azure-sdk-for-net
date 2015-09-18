//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public partial class DataFactoryManagementClient
    {
        #region Converters

        internal static readonly GenericRegisteredTypeConverter<Compression> CompressionConverter;
        internal static readonly GenericRegisteredTypeConverter<CopyLocation> CopyLocationConverter;
        internal static readonly GenericRegisteredTypeConverter<CopyTranslator> CopyTranslatorConverter;
        internal static readonly GenericRegisteredTypeConverter<PartitionValue> PartitionValueConverter;
        internal static readonly GenericRegisteredTypeConverter<StorageFormat> StorageFormatConverter;

        #endregion

        static DataFactoryManagementClient()
        {
            StorageFormatConverter = new GenericRegisteredTypeConverter<StorageFormat>();
            PartitionValueConverter = new GenericRegisteredTypeConverter<PartitionValue>();
            CopyLocationConverter = new GenericRegisteredTypeConverter<CopyLocation>();
            CopyTranslatorConverter = new GenericRegisteredTypeConverter<CopyTranslator>();
            CompressionConverter = new GenericRegisteredTypeConverter<Compression>();
        }

        public void RegisterType<T>(bool force = false) where T : TypeProperties
        {
            Type type = typeof(T);

            if (typeof(LinkedServiceTypeProperties).IsAssignableFrom(type))
            {
                ((LinkedServiceOperations)this.LinkedServices).RegisterType<T>(force);
            }
            else if (typeof(DatasetTypeProperties).IsAssignableFrom(type))
            {
                ((DatasetOperations)this.Datasets).RegisterType<T>(force);
            }
            else if (typeof(ActivityTypeProperties).IsAssignableFrom(type))
            {
                ((PipelineOperations)this.Pipelines).RegisterType<T>(force);
            } 
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void RegisterInternalType<T>(bool force = false) where T : Registration.Models.IRegisteredType
        {
            Type type = typeof(T);

            if (typeof(StorageFormat).IsAssignableFrom(type))
            {
                StorageFormatConverter.RegisterType<T>(force);
            }
            else if (typeof(PartitionValue).IsAssignableFrom(type))
            {
                PartitionValueConverter.RegisterType<T>(force);
            }
            else if (typeof(CopyLocation).IsAssignableFrom(type))
            {
                CopyLocationConverter.RegisterType<T>(force);
            }
            else if (typeof(CopyTranslator).IsAssignableFrom(type))
            {
                CopyTranslatorConverter.RegisterType<T>(force);
            }
            else if (typeof(Compression).IsAssignableFrom(type))
            {
                CompressionConverter.RegisterType<T>(force);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool TypeIsRegistered<T>() where T : Registration.Models.IRegisteredType
        {
            Type type = typeof(T);

            if (typeof(LinkedServiceTypeProperties).IsAssignableFrom(type))
            {
                return ((LinkedServiceOperations)this.LinkedServices).TypeIsRegistered<T>();
            }

            if (typeof(DatasetTypeProperties).IsAssignableFrom(type))
            {
                return ((DatasetOperations)this.Datasets).TypeIsRegistered<T>();
            }

            if (typeof(ActivityTypeProperties).IsAssignableFrom(type))
            {
                return ((PipelineOperations)this.Pipelines).TypeIsRegistered<T>();
            }

            if (typeof(StorageFormat).IsAssignableFrom(type))
            {
                return StorageFormatConverter.TypeIsRegistered<T>();
            }
            
            if (typeof(PartitionValue).IsAssignableFrom(type))
            {
                return PartitionValueConverter.TypeIsRegistered<T>();
            }
            
            if (typeof(CopyLocation).IsAssignableFrom(type))
            {
                return CopyLocationConverter.TypeIsRegistered<T>();
            }
            
            if (typeof(CopyTranslator).IsAssignableFrom(type))
            {
                return CopyTranslatorConverter.TypeIsRegistered<T>();
            }
            
            if (typeof(Compression).IsAssignableFrom(type))
            {
                return CompressionConverter.TypeIsRegistered<T>();
            }

            return false;
        }
    }
}
