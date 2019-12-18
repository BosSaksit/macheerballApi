using System;
namespace macheerballApi.Models
{
    public class Poll
    {
        public string PollId { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string DateBall { get; set; }
        public string TimeBall { get; set; }
        public string TimeEndPoll { get; set; }
        public string ScoreBall { get; set; }
        public User[] VoteHomeTeam { get; set; }
        public User[] VoteAwayTeam { get; set; }
        public string PollStatus { get; set; }
        public string LuckyName { get; set; }
        public string LuckyTel { get; set; }

    }
}
