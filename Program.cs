//using System.Xml.Linq;
//using System;

//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading

////BankCard (class)
////Bankname
////Fullname
////PAN (kartin uzerindeki 16 reqemli kod) //string
////PIN( karti bankamata daxil ederken yazdiginiz 4 reqemli kod) string
////CVC(kartin arxasindaki 3 reqemli kod) / string 100-999(random)
////ExpireDate (06/2023)
////Balans //random => istenilen

////Client (class)
////id, name, surname, age, salary, BankCard bankAccount

////Bank (class)
////Clients[]
////showCardBalance(BankCard)



//Oxumali oldugunuz materiallar:
//http://people.cs.aau.dk/~normark/oop-csharp/html/notes/exceptions-note-exception-hier-cs.html

//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/compiler-generated-exceptions
//ATM(bankomat) program:

//1.Card adinda bir class yaradirsiniz hansi ki, asagidaki fieldleri* var:

//   -PAN(kartin uzerindeki 16 reqemli kod) /string
//   - PIN(siniz karti bankamata daxil ederken yazdiginiz 4 reqemli kod) /string
//   - CVC(kartin arxasindaki 3 reqemli kod) /string
//   - Expire Date(month/year(kartin etibarlilib muddeti meselen(06/22))) /string
//   - Balans /decimal

//2.User adinda bir class yaradirsiniz hansi ki, asagidaki fieldleri var:

//   -Name /string
//   - Surname /string
//   - CreditCard /Card

//3.User massiv yaradirsiniz ve ora evvelceden 5 user yaradib elave edirsiniz. Kart melumatlarini ozunuz  elave edirsiniz.

//4. Proqram ise dusen kimi sizden PIN daxil etmeyinizi teleb edecek. Eger daxil etdiyiniz PIN e uygun kart varsa  yazilacaq ki, "{Name} {Surname} xos gelmisiniz zehmet olmasa asagidakilardan birini secerdiniz". 

//    1. Balans
//    2. Nagd pul

//     2.1. 1 secilen zaman kartdaki balansi gostermelidir
//     2.2. 2 seclien zaman:

//        1. 10 AZN
//        2. 20 AZN
//        3. 50 AZN
//        4. 100 AZN
//        5.Diger(Istediyi meblegi ozu qeyd ede biler)


//     2.3.Nezere alin ki, cixarmaq istediyiniz pul eger kartdaki balansdan coxdursa.Exception atmalidir ki "Balansda yeterli qeder mebleg yoxdur". 
//     2.4 Eger yerli qeder mebleg varsa balansdan secilen qeder mebleg cixilmali ve proqram yeniden menyuya qayitmalidir. Men artiq bu sefer Balans secende artiq Balansdaki pulun azaldigini gormeliyem.         

//    3. Kartdan karta kocurme

//       3.1. Bu bolmenin secdiyiniz zaman hansi karta kocurme etmek istediyinizi sorusacaq (PAN i sorusaraq)

//   Eger daxil etdiyiniz PIN yoxdursa o zaman "bu PAN koda aid kart tapilmadi" yazilmalidir. Ve yeniden basa qayitmali ve sizden PIN kod daxil etmeyinizi istemelidir.


//Ugurlar... 

using BankATM;
Bank bank = new();
BankCard leo1H = new("Leo Bank", "Huseyn Mammadov", "4098 5844 9012 3456", "1234", "987", "04/2025", 1957);
BankCard leo2S = new("Leo Bank", "Sarxan Tanriverdiyev", "4098 5844 9876 6789", "0000", "123", "06/2027", 2100);
BankCard leo3R = new("Leo Bank", "Rustam Mammadov", "4098 5844 2222 1111", "5555", "232", "01/2029", 2000);
BankCard leo4B = new("Leo Bank", "Bahruz Nezerov", "4098 5844 9012 3456", "8888", "964", "12/2025", 1957);
BankCard leo5W = new("Leo Bank", "Wamil Nebizade", "4098 5844 3040 5060", "1111", "676", "07/2027", 1670);



Client client1 = new("Huseyn", "Mammadov", 22, 3000, leo1H);
Client client2 = new("Sarxan", "Tanriverdiyev", 20, 5000, leo2S);
Client client3 = new("Rustam", "Mammadov", 22, 3000, leo3R);
Client client4 = new("Bahruz", "Nezerov", 22, 3500, leo4B);
Client client5 = new("Wamil", "Nebizade", 22, 10000, leo5W);

bank.client.Add(client1);
bank.client.Add(client2);
bank.client.Add(client3);
bank.client.Add(client4);
bank.client.Add(client5);


string[] arr = { "Balans", "Nagd Pul", "Diger karta kocurme" };
string[] arr2 = { "1. 10 AZN", "2. 20 AZN", "3. 50 AZN", "4. 100 AZN", "5. Diger" };
void print(string[] arr, int size, int x)
{
    for (int i = 0; i < size; i++)
    {
        if (i == x)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.WriteLine(arr[i]);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

Label:


Console.WriteLine("Pin Daxil Edin : ");
string str = Console.ReadLine();
bool check = true;

foreach (var item in bank.client)
{
    if (check == false)
    {
        Console.WriteLine("\t\t");
        Console.WriteLine(" HHesabdan cixilir...");
        Thread.Sleep(1000);
        goto Label;
    }

    if (str == item.bankAccount.PIN)
    {
        Console.WriteLine($"Xosh Geldiniz {item.bankAccount.Fullname} ");
        Thread.Sleep(1000); 
    Label2:
        int x = 0;

    LabelMenu:
        while (true)
        {
            Console.Clear();
            print(arr, arr.Length, x);
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    x = x == 2 ? 0 : x + 1;
                    break;
                case ConsoleKey.UpArrow:
                    x = x == 0 ? 2 : x - 1;
                    break;

                default:
                    break;
            }

            if (key.Key == ConsoleKey.Enter)
            {


                Console.Clear();

                if (x == 0)
                {
                    Console.WriteLine("Balansiniz : ");
                    Console.WriteLine(item.bankAccount.Balance);
                    Console.ReadLine();
                    goto Label2;

                }
                else if (x == 1)
                {
                    for (int i = 0; i < arr2.Length; i++)
                    {
                        Console.WriteLine(arr2[i]);
                    }
                    int.TryParse(Console.ReadLine(), out int ch);
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Balansinizdan 10 AZN cixarilir");
                            Thread.Sleep(400);
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("|");
                            Console.ForegroundColor= ConsoleColor.Yellow;
                            Thread.Sleep(400);

                            Console.WriteLine("||");
                            Thread.Sleep(400);
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("|||");
                            Console.ForegroundColor= ConsoleColor.Blue;
                            Thread.Sleep(400);
                            Console.WriteLine("||||");
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.WriteLine("Emeliyyat ugurla basha catdi");
                            Thread.Sleep(1000);
                            break;

                        case 2:
                            Console.WriteLine("Balansinizdan 20 AZN cixarilir");
                            Thread.Sleep(400);
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("|");
                            Console.ForegroundColor= ConsoleColor.Yellow;
                            Thread.Sleep(400);

                            Console.WriteLine("||");
                            Thread.Sleep(400);

                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("|||");
                            Console.ForegroundColor= ConsoleColor.Blue;
                            Thread.Sleep(400);
                            Console.WriteLine("||||");
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.WriteLine("Emeliyyat ugurla basha catdi");
                            Thread.Sleep(1000);
                            break;
                        case 3:
                            Console.WriteLine("Balansinizdan 50 AZN cixarilir");
                            Thread.Sleep(400);
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("|");
                            Console.ForegroundColor= ConsoleColor.Yellow;
                            Thread.Sleep(400);

                            Console.WriteLine("||");
                            Thread.Sleep(400);
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("|||");
                            Console.ForegroundColor= ConsoleColor.Blue;
                            Thread.Sleep(400);
                            Console.WriteLine("||||");
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.WriteLine("Emeliyyat ugurla basha catdi");
                            Thread.Sleep(1000);
                            goto Label2;
                        case 4:
                            Console.WriteLine("Balansinizdan 100 AZN cixarilir");
                            Thread.Sleep(400);
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("|");
                            Console.ForegroundColor= ConsoleColor.Yellow;
                            Thread.Sleep(400);

                            Console.WriteLine("||");
                            Thread.Sleep(400);
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("|||");
                            Console.ForegroundColor= ConsoleColor.Blue;
                            Thread.Sleep(400);
                            Console.WriteLine("||||");
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.WriteLine("Emeliyyat ugurla basha catdi");
                            Thread.Sleep(1000);
                            break;
                        case 5:
                            Console.Write("Cixarmaq istediyiniz meblegi yazin : ");
                            double.TryParse(Console.ReadLine(), out double m);
                            item.bankAccount.Balance -=m;
                            Thread.Sleep(1000);
                            Console.WriteLine("Emeliyyat ugurla basha catdi");
                            break;

                        default:
                            break;
                    }
                    goto Label2;
                }
                else if (x == 2)
                {
                    Console.WriteLine("Pul kocurmek istediyiniz kartin nomresini yazin(4 reqemden bir bowluq) : ");
                    string cardNumber = Console.ReadLine();
                    bool t = false;
                    foreach (var i in bank.client)
                    {
                        if (i.bankAccount.PAN16 == cardNumber)
                        {
                            Console.Write("Meblegi yazin : ");
                            double.TryParse(Console.ReadLine(), out double y);
                            item.bankAccount.Balance -= y;
                            i.bankAccount.Balance += y;
                            Console.WriteLine("Emeliyyat ugurla basha catdi");
                            Thread.Sleep(1000);
                            t = true;
                            goto Label2;
                        }
                    }
                    if (t == false)
                    {
                        Console.WriteLine("bu PAN koda aid kart tapilmadi");
                        Thread.Sleep(1000);
                        goto Label2;
                    }

                }
                break;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                check = false;
                break;
            }
            //else { goto LabelMenu; }
        }
    }
    

}
Console.WriteLine("Pin dogru deyil "); Thread.Sleep(1500); goto Label; 

