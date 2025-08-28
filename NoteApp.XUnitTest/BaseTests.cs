using System.Reflection;
using System.Runtime.CompilerServices;
using Ninject;

namespace NoteApp.XUnitTest;
/// <summary>
/// https://xunit.net/?tabs=cs
/// </summary>
public abstract class BaseTests : IDisposable
{
    protected IKernel? Kernel { get; private set; }

    /// <summary>
    /// Runs before each test
    /// Identifies a method to be called immediately before each test is run.
    /// </summary>
    protected BaseTests()
    {
        //prepare mock and interfaces to be used
        //for scenarios later
        //Kernel is from Niject is our guy
        //to specify the dependencies and their
        //concrete classes by using modules or manual
        //references
        Kernel = new StandardKernel();
        Kernel.Load(Assembly.GetExecutingAssembly());
        
        Console.WriteLine($"{this.GetType().Name} Running before each tests.....");
    }

    /// <summary>
    /// Runs after each test case
    /// Identifies a method to be called immediately after each test is run.
    /// The method is guaranteed to be called, even if an exception is thrown.
    /// </summary>
    public void Dispose()
    {
        Kernel?.Dispose();
        Kernel = null;
        
        Console.WriteLine($"{this.GetType().Name} Running after each tests.....");
    }
}