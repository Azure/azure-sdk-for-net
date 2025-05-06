// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

    /// <summary>
    /// Filter determines whether a telemetry document matches the criterion.
    /// The filter's configuration (condition) is specified in a <see cref="FilterInfo"/> DTO.
    /// </summary>
    /// <typeparam name="TTelemetry">Type of telemetry documents.</typeparam>
    internal class Filter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] TTelemetry> where TTelemetry : DocumentIngress
    {
        private const string FieldNameCustomDimensionsPrefix = "CustomDimensions.";

        private const string FieldNameCustomMetricsPrefix = "CustomMetrics.";

        private const string FieldNameAsterisk = "*";

        private const string CustomMetricsPropertyName = "Metrics";

        private const string CustomDimensionsPropertyName = "Properties";

        private const char FieldNameTrainSeparator = '.';

        private static readonly MethodInfo DoubleToStringMethodInfo = GetMethodInfo<double, string>(x => x.ToString(CultureInfo.InvariantCulture));

        private static readonly MethodInfo NullableDoubleToStringMethodInfo = GetMethodInfo<double?, string>(x => x.ToString());

        private static readonly MethodInfo ObjectToStringMethodInfo = GetMethodInfo<object, string>(x => x.ToString());

        private static readonly MethodInfo ValueTypeToStringMethodInfo = GetMethodInfo<ValueType, string>(x => x.ToString());

#pragma warning disable RS0030 // Do not used banned APIs. Using AbsoluteUri will fail test case FilterIntContains and FilterIntDoesNotContain.
        private static readonly MethodInfo UriToStringMethodInfo = GetMethodInfo<Uri, string>(x => x.ToString());
#pragma warning restore RS0030 // Do not used banned APIs

        private static readonly MethodInfo StringIndexOfMethodInfo =
            GetMethodInfo<string, string, int>((x, y) => x.IndexOf(y, StringComparison.OrdinalIgnoreCase));

        private static readonly MethodInfo StringEqualsMethodInfo =
            GetMethodInfo<string, string, bool>((x, y) => x.Equals(y, StringComparison.OrdinalIgnoreCase));

        private static readonly MethodInfo DoubleTryParseMethodInfo = typeof(double).GetMethod(
            "TryParse",
            new[] { typeof(string), typeof(NumberStyles), typeof(IFormatProvider), typeof(double).MakeByRefType() });

        private static readonly MethodInfo ListStringTryGetValueMethodInfo =
            GetMethodInfo<IList<KeyValuePairString>, string, string>((list, key) => TryGetString(list, key));

        private static readonly MethodInfo DictionaryStringDoubleTryGetValueMethodInfo = typeof(IDictionary<string, double>).GetMethod("TryGetValue");

        private static readonly MethodInfo ListKeyValuePairStringScanMethodInfo =
            GetMethodInfo<IList<KeyValuePairString>, string, bool>((list, searchValue) => ScanList(list, searchValue));

        private static readonly MethodInfo DictionaryStringDoubleScanMethodInfo =
           GetMethodInfo<IDictionary<string, double>, string, bool>((dict, searchValue) => ScanDictionary(dict, searchValue));

        private static readonly ConstantExpression DoubleDefaultNumberStyles = Expression.Constant(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent);
        private static readonly ConstantExpression InvariantCulture = Expression.Constant(CultureInfo.InvariantCulture);

        private readonly Func<TTelemetry, bool> filterLambda;

        private readonly double? comparandDouble;

        private readonly bool? comparandBoolean;

        private readonly TimeSpan? comparandTimeSpan;

        private readonly string comparand;

        private readonly Predicate predicate;

        private readonly string fieldName;

        private readonly FilterInfo info;

        public Filter(FilterInfo filterInfo)
        {
            ValidateInput(filterInfo);

            info = filterInfo;

            if (typeof(TTelemetry) == typeof(Request))
            {
                if (filterInfo.FieldName == "Success")
                {
                    filterInfo = new FilterInfo(nameof(Request.Extension_IsSuccess), filterInfo.Predicate, filterInfo.Comparand);
                }
            }
            else if (typeof(TTelemetry) == typeof(RemoteDependency))
            {
                var fieldName = filterInfo.FieldName;
                if (fieldName == "Type" || fieldName == "Target")
                {
                    Expression<Func<TTelemetry, bool>> lambdaExpression = Expression.Lambda<Func<TTelemetry, bool>>(Expression.Constant(true), Expression.Variable(typeof(TTelemetry)));
                    filterLambda = lambdaExpression.Compile();
                    return;
                }
                else if (fieldName == "Success")
                {
                    filterInfo = new FilterInfo(nameof(RemoteDependency.Extension_IsSuccess), filterInfo.Predicate, filterInfo.Comparand);
                }
                else if (fieldName == "Data")
                {
                    filterInfo = new FilterInfo(nameof(RemoteDependency.CommandName), filterInfo.Predicate, filterInfo.Comparand);
                }
            }
            else if (typeof(TTelemetry) == typeof(Models.Exception))
            {
                var fieldName = filterInfo.FieldName;
                if (fieldName == "Exception.StackTrace")
                {
                    Expression<Func<TTelemetry, bool>> lambdaExpression = Expression.Lambda<Func<TTelemetry, bool>>(Expression.Constant(true), Expression.Variable(typeof(TTelemetry)));
                    filterLambda = lambdaExpression.Compile();
                    return;
                }
                else if (fieldName == "Exception.Message")
                {
                    filterInfo = new FilterInfo(nameof(Models.Exception.ExceptionMessage), filterInfo.Predicate, filterInfo.Comparand);
                }
            }

            fieldName = filterInfo.FieldName;
            predicate = (Predicate)FilterInfoPredicateUtility.ToPredicate(filterInfo.Predicate);
            comparand = filterInfo.Comparand;

            FieldNameType fieldNameType;
            Type fieldType = GetFieldType(filterInfo.FieldName, out fieldNameType);
            ThrowOnInvalidFilter(
                null,
                fieldNameType == FieldNameType.AnyField && predicate != Predicate.Contains && predicate != Predicate.DoesNotContain);

            double comparandDouble;
            this.comparandDouble = double.TryParse(filterInfo.Comparand, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out comparandDouble) ? comparandDouble : null;

            bool comparandBoolean;
            this.comparandBoolean = bool.TryParse(filterInfo.Comparand, out comparandBoolean) ? comparandBoolean : null;

            TimeSpan comparandTimeSpan;
            this.comparandTimeSpan = TimeSpan.TryParse(filterInfo.Comparand, CultureInfo.InvariantCulture, out comparandTimeSpan)
                                         ? comparandTimeSpan
                                         : null;

            ParameterExpression documentExpression = Expression.Variable(typeof(TTelemetry));

            Expression comparisonExpression;

            try
            {
                if (fieldNameType == FieldNameType.AnyField)
                {
                    // multiple fields => multiple comparison expressions connected with ORs
                    comparisonExpression = ProduceComparatorExpressionForAnyFieldCondition(documentExpression);
                }
                else
                {
                    // a single field filterInfo.FieldName of type fieldType => a single comparison expression
                    Expression fieldExpression = ProduceFieldExpression(documentExpression, filterInfo.FieldName, fieldNameType);

                    comparisonExpression = ProduceComparatorExpressionForSingleFieldCondition(fieldExpression, fieldType);
                }
            }
            catch (System.Exception e)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Could not construct the filter."), e);
            }

            try
            {
                Expression<Func<TTelemetry, bool>> lambdaExpression = Expression.Lambda<Func<TTelemetry, bool>>(
                    comparisonExpression,
                    documentExpression);

                filterLambda = lambdaExpression.Compile();
            }
            catch (System.Exception e)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Could not compile the filter."), e);
            }
        }

        internal enum FieldNameType
        {
            FieldName,

            CustomMetricName,

            CustomDimensionName,

            AnyField,
        }

        public bool Check(TTelemetry document)
        {
            try
            {
                return filterLambda(document);
            }
            catch (System.Exception e)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Runtime error while filtering."), e);
            }
        }

        public override string ToString()
        {
            return info?.ToString() ?? string.Empty;
        }

        [UnconditionalSuppressMessage("AOT", "IL2075", Justification = "The DocumentIngress class and its derived classes have DynamicallyAccessedMembers attribute applied to preserve public properties.")]
        internal static Expression ProduceFieldExpression(
            ParameterExpression documentExpression,
            string fieldName,
            FieldNameType fieldNameType)
        {
            switch (fieldNameType)
            {
                case FieldNameType.FieldName:
                    Expression current = documentExpression;
                    string[] propertyNames = fieldName.Split(FieldNameTrainSeparator);

                    foreach (string propertyName in propertyNames)
                    {
                        Type currentType = current.Type;
                        PropertyInfo propertyInfo = currentType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

                        if (propertyInfo == null)
                        {
                            throw new ArgumentOutOfRangeException(
                                nameof(fieldName),
                                $"Property '{propertyName}' not found on type '{currentType.FullName}'");
                        }

                        current = Expression.Property(current, propertyInfo);
                    }

                    return current;

                case FieldNameType.CustomMetricName:
                    string customMetricName = fieldName.Substring(
                        FieldNameCustomMetricsPrefix.Length,
                        fieldName.Length - FieldNameCustomMetricsPrefix.Length);

                    return CreateDictionaryAccessExpression(
                        documentExpression,
                        CustomMetricsPropertyName,
                        DictionaryStringDoubleTryGetValueMethodInfo,
                        typeof(double),
                        customMetricName);
                case FieldNameType.CustomDimensionName:
                    string customDimensionName = fieldName.Substring(
                        FieldNameCustomDimensionsPrefix.Length,
                        fieldName.Length - FieldNameCustomDimensionsPrefix.Length);

                    return CreateListAccessExpression(
                        documentExpression,
                        CustomDimensionsPropertyName,
                        ListStringTryGetValueMethodInfo,
                        typeof(string),
                        customDimensionName);
                default:
                    throw new ArgumentOutOfRangeException(nameof(fieldNameType), fieldNameType, null);
            }
        }

        internal static Type GetFieldType(string fieldName, out FieldNameType fieldNameType)
        {
            if (fieldName.StartsWith(FieldNameCustomDimensionsPrefix, StringComparison.Ordinal))
            {
                fieldNameType = FieldNameType.CustomDimensionName;
                return typeof(string);
            }

            if (fieldName.StartsWith(FieldNameCustomMetricsPrefix, StringComparison.Ordinal))
            {
                fieldNameType = FieldNameType.CustomMetricName;
                return typeof(double);
            }

            if (fieldName.StartsWith(FieldNameAsterisk, StringComparison.Ordinal))
            {
                fieldNameType = FieldNameType.AnyField;
                return null;
            }

            // no special case in filterInfo.FieldName, treat it as the name of a property in TTelemetry type
            fieldNameType = FieldNameType.FieldName;
            return GetPropertyTypeFromFieldName(fieldName);
        }

        [UnconditionalSuppressMessage("AOT", "IL2075", Justification = "The DocumentIngress class and its derived classes have DynamicallyAccessedMembers attribute applied to preserve public properties.")]
        private static Expression CreateListAccessExpression(
            ParameterExpression documentExpression,
            string listName,
            MethodInfo tryGetValueMethodInfo,
            Type valueType,
            string keyValue)
        {
            // Get the PropertyInfo directly to avoid string-based property access
            PropertyInfo listProperty = documentExpression.Type.GetProperty(listName, BindingFlags.Instance | BindingFlags.Public);
            if (listProperty == null)
            {
                throw new ArgumentException($"Property '{listName}' not found on type '{documentExpression.Type.FullName}'", nameof(listName));
            }

            // return Filter<int>.TryGetString(document.listName, keyValue)
            MemberExpression properties = Expression.Property(documentExpression, listProperty);
            return Expression.Call(tryGetValueMethodInfo, properties, Expression.Constant(keyValue));
        }

        [UnconditionalSuppressMessage("AOT", "IL2075", Justification = "The DocumentIngress class and its derived classes have DynamicallyAccessedMembers attribute applied to preserve public properties.")]
        private static Expression CreateDictionaryAccessExpression(
            ParameterExpression documentExpression,
            string dictionaryName,
            MethodInfo tryGetValueMethodInfo,
            Type valueType,
            string keyValue)
        {
            // Get the PropertyInfo directly to avoid string-based property access
            PropertyInfo dictionaryProperty = documentExpression.Type.GetProperty(dictionaryName, BindingFlags.Instance | BindingFlags.Public);
            if (dictionaryProperty == null)
            {
                throw new ArgumentException($"Property '{dictionaryName}' not found on type '{documentExpression.Type.FullName}'", nameof(dictionaryName));
            }

            // valueType value;
            // document.dictionaryName.TryGetValue(keyValue, out value)
            // return value;
            ParameterExpression valueVariable = Expression.Variable(valueType);

            MemberExpression properties = Expression.Property(documentExpression, dictionaryProperty);
            MethodCallExpression tryGetValueCall = Expression.Call(properties, tryGetValueMethodInfo, Expression.Constant(keyValue), valueVariable);

            // a block will "return" its last expression
            return Expression.Block(valueType, new[] { valueVariable }, tryGetValueCall, valueVariable);
        }

        private static MethodInfo GetMethodInfo<T, TResult>(Expression<Func<T, TResult>> expression)
        {
            if (expression.Body is MethodCallExpression member)
            {
                return member.Method;
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Expression is not a method"), nameof(expression));
        }

        private static MethodInfo GetMethodInfo<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> expression)
        {
            if (expression.Body is MethodCallExpression member)
            {
                return member.Method;
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Expression is not a method"), nameof(expression));
        }

        private static Type GetPropertyTypeFromFieldName(string fieldName)
        {
            try
            {
                Type propertyType = typeof(TTelemetry);

                foreach (string propertyName in fieldName.Split(FieldNameTrainSeparator))
                {
                    propertyType = GetPropertyType(propertyType, propertyName);
                }

                if (fieldName == "Duration")
                {
                    propertyType = typeof(TimeSpan);
                }

                if (propertyType == null)
                {
                    string propertyNotFoundMessage = string.Format(
                        CultureInfo.InvariantCulture,
                        "Error finding property {0} in the type {1}",
                        fieldName,
                        typeof(TTelemetry).FullName);

                    throw new ArgumentOutOfRangeException(nameof(fieldName), propertyNotFoundMessage);
                }

                return propertyType;
            }
            catch (System.Exception e)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(CultureInfo.InvariantCulture, "Error finding property {0} in the type {1}", fieldName, typeof(TTelemetry).FullName),
                    e);
            }
        }

        private static Type GetPropertyType(
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] Type type,
            string propertyName)
        {
            PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public)
                ?? throw new ArgumentOutOfRangeException(nameof(propertyName), $"Property '{propertyName}' not found on type '{type.FullName}'");

            return propertyInfo.PropertyType;
        }

        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "Argument exceptions are valid.")]
        private static void ValidateInput(FilterInfo filterInfo)
        {
            if (filterInfo == null)
            {
                throw new ArgumentNullException(nameof(filterInfo));
            }

            if (string.IsNullOrEmpty(filterInfo.FieldName))
            {
                throw new ArgumentNullException(nameof(filterInfo.FieldName), string.Format(CultureInfo.InvariantCulture, "Parameter must be specified."));
            }

            if (filterInfo.Comparand == null)
            {
                throw new ArgumentNullException(nameof(filterInfo.Comparand), string.Format(CultureInfo.InvariantCulture, "Parameter cannot be null."));
            }
        }

        private static string TryGetString(IList<KeyValuePairString> list, string keyValue)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (string.Equals(list[i].Key, keyValue, StringComparison.OrdinalIgnoreCase))
                {
                    return list[i].Value;
                }
            }
            return null;
        }

        private static bool ScanList(IList<KeyValuePairString> list, string searchValue)
        {
            return list?.Any(val => (val.Value ?? string.Empty).IndexOf(searchValue ?? string.Empty, StringComparison.OrdinalIgnoreCase) != -1)
                   ?? false;
        }

        private static bool ScanDictionary(IDictionary<string, double> dict, string searchValue)
        {
            return dict?.Values.Any(val => val.ToString(CultureInfo.InvariantCulture).IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) != -1)
                   ?? false;
        }

        private Expression ProduceComparatorExpressionForSingleFieldCondition(Expression fieldExpression, Type fieldType, bool isFieldTypeNullable = false)
        {
            // this must determine an appropriate runtime comparison given the field type, the predicate, and the comparand
            TypeCode fieldTypeCode = Type.GetTypeCode(fieldType);
            switch (fieldTypeCode)
            {
                case TypeCode.Boolean:
                    {
                        ThrowOnInvalidFilter(fieldType, !comparandBoolean.HasValue);

                        switch (predicate)
                        {
                            case Predicate.Equal:
                                // fieldValue == this.comparandBoolean.Value;
                                return Expression.Equal(fieldExpression, Expression.Constant(comparandBoolean.Value, isFieldTypeNullable ? typeof(bool?) : typeof(bool)));
                            case Predicate.NotEqual:
                                // fieldValue != this.comparandBoolean.Value;
                                return Expression.NotEqual(fieldExpression, Expression.Constant(comparandBoolean.Value, isFieldTypeNullable ? typeof(bool?) : typeof(bool)));
                            default:
                                ThrowOnInvalidFilter(fieldType);
                                break;
                        }
                    }

                    break;
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                    {
                        if (fieldType.GetTypeInfo().IsEnum)
                        {
                            // this is actually an Enum
                            object enumValue = null;
                            try
                            {
                                enumValue = Enum.Parse(fieldType, comparand, true);
                            }
                            catch (System.Exception)
                            {
                                // we must throw unless this.predicate is either Contains or DoesNotContain, in which case it's ok
                                ThrowOnInvalidFilter(fieldType, predicate != Predicate.Contains && predicate != Predicate.DoesNotContain);
                            }

                            Type enumUnderlyingType = fieldType.GetTypeInfo().GetEnumUnderlyingType();

                            // This block matches the case statements just above.
                            static Type GetNullableType(Type inputType) => inputType switch
                            {
                                _ when inputType == typeof(sbyte) => typeof(sbyte?),
                                _ when inputType == typeof(short) => typeof(short?),
                                _ when inputType == typeof(int) => typeof(int?),
                                _ when inputType == typeof(long) => typeof(long?),
                                _ when inputType == typeof(byte) => typeof(byte?),
                                _ when inputType == typeof(ushort) => typeof(ushort?),
                                _ when inputType == typeof(uint) => typeof(uint?),
                                _ when inputType == typeof(ulong) => typeof(ulong?),
                                _ when inputType == typeof(float) => typeof(float?),
                                _ when inputType == typeof(double) => typeof(double?),
                                _ => throw new ArgumentException($"Cannot create a nullable type for {inputType.FullName}."),
                            };

                            switch (predicate)
                            {
                                case Predicate.Equal:
                                    // fieldValue == enumValue
                                    if (isFieldTypeNullable)
                                    {
                                        // For nullable enums, we need to use a different approach
                                        // First, check if the field is null, then check for equality if not null
                                        // (fieldExpression == null ? false : fieldExpression.Value == enumValue)
                                        return Expression.Condition(
                                            Expression.Equal(fieldExpression, Expression.Constant(null, fieldExpression.Type)),
                                            Expression.Constant(false),
                                            Expression.Equal(
                                                Expression.Convert(fieldExpression, fieldType),
                                                Expression.Constant(enumValue, fieldType)));
                                    }
                                    else
                                    {
                                        return Expression.Equal(fieldExpression, Expression.Constant(enumValue, fieldType));
                                    }
                                case Predicate.NotEqual:
                                    // fieldValue != enumValue
                                    if (isFieldTypeNullable)
                                    {
                                        // For nullable enums: (fieldExpression == null ? true : fieldExpression.Value != enumValue)
                                        return Expression.Condition(
                                            Expression.Equal(fieldExpression, Expression.Constant(null, fieldExpression.Type)),
                                            Expression.Constant(true),
                                            Expression.NotEqual(
                                                Expression.Convert(fieldExpression, fieldType),
                                                Expression.Constant(enumValue, fieldType)));
                                    }
                                    else
                                    {
                                        return Expression.NotEqual(fieldExpression, Expression.Constant(enumValue, fieldType));
                                    }
                                case Predicate.LessThan:
                                    // (int)fieldValue < (int)enumValue
                                    // (int?)fieldValue < (int?)enumValue
                                    Type underlyingType = isFieldTypeNullable ? GetNullableType(enumUnderlyingType) : enumUnderlyingType;
                                    return Expression.LessThan(
                                        Expression.Convert(fieldExpression, underlyingType),
                                        Expression.Convert(Expression.Constant(enumValue, fieldType), underlyingType));
                                case Predicate.GreaterThan:
                                    // (int)fieldValue > (int)enumValue
                                    // (int?)fieldValue > (int?)enumValue
                                    underlyingType = isFieldTypeNullable ? GetNullableType(enumUnderlyingType) : enumUnderlyingType;
                                    return Expression.GreaterThan(
                                        Expression.Convert(fieldExpression, underlyingType),
                                        Expression.Convert(Expression.Constant(enumValue, fieldType), underlyingType));
                                case Predicate.LessThanOrEqual:
                                    // (int)fieldValue <= (int)enumValue
                                    // (int?)fieldValue <= (int?)enumValue
                                    underlyingType = isFieldTypeNullable ? GetNullableType(enumUnderlyingType) : enumUnderlyingType;
                                    return Expression.LessThanOrEqual(
                                        Expression.Convert(fieldExpression, underlyingType),
                                        Expression.Convert(Expression.Constant(enumValue, fieldType), underlyingType));
                                case Predicate.GreaterThanOrEqual:
                                    // (int)fieldValue >= (int)enumValue
                                    // (int?)fieldValue >= (int?)enumValue
                                    underlyingType = isFieldTypeNullable ? GetNullableType(enumUnderlyingType) : enumUnderlyingType;
                                    return Expression.GreaterThanOrEqual(
                                        Expression.Convert(fieldExpression, underlyingType),
                                        Expression.Convert(Expression.Constant(enumValue, fieldType), underlyingType));
                                case Predicate.Contains:
                                    // fieldValue.ToString(CultureInfo.InvariantCulture).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) != -1
                                    Expression toStringCall = Expression.Call(fieldExpression, isFieldTypeNullable ? ValueTypeToStringMethodInfo : ObjectToStringMethodInfo);
                                    Expression indexOfCall = Expression.Call(toStringCall, StringIndexOfMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                                    return Expression.NotEqual(indexOfCall, Expression.Constant(-1));
                                case Predicate.DoesNotContain:
                                    // fieldValue.ToString(CultureInfo.InvariantCulture).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) == -1
                                    toStringCall = Expression.Call(fieldExpression, isFieldTypeNullable ? ValueTypeToStringMethodInfo : ObjectToStringMethodInfo);
                                    indexOfCall = Expression.Call(toStringCall, StringIndexOfMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                                    return Expression.Equal(indexOfCall, Expression.Constant(-1));
                                default:
                                    ThrowOnInvalidFilter(fieldType);
                                    break;
                            }
                        }
                        else
                        {
                            // this is a regular numerical type
                            // in order for the expression to compile, we must cast to double unless it's already double
                            // we're using double as the lowest common denominator for all numerical types
                            Expression fieldConvertedExpression = fieldTypeCode == TypeCode.Double
                                                                      ? fieldExpression
                                                                      : Expression.ConvertChecked(fieldExpression, isFieldTypeNullable ? typeof(double?) : typeof(double));

                            switch (predicate)
                            {
                                case Predicate.Equal:
                                    ThrowOnInvalidFilter(fieldType, !comparandDouble.HasValue);
                                    return Expression.Equal(
                                        fieldConvertedExpression,
                                        Expression.Constant(comparandDouble.Value, isFieldTypeNullable ? typeof(double?) : typeof(double)));
                                case Predicate.NotEqual:
                                    ThrowOnInvalidFilter(fieldType, !comparandDouble.HasValue);
                                    return Expression.NotEqual(
                                        fieldConvertedExpression,
                                        Expression.Constant(comparandDouble.Value, isFieldTypeNullable ? typeof(double?) : typeof(double)));
                                case Predicate.LessThan:
                                    ThrowOnInvalidFilter(fieldType, !comparandDouble.HasValue);
                                    return Expression.LessThan(
                                        fieldConvertedExpression,
                                        Expression.Constant(comparandDouble.Value, isFieldTypeNullable ? typeof(double?) : typeof(double)));
                                case Predicate.GreaterThan:
                                    ThrowOnInvalidFilter(fieldType, !comparandDouble.HasValue);
                                    return Expression.GreaterThan(
                                        fieldConvertedExpression,
                                        Expression.Constant(comparandDouble.Value, isFieldTypeNullable ? typeof(double?) : typeof(double)));
                                case Predicate.LessThanOrEqual:
                                    ThrowOnInvalidFilter(fieldType, !comparandDouble.HasValue);
                                    return Expression.LessThanOrEqual(
                                        fieldConvertedExpression,
                                        Expression.Constant(comparandDouble.Value, isFieldTypeNullable ? typeof(double?) : typeof(double)));
                                case Predicate.GreaterThanOrEqual:
                                    ThrowOnInvalidFilter(fieldType, !comparandDouble.HasValue);
                                    return Expression.GreaterThanOrEqual(
                                        fieldConvertedExpression,
                                        Expression.Constant(comparandDouble.Value, isFieldTypeNullable ? typeof(double?) : typeof(double)));
                                case Predicate.Contains:
                                    // fieldValue.ToString(CultureInfo.InvariantCulture).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) != -1
                                    Expression toStringCall = isFieldTypeNullable
                                                                  ? Expression.Call(fieldConvertedExpression, NullableDoubleToStringMethodInfo)
                                                                  : Expression.Call(fieldConvertedExpression, DoubleToStringMethodInfo, Expression.Constant(CultureInfo.InvariantCulture));
                                    Expression indexOfCall = Expression.Call(toStringCall, StringIndexOfMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                                    return Expression.NotEqual(indexOfCall, Expression.Constant(-1));
                                case Predicate.DoesNotContain:
                                    // fieldValue.ToString(CultureInfo.InvariantCulture).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) == -1
                                    toStringCall = isFieldTypeNullable
                                                       ? Expression.Call(fieldConvertedExpression, NullableDoubleToStringMethodInfo)
                                                       : Expression.Call(fieldConvertedExpression, DoubleToStringMethodInfo, Expression.Constant(CultureInfo.InvariantCulture));
                                    indexOfCall = Expression.Call(toStringCall, StringIndexOfMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                                    return Expression.Equal(indexOfCall, Expression.Constant(-1));
                                default:
                                    ThrowOnInvalidFilter(fieldType);
                                    break;
                            }
                        }
                    }

                    break;
                case TypeCode.String:
                    {
                        Expression fieldValueOrEmptyString = Expression.Condition(Expression.Equal(fieldExpression, Expression.Constant(null)), Expression.Constant(string.Empty), fieldExpression);

                        Expression indexOfCall = Expression.Call(fieldValueOrEmptyString, StringIndexOfMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));

                        switch (predicate)
                        {
                            case Predicate.Equal:
                                // (fieldValue ?? string.Empty).Equals(this.comparand, StringComparison.OrdinalIgnoreCase)
                                return Expression.Call(fieldValueOrEmptyString, StringEqualsMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                            case Predicate.NotEqual:
                                // !(fieldValue ?? string.Empty).Equals(this.comparand, StringComparison.OrdinalIgnoreCase)
                                return Expression.Not(Expression.Call(fieldValueOrEmptyString, StringEqualsMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase)));
                            case Predicate.LessThan:
                            case Predicate.GreaterThan:
                            case Predicate.LessThanOrEqual:
                            case Predicate.GreaterThanOrEqual:
                                // double.TryParse(fieldValue, out temp) && temp {<, <=, >, >=} comparandDouble
                                ThrowOnInvalidFilter(fieldType, !comparandDouble.HasValue);
                                return CreateStringToDoubleComparisonBlock(fieldExpression, predicate);
                            case Predicate.Contains:
                                // fieldValue => (fieldValue ?? string.Empty).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) != -1;
                                return Expression.NotEqual(indexOfCall, Expression.Constant(-1));
                            case Predicate.DoesNotContain:
                                // fieldValue => (fieldValue ?? string.Empty).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) == -1;
                                return Expression.Equal(indexOfCall, Expression.Constant(-1));
                            default:
                                ThrowOnInvalidFilter(fieldType);
                                break;
                        }
                    }

                    break;
                default:
                    Type nullableUnderlyingType;
                    if (fieldType == typeof(TimeSpan))
                    {
                        ThrowOnInvalidFilter(fieldType, !comparandTimeSpan.HasValue);
                        if (fieldExpression.Type == typeof(string))
                        {
                            MethodInfo parseMethod = typeof(TimeSpan).GetMethod("Parse", new[] { typeof(string) });
                            fieldExpression = Expression.Call(parseMethod, fieldExpression);
                        }

                        switch (predicate)
                        {
                            case Predicate.Equal:
                                Func<TimeSpan, bool> comparator = fieldValue => fieldValue == comparandTimeSpan.Value;
                                return Expression.Call(Expression.Constant(comparator.Target), comparator.GetMethodInfo(), fieldExpression);
                            case Predicate.NotEqual:
                                comparator = fieldValue => fieldValue != comparandTimeSpan.Value;
                                return Expression.Call(Expression.Constant(comparator.Target), comparator.GetMethodInfo(), fieldExpression);
                            case Predicate.LessThan:
                                comparator = fieldValue => fieldValue < comparandTimeSpan.Value;
                                return Expression.Call(Expression.Constant(comparator.Target), comparator.GetMethodInfo(), fieldExpression);
                            case Predicate.GreaterThan:
                                comparator = fieldValue => fieldValue > comparandTimeSpan.Value;
                                return Expression.Call(Expression.Constant(comparator.Target), comparator.GetMethodInfo(), fieldExpression);
                            case Predicate.LessThanOrEqual:
                                comparator = fieldValue => fieldValue <= comparandTimeSpan.Value;
                                return Expression.Call(Expression.Constant(comparator.Target), comparator.GetMethodInfo(), fieldExpression);
                            case Predicate.GreaterThanOrEqual:
                                comparator = fieldValue => fieldValue >= comparandTimeSpan.Value;
                                return Expression.Call(Expression.Constant(comparator.Target), comparator.GetMethodInfo(), fieldExpression);
                            default:
                                ThrowOnInvalidFilter(fieldType);
                                break;
                        }
                    }
                    else if (fieldType == typeof(Uri))
                    {
                        Expression toStringCall = Expression.Call(fieldExpression, UriToStringMethodInfo);

                        Expression fieldValueOrEmptyString = Expression.Condition(Expression.Equal(fieldExpression, Expression.Constant(null)), Expression.Constant(string.Empty), toStringCall);

                        Expression indexOfCall = Expression.Call(fieldValueOrEmptyString, StringIndexOfMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));

                        switch (predicate)
                        {
                            case Predicate.Equal:
                                // (fieldValue?.ToString() ?? string.Empty).Equals(this.comparand, StringComparison.OrdinalIgnoreCase)
                                return Expression.Call(fieldValueOrEmptyString, StringEqualsMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                            case Predicate.NotEqual:
                                // !(fieldValue?.ToString() ?? string.Empty).Equals(this.comparand, StringComparison.OrdinalIgnoreCase)
                                return Expression.Not(Expression.Call(fieldValueOrEmptyString, StringEqualsMethodInfo, Expression.Constant(comparand), Expression.Constant(StringComparison.OrdinalIgnoreCase)));
                            case Predicate.Contains:
                                // fieldValue => (fieldValue?.ToString() ?? string.Empty).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) != -1;
                                return Expression.NotEqual(indexOfCall, Expression.Constant(-1));
                            case Predicate.DoesNotContain:
                                // fieldValue => (fieldValue?.ToString() ?? string.Empty).IndexOf(this.comparand, StringComparison.OrdinalIgnoreCase) == -1;
                                return Expression.Equal(indexOfCall, Expression.Constant(-1));
                            default:
                                ThrowOnInvalidFilter(fieldType);
                                break;
                        }
                    }
                    else if ((nullableUnderlyingType = Nullable.GetUnderlyingType(fieldType)) != null)
                    {
                        // make a recursive call for the underlying type
                        return ProduceComparatorExpressionForSingleFieldCondition(fieldExpression, nullableUnderlyingType, true);
                    }
                    else
                    {
                        ThrowOnInvalidFilter(fieldType);
                    }

                    break;
            }

            return null;
        }

        [UnconditionalSuppressMessage("AOT", "IL2075", Justification = "The DocumentIngress class and its derived classes have DynamicallyAccessedMembers attribute applied to preserve public properties.")]
        private Expression ProduceComparatorExpressionForAnyFieldCondition(ParameterExpression documentExpression)
        {
            // this.predicate is either Predicate.Contains or Predicate.DoesNotContain at this point
            if (predicate != Predicate.Contains && predicate != Predicate.DoesNotContain)
            {
                throw new InvalidOperationException(
                    "ProduceComparatorExpressionForAnyFieldCondition is called while this.predicate is neither Predicate.Contains nor Predicate.DoesNotContain");
            }

            Expression comparisonExpression = predicate == Predicate.Contains ? Expression.Constant(false) : Expression.Constant(true);

            foreach (PropertyInfo propertyInfo in typeof(TTelemetry).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                try
                {
                    Expression propertyComparatorExpression;
                    if (string.Equals(propertyInfo.Name, CustomDimensionsPropertyName, StringComparison.Ordinal))
                    {
                        // ScanList(document.<CustomDimensionsPropertyName>, <this.comparand>)
                        PropertyInfo customDimensionsPropertyInfo = documentExpression.Type.GetProperty(
                            CustomDimensionsPropertyName, BindingFlags.Instance | BindingFlags.Public);

                        if (customDimensionsPropertyInfo == null)
                        {
                            continue; // Skip if property doesn't exist
                        }

                        MemberExpression customDimensionsProperty = Expression.Property(documentExpression, customDimensionsPropertyInfo);

                        propertyComparatorExpression = Expression.Call(
                            null,
                            ListKeyValuePairStringScanMethodInfo,
                            customDimensionsProperty,
                            Expression.Constant(comparand));

                        if (predicate == Predicate.DoesNotContain)
                        {
                            propertyComparatorExpression = Expression.Not(propertyComparatorExpression);
                        }
                    }
                    else if (string.Equals(propertyInfo.Name, CustomMetricsPropertyName, StringComparison.Ordinal))
                    {
                        // ScanDictionary(document.<CustomMetricsPropertyName>, <this.comparand>)
                        PropertyInfo customMetricsPropertyInfo = documentExpression.Type.GetProperty(
                            CustomMetricsPropertyName, BindingFlags.Instance | BindingFlags.Public);

                        if (customMetricsPropertyInfo == null)
                        {
                            continue; // Skip if property doesn't exist
                        }

                        MemberExpression customMetricsProperty = Expression.Property(documentExpression, customMetricsPropertyInfo);

                        propertyComparatorExpression = Expression.Call(
                            null,
                            DictionaryStringDoubleScanMethodInfo,
                            customMetricsProperty,
                            Expression.Constant(comparand));

                        if (predicate == Predicate.DoesNotContain)
                        {
                            propertyComparatorExpression = Expression.Not(propertyComparatorExpression);
                        }
                    }
                    else
                    {
                        // regular property, create a comparator
                        Expression fieldExpression = ProduceFieldExpression(documentExpression, propertyInfo.Name, FieldNameType.FieldName);
                        propertyComparatorExpression = ProduceComparatorExpressionForSingleFieldCondition(fieldExpression, propertyInfo.PropertyType);
                    }

                    comparisonExpression = predicate == Predicate.Contains
                                               ? Expression.OrElse(comparisonExpression, propertyComparatorExpression)
                                               : Expression.AndAlso(comparisonExpression, propertyComparatorExpression);
                }
                catch (System.Exception)
                {
                    // probably an unsupported property (e.g. bool), ignore and continue
                }
            }

            return comparisonExpression;
        }

        private Expression CreateStringToDoubleComparisonBlock(Expression fieldExpression, Predicate predicate)
        {
            ParameterExpression tempVariable = Expression.Variable(typeof(double));
            MethodCallExpression doubleTryParseCall = Expression.Call(DoubleTryParseMethodInfo, fieldExpression, DoubleDefaultNumberStyles, InvariantCulture, tempVariable);

            BinaryExpression comparisonExpression;
            switch (predicate)
            {
                case Predicate.LessThan:
                    comparisonExpression = Expression.LessThan(tempVariable, Expression.Constant(comparandDouble.Value));
                    break;
                case Predicate.LessThanOrEqual:
                    comparisonExpression = Expression.LessThanOrEqual(tempVariable, Expression.Constant(comparandDouble.Value));
                    break;
                case Predicate.GreaterThan:
                    comparisonExpression = Expression.GreaterThan(tempVariable, Expression.Constant(comparandDouble.Value));
                    break;
                case Predicate.GreaterThanOrEqual:
                    comparisonExpression = Expression.GreaterThanOrEqual(tempVariable, Expression.Constant(comparandDouble.Value));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(predicate));
            }

            BinaryExpression andExpression = Expression.AndAlso(
                doubleTryParseCall,
                comparisonExpression);

            return Expression.Block(typeof(bool), new[] { tempVariable }, andExpression);
        }

        private void ThrowOnInvalidFilter(Type fieldType, bool conditionToThrow = true)
        {
            if (conditionToThrow)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The filter is invalid. Field: '{0}', field type: '{1}', predicate: '{2}', comparand: '{3}', document type: '{4}'", fieldName, fieldType?.FullName ?? "---", predicate, comparand, typeof(TTelemetry).FullName));
            }
        }
    }
}
