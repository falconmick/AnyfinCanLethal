using System;
using System.Collections.Generic;
using Hearthstone_Deck_Tracker;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyfinCanLethal
{
    public interface IGraveyardTracker
    {
        IEnumerable<CardCount> GetCardCounts();
    }

    public class GraveyardTracker : IGraveyardTracker
    {
        private static List<string> _raceTrackingList;

        public GraveyardTracker()
        {
            _raceTrackingList = null;
        }

        public GraveyardTracker(params string[] raceTrackingList)
        {
            _raceTrackingList = raceTrackingList.ToList();
        }

        public IEnumerable<CardCount> GetCardCounts()
        {
            var cardGraveyard = GetCardGraveyard();

            var cardGraveyardGroups = cardGraveyard.GroupBy(item => item);

            return cardGraveyardGroups.Select((cardGroup) =>
            {
                return new CardCount
                {
                    Card = cardGroup.Key,
                    Count = cardGroup.Count()
                };
            });
        }

        private IEnumerable<Hearthstone_Deck_Tracker.Hearthstone.Card> GetCardGraveyard()
        {
            var playerGraveyard = Hearthstone_Deck_Tracker.API.Core.Game.Player.Graveyard.Select((card) =>
            {
                return card.Entity.Card;
            });

            var oponentGraveyard = Hearthstone_Deck_Tracker.API.Core.Game.Opponent.Graveyard.Select((card) =>
            {
                return card.Entity.Card;
            });

            var combinedGraveyard = oponentGraveyard.Concat(playerGraveyard);

            return _raceTrackingList == null ? combinedGraveyard : combinedGraveyard.Where((graveyardItem) =>
            {
                return _raceTrackingList.Contains(graveyardItem.Race);
            });
        }
    }
}
