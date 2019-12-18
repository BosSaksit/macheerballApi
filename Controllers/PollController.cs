using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using macheerballApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace macheerballApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        public static List<Poll> DataPoll = new List<Poll>
        {
            new Poll { PollId = "102101" ,HomeTeamName = "Japan" ,AwayTeamName = "thailand" , DateBall = "2019-12-14T16:05:28.607+07:00" , TimeBall = "2019-12-14T16:05:28.607+07:00" , TimeEndPoll = "2019-12-14T16:05:28.607+07:00", ScoreBall = "0-1" ,VoteHomeTeam = {} , VoteAwayTeam = {} , PollStatus = "เิด" , LuckyName = "ccc" , LuckyTel = "031231201"},
            new Poll { PollId = "102102" ,HomeTeamName = "Korea" ,AwayTeamName = "thailand" ,DateBall = "2019-12-14T16:05:28.607+07:00" , TimeBall = "2019-12-14T16:05:28.607+07:00" , TimeEndPoll = "2019-12-14T16:05:28.607+07:00" , ScoreBall = "1-1" ,VoteHomeTeam = {} , VoteAwayTeam = {} , PollStatus = "เปิด" , LuckyName = "vvv" , LuckyTel = "031001201"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Poll>> PollGetAllData()
        {
            return DataPoll.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Poll> PollGetByid(string id)
        {
            return DataPoll.FirstOrDefault(it => it.PollId == id.ToString());
        }

        [HttpPost]
        public Poll AddPoll([FromBody] Poll data)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Poll
            {
                PollId = id.ToString(),
                HomeTeamName = data.HomeTeamName,
                AwayTeamName = data.AwayTeamName,
                DateBall = data.DateBall,
                TimeBall = data.TimeBall,
                ScoreBall = "0-0",
                TimeEndPoll = data.TimeEndPoll,
                PollStatus = "เปิดโหวต"
,
            };
            DataPoll.Add(item);
            return item;
        }

        [HttpDelete("{id}")]
        public void DeletePoll(string id)
        {
            var delete = DataPoll.FirstOrDefault(it => it.PollId == id.ToString());
            DataPoll.Remove(delete);
        }

        [HttpGet("{id}/{score}")]
        public Poll SetScoreBall(string id, string score)
        {
            var getdataByid = DataPoll.FirstOrDefault(it => it.PollId == id.ToString());
            var item = new Poll
            {
                PollId = id.ToString(),
                HomeTeamName = getdataByid.HomeTeamName,
                AwayTeamName = getdataByid.AwayTeamName,
                DateBall = getdataByid.DateBall,
                ScoreBall = score.ToString(),
                TimeBall = getdataByid.TimeBall,
                TimeEndPoll = getdataByid.TimeEndPoll,
                PollStatus = "ปิดโหวต"
            };
            DataPoll.Add(item);
            DataPoll.Remove(getdataByid);
            return item;
        }

    }
}