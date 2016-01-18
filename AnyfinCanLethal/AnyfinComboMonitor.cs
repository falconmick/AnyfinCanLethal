using System;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyfinCanLethal
{
    public interface IAnyfinComboMonitor
    {
        void OnLoad();
        void OnUpdate();
    }

    public class AnyfinComboMonitor : IAnyfinComboMonitor
    {
        private List<CardCount> _cardCountList;
        private IGraveyardTracker _graveyardTracker;

        public AnyfinComboMonitor()
        {
            _graveyardTracker = new GraveyardTracker("Murloc");
        }
        
        public void OnLoad()
        {
            Log("Initilised");
        }

        public void OnUpdate()
        {
            // todo: use game events only to do this
            var newGraveyardState = _graveyardTracker.GetCardCounts().ToList();

            if (!newGraveyardState.CardListEquals(_cardCountList))
            {
                foreach(var cardList in newGraveyardState)
                {
                    Log(string.Format("CardId: {0}, Name: {1}, Count: {2}", cardList.Card.Id, cardList.Card.Name, cardList.Count));
                }

                UpdateCalculation(newGraveyardState);

                _cardCountList = newGraveyardState;
            }
        }

        

        private void Log(string item)
        {
            Logger.WriteLine(item, "Anyfin Combo Monitor");
        }

        private void UpdateCalculation(List<CardCount> cardCounts)
        {
            Log("Updating Calculation");
        }
    }
}
