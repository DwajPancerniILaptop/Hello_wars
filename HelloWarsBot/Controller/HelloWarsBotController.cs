using System.Web.Http;
using HelloWarsBot.BusinessLogic;
using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Controller.Interface;
using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.Algorithm;
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
            var algorithmParameter = new AlgorithmParameter(arenaInfo.GameConfig);
            IHelloWarsBotService helloWarsBotController = new HelloWarsBotService(arenaInfo, algorithmParameter);
            return helloWarsBotController.CalculateNextMove();
        }
    }
}