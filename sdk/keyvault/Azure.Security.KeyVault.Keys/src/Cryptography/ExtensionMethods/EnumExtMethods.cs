// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Keys.Cryptography.ExtensionMethods
{
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtMethods
    {
        #region public functions
        /// <summary>
        /// Get Attribute info for enum
        /// </summary>
        /// <typeparam name="TRet">Return type for delegate</typeparam>
        /// <typeparam name="TAttrib">Type for attribute you are interested in</typeparam>
        /// <param name="enumField">Enum member</param>
        /// <param name="TAttribDelegate">Delegate to be executed on the retrieved attribute</param>
        /// <returns></returns>
        public static TRet GetAttributeInfoForEnum<TRet, TAttrib>(this Enum enumField, Func<TAttrib, TRet> TAttribDelegate)
                                                                                            where TRet : class
                                                                                            where TAttrib : Attribute
        {
            TAttrib attrib = GetAttributeForField<Enum, TAttrib>(enumField);
            TRet returnValue = TAttribDelegate(attrib);
            return returnValue;
        }

        /// <summary>
        /// Get Description attribute value
        /// </summary>
        /// <param name="fieldInstance"></param>
        /// <returns></returns>
        public static string GetDescriptionAttributeValue(this Enum fieldInstance)
        {
            DescriptionAttribute descAttrib = GetAttributeForField<Enum, DescriptionAttribute>(fieldInstance);
            return descAttrib.Description;
        }

        #endregion

        #region private functions
        private static TAttrib GetAttributeForField<TField, TAttrib>(TField fieldInstance) where TField : class
                                                                                where TAttrib : Attribute
        {
            MemberInfo mi = fieldInstance.GetType().GetField(fieldInstance.ToString());
            TAttrib attrib = Attribute.GetCustomAttribute(mi, typeof(TAttrib)) as TAttrib;
            return attrib;
        }
        #endregion
    }
}
