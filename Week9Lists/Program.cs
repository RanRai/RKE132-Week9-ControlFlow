
List<string> myShoppingList = GetItemsFromUser();//tegime userListi
ShowItemsFromList(myShoppingList);//SIFL kuvab funktsiooni userList

static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();//vahemälu on valmis andmetüübi salvestamiseks

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")//kui kasutaja soovib lisada
        {
            Console.WriteLine("Enter an item:");//laseme lisada
            string userItem = Console.ReadLine();//loeme, mida kasutaja kirjutas
            userList.Add(userItem);//salvestame lisatud asja userItem-isse, mis omakorda läheb userListi
        }
        else
        {
            Console.WriteLine("Bye!");
            break;//brake ei lase programmil tagasi faili tulla, katkestan tsükli
        }
    }
    return userList;//tagastan andmed vahemälusse userList, et hiljem töötada nendega
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();//võimalus peale lisamist jätta ainult lisatud asjade arv

    int listLength = someList.Count;//listi count loeb kokku, siin muudame selle nimetuse Lengthiks
    Console.WriteLine($"You have added {listLength} items to your shopping list.");

    int i = 1;//määran järjekorranumbri alguse. i deklareetiti väljaspool foreachi, kui kajastaks selle sees, siis oleks i kogu aeg määratud 1
    foreach (string item in someList)//kuvab lisatud elemendid peale exitit
    {
        Console.WriteLine($"{i}. {item}");//{i}. <- nummerdab järjekorra ja {item} näitab lisatud asju
        i++;
    }
}
