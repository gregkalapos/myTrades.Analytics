``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 2 [1703, Creators Update] (10.0.15063.909)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=3328125 Hz, Resolution=300.4695 ns, Timer=TSC
.NET Core SDK=2.1.4
  [Host]     : .NET Core 2.0.5 (CoreCLR 4.6.26020.03, CoreFX 4.6.26018.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.5 (CoreCLR 4.6.26020.03, CoreFX 4.6.26018.01), 64bit RyuJIT


```
|           Method |     Mean |    Error |   StdDev |    Gen 0 | Allocated |
|----------------- |---------:|---------:|---------:|---------:|----------:|
| CalculateSmaPerf | 340.5 us | 6.410 us | 5.996 us | 196.7773 | 807.99 KB |
