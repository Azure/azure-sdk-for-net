﻿namespace CodeGenerationLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjectModelTypeData
    {
        private const string ParentBatchClientTypeName = "BatchClient";
        private const string ParentBatchClientConstructorParameterName = "parentBatchClient";
        private const string BaseBehaviorsTypeName = "IEnumerable<BatchClientBehavior>";
        private const string BaseBehaviorsConstructorParameterName = "baseBehaviors";

        public ObjectModelTypeData()
        {
            this.Properties = new List<KeyValuePair<PropertyData, PropertyData>>();
            this.ParentPathVariables = new List<string>();
            this.CustomIncludes = new List<string>();

            this.IsConstructorPublic = true; //Default is public visibility
        }

        /// <summary>
        /// Collection of includes which every object model type uses.
        /// </summary>
        private static readonly IReadOnlyList<string> UniversalIncludes = new List<string>
            {
                "System",
                "System.Collections.Generic",
                "System.Linq",
                "Models = Microsoft.Azure.Batch.Protocol.Models"
            };

        /// <summary>
        /// Gets or sets the object model type name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the protocol type name.
        /// </summary>
        public string ProtocolName { get; set; }

        /// <summary>
        /// Gets or sets the protocol type used by GetTransportObject.
        /// </summary>
        public string TransportProtocolName { get; set; }

        /// <summary>
        /// Gets or sets the comment for the object model type.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if this type is used in collections and should have the
        /// collection converters generated.
        /// </summary>
        public bool IsUsedInCollections { get; set; }

        /// <summary>
        /// Gets a value indicating if this type is statically read only. A statically read
        /// only type has properties which do not have any setters.
        /// </summary>
        public bool IsStaticallyReadOnly => this.Properties.All(kvp => !kvp.Key.HasPublicSetter);

        /// <summary>
        /// Gets or sets a value indicating if the constructor of this type is public.
        /// </summary>
        public bool IsConstructorPublic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the constructor parameter order should be as written in
        /// the metadata file instead of alphabetic.
        /// </summary>
        public bool ForceConstructorOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the custom constructor should be hidden no matter what.
        /// </summary>
        public bool HideCustomConstructor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if this type is a "top level" object. For example top level objects
        /// include job, job schedule, certificate.
        /// </summary>
        public bool IsTopLevelObject { get; set; }

        /// <summary>
        /// Gets or sets the parent path variables for this type. These generate some additional private
        /// properties in top level objects.
        /// </summary>
        public List<string> ParentPathVariables { get; set; }

        /// <summary>
        /// Gets or sets a list of custom includes to be added to the set of universal includes.
        /// </summary>
        public List<string> CustomIncludes { get; set; }

        /// <summary>
        /// Gets a collection of includes that are used by this object model type.
        /// </summary>
        public IEnumerable<string> Includes => UniversalIncludes.Union(this.CustomIncludes).OrderBy(str => str);

        /// <summary>
        /// Gets a mapping of OM properties to protocol properties. Protocol type can be null in which case the default property mapper (same name, same type) will be used.
        /// </summary>
        public List<KeyValuePair<PropertyData, PropertyData>> Properties { get; set; }

        /// <summary>
        /// Gets a mapping of OM properties to protocol properties that are public.
        /// </summary>
        public List<KeyValuePair<PropertyData, PropertyData>> PublicProperties =>
            this.Properties.Where(kvp => !kvp.Key.IsOutsidePropertyContainer).ToList();

        /// <summary>
        /// Gets a mapping of properties ordered by property name.
        /// </summary>
        public List<KeyValuePair<PropertyData, PropertyData>> OrderedPublicProperties => this.PublicProperties.OrderBy(kvp => kvp.Key.Name).ToList();

        /// <summary>
        /// Gets a mapping of properties that are outside the property container.  This is used for example for properties like ParentBatchClient.
        /// </summary>
        public List<KeyValuePair<PropertyData, PropertyData>> OutsidePropertyContainerProperties =>
            this.Properties.Where(p => p.Key.IsOutsidePropertyContainer).ToList();

        /// <summary>
        /// Gets a mapping of properties which are retrieved from the underlying protocol object.
        /// </summary>
        public List<KeyValuePair<PropertyData, PropertyData>> BoundProperties =>
            this.OrderedPublicProperties.Where(kvp => kvp.Key.BoundAccess != BindingAccess.None && !kvp.Key.IsClientOnly).ToList();

        /// <summary>
        /// Gets a mapping of properties which can be set on the underlying protocol object.
        /// </summary>
        public List<KeyValuePair<PropertyData, PropertyData>> UnboundProperties =>
            this.OrderedPublicProperties.Where(kvp => kvp.Key.UnboundAccess != BindingAccess.None).ToList();

        /// <summary>
        /// Gets a collection of properties which are used in the constructor of this type.
        /// </summary>
        /// <value>A collection of properties used in the constructor of this type.</value>
        public IEnumerable<PropertyData> ConstructorProperties
        {
            get
            {
                var properties = this.ForceConstructorOrder ? this.Properties : this.OrderedPublicProperties;
                IEnumerable<PropertyData> realProperties = properties.Select(kvp => kvp.Key)
                    .Where(p => p.ConstructorArgumentType != ConstructorArgumentType.None)
                    .OrderBy(p => p.ConstructorArgumentType == ConstructorArgumentType.Optional);

                if (this.IsTopLevelObject)
                {
                    IEnumerable<PropertyData> topLevelObjectProperties = new List<PropertyData>
                        {
                            new PropertyData
                                {
                                    Name = ParentBatchClientConstructorParameterName,
                                    Type = ParentBatchClientTypeName,
                                    SummaryComment = "The parent <see cref=\"BatchClient\"/> to use.",
                                    ConstructorArgumentType = ConstructorArgumentType.Required,
                                    IsOutsidePropertyContainer = true
                                },
                            new PropertyData
                                {
                                    Name = BaseBehaviorsConstructorParameterName,
                                    Type = BaseBehaviorsTypeName,
                                    SummaryComment = "The base behaviors to use.",
                                    ConstructorArgumentType = ConstructorArgumentType.Required,
                                    IsOutsidePropertyContainer = true,
                                    SkipPropertyAssignment = true,
                                    AdditionalPropertyInitializationStatement = "InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, baseBehaviors);"
                                },
                        };

                    IEnumerable<PropertyData> parentPathVariableProperties = this.ParentPathVariables.Select(
                        parentPathVariable => new PropertyData()
                        {
                            Name = parentPathVariable,
                            Type = "string",
                            SummaryComment = "The " + parentPathVariable + ".",
                            ConstructorArgumentType = ConstructorArgumentType.Required,
                            IsOutsidePropertyContainer = true
                        });

                    topLevelObjectProperties = topLevelObjectProperties.Union(parentPathVariableProperties);

                    realProperties = topLevelObjectProperties.Union(realProperties);
                }

                return realProperties;
            }
        }

        /// <summary>
        /// Gets a value indicating if this type should define a custom constructor.
        /// </summary>
        public bool ShouldDefineCustomConstructor => (this.ConstructorProperties.Any() || this.IsConstructorPublic) && !this.HideCustomConstructor;

        /// <summary>
        /// Gets a value indicating if this type should define a GetTransportObject method and implement the corresponding interface.
        /// In cases where the type is never serialized back to the server, GetTransportObject and the corresponding interface are not
        /// needed.
        /// </summary>
        public bool ShouldDefineGetTransportObject => this.Properties.Select(kvp => kvp.Key).Any(
                p => p.BoundAccess.HasFlag(BindingAccess.Write) || p.UnboundAccess.HasFlag(BindingAccess.Write));

        /// <summary>
        /// Gets the name of the transport type (used in the GetTransportObject method).
        /// </summary>
        public string TransportObjectTypeName => string.IsNullOrEmpty(this.TransportProtocolName) ? this.ProtocolName : this.TransportProtocolName;

        /// <summary>
        /// Gets this types constructor visibility string.
        /// </summary>
        public string ConstructorVisibilityString => this.IsConstructorPublic ? "public" : "internal";

        /// <summary>
        /// Gets the custom constructors parameter string.
        /// </summary>
        /// <param name="spacesIndented">The number of spaces to indent.</param>
        /// <returns>The custom constructors parameter string.</returns>
        public string GetCustomConstructorParametersString(int spacesIndented)
        {
            //Extract required constructor parameters
            var requiredProperties = this.ConstructorProperties.Where(p => p.ConstructorArgumentType == ConstructorArgumentType.Required);
            var optionalProperties = this.ConstructorProperties.Where(p => p.ConstructorArgumentType == ConstructorArgumentType.Optional);

            List<string> argumentStrings = new List<string>();

            foreach (PropertyData requiredProperty in requiredProperties)
            {
                argumentStrings.Add(string.Format("{0} {1}", requiredProperty.Type, requiredProperty.CamelName));
            }

            foreach (PropertyData optionalProperty in optionalProperties)
            {
                argumentStrings.Add(string.Format("{0} {1} = default({0})", optionalProperty.Type, optionalProperty.CamelName));
            }

            return GenerateConstructorParameterString(argumentStrings, spacesIndented);
        }

        /// <summary>
        /// Gets the bound constructors parameter string
        /// </summary>
        /// <param name="spacesIndented">The number of spaces to indent.</param>
        /// <returns>The bound constructors parameter string.</returns>
        public string GetBoundConstructorParameterString(int spacesIndented)
        {
            string result = this.ProtocolName + " protocolObject";
            if (this.IsTopLevelObject)
            {
                List<string> parameters = new List<string>();
                parameters.Add(string.Format("{0} {1}", ParentBatchClientTypeName, ParentBatchClientConstructorParameterName));
                foreach (string parentPathVariable in this.ParentPathVariables)
                {
                    parameters.Add(string.Format("string {0}", parentPathVariable));
                }
                parameters.Add(result);
                parameters.Add(string.Format("{0} {1}", BaseBehaviorsTypeName, BaseBehaviorsConstructorParameterName));

                result = GenerateConstructorParameterString(parameters, spacesIndented);
            }

            return result;
        }

        /// <summary>
        /// Gets the additional property initialization statements
        /// </summary>
        public IEnumerable<string> AdditionalPropertyInitializationStatements =>
            this.ConstructorProperties.Where(p => !string.IsNullOrEmpty(p.AdditionalPropertyInitializationStatement)).Select(p => p.AdditionalPropertyInitializationStatement);

        /// <summary>
        /// Generates a string containing the specified arguments one per line, indented by the specified number of spaces. So a collection of arguments "string foo" and "int bar" would
        /// become: "\r\nstring foo,\r\nint bar".
        /// </summary>
        private static string GenerateConstructorParameterString(List<string> arguments, int spacesIndented)
        {
            if (!arguments.Any())
            {
                return string.Empty;
            }
            const string separator = ",";
            string prefix = Environment.NewLine + Spaces(spacesIndented);

            IEnumerable<string> argumentsWithPrefix = arguments.Select(arg => prefix + arg);
            string argumentsString = string.Join(separator, argumentsWithPrefix);

            return argumentsString;
        }

        private static string Spaces(int spaces)
        {
            return new string(' ', spaces);
        }
    }
}
