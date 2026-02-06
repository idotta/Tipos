using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Runtime.CompilerServices;

namespace Tipos.Benchmarks;

[MemoryDiagnoser]
public class ValueOfStructBenchmarks
{
    private readonly Consumer _consumer = new();
    private AddressValue _valid;
    private AddressValue _other;
    private ClassAddress _classA = null!;
    private ClassAddress _classB = null!;
    private StructAddress _structA;
    private StructAddress _structB;

    [GlobalSetup]
    public void Setup()
    {
        _valid = new AddressValue("16 Food Street", "London", StructPostcode.From("N1 1LT"));
        _other = new AddressValue("17 Food Street", "London", StructPostcode.From("N1 1LT"));
        _classA = ClassAddress.From(_valid);
        _classB = ClassAddress.From(_other);
        _structA = StructAddress.From(_valid);
        _structB = StructAddress.From(_other);
    }

    [Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_From()
    {
        var value = ClassAddress.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_From()
    {
        var value = StructAddress.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_TryFrom()
    {
        var ok = ClassAddress.TryFrom(_valid, out var value);
        _consumer.Consume(ok);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_TryFrom()
    {
        var ok = StructAddress.TryFrom(_valid, out var value);
        _consumer.Consume(ok);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_Equals()
    {
        var result = _classA.Equals(_classB);
        _consumer.Consume(result);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_Equals()
    {
        var result = _structA.Equals(_structB);
        _consumer.Consume(result);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_GetHashCode()
    {
        var result = _classA.GetHashCode();
        _consumer.Consume(result);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_GetHashCode()
    {
        var result = _structA.GetHashCode();
        _consumer.Consume(result);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_ToString()
    {
        var result = _classA.ToString();
        _consumer.Consume(result);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_ToString()
    {
        var result = _structA.ToString();
        _consumer.Consume(result);
    }
}
