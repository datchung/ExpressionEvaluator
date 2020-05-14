# ExpressionEvaluator

Simple expression evaluator for C#

# Getting Started

1. Install via nuget: `ExpressionEvaluatorCs` https://www.nuget.org/packages/ExpressionEvaluatorCs/
2. Sample code
```c#
// Returns 6
var result1 = ExpressionEvaluator.Evaluate("(1 + 2) * 2");

// Returns false
var result2 = ExpressionEvaluator.Evaluate("false and true");
```

For more samples, see [ExpressionEvaluatorTest.cs](../master/src/ExpressionEvaluator.Test/ExpressionEvaluatorTEst.cs)

# Why Use This Library?

* Lightweight. Single DLL < 10kb and no third party library dependencies
* Easy to get started and use
* Customization options
* Supports older .NET Framework versions

# .NET Support

* Current Release: .NET Framework 4
* Future release: .NET Core (.NET Standard Library)

# Expression Support

* And
* False
* Not
* Or
* True

# Operator Support

* <
* \>
* <=
* \>=
* <>
* =
* \+
* \-
* \*
* \/
* %

# Options

## Specify Return Type

Sample code
```c#
// Returns 6
int result1 = ExpressionEvaluator.Evaluate<int>("(1 + 2) * 2");

// Returns false
bool result2 = ExpressionEvaluator.Evaluate<bool>("false and true");
```

## Specify Operator Mapping

Sample code
```c#
ExpressionEvaluator.SetOperatorMap(new Dictionary<string, string>
{
    {"and", "&&"},
    {"or", "||"},
    {"not", "!" },
    {"<>", "!=" },
    {"true", "1" },
    {"false", "0" }
});

// Returns false
bool result = ExpressionEvaluator.Evaluate<bool>("0 && !1");
```

```c#
ExpressionEvaluator.SetOperatorMap(new Dictionary<string, string>
{
    {"+", "plus"},
    {"*", "times"},
    {"/", "divideBy"},
});

// Returns 6
bool result = ExpressionEvaluator.Evaluate<int>("(1 plus 2) times 2");
```