using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameInstructions();
            while (true)
            {
                CardGame21 player1 = new CardGame21();
                CardGame21 dealer = new CardGame21();
                CardGame21 computer1 = new CardGame21();

                Console.Write("\nShuffling the deck...");
                DeckOfCards doc = new DeckOfCards(true);
                Thread.Sleep(1000);
                Console.WriteLine("Done");

                // initialize of hands
                Console.Write("Distributing cards...");
                dealer.SetHand(doc.drawACard(2));
                computer1.SetHand(doc.drawACard(2));
                player1.SetHand(doc.drawACard(2));
                Thread.Sleep(1000);
                Console.WriteLine("Done");

                Thread.Sleep(1000);
                Console.Clear();

                bool isdstand = false;
                bool isc1stand = false;
                bool isp1stand = false;

                while (!isc1stand || !isp1stand || !isdstand)
                {
                    Console.Clear();
                    dealer.Ace(false);
                    dealer.DisplayHand(false, true, false);
                    if (!dealer.Stand(false))
                    {
                        if (dealer.Hit(false, true))
                            dealer.AddCard(doc.drawACard());
                    }
                    else
                    {
                        Console.WriteLine("Dealer Stands");
                        isdstand = true;
                    }
                    Console.WriteLine();

                    computer1.Ace(false);
                    computer1.DisplayHand(false, false, false);
                    if (!computer1.Stand(false))
                    {
                        if (computer1.Hit(false, false))
                            computer1.AddCard(doc.drawACard());
                    }
                    else
                    {
                        Console.WriteLine("Computer Stands");
                        isc1stand = true;
                    }
                    Console.WriteLine();

                    player1.DisplayHand(true, false, true);
                    player1.Ace(true);
                    if (!player1.Stand(true))
                    {
                        if (player1.Hit(true, false))
                            player1.AddCard(doc.drawACard());
                    }
                    else
                    {
                        Console.WriteLine("Player Stands");
                        isp1stand = true;
                    }

                    Thread.Sleep(1200);
                }

                Console.WriteLine("\nPress any key to reveal the hands");
                Console.ReadKey();
                Console.Clear();
                dealer.DisplayHand(false, true, true);
                Console.WriteLine();
                computer1.DisplayHand(false, false, true);
                Console.WriteLine();
                player1.DisplayHand(true, false, true);

                int dval = dealer.GetValuetoMain();
                int c1val = computer1.GetValuetoMain();
                int p1val = player1.GetValuetoMain();

                Console.WriteLine("\n" + Winner(dval, c1val, p1val));

                if (!isAgain())
                    break;
            }

            Console.ReadKey();
        } 

        static void GameInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("WELCOME TO 21 CARD GAME");
            Console.ResetColor();
            Console.WriteLine("\nInstructions");
            Console.WriteLine("Each Player and the Dealer must have atleast 2 cards on their hand.");
            Console.WriteLine("After getting your cards, you have two options of move, Hit or Stand. Hit - Will draw 1 card from the deck. Stand - Will end your turn.");
            Console.WriteLine("If if you have an Ace card, you can set its value to 1 or 11");
            Console.WriteLine("To win, you must have a Hand Value equivalent to 21 or you're the closest to 21.");
            Console.WriteLine("If your Hand Value is over 21, you are bust meaning you lost.");
            Console.WriteLine("\nPress any key to start the game.");
            Console.ReadKey();
        }

        static string Winner(int dval, int c1val, int p1val)
        {
            if (dval > 21 && c1val > 21 && p1val > 21)
                return "No Winner, Player, Dealer, and Computer are Bust.";
            else if (dval > 21 && c1val > 21)
                return "Dealer and Computer Bust, Player Win";
            else if (p1val > 21 && c1val > 21)
                return "Player and Computer Bust, Dealer Win";
            else if (dval > 21 && p1val > 21)
                return "Player and Dealer Bust, Computer Win";
            else if (p1val == 21 && (c1val < 21 && dval < 21))
                return "Player Win";
            else if (c1val == 21 && (p1val < 21 && dval < 21))
                return "Computer Win";
            else if (dval == 21 && (p1val < 21 && c1val < 21))
                return "Dealer Win";
            else if (dval == c1val && dval == p1val)
                return "No winner, Player, Dealer, and Computer are Draw.";
            else if ((dval < p1val && c1val < p1val) && (p1val < 21 && dval < 21 && c1val < 21))
                return "Player Win";
            //else if ((c1val < p1val) && (p1val < 21 && c1val < 21 && p1val != dval))
            //    return "Player Win";
            else if ((p1val < c1val && dval < c1val) && (c1val < 21 && p1val < 21 && dval < 21))
                return "Computer Win";
            //else if ((dval < c1val) && (c1val < 21 && dval < 21 && c1val != p1val))
            //    return "Computer Win";
            else if ((c1val < dval && p1val < dval) && (dval < 21 && c1val < 21 && p1val < 21))
                return "Dealer Win";
            //else if ((p1val < dval) && (dval < 21 && p1val < 21 && dval != c1val))
            //    return "Dealer Win";
            else if (dval == c1val)
                return "Dealer and Computer are Draw";
            else if (dval == p1val)
                return "Player and Dealer are Draw";
            else if (c1val == p1val)
                return "Player and Computer are Draw";
            else if (p1val == 21)
                return "Player Win";
            else if (c1val == 21)
                return "Computer Win";
            else if (dval == 21)
                return "Dealer Win";
           

            return " ";
        }

        static bool isAgain()
        {
            bool ismove = false;
            do
            {
                Console.WriteLine("\nDo you want to play again?\n[A] - Yes\n[B] - No");
                string uInt = Console.ReadLine().ToUpper();

                switch (uInt)
                {
                    case "A":
                        ismove = true;
                        return true;
                    case "B":
                        ismove = true;
                        return false;
                    default:
                        Console.WriteLine("\nInvalid Input.\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            } while (!ismove);

            return false;
        }

   }
}