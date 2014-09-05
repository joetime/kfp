//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KfpWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public Game()
        {
            this.MondayGuesses = new HashSet<MondayGuess>();
        }
    
        public int id { get; set; }
        public int week { get; set; }
        public System.DateTime kickoff { get; set; }
        public string homeTeamId { get; set; }
        public string awayTeamId { get; set; }
        public string favoriteTeamId { get; set; }
        public decimal spread { get; set; }
        public Nullable<int> homeScore { get; set; }
        public Nullable<int> awayScore { get; set; }
        public string winningTeamId { get; set; }
        public System.DateTime dateModified { get; set; }
    
        public virtual Team AwayTeam { get; set; }
        public virtual Team FavoriteTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team WinningTeam { get; set; }
        public virtual ICollection<MondayGuess> MondayGuesses { get; set; }
    }
}