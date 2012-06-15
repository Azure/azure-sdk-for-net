//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the Validation class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.ManagementClient
{
    static class Validation
    {
        internal static void NotNull(object arg, string argName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

        internal static void ValidateStringArg(string arg, string argName, int maxLen = 0, bool allowNull = false)
        {
            if(string.IsNullOrEmpty(arg)) 
            {
                if (allowNull)
                {
                    return;
                }
                else
                {
                    throw new ArgumentNullException(argName);
                }
            }

            if (maxLen > 0 && arg.Length > maxLen)
            {
                throw new ArgumentException(string.Format(Resources.ArgStringTooLong, argName, maxLen), argName);
            }
        }

        internal static void ValidateLabel(string label, bool allowNull = false)
        {
            ValidateStringArg(label, "label", AzureConstants.LabelMax, allowNull);
        }

        internal static void ValidateDescription(string description)
        {
            //description is allowed to be null...
            ValidateStringArg(description, "description", AzureConstants.DescriptionMax, true);
        }

        internal static void ValidateLocationOrAffinityGroup(string location, string affinityGroup)
        {
            if (string.IsNullOrEmpty(location))
            {
                if (string.IsNullOrEmpty(affinityGroup))
                {
                    throw new ArgumentException(Resources.BothLocationAndAffinityGroupAreNull);
                }
            }
            else if (!string.IsNullOrEmpty(affinityGroup))
            {
                throw new ArgumentException(Resources.BothLocationAndAffinityGroupAreSet);
            }
        }

        internal static void ValidateStorageAccountName(string storageAccountName)
        {
            //rules here are between 3 and 24 chars in length, all numbers or lowercase
            //letters
            ValidateStringArg(storageAccountName, "storageAccountName");

            if (storageAccountName.Length < AzureConstants.StorageAccountNameMin || storageAccountName.Length > AzureConstants.StorageAccountNameMax)
                throw new ArgumentException(Resources.StorageAccountNameProblem, "storageAccountName");

            foreach (char c in storageAccountName)
            {
                if (!char.IsLower(c) && !char.IsDigit(c))
                    throw new ArgumentException(Resources.StorageAccountNameProblem, "storageAccountName");
            }
        }

        internal static void ValidateAllNotNull(params object[] parameters)
        {
            //if anything is not null we are fine, just can't all be null.
            foreach (object o in parameters)
            {
                if (o is string)
                {
                    if (!string.IsNullOrEmpty((string)o))
                        return;
                }
                else if (o != null)
                {
                    return;
                }
            }

            throw new ArgumentException(Resources.AtLeastOneThingMustBeSet);
        }

        internal static void ValidateExtendedProperties(IDictionary<string, string> properties)
        {
            //extended properties are allowed to be null
            if (properties != null)
            {
                foreach (var kvp in properties)
                {
                    ValidateExtendedPropertyName(kvp.Key);

                    if (kvp.Value.Length > AzureConstants.ExtPropValMax)
                        throw new ArgumentException(string.Format(Resources.ExtendedPropertyValueTooLong, kvp.Value));
                }
            }
        }

        //64 chars or less, looks like this [A-Za-z][A-Za-z0-9_]*
        private static void ValidateExtendedPropertyName(string name)
        {
            if (name.Length > AzureConstants.ExtPropKeyMax)
                throw new ArgumentException(string.Format(Resources.ExtendedPropertyKeyTooLong, name));

            Regex regex = new Regex("^[A-Za-z][A-Za-z0-9_]*$");

            if (!regex.IsMatch(name))
            {
                throw new ArgumentException(string.Format(Resources.ExtendedPropertyKeyInvalid, name));
            }
        }
    }
}
