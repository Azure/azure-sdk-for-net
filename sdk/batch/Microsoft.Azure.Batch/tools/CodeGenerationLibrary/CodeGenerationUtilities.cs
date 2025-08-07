// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

            if(omPropertyData.IsDictionary)
            {
                // just return simple setter
                return protocolObjectSimpleGetter;
            }

            if (omPropertyData.IsTypeCollection)
            {
                return GetProtocolCollectionToObjectModelCollectionString(protocolObjectSimpleGetter, omPropertyData, protocolPropertyData);
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
                return GetObjectModelToProtocolCollectionString(propertyValueAccessor, omPropertyData, protocolPropertyData);
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
            return IsMappedEnumPair(omPropertyData?.Type, protocolPropertyData?.Type);
        }

        private static bool IsMappedEnumPair(string omPropertyName, string protocolPropertyName)
        {
            //TODO: This is super hacky, do a better way
            return omPropertyName.StartsWith("Common.") && protocolPropertyName.StartsWith("Models.");
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
                            typeString.Equals("string, string") ||
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
                            typeString.Equals("DateTime?") ||
                            typeString.Equals("object"));

            return result;
        }

        private static string GetProtocolCollectionToObjectModelCollectionString(string protocolObjectSimpleGetter, PropertyData omPropertyData, PropertyData protocolPropertyData)
        {

            if (IsMappedEnumPair(omPropertyData?.GenericTypeParameter, protocolPropertyData?.GenericTypeParameter))
            {
                string omType = StripNullable(omPropertyData.GenericTypeParameter);
                string protocolType = StripNullable(protocolPropertyData.GenericTypeParameter);

                return "UtilitiesInternal.ConvertEnumCollection<" + protocolType + ", " + omType + ">(" + protocolObjectSimpleGetter + ")";
            }

            if (IsTypeComplex(omPropertyData.GenericTypeParameter))
            {
                if (omPropertyData.HasPublicSetter)
                {
                    if (omPropertyData.BoundAccess.HasFlag(BindingAccess.Write))
                    {
                        return omPropertyData.GenericTypeParameter +
                            ".ConvertFromProtocolCollection(" + protocolObjectSimpleGetter + ")";
                    }

                    // If the name of the type and the name of the property happen to match, we need to disambiguate
                    if(string.Equals(omPropertyData.Name, omPropertyData.GenericTypeParameter))
                    {
                        // This is a bit of a hack...
                        const string prefix = "Batch";
                        return $"{prefix}.{omPropertyData.GenericTypeParameter}.ConvertFromProtocolCollectionAndFreeze({protocolObjectSimpleGetter})";
                    }
                    else
                    {
                        return $"{omPropertyData.GenericTypeParameter}.ConvertFromProtocolCollectionAndFreeze({protocolObjectSimpleGetter})";
                    }
                }
                return omPropertyData.GenericTypeParameter + ".ConvertFromProtocolCollectionReadOnly(" + protocolObjectSimpleGetter + ")";
            }

            if (omPropertyData.HasPublicSetter)
            {
                return $"UtilitiesInternal.CollectionToThreadSafeCollection({protocolObjectSimpleGetter}, o => o)";
            }

            return "UtilitiesInternal.CreateObjectWithNullCheck(" + protocolObjectSimpleGetter + ", o => o.ToList().AsReadOnly())";
        }

        private static string GetObjectModelToProtocolCollectionString(string propertyValueAccessor, PropertyData omPropertyData, PropertyData protocolPropertyData)
        {
            if (IsMappedEnumPair(omPropertyData?.GenericTypeParameter, protocolPropertyData?.GenericTypeParameter))
            {
                string omType = StripNullable(omPropertyData.GenericTypeParameter);
                string protocolType = StripNullable(protocolPropertyData.GenericTypeParameter);
                return "UtilitiesInternal.ConvertEnumCollection<" + omType + ", " + protocolType + ">(" + propertyValueAccessor + ")";
            }

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

        private static string StripNullable(string type)
        {
            return type.Last() == '?'
                ? RemoveNullableQuestionmark(type)
                : type;
        }

    }
}
