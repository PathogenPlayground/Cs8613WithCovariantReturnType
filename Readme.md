This repository demonstrates a bug in the 05/14/18 C# [Nullable Reference Types Preview](https://github.com/dotnet/csharplang/wiki/Nullable-Reference-Types-Preview) with Visual Studio 2017 15.7.1. It corresponds to [dotnet/roslyn#27008](https://github.com/dotnet/roslyn/issues/27008).

# Project Setup

This project is somewhat similar to [PathogenPlayground/TestCs8614](https://github.com/PathogenPlayground/TestCs8614).

The solution consists of two assemblies:

* `ClassLibrary`
* `Cs8613WithCovariantReturnType`

`Cs8613WithCovariantReturnType` has a reference to `ClassLibrary`.

[`ClassLibrary.ITestClassCollection`](https://github.com/PathogenPlayground/Cs8613WithCovariantReturnType/blob/8f8b112eed3eb474e4f8b5fdbad8f4f2a775713e/ClassLibrary/ITestClassCollection.cs) defines the interface of a collection that can contain instances of [`IBaseInterface`](https://github.com/PathogenPlayground/Cs8613WithCovariantReturnType/blob/8f8b112eed3eb474e4f8b5fdbad8f4f2a775713e/ClassLibrary/IBaseInterface.cs) or `null`. [`Cs8613WithCovariantReturnType.TestClassCollection`](https://github.com/PathogenPlayground/Cs8613WithCovariantReturnType/blob/8f8b112eed3eb474e4f8b5fdbad8f4f2a775713e/Cs8613WithCovariantReturnType/TestClassCollection.cs) implements this interface, but internally it stores a list of [`Cs8613WithCovariantReturnType.TestClass`](https://github.com/PathogenPlayground/Cs8613WithCovariantReturnType/blob/8f8b112eed3eb474e4f8b5fdbad8f4f2a775713e/Cs8613WithCovariantReturnType/TestClass.cs) (an implementation of `IBaseInterface`) so the `GetEnumerator` is returning an `IEnumerator<TestClass?>` as a `IEnumerator<IBaseInterface?>`.

# Actual Behavior

The following warning is reported on `TestClassCollection.GetEnumerator`:

```
warning CS8613: Nullability of reference types in return type doesn't match implicitly implemented member 'IEnumerator<IBaseInterface> IEnumerable<IBaseInterface>.GetEnumerator()'.
```

# Expected Behavior

There should be no warnings.
