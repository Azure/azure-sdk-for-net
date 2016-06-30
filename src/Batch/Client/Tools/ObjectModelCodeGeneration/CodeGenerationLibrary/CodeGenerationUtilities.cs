namespace CodeGenerationLibrary
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
                return "UtilitiesInternal.MapNullableEnum<" + lhsNonNullableType + ">(" + rhsGetter + ")";
            }
            else if (!isLhsNullable && isRhsNullable)
            {
                return "UtilitiesInternal.MapNullableEnumToNonNullableEnum<" + lhsEnum.Type + ">(" + rhsGetter + ")";
            }
            else if (isLhsNullable && !isRhsNullable)
            {
                string lhsNonNullableType = RemoveNullableQuestionmark(lhsEnum.Type);
                return "UtilitiesInternal.MapEnum<" + lhsNonNullableType + ">(" + rhsGetter + ")";
            }
            else
            {
                return "UtilitiesInternal.MapEnum<" + lhsEnum.Type + ">(" + rhsGetter + ")";
            }
        }

    }
}
