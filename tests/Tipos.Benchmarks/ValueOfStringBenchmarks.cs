using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Runtime.CompilerServices;

namespace Tipos.Benchmarks;

[MemoryDiagnoser]
public class ValueOfStringBenchmarks
{
    private readonly Consumer _consumer = new();
    private const string Valid = "ASDF12345";
    private const string Other = "QWER98765";
    private ClassClientRef _classA = null!;
    private ClassClientRef _classB = null!;
    private StructClientRef _structA;
    private StructClientRef _structB;

    [GlobalSetup]
    public void Setup()
    {
        _classA = ClassClientRef.From(Valid);
        _classB = ClassClientRef.From(Other);
        _structA = StructClientRef.From(Valid);
        _structB = StructClientRef.From(Other);
    }

    [Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_From()
    {
        var value = ClassClientRef.From(Valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_From()
    {
        var value = StructClientRef.From(Valid);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Class_TryFrom()
    {
        var ok = ClassClientRef.TryFrom(Valid, out var value);
        _consumer.Consume(ok);
        _consumer.Consume(value);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Struct_TryFrom()
    {
        var ok = StructClientRef.TryFrom(Valid, out var value);
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
