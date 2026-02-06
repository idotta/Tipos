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
