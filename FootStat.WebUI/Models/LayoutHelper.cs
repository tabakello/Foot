using System.Collections.Generic;
using FootStat.Domain;
using System.Linq;

namespace FootStat.WebUI.Models
{
    public class LayoutHelper
    {
        public static IEnumerable<Tourney> tourneys() {
            return new SportStatEntities().Tourneys.Where(p => p.Id != 8 && p.Id != 9);
        } 
    }
}