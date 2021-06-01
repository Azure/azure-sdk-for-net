# Azure Cosmos DB client library for Python

Azure Cosmos DB is a globally distributed, multi-model database service that supports document, key-value, wide-column, and graph databases.

Use the Cosmos DB client library for Python to manage databases and the JSON documents they contain in this NoSQL database service:

* Create Cosmos DB databases and modify their settings
* Create and modify containers to store collections of JSON documents
* Create, read, update, and delete the items (JSON documents) in your containers
* Query the documents in your database using SQL-like syntax

  - [Package (PyPi)][pypi]
  - [API reference documentation][ref_cosmos_sdk]
  - [Product documentation][cosmos_docs]
  - [Source code](https://github.com/Azure/azure-sdk-for-python/tree/master/sdk/cosmos/azure-cosmos)
  - [ChangeLog](https://github.com/Azure/azure-sdk-for-python/blob/master/sdk/cosmos/azure-cosmos/CHANGELOG.md)
  - [Samples](https://github.com/Azure/azure-sdk-for-python/tree/master/sdk/cosmos/azure-cosmos/samples)
  - [Versioned API References](https://azure.github.io/azure-sdk-for-python/cosmosdb.html)

* Note, this library supports Cosmos API versions [2018-12-31](https://docs.microsoft.com/en-us/rest/api/cosmos-db/) and below.

## Getting started

### Install the package

Install the Azure Cosmos DB client library for Python with [pip][pip]:

```Bash
pip install azure-cosmos
```

**Prerequisites**: You must have an [Azure subscription][azure_sub], [Cosmos DB account][cosmos_account] (SQL API), and [Python 3.6+][python] to use this package.

If you need a Cosmos DB SQL API account, you can use the Azure [Cloud Shell][cloud_shell_bash] to create one with this Azure CLI command:

```Bash
az cosmosdb create --resource-group <resource-group-name> --name <cosmos-account-name>
```

### Authenticate the client

Interaction with Cosmos DB starts with an instance of the `CosmosClient` class. You need an **account**, its **URI**, and one of its **account keys** to instantiate the client object.

#### Get credentials

Use the [Azure CLI][azure_cli] snippet below to populate two environment variables with the database account URI and its primary master key (you can also find these values in the [Azure portal](https://portal.azure.com)). The snippet is formatted for the Bash shell.

```Bash
RES_GROUP=<resource-group-name>
ACCT_NAME=<cosmos-db-account-name>

export ACCOUNT_URI=$(az cosmosdb show --resource-group $RES_GROUP --name $ACCT_NAME --query documentEndpoint --output tsv)
export ACCOUNT_KEY=$(az cosmosdb list-keys --resource-group $RES_GROUP --name $ACCT_NAME --query primaryMasterKey --output tsv)
```

#### Create client

Once you've populated the `ACCOUNT_URI` and `ACCOUNT_KEY` environment variables, you can create the `CosmosClient`.

```Python
from azure.cosmos import HTTPFailure, CosmosClient, Container, Database, PartitionKey

import os
url = os.environ['ACCOUNT_URI']
key = os.environ['ACCOUNT_KEY']
client = CosmosClient(url, key)
```

## Key concepts

Once you've initialized a `CosmosClient`, you can interact with the primary resource types in Cosmos DB:

* Database: A Cosmos DB account can contain multiple databases. When you create a database, you specify the API you'd like to use when interacting with its documents: SQL, MongoDB, Gremlin, Cassandra, or Azure Table. Use the Database object to manage its containers.

* Container: A container is a collection of JSON documents. You create (insert), read, update, and delete items in a container by using methods on the Container object.

* Item: An Item is the dictionary-like representation of a JSON document stored in a container. Each Item you add to a container must include an `id` key with a value that uniquely identifies the item within the container.

For more information about these resources, see [Working with Azure Cosmos databases, containers and items][cosmos_resources].

## Examples

The following sections provide several code snippets covering some of the most common Cosmos DB tasks, including:

* [Create a database](#create-a-database)
* [Create a container](#create-a-container)
* [Insert data](#insert-data)
* [Query the database](#query-the-database)
* [Delete data](#delete-data)

### Create a database

After authenticating your `CosmosClient`, you can work with any resource in the account. The code snippet below creates a SQL API database, which is the default when no API is specified when create_database is invoked.

```Python
database_name = 'testDatabase'
try:
    database = client.create_database(id=database_name)
except HTTPFailure as e:
    if e.status_code != 409:
        raise
    database = client.get_database(id=database_name)
```

### Create a container

This example creates a container with default settings. If a container with the same name already exists in the database (generating a `409 Conflict` error), the existing container is obtained instead.

```Python
container_name = 'products'
try:
    container = database.create_container(id=container_name, partition_key=PartitionKey(path="/productName")
except HTTPFailure as e:
    if e.status_code != 409:
        raise
    container = database.get_container(container_name)
```

The preceding snippet also handles the HTTPFailure exception if the container creation failed. For more information on error handling and troubleshooting, see the [Troubleshooting](#troubleshooting) section.

### Insert data

To insert items into a container, pass a dictionary containing your data to Container.upsert_item. Each item you add to a container must include an `id` key with a value that uniquely identifies the item within the container.

This example inserts several items into the container, each with a unique `id`:

```Python
database = client.get_database(database_name)
container = database.get_container(container_name)

for i in range(1, 10):
    container.upsert_item(dict(
        id=f'item{i}',
        productName='Widget',
        productModel=f'Model {i}'
        )
    )
```

### Query the database

A Cosmos DB SQL API database supports querying the items in a container with Container.query_items using SQL-like syntax.

This example queries a container for items with a specific `id`:

```Python
database = client.get_database(database_name)
container = database.get_container(container_name)

# Enumerate the returned items
import json
for item in container.query_items(
                query='SELECT * FROM mycontainer r WHERE r.id="something"',
                enable_cross_partition_query=True):
    print(json.dumps(item, indent=True))
```

> NOTE: Although you can specify any value for the container name in the `FROM` clause, we recommend you use the container name for consistency.

Perform parameterized queries by passing a dictionary containing the parameters and their values to Container.query_items:

```Python
discontinued_items = container.query_items(
    query='SELECT * FROM products p WHERE p.productModel = @model',
    parameters=[
        dict(name='@model', value='DISCONTINUED')
    ],
    enable_cross_partition_query=True
)
for item in discontinued_items:
    print(json.dumps(item, indent=True))
```

For more information on querying Cosmos DB databases using the SQL API, see [Query Azure Cosmos DB data with SQL queries][cosmos_sql_queries].

### Delete data

To delete items from a container, use Container.delete_item. The SQL API in Cosmos DB does not support the SQL `DELETE` statement.

```Python
for item in container.query_items(query='SELECT * FROM products p WHERE p.productModel = "DISCONTINUED"'):
    container.delete_item(item, partition_key='Pager')
```

## Troubleshooting

### General

When you interact with Cosmos DB using the Python SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests:

[HTTP Status Codes for Azure Cosmos DB][cosmos_http_status_codes]

For example, if you try to create a container using an ID (name) that's already in use in your Cosmos DB database, a `409` error is returned, indicating the conflict. In the following snippet, the error is handled gracefully by catching the exception and displaying additional information about the error.

```Python
try:
    database.create_container(id=container_name, partition_key=PartitionKey(path="/productName")
except HTTPFailure as e:
    if e.status_code == 409:
        print("""Error creating container.
HTTP status code 409: The ID (name) provided for the container is already in use.
The container name must be unique within the database.""")
    else:
        raise
```

### Handle transient errors with retries

While working with Cosmos DB, you might encounter transient failures caused by [rate limits][cosmos_request_units] enforced by the service, or other transient problems like network outages. For information about handling these types of failures, see [Retry pattern][azure_pattern_retry] in the Cloud Design Patterns guide, and the related [Circuit Breaker pattern][azure_pattern_circuit_breaker].

## Next steps

### More sample code

Several Cosmos DB Python SDK samples are available to you in the SDK's GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Cosmos DB:

* [`examples.py`][sample_examples_misc] - Contains the code snippets found in this article.
* [`databasemanagementsample.py`][sample_database_mgmt] - Python code for working with Azure Cosmos DB databases, including:
  * Create database
  * Get database by ID
  * Get database by query
  * List databases in account
  * Delete database
* [`documentmanagementsample.py`][sample_document_mgmt] - Example code for working with Cosmos DB documents, including:
  * Create container
  * Create documents (including those with differing schemas)
  * Get document by ID
  * Get all documents in a container

### Additional documentation

For more extensive documentation on the Cosmos DB service, see the [Azure Cosmos DB documentation][cosmos_docs] on docs.microsoft.com.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_pattern_circuit_breaker]: https://docs.microsoft.com/azure/architecture/patterns/circuit-breaker
[azure_pattern_retry]: https://docs.microsoft.com/azure/architecture/patterns/retry
[azure_portal]: https://portal.azure.com
[azure_sub]: https://azure.microsoft.com/free/
[cloud_shell]: https://docs.microsoft.com/azure/cloud-shell/overview
[cloud_shell_bash]: https://shell.azure.com/bash
[cosmos_account_create]: https://docs.microsoft.com/azure/cosmos-db/how-to-manage-database-account
[cosmos_account]: https://docs.microsoft.com/azure/cosmos-db/account-overview
[cosmos_container]: https://docs.microsoft.com/azure/cosmos-db/databases-containers-items#azure-cosmos-containers
[cosmos_database]: https://docs.microsoft.com/azure/cosmos-db/databases-containers-items#azure-cosmos-databases
[cosmos_docs]: https://docs.microsoft.com/azure/cosmos-db/
[cosmos_http_status_codes]: https://docs.microsoft.com/rest/api/cosmos-db/http-status-codes-for-cosmosdb
[cosmos_item]: https://docs.microsoft.com/azure/cosmos-db/databases-containers-items#azure-cosmos-items
[cosmos_request_units]: https://docs.microsoft.com/azure/cosmos-db/request-units
[cosmos_resources]: https://docs.microsoft.com/azure/cosmos-db/databases-containers-items
[cosmos_sql_queries]: https://docs.microsoft.com/azure/cosmos-db/how-to-sql-query
[cosmos_ttl]: https://docs.microsoft.com/azure/cosmos-db/time-to-live
[pip]: https://pypi.org/project/pip/
[pypi]: https://pypi.org/project/azure-cosmos/
[python]: https://www.python.org/downloads/
[ref_cosmos_sdk]: https://azure.github.io/azure-sdk-for-python/cosmosdb.html#azure-cosmos
[sample_database_mgmt]: https://github.com/binderjoe/cosmos-python-prototype/blob/master/examples/databasemanagementsample.py
[sample_document_mgmt]: https://github.com/binderjoe/cosmos-python-prototype/blob/master/examples/documentmanagementsample.py
[sample_examples_misc]: https://github.com/binderjoe/cosmos-python-prototype/blob/master/examples/examples.py
[venv]: https://docs.python.org/3/library/venv.html
[virtualenv]: https://virtualenv.pypa.io
