# Roman Numeral Service
This repository contains a service that converts an integer to Roman numeral. For more detailed specification regarding the Roman numerals, please visit this [link](https://mathworld.wolfram.com/RomanNumerals.html). 

## Algorithm
The target integer is converted to Roman numeral using the following algorithm.

We look through the number array to find the largest symbol that fits into the target integer. We substract that number and continue looking for the largest symbol that fits into the remainder. We repeat the process until the remainder is 0. 

Each of the symbols we take out are appended onto the output Roman Numeral string.

## Run using Kestrel
Make sure that you have .NET 5.0 installed. If not, follow the instructions at this [link](https://docs.microsoft.com/en-us/dotnet/core/install/).

Clone the repository and switch to the source directory:
```sh
$ cd ./src/
```

Run the project:
```sh
$ dotnet run
```

## Test
Navigate to test directory:
```sh
$ cd ./test/
```

Run unit tests:
```sh
$ dotnet test .\RomanNumeralService.Test\
```

Run component tests
```sh
$ dotnet test .\RomanNumeralService.ComponentTest\
```

Run integration tests
```sh
$ dotnet test .\RomanNumeralService.IntegrationTest\
```

## Project Structure
```
roman-numeral-service
│   .gitattributes
│   .gitignore
│   README.md
│
├───src
│   │   Program.cs
│   │   Startup.cs
│   │   RomanNumeralService.csproj
│   │
│   ├───Controllers
│   │       RomanNumeralController.cs
│   │
│   ├───Converters
│   │   │   RomanNumeralConverter.cs
│   │   │
│   │   └───Abstractions
│   │           IRomanNumeralConverter.cs
│   │
│   ├───Models
│   │       RomanNumeralRequest.cs
│   │       RomanNumeralResponse.cs
│   │
│   ├───Properties
│   │       launchSettings.json
│   │
│   └───Validators
│           RomanNumeralRequestValidator.cs
│
└───test
    │   RomanNumeralServiceTest.csproj
    │
    ├───ComponentTests
    │       RomanNumeralControllerTests.cs
    │       RomanNumeralConverterTests.cs
    │
    └───IntegrationTests
            RomanNumeralControllerTests.cs
```
