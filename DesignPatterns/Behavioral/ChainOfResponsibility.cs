using System.Diagnostics;

namespace DesignPatterns.Behavioral;

public enum RequestCode
{
    RequestA,
    RequestB,
}

public interface IRequestHandler
{
    void HandleRequest(RequestCode code);
    void SetSuccessor(IRequestHandler? successor);
}

public abstract class BaseRequestHandler : IRequestHandler
{
    protected IRequestHandler? Successor { get; private set; }

    public void SetSuccessor(IRequestHandler? successor)
    {
        Successor = successor;
    }

    public void HandleRequest(RequestCode code)
    {
        if (TryHandleRequest(code))
        {
            Debug.WriteLine("Request handled.");
        }
        else if (Successor == null)
        {
            Debug.WriteLine("Request could not be resolved.");
        }
        else
        {
            Debug.WriteLine("Request passed to successor.");
            Successor.HandleRequest(code);
        }
    }

    protected abstract bool TryHandleRequest(RequestCode code);
}

public class ConcreteHandler : BaseRequestHandler
{
    private readonly bool _canHandleRequest;

    public ConcreteHandler(bool canHandleRequest)
    {
        _canHandleRequest = canHandleRequest;
    }

    protected override bool TryHandleRequest(RequestCode code)
    {
        return _canHandleRequest;
    }
}

// Helper class.
public class ChainOfResponsibilityBuilder
{
    private BaseRequestHandler? _leaf;

    public ChainOfResponsibilityBuilder AddHandler(bool shouldHandle)
    {
        ConcreteHandler handler = new(shouldHandle);
        
        if (_leaf == null)
        {
            _leaf = handler;
        }
        else
        {
            handler.SetSuccessor(_leaf);
            _leaf = handler;
        }

        return this;
    }

    public IRequestHandler GetResult()
    {
        if (_leaf == null)
            throw new InvalidOperationException("Attempted to get result before adding a handlers.");
        
        return _leaf;
    }
}