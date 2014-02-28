using System;
using System.Collections.Generic;
using FootStat.Domain;
using FootStat.Domain.Abstract;
using System.Linq;

namespace FootStat.WebUI.Models {
    public class MatchDetailsViewModel {
        public Match match;
        public Tourney tourney;
        public IEnumerable<TournamentTable> tournamentTable;
        public int scoredGoalsAtHome;
        public int scoredGoalsAtAway;
        public int missedGoalsAtHome;
        public int missedGoalsAtAway;
        public Match LastGameHomeCommand;
        public Match LastGameAwayCommand;
        public int CountMatchesAtHome;
        public int CountMatchesAtAway;
        public IEnumerable<MatchDetail> matchDetails;
        

        public MatchDetailsViewModel(int matchId, IRepository<Match> matchRepository, IQueryRepository queryRepository, IRepository<Tourney> tourneyRepository, IRepository<MatchDetail> mDetailsRepository ) {
            match = matchRepository.GetById(matchId);
            tournamentTable = queryRepository.GetTournamentTable(match.TourneyId);
            tourney = tourneyRepository.GetById(match.TourneyId);
            scoredGoalsAtHome = queryRepository.GetCountGoalsScoredAtHome(match.Command.Id);
            scoredGoalsAtAway = queryRepository.GetCountGoalsScoredAtAway(match.Command1.Id);
            missedGoalsAtAway = queryRepository.GetCountMissedGoalsAtAway(match.Command1.Id);
            missedGoalsAtHome = queryRepository.GetCountMissedGoalsAtHome(match.Command.Id);
            LastGameAwayCommand = matchRepository.GetAll()
                                                 .Where(p => (p.Command1.Id == match.Command1.Id || p.Command.Id == match.Command1.Id) && p.Date < DateTime.Now)
                                                 .OrderByDescending(p => p.Date).FirstOrDefault();
            LastGameHomeCommand = matchRepository.GetAll()
                                                 .Where(p => (p.Command.Id == match.Command.Id || p.Command1.Id == match.Command.Id) && p.Date < DateTime.Now)
                                                 .OrderByDescending(p => p.Date).FirstOrDefault();

            CountMatchesAtHome = matchRepository.GetAll()
                .Count(p => p.Command.Id == match.Command.Id && p.ResultId != 4 && p.SeasonId == 3);
            CountMatchesAtAway = matchRepository.GetAll()
                .Count(p => p.Command1.Id == match.Command1.Id && p.ResultId != 4 && p.SeasonId == 3);

            matchDetails = mDetailsRepository.GetAll().Where(p => p.MatchId == match.Id);
        }
    }
}