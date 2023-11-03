using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class CardGame21
    {
        private List<Card> hand = new List<Card>();
        private int handvalue = 0;
        private bool isStand = false;
        private int SearchAce = 0;

        public void SetHand(List<Card> cards)
        {
            hand = cards;
        }

        public int GetValuetoMain()
        {
            return handvalue;
        }
        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public void DisplayHand(bool isplayer, bool isdealer, bool isshowcards)
        {
            if (isplayer)
                Console.WriteLine("Player's Hand");
            else if (isdealer)
                Console.WriteLine("Dealer's Hand");
            else
                Console.WriteLine("Computer's Hand");

            for (int i = 0; i < hand.Count; i++)
            {
                if (i == 0 || isshowcards)
                {
                    if (hand[i].GetCardFace() == "Ace" && !isshowcards)
                        Console.WriteLine($"The Card is the {hand[i].GetCardFace()} of {hand[i].GetCardSuit()} with a value of 1");
                    else
                        Console.WriteLine($"The Card is the {hand[i].GetCardFace()} of {hand[i].GetCardSuit()} with a value of {hand[i].GetCardValue()}");
                }
                else
                    Console.WriteLine($"The Card is the ???? of ???? with a value of ????");
            }

            handvalue = GetValue();

            if (isshowcards)
            {
                if (isplayer)
                    Console.WriteLine($"Player's Hand Value is {handvalue}");
                else if (isdealer)
                    Console.WriteLine($"Dealer's Hand Value is {handvalue}");
                else
                    Console.WriteLine($"Computer's Hand Value is {handvalue}");
            }
        }

        public bool Stand(bool isplayer)
        {
            if (handvalue == 21)
            {
                if (isplayer)
                    Console.WriteLine("Player BlackJack");

                isStand = true;
                return true;
            }

            if (handvalue > 21)
            {
                if (isplayer)
                    Console.WriteLine("Player bust");

                isStand = true;
                return true;
            }

            if (isStand)
                return true;

            return false;
        }
        public bool Hit(bool isplayer, bool isdealer)
        {
            if (isplayer)
            {
                bool ismove = false;
                do
                {
                    if (handvalue == 21)
                        return false;

                    Console.WriteLine("\nDo you want to draw a card (Hit) or end the turn without drawing a card (Stand)?\n[A] - Hit\n[B] - Stand");
                    string uInt = Console.ReadLine().ToUpper();

                    switch (uInt)
                    {
                        case "A":
                            Console.WriteLine("Player Hits");
                            ismove = true;
                            return true;
                        case "B":
                            Console.WriteLine("PLayer Stands");
                            ismove = true;
                            isStand = true;
                            return false;
                        default:
                            Console.WriteLine("\nInvalid Input.\nPress any key to continue.");
                            Console.ReadKey();
                            break;
                    }
                } while (!ismove);
            }

            if (isdealer)
            {
                Console.Write("Dealer is thinking... ");
                Thread.Sleep(1200);
                if (handvalue < 17)
                {
                    Console.WriteLine("Dealer Hits");
                    return true;
                }

                Console.WriteLine("Dealer Stands");
                isStand = true;

                return false;
            }
            
            Console.Write("Computer is thinking... ");
            Thread.Sleep(1200);
            if (handvalue < 17)
            {
                Console.WriteLine("Computer Hits");
                return true;
            }

            Console.WriteLine("Computer Stands");
            isStand = true;
            return false;

        }

        private int GetValue()
        {
            int value = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                value += hand[i].GetCardValue();
            }

            return value;
        }

        public void Ace(bool isplayer)
        {
            for (int i = SearchAce; i < hand.Count; i++)
            {
                if (hand[i].GetCardValue() == 1)
                {
                    if (isplayer)
                    {
                        SetAceValue(hand[i]);
                    }
                    else
                    {
                        int tempval = GetValue() + 10;
                        if (tempval >= 17 && tempval <= 21)
                        {
                            hand[i].SetNewValue(11);
                        }
                    }
                }
            }
            SearchAce = hand.Count;
        }

        private void SetAceValue(Card card)
        {
            bool isvalid = false;
            int num = 0;
            do
            {
                Console.Write("\nWhat value do you want ace to be? 1 o 11: ");
                isvalid = int.TryParse(Console.ReadLine(), out num);
                if (num == 1 || num == 11)
                {
                    isvalid = true;
                    card.SetNewValue(num);
                    handvalue = handvalue - 1 + num;
                    Console.WriteLine($"Player's New Hand Value = {handvalue}");

                }
                else
                {
                    Console.WriteLine("Invalid Input\nPress any key to continue\n");
                    Console.ReadKey();
                    isvalid = false;
                }

            } while (!isvalid);
        }

        public void CheckWinner(bool isdealer, int opponentval)
        {
            string name1 = "Player";
            string name2 = "Dealer";

            if (isdealer)
            {
                name1 = "Dealer";
                name2 = "Player";
            }

            if (handvalue > 21 && opponentval > 21)
                Console.WriteLine($"No winner, {name1} and {name2} Bust");
            else if (handvalue > 21)
                Console.WriteLine($"{name1} Bust, {name2} Win");
            else if (opponentval > 21)
                Console.WriteLine($"{name2} Bust, {name1} Win");
            else if (handvalue == opponentval)
                Console.WriteLine($"No winner, {name1} and {name2} Draw");
            else if (handvalue == 21)
                Console.WriteLine($"{name1} Win");
            else if (opponentval == 21)
                Console.WriteLine($"{name2} Win");
            else if (handvalue > opponentval)
                Console.WriteLine($"{name1} Win");
            else if (opponentval > handvalue)
                Console.WriteLine($"{name2} Win");
        }

    }
}
