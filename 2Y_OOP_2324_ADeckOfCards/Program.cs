using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards doc = new DeckOfCards(true);

            //Card draw = doc.drawACard();
            //Console.WriteLine("Drawing a card");
            //Console.WriteLine($"The Card is the {draw.GetCardFace()} of {draw.GetCardSuit()} with a value of {draw.GetCardValue()}");
            //doc.DisplayDeck();

            //Console.WriteLine("\n\nDrawing a couple of cards");
            //List<Card> hand = new List<Card>();
            //hand = doc.drawACard(13);
            //foreach (Card c in hand)
            //{
            //    Console.WriteLine($"The Card is the {c.GetCardFace()} of {c.GetCardSuit()} with a value of {c.GetCardValue()}");
            //}

            PlayerHand player = new PlayerHand();
            PlayerHand computer = new PlayerHand();


            
            PlayerHand.dealerhand = doc.drawACard(2);
            computer.SetPlayerHand(doc.drawACard(2));
            player.SetPlayerHand(doc.drawACard(2));
            int showcard = 1;

            PlayerHand.DealerHand(showcard);
            if (PlayerHand.dealervalue < 17)
            {
                Console.WriteLine("Dealer Hit");
                showcard++;
                PlayerHand.dealerhand.Add(doc.drawACard());
            }
            else
            {
                Console.WriteLine("Computer Stand");
            }
            
            Console.WriteLine();
            computer.DisplayPlayerHand(true);
            int val = computer.GetPlayerValue();
            if (val < 17)
            {
                Console.WriteLine("Computer Hit");
                computer.AddCard(doc.drawACard());
            }
            else
            {
                Console.WriteLine("Computer Stand");
            }
            Console.WriteLine();
            player.isAce();
            player.DisplayPlayerHand(false);
            if (player.playernextmove())
            {
                player.AddCard(doc.drawACard());
            }
            Console.WriteLine();

            PlayerHand.DealerHand(showcard+1);
            Console.WriteLine();
            computer.DisplayPlayerHand(false);
            Console.WriteLine();
            player.DisplayPlayerHand(false);
            Console.WriteLine();

            Console.ReadKey();


            _21CardGame _21CG = new _21CardGame();
            List<Card> Dhand = doc.drawACard(2);
            List<Card> Phand = doc.drawACard(2);
            List<Card> Chand = doc.drawACard(2);
           
            int reveal = 1;
            while (true)
            {
                Console.Clear();
                int value = 0;
                value = _21CG.GetAceValue(Dhand);
                _21CG.DisplayHand(Dhand, reveal);
                if (value < 17)
                { 
                    Dhand.Add(doc.drawACard());
                    Console.WriteLine("Dealer hit");
                }
                else
                {
                    if (value < 21)
                        Console.WriteLine("Dealer stand");
                    else
                        Console.WriteLine("Dealer is busted");
                }
                Console.WriteLine();
                value = _21CG.GetAceValue(Chand);
                _21CG.DisplayHand(Chand, Chand.Count);
                if (value < 17)
                {
                    Chand.Add(doc.drawACard());
                    Console.WriteLine("Computer hit");
                }
                else
                {
                    if (value == 21)
                        Console.WriteLine("Computer won against dealer");
                    else if (value < 21)
                        Console.WriteLine("Computer stand");
                    else
                        Console.WriteLine("computer is busted");
                }
                Console.WriteLine();
                _21CG.DisplayHand(Phand, Phand.Count);

                //_21CG.DisplayHand(Phand);
                //_21CG.DisplayHand(Chand);
                //_21CG.DisplayHand(Dhand, 2);
                //_21CG.DisplayHand(Phand);
                //_21CG.DisplayHand(Chand);
                reveal++;

                Console.ReadKey();
               
            }
        }

    }
}
