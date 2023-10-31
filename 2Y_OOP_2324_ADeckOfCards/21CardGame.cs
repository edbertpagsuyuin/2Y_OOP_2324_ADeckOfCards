using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class _21CardGame
    {
        //private List<Card> Dhand = new List<Card>();
        //private List<Card> Phand = new List<Card>();
        //private List<Card> Chand = new List<Card>();
        //public void sethands(List<Card> D, List<Card> P, List<Card> C)
        //{
        //    Dhand = D;
        //    Phand = P;
        //    Chand = C;
        //}

        public int GetAceValue(List<Card> Hand)
        {
            int value = 0;
            for (int i = 0; i < Hand.Count; i++)
            {
                value += Hand[i].GetCardValue();
            }

            for (int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i].GetCardValue() == 1)
                {
                    if ((value - 1) + 11 > 17 || (value - 1) + 11 < 21)
                        Hand[i].SetNewValue(11);
                    value = value - 1 +  Hand[i].GetCardValue();
                }
            }

            return value;
        }
        public void DisplayHand(List<Card> Hand, int showcard)
        {
            int value = 0;
            for (int i = 0; i < Hand.Count; i++)
            {
                if (i < showcard)
                {
                    Console.WriteLine($"The Card is the {Hand[i].GetCardFace()} of {Hand[i].GetCardSuit()} with a value of {Hand[i].GetCardValue()}");
                    value += Hand[i].GetCardValue();
                }
                else
                {
                    Console.WriteLine($"The Card is the ???? of ???? with a value of ????");
                }
            }
            Console.WriteLine($"The Hand Value is {value}");

        }
        

        //public void DisplayHand(List<Card> Hand, int show, bool isplayer)
        //{
        //    int value = 0;
        //    for (int i = 0; i < Hand.Count; i++)
        //    {
        //        Console.WriteLine($"The Card is the {Hand[i].GetCardFace()} of {Hand[i].GetCardSuit()} with a value of {Hand[i].GetCardValue()}");
        //        value += Hand[i].GetCardValue();

        //        if (i < show)
        //        {
        //            if (Hand[i].GetCardFace() == "Ace")
        //            {
        //                if (!isplayer)
        //                {
        //                    if (cardAce(value))
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    bool isnum = false;
        //                    int num = 0;
        //                    do
        //                    {
        //                        Console.WriteLine("What Value do you want your ace to be, 1 or 11?");
        //                        isnum = int.TryParse(Console.ReadLine(), out num);
        //                        if (num == 1 || num == 11)
        //                            isnum = true;
        //                    } while (!isnum);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine($"The Card is the ??? of ??? with a value of ???");
        //        }
        //    }
        //    Console.WriteLine($"The Hand Value is {value}\n");
        //}

    }
}
