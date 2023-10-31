using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class PlayerHand
    {
        private List<Card> playerhand = new List<Card>();
        private int playervalue = 0;
        public static List<Card> dealerhand = new List<Card>();
        public static int dealervalue = 0;
        

        public void SetPlayerHand(List<Card> cards)
        {
            playerhand = cards;
        }

        public void AddCard(Card card)
        {
            playerhand.Add(card);
        }

        public void DisplayPlayerHand(bool isComp)
        {
            for (int i = 0; i < playerhand.Count; i++)
            {
                if (!isComp)
                {
                    Console.WriteLine($"The Card is the {playerhand[i].GetCardFace()} of {playerhand[i].GetCardSuit()} with a value of {playerhand[i].GetCardValue()}");
                }
                else
                {
                    if (playerhand[i].GetCardValue() == 1)
                    {
                        int tempval = GetPlayerValue(playerhand);
                        if ((tempval - 1) + 11 > 17 || (tempval - 1) + 11 < 21)
                            playerhand[i].SetNewValue(11);
                    }
                    Console.WriteLine($"The Card is the ???? of ???? with a value of ????");
                    //Console.WriteLine($"The Card is the {playerhand[i].GetCardFace()} of {playerhand[i].GetCardSuit()} with a value of {playerhand[i].GetCardValue()}");
                }
            }

            playervalue = GetPlayerValue(playerhand);
            if(!isComp)
                Console.WriteLine($"The Hand Value is {playervalue}");
            else
                //Console.WriteLine($"The Hand Value is {playervalue}");
                Console.WriteLine("The Hand Value is ???? ");
        }

        public int GetPlayerValue()
        {
            return playervalue;
        }

        public void isAce()
        {
            for (int i = 0; i < playerhand.Count; i++)
            {
                if (playerhand[i].GetCardValue() == 1)
                {
                    DisplayPlayerHand(false);
                    SetAceValue(playerhand[i]);
                }
            }

        }
        private void SetAceValue(Card card)
        {
            bool isvalid = false;
            int num = 0;
            do
            {
                Console.Write("What value do you want ace to be? 1 o 11: ");
                isvalid = int.TryParse(Console.ReadLine(), out num);
                if (num == 1 || num == 11)
                {
                    isvalid = true;
                    card.SetNewValue(num);
                }
                else
                {
                    Console.WriteLine("Invalid Input\nPress any key to continue");
                    Console.ReadKey();
                    isvalid = false;
                }

            } while (!isvalid);
        }
        
        public bool playernextmove()
        {
            bool ismove = false;
            do
            {
                Console.WriteLine("Do you want to draw a card (Hit) or end the turn without drawing a card (Stand)?\n[A] - Hit\n[B] - Stand");
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
                        Console.WriteLine("Invalid Input.\nPress any key to continue.");
                        Console.ReadKey();
                        ismove = false;
                        break;
                }
            } while (!ismove);

            return false;
        }

        private int GetPlayerValue(List<Card> Hand)
        {
            int tempval = 0;
            for (int i = 0; i < Hand.Count; i++)
            {
                tempval += Hand[i].GetCardValue();
            }

            return tempval;
        }

        public static void DealerHand(int reveal)
        {
            int tempdealerval = 0;
            for (int i = 0; i < dealerhand.Count; i++)
            {
                if (dealerhand[i].GetCardValue() == 1)
                {
                    int tempval = 0;
                    for (int j = 0; j < dealerhand.Count; j++)
                    {
                        tempval += dealerhand[i].GetCardValue();
                    }
                    if ((tempval - 1) + 11 > 17 || (tempval - 1) + 11 < 21)
                        dealerhand[i].SetNewValue(11);
                }
                if (i < reveal)
                {
                    Console.WriteLine($"The Card is the {dealerhand[i].GetCardFace()} of {dealerhand[i].GetCardSuit()} with a value of {dealerhand[i].GetCardValue()}");
                    tempdealerval += dealerhand[i].GetCardValue();
                    dealervalue += dealerhand[i].GetCardValue();

                }
                else
                {
                    Console.WriteLine($"The Card is the ???? of ???? with a value of ????");
                    dealervalue += dealerhand[i].GetCardValue();
                }
            }
            Console.WriteLine($"The Hand Value is {tempdealerval}");
        }

    }
}
