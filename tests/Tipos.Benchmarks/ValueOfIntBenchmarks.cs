using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Runtime.CompilerServices;

namespace Tipos.Benchmarks;

[MemoryDiagnoser]
public class ValueOfIntBenchmarks
{
    private readonly Consumer _consumer = new();
    private int _valid;
    private int _other;
    private ClassUserId _classA = null!;
    private ClassUserId _classB = null!;
    private StructUserId _structA;
    private StructUserId _structB;

    [GlobalSetup]
    public void Setup()
    {
        _valid = 123;
        _other = 456;
        _classA = ClassUserId.From(_valid);
        _classB = ClassUserId.From(_other);
        _structA = StructUserId.From(_valid);
        _structB = StructUserId.From(_other);
    }

    [Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_From()
    {
        var value = ClassUserId.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_From()
    {
        var value = StructUserId.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_TryFrom()
    {
        var ok = ClassUserId.TryFrom(_valid, out var value);
        _consumer.Consume(ok);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_TryFrom()
    {
        var ok = StructUserId.TryFrom(_valid, out var value);
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
