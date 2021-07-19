using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            ModifiedState modifiedState = new ModifiedState();
            DeletedState deletedState = new DeletedState();
            AddedState addedState = new AddedState();

            modifiedState.DoAction(context);
            deletedState.DoAction(context);
            addedState.DoAction(context);

            Console.WriteLine(context.GetState());

            Console.ReadLine();
        }
    }

    interface IState
    {
        void DoAction(Context context);
    }

    class Context
    {
        private IState _state;
        public void SetState(IState state) 
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }

    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: [MODIFIED]");
            context.SetState(this);
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: [DELETED]");
            context.SetState(this);
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: [ADDED]");
            context.SetState(this);
        }
    }
}
