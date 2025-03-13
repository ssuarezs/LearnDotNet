using BranchingLooping;

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// the ourAnimals array: 
Pet[] ourAnimals = new Pet[maxPets];

// create some initial ourAnimals array entries
for (int i = 0; i < 4; i++)
{
    string animalSpecies = "";
    string animalAge = "";
    string animalPhysicalDescription = "";
    string animalPersonalityDescription = "";
    string animalNickname = "";

    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    int age = 0;
    int.TryParse(animalAge, out age);

    ourAnimals[i] = new Pet
    {
        ID = Guid.NewGuid(),
        Specie = animalSpecies == "dog" ? PetSpecies.Dog : PetSpecies.Cat,
        Age = age,
        Condition = animalPhysicalDescription,
        Personality = animalPersonalityDescription,
        Nickname = animalNickname
    };
}



// display the top-level menu options
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                var animal = ourAnimals[i];
                Console.WriteLine($"ID #: {animal.ID}");
                Console.WriteLine($"Species: {animal.Specie}");
                Console.WriteLine($"Age: {animal.Age}");
                Console.WriteLine($"Nickname: {animal.Nickname}");
                Console.WriteLine($"Condition: {animal.Condition}");
                Console.WriteLine($"Personality: {animal.Personality}\n");
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i] != null)
                {
                    petCount += 1;
                }

            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "3":
            Console.WriteLine("3 this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            Console.WriteLine("4 this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("5 this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            Console.WriteLine("6 this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            Console.WriteLine("7 this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            Console.WriteLine("8 this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            Console.WriteLine("Default this app feature is coming soon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
    }

} while (menuSelection != "exit");
