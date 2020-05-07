# ExpressionEvaluator

Simple expression evaluator for C#

# Getting Started

1. Install via nuget: `ExpressionEvaluatorCs` https://www.nuget.org/packages/ExpressionEvaluatorCs/
2. Sample code
```
// Returns 6
object result1 = ExpressionEvaluator.Evaluate("(1 + 2) * 2");

// Returns false
object result2 = ExpressionEvaluator.Evaluate("false and true");
```

For more samples, see [ExpressionEvaluatorTest.cs](../blob/master/src/ExpressionEvaluator.Test/ExpressionEvaluatorTEst.cs)

# Why Use This Library?

* Lightweight
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
```
// Returns 6
int result1 = ExpressionEvaluator.Evaluate<int>("(1 + 2) * 2");

// Returns false
bool result2 = ExpressionEvaluator.Evaluate<bool>("false and true");
```

## Specify Operator Mapping

TBD