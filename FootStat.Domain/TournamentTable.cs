//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FootStat.Domain.Abstract;

namespace FootStat.Domain
{
    using System;
    using System.Collections.Generic;

    public partial class TournamentTable : IEntitie
    {
        public int Id { get; set; }
        public int TourneyId { get; set; }
        public int SeasonId { get; set; }
        public int CommandId { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<int> Games { get; set; }
        public Nullable<int> Missed { get; set; }
        public Nullable<int> Scored { get; set; }
    
        public virtual Command Command { get; set; }
        public virtual Tourney Tourney { get; set; }
    }
}
