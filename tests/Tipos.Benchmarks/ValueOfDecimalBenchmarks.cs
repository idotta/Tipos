using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Runtime.CompilerServices;

namespace Tipos.Benchmarks;

[MemoryDiagnoser]
public class ValueOfDecimalBenchmarks
{
    private readonly Consumer _consumer = new();
    private decimal _valid;
    private decimal _other;
    private ClassMoney _classA = null!;
    private ClassMoney _classB = null!;
    private StructMoney _structA;
    private StructMoney _structB;

    [GlobalSetup]
    public void Setup()
    {
        _valid = 10.5m;
        _other = 25.75m;
        _classA = ClassMoney.From(_valid);
        _classB = ClassMoney.From(_other);
        _structA = StructMoney.From(_valid);
        _structB = StructMoney.From(_other);
    }

    [Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_From()
    {
        var value = ClassMoney.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_From()
    {
        var value = StructMoney.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_TryFrom()
    {
        var ok = ClassMoney.TryFrom(_valid, out var value);
        _consumer.Consume(ok);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_TryFrom()
    {
        var ok = StructMoney.TryFrom(_valid, out var value);
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
