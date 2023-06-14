using System.Diagnostics;

namespace DesignPatterns.Structural;

public interface IComponent
{
    public void DoSomething();
}

public sealed class ComponentLeaf : IComponent
{
    public void DoSomething()
    {
        Debug.WriteLine("Leaf");
    }
}

public class ComponentComposite : IComponent
{
    private readonly List<IComponent> _children = new(); 
    
    public void AddChild(IComponent component)
    {
        _children.Add(component);
    }

    public void RemoveChild(IComponent component)
    {
        _children.Remove(component);
    }
    
    public void DoSomething()
    {
        Debug.WriteLine("Composite");
        foreach (IComponent child in _children)
        {
            child.DoSomething();
        }
    }
}