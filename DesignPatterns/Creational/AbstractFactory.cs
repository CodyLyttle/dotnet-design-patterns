namespace DesignPatterns.Creational;

public interface IComponent
{
    // Contract.
}

public class ComponentA : IComponent
{
    // Implementation.
}

public class ComponentB : IComponent
{
    // Implementation.
}

public interface IFactory
{
    public IComponent CreateThing();
    // Other creational methods.
}

public class ConcreteFactoryA : IFactory
{
    public IComponent CreateThing()
    {
        return new ComponentA();
    }
}

public class ConcreteFactoryB : IFactory
{
    public IComponent CreateThing()
    {
        return new ComponentB();
    }
}