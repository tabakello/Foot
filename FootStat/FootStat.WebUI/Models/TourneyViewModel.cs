using System.Collections.Generic;
using FootStat.Domain;
using FootStat.Domain.Abstract;

namespace FootStat.WebUI.Models
{
    public class TourneyViewModel {
        private readonly int toyrneyId;
        public IEnumerable<Match> nearestMatches;
        public Tourney tourney;
        public IEnumerable<TournamentTable> tournamentTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="TourneyViewModel"/> class.
        /// </summary>
        /// <param name="tourneyId">
        /// The toyrney id.
        /// </param>
        /// <param name="queryRepository">
        /// The query repository.
        /// </param>
        /// <param name="tourneyRepository">
        /// The tourney repository.
        /// </param>
        /// <param name="commandRepository">
        /// The command Repository.
        /// </param>
        public TourneyViewModel(int tourneyId, IQueryRepository queryRepository, IRepository<Tourney> tourneyRepository,IRepository<Command> commandRepository ) {
            this.toyrneyId = tourneyId;
            tourney = tourneyRepository.GetById(tourneyId);
            nearestMatches = queryRepository.GetMatchesInNearestTour(toyrneyId);
            tournamentTable = queryRepository.GetTournamentTable(tourneyId);
        }
    }
}