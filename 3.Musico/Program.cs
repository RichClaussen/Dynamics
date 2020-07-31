using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dynamo = new ExpandableBase();

            dynamic x = new ExpandoObject();

            dynamo.Squirrel = "Beany";
            Console.WriteLine(dynamo.Squirrel);

            dynamo.Peabody = new ExpandableBase();
            Console.WriteLine(dynamo.Peabody);

            dynamo.Peabody.Carl = 14;
            Console.WriteLine(dynamo.Peabody.Carl);

            Console.WriteLine();
            Console.WriteLine();

            dynamic withinTemptation = new Artist { Name = "Within Temptation", };
            dynamic silentForce = new Album { Title = "The Silent Force", Performer = withinTemptation };
            dynamic somewhere = new Song { Title = "Somewhere", Performer = withinTemptation };
            dynamic sharonDenAdel = new Artist { Name = "Sharon den Adel", };

            silentForce.Year = "2004";

            somewhere.Album = silentForce;
            somewhere.Length = new TimeSpan(0, 0, 4, 14);

            var members = new List<dynamic>
                          {
                              sharonDenAdel,
                              new Artist { Name = "Robert Westerholt", },
                              new Artist { Name = "Jeroen van Veen", },
                              new Artist { Name = "Ruud Jolie", },
                              new Artist { Name = "Martijn Spierenburg", },
                              new Artist { Name = "Mike Coolen", },
                          };

            var albums = new List<dynamic>
                         {
                             new Album { Title = "Enter", Performer = withinTemptation },
                             new Album { Title = "Mother Earth", Performer = withinTemptation },
                             silentForce,
                             new Album { Title = "The Heart of Everything", Performer = withinTemptation },
                             new Album { Title = "The Unforgiving", Performer = withinTemptation },
                         };

            var songs = new List<dynamic>
                        {
                            new Song { Title = "Intro", Performer = withinTemptation },
                            new Song { Title = "See Who I Am", Performer = withinTemptation },
                            new Song { Title = "Jillian (I'd Give My Heart)", Performer = withinTemptation },
                            new Song { Title = "Stand My Ground", Performer = withinTemptation },
                            new Song { Title = "Pale", Performer = withinTemptation },
                            new Song { Title = "Forsaken", Performer = withinTemptation },
                            new Song { Title = "Angels", Performer = withinTemptation },
                            new Song { Title = "Memories", Performer = withinTemptation },
                            new Song { Title = "Aquarius", Performer = withinTemptation },
                            new Song { Title = "It's the Fear", Performer = withinTemptation },
                            somewhere,
                        };

            sharonDenAdel.Instrument = "Vocals";
            sharonDenAdel.BirthDate = new DateTime(1974, 7, 12);
            sharonDenAdel.Band = withinTemptation;

            silentForce.Songs = songs;

            withinTemptation.Members = members;
            withinTemptation.Albums = albums;

            Console.WriteLine(somewhere.Title);
            Console.WriteLine(somewhere.Performer.Name);

            foreach (Artist artist in withinTemptation.Members)
            {
                Console.WriteLine("\t{0}", artist.Name);
            }

            Console.WriteLine("\nDynamic Members Added to {0}", somewhere);
            foreach (dynamic member in somewhere.GetDynamicMemberNames())
            {
                Console.WriteLine("\t{0}", member);
            }

            Console.WriteLine("\nDynamic Members Added to {0}", silentForce);
            foreach (dynamic member in silentForce.GetDynamicMemberNames())
            {
                Console.WriteLine("\t{0}", member);
            }

            Console.WriteLine("\nDynamic Members Added to {0}", withinTemptation);
            foreach (dynamic member in withinTemptation.GetDynamicMemberNames())
            {
                Console.WriteLine("\t{0}", member);
            }

            Console.WriteLine("\nDynamic Members Added to {0}", sharonDenAdel);
            foreach (dynamic member in sharonDenAdel.GetDynamicMemberNames())
            {
                Console.WriteLine("\t{0}", member);
            }

            Console.ReadLine();
        }
    }
}
