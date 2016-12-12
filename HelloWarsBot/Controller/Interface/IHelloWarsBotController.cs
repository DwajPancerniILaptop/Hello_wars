using System.Web.Http;
using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.BotInfo;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.Controller.Interface
{
    public interface IHelloWarsBotController
    {
        [HttpPost]
        BotMove PerformNextMove(BotArenaInfo arenaInfo);

        [HttpGet]
        BotInfo Info();
    }
}
