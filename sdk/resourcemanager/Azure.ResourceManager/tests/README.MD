# Azure ResourceManager Tests

To run test: ```dotnet test```

To run test with code coverage and auto generate an html report: ```dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura```

Coverage report will be placed in your path relative to azure-proto-core-test in```/coverage``` in html format for viewing

Reports can also be viewed VS or VsCode with the proper viewer plugin

A terse report will also be displayed on the command line when running. 


## run test with single file or test

To run test with code coverage and auto generate an html report with just a single test: ```dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura --filter <test-to-run>```
