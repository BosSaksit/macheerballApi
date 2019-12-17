using System;

namespace macheerballApi.Models
{

    public class Poll {
         public string  pollId   { get; set; }

         public string homeTeamName  { get; set; }

         public string awayTeamName  { get; set; }

         public DateTime? dateBall  { get; set; }

         public string timeBall  { get; set; }
         public string timeBallpoll  { get; set; }
         public string scoreBall  { get; set; }
         public string voteHomeTeam  { get; set; }
         public string voteAwayTeam  { get; set; }
         public string pollStatus  { get; set; }
         public string luckyName  { get; set; }
         public string luckyTel  { get; set; }


    }
}
