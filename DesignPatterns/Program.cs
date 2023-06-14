// See https://aka.ms/new-console-template for more information


using DesignPatterns.Behavioral;

ChainOfResponsibilityBuilder builder = new();
builder.AddHandler(false)
    .AddHandler(false)
    .AddHandler(false);

IRequestHandler handler = builder.GetResult();
handler.HandleRequest(RequestCode.RequestA);