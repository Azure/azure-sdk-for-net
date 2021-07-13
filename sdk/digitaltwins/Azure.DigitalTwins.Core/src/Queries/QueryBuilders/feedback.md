### ADT Query Builder Instructions for Use

The ADT query builder allows for fast and intelligent query building in the [Azure Digital Twins Query Language](https://docs.microsoft.com/azure/digital-twins/concepts-query-language) a SQL-like query language used to get information about digital twins and relationships that they may contain. When building a query, the place to start is with an `AdtQueryBuilder()` object. From this point, the induvidual components of the query (called clauses) are added one by one using fluent-style syntax. An example query resembles the following:

``` C#
// SELECT * FROM DIGITALTWINS
new AdtQueryBuilder().SelectAll().From(AdtCollection.DigitalTwins).Build();
```

#### Select Clauses

In the simple query above, a `Select` method is called on the `AdtQueryBuilder` (in this case, the `SelectAll()` method). `Select` methods belong to a class called `SelectQuery` that outlines the different ways to add a `Select` clause to a query.

* `SelectAll()`
    * Used when selecting all `(SELECT * FROM ...)` from an ADT graph.
* `Select()`
    * Intended for selecting certain single or multiple "columns" `(SELECT Room, Temperature FROM ...)` from an ADT graph.
* `SelectTop()`
    * Adds the [Top aggreagate](https://docs.microsoft.com/azure/digital-twins/reference-query-clause-select#select-top) before selecting certain columns `(SELECT TOP(X) Room, Temperature FROM ...)` from an ADT graph.
* `SelectTopAll()`
    * Adds the [Top aggregate](https://docs.microsoft.com/azure/digital-twins/reference-query-clause-select#select-top) before selecting all.
* `SelectCount()`
    * Adds the [Count aggregate](https://docs.microsoft.com/azure/digital-twins/reference-query-clause-select#select-count) `(SELECT COUNT() FROM ... )`
* `SelectCustom()`
    * Provides the option for custom written select clauses. `(SELECT("Top(3) Temperature") FROM...)`

#### From Clauses

After a select clause, the collection that the query is acting upon must be specified. This is done with a `From` clause, which requires an argument that specifies a queryable collection:

``` C#
From(AdtCollection.DigitalTwins)
From(AdtCollection.Relationships)
FromCustom("DigitalTwins")
```

Queryable collections are specified in the `AdtCollection` enum to provide finite options in an autocompletable format to speed up the process of writing a query.

#### Where Clauses

Though `Where` is technically a single clause (as [defined in the ADT query language](https://docs.microsoft.com/azure/digital-twins/reference-query-clause-where)), it is broken up into two pieces in the `AdtQueryBuilder` -- `WhereStatement` and `WhereLogic`.

A `WhereStatement` is simply a method that denotes that some kind of `Where` clause needs to be added to the query being built (i.e. that the query doesn't just end after the `From` clause), and reads just like the `Where` keyword during the query building process.

``` C#
new AdtQueryBuilder.SelectAll().From(...)
.Where()
.SomeLogicalFunction().Build();
```
`WhereLogic`, on the other hand contains the logical expression(s) in a query's `Where` clause. Examples of this include numerical comparisons and the use of [functions](https://docs.microsoft.com/azure/digital-twins/reference-query-functions) in the ADT Query Language.

* `Compare`
    * Used to write conditions using [comparison operators](https://docs.microsoft.com/azure/digital-twins/reference-query-operators#comparison-operators). Comparison operators are denoted in the ADT Query Builder using the `QueryComparisonOperator` enum.
* `Contains` / `NotContains`
    * Used to write conditions using [contains operators](https://docs.microsoft.com/azure/digital-twins/reference-query-operators#contains-operators).
* `IsDefined`
    * Used in place of the [IS_DEFINED](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_defined) function in the ADT Query Language.
* `IsOfModel`
    * Used in place of the [IS_OF_MODEL](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_of_model) function in the ADT Query Language.
* `IsNull`
    * Used in place of the [IS_NULL](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_null) function in the ADT Query Language.
* `IsOfType`
    * Single method that encapsulates the [IS_BOOL](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_bool), [IS_NUMBER](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_number), [IS_STRING](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_string), [IS_PRIMATIVE](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_primative) and [IS_OBJECT](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_object) functions in the ADT Query Language.
* `StartsWith` / `EndsWith`
    * Used in place of the [STARTSWITH](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#startswith) AND [ENDSWITH](https://docs.microsoft.com/azure/digital-twins/reference-query-functions#endswith) functions in the ADT Query Language.
* `CustomClause`

A query with a single logical component could be written like the following:

``` C#
new AdtQueryBuilder()
.SelectAll()
.From(AdtCollection.DigitalTwins)
.Where()
.IsDefined("Temperature")
.Build();
```

To add more than one logical condition to a query, multiple `WhereLogic` objects are chained together with [Logical Operators](#logical-operators):

``` C#
new AdtQueryBuilder()
.SelectAll()
.From(AdtCollection.DigitalTwins)
.Where()
.IsDefined("Temperature")
.And()
.IsOfModel("dtmi:example:hvac;1")
.Build();
```

To nest multiple `WhereLogic` objects in parenthesis in order to create queries with complex logical conditions, the `Parenthetical` method is used:

``` C#
.Where()
.Parentheitcal(q => q
    .IsOfModel("dtmi:example:hvac;1")
    .Or()
    .Compare("Temperature", QueryComparisonOperator.Equal, 50))
.And()
.IsDefined("Humidity")
.Build();
```

`Parenthetical` uses [Lambda expressions](https://docs.microsoft.com/dotnet/csharp/language-reference/operators/lambda-expressions#:~:text=Lambda%20expressions%20%28C%23%20reference%29%201%20Expression%20lambdas.%20...,lambda%20expressions.%20...%209%20C%23%20language%20specification.%20) to reperesent nested logical conditions.

#### Logical Operators

When building a query that contains multiple `WhereLogic` components, [logical operators](https://docs.microsoft.com/azure/digital-twins/reference-query-operators#logical-operators) are used to chain them together. In the query builder, logical operators are represented with the `And()` and the `Or()` methods:

``` C#
.Where()
.WhereLogic()
.And()
.WhereLogic()
.Or()
.WhereLogic()
.Build();
```

#### Converting Queries into Strings

After calling `Build()` on a query to signify that the query is complete, it can be converted into a string by calling `GetQueryText()`:

```C# Snippet:DigitalTwinsQueryBuilderToString
string basicQueryStringFormat = new AdtQueryBuilder()
    .SelectAll()
    .From(AdtCollection.DigitalTwins)
    .Build()
    .GetQueryText();
```

### Samples

```C# Snippet:DigitalTwinsQueryBuilder
// SELECT * FROM DIGITALTWINS
AdtQueryBuilder simplestQuery = new AdtQueryBuilder().Select("*").From(AdtCollection.DigitalTwins).Build();

// SELECT * FROM DIGITALTWINS
// Note that the this is the same as the previous query, just with the prebuilt SelectAll() method that can be used
// interchangeably with Select("*")
AdtQueryBuilder simplestQuerySelectAll = new AdtQueryBuilder().SelectAll().From(AdtCollection.DigitalTwins).Build();

// SELECT TOP(3) FROM DIGITALTWINS
// Note that if no property is specfied, the SelectTopAll() method can be used instead of SelectTop()
AdtQueryBuilder queryWithSelectTop = new AdtQueryBuilder()
    .SelectTopAll(3)
    .From(AdtCollection.DigitalTwins)
    .Build();

// SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
AdtQueryBuilder queryWithSelectTopProperty = new AdtQueryBuilder()
    .SelectTop(3, "Temperature", "Humidity")
    .From(AdtCollection.DigitalTwins)
    .Build();

// SELECT COUNT() FROM RELATIONSHIPS
AdtQueryBuilder queryWithSelectRelationships = new AdtQueryBuilder()
    .SelectCount()
    .From(AdtCollection.Relationships)
    .Build();

// SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
AdtQueryBuilder queryWithIsOfModel = new AdtQueryBuilder()
    .Select("*")
    .From(AdtCollection.DigitalTwins)
    .Where()
    .IsOfModel("dtmi:example:room;1")
    .Build();
```

Clauses can also be manually overridden with strings:

```C# Snippet:DigitalTwinsQueryBuilderOverride
// SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
new AdtQueryBuilder()
.SelectCustom("TOP(3) Room, Temperature")
.From(AdtCollection.DigitalTwins)
.Build();
```

Examples of `Parenthetical` and `Logical Operators`:

```C# Snippet:DigitalTwinsQueryBuilder_ComplexConditions
// SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact) OR IS_NUMBER(Temperature)
AdtQueryBuilder logicalOps_MultipleOr = new AdtQueryBuilder()
    .SelectAll()
    .From(AdtCollection.DigitalTwins)
    .Where()
    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
    .Or()
    .IsOfModel("dtmi:example:room;1", true)
    .Or()
    .IsOfType("Temperature", AdtDataType.AdtNumber)
    .Build();

// SELECT * FROM DIGITALTWINS WHERE (IS_NUMBER(Humidity) OR IS_DEFINED(Humidity)) 
// OR (IS_OF_MODEL("dtmi:example:hvac;1") AND IS_NULL(Occupants))
AdtQueryBuilder logicalOpsNested = new AdtQueryBuilder()
    .SelectAll()
    .From(AdtCollection.DigitalTwins)
    .Where()
    .Parenthetical(q => q
        .IsOfType("Humidity", AdtDataType.AdtNumber)
        .Or()
        .IsDefined("Humidity"))
    .And()
    .Parenthetical(q => q
        .IsOfModel("dtmi:example:hvac;1")
        .And()
        .IsNull("Occupants"))
    .Build();
```

### Ambiguities

There are a few aspects of the query builder that could use feedback:

#### Naming Conventions
* **Parenthetical**
    * The `Parenthetical()` method has had several different names in the past:
        * `IsTrue()`
        * `Nested()`
        * `CompoundCondition()`
        * `CompoundPredicate()`
    * Naming suggestions that make the query readable and the method's purpose intutively understood would be very much appreciated.
* **Equal vs Equals**
    * There is a debate regarding the grammatical formatting of comparison operators under the `QueryComparisonOperator` enum. There are two options:
        * `Where().Compare("Temperature", QueryComparisonOperator.Equal, 50)...`
        * `Where().Compare("Temperature", QueryComparisonOperator.Equals, 50)...`
    * The disccussion regarding renaming this enum is based upon the way the query reads in the head of a user. Keeping that it mind, we would appreciate feedback on the peoples's natural ways to read a mathematical expression:
        * Temperature is **equal to** 50.
        * Temperature **equals** 50.

#### Design
* **Comparison Operators**
    * [Comparison operators](https://docs.microsoft.com/azure/digital-twins/reference-query-operators#comparison-operators) in the ADT query language are represented in the query builder using the `QueryComparisonOperator` enum. There is an ongoing discussion regarding how readable this and ways that it could be improved. Feedback and suggestions of alternatives to storing a finite list of comparison operators that can be suggested to a user would be greatly appreciated.
* **Implicit Logical Operators**
    * There is discussion regarding making the `And()` logical operator implicit between multiple `WhereLogic()` components. This would look like this:
    
``` C#
// SELECT * FROM DIGITALTWINS WHERE Temperature = 50 
// AND IS_OF_MODEL("dtmi:example:room;1", exact) 
// AND IS_NUMBER(Temperature)
AdtQueryBuilder logicalOps_implicitAnd = new AdtQueryBuilder()
    .SelectAll()
    .From(AdtCollection.DigitalTwins)
    .Where()
    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
    .IsOfModel("dtmi:example:room;1", true)
    .IsOfType("Temperature", AdtDataType.AdtNumber)
    .Build();
```

The `Or()` logical operator would still be explicity declared, as per other examples. Any feedback regarding the UX and readability of implicity defined `And()` operators would be greatly appreciated. 
