using System.Data.Entity;

namespace FootStat.Domain.Abstract
{
    public interface IDBContext
    {
        DbSet<Command> Commands { get; set; }
        DbSet<Forecast> Forecasts { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<Result> Results { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Tourney> Tourneys { get; set; }
        DbSet<TournamentTable> TournamentTables { get; set; }
        DbSet<MatchDetail> MatchDetails { get; set; }
        DbSet<MatchDetailType> MatchDetailTypes { get; set; }
        
    }
}
