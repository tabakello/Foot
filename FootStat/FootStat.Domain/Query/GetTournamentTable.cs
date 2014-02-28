using System.Collections.Generic;
using System.Linq;
using FootStat.Domain.Abstract;

namespace FootStat.Domain.Query
{
    public class GetTournamentTable {

        private readonly IRepository<TournamentTable> tRepository;

        public GetTournamentTable(IRepository<TournamentTable> tRepository) {
            this.tRepository = tRepository;
        }

        public IEnumerable<TournamentTable> GetTournametnTable(int tourneyId) {
            var tournamentTable = tRepository.GetAll().Where(p => p.TourneyId == tourneyId);
            return tournamentTable.OrderByDescending(p => p.Points).ThenByDescending(q => (q.Scored - q.Missed)).ThenByDescending(e => e.Scored);
        }
    }
}