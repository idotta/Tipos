using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Tipos;

public abstract class ValueOf<TValue, TThis> : IEquatable<ValueOf<TValue, TThis>>
    where TThis : ValueOf<TValue, TThis>, new()
{
    public TValue Value { get; protected set; } = default!;

    protected virtual void Validate() { }

    protected virtual bool TryValidate() => true;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TThis From(TValue item)
    {
        var x = new TThis
        {
            Value = item
        };
        x.Validate();
        return x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryFrom(TValue item, [NotNullWhen(true)] out TThis? thisValue)
    {
        var x = new TThis
        {
            Value = item
        };

        if (x.TryValidate())
        {
            thisValue = x;
            return true;
        }
        thisValue = null;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(ValueOf<TValue, TThis>? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ValueOf<TValue, TThis>);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return EqualityComparer<TValue>.Default.GetHashCode(Value!);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value?.ToString() ?? string.Empty;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ValueOf<TValue, TThis>? a, ValueOf<TValue, TThis>? b)
    {
        if (a is null)
        {
            return b is null;
        }
        return a.Equals(b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ValueOf<TValue, TThis>? a, ValueOf<TValue, TThis>? b)
    {
        return !(a == b);
    }
}