namespace Tipos.Generator.Tests;

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

[ValueOf<string>]
public readonly partial record struct ClientRef
{
    static partial void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty", nameof(value));
        }
    }
}

[ValueOf<string>]
public readonly partial record struct TryValidateClientRef
{
    static partial void TryValidate(string value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = !string.IsNullOrWhiteSpace(value);
    }
}

[ValueOf<string>]
public readonly partial record struct Postcode
{
    static partial void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Postcode cannot be null or empty", nameof(value));
        }
    }
}

public readonly record struct AddressValue(string FirstLine, string SecondLine, Postcode Postcode);

[ValueOf<AddressValue>]
public readonly partial record struct Address
{
}

[ValueOf<Guid>]
public readonly partial record struct OrderId
{
    static partial void Validate(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Value cannot be empty", nameof(value));
        }
    }
}

[ValueOf<decimal>]
public readonly partial record struct Money
{
    static partial void Validate(decimal value)
    {
        if (value < 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative");
        }
    }
}

[ValueOf<int>]
public readonly partial record struct ValidateFallback
{
    public static int ValidateCallCount { get; private set; }

    public static void Reset() => ValidateCallCount = 0;

    static partial void TryValidate(int value, ref bool isValid, ref bool handled)
    {
        handled = false;
        isValid = true;
    }

    static partial void Validate(int value)
    {
        ValidateCallCount++;
        if (value < 0)
        {
            throw new ArgumentException("Value cannot be negative", nameof(value));
        }
    }
}

[ValueOf<int>]
public readonly partial record struct ValidateHandled
{
    public static int ValidateCallCount { get; private set; }

    public static void Reset() => ValidateCallCount = 0;

    static partial void TryValidate(int value, ref bool isValid, ref bool handled)
    {
        handled = true;
        isValid = value >= 0;
    }

    static partial void Validate(int value)
    {
        ValidateCallCount++;
        throw new InvalidOperationException("Validate should not be called when handled.");
    }
}
