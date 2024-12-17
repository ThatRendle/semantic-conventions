namespace OTel
{
    public partial class Metrics
    {
        public partial class DotnetMetric : OTelMetric
        {
            public partial class ProcessMetric : OTelMetric
            {
                public partial class CpuMetric : OTelMetric
                {
                    public partial class CountMetric : OTelUpDownCounterMetric
                    {
                    }
                    
                    public CountMetric Count { get; } = new()
                    {
                        Id = "metric.dotnet.process.cpu.count",
                        MetricName = "dotnet.process.cpu.count",
                        Brief = "The number of processors available to the process.",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as accessing [`Environment.ProcessorCount`](https://learn.microsoft.com/dotnet/api/system.environment.processorcount).\n",
                        Instrument = "updowncounter",
                        Unit = "{cpu}",
                        Stability = "stable",
                    };
                    public partial class TimeMetric : OTelCounterMetric
                    {
                    }
                    
                    public TimeMetric Time { get; } = new()
                    {
                        Id = "metric.dotnet.process.cpu.time",
                        MetricName = "dotnet.process.cpu.time",
                        Brief = "CPU time used by the process.",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as accessing the corresponding processor time properties on [`System.Diagnostics.Process`](https://learn.microsoft.com/dotnet/api/system.diagnostics.process).\n",
                        Instrument = "counter",
                        Unit = "s",
                        Stability = "stable",
                    };
                }
                
                public CpuMetric Cpu { get; } = new()
                {
                    Id = "metric.dotnet.process.cpu",
                };
                public partial class MemoryMetric : OTelMetric
                {
                    public partial class WorkingSetMetric : OTelUpDownCounterMetric
                    {
                    }
                    
                    public WorkingSetMetric WorkingSet { get; } = new()
                    {
                        Id = "metric.dotnet.process.memory.working_set",
                        MetricName = "dotnet.process.memory.working_set",
                        Brief = "The number of bytes of physical memory mapped to the process context.",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`Environment.WorkingSet`](https://learn.microsoft.com/dotnet/api/system.environment.workingset).\n",
                        Instrument = "updowncounter",
                        Unit = "By",
                        Stability = "stable",
                    };
                }
                
                public MemoryMetric Memory { get; } = new()
                {
                    Id = "metric.dotnet.process.memory",
                };
            }
            
            public ProcessMetric Process { get; } = new()
            {
                Id = "metric.dotnet.process",
            };
            public partial class GcMetric : OTelMetric
            {
                public partial class CollectionsMetric : OTelCounterMetric
                {
                }
                
                public CollectionsMetric Collections { get; } = new()
                {
                    Id = "metric.dotnet.gc.collections",
                    MetricName = "dotnet.gc.collections",
                    Brief = "The number of garbage collections that have occurred since the process has started.",
                    Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric uses the [`GC.CollectionCount(int generation)`](https://learn.microsoft.com/dotnet/api/system.gc.collectioncount) API to calculate exclusive collections per generation.\n",
                    Instrument = "counter",
                    Unit = "{collection}",
                    Stability = "stable",
                };
                public partial class HeapMetric : OTelMetric
                {
                    public partial class TotalAllocatedMetric : OTelCounterMetric
                    {
                    }
                    
                    public TotalAllocatedMetric TotalAllocated { get; } = new()
                    {
                        Id = "metric.dotnet.gc.heap.total_allocated",
                        MetricName = "dotnet.gc.heap.total_allocated",
                        Brief = "The *approximate* number of bytes allocated on the managed GC heap since the process has started. The returned value does not include any native allocations.\n",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`GC.GetTotalAllocatedBytes()`](https://learn.microsoft.com/dotnet/api/system.gc.gettotalallocatedbytes).\n",
                        Instrument = "counter",
                        Unit = "By",
                        Stability = "stable",
                    };
                }
                
                public HeapMetric Heap { get; } = new()
                {
                    Id = "metric.dotnet.gc.heap",
                };
                public partial class LastCollectionMetric : OTelMetric
                {
                    public partial class MemoryMetric : OTelMetric
                    {
                        public partial class CommittedSizeMetric : OTelUpDownCounterMetric
                        {
                        }
                        
                        public CommittedSizeMetric CommittedSize { get; } = new()
                        {
                            Id = "metric.dotnet.gc.last_collection.memory.committed_size",
                            MetricName = "dotnet.gc.last_collection.memory.committed_size",
                            Brief = "The amount of committed virtual memory in use by the .NET GC, as observed during the latest garbage collection.\n",
                            Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`GC.GetGCMemoryInfo().TotalCommittedBytes`](https://learn.microsoft.com/dotnet/api/system.gcmemoryinfo.totalcommittedbytes). Committed virtual memory may be larger than the heap size because it includes both memory for storing existing objects (the heap size) and some extra memory that is ready to handle newly allocated objects in the future.\n",
                            Instrument = "updowncounter",
                            Unit = "By",
                            Stability = "stable",
                        };
                    }
                    
                    public MemoryMetric Memory { get; } = new()
                    {
                        Id = "metric.dotnet.gc.last_collection.memory",
                    };
                    public partial class HeapMetric : OTelMetric
                    {
                        public partial class SizeMetric : OTelUpDownCounterMetric
                        {
                        }
                        
                        public SizeMetric Size { get; } = new()
                        {
                            Id = "metric.dotnet.gc.last_collection.heap.size",
                            MetricName = "dotnet.gc.last_collection.heap.size",
                            Brief = "The managed GC heap size (including fragmentation), as observed during the latest garbage collection.\n",
                            Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`GC.GetGCMemoryInfo().GenerationInfo.SizeAfterBytes`](https://learn.microsoft.com/dotnet/api/system.gcgenerationinfo.sizeafterbytes).\n",
                            Instrument = "updowncounter",
                            Unit = "By",
                            Stability = "stable",
                        };
                        public partial class FragmentationMetric : OTelMetric
                        {
                            public partial class SizeMetric : OTelUpDownCounterMetric
                            {
                            }
                            
                            public SizeMetric Size { get; } = new()
                            {
                                Id = "metric.dotnet.gc.last_collection.heap.fragmentation.size",
                                MetricName = "dotnet.gc.last_collection.heap.fragmentation.size",
                                Brief = "The heap fragmentation, as observed during the latest garbage collection.\n",
                                Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`GC.GetGCMemoryInfo().GenerationInfo.FragmentationAfterBytes`](https://learn.microsoft.com/dotnet/api/system.gcgenerationinfo.fragmentationafterbytes).\n",
                                Instrument = "updowncounter",
                                Unit = "By",
                                Stability = "stable",
                            };
                        }
                        
                        public FragmentationMetric Fragmentation { get; } = new()
                        {
                            Id = "metric.dotnet.gc.last_collection.heap.fragmentation",
                        };
                    }
                    
                    public HeapMetric Heap { get; } = new()
                    {
                        Id = "metric.dotnet.gc.last_collection.heap",
                    };
                }
                
                public LastCollectionMetric LastCollection { get; } = new()
                {
                    Id = "metric.dotnet.gc.last_collection",
                };
                public partial class PauseMetric : OTelMetric
                {
                    public partial class TimeMetric : OTelCounterMetric
                    {
                    }
                    
                    public TimeMetric Time { get; } = new()
                    {
                        Id = "metric.dotnet.gc.pause.time",
                        MetricName = "dotnet.gc.pause.time",
                        Brief = "The total amount of time paused in GC since the process has started.",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`GC.GetTotalPauseDuration()`](https://learn.microsoft.com/dotnet/api/system.gc.gettotalpauseduration).\n",
                        Instrument = "counter",
                        Unit = "s",
                        Stability = "stable",
                    };
                }
                
                public PauseMetric Pause { get; } = new()
                {
                    Id = "metric.dotnet.gc.pause",
                };
            }
            
            public GcMetric Gc { get; } = new()
            {
                Id = "metric.dotnet.gc",
            };
            public partial class JitMetric : OTelMetric
            {
                public partial class CompiledIlMetric : OTelMetric
                {
                    public partial class SizeMetric : OTelCounterMetric
                    {
                    }
                    
                    public SizeMetric Size { get; } = new()
                    {
                        Id = "metric.dotnet.jit.compiled_il.size",
                        MetricName = "dotnet.jit.compiled_il.size",
                        Brief = "Count of bytes of intermediate language that have been compiled since the process has started.",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`JitInfo.GetCompiledILBytes()`](https://learn.microsoft.com/dotnet/api/system.runtime.jitinfo.getcompiledilbytes).\n",
                        Instrument = "counter",
                        Unit = "By",
                        Stability = "stable",
                    };
                }
                
                public CompiledIlMetric CompiledIl { get; } = new()
                {
                    Id = "metric.dotnet.jit.compiled_il",
                };
                public partial class CompiledMethodsMetric : OTelCounterMetric
                {
                }
                
                public CompiledMethodsMetric CompiledMethods { get; } = new()
                {
                    Id = "metric.dotnet.jit.compiled_methods",
                    MetricName = "dotnet.jit.compiled_methods",
                    Brief = "The number of times the JIT compiler (re)compiled methods since the process has started.\n",
                    Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`JitInfo.GetCompiledMethodCount()`](https://learn.microsoft.com/dotnet/api/system.runtime.jitinfo.getcompiledmethodcount).\n",
                    Instrument = "counter",
                    Unit = "{method}",
                    Stability = "stable",
                };
                public partial class CompilationMetric : OTelMetric
                {
                    public partial class TimeMetric : OTelCounterMetric
                    {
                    }
                    
                    public TimeMetric Time { get; } = new()
                    {
                        Id = "metric.dotnet.jit.compilation.time",
                        MetricName = "dotnet.jit.compilation.time",
                        Brief = "The amount of time the JIT compiler has spent compiling methods since the process has started.\n",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`JitInfo.GetCompilationTime()`](https://learn.microsoft.com/dotnet/api/system.runtime.jitinfo.getcompilationtime).\n",
                        Instrument = "counter",
                        Unit = "s",
                        Stability = "stable",
                    };
                }
                
                public CompilationMetric Compilation { get; } = new()
                {
                    Id = "metric.dotnet.jit.compilation",
                };
            }
            
            public JitMetric Jit { get; } = new()
            {
                Id = "metric.dotnet.jit",
            };
            public partial class MonitorMetric : OTelMetric
            {
                public partial class LockContentionsMetric : OTelCounterMetric
                {
                }
                
                public LockContentionsMetric LockContentions { get; } = new()
                {
                    Id = "metric.dotnet.monitor.lock_contentions",
                    MetricName = "dotnet.monitor.lock_contentions",
                    Brief = "The number of times there was contention when trying to acquire a monitor lock since the process has started.\n",
                    Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`Monitor.LockContentionCount`](https://learn.microsoft.com/dotnet/api/system.threading.monitor.lockcontentioncount).\n",
                    Instrument = "counter",
                    Unit = "{contention}",
                    Stability = "stable",
                };
            }
            
            public MonitorMetric Monitor { get; } = new()
            {
                Id = "metric.dotnet.monitor",
            };
            public partial class ThreadPoolMetric : OTelMetric
            {
                public partial class ThreadMetric : OTelMetric
                {
                    public partial class CountMetric : OTelUpDownCounterMetric
                    {
                    }
                    
                    public CountMetric Count { get; } = new()
                    {
                        Id = "metric.dotnet.thread_pool.thread.count",
                        MetricName = "dotnet.thread_pool.thread.count",
                        Brief = "The number of thread pool threads that currently exist.",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`ThreadPool.ThreadCount`](https://learn.microsoft.com/dotnet/api/system.threading.threadpool.threadcount).\n",
                        Instrument = "updowncounter",
                        Unit = "{thread}",
                        Stability = "stable",
                    };
                }
                
                public ThreadMetric Thread { get; } = new()
                {
                    Id = "metric.dotnet.thread_pool.thread",
                };
                public partial class WorkItemMetric : OTelMetric
                {
                    public partial class CountMetric : OTelCounterMetric
                    {
                    }
                    
                    public CountMetric Count { get; } = new()
                    {
                        Id = "metric.dotnet.thread_pool.work_item.count",
                        MetricName = "dotnet.thread_pool.work_item.count",
                        Brief = "The number of work items that the thread pool has completed since the process has started.\n",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`ThreadPool.CompletedWorkItemCount`](https://learn.microsoft.com/dotnet/api/system.threading.threadpool.completedworkitemcount).\n",
                        Instrument = "counter",
                        Unit = "{work_item}",
                        Stability = "stable",
                    };
                }
                
                public WorkItemMetric WorkItem { get; } = new()
                {
                    Id = "metric.dotnet.thread_pool.work_item",
                };
                public partial class QueueMetric : OTelMetric
                {
                    public partial class LengthMetric : OTelUpDownCounterMetric
                    {
                    }
                    
                    public LengthMetric Length { get; } = new()
                    {
                        Id = "metric.dotnet.thread_pool.queue.length",
                        MetricName = "dotnet.thread_pool.queue.length",
                        Brief = "The number of work items that are currently queued to be processed by the thread pool.\n",
                        Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`ThreadPool.PendingWorkItemCount`](https://learn.microsoft.com/dotnet/api/system.threading.threadpool.pendingworkitemcount).\n",
                        Instrument = "updowncounter",
                        Unit = "{work_item}",
                        Stability = "stable",
                    };
                }
                
                public QueueMetric Queue { get; } = new()
                {
                    Id = "metric.dotnet.thread_pool.queue",
                };
            }
            
            public ThreadPoolMetric ThreadPool { get; } = new()
            {
                Id = "metric.dotnet.thread_pool",
            };
            public partial class TimerMetric : OTelMetric
            {
                public partial class CountMetric : OTelUpDownCounterMetric
                {
                }
                
                public CountMetric Count { get; } = new()
                {
                    Id = "metric.dotnet.timer.count",
                    MetricName = "dotnet.timer.count",
                    Brief = "The number of timer instances that are currently active.",
                    Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`Timer.ActiveCount`](https://learn.microsoft.com/dotnet/api/system.threading.timer.activecount).\n",
                    Instrument = "updowncounter",
                    Unit = "{timer}",
                    Stability = "stable",
                };
            }
            
            public TimerMetric Timer { get; } = new()
            {
                Id = "metric.dotnet.timer",
            };
            public partial class AssemblyMetric : OTelMetric
            {
                public partial class CountMetric : OTelUpDownCounterMetric
                {
                }
                
                public CountMetric Count { get; } = new()
                {
                    Id = "metric.dotnet.assembly.count",
                    MetricName = "dotnet.assembly.count",
                    Brief = "The number of .NET assemblies that are currently loaded.",
                    Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as calling [`AppDomain.CurrentDomain.GetAssemblies().Length`](https://learn.microsoft.com/dotnet/api/system.appdomain.getassemblies).\n",
                    Instrument = "updowncounter",
                    Unit = "{assembly}",
                    Stability = "stable",
                };
            }
            
            public AssemblyMetric Assembly { get; } = new()
            {
                Id = "metric.dotnet.assembly",
            };
            public partial class ExceptionsMetric : OTelCounterMetric
            {
            }
            
            public ExceptionsMetric Exceptions { get; } = new()
            {
                Id = "metric.dotnet.exceptions",
                MetricName = "dotnet.exceptions",
                Brief = "The number of exceptions that have been thrown in managed code.",
                Note = "Meter name: `System.Runtime`; Added in: .NET 9.0.\nThis metric reports the same values as counting calls to [`AppDomain.CurrentDomain.FirstChanceException`](https://learn.microsoft.com/dotnet/api/system.appdomain.firstchanceexception).\n",
                Instrument = "counter",
                Unit = "{exception}",
                Stability = "stable",
            };
        }
        
        public static DotnetMetric Dotnet { get; } = new()
        {
            Id = "metric.dotnet",
        };
    }
}
