using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace War
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Card> cards;

        bool pick = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            // TODO: Add your initialization logic here
            cards = new List<Card>(52);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Shuffle Through club cards
            for (int i = 0; i < cards.Capacity / 4; i++)
            {
                String index = String.Concat("", (i + 1));
                if (i <= 8)
                    index = String.Concat("0", index);
                Card c = new Card(this.Content);
                c.LoadContent(String.Concat("c", index), "Clubs", index);
                cards.Add(c);
            }
            // Do the same for diamonds
            for (int i = 0; i < cards.Capacity / 4; i++)
            {
                String index = String.Concat("", (i + 1));
                if (i <= 8)
                    index = String.Concat("0", index);
                Card c = new Card(this.Content);
                c.LoadContent(String.Concat("d", index), "Diamonds", index);
                cards.Add(c);
            }
            // and Hearts
            for (int i = 0; i < cards.Capacity / 4; i++)
            {
                String index = String.Concat("", (i + 1));
                if (i <= 8)
                    index = String.Concat("0", index);
                Card c = new Card(this.Content);
                c.LoadContent(String.Concat("h", index), "Hearts", index);
                cards.Add(c);
            }
            // and Finally Spades
            for (int i = 0; i < cards.Capacity / 4; i++)
            {
                String index = String.Concat("", (i + 1));
                if (i <= 8)
                    index = String.Concat("0", index);
                Card c = new Card(this.Content);
                c.LoadContent(String.Concat("s", index), "Spades", index);
                cards.Add(c);
            }
        }
        //Puts the cards in a random location in the deck
        public List<T> ShuffleDeck<T>(T Value, List<T> cardList)
        {
            // Local Vars
            int I, R;
            bool Flag;
            Random Rand = new Random();
            // Local List of T type
            var deck = new List<T>();
            // Build Local List as big as passed in list and fill it with default value
            for (I = 0; I < cardList.Count; I++)
                deck.Add(Value);
            // Shuffle the list of cards
            for (I = 0; I < cardList.Count; I++)
            {
                Flag = false;
                // Loop until an empty spot is found
                do
                {
                    R = Rand.Next(0, cardList.Count);
                    if (deck[R].Equals(Value))
                    {
                        Flag = true;
                        deck[R] = cardList[I];
                    }
                } while (!Flag);
            }
            // Return the shuffled list
            return deck;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            int random1 = 0;
            int random2 = 1;
            //Only run once
            if (!pick)
            {
                Random random = new Random();
                cards = ShuffleDeck(cards[0], cards);
                random1 = random.Next(52);
                random2 = random.Next(52);
                cards = ShuffleDeck(cards[1], cards);
                pick = true;
            }
            //Draws each of the cards
            cards[random1].Draw(graphics.GraphicsDevice, 0);
            cards[random2].Draw(graphics.GraphicsDevice, 1);

            base.Draw(gameTime);
        }
    }
}
