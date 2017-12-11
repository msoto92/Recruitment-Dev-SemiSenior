namespace Codifico.LogicPoker
{
    // Author Miguel Soto Varela (miguelsotova21@gmail.com)
    // Version 20171211 10:15:00

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class PokerCard
    {
        #region Getter y Setter

        /// <summary>
        /// Obtiene o establece el simbolo de la carta
        /// </summary>
        public CardSymbol Symbol { get; set; }

        /// <summary>
        /// Numero de la carta (A = 14 )
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// nombre de la imagen de la carta
        /// </summary>
        public string ImageName { get; set; }

        #endregion

        #region Metodos y funciones

        /// <summary>
        /// Obtiene de forma random una carta.
        /// </summary>
        /// <returns></returns>
        public static PokerCard GetCardRandom()
        {
            Random RndCard = new Random();

            int Symbol = RndCard.Next(1, 4);
            int Number = RndCard.Next(2, 14);

            PokerCard Card = new PokerCard();
            Card.Number = Number;
            Card.Symbol = (CardSymbol)Symbol;
            Card.ImageName = GetImage(Card.Symbol, Card.Number);
            return Card;
        }


        public static string GetImage(CardSymbol Symbol, int Number)
        {
            string url = "{0}_of_{1}.png";

            switch (Number)
            {
                case 2:
                    url = url.Replace("{0}", "2");
                    break;
                case 3:
                    url = url.Replace("{0}", "3");
                    break;
                case 4:
                    url = url.Replace("{0}", "4");
                    break;
                case 5:
                    url = url.Replace("{0}", "5");
                    break;
                case 6:
                    url = url.Replace("{0}", "6");
                    break;
                case 7:
                    url = url.Replace("{0}", "7");
                    break;
                case 8:
                    url = url.Replace("{0}", "8");
                    break;
                case 9:
                    url = url.Replace("{0}", "9");
                    break;
                case 10:
                    url = url.Replace("{0}", "10");
                    break;
                case 11:
                    url = url.Replace("{0}", "jack");
                    break;
                case 12:
                    url = url.Replace("{0}", "queen");
                    break;
                case 13:
                    url = url.Replace("{0}", "king");
                    break;
                case 14:
                    url = url.Replace("{0}", "ace");
                    break;
                default:
                    throw new Exception("Not Found Image");
            }

            switch (Symbol)
            {
                case CardSymbol.Club:
                    url = url.Replace("{1}", "clubs");
                    break;
                case CardSymbol.Diamond:
                    url = url.Replace("{1}", "diamonds");
                    break;
                case CardSymbol.Heart:
                    url = url.Replace("{1}", "hearts");
                    break;
                case CardSymbol.Spade:
                    url = url.Replace("{1}", "spades");
                    break;
                default:
                    throw new Exception("Not Found Image");
            }

            return url;
        }

        #endregion
    }
}
