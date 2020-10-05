// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ObjectComparer
    {
        private readonly IList<ComparisonRule> comparisonRules;
        private readonly IList<ComparerPropertyMapping> propertyMappings;
        private readonly Func<Exception, bool> shouldSwallowPropertyReadException;

        public ObjectComparer(
            IList<ComparisonRule> comparisonRules = null,
            IList<ComparerPropertyMapping> propertyMappings = null,
            Func<Exception, bool> shouldThrowOnPropertyReadException = null)
        {
            this.comparisonRules = comparisonRules;
            this.propertyMappings = propertyMappings ?? new List<ComparerPropertyMapping>();
            this.shouldSwallowPropertyReadException = shouldThrowOnPropertyReadException ?? (e => false);
        }

        public class CheckEqualityResult
        {
            public bool Equal { get; private set; }

            public string Message { get; private set; }

            public static readonly CheckEqualityResult True = new CheckEqualityResult(true);

            public static CheckEqualityResult False(string message)
            {
                return new CheckEqualityResult(false, message);
            }

            private CheckEqualityResult(bool equal, string message = null)
            {
                this.Equal = equal;
                this.Message = message;
            }
        }

        public CheckEqualityResult CheckEquality(object o1, object o2)
        {
            if (o1 == null && o2 == null)
            {
                return CheckEqualityResult.True;
            }
            else if (o1 == null && o2 != null)
            {
                return CheckEqualityResult.False("o1 == null but not o2");
            }
            else if (o1 != null && o2 == null)
            {
                return CheckEqualityResult.False("o2 == null but not o1");
            }

            Type o1Type = o1.GetType();
            Type o2Type = o2.GetType();

            if (o1 is Enum && o2 is Enum)
            {
                //Match enums based on an ignore-cased ToString
                bool matches = o1.ToString().Equals(o2.ToString(), StringComparison.InvariantCultureIgnoreCase);
                if (matches)
                {
                    return CheckEqualityResult.True;
                }
                else
                {
                    return CheckEqualityResult.False(string.Format("Enum {0} doesn't match {1}", o1, o2));
                }
            }
            //Check to see if the object is using "System.Object"'s default comparator
            else if (OverridesEqualsMethod(o1Type))
            {
                //Since we are not using System.Objects default equals implementation we can go ahead
                //and just call .Equals
                if (o1.Equals(o2))
                {
                    return CheckEqualityResult.True;
                }
                else
                {
                    return CheckEqualityResult.False(string.Format("Type {0}.Equals({1}) returned false", o1Type, o2Type));
                }
            }
            //Deal with collections
            else if (o1 is IEnumerable)
            {
                if (!(o2 is IEnumerable))
                {
                    return CheckEqualityResult.False("o2 was not IEnumerable");
                }

                IEnumerable o1Enumerable = (IEnumerable)o1;
                IEnumerable o2Enumerable = (IEnumerable)o2;

                return this.CompareEnumerables(o1Enumerable, o2Enumerable);
            }
            else
            {
                return this.DoesComplexTypeOneMatchTypeTwo(o1, o2);
            }
        }

        /// <summary>
        /// Compares the two types, ensuring that all properties of <paramref name="o2"/> are matched by corresponding properties of <paramref name="o1"/>.
        /// </summary>
        private CheckEqualityResult DoesComplexTypeOneMatchTypeTwo(object o1, object o2)
        {
            Type o1Type = o1.GetType();
            Type o2Type = o2.GetType();

            PropertyInfo[] o1Properties = o1Type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] o2Properties = o2Type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            List<string> o1PropertyNames = o1Properties.Select(prop => prop.Name).ToList();

            foreach (PropertyInfo o2Property in o2Properties)
            {
                object o2Value = o2Property.GetValue(o2);
                string o1PropertyName = o2Property.Name;

                //Find the corresponding o1 property if there is one
                if (!o1PropertyNames.Contains(o2Property.Name))
                {
                    string mappedPropertyName = this.GetPropertyMappingOrNull(o2Type, o2Property.Name);
                    if (!string.IsNullOrEmpty(mappedPropertyName))
                    {
                        //Property names don't match but we have a mapping which maps them
                        o1PropertyName = mappedPropertyName;
                    }
                    else
                    {
                        return CheckEqualityResult.False(string.Format("Unknown property: {0} on type {1}", o2Property.Name, o2Type));
                    }
                }

                PropertyInfo o1Property = o1Type.GetProperty(o1PropertyName);

                try
                {
                    object o1Value = o1Property.GetValue(o1);

                    ComparisonRule customComparisonRule = this.GetComparisonRuleOrNull(o1Type, o2Type, o1PropertyName, o2Property.Name);

                    if (customComparisonRule != null)
                    {
                        CheckEqualityResult result = customComparisonRule.Comparer(o1Value, o2Value);
                        if (!result.Equal)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        CheckEqualityResult result = this.CheckEquality(o1Value, o2Value);
                        if (!result.Equal)
                        {
                            return result;
                        }
                    }
                }
                catch (TargetInvocationException e)
                {
                    if (this.shouldSwallowPropertyReadException(e))
                    {
                        throw;
                    }
                }
            }

            return CheckEqualityResult.True;
        }

        private CheckEqualityResult CompareEnumerables(IEnumerable enumerable1, IEnumerable enumerable2)
        {
            //Order doesn't matter but should be preserved
            List<object> list1 = enumerable1.Cast<object>().ToList();
            List<object> list2 = enumerable2.Cast<object>().ToList();

            if (list2.Count != list1.Count)
            {
                return CheckEqualityResult.False("Collection counts do not match");
            }
            var checkResult = list1.Select((item1, i) => this.CheckEquality(item1, list2[i])).FirstOrDefault(check => !check.Equal);
            return checkResult != null ? checkResult : CheckEqualityResult.True;
        }

        private string GetPropertyMappingOrNull(Type type, string propertyName)
        {
            return this.propertyMappings.Select(m => m.FindMatch(type, propertyName)).SingleOrDefault(str => !string.IsNullOrEmpty(str));
        }

        private ComparisonRule GetComparisonRuleOrNull(Type type1, Type type2, string type1PropertyName, string type2PropertyName)
        {
            ComparisonRule comparisonRule =
                this.comparisonRules?.SingleOrDefault(rule =>
                    rule.Type1 == type1 &&
                    rule.Type2 == type2 &&
                    rule.Type1PropertyName == type1PropertyName &&
                    rule.Type2PropertyName == type2PropertyName) ??
                this.comparisonRules?.SingleOrDefault(rule =>
                    rule.Type2 == type1 &&
                    rule.Type1 == type2 &&
                    rule.Type2PropertyName == type1PropertyName &&
                    rule.Type1PropertyName == type2PropertyName)?.Flip();

            return comparisonRule;
        }
        
        private static bool IsObjectEqualsMethod(MethodInfo methodInfo)
        {
            return methodInfo.Name == "Equals" && methodInfo.GetBaseDefinition().DeclaringType.Equals(typeof (object));
        }

        private static bool OverridesEqualsMethod(Type t)
        {
            MethodInfo equalsMethod = t.GetMethods().Single(IsObjectEqualsMethod);

            return !equalsMethod.DeclaringType.Equals(typeof (object));
        }
    }
}
