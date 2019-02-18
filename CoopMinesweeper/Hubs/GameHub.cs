﻿using CoopMinesweeper.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CoopMinesweeper.Hubs
{
    public class GameHub : Hub<IGameClient>
    {
        private readonly IGameService _gameService;

        public GameHub(IGameService gameService)
        {
            _gameService = gameService;
        }

        public string CreateGame(string hostSignal)
        {
            var newGameId = _gameService.CreateGame(Context.ConnectionId, hostSignal);
            return newGameId;
        }


        public async Task SendMessage(string user, string message)
        {
            // await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Caller.ReceiveMessage(user, message);
            //await Clients.Client("").ReceiveMessage(user, message);

            //string name = Context.User.Identity.Name;

            //foreach (var connectionId in _connections.GetConnections(who))
            //{
            //    Clients.Client(connectionId).addChatMessage(name + ": " + message);
            //}
            var a = Context.ConnectionId;
            var b = Context.User;
            var c = Context.UserIdentifier;
        }

        public override Task OnConnectedAsync()
        {
            var a = Context.ConnectionId;
            var b = Context.User;
            var c = Context.UserIdentifier;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var a = Context.ConnectionId;
            var b = Context.User;
            var c = Context.UserIdentifier;
            return base.OnDisconnectedAsync(exception);
        }
    }

    public interface IGameClient
    {
        Task ReceiveMessage(string user, string message);
        Task ReceiveClientSignal(string message);
    }
}
