using System;
using System.Dynamic;

namespace Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dynamo = new RExpandoObject();

            dynamo.Peabody = new RExpandoObject();
            Console.WriteLine(dynamo.Peabody);

            dynamo.Peabody.Carl = 14;
            Console.WriteLine(dynamo.Peabody.Carl);

            Console.WriteLine(dynamo.Moose);
            Console.WriteLine(((RExpandoObject)dynamo).Moose);

            Console.WriteLine(dynamo.Squirrel);
            Console.WriteLine(((RExpandoObject)dynamo).Squirrel);

            dynamo.Squirrel = "Beany";
            Console.WriteLine(dynamo.Squirrel);
            Console.WriteLine(((RExpandoObject)dynamo).Squirrel);

            // The Difference
            dynamic dynamo2 = new ExpandoObject();
            //Console.WriteLine(dynamo2.Moose);
            //Console.WriteLine(((ExpandoObject)dynamo2).Moose);

            dynamo.UpdateMoose("Boris");
            Console.WriteLine(dynamo.Moose);

            dynamo.NewFunction = new Func<int, string>(number => string.Format("The {0} #{1}", dynamo.Moose, number));
            Console.WriteLine(dynamo.NewFunction(3));

            Console.WriteLine();

            dynamic coolDynamo = new CoolObject();
            Console.WriteLine(coolDynamo.Dudley);
            Console.WriteLine(coolDynamo.Snidely);
            Console.WriteLine(dynamo.Moose);
            Console.WriteLine(dynamo.Squirrel);

            coolDynamo.Peabody = 5;
            Console.WriteLine(coolDynamo.Peabody);

            Console.ReadLine();
        }
    }
}
