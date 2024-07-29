using System;

namespace CollectionsInteraction
{
    public class CommandBase
    {
        public string Expression { get; protected set; }
    }

    public class Command<TCollection> : CommandBase where TCollection : new()
    {
        public Command(Action<TCollection> action, string expression)
        {
            Action = action;
            Expression = expression;
        }

        public Action<TCollection> Action { get; }
    }
}