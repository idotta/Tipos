using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Runtime.CompilerServices;

namespace Tipos.Benchmarks;

[MemoryDiagnoser]
public class ValueOfGuidBenchmarks
{
    private readonly Consumer _consumer = new();
    private Guid _valid;
    private Guid _other;
    private ClassOrderId _classA = null!;
    private ClassOrderId _classB = null!;
    private StructOrderId _structA;
    private StructOrderId _structB;

    [GlobalSetup]
    public void Setup()
    {
        _valid = Guid.NewGuid();
        _other = Guid.NewGuid();
        _classA = ClassOrderId.From(_valid);
        _classB = ClassOrderId.From(_other);
        _structA = StructOrderId.From(_valid);
        _structB = StructOrderId.From(_other);
    }

    [Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_From()
    {
        var value = ClassOrderId.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_From()
    {
        var value = StructOrderId.From(_valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_TryFrom()
    {
        var ok = ClassOrderId.TryFrom(_valid, out var value);
        _consumer.Consume(ok);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_TryFrom()
    {
        var ok = StructOrderId.TryFrom(_valid, out var value);
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
