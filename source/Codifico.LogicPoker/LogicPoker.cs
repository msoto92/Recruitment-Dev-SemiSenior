namespace Codifico.LogicPoker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// Clase para manipular las cartas
    /// </summary>
    public class LogicPoker
    {
        /// <summary>
        /// listado de cartas 
        /// </summary>
        private static List<PokerCard> listCard = new List<PokerCard>();

        /// <summary>
        /// agrega las cartas a listado de cartas disponibles
        /// </summary>
        /// <param name="Card"> Carta para agregar</param>
        /// <returns></returns>
        public static bool AddPokerCard(PokerCard Card)
        {

            List<PokerCard> CardsFind = listCard
                                        .Where(x => x.Number == Card.Number && x.Symbol == Card.Symbol)
                                        .ToList();
            if (CardsFind == null || CardsFind.Count() <= 0)
            {
                listCard.Add(Card);
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Obtiene las 5 cartas para jugar.
        /// </summary>
        /// <returns></returns>
        public static PokerCard[] GetCards()
        {
            int sizeCard = 1;

            while (sizeCard <= 5)
            {
                PokerCard randomCard = PokerCard.GetCardRandom();

                if (AddPokerCard(randomCard))
                {
                    sizeCard++;
                }
            }

            return listCard.ToArray();

        }

    }
}
