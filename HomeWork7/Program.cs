using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            StringArray();
            ArrayList();
            Collection();
            AnimalData();

            Console.ReadKey();
        }
        static void StringArray()
        {
            string[] dogs = {"Brian Griffin", "Scooby Doo", "Old Yeller", "Rin Tin Tin",
            "Benji", "Charlie B. Barkin", "Lassie", "Snoopy"};

            var dogSpaces = from dog in dogs
                            where dog.Contains(" ")
                            orderby dog descending
                            select dog;

            Console.WriteLine("Descended names with space:");
            foreach (var i in dogSpaces)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.WriteLine("Names whose first letters is 'S':");
            var firstLetter = from dog in dogs
                              where dog.StartsWith("S")
                              select dog;
            foreach (var i in firstLetter)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
        static void ArrayList()
        {
            ArrayList famAnimals = new ArrayList()
            {
                new Animal
                {
                    Name = "Bolto",
                    Weight = 18
                },
                new Animal
                {
                    Name = "Shrek",
                    Weight = 130
                },
                new Animal
                {
                    Name = "Togo",
                    Weight = 50
                }
            };
            var famAnimalEnum = famAnimals.OfType<Animal>();

            var smAnimals = from animal in famAnimalEnum
                            where animal.Weight <= 50
                            orderby animal.Name
                            select animal;

            Console.WriteLine("Names that weigh less than or equal to 50:");
            foreach (var animal in smAnimals)
            {
                Console.WriteLine("{0}´s weigh is {1}", animal.Name, animal.Weight);
            }
            Console.WriteLine();
        }
        static void Collection()
        {
            var animalList = new List<Animal>()
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77
                },
                new Animal
                {
                    Name = "Pit Bull",
                    Height = 7,
                    Weight = 4.4
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 60
                }
            };
            var bigDogs = from dog in animalList
                          where (dog.Weight > 25) && (dog.Height > 25)
                          orderby dog.Name
                          select dog;

            Console.WriteLine("Names whose weight and height are greater than 25:");
            foreach (var dog in bigDogs)
            {
                Console.WriteLine("{0}'s weigh & height are greater than 25",
                    dog.Name, dog.Weight);
            }
            Console.WriteLine();
        }
        static void AnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77,
                    AnimalID = 1
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4,
                    AnimalID = 2
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200,
                    AnimalID = 3
                },
                new Animal
                {
                    Name = "Labrador Retriever",
                    Height = 12,
                    Weight = 16,
                    AnimalID = 1
                },
                new Animal
                {
                    Name = "Beagle",
                    Height = 15,
                    Weight = 23,
                    AnimalID = 2
                }
            };
            Owner[] owners = new[]
            {
                new Owner
                {
                    Name = "Sansa Stark",
                    OwnerID = 1
                },
                new Owner
                {
                    Name = "John Snow",
                    OwnerID = 2
                },
                new Owner
                {
                    Name = "Petyr Baelish",
                    OwnerID = 3
                }
            };
            var innerJoin =
                from animal in animals
                join owner in owners on animal.AnimalID
                equals owner.OwnerID
                select new { OwnerName = owner.Name, AnimalName = animal.Name };

            Console.WriteLine("Owners and dogs:");
            foreach (var i in innerJoin)
            {
                Console.WriteLine("{0} owns {1}",
                    i.OwnerName, i.AnimalName);
            }
        }
    }
}
