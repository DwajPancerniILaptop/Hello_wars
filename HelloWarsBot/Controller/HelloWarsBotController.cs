using System.Web.Http;
using HelloWarsBot.Controller.Interface;
using HelloWarsBot.Helpers;
using HelloWarsBot.Models;
using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.BotInfo;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.Controller
{
    public class HelloWarsBotController : ApiController, IHelloWarsBotController
    {
        [HttpGet]
        public BotInfo Info()
        {
            var botInfo = new BotInfo();
            botInfo.AvatarUrl = Url.Content("~/Content/BotImg.png");
            botInfo.Description = "test";
            botInfo.GameType = "TankBlaster";
            botInfo.Name = "name";
            return botInfo;
        }

        [HttpPost]
        public BotMove PerformNextMove(BotArenaInfo arenaInfo)
        {
            var aiService = new TankBlasterSimpleAIService(false, true, 99999, 8);
            var result = aiService.CalculateNextMove(arenaInfo);

            return result;
        }
    }
}