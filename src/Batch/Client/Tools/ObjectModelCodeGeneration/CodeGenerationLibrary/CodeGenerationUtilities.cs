// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace CodeGenerationLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CodeGenerationUtilities
    {
        public static string GenerateBindingAccessString(BindingAccess access)
        {
            List<string> allowedAccesses = new List<string>();
            if (access.HasFlag(BindingAccess.Read))
            {
                allowedAccesses.Add("BindingAccess.Read");
            }

            if (access.HasFlag(BindingAccess.Write))
            {
                allowedAccesses.Add("BindingAccess.Write");
            }

            if (!allowedAccesses.Any())
            {
                allowedAccesses.Add("BindingAccess.None");
            }

            return string.Join(" | ", allowedAccesses);
        }

        public static string GetProtocolToObjectModelString(PropertyData omPropertyData, PropertyData protocolPropertyData)
        {
            string protocolObjectSimpleGetter = "protocolObject." + GetProtocolPropertyName(omPropertyData, protocolPropertyData);

            if (omPropertyData.HasProtocolToObjectModelMethod)
            {
                return omPropertyData.ProtocolToObjectModelMethod + "(" + protocolObjectSimpleGetter + ")";
            }

            if (IsMappedEnumPair(omPropertyData, protocolPropertyData))
            {
                return GetEnumConversionString(omPropertyData, protocolPropertyData, protocolObjectSimpleGetter);
            }

            if (omPropertyData.IsTypeCollection)
            {
                return GetProtocolCollectionToObjectModelCollectionString(protocolObjectSimpleGetter, omPropertyData);
            }

            if (IsTypeComplex(omPropertyData.Type))
            {
                string readonlySuffix = (!omPropertyData.BoundAccess.HasFlag(BindingAccess.Write) ? ".Freeze()" : string.Empty);
                return "UtilitiesInternal.CreateObjectWithNullCheck(" + protocolObjectSimpleGetter + ", o => new " + omPropertyData.Type + "(o)" + readonlySuffix + ")";
            }

            return protocolObjectSimpleGetter;
        }

        public static string GetObjectModelToProtocolString(PropertyData omPropertyData, PropertyData protocolPropertyData)
        {
            string propertyValueAccessor = "this." + omPropertyData.Name;

            if (omPropertyData.HasObjectModelToProtocolMethod)
            {
                return omPropertyData.ObjectModelToProtocolMethod + "(" + propertyValueAccessor + ")";
            }

            if (IsMappedEnumPair(omPropertyData, protocolPropertyData))
            {
                return GetEnumConversionString(protocolPropertyData, omPropertyData, propertyValueAccessor);
            }

            if (omPropertyData.IsTypeCollection)
            {
                return GetObjectModelToProtocolCollectionString(propertyValueAccessor, omPropertyData);
            }

            if (IsTypeComplex(omPropertyData.Type))
            {
                return "UtilitiesInternal.CreateObjectWithNullCheck(" + propertyValueAccessor + ", (o) => o.GetTransportObject())";
            }

            return propertyValueAccessor;
        }

        /// <summary>
        /// Given two <see cref="PropertyData"/> objects, determines if they are a "paired" enum.  That is, if one of them is a "Models" enumeration and
        /// the other of them is a "Common" enum.
        /// </summary>
        /// <returns>True if the two properties are a "paired" enum, false otherwise</returns>
        public static bool IsMappedEnumPair(PropertyData omPropertyData, PropertyData protocolPropertyData)
        {
            //TODO: This is super hacky, do a better way
            return (omPropertyData.Type.StartsWith("Common.") && protocolPropertyData.Type.StartsWith("Models."));
        }

        public static string GetProtocolPropertyName(PropertyData omPropertyData, PropertyData protocolPropertyData)
        {
            if (protocolPropertyData == null)
            {
                return omPropertyData.Name;
            }
            else
            {
                return protocolPropertyData.Name;
            }
        }

        private static string RemoveNullableQuestionmark(string type)
        {
            return type.Substring(0, type.Length - 1);
        }

        /// <summary>
        /// Gets if the type is complex
        /// </summary>
        /// <param name="typeString">The string of the type</param>
        /// <returns>True if the type is complex, false otherwise.</returns>
        //TODO: Kinda hacky
        public static bool IsTypeComplex(string typeString)
        {
            bool result = !(typeString.Equals("string") ||
                            typeString.Equals("bool") ||
                            typeString.Equals("bool?") ||
                            typeString.Equals("int") ||
                            typeString.Equals("int?") ||
                            typeString.Equals("long") ||
                            typeString.Equals("long?") ||
                            typeString.Equals("double") ||
                            typeString.Equals("double?") ||
                            typeString.Equals("TimeSpan") ||
                            typeString.Equals("TimeSpan?") ||
                            typeString.Equals("DateTime") ||
                            typeString.Equals("DateTime?"));

            return result;
        }

        private static string GetProtocolCollectionToObjectModelCollectionString(string protocolObjectSimpleGetter, PropertyData omPropertyData)
        {
            if (IsTypeComplex(omPropertyData.GenericTypeParameter))
            {
                if (omPropertyData.HasPublicSetter)
                {
                    if (omPropertyData.BoundAccess.HasFlag(BindingAccess.Write))
                    {
                        return omPropertyData.GenericTypeParameter +
                            ".ConvertFromProtocolCollection(" + protocolObjectSimpleGetter + ")";
                    }
                    return omPropertyData.GenericTypeParameter + ".ConvertFromProtocolCollectionAndFreeze(" +
                        protocolObjectSimpleGetter + ")";
                }
                return omPropertyData.GenericTypeParameter + ".ConvertFromProtocolCollectionReadOnly(" + protocolObjectSimpleGetter + ")";
            }

            if (omPropertyData.HasPublicSetter)
            {
                throw new InvalidOperationException("Collection types of non-complex objects that are publically settable are not supported by the code generator");
            }

            return "UtilitiesInternal.CreateObjectWithNullCheck(" + protocolObjectSimpleGetter + ", o => o.ToList().AsReadOnly())";
        }

        private static string GetObjectModelToProtocolCollectionString(string propertyValueAccessor, PropertyData omPropertyData)
        {
            if (IsTypeComplex(omPropertyData.GenericTypeParameter))
            {
                return "UtilitiesInternal.ConvertToProtocolCollection(" + propertyValueAccessor + ")";
            }

            if (omPropertyData.HasPublicSetter)
            {
                return propertyValueAccessor; //Basic assignment is okay for this case
            }

            return "UtilitiesInternal.CreateObjectWithNullCheck(" + propertyValueAccessor + ", o => o.ToList())";
        }

        private static string GetEnumConversionString(PropertyData lhsEnum, PropertyData rhsEnum, string rhsGetter)
        {
            bool isLhsNullable = lhsEnum.IsTypeNullable;
            bool isRhsNullable = rhsEnum.IsTypeNullable;

            if (isLhsNullable && isRhsNullable)
            {
                string lhsNonNullableType = RemoveNullableQuestionmark(lhsEnum.Type);
                string rhsNonNullableType = RemoveNullableQuestionmark(rhsEnum.Type);

                return string.Format("UtilitiesInternal.MapNullableEnum<{0}, {1}>({2})", rhsNonNullableType, lhsNonNullableType, rhsGetter);
            }
            else if (!isLhsNullable && isRhsNullable)
            {
                throw new InvalidOperationException("Nullable enum to non-nullable enum mapping not supported");
            }
            else if (isLhsNullable && !isRhsNullable)
            {
                string lhsNonNullableType = RemoveNullableQuestionmark(lhsEnum.Type);
                return string.Format("UtilitiesInternal.MapEnum<{0}, {1}>({2})", rhsEnum.Type, lhsNonNullableType, rhsGetter);
            }
            else
            {
                return string.Format("UtilitiesInternal.MapEnum<{0}, {1}>({2})", rhsEnum.Type, lhsEnum.Type, rhsGetter);
            }
        }

    }
}
