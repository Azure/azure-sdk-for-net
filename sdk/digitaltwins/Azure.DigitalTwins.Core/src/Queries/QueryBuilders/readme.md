### ADT Query Builder Instructions for Use

The ADT query builder allows for fast and intelligent query building in the [Azure Digital Twins Query Language](https://docs.microsoft.com/azure/digital-twins/concepts-query-language) a SQL-like query language used to get information about digital twins and relationships that they may contain. When building a query, the place to start is with an `AdtQueryBuilder()` object. From this point, the induvidual components of the query (called clauses) are added one by one using fluent-style syntax. An example query resembles the following:

``` C# Snippet
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
    * Adds the `Count` aggregate (LINK) `(SELECT COUNT() FROM ... )`
* `SelectCustom()`
    * Provides the option for custom written select clauses. `(SELECT("Top(3) Temperature") FROM...)`

#### From Clauses

After a select clause, the collection that the query is acting upon must be specified. This is done with a `From` clause, which requires an argument that specifies a queryable collection:

``` C# Snippet
From(AdtCollection.DigitalTwins)
From(AdtCollection.Relationships)
```

Queryable collections are specified in the `AdtCollection` enum to provide finite options in an autocompletable format to speed up the process of writing a query.

#### Where Clauses

Though `Where` is technically a single clause (as [defined in the ADT query language](https://docs.microsoft.com/azure/digital-twins/reference-query-clause-where)), it is broken up into two pieces in the `AdtQueryBuilder` -- `WhereStatement` and `WhereLogic`.

A `WhereStatement` is simply a method that denotes that some kind of `Where` clause needs to be added to the query being built (i.e. that the query doesn't just end after the `From` clause), and reads just like the `Where` keyword during the query building process.

`new AdtQueryBuilder.SelectAll().From(...)`**`Where()`**.`SomeLogicalFunction().Build();`

`WhereLogic`, on the other hand contains the logical expression(s) in a query's `Where` clause. Examples of this include numerical comparisons and the use of functions in the ADT Query Language.

* `Compare`
    * Used to write conditions using [comparison operators](https://docs.microsoft.com/azure/digital-twins/reference-query-operators#comparison-operators).
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

``` C# Snippet
new AdtQueryBuilder()
.SelectAll()
.From(AdtCollection.DigitalTwins)
.Where()
.IsDefined("Temperature")
.Build();
```

To add more than one logical condition to a query, multiple `WhereLogic` objects are chained together with [Logical Operators](#logical-operators):

``` C# Snippet
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

``` C# Snippet
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

```
.Where()
.WhereLogic()
.And()
.WhereLogic()
.Or()
.WhereLogic()
.Build();
```

### Samples

### Ambiguities