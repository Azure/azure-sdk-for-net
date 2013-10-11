// -----------------------------------------------------------------------------------------
// <copyright file="TableEntity.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

#if WINDOWS_DESKTOP && !WINDOWS_PHONE
    using ReadAction = System.Action<object, OperationContext, System.Collections.Generic.IDictionary<string, EntityProperty>>;
    using WriteFunc = System.Func<object, OperationContext, System.Collections.Generic.IDictionary<string, EntityProperty>>;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Concurrent;

#endif

    /// <summary>
    /// Represents the base object type for a table entity in the Table service.
    /// </summary>
    /// <remarks><see cref="TableEntity"/> provides a base implementation for the <see cref="ITableEntity"/> interface that provides <see cref="ReadEntity(IDictionary{string, EntityProperty}, OperationContext)"/> and <see cref="WriteEntity(OperationContext)"/> methods that by default serialize and 
    /// deserialize all properties via reflection. A table entity class may extend this class and override the <see cref="ITableEntity.ReadEntity(IDictionary{string, EntityProperty}, OperationContext)"/> and <see cref="ITableEntity.WriteEntity(OperationContext)"/> methods to provide customized or better performing serialization logic.</remarks>
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1114:ParameterListMustFollowDeclaration", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1115:ParameterMustFollowComma", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1116:SplitParametersMustStartOnLineAfterDeclaration", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1117:ParametersMustBeOnSameLineOrSeparateLines", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Reviewed.")]
    public class TableEntity : ITableEntity
    {
#if WINDOWS_DESKTOP && !WINDOWS_PHONE
        static TableEntity()
        {
            DisableCompiledSerializers = false;
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEntity"/> class.
        /// </summary>
        public TableEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEntity"/> class with the specified partition key and row key.
        /// </summary>
        /// <param name="partitionKey">The partition key of the <see cref="TableEntity"/> to be initialized.</param>
        /// <param name="rowKey">The row key of the <see cref="TableEntity"/> to be initialized.</param>
        public TableEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        #region ITableEntity Implementation

        /// <summary>
        /// Gets or sets the entity's partition key.
        /// </summary>
        /// <value>The partition key of the entity.</value>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's row key.
        /// </summary>
        /// <value>The row key of the entity.</value>
        public string RowKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's timestamp.
        /// </summary>
        /// <value>The timestamp of the entity.</value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the entity's current ETag.  Set this value to '*' in order to blindly overwrite an entity as part of an update operation.
        /// </summary>
        /// <value>The ETag of the entity.</value>
        public string ETag { get; set; }

        /// <summary>
        /// Deserializes this <see cref="TableEntity"/> instance using the specified <see cref="Dictionary{TKey,TValue}"/> of property names to <see cref="EntityProperty"/> data typed values. 
        /// </summary>
        /// <param name="properties">The map of string property names to <see cref="EntityProperty"/> data values to deserialize and store in this table entity instance.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        public virtual void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
#if WINDOWS_DESKTOP && !WINDOWS_PHONE
            if (!TableEntity.DisableCompiledSerializers)
            {
                if (this.CompiledRead == null)
                {
                    this.CompiledRead = compiledReadCache.GetOrAdd(this.GetType(), TableEntity.CompileReadAction);
                }

                this.CompiledRead(this, operationContext, properties);
                return;
            }
#endif
            ReflectionRead(this, properties, operationContext);
        }

        /// <summary>
        /// Deserializes a custom entity instance using the specified <see cref="Dictionary{TKey,TValue}"/> of property names to <see cref="EntityProperty"/> data typed values. 
        /// </summary>
        /// <param name="entity">Custom entity instance being deserialized.</param>
        /// <param name="properties">The map of string property names to <see cref="EntityProperty"/> data values to deserialize and store in this entity instance.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>       
        public static void ReadUserObject(object entity, IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("entity", entity);

#if WINDOWS_DESKTOP && !WINDOWS_PHONE
            if (!TableEntity.DisableCompiledSerializers)
            {
                ReadAction compiledReadAction = compiledReadCache.GetOrAdd(entity.GetType(), TableEntity.CompileReadAction);
                compiledReadAction(entity, operationContext, properties);
                return;
            }
#endif
            ReflectionRead(entity, properties, operationContext);
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Needed for object type checking.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Reviewed")]
        private static void ReflectionRead(object entity, IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
#if WINDOWS_RT
            IEnumerable<PropertyInfo> objectProperties = entity.GetType().GetRuntimeProperties();
#else
            IEnumerable<PropertyInfo> objectProperties = entity.GetType().GetProperties();
#endif
            foreach (PropertyInfo property in objectProperties)
            {
                if (ShouldSkipProperty(property, operationContext))
                {
                    continue;
                }

                // only proceed with properties that have a corresponding entry in the dictionary
                if (!properties.ContainsKey(property.Name))
                {
                    Logger.LogInformational(operationContext, SR.TraceMissingDictionaryEntry, property.Name);
                    continue;
                }

                EntityProperty entityProperty = properties[property.Name];

                if (entityProperty.IsNull)
                {
                    property.SetValue(entity, null, null);
                }
                else
                {
                    switch (entityProperty.PropertyType)
                    {
                        case EdmType.String:
                            if (property.PropertyType != typeof(string))
                            {
                                continue;
                            }

                            property.SetValue(entity, entityProperty.StringValue, null);
                            break;
                        case EdmType.Binary:
                            if (property.PropertyType != typeof(byte[]))
                            {
                                continue;
                            }

                            property.SetValue(entity, entityProperty.BinaryValue, null);
                            break;
                        case EdmType.Boolean:
                            if (property.PropertyType != typeof(bool) && property.PropertyType != typeof(bool?))
                            {
                                continue;
                            }

                            property.SetValue(entity, entityProperty.BooleanValue, null);
                            break;
                        case EdmType.DateTime:
                            if (property.PropertyType == typeof(DateTime))
                            {
                                property.SetValue(entity, entityProperty.DateTimeOffsetValue.Value.UtcDateTime, null);
                            }
                            else if (property.PropertyType == typeof(DateTime?))
                            {
                                property.SetValue(entity, entityProperty.DateTimeOffsetValue.HasValue ? entityProperty.DateTimeOffsetValue.Value.UtcDateTime : (DateTime?)null, null);
                            }
                            else if (property.PropertyType == typeof(DateTimeOffset))
                            {
                                property.SetValue(entity, entityProperty.DateTimeOffsetValue.Value, null);
                            }
                            else if (property.PropertyType == typeof(DateTimeOffset?))
                            {
                                property.SetValue(entity, entityProperty.DateTimeOffsetValue, null);
                            }

                            break;
                        case EdmType.Double:
                            if (property.PropertyType != typeof(double) && property.PropertyType != typeof(double?))
                            {
                                continue;
                            }

                            property.SetValue(entity, entityProperty.DoubleValue, null);
                            break;
                        case EdmType.Guid:
                            if (property.PropertyType != typeof(Guid) && property.PropertyType != typeof(Guid?))
                            {
                                continue;
                            }

                            property.SetValue(entity, entityProperty.GuidValue, null);
                            break;
                        case EdmType.Int32:
                            if (property.PropertyType != typeof(int) && property.PropertyType != typeof(int?))
                            {
                                continue;
                            }

                            property.SetValue(entity, entityProperty.Int32Value, null);
                            break;
                        case EdmType.Int64:
                            if (property.PropertyType != typeof(long) && property.PropertyType != typeof(long?))
                            {
                                continue;
                            }

                            property.SetValue(entity, entityProperty.Int64Value, null);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Serializes the <see cref="Dictionary{TKey,TValue}"/> of property names mapped to <see cref="EntityProperty"/> data values from this <see cref="TableEntity"/> instance.
        /// </summary>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        /// <returns>A map of property names to <see cref="EntityProperty"/> data typed values created by serializing this table entity instance.</returns>
        public virtual IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
#if WINDOWS_DESKTOP && !WINDOWS_PHONE
            if (!TableEntity.DisableCompiledSerializers)
            {
                if (this.CompiledWrite == null)
                {
                    this.CompiledWrite = compiledWriteCache.GetOrAdd(this.GetType(), TableEntity.CompileWriteFunc);
                }

                return this.CompiledWrite(this, operationContext);
            }
#endif
            return ReflectionWrite(this, operationContext);
        }

        /// <summary>
        /// Create a <see cref="Dictionary{TKey,TValue}"/> of <see cref="EntityProperty"/> objects for all the properties of the specified entity object.
        /// </summary>
        /// <param name="entity">The entity object to serialize.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> of <see cref="EntityProperty"/> objects for all the properties of the specified entity object.</returns>
        public static IDictionary<string, EntityProperty> WriteUserObject(object entity, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("entity", entity);

#if WINDOWS_DESKTOP && !WINDOWS_PHONE
            if (!TableEntity.DisableCompiledSerializers)
            {
                WriteFunc compiledWriteAction = compiledWriteCache.GetOrAdd(entity.GetType(), TableEntity.CompileWriteFunc);
                return compiledWriteAction(entity, operationContext);
            }
#endif
            return ReflectionWrite(entity, operationContext);
        }

        private static IDictionary<string, EntityProperty> ReflectionWrite(object entity, OperationContext operationContext)
        {
            Dictionary<string, EntityProperty> retVals = new Dictionary<string, EntityProperty>();

#if WINDOWS_RT
            IEnumerable<PropertyInfo> objectProperties = entity.GetType().GetRuntimeProperties();
#else
            IEnumerable<PropertyInfo> objectProperties = entity.GetType().GetProperties();
#endif

            foreach (PropertyInfo property in objectProperties)
            {
                if (ShouldSkipProperty(property, operationContext))
                {
                    continue;
                }

                EntityProperty newProperty = EntityProperty.CreateEntityPropertyFromObject(property.GetValue(entity, null), property.PropertyType);

                // property will be null if unknown type
                if (newProperty != null)
                {
                    retVals.Add(property.Name, newProperty);
                }
            }

            return retVals;
        }

        #endregion

        #region Static Helpers
        /// <summary>
        /// Determines if the given property should be skipped based on its name, if it exposes a public getter and setter, and if the IgnoreAttribute is not defined.
        /// </summary>
        /// <param name="property">The PropertyInfo of the property to check</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        /// <returns>True if the property should be skipped, false otherwise. </returns>
        private static bool ShouldSkipProperty(PropertyInfo property, OperationContext operationContext)
        {
            // reserved properties
            string propName = property.Name;
            if (propName == TableConstants.PartitionKey ||
                propName == TableConstants.RowKey ||
                propName == TableConstants.Timestamp ||
                propName == TableConstants.Etag)
            {
                return true;
            }

            MethodInfo setter = property.FindSetProp();
            MethodInfo getter = property.FindGetProp();

            // Enforce public getter / setter
            if (setter == null || !setter.IsPublic || getter == null || !getter.IsPublic)
            {
                Logger.LogInformational(operationContext, SR.TraceNonPublicGetSet, property.Name);
                return true;
            }

            // Skip static properties
            if (setter.IsStatic)
            {
                return true;
            }

            // properties with [IgnoreAttribute]
#if WINDOWS_RT
            if (property.GetCustomAttribute(typeof(IgnorePropertyAttribute)) != null)
#else
            if (Attribute.IsDefined(property, typeof(IgnorePropertyAttribute)))
#endif
            {
                Logger.LogInformational(operationContext, SR.TraceIgnoreAttribute, property.Name);
                return true;
            }

            return false;
        }
        #endregion

        #region CompiledSerialization Logic

#if WINDOWS_DESKTOP && !WINDOWS_PHONE
        private static void ReadNoOpAction(object obj, OperationContext ctx, IDictionary<string, EntityProperty> dict)
        {
            // no op
        }

        private static IDictionary<string, EntityProperty> WriteNoOpFunc(object obj, OperationContext ctx)
        {
            return new Dictionary<string, EntityProperty>();
        }

        private static MethodInfo GetKeyOrNullFromDictionaryMethodInfo { get; set; }

        private static MethodInfo DictionaryAddMethodInfo { get; set; }

        private static MethodInfo EntityProperty_CreateFromObjectMethodInfo { get; set; }

        private static MethodInfo EntityPropertyIsNullInfo { get; set; }

        private static PropertyInfo EntityPropertyPropTypePInfo { get; set; }

        private static PropertyInfo EntityProperty_StringPI { get; set; }

        private static PropertyInfo EntityProperty_BinaryPI { get; set; }

        private static PropertyInfo EntityProperty_BoolPI { get; set; }

        private static PropertyInfo EntityProperty_DateTimeOffsetPI { get; set; }

        private static PropertyInfo EntityProperty_DoublePI { get; set; }

        private static PropertyInfo EntityProperty_GuidPI { get; set; }

        private static PropertyInfo EntityProperty_Int32PI { get; set; }

        private static PropertyInfo EntityProperty_Int64PI { get; set; }

        private static PropertyInfo EntityProperty_PropTypePI { get; set; }

        private static MethodInfo EntityProperty_PropTypeGetter { get; set; }

        private static ConcurrentDictionary<Type, WriteFunc> compiledWriteCache = new ConcurrentDictionary<Type, WriteFunc>();

        private static ConcurrentDictionary<Type, ReadAction> compiledReadCache = new ConcurrentDictionary<Type, ReadAction>();

        /// <summary>
        /// Disables the ability to dynamically generate read and write lambdas at runtime. Setting this to false will clear out the static cache shared across all type instances that derive from TableEntity.
        /// </summary>
        public static bool DisableCompiledSerializers
        {
            get
            {
                return disableCompiledSerializers;
            }

            set
            {
                if (value)
                {
                    // Disabled, clear all dictionaries
                    compiledReadCache.Clear();
                    compiledWriteCache.Clear();
                }
                else if (EntityProperty_CreateFromObjectMethodInfo == null)
                {
                    // Only do reflection once
                    EntityProperty_CreateFromObjectMethodInfo = typeof(EntityProperty).FindStaticMethods("CreateEntityPropertyFromObject").First((m) =>
                    {
                        ParameterInfo[] mParams = m.GetParameters();
                        return mParams.Length == 2 && mParams[0].ParameterType == typeof(object) && mParams[1].ParameterType == typeof(Type);
                    });

                    GetKeyOrNullFromDictionaryMethodInfo = typeof(TableEntity).FindStaticMethods("GetValueByKeyFromDictionary").First((m) => m.GetParameters().Length == 3);
                    DictionaryAddMethodInfo = typeof(Dictionary<string, EntityProperty>).FindMethod("Add", new Type[] { typeof(string), typeof(EntityProperty) });
                    EntityProperty_StringPI = typeof(EntityProperty).FindProperty("StringValue");
                    EntityProperty_BinaryPI = typeof(EntityProperty).FindProperty("BinaryValue");
                    EntityProperty_BoolPI = typeof(EntityProperty).FindProperty("BooleanValue");
                    EntityProperty_DateTimeOffsetPI = typeof(EntityProperty).FindProperty("DateTimeOffsetValue");
                    EntityProperty_DoublePI = typeof(EntityProperty).FindProperty("DoubleValue");
                    EntityProperty_GuidPI = typeof(EntityProperty).FindProperty("GuidValue");
                    EntityProperty_Int32PI = typeof(EntityProperty).FindProperty("Int32Value");
                    EntityProperty_Int64PI = typeof(EntityProperty).FindProperty("Int64Value");
                    EntityProperty_PropTypePI = typeof(EntityProperty).FindProperty("PropertyType");
                    EntityProperty_PropTypeGetter = EntityProperty_PropTypePI.FindGetProp();

#if WINDOWS_RT
                    EntityPropertyIsNullInfo = typeof(EntityProperty).GetRuntimeProperties().First((m) => m.Name == "IsNull").GetMethod;
#else
                    EntityPropertyIsNullInfo = typeof(EntityProperty).FindProperty("IsNull").GetGetMethod(true);
#endif
                }

                disableCompiledSerializers = value;
            }
        }

        private static volatile bool disableCompiledSerializers = false;

        /// <summary>
        /// This entities compiled Write Func
        /// </summary>
        internal WriteFunc CompiledWrite { get; set; }

        /// <summary>
        /// This entities compiled Read Action
        /// </summary>
        internal ReadAction CompiledRead { get; set; }

        /// <summary>
        /// Compiles a ReadAction for the given type
        /// </summary>
        /// <param name="type">The type to compile for</param>
        /// <returns>A ReadAction that deserializes the given entity type.</returns>
        private static ReadAction CompileReadAction(Type type)
        {
#if WINDOWS_RT
            IEnumerable<PropertyInfo> objectProperties = type.GetRuntimeProperties();
#else
            IEnumerable<PropertyInfo> objectProperties = type.GetProperties();
#endif
            ParameterExpression instanceParam = Expression.Parameter(typeof(object), "instance");
            ParameterExpression ctxParam = Expression.Parameter(typeof(OperationContext), "ctx");
            ParameterExpression dictVariable = Expression.Parameter(typeof(IDictionary<string, EntityProperty>), "dict");
            ParameterExpression tempProp = Expression.Variable(typeof(EntityProperty), "entityProp");
            ParameterExpression propName = Expression.Variable(typeof(string), "propName");

            List<Expression> exprs = new List<Expression>();
            foreach (PropertyInfo prop in objectProperties.Where(p => !ShouldSkipProperty(p, null /* OperationContext */)))
            {
                Expression readExpr = GeneratePropertyReadExpressionByType(type, prop, instanceParam, tempProp);

                if (readExpr != null)
                {
                    exprs.Add(Expression.Assign(propName, Expression.Constant(prop.Name)));
                    exprs.Add(Expression.Assign(tempProp, Expression.Call(GetKeyOrNullFromDictionaryMethodInfo, propName, dictVariable, ctxParam)));

                    exprs.Add(

                            // If property is not null
                            Expression.IfThen(Expression.NotEqual(tempProp, Expression.Constant(null)),

                            // then if prop.Isnull, objProp.SetValue(null)
                            Expression.IfThenElse(Expression.Call(tempProp, EntityPropertyIsNullInfo),

                            // then
                            Expression.Call(Expression.Convert(instanceParam, type), prop.FindSetProp(), Expression.Convert(Expression.Constant(null), prop.PropertyType)),

                            // else set entity property based on type
                           readExpr)));
                }
            }

            // If no additional property expressions were added return a no op lambda
            if (exprs.Count == 0)
            {
                return TableEntity.ReadNoOpAction;
            }

            var lambda = Expression.Lambda<Action<object, OperationContext, IDictionary<string, EntityProperty>>>(
            Expression.Block(new[] { tempProp, propName }, exprs),
                new[] { instanceParam, ctxParam, dictVariable });

            return lambda.Compile();
        }

        /// <summary>        
        /// Compiles a WriteFunc for the given type
        /// </summary>
        /// <param name="type">The type to compile for</param>
        /// <returns>A WriteFunc that serializes the given entity type.</returns>
        private static WriteFunc CompileWriteFunc(Type type)
        {
#if WINDOWS_RT
            IEnumerable<PropertyInfo> objectProperties = type.GetRuntimeProperties();
#else
            IEnumerable<PropertyInfo> objectProperties = type.GetProperties();
#endif
            ParameterExpression instanceParam = Expression.Parameter(typeof(object), "instance");
            ParameterExpression ctxParam = Expression.Parameter(typeof(OperationContext), "ctx");
            ParameterExpression tempProp = Expression.Variable(typeof(EntityProperty), "entityProp");
            ParameterExpression propName = Expression.Variable(typeof(string), "propName");
            ParameterExpression dictVar = Expression.Variable(typeof(Dictionary<string, EntityProperty>), "dictVar");

            List<Expression> exprs = new List<Expression>();

            // Dict = new Dictionary<string, EntityProperty>();
            exprs.Add(Expression.Assign(dictVar, Expression.New(typeof(Dictionary<string, EntityProperty>))));

            foreach (PropertyInfo prop in objectProperties.Where(p => !ShouldSkipProperty(p, null /* OperationContext */)))
            {
                exprs.Add(Expression.Assign(tempProp, Expression.Call(EntityProperty_CreateFromObjectMethodInfo,
                                                     Expression.Convert(Expression.Call(Expression.Convert(instanceParam, type), prop.FindGetProp()), typeof(object)),
                                                     Expression.Constant(prop.PropertyType))));

                exprs.Add(Expression.Assign(propName, Expression.Constant(prop.Name)));

                // if tempprop!=null dict.Add(propName, Prop);
                exprs.Add(Expression.IfThen(Expression.NotEqual(tempProp, Expression.Constant(null)), Expression.Call(dictVar, DictionaryAddMethodInfo, propName, tempProp)));
            }

            // If no additional property expressions were added return a no op lambda
            if (exprs.Count == 1)
            {
                return TableEntity.WriteNoOpFunc;
            }

            // return dictionary
            exprs.Add(dictVar);

            var finalLambdaExpr = Expression.Lambda<Func<object, OperationContext, Dictionary<string, EntityProperty>>>(Expression.Block(new[] { dictVar, tempProp, propName }, exprs), new[] { instanceParam, ctxParam });
            return finalLambdaExpr.Compile();
        }

        /// <summary>
        /// Generates a Conditional Expression that will retrieve the given entity value by type and set it into the current property. 
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <param name="property">The property to deserialize into</param>
        /// <param name="instanceParam">An Expression that represents the entity instance</param>
        /// <param name="currentEntityProperty">An Expression that represents the current EntityProperty expression</param>
        /// <returns></returns>
        private static Expression GeneratePropertyReadExpressionByType(Type type, PropertyInfo property, Expression instanceParam, Expression currentEntityProperty)
        {
            if (property.PropertyType == typeof(string))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.String)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_StringPI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(byte[]))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Binary)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_BinaryPI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(bool?))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Boolean)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_BoolPI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(bool))
            {
                MethodInfo hasValuePI = typeof(bool?).FindProperty("HasValue").FindGetProp();
                MethodInfo valuePI = typeof(bool?).FindProperty("Value").FindGetProp();
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Boolean)),
                    Expression.IfThen(Expression.IsTrue(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_BoolPI.FindGetProp()), hasValuePI)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_BoolPI.FindGetProp()), valuePI))));
            }
            else if (property.PropertyType == typeof(DateTime?))
            {
                MethodInfo hasValuePI = typeof(DateTimeOffset?).FindProperty("HasValue").FindGetProp();
                MethodInfo valuePI = typeof(DateTimeOffset?).FindProperty("Value").FindGetProp();
                MethodInfo utcDateTimePI = typeof(DateTimeOffset).FindProperty("UtcDateTime").FindGetProp();

                ParameterExpression tempVal = Expression.Variable(typeof(DateTime?), "tempVal");
                ConditionalExpression valToSetExpr = Expression.IfThenElse(

                  // entityProperty.DateTimeOffsetValue.HasValue                   
                  Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_DateTimeOffsetPI.FindGetProp()), hasValuePI),

                  // then //entityProperty.DateTimeOffsetValue.Value.UtcDateTime   
                  Expression.Assign(tempVal, Expression.TypeAs(Expression.Call(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_DateTimeOffsetPI.FindGetProp()), valuePI), utcDateTimePI), typeof(DateTime?))),

                  // else
                  Expression.Assign(tempVal, Expression.TypeAs(Expression.Constant(null), typeof(DateTime?))));

                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.DateTime)),
                            Expression.Block(new[] { tempVal },
                            valToSetExpr,
                            Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), tempVal)));
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                MethodInfo valuePI = typeof(DateTimeOffset?).FindProperty("Value").FindGetProp();
                MethodInfo utcDateTimePI = typeof(DateTimeOffset).FindProperty("UtcDateTime").FindGetProp();

                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.DateTime)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(),

                // entityProperty.DateTimeOffsetValue.Value.UtcDateTime   
                Expression.Call(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_DateTimeOffsetPI.FindGetProp()), valuePI), utcDateTimePI)));
            }
            else if (property.PropertyType == typeof(DateTimeOffset?))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.DateTime)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_DateTimeOffsetPI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(DateTimeOffset))
            {
                MethodInfo hasValuePI = typeof(DateTimeOffset?).FindProperty("HasValue").FindGetProp();
                MethodInfo valuePI = typeof(DateTimeOffset?).FindProperty("Value").FindGetProp();

                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.DateTime)),
                       Expression.IfThen(Expression.IsTrue(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_DateTimeOffsetPI.FindGetProp()), hasValuePI)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_DateTimeOffsetPI.FindGetProp()), valuePI))));
            }
            else if (property.PropertyType == typeof(double?))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Double)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_DoublePI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(double))
            {
                MethodInfo hasValuePI = typeof(double?).FindProperty("HasValue").FindGetProp();
                MethodInfo valuePI = typeof(double?).FindProperty("Value").FindGetProp();

                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Double)),
                     Expression.IfThen(Expression.IsTrue(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_DoublePI.FindGetProp()), hasValuePI)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_DoublePI.FindGetProp()), valuePI))));
            }
            else if (property.PropertyType == typeof(Guid?))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Guid)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_GuidPI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(Guid))
            {
                MethodInfo hasValuePI = typeof(Guid?).FindProperty("HasValue").FindGetProp();
                MethodInfo valuePI = typeof(Guid?).FindProperty("Value").FindGetProp();

                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Guid)),
                     Expression.IfThen(Expression.IsTrue(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_GuidPI.FindGetProp()), hasValuePI)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_GuidPI.FindGetProp()), valuePI))));
            }
            else if (property.PropertyType == typeof(int?))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Int32)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_Int32PI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(int))
            {
                MethodInfo hasValuePI = typeof(int?).FindProperty("HasValue").FindGetProp();
                MethodInfo valuePI = typeof(int?).FindProperty("Value").FindGetProp();

                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Int32)),
                     Expression.IfThen(Expression.IsTrue(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_Int32PI.FindGetProp()), hasValuePI)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_Int32PI.FindGetProp()), valuePI))));
            }
            else if (property.PropertyType == typeof(long?))
            {
                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Int64)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(currentEntityProperty, EntityProperty_Int64PI.FindGetProp())));
            }
            else if (property.PropertyType == typeof(long))
            {
                MethodInfo hasValuePI = typeof(long?).FindProperty("HasValue").FindGetProp();
                MethodInfo valuePI = typeof(long?).FindProperty("Value").FindGetProp();

                return Expression.IfThen(Expression.Equal(Expression.Call(currentEntityProperty, EntityProperty_PropTypeGetter), Expression.Constant(EdmType.Int64)),
                     Expression.IfThen(Expression.IsTrue(Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_Int64PI.FindGetProp()), hasValuePI)),
                Expression.Call(Expression.Convert(instanceParam, type), property.FindSetProp(), Expression.Call(Expression.Call(currentEntityProperty, EntityProperty_Int64PI.FindGetProp()), valuePI))));
            }

            return null;
        }

        /// <summary>
        /// Gets the EntityProperty from the dictionary, or returns null. Similar to IDictionary.TryGetValue with logging support.
        /// </summary>
        /// <param name="key">The key value</param>
        /// <param name="dict">The Dictionary instance</param>
        /// <param name="operationContext">The operationContext to log to.</param>
        /// <returns></returns>
        private static EntityProperty GetValueByKeyFromDictionary(string key, IDictionary<string, EntityProperty> dict, OperationContext operationContext)
        {
            EntityProperty retProp;
            dict.TryGetValue(key, out retProp);

            if (retProp == null)
            {
                Logger.LogInformational(operationContext, SR.TraceMissingDictionaryEntry, key);
            }

            return retProp;
        }
#endif
        #endregion
    }
}
