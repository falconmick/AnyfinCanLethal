using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyfinCanLethal
{
    public static class CardCountExtensions
    {
        public static bool CardListEquals(this IEnumerable<CardCount> thisCardCountList, IEnumerable<CardCount> cardCountList)
        {
            bool listsAreEqual = false;

            // if both lists are null, they are equal
            if(thisCardCountList == null || cardCountList == null)
            {
                if(cardCountList == thisCardCountList)
                {
                    return true;
                }

                // else they are not
                return false;
            }

            // can only have equal lists if the counts are equal
            if (thisCardCountList.Count() == cardCountList.Count())
            {
                listsAreEqual = true;
                foreach (var cardCount in thisCardCountList)
                {
                    // find the matching cardCoutn inside the other list
                    var match = cardCountList.SingleOrDefault((item) =>
                        {
                            return item.Card.Id == cardCount.Card.Id;
                        });

                    // if it didn't exist or the counts don't match, lists are not equal
                    if (match == null || match.Count != cardCount.Count)
                    {
                        listsAreEqual = false;
                        break;
                    }
                }
            }

            return listsAreEqual;
        }
    }
}
