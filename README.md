# ExpressionEvaluator

Simple expression evaluator for C#

# Getting Started

1. Install Nuget package `ExpressionEvaluator`
2. Sample code
```
// Returns 5
object result1 = ExpressionEvaluator.Evaluate("1 + 2 * 2*");

// Returns false
object result2 = ExpressionEvaluator.Evaluate("false and true");
```

# .NET Support

* Current Release: .NET Framework 4.x
* Future release: .NET Core (.NET Standard Library)

# Options

## Specify Return Type

Sample code
```
// Returns 5
int result1 = ExpressionEvaluator.Evaluate<int>("1 + 2 * 2*");

// Returns false
bool result2 = ExpressionEvaluator.Evaluate<bool>("false and true");
```

## Specify Operator Mapping

TBD