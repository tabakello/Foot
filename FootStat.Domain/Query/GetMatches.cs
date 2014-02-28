using System;
using System.Collections.Generic;
using System.Linq;
using FootStat.Domain.Abstract;

namespace FootStat.Domain.Query {
    public class GetMatches {
        private readonly IRepository<Match> matches;
        private readonly int tourneyId;
        private readonly IRepository<Tourney> tourney;

        public GetMatches(IRepository<Match> matches, IRepository<Tourney> tourney, int tourneyId) {
            this.matches = matches;
            this.tourneyId = tourneyId;
            this.tourney = tourney;
        }

        /// <summary>
        /// Матчи следующего тура конкретного турнира. May be null
        /// </summary>
        public IEnumerable<Match> GetMatchesInNearestTour() {
            var countMatches = tourney.GetById(tourneyId).CountComannds / 2;
            return matches.GetAll().Where(p => p.TourneyId.Equals(tourneyId) && p.ResultId.Equals(4) && p.Date >= DateTime.Now).Take(countMatches).Any()
                ? matches.GetAll().Where(p => p.TourneyId.Equals(tourneyId) && p.ResultId.Equals(4) && p.Date >= DateTime.Now).Take(countMatches).OrderBy(q => q.Date)
                : matches.GetAll().Where(p => p.TourneyId.Equals(tourneyId)).OrderByDescending(p => p.Date).Take(countMatches);
        }

        /// <summary>
        /// Матчи следующего тура всех турниров. May be null
        /// </summary>
        public IEnumerable<Match> GetMatchesInNearestTourAllTourneys()
        {
            return matches.GetAll().Any(p => p.ResultId.Equals(4) && p.Date >= DateTime.Now)
                ? matches.GetAll().Where(p => p.ResultId.Equals(4) && p.Date >= DateTime.Now).OrderBy(q => q.Date)
                : matches.GetAll().OrderByDescending(p => p.Date);
        }

        /// <summary>
        /// The get matches by season.
        /// </summary>
        /// <param name="tourneyId">
        /// The tourney id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Match> GetMatchesByTourney()
        {
            return matches.GetAll().Where(p => p.TourneyId == tourneyId && p.SeasonId == 3);
        }
    }
}
