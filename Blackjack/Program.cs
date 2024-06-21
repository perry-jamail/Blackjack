namespace Blackjack
{
    class Program
    {

        static Deck Deck = new Deck();
        static int playerValue;
        static int dealerValue;
        static List<int> playerDrawnValuesList;
        static List<int> dealerDrawnValuesList;
        static Card dealerSecondDraw;

        static void Main(string[] args)
        {
            WelcomeOptions();
        }

        public static void WelcomeOptions()
        {
            string initialChoice = "-1";
            while (initialChoice != "0")
            {
                Console.WriteLine("Welcome to Blackjack!\n\t1) Play\n\t2) Read Rules\n\t0) Quit");
                Console.Write("> ");
                initialChoice = Console.ReadLine();
                if (initialChoice == "1")
                {
                    PlayGame();
                } 
                else if (initialChoice == "2")
                {
                    Console.WriteLine(ReadRules());
                }
                else if (initialChoice == "0")
                {
                    Console.WriteLine("Goodbye!");
                }
                Console.WriteLine();
            }
        }

        public static string ReadRules()
        {
            return "Blackjack is an incredibly popular, exciting and easy card game to play. " +
                "The object is to have a hand with a total value higher than the dealer’s without going over 21. " +
                "Kings, Queens, Jacks and Tens are worth a value of 10. An Ace has the value of 1 or 11. " +
                "The remaining cards are counted at face value.\n\nYou are dealt two cards " +
                "whilst the dealer is dealt one face up. If your first 2 cards add up to 21 (an Ace and a " +
                "card valued 10), that’s Blackjack! If they have any other total, decide whether you wish to " +
                "‘hit’ or ‘stay’. You can continue to draw cards until you are happy with your hand.\n\nOnce " +
                "you have taken your turn the dealer draws another card for their hand. They must draw until they" +
                " reach 17 or more.\n\nOnce all cards are drawn, whoever has a total closer to 21 wins. If player's" +
                " hand and dealer's hand have an equal value, it's a tie.";
        }

        public static void PlayGame()
        {
            Console.WriteLine();

            Deck = new Deck();
            playerValue = 0;
            dealerValue = 0;
            playerDrawnValuesList = new List<int>();
            dealerDrawnValuesList = new List<int>();

            Card playerFirstDraw = Deck.Draw();
            playerValue += playerFirstDraw.Value;
            Card dealerFirstDraw = Deck.Draw();
            dealerValue += dealerFirstDraw.Value;
            Card playerSecondDraw = Deck.Draw();
            playerValue += playerSecondDraw.Value;
            dealerSecondDraw = Deck.Draw();
            dealerValue += dealerSecondDraw.Value;

            if (playerFirstDraw.Value == 11 && playerSecondDraw.Value == 11)
            {
                playerSecondDraw.Value = 1;
                playerValue -= 10;
            }
            else if (dealerFirstDraw.Value == 11 && dealerSecondDraw.Value == 11)
            {
                dealerSecondDraw.Value = 1;
                dealerValue -= 10;
            }

            playerDrawnValuesList.Add(playerFirstDraw.Value);
            playerDrawnValuesList.Add(playerSecondDraw.Value);
            dealerDrawnValuesList.Add(dealerFirstDraw.Value);
            dealerDrawnValuesList.Add(dealerSecondDraw.Value);

            if (playerValue == 21)
            {
                Console.WriteLine($"You have Blackjack with the {playerFirstDraw.Name} and the {playerSecondDraw.Name}! You won!");
            }
            else if (dealerValue == 21)
            {
                Console.WriteLine($"Dealer has Blackjack with the {dealerFirstDraw.Name} and the {dealerSecondDraw.Name}. You lost.");
            }
            else
            {
                Console.WriteLine($"You have drawn the {playerFirstDraw.Name} and the {playerSecondDraw.Name}," +
                $" putting you at a value of {playerValue}. The dealer's first card is the {dealerFirstDraw.Name}" +
                $" so the dealer's initial value is {dealerFirstDraw.Value}.");
                PlayerTurn();
            }  
        }

        public static void PlayerTurn()
        {

                string stayHitChoice = null;
                while (stayHitChoice != "stay")
                {
                    Console.WriteLine($"You are at {playerValue}, would you like to stay or hit?");
                    Console.Write("> ");
                    stayHitChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();

                    if (stayHitChoice == "hit")
                    {
                        Card playerDraw = Deck.Draw();
                        playerDrawnValuesList.Add(playerDraw.Value);
                        playerValue += playerDraw.Value;
                        
                        bool containsAce = playerDrawnValuesList.IndexOf(11) != -1;
                        while (playerValue > 21 && containsAce)
                        {
                            playerDrawnValuesList[playerDrawnValuesList.IndexOf(11)] = 1;
                            playerValue -= 10;
                        }

                        if (playerValue < 21)
                        {
                            Console.WriteLine($"You have drawn the {playerDraw.Name}. Your value is now at {playerValue}.");
                        }
                        else if (playerValue == 21)
                        {
                            Console.WriteLine($"You drew the {playerDraw.Name} and now have Blackjack! You won!");
                            stayHitChoice = "stay";
                        }
                        else
                        {
                            Console.WriteLine($"You have drawn the {playerDraw.Name}, putting your value over 21, at {playerValue}. You lost.");
                            stayHitChoice = "stay";
                        }
                    }
                    else if (stayHitChoice == "stay")
                    {
                        Console.WriteLine($"You stay at {playerValue}. Dealer's turn...\n");
                        DealerTurn();
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 'stay' or 'hit'. No other commands are valid at this time.");
                    }
                }
            }

        public static void DealerTurn()
        {
            string dealerStayHitChoice = null;

            if (dealerValue < 17)
            {
                dealerStayHitChoice = "hit";
                Console.Write($"Dealer's second draw is the {dealerSecondDraw.Name}, putting dealer's value at {dealerValue}. Dealer hits. (Press 'Enter' to continue)");
                Console.ReadLine();
            }
            else if (dealerValue >= 17 && dealerValue < 21 && dealerValue >= playerValue)
            {
                dealerStayHitChoice = "stay";
                Console.Write($"Dealer's second draw is the {dealerSecondDraw.Name}, putting dealer's value at {dealerValue}. Dealer stays. (Press 'Enter' to continue)");
                Console.ReadLine();
                Console.WriteLine();
                ChooseWinner();
            }
            else
            {
                dealerStayHitChoice = "hit";
                Console.Write($"Dealer's second draw is the {dealerSecondDraw.Name}, putting dealer's value at {dealerValue}. Dealer hits. (Press 'Enter' to continue)");
                Console.ReadLine();
            }

            while (dealerStayHitChoice != "stay")
            {
                if (dealerStayHitChoice == "hit")
                {
                    Card dealerDraw = Deck.Draw();
                    dealerDrawnValuesList.Add(dealerDraw.Value);
                    dealerValue += dealerDraw.Value;

                    bool containsAce = dealerDrawnValuesList.IndexOf(11) != -1;
                    while (dealerValue > 21 && containsAce)
                    {
                        dealerDrawnValuesList[dealerDrawnValuesList.IndexOf(11)] = 1;
                        dealerValue -= 10;
                    }

                    if (dealerValue < 17)
                    {
                        Console.Write($"Dealer drew the {dealerDraw.Name}. Dealer value is now at {dealerValue}. Dealer hits. (Press 'Enter' to continue)");
                        Console.ReadLine();
                    }
                    else if (dealerValue >= 17 && dealerValue < 21 && dealerValue >= playerValue)
                    {
                        Console.Write($"Dealer drew the {dealerDraw.Name}. Dealer value is now at {dealerValue}. Dealer stays. (Press 'Enter' to continue)\n");
                        dealerStayHitChoice = "stay";
                        Console.ReadLine();
                        ChooseWinner();
                    }
                    else if (dealerValue >= 17 && dealerValue < 21 && dealerValue < playerValue)
                    {
                        Console.Write($"Dealer drew the {dealerDraw.Name}. Dealer value is now at {dealerValue}. Dealer hits. (Press 'Enter' to continue)");
                        Console.ReadLine();
                    }
                    else if (dealerValue == 21)
                    {
                        Console.WriteLine($"Dealer drew the {dealerDraw.Name}, putting the dealer value at 21. Dealer Blackjack, you lost.");
                        dealerStayHitChoice = "stay";
                    }
                    else
                    {
                        Console.WriteLine($"Dealer drew the {dealerDraw.Name}, putting the dealer value above 21, at {dealerValue}. You won!");
                        dealerStayHitChoice = "stay";
                    }
                }
            }
        }

        public static void ChooseWinner()
        {
            if (playerValue > dealerValue)
            {
                Console.WriteLine($"You have {playerValue} and the dealer has {dealerValue}, you won!");
            }
            else if (playerValue == dealerValue)
            {
                Console.WriteLine($"You have {playerValue} and the dealer has {dealerValue}, you tied!");
            }
            else
            {
                Console.WriteLine($"You have {playerValue} and the dealer has {dealerValue}, you lost.");
            }
        }
    }
}
