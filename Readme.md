This repository demonstrates a bug in the 05/14/18 C# [Nullable Reference Types Preview](https://github.com/dotnet/csharplang/wiki/Nullable-Reference-Types-Preview) with Visual Studio 2017 15.7.1. It corresponds to `<TODO>`.

# Project Setup

This project is somewhat similar to [PathogenPlayground/TestCs8614](https://github.com/PathogenPlayground/TestCs8614).

The solution consists of two assemblies:

* `ClassLibrary`
* `Cs8613WithCovariantReturnType`

`Cs8613WithCovariantReturnType` has a reference to `ClassLibrary`.

`ClassLibrary.ITestClassCollection` defines the interface of a collection that can contain instances of `IBaseInterface` or `null`. `Cs8613WithCovariantReturnType.TestClassCollection` implements this interface, but internally it stores a list of `Cs8613WithCovariantReturnType.TestClass` (an implementation of `IBaseInterface`) so the `GetEnumerator` is returning an `IEnumerator<TestClass?>` as a `IEnumerator<IBaseInterface?>`.

# Actual Behavior

The following warning is reported on `TestClassCollection.GetEnumerator`:

```
warning CS8613: Nullability of reference types in return type doesn't match implicitly implemented member 'IEnumerator<IBaseInterface> IEnumerable<IBaseInterface>.GetEnumerator()'.
```

# Expected Behavior

There should be no warnings.
