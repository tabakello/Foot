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

    public partial class MatchDetailType : IEntitie
    {
        public MatchDetailType()
        {
            this.MatchDetails = new HashSet<MatchDetail>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<MatchDetail> MatchDetails { get; set; }
    }
}
