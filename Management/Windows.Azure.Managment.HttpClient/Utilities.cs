using System;

namespace Windows.Azure.Management
{
    static class Validation
    {
        internal static void NotNull(object arg, String argName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

        internal static void ValidateStringArg(String arg, String argName, int maxLen = 0, bool allowNull = false)
        {
            if(String.IsNullOrEmpty(arg)) 
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
                throw new ArgumentException(String.Format(Resources.ArgStringTooLong, argName, maxLen), argName);
            }
        }

        internal static void ValidateLabel(String label, bool allowNull = false)
        {
            ValidateStringArg(label, "label", AzureConstants.LabelMax, allowNull);
        }

        internal static void ValidateDescription(String description)
        {
            //description is allowed to be null...
            ValidateStringArg(description, "description", AzureConstants.DescriptionMax, true);
        }

        internal static void ValidateLocationOrAffinityGroup(String location, String affinityGroup)
        {
            if (String.IsNullOrEmpty(location))
            {
                if (String.IsNullOrEmpty(affinityGroup))
                {
                    throw new ArgumentException(Resources.BothLocationAndAffinityGroupAreNull);
                }
            }
            else if (!String.IsNullOrEmpty(affinityGroup))
            {
                throw new ArgumentException(Resources.BothLocationAndAffinityGroupAreSet);
            }
        }

        internal static void ValidateStorageAccountName(String storageAccountName)
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
                if (o is String)
                {
                    if (!String.IsNullOrEmpty((String)o))
                        return;
                }
                else if (o != null)
                {
                    return;
                }
            }

            throw new ArgumentException(Resources.AtLeastOneThingMustBeSet);
        }
    }
}
