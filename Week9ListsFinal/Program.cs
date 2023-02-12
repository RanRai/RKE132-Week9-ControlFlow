string folderPath = @"C:\Users\Ranno\Desktop\tktk\programmeerimise_algkursus_RKE132";
string fileName = "shoppingList.txt"; //saan luua iganes tüüpi faili!
string filePath = Path.Combine(folderPath, fileName);
List<string> myShoppingList = new List<string>();

if (File.Exists(filePath)) //kui fail eksisteerib filePath kohas, siis annab true, kui mitte siis false
{
    myShoppingList = GetItemsFromUser();//kui fail eksisteerib, siis lasen käima.
    File.WriteAllLines(filePath, myShoppingList);
}
else
{
    File.Create(filePath).Close(); //siin LOON file. peale loomist PEAB kinni panema. Kui jääb avatuks, ei saa teises protsessis kasutada.
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}


static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();//vahemälu on valmis andmetüübi salvestamiseks

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);//salvestame lisatud asja userItem-isse, mis omakorda läheb myShoppingListi
        }
        else
        {
            Console.WriteLine("Bye!");
            break;//brake ei lase programmil tagasi faili tulla
        }
    }
    return userList;//tagastan andmed vahemälusse myShoppingList, et hiljem töötada nendega
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();//võimalus peale lisamist jätta ainult lisatud asjade arv

    int listLenth = someList.Count;
    Console.WriteLine($"You have added {listLenth} items to your shopping list.");

    int i = 1;//määran järjekorranumbri alguse. i deklareetiti väljaspool foreachi, kui kajastaks selle sees, siis oleks i kogu aeg määratud 1
    foreach (string item in someList)//kuvab lisatud elemendid peale exitit
    {
        Console.WriteLine($"{i}. {item}");//{i}. <- nummerdab järjekorra ja {item} näitab lisatud asju
        i++;
    }
}
