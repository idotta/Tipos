using Tipos;

namespace Tipos.Benchmarks;

public sealed class ClassUserId : ValueOf<int, ClassUserId>
{
    protected override void Validate()
    {
        if (Value < 0)
        {
            throw new ArgumentException("Id cannot be negative", nameof(Value));
        }
    }

    protected override bool TryValidate() => Value >= 0;
}

public sealed class ClassClientRef : ValueOf<string, ClassClientRef>
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Value cannot be null or empty", nameof(Value));
        }
    }

    protected override bool TryValidate() => !string.IsNullOrWhiteSpace(Value);
}

public sealed class ClassOrderId : ValueOf<Guid, ClassOrderId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Value cannot be empty", nameof(Value));
        }
    }

    protected override bool TryValidate() => Value != Guid.Empty;
}

public sealed class ClassMoney : ValueOf<decimal, ClassMoney>
{
    protected override void Validate()
    {
        if (Value < 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), "Value cannot be negative");
        }
    }

    protected override bool TryValidate() => Value >= 0m;
}

public sealed class ClassAddress : ValueOf<AddressValue, ClassAddress>
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value.FirstLine))
        {
            throw new ArgumentException("First line cannot be null or empty", nameof(Value));
        }
        if (string.IsNullOrWhiteSpace(Value.SecondLine))
        {
            throw new ArgumentException("Second line cannot be null or empty", nameof(Value));
        }
    }

    protected override bool TryValidate()
    {
        return !string.IsNullOrWhiteSpace(Value.FirstLine)
            && !string.IsNullOrWhiteSpace(Value.SecondLine)
            && Value.Postcode != default;
    }
}

public readonly record struct AddressValue(string FirstLine, string SecondLine, StructPostcode Postcode);

[ValueOf<int>]
public readonly partial record struct StructUserId
{
    static partial void Validate(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Id cannot be negative", nameof(value));
        }
    }

    static partial void TryValidate(int value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = value >= 0;
    }
}

[ValueOf<string>]
public readonly partial record struct StructClientRef
{
    static partial void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty", nameof(value));
        }
    }

    static partial void TryValidate(string value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = !string.IsNullOrWhiteSpace(value);
    }
}

[ValueOf<Guid>]
public readonly partial record struct StructOrderId
{
    static partial void Validate(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Value cannot be empty", nameof(value));
        }
    }

    static partial void TryValidate(Guid value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = value != Guid.Empty;
    }
}

[ValueOf<decimal>]
public readonly partial record struct StructMoney
{
    static partial void Validate(decimal value)
    {
        if (value < 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative");
        }
    }

    static partial void TryValidate(decimal value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = value >= 0m;
    }
}

[ValueOf<string>]
public readonly partial record struct StructPostcode
{
    static partial void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Postcode cannot be null or empty", nameof(value));
        }
    }

    static partial void TryValidate(string value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = !string.IsNullOrWhiteSpace(value);
    }
}

[ValueOf<AddressValue>]
public readonly partial record struct StructAddress
{
    static partial void Validate(AddressValue value)
    {
        if (string.IsNullOrWhiteSpace(value.FirstLine))
        {
            throw new ArgumentException("First line cannot be null or empty", nameof(value));
        }
        if (string.IsNullOrWhiteSpace(value.SecondLine))
        {
            throw new ArgumentException("Second line cannot be null or empty", nameof(value));
        }
    }

    static partial void TryValidate(AddressValue value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = !string.IsNullOrWhiteSpace(value.FirstLine)
            && !string.IsNullOrWhiteSpace(value.SecondLine)
            && value.Postcode != default;
    }
}
