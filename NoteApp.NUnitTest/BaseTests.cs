using System.Reflection;
using Ninject;

namespace NoteApp.NUnitTest;

/// <summary>
/// https://www.nuget.org/packages/Ninject
/// </summary>
public class BaseTests
{
    protected IKernel? Kernel { get; private set; }

    /// <summary>
    /// Runs before each test
    /// Identifies a method to be called immediately before each test is run.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        //prepare mock and interfaces to be used
        //for scenarios later
        //Kernel is from Niject is our guy
        //to specify the dependencies and their
        //concrete classes by using modules or manual
        //references
        Kernel = new StandardKernel();
        Kernel.Load(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Runs after each test case
    /// Identifies a method to be called immediately after each test is run.
    /// The method is guaranteed to be called, even if an exception is thrown.
    /// </summary>
    [TearDown]
    public void Cleanup()
    {
        Kernel?.Dispose();
        Kernel = null;
    }
}