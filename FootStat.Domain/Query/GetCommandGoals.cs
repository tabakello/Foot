using System.Collections.Generic;
using System.Linq;
using FootStat.Domain.Abstract;

namespace FootStat.Domain.Query
{
    public class GetCommandGoals {
        /// <summary>
        /// The _ match repisitory.
        /// </summary>
        private readonly IRepository<Match> matchRepisitory;

        
        /// <summary>
        /// The all matches.
        /// </summary>
        private readonly IEnumerable<Match> allMatches;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCommandGoals"/> class.
        /// </summary>
        /// <param name="matchRepository">
        /// The match Repository.
        
        public GetCommandGoals(IRepository<Match> matchRepository) 
        {
            matchRepisitory = matchRepository;
            allMatches = matchRepisitory.GetAll();
        }

        /// <summary>
        /// Количество забитых дома голов команды
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetCountGoalsScoredAtHome(int commandId) 
        {
            return allMatches.Where(p => p.FirstCommandId == commandId && p.SeasonId == 3).Sum(q => q.ScoreFirstCommandId);
        }

        /// <summary>
        /// Количество забитых голов команды на выезде
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetCountGoalsScoredAtAway(int commandId) 
        {
            return allMatches.Where(p => p.SecondCommandId == commandId && p.SeasonId == 3).Sum(q => q.ScoreSecondCommandId);
        }

        /// <summary>
        /// Количество забитых голов командой
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetAllScoredGoals(int commandId) 
        {
            return GetCountGoalsScoredAtAway(commandId) + GetCountGoalsScoredAtHome(commandId);
        }

        /// <summary>
        /// Пропущенных голов дома
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetCountMissedGoalsAtHome(int commandId) 
        {
            return allMatches.Where(p => p.FirstCommandId == commandId && p.SeasonId == 3).Sum(q => q.ScoreSecondCommandId);
        }

        /// <summary>
        /// Количество пропущенных голов на выезде
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetCountMissedGoalsAtAway(int commandId) 
        {
            return allMatches.Where(p => p.SecondCommandId == commandId && p.SeasonId == 3).Sum(q => q.ScoreFirstCommandId);
        }

        /// <summary>
        /// Количество пропущенных голов 
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetAllMissedGoals(int commandId) 
        {
            return GetCountMissedGoalsAtAway(commandId) + GetCountMissedGoalsAtHome(commandId);
        }
    }
}
