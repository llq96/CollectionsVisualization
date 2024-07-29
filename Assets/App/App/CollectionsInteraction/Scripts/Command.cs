using System;

namespace CollectionsInteraction
{
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