Feature: CodeGenerationVerification
	Code generator should be able to generate correct CSharp code
	There should proper mapping between Avro type and CSharp types
	The generated code should be handeled correctly by Avro serializer

@CheckIn
Scenario Outline: I can generate a proper CSharp type from Avro type having a default namespace
	Given I have a record schema with Parent.Namespace namespace containing only "<Avro Type>" field
	 When I generate CSharp code from the schema using a default namespace "Default.Namespace" and compile the generated code
	 Then the generated code is a class containing one field of the corresponding "<CSharp Type>"
	  And I can perform roundtrip serialization of a randomly created object of the generated class
	  And The serialized object should match the deserialized object and namespace of original schema should match namespace of serialized schema
	  Examples: 
| Avro Type                                                                     | CSharp Type                 |
#| ""null""                                                                      | Object                      |
| ""boolean""                                                                   | Boolean                     |
| ""int""                                                                       | Int32                       |
| ""long""                                                                      | Int64                       |
| ""float""                                                                     | Single                      |
| ""double""                                                                    | Double                      |
| ""string""                                                                    | String                      |
| ""bytes""                                                                     | Byte[]                      |
| "{"type": "enum", "name": "E", "namespace":"N", "symbols" : ["A", "B"]}"      | N.E                         |
| "{"type": "enum", "name": "E", "symbols" : ["A", "B"]}"                       | Parent.Namespace.E          |
| "{"type": "record", "name":"R", "namespace":"N"}"                             | N.R                         |
| "{"type": "record", "name":"R"}"                                              | Parent.Namespace.R          |
#| "{"type": "array", "items": "null"}"                                          | List<Object>                |
| "{"type": "array", "items": "boolean"}"                                       | IList<Boolean>               |
| "{"type": "array", "items": "int"}"                                           | IList<Int32>                 |
| "{"type": "array", "items": "long"}"                                          | IList<Int64>                 |
| "{"type": "array", "items": "float"}"                                         | IList<Single>                |
| "{"type": "array", "items": "double"}"                                        | IList<Double>                |
| "{"type": "array", "items": "string"}"                                        | IList<String>                |
| "{"type": "array", "items": "bytes"}"                                         | IList<Byte[]>                |
| "{"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}" | IList<N.R>                   |
#| "{"type": "map", "values": "null"}"                                           | Dictionary<String, Object>  |
| "{"type": "map", "values": "boolean"}"                                        | IDictionary<String, Boolean> |
| "{"type": "map", "values": "int"}"                                            | IDictionary<String, Int32>   |
| "{"type": "map", "values": "long"}"                                           | IDictionary<String, Int64>   |
| "{"type": "map", "values": "float"}"                                          | IDictionary<String, Single>  |
| "{"type": "map", "values": "double"}"                                         | IDictionary<String, Double>  |
| "{"type": "map", "values": "string"}"                                         | IDictionary<String, String>  |
| "{"type": "map", "values": "bytes"}"                                          | IDictionary<String, Byte[]>  |
| "{"type": "map", "values": {"type": "record", "name":"R", "namespace":"N"}}"  | IDictionary<String, N.R>     |
| "{"type": "fixed", "size": 10, "name":"F", "namespace":"N"}"                  | Byte[]                      |
| "{"type": "fixed", "size": 10, "name":"F"}"                                   | Byte[]                      |
| "["null", "boolean"]"                                                         | Nullable<Boolean>           |
| "["null", "int"]"                                                             | Nullable<Int32>             |
| "["null", "long"]"                                                            | Nullable<Int64>             |
| "["null", "float"]"                                                           | Nullable<Single>            |
| "["null", "double"]"                                                          | Nullable<Double>            |
| "["null", "string"]"                                                          | String                      |
| "["null", "bytes"]"                                                           | Byte[]                      |
| "["int", "null", "string"]"                                                   | Object                      |
# complex nesting types
| "{"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}"                             | IDictionary<String, IList<N.R>>       |
| "{"type": "array", "items": {"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}}" | IList<IDictionary<String, IList<N.R>>> |

@CheckIn
Scenario Outline: I can generate a proper CSharp type from Avro type having a forced namespace
	Given I have a record schema with Parent.Namespace namespace containing only "<Avro Type>" field
	 When I generate CSharp code from the schema using a forced namespace "Forced.Namespace" and compile the generated code
	 Then the generated code is a class containing one field of the corresponding "<CSharp Type>"
	  And I can perform roundtrip serialization of a randomly created object of the generated class
	  And The serialized object should match the deserialized object and namespace of original schema should match namespace of serialized schema
	  Examples: 
| Avro Type                                                                     | CSharp Type                             |
| "{"type": "enum", "name": "E", "namespace":"N", "symbols" : ["A", "B"]}"      | Forced.Namespace.E                      |
| "{"type": "enum", "name": "E", "symbols" : ["A", "B"]}"                       | Forced.Namespace.E                      |
| "{"type": "record", "name":"R", "namespace":"N"}"                             | Forced.Namespace.R                      |
| "{"type": "record", "name":"R"}"                                              | Forced.Namespace.R                      |
| "{"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}" | IList<Forced.Namespace.R>               |
| "{"type": "map", "values": {"type": "record", "name":"R", "namespace":"N"}}"  | IDictionary<String, Forced.Namespace.R> |
| "{"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}"                             | IDictionary<String, IList<Forced.Namespace.R>>       |
| "{"type": "array", "items": {"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}}" | IList<IDictionary<String, IList<Forced.Namespace.R>>> |

@CheckIn
Scenario Outline: I can generate a proper CSharp type from Avro type without having a namespace and using default namespace
	Given I have a record schema without namespace containing only "<Avro Type>" field
	 When I generate CSharp code from the schema using a default namespace "Default.Namespace" and compile the generated code
	 Then the generated code is a class containing one field of the corresponding "<CSharp Type>"
	  Examples: 
| Avro Type                                                                    | CSharp Type              |
| "{"type": "enum", "name": "E", "namespace":"N", "symbols" : ["A", "B"]}"     | N.E                      |
| "{"type": "enum", "name": "E", "symbols" : ["A", "B"]}"                      | Default.Namespace.E      |
| "{"type": "record", "name":"R", "namespace":"N"}"                            | N.R                      |
| "{"type": "record", "name":"R"}"                                             | Default.Namespace.R      |
| "{"type": "map", "values": {"type": "record", "name":"R", "namespace":"N"}}" | IDictionary<String, N.R> |

@CheckIn
Scenario Outline: I can generate a proper CSharp type from Avro type without having a namespace and using forced namespace
	Given I have a record schema without namespace containing only "<Avro Type>" field
	 When I generate CSharp code from the schema using a forced namespace "Forced.Namespace" and compile the generated code
	 Then the generated code is a class containing one field of the corresponding "<CSharp Type>"
	  Examples: 
| Avro Type                                                                    | CSharp Type                             |
| "{"type": "enum", "name": "E", "namespace":"N", "symbols" : ["A", "B"]}"     | Forced.Namespace.E                      |
| "{"type": "enum", "name": "E", "symbols" : ["A", "B"]}"                      | Forced.Namespace.E                      |
| "{"type": "record", "name":"R", "namespace":"N"}"                            | Forced.Namespace.R                      |
| "{"type": "record", "name":"R"}"                                             | Forced.Namespace.R                      |
| "{"type": "map", "values": {"type": "record", "name":"R", "namespace":"N"}}" | IDictionary<String, Forced.Namespace.R> |

@CheckIn
Scenario Outline: I can serialize generated types with default values with default namespace
	Given I have a record schema with Parent.Namespace namespace containing only "<Avro Type>" field
	 And the field has a default value "<Default Value>"
	 When I generate CSharp code from the schema using a default namespace "Default.Namespace" and compile the generated code
	 Then I can perform roundtrip serialization of an object of the generated class
	  And The serialized object should match the deserialized object and namespace of original schema should match namespace of serialized schema
Examples:
| Avro Type                                                                                                                            | Default Value                    |
| ""boolean""                                                                                                                          | "true"                           |
| ""int""                                                                                                                              | "10"                             |
| ""long""                                                                                                                             | "11"                             |
| ""float""                                                                                                                            | "12.1"                           |
| ""double""                                                                                                                           | "13.2"                           |
| ""string""                                                                                                                           | ""value1""                       |
| ""bytes""                                                                                                                            | ""\u00FF""                       |
| "{"type": "record", "name":"R", "namespace":"N"}"                                                                                    | "{}"                             |
| "{"type": "array", "items": "boolean"}"                                                                                              | "[true, false, false]"           |
| "{"type": "array", "items": "int"}"                                                                                                  | "[1,2,3]"                        |
| "{"type": "array", "items": "long"}"                                                                                                 | "[1,2,3]"                        |
| "{"type": "array", "items": "float"}"                                                                                                | "[1.1, 2.2, 3.2]"                |
| "{"type": "array", "items": "double"}"                                                                                               | "[1.1, 2.2, 3.2]"                |
| "{"type": "array", "items": "string"}"                                                                                               | "["value1", "value2", "value3"]" |
| "{"type": "array", "items": "bytes"}"                                                                                                | "["\u00FF", "\u00FF", "\u00FF"]" |
| "{"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}"                                                        | "[{}, {}, {}]"                   |
| "{"type": "map", "values": "boolean"}"                                                                                               | "{"value1": true}"               |
| "{"type": "map", "values": "int"}"                                                                                                   | "{"value1": 10}"                 |
| "{"type": "map", "values": "long"}"                                                                                                  | "{"value1": 11}"                 |
| "{"type": "map", "values": "float"}"                                                                                                 | "{"value1": 12.1}"               |
| "{"type": "map", "values": "double"}"                                                                                                | "{"value1": 13.1}"               |
| "{"type": "map", "values": "string"}"                                                                                                | "{"value1": "value2"}"           |
| "{"type": "map", "values": "bytes"}"                                                                                                 | "{"value1": "\u00FF"}"           |
| "{"type": "map", "values": {"type": "record", "name":"R", "namespace":"N"}}"                                                         | "{"value1": {}}"                 |
| "{"type": "fixed", "size": 1, "name":"F", "namespace":"N"}"                                                                          | ""\u00FF""                       |
| "["null", "boolean"]"                                                                                                                | "null"                           |
| "["null", "int"]"                                                                                                                    | "null"                           |
| "["long", "null"]"                                                                                                                   | "10"                             |
| "["null", "float"]"                                                                                                                  | "null"                           |
| "["null", "double"]"                                                                                                                 | "null"                           |
| "["null", "string"]"                                                                                                                 | "null"                           |
| "["null", "bytes"]"                                                                                                                  | "null"                           |
| "["null", {"type": "record", "name":"R", "namespace":"N"}]"                                                                          | "null"                           |
| "["null", "int", "long"]"                                                                                                            | "null"                           |
| "["int", "null", "long"]"                                                                                                            | "10"                             |
| "["null", "string", "bytes"]"                                                                                                        | "null"                           |
# nesting types
| "{"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}"                             | "{"value1": [{}, {}]}"           |
| "{"type": "array", "items": {"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}}" | "[{"value1": [{}, {}]}]"         |

@CheckIn
Scenario Outline: I can serialize generated types with default values with enforced namespace
	Given I have a record schema with Parent.Namespace namespace containing only "<Avro Type>" field
	 And the field has a default value "<Default Value>"
	 When I generate CSharp code from the schema using a forced namespace "Forced.Namespace" and compile the generated code
	 Then I can perform roundtrip serialization of an object of the generated class
	  And The serialized object should match the deserialized object and namespace of original schema should match namespace of serialized schema
Examples:
| Avro Type                                                                     | Default Value  |
| "{"type": "record", "name":"R", "namespace":"N"}"                             | "{}"           |
| "{"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}" | "[{}, {}, {}]" |
| "{"type": "map", "values": {"type": "record", "name":"R", "namespace":"N"}}"  | "{"value1": {}}"  |
| "["null", {"type": "record", "name":"R", "namespace":"N"}]"                   | "null"         |
# nesting types
| "{"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}"                             | "{"value1": [{}, {}]}"              |
| "{"type": "array", "items": {"type": "map", "values": {"type": "array", "items": {"type": "record", "name":"R", "namespace":"N"}}}}" | "[{"value1": [{}, {}]}]"            |