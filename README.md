Tipos
=====

Tipos is a small value-object library inspired by https://github.com/mcintyre321/ValueOf, and it is an iteration on that idea with performance and AOT-friendly goals.

It gives you two ways to model strong IDs and domain types:

- **Base class**: `ValueOf<TValue, TThis>` for classic OOP value objects.
- **Source generator**: `[ValueOf<TValue>]` to generate high-performance `record struct` value objects.

Why use it
----------

- Make IDs and domain primitives explicit (`UserId` vs `int`).
- Centralize validation rules at construction time.
- Improve performance and reduce allocations with generated structs.
- Keep equality and `ToString()` consistent with the underlying value.

Base class usage
----------------

Create a value object by inheriting from `ValueOf<TValue, TThis>`:

```csharp
public sealed class UserId : ValueOf<int, UserId>
{
	protected override void Validate()
	{
		if (Value < 0)
		{
			throw new ArgumentException("Id cannot be negative", nameof(Value));
		}
	}
}

var id = UserId.From(42);
Console.WriteLine(id.Value); // 42
```

If you want a non-throwing validation path, override `TryValidate()`:

```csharp
public sealed class ClientRef : ValueOf<string, ClientRef>
{
	protected override bool TryValidate()
	{
		return !string.IsNullOrWhiteSpace(Value);
	}
}

if (ClientRef.TryFrom("ABC", out var valueObject))
{
	Console.WriteLine(valueObject.Value);
}
```

Source generator usage (record struct)
--------------------------------------

Use the generator to create allocation-free value objects:

```csharp
[ValueOf<int>]
public readonly partial record struct UserId
{
	static partial void Validate(int value)
	{
		if (value < 0)
		{
			throw new ArgumentException("Id cannot be negative", nameof(value));
		}
	}
}

var id = UserId.From(42);
```

Optional non-throwing validation hook:

```csharp
[ValueOf<string>]
public readonly partial record struct ClientRef
{
	static partial void TryValidate(string value, ref bool isValid, ref bool handled)
	{
		handled = true;
		isValid = !string.IsNullOrWhiteSpace(value);
	}
}

if (ClientRef.TryFrom("ABC", out var id))
{
	Console.WriteLine(id.Value);
}
```

Structured value types
----------------------

Generic attributes require metadata-friendly types. For complex data, wrap it in a named type:

```csharp
public readonly record struct AddressValue(string FirstLine, string SecondLine, string Postcode);

[ValueOf<AddressValue>]
public readonly partial record struct Address
{
}

var address = Address.From(new AddressValue("16 Food Street", "London", "N1 1LT"));
```

Performance notes
-----------------

- Generated `record struct` value objects avoid heap allocations for `From`/`TryFrom`.
- Class-based value objects allocate on creation but can be simpler for inheritance.
- `ToString()` cost is dominated by the underlying value type.

When to choose which
--------------------

- **Use the base class** when you need classic inheritance and reference semantics.
- **Use the generator** when you want the fastest path and value semantics.

License
-------

See LICENSE.
