
using System.Collections.Generic;
using FootStat.Domain.Abstract;
using FootStat.Domain.Query;

namespace FootStat.Domain.Concrete
{
    public class QueryRepository : IQueryRepository 
    {
        private readonly IRepository<Match> matchRepisitory;
        private readonly IRepository<Command> commandRepository;
        private readonly IRepository<Tourney> tourneyRepository;
        private readonly IRepository<TournamentTable> tournamentTableRepository;
        private readonly GetCommandGoals getCommandGoals;

        public QueryRepository(IRepository<Match> matchRepisitory, IRepository<Command> commandRepository, IRepository<Tourney> tourneyRepository, IRepository<TournamentTable> tournamentTableRepository)
        {
            this.matchRepisitory = matchRepisitory;
            this.commandRepository = commandRepository;
            this.tourneyRepository = tourneyRepository;
            this.tournamentTableRepository = tournamentTableRepository;
            getCommandGoals = new GetCommandGoals(matchRepisitory);
        }
        public int GetCountGoalsScoredAtHome(int commandId) {
            return getCommandGoals.GetCountGoalsScoredAtAway(commandId);
        }

        public int GetCountGoalsScoredAtAway(int commandId)
        {
            return getCommandGoals.GetCountGoalsScoredAtAway(commandId);
        }

        public int GetAllScoredGoals(int commandId)
        {
            return getCommandGoals.GetAllScoredGoals(commandId);
        }

        public int GetCountMissedGoalsAtHome(int commandId)
        {
            return getCommandGoals.GetCountMissedGoalsAtHome(commandId);
        }

        public int GetCountMissedGoalsAtAway(int commandId)
        {
            return getCommandGoals.GetCountMissedGoalsAtAway(commandId);
        }

        public int GetAllMissedGoals(int commandId)
        {
            return getCommandGoals.GetAllMissedGoals(commandId);
        }

        public int GetCommandPoints(int commandId, int tourneyId) {
            return new GetCommandPoints(matchRepisitory, commandId, tourneyId).GetPoints();
        }

        public IEnumerable<Command> GetActualCommandsByTourney(int tourneyId) {
            return new GetCommands(commandRepository, tourneyId).GetActualCommandsByTourney();
        }

        public int GetMathesCount(int commandId, int tourneyId) {
            return new GetCountMatches(matchRepisitory, commandId, tourneyId).GetMathesCount();
        }

        public IEnumerable<Match> GetMatchesInNearestTour(int tourneyId) {
            return new GetMatches(matchRepisitory, tourneyRepository, tourneyId).GetMatchesInNearestTour();
        }

        public IEnumerable<Match> GetMatchesByTourney(int tourneyId)
        {
            return new GetMatches(matchRepisitory, tourneyRepository, tourneyId).GetMatchesByTourney();
        }

        public IEnumerable<TournamentTable> GetTournamentTable(int tourneyId) {
            return new GetTournamentTable(tournamentTableRepository).GetTournametnTable(tourneyId);
        }
    }
}
