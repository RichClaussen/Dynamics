using System;
using System.Dynamic;

namespace Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic thing1 = 5;
            Console.WriteLine(thing1);
            Console.WriteLine(thing1.GetType());

            thing1 = "cat in the hat";
            Console.WriteLine(thing1);
            Console.WriteLine(thing1.GetType());

            thing1 = 5.3;
            Console.WriteLine(thing1);
            Console.WriteLine(thing1.GetType());

            dynamic thing2 = new ExpandoObject();
            thing2.SuperDuper = 6;
            thing2.Cathy = "Paul";

            thing2.Items = new[] { 1, 2, 5, };

            Console.WriteLine(thing2.Items);

            Console.WriteLine(thing2.Cathy);



            dynamic myDynamo = new RichDynamo();
            myDynamo--;

            dynamic otherDynamo = new RichDynamo();
            var resultDynamo = myDynamo - otherDynamo;

            resultDynamo++;

            resultDynamo = resultDynamo.FreakOut();

            resultDynamo = resultDynamo.Moose;

            resultDynamo.Pickle = 5;

            Console.ReadLine();
        }
    }

    public class RichDynamo : DynamicObject
    {
        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result)
        {
            Console.WriteLine("Binary op \"{0}\"", binder.Operation);
            result = new RichDynamo();
            return true;
        }

        public override bool TryUnaryOperation(UnaryOperationBinder binder, out object result)
        {
            Console.WriteLine("Unary op \"{0}\"", binder.Operation);
            result = new RichDynamo();
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine("Invoke Method \"{0}\"", binder.Name);
            result = new RichDynamo();
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.WriteLine("Get Property \"{0}\"", binder.Name);
            result = new RichDynamo();
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Console.WriteLine("Set Property \"{0}\" to {1}", binder.Name, value);
            return true;
        }
    }
}
